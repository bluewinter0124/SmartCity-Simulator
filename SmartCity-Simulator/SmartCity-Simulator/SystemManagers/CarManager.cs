using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemManagers;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator.SystemManagers
{
    class CarManager
    {
        //車輛大小
        public int carSize = 12;
        public int carLength = 24;
        public int carWidth = 12;

        public int carSpeed = 60;
        public int carRunPerSecond = 17;

        public List<Car> carList = new List<Car>();
        int generateCarSerialID = 0;

        public void CreateCar(Road startRoad,int Weight)
        {
        
           //if (startRoad.getRoadLength() - ((startRoad.WaittingCars()-1) * SimulatorConfiguration.carLength) > SimulatorConfiguration.carLength) //不超出道路
           // {
                Car tempCar = new Car(generateCarSerialID, Weight, startRoad);

                generateCarSerialID++;

                Simulator.UI.AddCar(tempCar);

                carList.Add(tempCar);
            //}
        }

        public void DestoryCar(Car car)
        {
            carList.Remove(car);
            Simulator.UI.RemoveCar(car);
        }

        public void SetCarSize(int size)
        {
            carSize = size;
            carLength = size * 2;
            carWidth = size;
        }

        public void SetCarSpeedKMH(double KMH)
        {
            carSpeed = System.Convert.ToInt16(KMH);
            double temp = Math.Round((KMH * 1000) / 3600, 0, MidpointRounding.AwayFromZero);
            carRunPerSecond = System.Convert.ToInt16(temp);

            if(Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Car run per second : " + carRunPerSecond);

            Simulator.UI.SetCarRunPerSecond(carRunPerSecond);
        }

        public void AllCarRun()
        {
            for (int i = 0; i < Simulator.RoadManager.roadList.Count; i++)
            {

                for (int j = 0; j < Simulator.RoadManager.roadList[i].connectedPathList.Count; j++) //連接路段的車先移動
                {
                    for (int k = 0; k < Simulator.RoadManager.roadList[i].connectedPathList[j].carList.Count; k++)
                    {
                        Simulator.RoadManager.roadList[i].connectedPathList[j].carList[k].Drive();
                    }
                }

                for (int x = 0; x < Simulator.RoadManager.roadList[i].carList.Count; x++) // 該路段的車移動
                {
                    Simulator.RoadManager.roadList[i].carList[x].Drive();
                }
            }
        }

        public void RefreshAllCarGraphic()
        {
            for (int x = 0; x < carList.Count; x++)
            {
                carList[x].RefreshCarGraphic();
            }
        }

        public void GenerateCar()
        {
            int generateCars;
            Random Random = new Random();
            int RandomNum;

            for (int i = 0; i < Simulator.RoadManager.GenerateCarRoadList.Count; i++)
            {
                generateCars = 0;
                RandomNum = Random.Next(999);

                if (Simulator.RoadManager.GenerateCarRoadList[i].carGenerationRate == 1)
                {
                    if(RandomNum >= 992)
                        generateCars = 4;
                    else if (RandomNum >= 985)
                        generateCars = 3;
                    else if (RandomNum >= 909)
                        generateCars = 2;
                    else if (RandomNum >= 606)
                        generateCars = 1;
                }
                else if (Simulator.RoadManager.GenerateCarRoadList[i].carGenerationRate == 2) 
                {
                    if (RandomNum >= 999)
                        generateCars = 6;
                    else if (RandomNum >= 996)
                        generateCars = 5;
                    else if (RandomNum >= 981)
                        generateCars = 4;
                    else if (RandomNum >= 919)
                        generateCars = 3;
                    else if (RandomNum >= 735)
                        generateCars = 2;
                    else if (RandomNum >= 367)
                        generateCars = 1;

                }
                else if (Simulator.RoadManager.GenerateCarRoadList[i].carGenerationRate == 3)
                {
                    if (RandomNum >= 999)
                        generateCars = 9;
                    else if (RandomNum >= 998)
                        generateCars = 8;
                    else if (RandomNum >= 995)
                        generateCars = 7;
                    else if (RandomNum >= 983)
                        generateCars = 6;
                    else if (RandomNum >= 947)
                        generateCars = 5;
                    else if (RandomNum >= 857)
                        generateCars = 4;
                    else if (RandomNum >= 676)
                        generateCars = 3;
                    else if (RandomNum >= 406)
                        generateCars = 2;
                    else if (RandomNum >= 135)
                        generateCars = 1;
                }
                else if (Simulator.RoadManager.GenerateCarRoadList[i].carGenerationRate == 4)
                {
                    if (RandomNum >= 998)
                        generateCars = 10;
                    else if (RandomNum >= 996)
                        generateCars = 9;
                    else if (RandomNum >= 988)
                        generateCars = 8;
                    else if (RandomNum >= 966)
                        generateCars = 7;
                    else if (RandomNum >= 916)
                        generateCars = 6;
                    else if (RandomNum >= 815)
                        generateCars = 5;
                    else if (RandomNum >= 647)
                        generateCars = 4;
                    else if (RandomNum >= 423)
                        generateCars = 3;
                    else if (RandomNum >= 199)
                        generateCars = 2;
                    else if (RandomNum >= 49)
                        generateCars = 1;
                }
                else if (Simulator.RoadManager.GenerateCarRoadList[i].carGenerationRate == 5)
                {
                    if (RandomNum >= 991)
                        generateCars = 10;
                    else if (RandomNum >= 978)
                        generateCars = 9;
                    else if (RandomNum >= 948)
                        generateCars = 8;
                    else if (RandomNum >= 889)
                        generateCars = 7;
                    else if (RandomNum >= 785)
                        generateCars = 6;
                    else if (RandomNum >= 628)
                        generateCars = 5;
                    else if (RandomNum >= 433)
                        generateCars = 4;
                    else if (RandomNum >= 238)
                        generateCars = 3;
                    else if (RandomNum >= 91)
                        generateCars = 2;
                    else if (RandomNum >= 18)
                        generateCars = 1;
                }
                if (generateCars != 0)
                {
                    //SimulatorConfiguration.UI.AddMessage("System", "Road : " + SimulatorConfiguration.RoadManager.GenerateCarRoadList[i].roadName + " Generate " + generateCars + " Cars");
                    CreateCar(Simulator.RoadManager.GenerateCarRoadList[i], generateCars);
                }
            }
        }
    }
}
