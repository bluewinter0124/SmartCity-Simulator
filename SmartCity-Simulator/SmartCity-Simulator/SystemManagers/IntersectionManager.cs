using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator.SystemManagers
{
    class IntersectionManager
    {
        public Boolean AIOptimazation = false;

        private List<Intersection> IntersectionList = new List<Intersection>();
        public Intersection VirtualIntersection;

        public Boolean refreshRequest = false;

        public void InitializeIntersectionsManager()
        {
            for (int i = 0; i < IntersectionList.Count(); i++)
            {
                IntersectionList[i].Initialize();
            }
        }

        public void InitializeLightStates()
        {
            for (int i = 0; i < IntersectionList.Count(); i++)
            {
                Simulator.UI.AddMessage("System", "Intersection : " + IntersectionList[i].intersectionID + " is initialize");

                IntersectionList[i].RenewLightStateList();
                IntersectionList[i].RefreshLightGraphicDisplay();
            }
        }

        public void AIOn()
        {
            AIOptimazation = true;
            Simulator.UI.RefreshAIStatus();
        }

        public void AIOff()
        {
            AIOptimazation = false;
            Simulator.UI.RefreshAIStatus();
        }

        public void AddNewIntersection(int IntersectionID)
        {
            Intersection newIntersection = new Intersection(IntersectionID);
            if (IntersectionID == -1)
                VirtualIntersection = newIntersection;
            else
                IntersectionList.Add(newIntersection);


        }

        public void AddRoadToIntersection(int IntersectionID, int RoadID)
        {
            Road addedRoad = Simulator.RoadManager.GetRoadByID(RoadID);
            addedRoad.locateIntersectionID = IntersectionID;
            GetIntersectionByID(IntersectionID).roadList.Add(addedRoad);
        }

        public int GetTotalIntersections()
        {
            return IntersectionList.Count;
        }

        public Intersection GetIntersectionByID(int id)
        {
            if (id == -1)
                return VirtualIntersection;
            else
                return IntersectionList[id];
        }

        public List<Intersection> GetIntersectionList()
        {
            return IntersectionList;
        }

        public void callRefreshRequest() 
        {
            if (!refreshRequest)
                refreshRequest = true;
        }

        public void AllIntersectionCountDown()
        {
            for (int i = 0; i < IntersectionList.Count(); i++)
            {
                IntersectionList[i].LightCountDown();
            }

        }

    }
}
