using SmartTrafficSimulator.SystemManagers;
using SmartTrafficSimulator.SystemObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.Models
{
    public class ReservationTimeCalculation
    {
        //Simplify Vehicle 
        public class IDMVehicle
        {
            public int vehicle_ID;
            public double vehicle_speed_KMH = 0;
            public int vehicle_length = 16;
            public int vehicle_width = 8;
            public int location = 0;

            public List<double> speedRecord = new List<double>();

            public IDMVehicle()
            {
                speedRecord.Add(vehicle_speed_KMH);
            }

            public void Run(IDMVehicle front)
            {
                double nextSpeed = ReservationTimeCalculation.IDM(this, front);

                int runDistance = System.Convert.ToInt16(Math.Round(((((vehicle_speed_KMH + nextSpeed) / 2) * 10 / 36)), 0, MidpointRounding.AwayFromZero));

                location += runDistance;

                this.vehicle_speed_KMH = nextSpeed;

                speedRecord.Add(vehicle_speed_KMH);
            }

        }


        public int ReservationTime(int vehicles)
        {
            double vehicleLength = Simulator.VehicleManager.vehicleLength;
            double minSafeDistance = Simulator.VehicleManager.vehicleLength / 2;
            int signalLocation = System.Convert.ToInt16(vehicles * (vehicleLength + minSafeDistance));
            List<IDMVehicle> vehicleQueue = new List<IDMVehicle>();

            //Initial vehicles on the road 
            int reservationTime = 0;
            for (int ID = 0; ID < vehicles; ID++)
            {
                IDMVehicle vehicle = new IDMVehicle();
                vehicle.vehicle_ID = ID;
                vehicle.location = System.Convert.ToInt16(signalLocation - (ID * (vehicleLength + minSafeDistance) + minSafeDistance));
                vehicleQueue.Add(vehicle);
            }

            //Calculate 
            do
            {
                reservationTime++;

                //All vehicles run
                for (int i = 0; i < vehicleQueue.Count; i++) 
                {
                    if (i == 0)
                    {
                        vehicleQueue[i].Run(null);
                    }
                    else
                    {
                        vehicleQueue[i].Run(vehicleQueue[i - 1]);
                    }
                }
            } while (vehicleQueue[vehicleQueue.Count() - 1].location < (signalLocation + vehicleLength)); //If the last vehicle exit, end

            return reservationTime;
        }


        //Simplify IDM
        public static double IDM(IDMVehicle self, IDMVehicle front)
        {
            double vehicleLength = Simulator.VehicleManager.vehicleLength;
            double minSafeDistance = Simulator.VehicleManager.vehicleLength / 2;
            double safeTime = Simulator.VehicleManager.vehicleSafeTime;
            double vehicleAccelerationFactor = ((Simulator.VehicleManager.vehicleAccelerationFactor_KMH * 1000) / 3600);
            double vehicleBrakeFactor = ((Simulator.VehicleManager.vehicleBrakeFactor_KMH * 1000) / 3600);
            double speedLimit = Simulator.VehicleManager.vehicleMaxSpeed_KMH;

            double deltaV = .0, netD = 0, sFunction = 0, velocity = 0;


            if (front == null)
            {
                velocity = vehicleAccelerationFactor * (1 - Math.Pow(self.vehicle_speed_KMH / speedLimit, 4));
            }
            else
            {
                deltaV = self.vehicle_speed_KMH - front.vehicle_speed_KMH;

                netD = front.location - self.location - vehicleLength;
                if (netD < minSafeDistance)
                    netD = minSafeDistance;

                sFunction = minSafeDistance +
                    self.vehicle_speed_KMH * safeTime +
                    (self.vehicle_speed_KMH * deltaV / (2 * Math.Sqrt(vehicleAccelerationFactor * vehicleBrakeFactor)));

                velocity = vehicleAccelerationFactor * (1 - Math.Pow(self.vehicle_speed_KMH / speedLimit, 4) - Math.Pow(sFunction / netD, 2));
            }

            velocity = Math.Round(velocity, 1, MidpointRounding.AwayFromZero);
            if (velocity < 0 && (velocity * -1) > vehicleBrakeFactor)
                velocity = vehicleBrakeFactor * -1;

            double nextSpeed = self.vehicle_speed_KMH + velocity;
            if (nextSpeed < 0)
                nextSpeed = 0;

            return nextSpeed;
        }

    }
}
