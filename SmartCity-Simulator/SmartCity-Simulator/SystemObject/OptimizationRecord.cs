using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemObject
{
    class OptimizationRecord
    {

        int optimizeCycle;
        List<string> originConfiguration = new List<string>();
        List<string> optimizedConfiguration = new List<string>();

        public int GetOptimizeCycle()
        {
            return optimizeCycle;
        }

        public void addOriginConfiguration(int order,int green, int yellow, int red)
        {
            string record = "Order : " + order + ",Green :" + green + ",Yellow : " + yellow + ",Red : " + red;
            originConfiguration.Add(record);
        }

        public void addOptimizedConfiguration(int order, int green, int yellow, int red)
        {
            string record = "Order : " + order + ",Green :" + green + ",Yellow : " + yellow + ",Red : " + red;
            optimizedConfiguration.Add(record);
        }
    }
}
