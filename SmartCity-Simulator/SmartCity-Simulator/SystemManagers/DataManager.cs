using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator.SystemManagers
{
    class DataManager
    {
        Dictionary<int, List<CycleRecord>> Database;

        public void InitializeDataManager()
        {
            Database = new Dictionary<int, List<CycleRecord>>();
        }

        public void RegisterRoad(int roadID)
        { 
            List<CycleRecord> intersectionRecord = new List<CycleRecord>();
            Database.Add(roadID, intersectionRecord);
        }

        public void StoreRecord(int roadID, CycleRecord record)
        {
            Database[roadID].Add(record);
            //Test Code
            //Simulator.UI.AddMessage("System", "Road : " + roadID + " store data to database");
        }

        public CycleRecord GetRecord(int roadID, int cycle)
        {
            return Database[roadID][cycle];
        }

        public int CountRecords(int roadID)
        {
            return Database[roadID].Count;
        }

        public double GetArrivalRate(int RoadID, int startCycle, int endCycle)
        {
            if (Database[RoadID].Count == 0)
                return 0;   

            if (startCycle >= Database[RoadID].Count)
                startCycle = Database[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= Database[RoadID].Count || endCycle <= 0)
                endCycle = Database[RoadID].Count - 1;

            double arrivalRate = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                arrivalRate += Database[RoadID][cycle].arrivedVehicles;
            }

            if (cycles > 0)
                arrivalRate /= cycles;

            return Math.Round(arrivalRate,2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingRate(int RoadID, int startCycle, int endCycle)
        {
            if (Database[RoadID].Count == 0)
                return 0;   

            if (startCycle >= Database[RoadID].Count)
                startCycle = Database[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= Database[RoadID].Count || endCycle <= 0)
                endCycle = Database[RoadID].Count - 1;

            double waittingRate = 0;
            int cycles = (endCycle - startCycle) + 1;

            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                waittingRate += Database[RoadID][cycle].WaittingRate;
            }

            if (cycles > 0)
                waittingRate = ((waittingRate *100) / cycles);

            return Math.Round(waittingRate, 2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingVehicles(int RoadID, int startCycle, int endCycle)
        {
            if (Database[RoadID].Count == 0)
                return 0;   

            if (startCycle >= Database[RoadID].Count)
                startCycle = Database[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= Database[RoadID].Count || endCycle <= 0)
                endCycle = Database[RoadID].Count - 1;

            double averageWaittingVehicles = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                averageWaittingVehicles += Database[RoadID][cycle].WaitingVehicles;
            }

            if (cycles > 0)
                averageWaittingVehicles /= cycles;

            return Math.Round(averageWaittingVehicles, 2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingTime(int RoadID, int startCycle, int endCycle)
        {
            if (Database[RoadID].Count == 0)
                return 0;   

            if (startCycle >= Database[RoadID].Count)
                startCycle = Database[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= Database[RoadID].Count || endCycle <= 0)
                endCycle = Database[RoadID].Count - 1;


            double averageWaittingTime = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                averageWaittingTime += Database[RoadID][cycle].AvgWaittingTime;
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