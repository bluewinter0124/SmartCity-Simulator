using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace signalAI
{
    public struct Direction
    {
        public int id;
        public int vector;
        public double Qright;
        public double Qleft;
        public double AvgUp;
        public double AvgDown;
        public int PreGtA;
        public int PreGtB;
        public int PreGtC;
    }

    class GA_Optimization
    {
        public List<int> GAOptimize(List<double[]> intersection)
        {
            Map_initial MapIni = new Map_initial();
            TSC_GA GTopt1 = new TSC_GA();
            TSC_GA GTopt2 = new TSC_GA();
            Result ResultCal1 = new Result();
            Result ResultCal2 = new Result();
            SetResult SRcal = new SetResult();
            List<int> settime = new List<int>();
            
            Direction[] direction = new Direction[2];

            int list_length=intersection.Count;
            int i,a=0,b=0;

            MapIni.MImain();

            for (i = 0; i < list_length; i++)
            {
                if (i / 2 == 0)
                {
                    a = 0;
                    b = 1;
                }
                else if (i / 2 == 1)
                {
                    a = 1;
                    b = 0;
                }

                if (i % 2 == 0)
                {
                    direction[a].id = (int)intersection[i][0];
                    direction[a].vector = (int)intersection[i][1];
                    direction[a].PreGtA = (int)intersection[i][2];
                    direction[a].PreGtB = (int)intersection[i][3];
                    direction[a].Qright = intersection[i][4];
                    direction[b].AvgUp = intersection[i][5];
                }
                else
                {
                    direction[a].PreGtC = (int)intersection[i][3];
                    direction[a].Qleft = intersection[i][4];
                    direction[b].AvgDown = intersection[i][5];
                }
            }

            GTopt1.GAmain(MapIni, direction[0].id, direction[0].vector, direction[0].Qright, direction[0].Qleft, direction[0].AvgUp, direction[0].AvgDown, direction[0].PreGtA, direction[0].PreGtB, direction[0].PreGtC);
            ResultCal1.RCmain(MapIni, GTopt1);

            GTopt2.GAmain(MapIni, direction[1].id, direction[1].vector, direction[1].Qright, direction[1].Qleft, direction[1].AvgUp, direction[1].AvgDown, direction[1].PreGtA, direction[1].PreGtB, direction[1].PreGtC);
            ResultCal2.RCmain(MapIni, GTopt2);
            
            SRcal.SRcalculat(direction[0].PreGtA, direction[1].PreGtA, MapIni, GTopt1, GTopt2, ResultCal1, ResultCal2);

            settime.Add(SRcal.SetVec1);
            settime.Add(SRcal.SetVec2);

            return settime;
        }
    }
}
