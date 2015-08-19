using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.SystemObject
{
    public class IntelligentDriverModel
    {
        // Ref : Treiber, Martin; Hennecke, Ansgar; Helbing, Dirk (2000), "Congested traffic states in empirical observations and microscopic simulations", Physical Review E 62 (2): 1805–1824

        public static double SpeedCalculation(Vehicle self, Vehicle front)
        {
            double deltaV = 0, netD = 0, sFunction = 0, velocity = 0;

            //No vehicle in front
            if (front == null)
            {
                //Located road signal is green 
                if (self.locatedRoad.signalState == 0)
                {
                    velocity = Simulator.VehicleManager.vehicleAccelerationFactor_KMH * (1 - Math.Pow(self.vehicle_speed_KMH / self.locatedRoad.speedLimit, 4));
                }

                //Located road signal is yellow or red
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
                }
            }

            //Vehicle in front
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
