using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace signalAI
{
    class MainClass
    {
        public void AItest(string[] args)
        {
            /********temp********/
            int PreGtA1 = 20, PreGtB1 = 30, PreGtC1 = 30;
            int id1 = 5, vector1 = 0;
            double Qright1 = 6.7, Qleft1 = 7.8;
            double AvgUp1 = 20.4, AvgDown1 = 20.3;
            /*******************/
            int PreGtA2 = 39, PreGtB2 = 30, PreGtC2 = 30;
            int id2 = 5, vector2 = 1;
            double Qright2 = 8.9, Qleft2 = 8.4;
            double AvgUp2 = 10, AvgDown2 = 11.3;
            /*******************/

            Optimization proj = new Optimization();
            List<int> settime = new List<int>();

            settime = proj.GA(id1, vector1, Qright1, Qleft1, AvgUp1, AvgDown1, PreGtA1, PreGtB1, PreGtC1,
                              id2, vector2, Qright2, Qleft2, AvgUp2, AvgDown2, PreGtA2, PreGtB2, PreGtC2);

            Console.WriteLine("SetVec1=" + settime[0] + "  " + "SetVec2=" + settime[1]);
            Console.ReadLine();
            return;
        }
    }
}
