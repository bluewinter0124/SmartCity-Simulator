using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartTrafficSimulator.Models;
using SmartTrafficSimulator.SystemObject;

namespace SmartTrafficSimulator.SystemManagers
{
    class VehicleManager
    {
        private int vehicleGenerateSerialID;

        //Vehicle related parameter
        public int vehicleGraphicSize = 8;
        public double vehicleLength = 5;
        public double vehicleWidth = 2.5;
        //length : 5M , width = 2.5M

        public int vehicleRunPerSecond = 1;
        public double vehicleMaxSpeed_KMH = 80;
        public double vehicleAccelerationFactor_KMH = 10;
        public double vehicleBrakeFactor_KMH = 30;
        public double vehicleSafeTime = 1.5;


        public Dictionary<int, Vehicle> vehicleList = new Dictionary<int,Vehicle>(); // All vehicles in simulation, 
        //vehicle ID -> vehicle

        Dictionary<int, Dictionary<string, DrivingPath>> DrivingPathList; 
        //RoadID -> list of drivingPath -> name -> get drivingPath

        Dictionary<int, List<string>> DrivingPathTable; 
        //Use in get random drivingPath

        public int vehicleGenerateInterval = 1;
        Boolean vehicleWeight = false;

        public void InitializeVehicleManager()
        {
            DestoryAllVehicles();
            vehicleGenerateSerialID = 0;
            DrivingPathList = new Dictionary<int, Dictionary<string, DrivingPath>>();
            DrivingPathTable = new Dictionary<int, List<string>>();

            //Simulator.UI.SetVehicleRunTask(vehicleRunPerSecond);
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

        public void CreateVehicle(Road startRoad, int Weight,DrivingPath dp)
        {
            CreateVehicle(startRoad,Weight).SetDrivingPath(dp);
        }

        public Vehicle CreateVehicle(Road startRoad,int Weight)
        {
           //if (startRoad.getRoadLength() - ((startRoad.WaittingVehicles()-1) * SimulatorConfiguration.vehicleLength) > SimulatorConfiguration.vehicleLength) //不超出道路
           // {
                Vehicle newVehicle = new Vehicle(vehicleGenerateSerialID, Weight, startRoad);

                vehicleGenerateSerialID++;

                Simulator.UI.AddVehicle(newVehicle);

                vehicleList.Add(newVehicle.vehicle_ID,newVehicle);

                return newVehicle;
            //}
        }

        public void DestoryVehicle(int vehicleID)
        {
            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Destory Vehicle ID : " + vehicleID);

            VehicleRecord record = new VehicleRecord(Simulator.getCurrentTime(), vehicleList[vehicleID].travelTime_total, (vehicleList[vehicleID].travelDistace_pixel * Simulator.mapScale), vehicleList[vehicleID].travelTime_waiting);

            Simulator.DataManager.AddVehicleRecord(record);

            Simulator.UI.RemoveVehicle(vehicleList[vehicleID]);
            vehicleList.Remove(vehicleID);
        }

        public void SetVehicleGraphicSize(int size)
        {
            vehicleGraphicSize = size;
            //vehicleLength = System.Convert.ToInt16((vehicleGraphicSize * 2) / Simulator.mapScale);
            //vehicleWidth = System.Convert.ToInt16(vehicleGraphicSize / Simulator.mapScale);
        }

        public void SetVehicleSpeedKMH(double KMH)
        {
            vehicleMaxSpeed_KMH = System.Convert.ToInt16(KMH);
            //vehicleRunPixelPerTime = Math.Round(((KMH * 1000) / 3600) / vehicleRunPerSecond ,1, MidpointRounding.AwayFromZero);

            if(Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Vehicle max speed  : " + KMH + "KM/H");
        }

        public void SetVehicleAccelerationFactor(int factor)
        {
            this.vehicleAccelerationFactor_KMH = factor;
        }
        public void SetVehicleBrakeFactor(int factor)
        {
            this.vehicleBrakeFactor_KMH = factor;
        }

        public void AllVehicleRun()
        {
            for (int i = 0; i < Simulator.RoadManager.GetRoadList().Count; i++)
            {

                for (int j = 0; j < Simulator.RoadManager.GetRoadList()[i].intermediateRoadList.Count; j++) //連接路段的車先移動
                {
                    for (int k = 0; k < Simulator.RoadManager.GetRoadList()[i].intermediateRoadList[j].onRoadVehicleList.Count; k++)
                    {
                        Simulator.RoadManager.GetRoadList()[i].intermediateRoadList[j].onRoadVehicleList[k].Driving();
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
            PoissonDistribution P = new PoissonDistribution(0);

            foreach (Road road in Simulator.RoadManager.GetGenerateVehicleRoadList())
            {
                if (road.generateLevel_lambda > 0 && DrivingPathList[road.roadID].Count >= 1)
                {
                    generateVehicles = 0;

                    double lambda = road.generateLevel_lambda / (60 / vehicleGenerateInterval) ;

                    P.SetLambda(lambda);

                    RandomNum = Random.Next(999);

                    if (!vehicleWeight)
                    {
                        if (RandomNum >= P.CummulitiveDistributionFunction(0) * 1000)
                        {
                            generateVehicles = 1;
                        }
                    }
                    else if (vehicleWeight)
                    {
                        while (RandomNum >= P.CummulitiveDistributionFunction(generateVehicles) * 1000)
                        {
                            generateVehicles++;
                        }
                    }

                    if (generateVehicles > 0)
                    {
                        if (Simulator.TESTMODE)
                            Simulator.UI.AddMessage("System", "Road : " + road.roadID + " Generate " + generateVehicles + " Vehicles");
                           
                        CreateVehicle(road, generateVehicles);
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

        public DrivingPath GetRoadomDrivingPath(int startRoadID)
        {
            int randomRange = DrivingPathTable[startRoadID].Count;

            Random Random = new Random();
            DrivingPath randomDrivingPath = DrivingPathList[startRoadID][DrivingPathTable[startRoadID][Random.Next(randomRange)]];

            return randomDrivingPath;
        }

        /*public DrivingPath GetDrivingPathByName(int startRoadID,string name)
        { 
        
        }*/
    }
}
