using SmartTrafficSimulator.Unit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace SmartTrafficSimulator.SystemObject
{
    class SimulatorFileReader
    {
        public Boolean MapFileRead_XML(String filePath)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(filePath+".xml");

            String mapName = XmlDoc.SelectSingleNode("Map/MapName").InnerText;
            Simulator.mapName = mapName;

            String mapPicture = XmlDoc.SelectSingleNode("Map/MapPicture").InnerText;
            Simulator.mapPicture = mapPicture;
            Simulator.mapPicturePath = Simulator.mapFileFolder + "\\" + mapPicture;
            Simulator.UI.SetMapBackground(Simulator.mapPicturePath);


            XmlNodeList containRoads = XmlDoc.SelectSingleNode("Map/ContainRoads").ChildNodes;

            foreach (XmlNode singleRoad in containRoads)
            {
                Road newRoad = Simulator.RoadManager.CreateNewRoad();

                XmlNodeList RoadInfos = singleRoad.ChildNodes;
                String roadID,roadName;

                foreach(XmlNode roadInfo in RoadInfos)
                {
                    if (roadInfo.Name.Equals("ID"))
                    {
                        roadID = roadInfo.InnerText;
                    }
                    else if (roadInfo.Name.Equals("Name"))
                    {
                        roadName = roadInfo.InnerText;
                    }
                    else if (roadInfo.Name.Equals("Nodes"))
                    {
                        XmlNodeList roadNodes = roadInfo.ChildNodes;
                        foreach (XmlNode RoadNode in roadNodes)
                        {
                            newRoad.AddRoadNode(new Point(System.Convert.ToInt16(RoadNode.Attributes["X"].Value), System.Convert.ToInt16(RoadNode.Attributes["Y"].Value)));
                        }
                    }
                    else if (roadInfo.Name.Equals("ConnectedRoad"))
                    {
                        if (!roadInfo.InnerText.Equals(""))
                        {
                            String[] connectedRoads = roadInfo.InnerText.Split(',');
                            foreach (String id in connectedRoads)
                            {
                                newRoad.AddConnectRoad(System.Convert.ToInt16(id));
                            }
                        }
                    }
                }//one road read
            }//all containRoads read 

            XmlNodeList intersectionConfiguration = XmlDoc.SelectSingleNode("Map/IntersectionConfiguration").ChildNodes;
            foreach (XmlNode singleIntersection in intersectionConfiguration)
            {
                XmlNodeList intersectionInfos = singleIntersection.ChildNodes;
                String intersectionID, intersectionName;
                Intersection newIntersection = null;

                foreach (XmlNode intersectionInfo in intersectionInfos)
                {
                    if (intersectionInfo.Name.Equals("ID"))
                    {
                        intersectionID = intersectionInfo.InnerText;
                        Simulator.IntersectionManager.AddNewIntersection(System.Convert.ToInt16(intersectionInfo.InnerText));
                        newIntersection = Simulator.IntersectionManager.GetIntersectionByID(System.Convert.ToInt16(intersectionID));
                    }
                    else if (intersectionInfo.Name.Equals("Name"))
                    {
                        intersectionName = intersectionInfo.InnerText;
                        newIntersection.intersectionName = intersectionName;
                    }
                    else if (intersectionInfo.Name.Equals("ComposedRoads"))
                    {
                        foreach (XmlNode composedRoad in intersectionInfo.ChildNodes)
                        {
                            int roadID = System.Convert.ToInt16(composedRoad.Attributes["ID"].Value);
                            Simulator.RoadManager.GetRoadByID(roadID).order = System.Convert.ToInt16(composedRoad.Attributes["ConfigNo"].Value);
                            newIntersection.AddComposedRoad(roadID);
                        }
                    }

                }//intersection read end 
            }//read intersection configuration end 

            return true;
        }

    }


}
