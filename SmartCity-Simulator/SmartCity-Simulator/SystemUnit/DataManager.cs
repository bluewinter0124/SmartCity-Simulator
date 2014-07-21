using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator.SystemUnit
{
    class DataManager
    {
        Dictionary<int, List<CycleRecord>> Database = new Dictionary<int,List<CycleRecord>>();

        public void RegisterRoad(int roadID)
        { 
            List<CycleRecord> intersectionRecord = new List<CycleRecord>();
            Database.Add(roadID, intersectionRecord);
        }

        public void StoreRecord(int roadID, CycleRecord record)
        {
            Database[roadID].Add(record);
            //Test Code
            Simulator.UI.AddMessage("System", "Road : " + roadID + " store data to database");
        }

        public double GetArrivalRate(int RoadID, int startCycle, int endCycle)
        {
            double arrivalRate = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                arrivalRate += Database[RoadID][cycle].arrivedCars;
            }

            arrivalRate /= cycles;

            return Math.Round(arrivalRate,2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingTime(int RoadID, int startCycle, int endCycle)
        {
            double averageWaittingTime = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                averageWaittingTime += Database[RoadID][cycle].WaitingTimeOfAllCars / Database[RoadID][cycle].arrivedCars;
            }

            averageWaittingTime /= cycles;

            return Math.Round(averageWaittingTime,2,MidpointRounding.AwayFromZero);
        }

        public double GetWaittingRate(int RoadID, int startCycle, int endCycle)
        {
            double waittingRate = 0;
            int cycles = (endCycle - startCycle) + 1;

            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                waittingRate += Database[RoadID][cycle].WaitingCars / Database[RoadID][cycle].arrivedCars;
            }

            waittingRate /= cycles;

            return Math.Round(waittingRate, 2, MidpointRounding.AwayFromZero);
        }

        public double GetIntersectionAvgWaitingTime(int intersectionID, int startCycle, int endCycle)
        {

            List<Road> roadList = Simulator.IntersectionManager.IntersectionList[intersectionID].roadList;
            List<double> roadWeight = new List<double>();
            double intersectionAvgWaitingTime = 0;
            double totalArrivalRate = 0;

            for (int r = 0; r < roadList.Count; r++)
            {
                double arrivalRate = GetArrivalRate(roadList[r].roadID, startCycle, endCycle);
                roadWeight.Add(arrivalRate);
                totalArrivalRate += arrivalRate;
            }

            for (int r = 0; r < roadList.Count; r++)
            {
                roadWeight[r] /= totalArrivalRate;
                intersectionAvgWaitingTime += roadWeight[r] * GetAvgWaittingTime(roadList[r].roadID, startCycle, endCycle);
            }

            return Math.Round(intersectionAvgWaitingTime, 2, MidpointRounding.AwayFromZero);
        }

        public double GetIntersectionAvgWaitingRate(int intersectionID, int startCycle, int endCycle)
        {

            List<Road> roadList = Simulator.IntersectionManager.IntersectionList[intersectionID].roadList;
            List<double> roadWeight = new List<double>();
            double intersectionAvgWaitingRate = 0;
            double totalArrivalRate = 0;

            for (int r = 0; r < roadList.Count; r++)
            {
                double arrivalRate = GetArrivalRate(roadList[r].roadID, startCycle, endCycle);
                roadWeight.Add(arrivalRate);
                totalArrivalRate += arrivalRate;
            }

            for (int r = 0; r < roadList.Count; r++)
            {
                roadWeight[r] /= totalArrivalRate;
                intersectionAvgWaitingRate += roadWeight[r] * GetWaittingRate(roadList[r].roadID, startCycle, endCycle);
            }

            return Math.Round(intersectionAvgWaitingRate, 2, MidpointRounding.AwayFromZero);
        }

    }
}
