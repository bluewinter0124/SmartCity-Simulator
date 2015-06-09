using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.SystemObject
{
    class OptimizationRecord
    {
        public int optimizeCycle;
        public string optimizeTime;
        public double IAWR;
        public double IAWRThreshold;
        public int optimizationTimes = 0;
        List<String> originConfiguration = new List<String>();
        List<String> optimizedConfiguration = new List<String>();

        public OptimizationRecord(int optimizeCycle,string time, double currentIAWR, double IAWRThreshold)
        {
            this.optimizeCycle = optimizeCycle;
            this.optimizeTime = time;
            this.IAWR = currentIAWR;
            this.IAWRThreshold = IAWRThreshold;
        }

        public void AddOriginConfiguration(String lightConfig)
        {
            originConfiguration.Add(lightConfig);
        }

        public void AddOptimizedConfiguration(String lightConfig)
        {
            optimizedConfiguration.Add(lightConfig);
            optimizationTimes = 1;
        }

        public string OriginConfigToString()
        {
            string temp ="";
            if (originConfiguration.Count > 0)
            {
                for (int i = 0; i < originConfiguration.Count; i++)
                {
                    temp += originConfiguration[i];
                    temp += " / ";
                }
            }
            else
            {
                temp += "-";
            }
            return temp;
        }

        public string OptimizedConfigToString()
        {
            string temp = "";
            if (optimizedConfiguration.Count > 0)
            {
                for (int i = 0; i < optimizedConfiguration.Count; i++)
                {
                    temp += optimizedConfiguration[i];
                    temp += "/ ";
                }
            }
            else
            {
                temp += "-";
            }
            return temp;
        }

        public string ToSaveFormat()
        {
            string toSave = this.optimizeCycle + "\t"
                          + this.optimizeTime + "\t"
                          + this.IAWR + "\t"
                          + this.IAWRThreshold + "\t"
                          + this.OriginConfigToString() + "\t"
                          + this.OptimizedConfigToString();

            return toSave;
        }
    }
}
