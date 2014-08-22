using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemManagers
{
    class CycleRecord
    {
        public double cycleTime = 0;
        public double arrivedCars = 0;
        public double passedCars = 0;
        public double WaitingTimeOfAllCars = 0;
        public double WaitingCars = 0;

        public double AvgWaittingTime = 0;
        public double WaittingRate = 0;

        public CycleRecord(double cycleTime, double arrivedCars, double passedCars, double WaitingTimeOfAllCars, double WaitingCars)
        {
            this.cycleTime = cycleTime;
            this.arrivedCars = arrivedCars;
            this.passedCars = passedCars;
            this.WaitingTimeOfAllCars = WaitingTimeOfAllCars;
            this.WaitingCars = WaitingCars;

            if (arrivedCars > 0)
            {
                this.AvgWaittingTime = WaitingTimeOfAllCars / arrivedCars;
                this.WaittingRate = Math.Round((WaitingCars / arrivedCars), 2, MidpointRounding.AwayFromZero);
                if (WaittingRate > 1)
                    WaittingRate = 1;
            }
            
        }
    }
}
