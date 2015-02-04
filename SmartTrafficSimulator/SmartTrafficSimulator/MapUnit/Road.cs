using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartTrafficSimulator.GraphicUnit;
using SmartTrafficSimulator.SystemObject;
using System.Xml;

namespace SmartTrafficSimulator.Unit
{
    public class Road
    {
        const int ROAD = 0, ROAD_NOLIGHT = 1, CONNECTED_ROAD = 2, EXIT_ROAD = 3;
        const int LIGHT_GREEN = 0, LIGHT_YELLOW = 1, LIGHT_RED = 2, LIGHT_TEMPRED = 3;

        //Road info
        public List<Point> roadNode; //composed node of the road (e.g. straight road has 2 nodes, L-shaped road has 4 nodes)  
        public List<Point> roadPoints; //composed point(Coordinates) of the road, generated from nodes

        public List<int> connectedRoadIDList; // list of connected road ID
        public List<Road> connectedRoadList; //list of connected road
        public int connectTo = -1; //the connected road of this road,-1 = connect to intersection

        public string roadName = "default"; //road Name
        public int roadID; //system ID
        public int locateIntersectionID = -1;
        public int roadType = 0;
        public int order = 0;


        Light ownLight;
        public int lightState = 0;
        public int lightSecond = 0;

        //Vehicle on the road
        public List<Vehicle> onRoadVehicleList = new List<Vehicle>();

        //Vehicle Generate 
        public int vehicleGenerateLevel = -1;
        public Dictionary<string, int> generateSchedule = new Dictionary<string, int>();
        
        //data
        public int passedVehicles = 0;
        public int arrivedVehicles = 0;
        public int currentVehicles = 0;
        int waitingTimeOfAllVehicles = 0;
        public int waitingVehicles = 0;
        public int previousCycleRemainVehicles = 0;

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
            onRoadVehicleList = new List<Vehicle>();
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

        public void SetRoadName(string name)
        {
            this.roadName = name;
        }

        public void AddRoadNode(Point node)
        {
            roadNode.Add(node);
        }

        public void SetRoadNode(List<Point> roadNodeList)
        {
            this.roadNode = roadNodeList;
        }

        public void AddConnectRoad(int RoadID) 
        {
            connectedRoadIDList.Add(RoadID);
        }

        public List<int> GetConnectedRoadIDList()
        {
            return connectedRoadIDList;
        }

        public void CalculateCompletePath() //Generate points from nodes
        {
            for (int i = 0; i < roadNode.Count-1; i++)
            {
                CalculatePath(roadNode[i],roadNode[i + 1],roadPoints);
            }
        }

        public int GetRoadLength()
        {
            return roadPoints.Count;
        }

        public List<Point> GetRoadPoints() //取得這條路的路徑(points)
        {
            return roadPoints;
        }

        public Road GetConnectPath(int connectRoadID) //取得指定的道路的連接路徑
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

        public void AddWaitingTimeOfAllVehicles(int time)
        {
            waitingTimeOfAllVehicles += time;
        }

        public void StoreRecord()
        {
            for (int i = 0; i < onRoadVehicleList.Count; i++)
            { 
                if(onRoadVehicleList[i].vehicle_state == onRoadVehicleList[i].CAR_WAITING)
                {
                    waitingVehicles += onRoadVehicleList[i].vehicle_weight;
                }
                onRoadVehicleList[i].UploadVehicleWaittingTime();
            }
            int cycleTime = Simulator.IntersectionManager.GetIntersectionByID(locateIntersectionID).signalConfigList[order].GetCycleTime();

            CycleRecord cycleRecord = new CycleRecord(cycleTime,previousCycleRemainVehicles,arrivedVehicles, passedVehicles, waitingTimeOfAllVehicles, waitingVehicles);

            Simulator.DataManager.PutCycleRecord(roadID, cycleRecord);
            
            waitingTimeOfAllVehicles = 0;
            waitingVehicles = 0;
            arrivedVehicles = 0;
            passedVehicles = 0;
            previousCycleRemainVehicles = GetCurrentVehicles_Weight();

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

                string name = this.roadName + " -> " + Simulator.RoadManager.GetRoadList()[goalRoadID].roadName;
                newConnectRoad.SetRoadName(name);

                List<Point> connectRoadNode = new List<Point>();
                connectRoadNode.Add(roadNode[roadNode.Count - 1]);
                connectRoadNode.Add(Simulator.RoadManager.GetRoadList()[goalRoadID].roadNode[0]);
                newConnectRoad.SetRoadNode(connectRoadNode);

                newConnectRoad.CalculateCompletePath();

                connectedRoadList.Add(newConnectRoad);
            }
        }
        public void DeployLight(Light light)
        {
            ownLight = light;
        }
        public void setLightState(int state, int second)
        {
            lightState = state;
            lightSecond = second;
            RefreshSignalGraphic();
        }

        public void RefreshSignalGraphic()
        {
            if (Simulator.trafficSignalCountdownDisplay)
            {
                ownLight.setLightState(lightState);
                ownLight.setLightSecond(lightSecond);
            }
        }

        public void VehicleEnterRoad(Vehicle vehicle)
        {
            arrivedVehicles += vehicle.vehicle_weight;
            onRoadVehicleList.Add(vehicle);
        }

        public void VehicleExitRoad(Vehicle vehicle)
        {
            passedVehicles += vehicle.vehicle_weight;
            onRoadVehicleList.Remove(vehicle);
        }

        public int GetCurrentVehicles_NoWeight()
        {
            return onRoadVehicleList.Count;
        }

        public int GetCurrentVehicles_Weight()
        {
            int totalvehicles = 0;
            for (int x = 0; x < onRoadVehicleList.Count; x++)
            {
                totalvehicles += onRoadVehicleList[x].vehicle_weight;
            }
            return totalvehicles;
        }

        public int GetWaittingVehicles()
        {
            int waittingVehicles = 0;
            for (int x = 0; x < onRoadVehicleList.Count; x++)
            {
                if (onRoadVehicleList[x].vehicle_state == 3)
                    waittingVehicles++;
            }
                return waittingVehicles;
        }

        public List<Vehicle> getVehicleList()
        {
            return onRoadVehicleList;
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
