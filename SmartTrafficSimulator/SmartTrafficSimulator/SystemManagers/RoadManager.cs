using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.SystemObject;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace SmartTrafficSimulator.SystemManagers
{
    class RoadManager
    {
        List<Road> roadList = new List<Road>();
        List<Road> GenerateVehicleRoadList = new List<Road>();

        public void InitializeRoads_Map()
        {
            GenerateCompleteRoadPath();
            GenerateCompleteMap();
            RoadsDeployLight();
        }

        public void InitializeRoads_Simulation()
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

        public List<Road> GetRoadList()
        {
            return roadList;
        }
        public List<Road> GetGenerateVehicleRoadList()
        {
            return GenerateVehicleRoadList;
        }

        public void GenerateCompleteRoadPath()
        {
            foreach (Road road in Simulator.RoadManager.roadList)
            {
                road.GenerateCompleteRoad();
            }
        }

        public void GenerateCompleteMap()
        {
            foreach (Road road in Simulator.RoadManager.roadList)
            {
                road.GenerateIntermediateRoad();
            }
        }

        public void RoadsDeployLight()
        {
            foreach (Road road in Simulator.RoadManager.roadList)
            {
                road.DeployLight();
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

        public Road CreateNewRoad()
        {
            int newRoadID = roadList.Count;
            Road newRoad = new Road(newRoadID);
            this.roadList.Add(newRoad);
            return newRoad;
        }

        public void AddVehicleGenerateRoad(int roadID)
        {
            GetRoadByID(roadID).SetGenerateLevel(0);
            this.GenerateVehicleRoadList.Add(roadList[roadID]);
        }

        public void RemoveVehicleGenerateRoad(int roadID)
        {
            for (int i = 0; i < GenerateVehicleRoadList.Count; i++)
            {
                if (GenerateVehicleRoadList[i].roadID == roadID)
                {
                    GenerateVehicleRoadList.RemoveAt(i);
                    GetRoadByID(roadID).SetGenerateLevel(-1);
                }
            }
        }

        public void CheckVehicleGenerationSchedule()
        {
            string time = Simulator.getCurrentTime_Format();
            for (int i = 0; i < GenerateVehicleRoadList.Count; i++)
            {
                GenerateVehicleRoadList[i].CheckVehicleGenerateSchedule(time); 
            }
        }

    }
}
