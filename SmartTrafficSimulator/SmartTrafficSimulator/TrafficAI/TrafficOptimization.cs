using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrafficAI
{
    class TrafficOptimization
    {
        Boolean cycleLengthFixed = true;

        int maxGreen = 90;
        int minGreen = 30;

        Dictionary<int, Direction> directions = new Dictionary<int,Direction>();

        // optimizations
        GAOptimization GAOptimization = new GAOptimization();

        public void setCycleLengthFixed(Boolean isFixed)
        {
            this.cycleLengthFixed = isFixed; 
        }

        public Boolean getCycleLengthFixed()
        {
            return cycleLengthFixed;
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

        public void AddRoad(int roadID, int config, int curGreen, int neiGreen, double avgArrival, double avgQueue)
        {
            if (directions.ContainsKey(config))
            {
                Direction newDirection = new Direction(config);
                directions.Add(config, newDirection);
            }
            directions[config].AddRoad(roadID, curGreen, neiGreen, avgArrival, avgQueue);
        }

        public void CleanRoadList()
        {
            directions.Clear();
        }

        public void GAOptimize()
        {
            int[] configs = directions.Keys.ToArray<int>();
            List<Direction> directionList = new List<Direction>();

            foreach (int order in configs)
            {
                directionList.Add(directions[order]);
            }

            GAOptimization.Optimize(cycleLengthFixed, maxGreen, minGreen, directionList);
        }

    }
}
