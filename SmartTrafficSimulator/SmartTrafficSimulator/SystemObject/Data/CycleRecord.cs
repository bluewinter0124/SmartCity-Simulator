using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.SystemObject
{
    class CycleRecord
    {
        public double cycleTime = 0;
        public double arrivalVehicles = 0;
        public double passedVehicles = 0;
        public double waitingTimeOfAllVehicles = 0;
        public double waitingVehicles = 0;
        public double previousCycleVehicles = 0;

        public double arrivalRate_min = 0;
        public double departureRate_min = 0;
        public double avgWaittingTime = 0;
        public double waittingRate = 0;

        public CycleRecord(double cycleTime, double previousCycleRemainVehicles,double arrivalVehicles, double passedVehicles, double WaitingTimeOfAllVehicles, double WaitingVehicles)
        {
            this.cycleTime = cycleTime;
            this.previousCycleVehicles = previousCycleRemainVehicles;
            this.arrivalVehicles = arrivalVehicles;
            this.passedVehicles = passedVehicles;
            this.waitingTimeOfAllVehicles = WaitingTimeOfAllVehicles;
            this.waitingVehicles = WaitingVehicles;

            if (arrivalVehicles > 0)
            {
                //this.AvgWaittingTime = WaitingTimeOfAllVehicles / (arrivedVehicles + previousCycleRemainVehicles);
                this.avgWaittingTime = WaitingTimeOfAllVehicles / arrivalVehicles;
                //this.WaittingRate = Math.Round(WaitingVehicles / (arrivedVehicles + previousCycleRemainVehicles), 2, MidpointRounding.AwayFromZero);
                this.waittingRate = Math.Round(WaitingVehicles / arrivalVehicles, 2, MidpointRounding.AwayFromZero);
                if (waittingRate > 1)
                    waittingRate = 1;

                this.arrivalRate_min = Math.Round(((arrivalVehicles / cycleTime) * 60), 2, MidpointRounding.AwayFromZero);
                this.departureRate_min = Math.Round(((passedVehicles / cycleTime) * 60), 2, MidpointRounding.AwayFromZero);
            }

        }
    }
}
