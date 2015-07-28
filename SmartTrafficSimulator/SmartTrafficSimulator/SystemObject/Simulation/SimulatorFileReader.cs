using SmartTrafficSimulator.SystemManagers;
using SmartTrafficSimulator.SystemObject;
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
            XmlDoc.Load(filePath);

            String mapName = XmlDoc.SelectSingleNode("Map/MapName").InnerText;
            Simulator.mapName = mapName;

            String mapPicture = XmlDoc.SelectSingleNode("Map/MapPicture").InnerText;
            Simulator.mapPictureName = mapPicture;
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
                                newRoad.AddConnectRoadByID(System.Convert.ToInt16(id));
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
                            Simulator.RoadManager.GetRoadByID(roadID).phaseNo = System.Convert.ToInt16(composedRoad.Attributes["ConfigNo"].Value);
                            newIntersection.AddComposedRoad(roadID);
                        }
                    }

                }//intersection read end 
            }//read intersection configuration end 

            return true;
        }

        public Boolean SimulationFileRead_XML(String filePath)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(filePath);

            SimulationFileRead_IntersectionsConfig(XmlDoc);
            SimulationFileRead_VehicleGenerate(XmlDoc);
            return true;
        }

        public Boolean SimulationFileRead_IntersectionsConfig(XmlDocument XmlDoc)
        {
            XmlNodeList intersectionList = XmlDoc.SelectSingleNode("Simulation/IntersectionsConfig").ChildNodes; //get all intersection

            foreach (XmlNode intersectionNode in intersectionList)
            {
                Intersection intersection = Simulator.IntersectionManager.GetIntersectionByID(System.Convert.ToInt16(intersectionNode.Attributes["ID"].Value));

                XmlNodeList intersectionConfigs = intersectionNode.ChildNodes;
                foreach (XmlNode intersectionConfig in intersectionConfigs) //Read all config
                {
                    if (intersectionConfig.Name.Equals("SignalConfigs")) //Read signal config
                    {
                        XmlNodeList signalConfigs = intersectionConfig.ChildNodes;
                        foreach (XmlNode signalConfig in signalConfigs)
                        {
                            int green = System.Convert.ToInt32(signalConfig.Attributes["Green"].Value);
                            int yellow = System.Convert.ToInt32(signalConfig.Attributes["Yellow"].Value);
                            SignalConfig newConfig = new SignalConfig(green,yellow);
                            intersection.AddNewSignalSetting(newConfig);
                        }
                    }
                }
            }

            return true;
        }

        public Boolean SimulationFileRead_VehicleGenerate(XmlDocument XmlDoc)
        {
            XmlNodeList generateRoadList = XmlDoc.SelectSingleNode("Simulation/VehicleGenerate").ChildNodes; //get all generate road

            foreach (XmlNode generateRoadNode in generateRoadList)
            {
                Road generateRoad = Simulator.RoadManager.GetRoadByID(System.Convert.ToInt16(generateRoadNode.Attributes["ID"].Value));
                Simulator.RoadManager.AddVehicleGenerateRoad(System.Convert.ToInt16(generateRoadNode.Attributes["ID"].Value));

                int defaultLevel = System.Convert.ToInt16(generateRoadNode.Attributes["DefaultLevel"].Value);
                generateRoad.SetGenerateLevel(defaultLevel);

                XmlNodeList generateConfigs = generateRoadNode.ChildNodes;
                foreach (XmlNode generateConfig in generateConfigs)
                {
                    if (generateConfig.Name.Equals("GenerateSchedules"))
                    {
                        SimulationFileRead_GenerateSchedule(generateRoad, generateConfig);
                    }
                    else if (generateConfig.Name.Equals("DrivingPaths"))
                    {
                        SimulationFileRead_DrivingPath(generateRoad, generateConfig);
                    }
                }
            }

            return true;
        }

        public Boolean SimulationFileRead_GenerateSchedule(Road generateRoad, XmlNode generateSchedules)
        {
            XmlNodeList generateScheduleList = generateSchedules.ChildNodes;

            foreach (XmlNode generateSchedule in generateScheduleList)
            {
                string time = generateSchedule.Attributes["Time"].Value;
                int level = System.Convert.ToInt16(generateSchedule.Attributes["Level"].Value);
                generateRoad.AddGenerateSchedule(time, level);
            }
            return true;
        }
        public Boolean SimulationFileRead_DrivingPath(Road road, XmlNode drivingPaths)
        {
            XmlNodeList drivingPathList = drivingPaths.ChildNodes;

            foreach (XmlNode drivingPath in drivingPathList)
            {
                int startRoadID = System.Convert.ToInt16(drivingPath.Attributes["Start"].Value);
                int goalRoadID = System.Convert.ToInt16(drivingPath.Attributes["Goal"].Value);
                int Probability = System.Convert.ToInt16(drivingPath.Attributes["Probability"].Value);

                string passingRoad = drivingPath.Attributes["Passing"].Value;

                Simulator.VehicleManager.AddDrivingPath(new DrivingPath(startRoadID,goalRoadID,Probability,passingRoad));
            }
            return true;
        }
    }


}
