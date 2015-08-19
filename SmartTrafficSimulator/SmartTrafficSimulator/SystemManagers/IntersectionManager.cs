using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.SystemObject;

namespace SmartTrafficSimulator.SystemManagers
{
    class IntersectionManager
    {
        private List<Intersection> intersectionList = new List<Intersection>();
        public Intersection virtualIntersection;

        public double defaultIAWR = 45.0;
        public int defaultOptimizeInterval = 5;

        public Boolean signalRefreshRequest = false;

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
                if (Simulator.TESTMODE)
                    Simulator.UI.AddMessage("System", "Intersection : " + intersectionList[i].intersectionID + " is initialize");
                intersectionList[i].RenewSignalStatusList();
                intersectionList[i].RefreshSignalGraphic();
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
            if (!signalRefreshRequest)
                signalRefreshRequest = true;
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
