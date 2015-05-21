using SignalOptimization_GA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class TrafficOptimization
    {
        Boolean cycleLengthFixed = true;
        int phases = 2;
        int maxGreen = 90;
        int minGreen = 30;

        public List<RoadInfo> roadInfoList = new List<RoadInfo>();

        // optimizations
        Optimization_GA optimization_GA = new Optimization_GA();


        public TrafficOptimization(int minGreen, int maxGreen, Boolean cycleLengthFixed)
        {
            this.cycleLengthFixed = cycleLengthFixed;
            this.minGreen = minGreen;
            this.maxGreen = maxGreen;
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

        public void AddRoad(int roadID, int phaseNo, int curGreen, int curRed, double avgArriVehicle_min, double avgQueue, double avgWaitingRate)
        {
            RoadInfo newRoadInfo = new RoadInfo(roadID, phaseNo, curGreen, curRed, avgArriVehicle_min, avgQueue, avgWaitingRate);
            this.roadInfoList.Add(newRoadInfo);
        }

        public void CleanRoadList()
        {
            this.roadInfoList.Clear();
        }

        public Dictionary<int,int> Optimization_GA()
        {
            return optimization_GA.Optimize(cycleLengthFixed,phases, minGreen, maxGreen, roadInfoList);
        }

        public List<string> GetRecord_GA()
        {
            return optimization_GA.GetOptimizationRecoed();
        }

        public void Config_GA_Parameter(int popuSize, int generation, double crossover, double mutation)
        { 
            optimization_GA.Config_GAParameter(popuSize,generation,crossover,mutation);
        }

        public void Config_GA_FitnessWeight(double IAWR, double TDF, double CLF)
        {
            optimization_GA.Config_FitnessWeight(IAWR, TDF, CLF);
        }
    }
}
