using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator.SystemUnit
{
    class IntersectionManager
    {

        private List<Intersection> IntersectionList = new List<Intersection>();
        public Intersection VirtualIntersection = new Intersection(-1);

        public Boolean refreshRequest = false;

        public IntersectionManager()
        {
            //this.intersectionList = new IntersectionList(SimulatorConfiguration.MapInfo.totalInter);
        }

        public void InitialIntersection()
        {
            for (int i = 0; i < IntersectionList.Count(); i++)
            {
                if (IntersectionList[i].intersectionID != 999)
                {
                    Simulator.UI.AddMessage("System", "Intersection : " + IntersectionList[i].intersectionID + " is initialize");
                    IntersectionList[i].RenewLightStateList();
                    IntersectionList[i].RefreshLightGraphicDisplay();
                }
            }
            //Simulator.UI.RefreshRoadInfomation(0);
        }

        public void AddNewIntersection(int IntersectionID)
        {
            Intersection newIntersection = new Intersection(IntersectionID);
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
            return IntersectionList.Count - 1;
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
