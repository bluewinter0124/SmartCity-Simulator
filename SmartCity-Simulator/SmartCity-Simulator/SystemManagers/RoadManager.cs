﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;
using System.Collections;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemManagers;
using System.Drawing;
using System.Windows.Forms;

namespace SmartCitySimulator.SystemManagers
{
    class RoadManager
    {
        public List<Road> roadList = new List<Road>();
        public List<Road> GenerateCarRoadList = new List<Road>();

        public void MapFormation()
        {
            GenerateCompleteRoadPath();
            GenerateCompleteMap();
            DeployLightToAllRoads();
        }

        public void InitializeRoadsManager()
        {
            RegisterToDataManager();
            GenerateCarRoadClear();
            InitializeRoads();
        }

        public void GenerateCarRoadClear()
        {
            GenerateCarRoadList.Clear();
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
                if (road.connectedRoadID.Count > 0)
                {
                    Light light = new Light();
                    light.trafficLight_ID = Convert.ToInt32(road.roadID);

                    road.DeployLight(light);         //配置紅綠燈給road

                    road.DeployLight(light);         //配置紅綠燈給road
                    light.deployRoad = road;

                    if (road.roadPath[road.roadPath.Count - 1].Y == road.roadPath[road.roadPath.Count - 2].Y)
                        light.LightRotate(90);

                    light.setLocation(road.roadNode[road.roadNode.Count - 1]);

                    Simulator.UI.splitContainer1.Panel2.Controls.Add(light);
                    Simulator.UI.splitContainer1.Panel2.Controls.Add(light.ownCounter);
                    
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

        public void AddCarGenerateRoad(int roadID)
        {
            GetRoadByID(roadID).SetGenerationLevel(0);
            this.GenerateCarRoadList.Add(roadList[roadID]);
        }

        public void RemoveCarGenerateRoad(int roadID)
        {
            for (int i = 0; i < GenerateCarRoadList.Count; i++)
            {
                if (GenerateCarRoadList[i].roadID == roadID)
                {
                    GenerateCarRoadList.RemoveAt(i);
                    GetRoadByID(roadID).SetGenerationLevel(-1);
                }
            }
        }

        public void CheckCarGenerationSchedule()
        {
            string time = Simulator.getCurrentTime();
            Simulator.UI.AddMessage("System", "Time " + time);
            for (int i = 0; i < GenerateCarRoadList.Count; i++)
            {
                GenerateCarRoadList[i].CheckCarGenerationSchedule(time); 
            }
        }

    }
}