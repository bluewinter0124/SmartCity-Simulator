using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator.SystemUnit
{
    class IntersectionManager
    {

        public List<Intersection> IntersectionList = new List<Intersection>();

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
            Simulator.UI.RefreshRoadInfomation(0);
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
