using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.GraphicUnit;
using SmartTrafficSimulator.SystemManagers;


namespace SmartTrafficSimulator.SystemObject
{
    class VehicleDriveModels
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

        public static double Normal(Vehicle self, int obstacleDistance)
        {
            double nextSpeed = self.vehicle_speed_KMH;

            double brakeTime = self.vehicle_speed_KMH / Simulator.VehicleManager.vehicleBrakeFactor_KMH;
            //brakeTime = Math.Round(brakeTime, 0, MidpointRounding.AwayFromZero);

            double MSD = Math.Round(self.safeDistance + ((brakeTime * self.vehicle_speed_KMH * 1000) / 7200 / Simulator.mapScale), 0, MidpointRounding.AwayFromZero); //Max safe distance
            //Simulator.UI.AddMessage("System", "OD" + OD + " MSD : " + MSD);

            if (obstacleDistance > MSD || obstacleDistance == -1) //Accelerate or keep current speed
            {
                if (self.vehicle_speed_KMH < self.locatedRoad.speedLimit)
                {
                    nextSpeed = self.vehicle_speed_KMH + Simulator.VehicleManager.vehicleAccelerationFactor_KMH;
                    if (nextSpeed > self.locatedRoad.speedLimit)
                    {
                        nextSpeed = self.locatedRoad.speedLimit;
                    }
                }
            }
            else if (obstacleDistance <= MSD) //Normal brake
            {
                if (self.vehicle_speed_KMH > 0)
                {
                    nextSpeed = self.vehicle_speed_KMH - Simulator.VehicleManager.vehicleBrakeFactor_KMH;
                    if (nextSpeed < 0)
                    {
                        nextSpeed = 0;
                    }
                }
                //Simulator.UI.AddMessage("System", "NB : " + vehicle_speed_KMH);
            }
            else if (obstacleDistance < (self.safeDistance / 2)) //Emergency brake
            {
                nextSpeed = 0;
            }

            return nextSpeed;
        }

        public static double IDM(Vehicle self, Vehicle front)
        {
            double deltaV = .0, netD = 0, sFunction = 0, velocity = 0;
    
            if (front == null)
            {
                if (self.locatedRoad.signalState == 0)
                {
                    velocity = Simulator.VehicleManager.vehicleAccelerationFactor_KMH * (1 - Math.Pow(self.vehicle_speed_KMH / self.locatedRoad.speedLimit, 4));
                }
                else
                {
                    deltaV = self.vehicle_speed_KMH;

                    netD = (self.locatedRoad.GetRoadLength() - 1) - self.location - self.vehicle_length;
                    /*if (netD < self.safeDistance)
                        netD = self.safeDistance;*/

                    sFunction = Simulator.VehicleManager.vehicleLength / 2 +
                        self.vehicle_speed_KMH * Simulator.VehicleManager.vehicleSafeTime +
                        (self.vehicle_speed_KMH * deltaV / (2 * Math.Sqrt(Simulator.VehicleManager.vehicleAccelerationFactor_KMH * Simulator.VehicleManager.vehicleBrakeFactor_KMH)));

                    velocity = Simulator.VehicleManager.vehicleAccelerationFactor_KMH * (1 - Math.Pow(self.vehicle_speed_KMH / self.locatedRoad.speedLimit, 4) - Math.Pow(sFunction / netD, 2));

                    //Simulator.UI.AddMessage("System", "netD" + netD + "     V:" + velocity);
                }
            }
            else
            {
                deltaV = self.vehicle_speed_KMH - front.vehicle_speed_KMH;

                double avgVehicleLength = (self.vehicle_length + front.vehicle_length) / 2;

                netD = front.location - self.location - avgVehicleLength;
                /*if (netD < self.safeDistance)
                    netD = self.safeDistance;*/

                sFunction = Simulator.VehicleManager.vehicleLength / 2 + 
                    self.vehicle_speed_KMH * Simulator.VehicleManager.vehicleSafeTime + 
                    (self.vehicle_speed_KMH * deltaV / (2 * Math.Sqrt(Simulator.VehicleManager.vehicleAccelerationFactor_KMH * Simulator.VehicleManager.vehicleBrakeFactor_KMH)));

                velocity = Simulator.VehicleManager.vehicleAccelerationFactor_KMH * (1 - Math.Pow(self.vehicle_speed_KMH / self.locatedRoad.speedLimit, 4) - Math.Pow(sFunction / netD, 2));
            }

            velocity = Math.Round(velocity, 1, MidpointRounding.AwayFromZero);
            if (velocity < 0 && (velocity * -1) > Simulator.VehicleManager.vehicleBrakeFactor_KMH)
                velocity = Simulator.VehicleManager.vehicleBrakeFactor_KMH * -1;

            double nextSpeed = self.vehicle_speed_KMH + velocity;
            if (nextSpeed < 0)
                nextSpeed = 0;

            return nextSpeed;
        }
    }
}
