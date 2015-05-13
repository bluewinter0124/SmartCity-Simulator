using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.SystemObject
{
    class VehicleRecord
    {
        public int exitTime = 0;
        public int travelTime_Sec = 0;
        public double travelDistance_M = 0;
        public double travelSpeed_MS = 0;
        public double travelSpeed_KMH = 0;
        public int delayTime_Sec = 0;

        public VehicleRecord(int exitTime, int travelTime, double travelDistance_M, int delayTime)
        {
            this.exitTime = exitTime;
            this.travelTime_Sec = travelTime;
            this.travelDistance_M = travelDistance_M;
            this.travelSpeed_MS = Math.Round(travelDistance_M / travelTime, 2, MidpointRounding.AwayFromZero);
            this.travelSpeed_KMH = Math.Round(this.travelSpeed_MS * 3.6, 2, MidpointRounding.AwayFromZero);
            this.delayTime_Sec = delayTime;
        }
    }
}
