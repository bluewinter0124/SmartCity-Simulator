using SmartTrafficSimulator;
using SmartTrafficSimulator.SystemManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartTrafficSimulator.OptimizationModels.GA_Yo;
using SmartTrafficSimulator.OptimizationModels.GA;
using SmartTrafficSimulator.OptimizationModels.Other;

namespace Optimization
{
    class TrafficOptimization
    {
        Boolean useGlobalConfig = true;

        Boolean cycleLengthFixed = true;
        int phases = 2;
        int maxGreen = 90;
        int minGreen = 30;

        List<RoadInfo> roadInfoList = new List<RoadInfo>();

        public Optimization_GA optimization_GA = new Optimization_GA();
        public Optimization_GT optimization_GT = new Optimization_GT();
        public Optimization_GA_YO optimization_GA_YO = new Optimization_GA_YO();

        public TrafficOptimization(int minGreen, int maxGreen, Boolean cycleLengthFixed)
        {
            this.cycleLengthFixed = cycleLengthFixed;
            this.minGreen = minGreen;
            this.maxGreen = maxGreen;
        }
        public void UseGlobalParameters(Boolean isUse)
        {
            useGlobalConfig = isUse;
        }

        public void setCycleLengthFixed(Boolean isFixed)
        {
            this.cycleLengthFixed = isFixed;
        }

        public Boolean getCycleLengthFixed()
        {
            return cycleLengthFixed;
        }

        public void setPhases(int phases)
        {
            this.phases = phases;
        }

        public int getPhase()
        {
            return phases;
        }

        public void setMaxGreen(int newMaxGreen)
        {
            this.maxGreen = newMaxGreen;
        }

        public int getMaxGreen()
        {
            return maxGreen;
        }

        public void setMinGreen(int newMinGreen)
        {
            this.minGreen = newMinGreen;
        }

        public int getMinGreen()
        {
            return minGreen;
        }

        public void AddRoad(int roadID, int phaseNo, int curGreen, int curRed, double avgArriVehicle_min, double avgDepartureRate_min,double avgQueue, double avgWaitingRate)
        {
            RoadInfo newRoadInfo = new RoadInfo(roadID, phaseNo, curGreen, curRed, avgArriVehicle_min,avgDepartureRate_min,avgQueue, avgWaitingRate);
            this.roadInfoList.Add(newRoadInfo);
        }

        public void CleanRoadList()
        {
            this.roadInfoList.Clear();
        }

        public Dictionary<int, int> Optimization()
        {
            if (Simulator.AIManager.GetEnableTrafficVolumePredection())
            {
                int interval_seconds = 600;
                int useData = 4;

                foreach (RoadInfo ri in roadInfoList)
                {
                    ri.UsePredictionArrivalRate(interval_seconds, useData);
                }
            }

            if (Simulator.AIManager.GetoptimizationMethodID() == 0)
            {
                return optimization_GA.Optimize(cycleLengthFixed, phases, minGreen, maxGreen, roadInfoList);
            }
            else if (Simulator.AIManager.GetoptimizationMethodID() == 1)
            {
                return optimization_GT.Optimize(cycleLengthFixed, phases, minGreen, maxGreen, roadInfoList);
            }
            else if (Simulator.AIManager.GetoptimizationMethodID() == 2)
            {
                return optimization_GA_YO.Optimize(cycleLengthFixed, phases, minGreen, maxGreen, roadInfoList);
            }
            else
            {
                return optimization_GA.Optimize(cycleLengthFixed, phases, minGreen, maxGreen, roadInfoList);
            }
        }
        
        public List<string> GetRecord_GA()
        {
            return optimization_GA.GetOptimizationRecoeds();
        }

    }
}
