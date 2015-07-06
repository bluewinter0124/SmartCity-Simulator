using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.OptimizationModels.Other
{
    class Optimization_GT
    {
        public Dictionary<int, int> Optimize(Boolean cycleLengthFixed, int phases, int minGreen, int maxGreen, List<RoadInfo> roadInfos)
        {
            double cycleTime = phases * ((minGreen + maxGreen) / 2);
            cycleTime = Math.Round(cycleTime, 0, MidpointRounding.AwayFromZero);
            Dictionary<int, int> greenTime = new Dictionary<int, int>();

            int p0 = 0;
            int p1 = 0;

            double queue_0 = 0;
            double queue_1 = 0;

            double arrivalRate_0 = 0;
            double arrivalRate_1 = 0;

            double departureRate_0 = 0;
            double departureRate_1 = 0;


            foreach (RoadInfo ri in roadInfos)
            {
                if (ri.phaseNo == 0)
                {
                    p0++;
                    queue_0 += ri.avgQueue;
                    arrivalRate_0 += ri.avgArrivalRate_min;
                    departureRate_0 += ri.avgDepartureRate_min;
                }
                if (ri.phaseNo == 1)
                {
                    p1++;
                    queue_1 += ri.avgQueue;
                    arrivalRate_1 += ri.avgArrivalRate_min;
                    departureRate_1 += ri.avgDepartureRate_min;
                }
            }


            queue_0 /= p0;
            queue_1 /= p1;

            arrivalRate_0 /= p0;
            arrivalRate_1 /= p1;

            departureRate_0 /= p0;
            departureRate_1 /= p1;

            double a = ((arrivalRate_0 + arrivalRate_1)/2)/60;
            double b = ((departureRate_0 + departureRate_1)/2)/60;

            double t1 = (queue_0 - queue_1 + ((a + b) * cycleTime)) / (2 * (a + b));
            double t2 = (queue_1 - queue_0 + ((a + b) * cycleTime)) / (2 * (a + b));

            t1 = Math.Round(t1, 0, MidpointRounding.AwayFromZero);
            t2 = Math.Round(t2, 0, MidpointRounding.AwayFromZero);

            if (t1 > maxGreen)
                t1 = maxGreen;
            else if(t1 < minGreen)
                t1 = minGreen;

            if (t2 > maxGreen)
                t2 = maxGreen;
            else if (t2 < minGreen)
                t2 = minGreen;

            greenTime.Add(0, System.Convert.ToInt16(t1));
            greenTime.Add(1, System.Convert.ToInt16(t2));

            //System.Console.WriteLine("T1 : " + t1 + " T2 :" + t2);

            return greenTime;
        }


    }
}
