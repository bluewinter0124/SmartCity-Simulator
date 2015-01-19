using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.Unit;

namespace SmartTrafficSimulator.SystemObject
{
    class IntersectionManager
    {
        public Boolean AIOptimazation = false;

        private List<Intersection> intersectionList = new List<Intersection>();
        public Intersection virtualIntersection;

        public double defaultIAWR = 50.0;
        public int defaultOptimizeInterval = 10;
        public Boolean dynamicIAWR = true;

        public Boolean refreshRequest = false;

        public void InitializeIntersectionsManager()
        {
            for (int i = 0; i < intersectionList.Count(); i++)
            {
                intersectionList[i].Initialize();
            }
        }

        public void InitializeLightStates()
        {
            for (int i = 0; i < intersectionList.Count(); i++)
            {
                if(Simulator.TESTMODE)
                    Simulator.UI.AddMessage("System", "Intersection : " + intersectionList[i].intersectionID + " is initialize");

                intersectionList[i].RenewLightStateList();
                intersectionList[i].RefreshLightGraphic();
            }
        }

        public void AIOn()
        {
            AIOptimazation = true;
            Simulator.UI.RefreshAIStatus();
            Simulator.UI.AddMessage("AI","On");
        }

        public void AIOff()
        {
            AIOptimazation = false;
            Simulator.UI.RefreshAIStatus();
            Simulator.UI.AddMessage("AI", "Off");
        }
        public void EnableDynamicIAWR(Boolean available)
        {
            dynamicIAWR = available;
            for (int i = 0; i < intersectionList.Count; i++)
            {
                intersectionList[i].EnableDynamicIAWR(available);
            }
        }

        public void AddNewIntersection(int IntersectionID)
        {
            Intersection newIntersection = new Intersection(IntersectionID);
            if (IntersectionID == -1)
                virtualIntersection = newIntersection;
            else
                intersectionList.Add(newIntersection);
        }

        public void AddRoadToIntersection(int IntersectionID, int RoadID)
        {
            Road addedRoad = Simulator.RoadManager.GetRoadByID(RoadID);
            addedRoad.locateIntersectionID = IntersectionID;
            GetIntersectionByID(IntersectionID).roadList.Add(addedRoad);
        }

        public int CountIntersections()
        {
            return intersectionList.Count;
        }

        public Intersection GetIntersectionByID(int id)
        {
            if (id == -1)
                return virtualIntersection;
            else
                return intersectionList[id];
        }

        public List<Intersection> GetIntersectionList()
        {
            return intersectionList;
        }

        public void callRefreshRequest() 
        {
            if (!refreshRequest)
                refreshRequest = true;
        }

        public void AllIntersectionCountDown()
        {
            for (int i = 0; i < intersectionList.Count(); i++)
            {
                intersectionList[i].LightCountDown();
            }

        }

    }
}
