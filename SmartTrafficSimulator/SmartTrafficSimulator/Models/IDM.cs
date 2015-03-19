﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.GraphicUnit;

namespace SmartTrafficSimulator.SystemObject
{
    class IMD
    {
        /*//沒紅燈
        public static double[,] UpdateNormal(double[,] positionVelocity,
            Vehicles[] vehicleArray, double h)
        {
            int numberOfVehicles = Form1.numberOfCar + Form1.numberOfTruck;

            double[,] positionVelocityNew = new double[positionVelocity.Length, 2];    //[i][0] : 第i車的位子, [i][1] : 第i車的速度
            double k1, w1;
            double[] temp;
            //從第一台車計算到i-1台(由左往右算)
            for (int i = 0; i < numberOfVehicles - 1; i++)
            {
                temp = VDot(positionVelocity[i, 0], positionVelocity[i, 1],
                    positionVelocity[i + 1, 0], positionVelocity[i + 1, 1],
                    vehicleArray[i]);
                k1 = h * temp[0];
                w1 = h * temp[1];

                positionVelocityNew[i, 0] = positionVelocity[i, 0] + k1;
                positionVelocityNew[i, 1] = positionVelocity[i, 1] + w1;
                //車子超出panel, 就放回路段起點, 變成ring road
                if (positionVelocityNew[i, 0] > (Form1.panel_Road.Width + vehicleArray[i].GetLength()))
                {
                    positionVelocityNew[i, 0] = positionVelocityNew[i, 0] - Form1.panel_Road.Width;
                }
                //車子車速 < 0, 因為沒有倒車狀況, 所以變0
                if (positionVelocityNew[i, 1] < 0)
                {
                    positionVelocityNew[i, 1] = 0;
                }
            }

            temp = VDot(positionVelocity[numberOfVehicles - 1, 0],
                positionVelocity[numberOfVehicles - 1, 1],
                positionVelocity[0, 0], positionVelocity[0, 1],
                vehicleArray[numberOfVehicles - 1]);
            k1 = h * temp[0];
            w1 = h * temp[1];

            positionVelocityNew[numberOfVehicles - 1, 0] = positionVelocity[numberOfVehicles - 1, 0] + k1;
            positionVelocityNew[numberOfVehicles - 1, 1] = positionVelocity[numberOfVehicles - 1, 1] + w1;
            //車子超出panel, 就放回路段起點, 變成ring road
            if (positionVelocityNew[numberOfVehicles - 1, 0] > (Form1.panel_Road.Width + vehicleArray[numberOfVehicles - 1].GetLength()))
            {
                positionVelocityNew[numberOfVehicles - 1, 0] = positionVelocityNew[numberOfVehicles - 1, 0] - Form1.panel_Road.Width;
            }
            //車子車速 < 0, 因為沒有倒車狀況, 所以變0
            if (positionVelocityNew[numberOfVehicles - 1, 1] < 0)
            {
                positionVelocityNew[numberOfVehicles - 1, 1] = 0;
            }

            return positionVelocityNew;

        }

        static int carBehindTrafficLight = 0;
        static double[] distanceToTrafficLight = new double[Form1.numberOfCar + Form1.numberOfTruck];
        static double locatedOfTrafficLight = 670;
        //有紅燈
        public static double[,] UpdateRedLight(double[,] positionVelocity,
            Vehicles[] vehicleArray, double h)
        {
            int numberOfVehicles = Form1.numberOfCar + Form1.numberOfTruck;


            double[,] positionVelocityNew = new double[positionVelocity.Length, 2];    //[i][0] : 第i車的位子, [i][1] : 第i車的速度
            double k1, w1;
            double[] temp;
            double closest = -locatedOfTrafficLight;
            for (int i = 0; i < numberOfVehicles; i++)
            {
                distanceToTrafficLight[i] = positionVelocity[i, 0] - locatedOfTrafficLight;
                if (distanceToTrafficLight[i] >= closest)
                {
                    if (distanceToTrafficLight[i] <= 0)
                    {
                        closest = distanceToTrafficLight[i];
                        carBehindTrafficLight = i;
                    }
                }
            }

            //從第i台車計算到1台(由右往左算)
            for (int i = 0; i < numberOfVehicles; i++)
            {
                if (i == carBehindTrafficLight)
                {
                    temp = VDot(positionVelocity[i, 0], positionVelocity[i, 1],
                        locatedOfTrafficLight, 0,
                        vehicleArray[i]);
                    k1 = h * temp[0];
                    w1 = h * temp[1];

                    positionVelocityNew[i, 0] = positionVelocity[i, 0] + k1;
                    positionVelocityNew[i, 1] = positionVelocity[i, 1] + w1;
                }
                else if (i == numberOfVehicles - 1)
                {
                    temp = VDot(positionVelocity[i, 0], positionVelocity[i, 1],
                        positionVelocity[0, 0], positionVelocity[0, 1],
                        vehicleArray[i]);
                    k1 = h * temp[0];
                    w1 = h * temp[1];

                    positionVelocityNew[i, 0] = positionVelocity[i, 0] + k1;
                    positionVelocityNew[i, 1] = positionVelocity[i, 1] + w1;
                }
                else
                {
                    temp = VDot(positionVelocity[i, 0], positionVelocity[i, 1],
                        positionVelocity[i + 1, 0], positionVelocity[i + 1, 1],
                        vehicleArray[i]);
                    k1 = h * temp[0];
                    w1 = h * temp[1];

                    positionVelocityNew[i, 0] = positionVelocity[i, 0] + k1;
                    positionVelocityNew[i, 1] = positionVelocity[i, 1] + w1;
                }

                //車子超出panel, 就放回路段起點, 變成ring road
                if (positionVelocityNew[i, 0] > (Form1.panel_Road.Width + vehicleArray[i].GetLength()))
                {
                    positionVelocityNew[i, 0] = positionVelocityNew[i, 0] - Form1.panel_Road.Width;
                }
                //車子車速 < 0, 因為沒有倒車狀況, 所以變0
                if (positionVelocityNew[i, 1] < 0)
                {
                    positionVelocityNew[i, 1] = 0;
                }
            }

            return positionVelocityNew;
        }*/

        public static double IDM(Vehicle self, Vehicle front)
        {
            double deltaV, netD, sFunction, result;
            
            //現在是拿自己車的長度，因為每台車都假設是一樣長

            if (front == null)
            {
                result = Simulator.VehicleManager.vehicleAccelerationFactor * (1 - Math.Pow(self.vehicle_speed_KMH / self.locatedRoad.speedLimit, 4));
            }
            else
            {
                deltaV = self.vehicle_speed_KMH - front.vehicle_speed_KMH;
                netD = front.locatedPoint - Simulator.VehicleManager.vehicleLength - self.locatedPoint;

                sFunction = Simulator.VehicleManager.vehicleLength / 2 + 
                    self.vehicle_speed_KMH * Simulator.VehicleManager.vehicleSafeTime + 
                    (self.vehicle_speed_KMH * deltaV / (2 * Math.Sqrt(Simulator.VehicleManager.vehicleAccelerationFactor * Simulator.VehicleManager.vehicleBrakeFactor)));

                result = Simulator.VehicleManager.vehicleAccelerationFactor * (1 - Math.Pow(self.vehicle_speed_KMH / self.locatedRoad.speedLimit, 4) - Math.Pow(sFunction / netD, 2));
            }
            return result;
        }
    }
}