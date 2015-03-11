using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartTrafficSimulator.GraphicUnit;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.Unit;

namespace SmartTrafficSimulator.SystemObject
{
    class VehicleManager
    {
        //Vehicle related
        public int vehicleSize = 12;
        public int vehicleLength = 24;
        public int vehicleWidth = 12;
        public int vehicleRunPerSecond = 5;
        public int vehicleMaxSpeed = 80;
        public int vehicleAccelerationFactor = 2;
        public int vehicleBrakeFactor = 3;
        public int vehicleSafeTime = 2;


        public Dictionary<int, Vehicle> vehicleList = new Dictionary<int,Vehicle>();

        Dictionary<int, Dictionary<string,DrivingPath>> DrivingPathList; //RoadID -> List of DrivingPath
        Dictionary<int, List<string>> DrivingPathTable;

        int vehicleGenerateSerialID;

        public void InitializeVehicleManager()
        {
            DestoryAllVehicles();
            vehicleGenerateSerialID = 0;
            DrivingPathList = new Dictionary<int, Dictionary<string, DrivingPath>>();
            DrivingPathTable = new Dictionary<int, List<string>>();
            Simulator.UI.SetVehicleRunTask(vehicleRunPerSecond);
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
                Vehicle tempVehicle = new Vehicle(vehicleGenerateSerialID, Weight, startRoad);

                vehicleGenerateSerialID++;

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
            vehicleMaxSpeed = System.Convert.ToInt16(KMH);
            //vehicleRunPixelPerTime = Math.Round(((KMH * 1000) / 3600) / vehicleRunPerSecond ,1, MidpointRounding.AwayFromZero);

            if(Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Vehicle max speed  : " + KMH + "KM/H");

            Simulator.UI.SetVehicleRunTask(vehicleRunPerSecond);
        }

        public void SetVehicleAccelerationFactor(int factor)
        {
            this.vehicleAccelerationFactor = factor;
        }
        public void SetVehicleBrakeFactor(int factor)
        {
            this.vehicleBrakeFactor = factor;
        }

        public void AllVehicleRun()
        {
            for (int i = 0; i < Simulator.RoadManager.GetRoadList().Count; i++)
            {

                for (int j = 0; j < Simulator.RoadManager.GetRoadList()[i].connectedRoadList.Count; j++) //連接路段的車先移動
                {
                    for (int k = 0; k < Simulator.RoadManager.GetRoadList()[i].connectedRoadList[j].onRoadVehicleList.Count; k++)
                    {
                        Simulator.RoadManager.GetRoadList()[i].connectedRoadList[j].onRoadVehicleList[k].Driving();
                    }
                }

                for (int x = 0; x < Simulator.RoadManager.GetRoadList()[i].onRoadVehicleList.Count; x++) // 該路段的車移動
                {
                    Simulator.RoadManager.GetRoadList()[i].onRoadVehicleList[x].Driving();
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
                    try
                    {
                        vehicle.RefreshVehicleGraphic();
                    }
                    catch (NullReferenceException nre)
                    { }

                }
            }
        }

        public void GenerateVehicle()
        {
            int generateVehicles;
            Random Random = new Random();
            int RandomNum;

            for (int i = 0; i < Simulator.RoadManager.GetGenerateVehicleRoadList().Count; i++)
            {
                generateVehicles = 0;
                RandomNum = Random.Next(999);
                int RoadID = Simulator.RoadManager.GetGenerateVehicleRoadList()[i].roadID;
                if (DrivingPathList[RoadID].Count >= 1)
                {
                    if (Simulator.RoadManager.GetGenerateVehicleRoadList()[i].vehicleGenerateLevel == 1)
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
                    else if (Simulator.RoadManager.GetGenerateVehicleRoadList()[i].vehicleGenerateLevel == 2)
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
                    else if (Simulator.RoadManager.GetGenerateVehicleRoadList()[i].vehicleGenerateLevel == 3)
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
                    else if (Simulator.RoadManager.GetGenerateVehicleRoadList()[i].vehicleGenerateLevel == 4)
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
                    else if (Simulator.RoadManager.GetGenerateVehicleRoadList()[i].vehicleGenerateLevel == 5)
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
                            Simulator.UI.AddMessage("System", "Road : " + Simulator.RoadManager.GetGenerateVehicleRoadList()[i].roadID + " Generate " + generateVehicles + " Vehicles");

                        CreateVehicle(Simulator.RoadManager.GetGenerateVehicleRoadList()[i], generateVehicles);
                    }

                }
            }
        }

        public Dictionary<int, Dictionary<string,DrivingPath>> GetDrivingPathList()
        {
            return DrivingPathList;
        }

        public void AddDrivingPath(DrivingPath newDrivingPath)
        {
            int startRoadID = newDrivingPath.GetStartRoadID();

            if (!DrivingPathList.ContainsKey(startRoadID))
            {
                Dictionary<string, DrivingPath> temp = new Dictionary<string, DrivingPath>();
                DrivingPathList.Add(startRoadID, temp);
            }

            if (DrivingPathList[startRoadID].ContainsKey(newDrivingPath.GetName()))
            {
                int currentPro = DrivingPathList[startRoadID][newDrivingPath.GetName()].GetProbability();
                DrivingPathList[startRoadID][newDrivingPath.GetName()].SetProbability(currentPro + newDrivingPath.GetProbability());
            }
            else
            {
                DrivingPathList[startRoadID].Add(newDrivingPath.GetName(), newDrivingPath);
            }

            GenerateDrivingPathTable(startRoadID);

            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Add driving path to road " + startRoadID);
        }

        public void RemoveDrivingPath(int roadID,string pathName)
        {
            DrivingPathList[roadID].Remove(pathName);
            GenerateDrivingPathTable(roadID);

            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Remove driving path : " + pathName);
        }

        public void GenerateDrivingPathTable(int RoadID)
        {
            DrivingPath[] drivingPaths = Simulator.VehicleManager.DrivingPathList[RoadID].Values.ToArray<DrivingPath>();
            List<string> probabilityTable = new List<string>();

            foreach (DrivingPath drivingPath in drivingPaths)
            {
                int probability = drivingPath.GetProbability();
                for (int t = 0; t < probability; t++)
                {
                    probabilityTable.Add(drivingPath.GetName());
                }
            }
            
            if (!DrivingPathTable.ContainsKey(RoadID))
            {
                DrivingPathTable.Add(RoadID, probabilityTable);
            }
            else
            {
                DrivingPathTable[RoadID] = probabilityTable;
            }

        }

        public DrivingPath GetRoadomDrivingPath(int RoadID)
        {
            int randomRange = DrivingPathTable[RoadID].Count;

            Random Random = new Random();
            DrivingPath randomDrivingPath = DrivingPathList[RoadID][DrivingPathTable[RoadID][Random.Next(randomRange)]];

            return randomDrivingPath;
        }
    }
}
