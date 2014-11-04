using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemObject
{
    class CycleRecord
    {
        public double cycleTime = 0;
        public double arrivedVehicles = 0;
        public double passedVehicles = 0;
        public double waitingTimeOfAllVehicles = 0;
        public double waitingVehicles = 0;
        public double previousCycleVehicles = 0;

        public double avgWaittingTime = 0;
        public double waittingRate = 0;

        public CycleRecord(double cycleTime, double previousCycleRemainVehicles,double arrivedVehicles, double passedVehicles, double WaitingTimeOfAllVehicles, double WaitingVehicles)
        {
            this.cycleTime = cycleTime;
            this.previousCycleVehicles = previousCycleRemainVehicles;
            this.arrivedVehicles = arrivedVehicles;
            this.passedVehicles = passedVehicles;
            this.waitingTimeOfAllVehicles = WaitingTimeOfAllVehicles;
            this.waitingVehicles = WaitingVehicles;

            if (arrivedVehicles > 0)
            {
                //this.AvgWaittingTime = WaitingTimeOfAllVehicles / (arrivedVehicles + previousCycleRemainVehicles);
                this.avgWaittingTime = WaitingTimeOfAllVehicles / arrivedVehicles;
                //this.WaittingRate = Math.Round(WaitingVehicles / (arrivedVehicles + previousCycleRemainVehicles), 2, MidpointRounding.AwayFromZero);
                this.waittingRate = Math.Round(WaitingVehicles / arrivedVehicles, 2, MidpointRounding.AwayFromZero);
                if (waittingRate > 1)
                    waittingRate = 1;
            }
            
        }
    }
}
