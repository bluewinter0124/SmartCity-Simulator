using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrafficAI
{
    class Direction
    {
        List<int> roadIDList = new List<int>();

        int dirConfig;

        int dirCurrentGreen;
        List<int> currentGreenList;

        List<int> neighborGreen;

        double dirAverageArrival;
        List<double> averageArrivalList;

        double dirAverageQueue;
        List<double> averageQueueList;

        public Direction(int order)
        {
            this.dirConfig = order;
        }

        public void AddRoad(int roadID,int curGreen, int neiGreen, double avgArrival, double avgQueue)
        {
            this.roadIDList.Add(roadID);
            this.currentGreenList.Add(curGreen);
            this.neighborGreen.Add(neiGreen);
            this.averageArrivalList.Add(avgArrival);
            this.averageQueueList.Add(avgQueue);

            Calculate_Normal();
        }

        public void Calculate_Normal()
        {
            int roads = roadIDList.Count;

            foreach(int curGreen in currentGreenList)
            {
                this.dirCurrentGreen += curGreen;
            }
            this.dirCurrentGreen /= roads;

            foreach (int avgArrival in averageArrivalList)
            {
                this.dirAverageArrival += avgArrival;
            }
            this.dirAverageArrival /= roads;

            foreach (int avgQueue in averageQueueList)
            {
                this.dirAverageQueue += avgQueue;
            }
            this.dirAverageQueue /= roads;
        
        }

        public void Calculate_Weight()
        {
            int roads = roadIDList.Count;



            foreach (int curGreen in currentGreenList)
            {
                this.dirCurrentGreen += curGreen;
            }
            this.dirCurrentGreen /= roads;

            foreach (int avgArrival in averageArrivalList)
            {
                this.dirAverageArrival += avgArrival;
            }
            this.dirAverageArrival /= roads;

            foreach (int avgQueue in averageQueueList)
            {
                this.dirAverageQueue += avgQueue;
            }
            this.dirAverageQueue /= roads;

        }
    }
}
