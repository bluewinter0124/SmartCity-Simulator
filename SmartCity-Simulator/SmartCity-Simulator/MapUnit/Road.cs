using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemObject;

namespace SmartCitySimulator.Unit
{
    public class Road
    {
        const int ROAD = 0, ROAD_NOLIGHT = 1, CONNECTED_ROAD = 2, EXIT_ROAD = 3;
        const int LIGHT_GREEN = 0, LIGHT_YELLOW = 1, LIGHT_RED = 2, LIGHT_TEMPRED = 3;

        //道路基本資料
        public List<Point> roadNode; //道路的節點
        public List<Point> roadPoints; //道路路徑，道路全部的點

        public List<int> connectedRoadIDList; // 所有連接道路的ID
        public List<Road> connectedRoadList; //連接路段的路徑
        public int connectTo = -1; //此條道路連接的路 -1為連接到路口

        public string roadName = "default"; //顯示用名稱
        public int roadID; //系統用ID
        public int locateIntersectionID;
        public int roadType = 0;

        Light ownLight;
        public int lightState = 0;
        public int order = 0;

        //車輛相關
        public int vehicleGenerateLevel = -1;
        public Dictionary<string, int> generateSchedule = new Dictionary<string, int>();
        public List<Vehicle> vehicleList = new List<Vehicle>();

        //統計相關
        public int passedVehicles = 0;
        public int arrivedVehicles = 0;
        public int currentVehicles = 0;
        public int waitingTimeOfAllVehicles = 0;
        public int waitingVehicles = 0;

        public Road(int roadID)
        {
            this.roadID = roadID;
            this.roadName = roadID+"";
            roadNode = new List<Point>();
            roadPoints = new List<Point>();
            connectedRoadIDList = new List<int>();
            connectedRoadList = new List<Road>();
        }

        public void Initialize()
        {
            vehicleList = new List<Vehicle>();
            for (int i = 0; i < connectedRoadList.Count; i++)
            {
                connectedRoadList[i].Initialize();
            }
            passedVehicles = 0;
            arrivedVehicles = 0;
            currentVehicles = 0;
            waitingTimeOfAllVehicles = 0;
            waitingVehicles = 0;

            vehicleGenerateLevel = -1;
            generateSchedule.Clear();
        }

        public void setRoadName(string name)
        {
            this.roadName = name;
        }

        public void addRoadNode(Point node)
        {
            roadNode.Add(node);
        }

        public void setRoadNode(List<Point> roadNodeList)
        {
            this.roadNode = roadNodeList;
        }

        public void addConnectRoad(int RoadID) //加入連接道路的ID
        {
            connectedRoadIDList.Add(RoadID);
        }

        public List<int> getConnectedRoadIDList()
        {
            return connectedRoadIDList;
        }

        public void CalculateCompletePath() //將道路所有的點都計算出來
        {
            for (int i = 0; i < roadNode.Count-1; i++)
            {
                CalculatePath(roadNode[i],roadNode[i + 1],roadPoints);
            }
        }

        public int getRoadLength()
        {
            return roadPoints.Count;
        }

        public List<Point> getRoadPoints() //取得這條路的路徑(points)
        {
            return roadPoints;
        }

        public Road getConnectPath(int connectRoadID) //取得指定的道路的連接路徑
        {
            for(int i=0;i<connectedRoadIDList.Count;i++) //搜尋是第幾個連接路段
            {
                Console.WriteLine(connectedRoadIDList[i]);
                if (connectedRoadIDList[i] == connectRoadID)
                {
                    return connectedRoadList[i];
                }
            }
            return connectedRoadList[0];
        }

        public void StoreToDataManager()
        {
            for (int i = 0; i < vehicleList.Count; i++)
            { 
                if(vehicleList[i].vehicle_state == vehicleList[i].CAR_WAITING)
                    vehicleList[i].UploadVehicleWaittingTime();
            }
            int cycleTime = Simulator.IntersectionManager.GetIntersectionByID(locateIntersectionID).lightConfigList[order].GetCycleTime();

            CycleRecord cycleRecord = new CycleRecord(cycleTime, arrivedVehicles, passedVehicles, waitingTimeOfAllVehicles, waitingVehicles);

            Simulator.DataManager.StoreCycleRecord(roadID, cycleRecord);
            
            // SimulatorConfiguration.UI.AddMessage("System", "Road " + roadID + ":" + data);

            waitingTimeOfAllVehicles = 0;
            waitingVehicles = 0;
            arrivedVehicles = 0;
            passedVehicles = 0;
        }

