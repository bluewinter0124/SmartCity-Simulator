using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.OptimizationModels.GA_Yo;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.OptimizationModels.GA_Yo
{
    class Optimization_GA_YO
    {
        public Dictionary<int, int> Optimize(Boolean cycleLengthFixed, int phases, int minGreen, int maxGreen, List<RoadInfo> roadInfos)
        {
            //Map_initial MapIni = new Map_initial();
            TSC_GA GTopt1 = new TSC_GA();
            TSC_GA GTopt2 = new TSC_GA();
            //Result ResultCal1 = new Result();
            //Result ResultCal2 = new Result();
            SetResult SRcal = new SetResult();
            List<int> settime = new List<int>();

            List<Direction> direction = new List<Direction>();
            direction.Add(new Direction());
            direction.Add(new Direction());
            

            foreach(RoadInfo ri in roadInfos)
            {                
                int phase = ri.phaseNo;
                
                if (direction[phase].id1 == -1)
                {
                    direction[phase].vector = ri.phaseNo;
                    direction[phase].PreGtA = ri.currentGreen;
                    direction[phase].id1 = ri.roadID;
                    direction[phase].Qright = ri.avgQueue;
                    direction[phase].AvgUp = ri.avgArrivalRate_min;
                    //direction[phase].PreGtB = (int)intersection1[i][3];
                }
                else
                {
                    direction[phase].id2 = ri.roadID;
                    direction[phase].Qleft = ri.avgQueue;
                    direction[phase].AvgDown = ri.avgArrivalRate_min;
                    //direction[phase].PreGtC = (int)intersection1[i][3];
                }
                
            }
            //Simulator.UI.AddMessage("AI", "  vector:" + direction[0].vector + "  GT:" + direction[0].PreGtA + "  QR:" + direction[0].Qright + "  QL:" + direction[0].Qleft + "  AU:" + direction[0].AvgUp + "  AD:" + direction[0].AvgDown + "  Pre:" + direction[0].PreGtA);
            //Simulator.UI.AddMessage("AI", "  vector:" + direction[1].vector + "  GT:" + direction[1].PreGtA + "  QR:" + direction[1].Qright + "  QL:" + direction[1].Qleft + "  AU:" + direction[1].AvgUp + "  AD:" + direction[1].AvgDown + "  Pre:" + direction[1].PreGtA);
            //Console.WriteLine(" " + direction[0].vector + " " + direction[0].Qright + " " + direction[0].Qleft + " " + direction[0].AvgUp + " " + direction[0].AvgDown + " " + direction[0].PreGtA + " " + direction[0].PreGtB + " " + direction[0].PreGtC);
            //Console.WriteLine(" " + direction[1].vector + " " + direction[1].Qright + " " + direction[1].Qleft + " " + direction[1].AvgUp + " " + direction[1].AvgDown + " " + direction[1].PreGtA + " " + direction[1].PreGtB + " " + direction[1].PreGtC);
            //Console.ReadLine();
            int result_vec1 = 0, result_vec2 = 0;
            result_vec1 = GTopt1.GAmain(direction[0].vector, direction[0].Qright, direction[0].Qleft, direction[1].AvgUp, direction[1].AvgDown, direction[0].PreGtA, direction[0].PreGtB, direction[0].PreGtC);
            //ResultCal1.RCmain(GTopt1);

            result_vec2 = GTopt2.GAmain(direction[1].vector, direction[1].Qright, direction[1].Qleft, direction[0].AvgUp, direction[0].AvgDown, direction[1].PreGtA, direction[1].PreGtB, direction[1].PreGtC);
            //ResultCal2.RCmain(GTopt2);

            //Simulator.UI.AddMessage("AI", "  time1:" + result_vec1 + "  time2:" + result_vec2);
            return SRcal.SRcalculat(direction[0].PreGtA, direction[1].PreGtA, result_vec1, result_vec2);
        }
    }
}
