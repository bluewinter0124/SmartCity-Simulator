using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;
using System.Collections;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemObject;
using System.Drawing;
using System.Windows.Forms;

namespace SmartCitySimulator.SystemObject
{
    class RoadManager
    {
        public List<Road> roadList = new List<Road>();
        public List<Road> GenerateVehicleRoadList = new List<Road>();

        public void MapFormation()
        {
            GenerateCompleteRoadPath();
            GenerateCompleteMap();
            DeployLightToAllRoads();
        }

        public void InitializeRoadsManager()
        {
            RegisterToDataManager();
            GenerateVehicleRoadClear();
            InitializeRoads();
        }

        public void GenerateVehicleRoadClear()
        {
            GenerateVehicleRoadList.Clear();
        }

        public void InitializeRoads()
        {
            foreach (Road road in Simulator.RoadManager.roadList)
            {
                road.Initialize();
            }
        }

        public void GenerateCompleteRoadPath()
        {
            foreach (Road road in Simulator.RoadManager.roadList)
            {
                road.CalculateCompletePath();
            }
        }

        public void GenerateCompleteMap()
        {
            foreach (Road road in Simulator.RoadManager.roadList)
            {
                road.CalculateConnectPath();
            }
        }

        public void DeployLightToAllRoads()
        {
            foreach (Road road in Simulator.RoadManager.roadList)
            {
                if (road.connectedRoadIDList.Count > 0)
                {
                    Light light = new Light();
                    light.trafficLight_ID = Convert.ToInt32(road.roadID);

                    road.DeployLight(light);         //配置紅綠燈給road

                    road.DeployLight(light);         //配置紅綠燈給road
                    light.deployRoad = road;

                    if (road.roadPoints[road.roadPoints.Count - 1].Y == road.roadPoints[road.roadPoints.Count - 2].Y)
                        light.LightRotate(90);

                    light.setLocation(road.roadNode[road.roadNode.Count - 1]);

                    Simulator.UI.splitContainer_main.Panel2.Controls.Add(light);
                    Simulator.UI.splitContainer_main.Panel2.Controls.Add(light.ownCounter);
                    
                }
            }
        }

        public void RegisterToDataManager()
        {
            foreach (Road road in Simulator.RoadManager.roadList)
            {
                Simulator.DataManager.RegisterRoad(road.roadID);
            }
        }

        public Road GetRoadByID(int roadID)
        {
            for (int i = 0; i < roadList.Count; i++)
            {
                if (roadList[i].roadID == roadID)
                {
                    return roadList[i];
                }
            }
            return null;
        }

        public int CreateNewRoad()
        {
            int newRoadID = roadList.Count;
            Road newRoad = new Road(newRoadID);
            this.roadList.Add(newRoad);
            return newRoadID;
        }

        public void AddVehicleGenerateRoad(int roadID)
        {
            GetRoadByID(roadID).ChangeGenerateLevel(0);
            this.GenerateVehicleRoadList.Add(roadList[roadID]);
        }

        public void RemoveVehicleGenerateRoad(int roadID)
        {
            for (int i = 0; i < GenerateVehicleRoadList.Count; i++)
            {
                if (GenerateVehicleRoadList[i].roadID == roadID)
                {
                    GenerateVehicleRoadList.RemoveAt(i);
                    GetRoadByID(roadID).ChangeGenerateLevel(-1);
                }
            }
        }

        public void CheckVehicleGenerationSchedule()
        {
            string time = Simulator.getCurrentTime();
            for (int i = 0; i < GenerateVehicleRoadList.Count; i++)
            {
                GenerateVehicleRoadList[i].CheckVehicleGenerateSchedule(time); 
            }
        }

    }
}
