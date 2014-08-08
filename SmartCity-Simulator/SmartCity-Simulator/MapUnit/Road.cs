using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemUnit;

namespace SmartCitySimulator.Unit
{
    public class Road
    {
        const int ROAD = 0, ROAD_NOLIGHT = 1, CONNECTED_ROAD = 2, EXIT_ROAD = 3;
        const int LIGHT_GREEN = 0, LIGHT_YELLOW = 1, LIGHT_RED = 2, LIGHT_TEMPRED = 3;

        //道路基本資料
        public List<Point> roadNode; //道路的節點
        public List<Point> roadPath; //道路路徑，道路全部的點

        public List<int> connectedRoadID; // 所有連接道路的ID
        public List<Road> connectedPathList; //連接路段的路徑
        public int connectTo = -1; //此條道路連接的路 -1為連接到路口

        public string roadName = "default"; //顯示用名稱
        public int roadID; //系統用ID
        public int locateIntersectionID;
        public int roadType = 0;

        Light ownLight;
        public int lightState = 0;
        public int order = 0;

        //車輛相關
        public int carGenerationRate = -1;
        public List<Car> carList;
        public int waittingCars = 0;

        //統計相關
        public int passedCars = 0;
        public int arrivedCars = 0;
        public int currentCars = 0;
        public int WaitingTimeOfAllCars = 0;
        public int WaitingCars = 0;
        public List<string> historyData = new List<string>();

        public Road(int roadID)
        {
            this.roadID = roadID;
            this.roadName = roadID+"";
            roadNode = new List<Point>();
            roadPath = new List<Point>();
            connectedRoadID = new List<int>();
            connectedPathList = new List<Road>();
            carList = new List<Car>();
        }

        public void setRoadName(string name)
        {
            this.roadName = name;
        }

        public int RoadLength() 
        {
            return roadPath.Count;
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
            connectedRoadID.Add(RoadID);
        }

        public void CalculateCompletePath() //將道路所有的點都計算出來
        {
            for (int i = 0; i < roadNode.Count-1; i++)
            {
                CalculatePath(roadNode[i],roadNode[i + 1],roadPath);
            }
        }

        public int getRoadLength()
        {
            return roadPath.Count;
        }

        public List<Point> getRoadPath() //取得這條路的路徑
        {
            return roadPath;
        }

        public Road getConnectPath(int connectRoadID) //取得指定的道路的連接路徑
        {
            for(int i=0;i<connectedRoadID.Count;i++) //搜尋是第幾個連接路段
            {
                Console.WriteLine(connectedRoadID[i]);
                if (connectedRoadID[i] == connectRoadID)
                {
                    return connectedPathList[i];
                }
            }
            return connectedPathList[0];
        }

        public void StoreToDataManager()
        {
            for (int i = 0; i < carList.Count; i++)
            { 
                if(carList[i].car_state == carList[i].CAR_WAITING)
                    carList[i].UploadCarWaittingTime();
            }

            int[] LightSetting = Simulator.IntersectionManager.GetIntersectionByID(locateIntersectionID).LightSettingList[order];

            int cycleTime = (LightSetting[0] + LightSetting[1] + LightSetting[2]);

            CycleRecord cycleRecord = new CycleRecord(cycleTime, arrivedCars, passedCars, WaitingTimeOfAllCars, WaitingCars);

            Simulator.DataManager.StoreRecord(roadID, cycleRecord);
            
            // SimulatorConfiguration.UI.AddMessage("System", "Road " + roadID + ":" + data);

            WaitingTimeOfAllCars = 0;
            WaitingCars = 0;
            arrivedCars = 0;
            passedCars = 0;
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
            for (int i = 0; i < connectedRoadID.Count; i++)
            {
                Road newConnectRoad = new Road(i);

                int goalRoadID = connectedRoadID[i];
                newConnectRoad.connectTo = connectedRoadID[i];
                newConnectRoad.roadType = 2;

                string name = this.roadName + " -> " + Simulator.RoadManager.roadList[goalRoadID].roadName;
                newConnectRoad.setRoadName(name);

                List<Point> connectRoadNode = new List<Point>();
                connectRoadNode.Add(roadNode[roadNode.Count - 1]);
                connectRoadNode.Add(Simulator.RoadManager.roadList[goalRoadID].roadNode[0]);
                newConnectRoad.setRoadNode(connectRoadNode);

                newConnectRoad.CalculateCompletePath();

                connectedPathList.Add(newConnectRoad);
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

        public void CarEnterRoad(Car car)
        {
            arrivedCars += car.car_weight;
            carList.Add(car);
        }

        public void CarExitRoad(Car car)
        {
            passedCars += car.car_weight;
            carList.Remove(car);
        }

        public int TotalCars_NoWeight()
        {
            return carList.Count;
        }

        public int TotalCars_Weight()
        {
            int totalcars = 0;
            for (int x = 0; x < carList.Count; x++)
            {
                totalcars += carList[x].car_weight;
            }
            return totalcars;
        }

        public int WaittingCars()
        {
            waittingCars = 0;
            for (int x = 0; x < carList.Count; x++)
            {
                if (carList[x].car_state == 3)
                    waittingCars++;
            }
                return waittingCars;
        }

        public List<string> getHistoryData()
        {
            return historyData;
        }

        public List<Car> getCarList()
        {
            return carList;
        }

    }
}
