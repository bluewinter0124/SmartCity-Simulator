using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemObject;
using SmartCitySimulator.Unit;
using SmartCitySimulator.SystemObject;

namespace SmartCitySimulator.SystemObject
{
    class VehicleManager
    {
        //車輛大小
        public int vehicleSize = 12;
        public int vehicleLength = 24;
        public int vehicleWidth = 12;

        public int vehicleSpeed = 60;
        public int vehicleRunPerSecond = 17;

        public Dictionary<int, Vehicle> vehicleList = new Dictionary<int,Vehicle>();

        public Dictionary<int, List<DrivingPath>> DrivingPathList; //RoadID -> List of DrivingPath
        public Dictionary<int, List<int>> DrivingPathTable;

        int generateVehicleSerialID;

        public void InitializeVehicleManager()
        {
            DestoryAllVehicles();
            generateVehicleSerialID = 0;
            DrivingPathList = new Dictionary<int, List<DrivingPath>>();
            DrivingPathTable = new Dictionary<int, List<int>>();
        }

        public void DestoryAllVehicles()
        {
            int vehicles = vehicleList.Count;

            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Destory " + vehicles + " Vehicles");

            for (int i = 0; i < vehicles; i++)
            {
                int id = vehicleList.Keys.ToArray()[0];
                DestoryVehicle(id);
            }
        }

        public void CreateVehicle(Road startRoad,int Weight)
        {
           //if (startRoad.getRoadLength() - ((startRoad.WaittingVehicles()-1) * SimulatorConfiguration.vehicleLength) > SimulatorConfiguration.vehicleLength) //不超出道路
           // {
                Vehicle tempVehicle = new Vehicle(generateVehicleSerialID, Weight, startRoad);

                generateVehicleSerialID++;

                Simulator.UI.AddVehicle(tempVehicle);

                vehicleList.Add(tempVehicle.vehicle_ID,tempVehicle);
            //}
        }

        public void DestoryVehicle(int vehicleID)
        {
            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Destory Vehicle ID : " + vehicleID);

            Simulator.UI.RemoveVehicle(vehicleList[vehicleID]);
            vehicleList.Remove(vehicleID);
        }

        public void SetVehicleSize(int size)
        {
            vehicleSize = size;
            vehicleLength = size * 2;
            vehicleWidth = size;
        }

