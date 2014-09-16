using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemManagers
{
    class CycleRecord
    {
        public double cycleTime = 0;
        public double arrivedVehicles = 0;
        public double passedVehicles = 0;
        public double WaitingTimeOfAllVehicles = 0;
        public double WaitingVehicles = 0;

        public double AvgWaittingTime = 0;
        public double WaittingRate = 0;

        public CycleRecord(double cycleTime, double arrivedVehicles, double passedVehicles, double WaitingTimeOfAllVehicles, double WaitingVehicles)
        {
            this.cycleTime = cycleTime;
            this.arrivedVehicles = arrivedVehicles;
            this.passedVehicles = passedVehicles;
            this.WaitingTimeOfAllVehicles = WaitingTimeOfAllVehicles;
            this.WaitingVehicles = WaitingVehicles;

            if (arrivedVehicles > 0)
            {
                this.AvgWaittingTime = WaitingTimeOfAllVehicles / arrivedVehicles;
                this.WaittingRate = Math.Round((WaitingVehicles / arrivedVehicles), 2, MidpointRounding.AwayFromZero);
                if (WaittingRate > 1)
                    WaittingRate = 1;
            }
            
        }
    }
}
