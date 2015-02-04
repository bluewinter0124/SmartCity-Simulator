using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.SystemObject
{
    class DrivingPath
    {
        int startRoadID = 0;
        int goalRoadID = 0;
        List<int> passingRoad = new List<int>();

        int probability = 1;

        public void SetStartRoadID(int roadID)
        {
            startRoadID = roadID;
        }

        public int GetStartRoadID()
        {
            return startRoadID;
        }

        public void SetGoalRoadID(int roadID)
        {
            goalRoadID = roadID;
        }

        public int GetGoalRoadID()
        {
            return goalRoadID;
        }

        public void AddPassingRoad(int roadID)
        {
            passingRoad.Add(roadID);
        }

        public void RemovePassingRoad(int roadID)
        {
            passingRoad.Remove(roadID);
        }

        public List<int> GetPassingRoads()
        {
            return passingRoad;
        }
        public string GetPassingRoadsID()
        {
            string passingRoadsID = "";
            for (int i = 0; i < passingRoad.Count; i++)
            {
                passingRoadsID += passingRoad[i];
                if (i < passingRoad.Count - 1)
                    passingRoadsID += ",";
            }
            return passingRoadsID;
        }

        public void setProbability(int probability)
        {
            this.probability = probability;
        }

        public int getProbability()
        {
            return probability;
        }

        public string GetName()
        {
            string name = startRoadID + "-";
            for (int i = 0; i < passingRoad.Count; i++)
            {
                name += passingRoad[i] + "-";
            }
            name += goalRoadID;

            return name;
        }
    }
}
