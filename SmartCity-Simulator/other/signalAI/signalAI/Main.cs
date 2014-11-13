using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace signalAI
{
    class MainClass
    {
        static void Main(string[] args)
        {
            /********temp********/
            int PreGtA1 = 10, PreGtB1 = 30, PreGtC1 = 30;
            int id1 = 5, vector1 = 0;
            double Qright1 = 6.7, Qleft1 = 7.8;
            double AvgUp1 = 20.4, AvgDown1 = 20.3;
            /*******************/
            int PreGtA2 = 39, PreGtB2 = -1, PreGtC2 = 30;
            int id2 = 5, vector2 = 1;
            double Qright2 = -1, Qleft2 = 8.4;
            double AvgUp2 = 10, AvgDown2 = -1;
            /*******************/

            Optimization proj = new Optimization();
            List<int> settime = new List<int>();

            double[] road1 = new double[6] { id1, vector1, PreGtA1, PreGtB1, Qright1, AvgUp2 };
            double[] road2 = new double[6] { id1, vector1, PreGtA1, PreGtC1, Qleft1,  AvgDown2 };
            double[] road3 = new double[6] { id2, vector2, PreGtA2, PreGtB2, Qright2, AvgUp1 };
            double[] road4 = new double[6] { id2, vector2, PreGtA2, PreGtC2, Qleft2,  AvgDown1 };

            List<double[]> intersection1 = new List<double[]>();
            intersection1.Add(road1);
            intersection1.Add(road2);
            intersection1.Add(road3);
            intersection1.Add(road4);

            settime = proj.GA(intersection1);

            Console.WriteLine("SetVec1=" + settime[0] + "  " + "SetVec2=" + settime[1]);
            Console.ReadLine();
            return;
        }
    }
}
