using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.OptimizationModels.GA_Yo
{
    class Direction
    {
        public int id1 = -1;
        public int id2 = -1;
        public int vector;
        public double Qright = -1;
        public double Qleft = -1;
        public double AvgUp = -1;
        public double AvgDown = -1;
        public int PreGtA = -1;
        public int PreGtB = -1;
        public int PreGtC = -1;
    }
}
