using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemObject
{
    class OptimizationRecord
    {
        public int optimizeCycle;
        public string optimizeTime;
        public double IAWR;
        public double IAWRThreshold;
        List<LightConfig> originConfiguration = new List<LightConfig>();
        List<LightConfig> optimizedConfiguration = new List<LightConfig>();

        public OptimizationRecord(int optimizeCycle,string time, double currentIAWR, double IAWRThreshold)
        {
            this.optimizeCycle = optimizeCycle;
            this.optimizeTime = time;
            this.IAWR = currentIAWR;
            this.IAWRThreshold = IAWRThreshold;
        }

        public void AddOriginConfiguration(LightConfig lightConfig)
        {
            originConfiguration.Add(lightConfig);
        }

        public void AddOptimizedConfiguration(LightConfig lightConfig)
        {
            optimizedConfiguration.Add(lightConfig);
        }

        public string OriginConfigToString()
        {
            string temp ="";
            if (originConfiguration.Count > 0)
            {
                for (int i = 0; i < originConfiguration.Count; i++)
                { 
                    temp += ("G:" + originConfiguration[i].Green + " ");
                    temp += ("Y:" + originConfiguration[i].Yellow + " ");
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
                    temp += ("G:" + optimizedConfiguration[i].Green + " ");
                    temp += ("Y:" + optimizedConfiguration[i].Yellow + " ");
                    temp += " / ";
                }
            }
            else
            {
                temp += "-";
            }
            return temp;
        }
    }
}
