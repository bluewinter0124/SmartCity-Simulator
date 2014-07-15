using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace signalAI
{
    class Optimization
    {
        public List<int> GA(int id1, int vector1, double Qright1, double Qleft1, double AvgUp1, double AvgDown1, int PreGtA1, int PreGtB1, int PreGtC1, 
                            int id2, int vector2, double Qright2, double Qleft2, double AvgUp2, double AvgDown2, int PreGtA2, int PreGtB2, int PreGtC2)
        {
            Map_initial MapIni = new Map_initial();
            TSC_GA GTopt1 = new TSC_GA();
            TSC_GA GTopt2 = new TSC_GA();
            Result ResultCal1 = new Result();
            Result ResultCal2 = new Result();
            SetResult SRcal = new SetResult();
            List<int> settime = new List<int>();

            MapIni.MImain();

            GTopt1.GAmain(MapIni, id1, vector1, Qright1, Qleft1, AvgUp1, AvgDown1, PreGtA1, PreGtB1, PreGtC1);
            ResultCal1.RCmain(MapIni, GTopt1);

            GTopt2.GAmain(MapIni, id2, vector2, Qright2, Qleft2, AvgUp2, AvgDown2, PreGtA2, PreGtB2, PreGtC2);
            ResultCal2.RCmain(MapIni, GTopt2);

            //Console.WriteLine(ResultCal1.final_ans + " " + ResultCal2.final_ans;

            SRcal.SRcalculat(PreGtA1, PreGtA2, MapIni, GTopt1, GTopt2, ResultCal1, ResultCal2);

            settime.Add(SRcal.SetVec1);
            settime.Add(SRcal.SetVec2);

            return settime;
        }
    }
}