        public void CalculatePath(Point startPoint,Point endPoint,List<Point> Path) //計算兩點間路徑 包含起始點
        {
            // 計算道路長度
            double roadLength = Math.Sqrt((startPoint.X - endPoint.X) * (startPoint.X - endPoint.X) + (startPoint.Y - endPoint.Y) * (startPoint.Y - endPoint.Y));
            int roadPathPoints = (int)(roadLength); ;  

            //計算每單位X Y 的位移量
            double interval_X = (endPoint.X - startPoint.X ) / roadLength;
            double interval_Y = (endPoint.Y - startPoint.Y) / roadLength;

            //產生所有的點 不包含終點
            for (int i = 0; i < roadPathPoints; i++)
            {
                int pointX = (int)(startPoint.X + i * interval_X);
                int pointY = (int)(startPoint.Y + i * interval_Y);
                Path.Add(new Point(pointX, pointY));
                //Console.WriteLine("X,Y : " + pointX + " " + pointY);
            }

            //加上終點
            Path.Add(endPoint);
        }

        public void CalculateConnectPath() //計算所有相連道路間路徑
        {
            for (int i = 0; i < connectedRoadIDList.Count; i++)
            {
                Road newConnectRoad = new Road(i);

                int goalRoadID = connectedRoadIDList[i];
                newConnectRoad.connectTo = connectedRoadIDList[i];
                newConnectRoad.roadType = 2;

                string name = this.roadName + " -> " + Simulator.RoadManager.roadList[goalRoadID].roadName;
                newConnectRoad.setRoadName(name);

                List<Point> connectRoadNode = new List<Point>();
                connectRoadNode.Add(roadNode[roadNode.Count - 1]);
                connectRoadNode.Add(Simulator.RoadManager.roadList[goalRoadID].roadNode[0]);
                newConnectRoad.setRoadNode(connectRoadNode);

                newConnectRoad.CalculateCompletePath();

                connectedRoadList.Add(newConnectRoad);
            }
        }

        public void setLightState(int state,int second)
        {
            lightState = state;
            ownLight.setLightState(state);
            ownLight.setLightSecond(second);
        }

        public void DeployLight(Light light)
        {
            ownLight = light;
        }

        public void VehicleEnterRoad(Vehicle vehicle)
        {
            arrivedVehicles += vehicle.vehicle_weight;
            vehicleList.Add(vehicle);
        }

        public void VehicleExitRoad(Vehicle vehicle)
        {
            passedVehicles += vehicle.vehicle_weight;
            vehicleList.Remove(vehicle);
        }

        public int TotalVehicles_NoWeight()
        {
            return vehicleList.Count;
        }

        public int TotalVehicles_Weight()
        {
            int totalvehicles = 0;
            for (int x = 0; x < vehicleList.Count; x++)
            {
                totalvehicles += vehicleList[x].vehicle_weight;
            }
            return totalvehicles;
        }

        public int WaittingVehicles()
        {
            int waittingVehicles = 0;
            for (int x = 0; x < vehicleList.Count; x++)
            {
                if (vehicleList[x].vehicle_state == 3)
                    waittingVehicles++;
            }
                return waittingVehicles;
        }

        public List<Vehicle> getVehicleList()
        {
            return vehicleList;
        }

        public void ChangeGenerateLevel(int level)
        {
            if(Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Road " + roadID + " change generate level : " + vehicleGenerateLevel + " to "  +level);

            vehicleGenerateLevel = level;
        }
        public void AddGenerateSchedule(string time, int level)
        {
            if (generateSchedule.ContainsKey(time))
            {
                generateSchedule[time] = level;
                if (Simulator.TESTMODE)
                    Simulator.UI.AddMessage("System", "Road " + roadID + " change generate schedule : " + time + " level " + level);
            }
            else
            {
                generateSchedule.Add(time, level);
                if (Simulator.TESTMODE)
                    Simulator.UI.AddMessage("System", "Road " + roadID + " add generate schedule : " + time + " level " + level);
            }
        }

        public void RemoveGenerateSchedule(string time)
        {
            if (generateSchedule.ContainsKey(time))
            {
                generateSchedule.Remove(time);
                if (Simulator.TESTMODE)
                    Simulator.UI.AddMessage("System", "Road " + roadID + " remove generate schedule : " + time);
            }
        }

        public void CheckVehicleGenerateSchedule(string time)
        {
            if (generateSchedule.ContainsKey(time))
            {
                int level = generateSchedule[time];
                ChangeGenerateLevel(level);
            }
        }
    }
}