        public void SetVehicleSpeedKMH(double KMH)
        {
            vehicleSpeed = System.Convert.ToInt16(KMH);
            double temp = Math.Round((KMH * 1000) / 3600, 0, MidpointRounding.AwayFromZero);
            vehicleRunPerSecond = System.Convert.ToInt16(temp);

            if(Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Vehicle run per second : " + vehicleRunPerSecond);

            Simulator.UI.SetVehicleRunTask(vehicleRunPerSecond);
        }

        public void AllVehicleRun()
        {
            for (int i = 0; i < Simulator.RoadManager.roadList.Count; i++)
            {

                for (int j = 0; j < Simulator.RoadManager.roadList[i].connectedRoadList.Count; j++) //連接路段的車先移動
                {
                    for (int k = 0; k < Simulator.RoadManager.roadList[i].connectedRoadList[j].vehicleList.Count; k++)
                    {
                        Simulator.RoadManager.roadList[i].connectedRoadList[j].vehicleList[k].Driving();
                    }
                }

                for (int x = 0; x < Simulator.RoadManager.roadList[i].vehicleList.Count; x++) // 該路段的車移動
                {
                    Simulator.RoadManager.roadList[i].vehicleList[x].Driving();
                }
            }
        }

        public void RefreshAllVehicleGraphic()
        {
            if (Simulator.vehicleGraphicFPS > 0)
            {
                Vehicle[] vehicles = vehicleList.Values.ToArray<Vehicle>();
                foreach (Vehicle vehicle in vehicles)
                {
                    vehicle.RefreshVehicleGraphic();
                }
            }
        }

        public void GenerateVehicle()
        {
            int generateVehicles;
            Random Random = new Random();
            int RandomNum;

            for (int i = 0; i < Simulator.RoadManager.GenerateVehicleRoadList.Count; i++)
            {
                generateVehicles = 0;
                RandomNum = Random.Next(999);
                int RoadID = Simulator.RoadManager.GenerateVehicleRoadList[i].roadID;
                if (DrivingPathList[RoadID].Count >= 1)
                {
                    if (Simulator.RoadManager.GenerateVehicleRoadList[i].vehicleGenerateLevel == 1)
                    {
                        if (RandomNum >= 992)
                            generateVehicles = 4;
                        else if (RandomNum >= 985)
                            generateVehicles = 3;
                        else if (RandomNum >= 909)
                            generateVehicles = 2;
                        else if (RandomNum >= 606)
                            generateVehicles = 1;
                    }
                    else if (Simulator.RoadManager.GenerateVehicleRoadList[i].vehicleGenerateLevel == 2)
                    {
                        if (RandomNum >= 999)
                            generateVehicles = 6;
                        else if (RandomNum >= 996)
                            generateVehicles = 5;
                        else if (RandomNum >= 981)
                            generateVehicles = 4;
                        else if (RandomNum >= 919)
                            generateVehicles = 3;
                        else if (RandomNum >= 735)
                            generateVehicles = 2;
                        else if (RandomNum >= 367)
                            generateVehicles = 1;

                    }
                    else if (Simulator.RoadManager.GenerateVehicleRoadList[i].vehicleGenerateLevel == 3)
                    {
                        if (RandomNum >= 999)
                            generateVehicles = 9;
                        else if (RandomNum >= 998)
                            generateVehicles = 8;
                        else if (RandomNum >= 995)
                            generateVehicles = 7;
                        else if (RandomNum >= 983)
                            generateVehicles = 6;
                        else if (RandomNum >= 947)
                            generateVehicles = 5;
                        else if (RandomNum >= 857)
                            generateVehicles = 4;
                        else if (RandomNum >= 676)
                            generateVehicles = 3;
                        else if (RandomNum >= 406)
                            generateVehicles = 2;
                        else if (RandomNum >= 135)
                            generateVehicles = 1;
                    }
                    else if (Simulator.RoadManager.GenerateVehicleRoadList[i].vehicleGenerateLevel == 4)
                    {
                        if (RandomNum >= 998)
                            generateVehicles = 10;
                        else if (RandomNum >= 996)
                            generateVehicles = 9;
                        else if (RandomNum >= 988)
                            generateVehicles = 8;
                        else if (RandomNum >= 966)
                            generateVehicles = 7;
                        else if (RandomNum >= 916)
                            generateVehicles = 6;
                        else if (RandomNum >= 815)
                            generateVehicles = 5;
                        else if (RandomNum >= 647)
                            generateVehicles = 4;
                        else if (RandomNum >= 423)
                            generateVehicles = 3;
                        else if (RandomNum >= 199)
                            generateVehicles = 2;
                        else if (RandomNum >= 49)
                            generateVehicles = 1;
                    }
                    else if (Simulator.RoadManager.GenerateVehicleRoadList[i].vehicleGenerateLevel == 5)
                    {
                        if (RandomNum >= 991)
                            generateVehicles = 10;
                        else if (RandomNum >= 978)
                            generateVehicles = 9;
                        else if (RandomNum >= 948)
                            generateVehicles = 8;
                        else if (RandomNum >= 889)
                            generateVehicles = 7;
                        else if (RandomNum >= 785)
                            generateVehicles = 6;
                        else if (RandomNum >= 628)
                            generateVehicles = 5;
                        else if (RandomNum >= 433)
                            generateVehicles = 4;
                        else if (RandomNum >= 238)
                            generateVehicles = 3;
                        else if (RandomNum >= 91)
                            generateVehicles = 2;
                        else if (RandomNum >= 18)
                            generateVehicles = 1;
                    }

                    if (generateVehicles != 0)
                    {
                        if (Simulator.TESTMODE)
                            Simulator.UI.AddMessage("System", "Road : " + Simulator.RoadManager.GenerateVehicleRoadList[i].roadID + " Generate " + generateVehicles + " Vehicles");

                        CreateVehicle(Simulator.RoadManager.GenerateVehicleRoadList[i], generateVehicles);
                    }

                }
            }
        }

        public void AddDrivingPath(DrivingPath DrivingPath)
        {
            int startRoadID = DrivingPath.getStartRoadID();

            if (!DrivingPathList.ContainsKey(startRoadID))
            {
                List<DrivingPath> temp = new List<DrivingPath>();
                DrivingPathList.Add(startRoadID, temp);
            }

            DrivingPathList[startRoadID].Add(DrivingPath);
            GenerateDrivingPathTable(startRoadID);

            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Add driving path to road " + startRoadID);
        }

        public void RemoveDrivingPath(int roadID,int pathNo,string pathName)
        {
            if (DrivingPathList[roadID][pathNo].GetName().Equals(pathName))
            {
                DrivingPathList[roadID].RemoveAt(pathNo);
                GenerateDrivingPathTable(roadID);
            }

            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Remove driving path : " + pathName);
        }

        public void GenerateDrivingPathTable(int RoadID)
        {
            List<DrivingPath> DrivingPaths = Simulator.VehicleManager.DrivingPathList[RoadID];
            List<int> table = new List<int>();

            for (int i = 0; i < DrivingPaths.Count; i++)
            { 
                int probability =  DrivingPaths[i].getProbability();
                for (int t = 0; t < probability; t++)
                {
                    table.Add(i);
                }
            }

            if (!DrivingPathTable.ContainsKey(RoadID))
            {
                DrivingPathTable.Add(RoadID, table);
            }
            else
            {
                DrivingPathTable[RoadID] = table;
            }

        }

        public DrivingPath GetDrivingPath(int RoadID)
        {
            int randomRange = DrivingPathTable[RoadID].Count;
            List<int> table = DrivingPathTable[RoadID];

            Random Random = new Random();
            int DrivingPathNo = DrivingPathTable[RoadID][Random.Next(randomRange)];

            return DrivingPathList[RoadID][DrivingPathNo];
        }
    }
}
