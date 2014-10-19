using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;
using SmartCitySimulator.SystemObject;

namespace SmartCitySimulator.SystemObject
{
    class DataManager
    {
        Dictionary<int, List<CycleRecord>> TrafficData;
        Dictionary<int, Dictionary<int,OptimizationRecord>> OptimizationData;

        public void InitializeDataManager()
        {
            TrafficData = new Dictionary<int, List<CycleRecord>>();
            OptimizationData = new Dictionary<int, Dictionary<int, OptimizationRecord>>();
        }

        public void RegisterRoad(int roadID)
        { 
            List<CycleRecord> trafficRecord = new List<CycleRecord>();
            TrafficData.Add(roadID,trafficRecord);
        }

        public void RegisterIntersection(int intersectionID)
        {
            Dictionary<int, OptimizationRecord> optimizationRecord = new Dictionary<int, OptimizationRecord>();
            OptimizationData.Add(intersectionID, optimizationRecord);
        }

        public void StoreCycleRecord(int roadID, CycleRecord cycleRecord)
        {
            TrafficData[roadID].Add(cycleRecord);
        }

        public void StoreOptimizationRecord(int intersectionID, OptimizationRecord optRecord)
        {
            int cycle = optRecord.optimizeCycle;
            OptimizationData[intersectionID].Add(cycle, optRecord);
        }

        public CycleRecord GetCycleRecord(int roadID, int cycle)
        {
            return TrafficData[roadID][cycle];
        }

        public OptimizationRecord GetOptimizationRecord(int roadID, int cycle)
        {
            if (OptimizationData[roadID].ContainsKey(cycle))
                return OptimizationData[roadID][cycle];
            else
                return null;
        }

        public List<OptimizationRecord> GetOptimizationRecords(int intersectionID, int startCycle, int endCycle)
        {
            int maxCycle = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).currentCycle;
            List<OptimizationRecord> searchResult = new List<OptimizationRecord>();

            if (startCycle > maxCycle)
                startCycle = maxCycle;

            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle > maxCycle || endCycle <= 0)
                endCycle = maxCycle;

            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                if (OptimizationData[intersectionID].ContainsKey(cycle))
                    searchResult.Add(OptimizationData[intersectionID][cycle]);
            }

            return searchResult;
        }

        public int CountTrafficRecords(int roadID)
        {
            return TrafficData[roadID].Count;
        }

        public int CountOptimizationRecords(int roadID)
        {
            return OptimizationData[roadID].Keys.Count();
        }

        public double GetArrivalRate(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;

            double arrivalRate = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                arrivalRate += TrafficData[RoadID][cycle].arrivedVehicles;
            }

            if (cycles > 0)
                arrivalRate /= cycles;

            return Math.Round(arrivalRate,2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingRate(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;

            double waittingRate = 0;
            int cycles = (endCycle - startCycle) + 1;

            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                waittingRate += TrafficData[RoadID][cycle].WaittingRate;
            }

            if (cycles > 0)
                waittingRate = ((waittingRate *100) / cycles);

            return Math.Round(waittingRate, 2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingVehicles(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;

            double averageWaittingVehicles = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                averageWaittingVehicles += TrafficData[RoadID][cycle].WaitingVehicles;
            }

            if (cycles > 0)
                averageWaittingVehicles /= cycles;

            return Math.Round(averageWaittingVehicles, 2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingTime(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;


            double averageWaittingTime = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                averageWaittingTime += TrafficData[RoadID][cycle].AvgWaittingTime;
            }
            if (cycles > 0)
                averageWaittingTime /= cycles;

            return Math.Round(averageWaittingTime,2,MidpointRounding.AwayFromZero);
        }

        public double GetIntersectionAvgWaitingTime(int intersectionID, int startCycle, int endCycle)
        {
            if (startCycle > endCycle)
                startCycle = endCycle;
            else if (startCycle < 0)
                startCycle = 0;

            List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;
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
                if (totalArrivalRate != 0)
                    roadWeight[r] /= totalArrivalRate;
                intersectionAvgWaitingTime += roadWeight[r] * GetAvgWaittingTime(roadList[r].roadID, startCycle, endCycle);
            }

            return Math.Round(intersectionAvgWaitingTime, 2, MidpointRounding.AwayFromZero);
        }

        public double GetIntersectionAvgWaitingRate(int intersectionID, int startCycle, int endCycle)
        {
            if (startCycle > endCycle)
                startCycle = endCycle;
            else if (startCycle < 0)
                startCycle = 0;

            List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;
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
                if (totalArrivalRate != 0)
                    roadWeight[r] /= totalArrivalRate;
                intersectionAvgWaitingRate += roadWeight[r] * GetAvgWaittingRate(roadList[r].roadID, startCycle, endCycle);
            }

            return Math.Round(intersectionAvgWaitingRate, 2, MidpointRounding.AwayFromZero);
        }

    }
}