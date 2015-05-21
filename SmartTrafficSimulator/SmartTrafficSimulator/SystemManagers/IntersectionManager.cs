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
        public int defaultOptimizeInterval = 5;
        public Boolean dynamicIAWR = true;

        public Boolean refreshRequest = false;

        public void InitializeIntersections_Map()
        { 
            foreach(Intersection inte in intersectionList)
            {
                inte.EstablishAdjacentIntersectionInfo();
            }
        }

        public void InitializeIntersections_Simulation()
        {
            for (int i = 0; i < intersectionList.Count(); i++)
            {
                intersectionList[i].Initialize();
            }
        }

        public void InitializeSignalStates()
        {
            for (int i = 0; i < intersectionList.Count(); i++)
            {
                if(Simulator.TESTMODE)
                    Simulator.UI.AddMessage("System", "Intersection : " + intersectionList[i].intersectionID + " is initialize");

                intersectionList[i].RenewSignalStateList();
                intersectionList[i].RefreshSignalGraphic();
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

        public int GetNumberOfIntersections()
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
                intersectionList[i].SignalCountDown();
            }

        }

    }
}
