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
        List<int> PassingRoad = new List<int>();

        int probability = 1;

        public void setStartRoadID(int roadID)
        {
            startRoadID = roadID;
        }

        public int getStartRoadID()
        {
            return startRoadID;
        }

        public void setGoalRoadID(int roadID)
        {
            goalRoadID = roadID;
        }

        public int getGoalRoadID()
        {
            return goalRoadID;
        }

        public void AddPassingRoad(int roadID)
        {
            PassingRoad.Add(roadID);
        }

        public void RemovePassingRoad(int roadID)
        {
            PassingRoad.Remove(roadID);
        }

        public List<int> getPassingRoads()
        {
            return PassingRoad;
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
            for (int i = 0; i < PassingRoad.Count; i++)
            {
                name += PassingRoad[i] + "-";
            }
            name += goalRoadID;

            return name;
        }
    }
}
