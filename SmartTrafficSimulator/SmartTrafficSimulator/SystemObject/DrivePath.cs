using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.SystemObject
{
    public class DrivingPath
    {
        int startRoadID = 0;
        int goalRoadID = 0;
        List<int> passingRoad = new List<int>();

        int probability = 1;

        public DrivingPath()
        { }

        public DrivingPath(int startRoadID, int goalRoadID,int probability,string passingRoads)
        {
            this.startRoadID = startRoadID;
            this.goalRoadID = goalRoadID;
            this.probability = probability;

            if (!passingRoads.Equals(""))
            {
                string[] passingRoadIDs = passingRoads.Split(',');
                foreach (string roadID in passingRoadIDs)
                {
                    AddPassingRoad(System.Convert.ToInt16(roadID));
                }
            }
        }

        public DrivingPath(int startRoadID, int goalRoadID,int probability)
        {
            this.startRoadID = startRoadID;
            this.goalRoadID = goalRoadID;
            this.probability = probability;
        }

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

        public void SetProbability(int probability)
        {
            this.probability = probability;
        }

        public int GetProbability()
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
