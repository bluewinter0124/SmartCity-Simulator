using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemUnit
{
    class CycleRecord
    {
        public int cycleTime = 0;
        public int arrivedCars = 0;
        public int passedCars = 0;
        public int WaitingTimeOfAllCars = 0;
        public int WaitingCars = 0;

        public CycleRecord(int cycleTime, int arrivedCars, int passedCars, int WaitingTimeOfAllCars, int WaitingCars)
        {
            this.cycleTime = cycleTime;
            this.arrivedCars = arrivedCars;
            this.passedCars = passedCars;
            this.WaitingTimeOfAllCars = WaitingTimeOfAllCars;
            this.WaitingCars = WaitingCars;
        }


    }
}
