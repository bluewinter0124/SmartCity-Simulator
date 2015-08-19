using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using SmartTrafficSimulator;
using System.Xml;
using SmartTrafficSimulator.SystemObject;
using System.Drawing;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.SystemObject
{
    class SimulationFileWriter
    {
        public void SaveMapFile_XML()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "xml files (*.xml)|*.xml";
            save.Title = "Save Map File To";

            if (save.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                XmlElement map = doc.CreateElement("Map");
                doc.AppendChild(map);

                XmlElement MapName = doc.CreateElement("MapName");
                MapName.InnerText = Simulator.mapFileName;
                map.AppendChild(MapName);

                XmlElement MapPicture = doc.CreateElement("MapPicture");
                MapPicture.InnerText = Simulator.mapPictureName;
                map.AppendChild(MapPicture);

                XmlElement ContainsRoads = doc.CreateElement("ContainRoads");
                map.AppendChild(ContainsRoads);

                foreach (SmartTrafficSimulator.MapEditor.MapEditorRoad road in MapEditor.roadList)
                {
                    XmlElement roadInfo = doc.CreateElement("Road");

                    XmlElement ID = doc.CreateElement("ID");
                    ID.InnerText = road.roadID + "";
                    roadInfo.AppendChild(ID);

                    XmlElement Name = doc.CreateElement("Name");
                    Name.InnerText = road.roadName;
                    roadInfo.AppendChild(Name);

                    XmlElement Nodes = doc.CreateElement("Nodes");
                    roadInfo.AppendChild(Nodes);

                    XmlElement Node;
                    foreach (Point p in road.roadNode)
                    {
                        Node = doc.CreateElement("Node");
                        Node.SetAttribute("X", p.X + "");
                        Node.SetAttribute("Y", p.Y + "");
                        Nodes.AppendChild(Node);
                    }

                    XmlElement ConnectedRoad = doc.CreateElement("ConnectedRoad");
                    if (road.connectedRoadIDList.Count > 0)
                    {
                        roadInfo.AppendChild(ConnectedRoad);

                        string connectedRoadID = "";
                        for (int i = 0; i < road.connectedRoadIDList.Count; i++)
                        {
                            connectedRoadID += road.connectedRoadIDList[i];
                            if (i < road.connectedRoadIDList.Count - 1)
                                connectedRoadID += ",";
                        }
                        ConnectedRoad.InnerText = connectedRoadID;
                    }
                    ContainsRoads.AppendChild(roadInfo);
                }

                XmlElement IntersectionConfiguration = doc.CreateElement("IntersectionConfiguration");
                map.AppendChild(IntersectionConfiguration);

                foreach (SmartTrafficSimulator.MapEditor.MapEditorIntersection intersection in MapEditor.intersectionList)
                {
                    XmlElement intersectionInfo = doc.CreateElement("Intersection");

                    XmlElement ID = doc.CreateElement("ID");
                    ID.InnerText = intersection.intersectionID + "";
                    intersectionInfo.AppendChild(ID);

                    XmlElement Name = doc.CreateElement("Name");
                    Name.InnerText = intersection.intersectionName;
                    intersectionInfo.AppendChild(Name);

                    XmlElement composedRoads = doc.CreateElement("ComposedRoads");
                    intersectionInfo.AppendChild(composedRoads);

                    XmlElement composedRoad;
                    foreach (SmartTrafficSimulator.MapEditor.MapEditorRoad road in intersection.composedRoads)
                    {
                        composedRoad = doc.CreateElement("ComposedRoad");
                        composedRoad.SetAttribute("ID", road.roadID + "");
                        composedRoad.SetAttribute("ConfigNo", road.configNo + "");
                        composedRoads.AppendChild(composedRoad);
                    }

                    IntersectionConfiguration.AppendChild(intersectionInfo);
                }

                doc.Save(save.FileName);
            }
        }

        public void SaveMapFileXML()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement map = doc.CreateElement("Map");
            doc.AppendChild(map);

            XmlElement MapName = doc.CreateElement("MapName");
            MapName.InnerText = Simulator.mapFileName;
            map.AppendChild(MapName);

            XmlElement MapPicture = doc.CreateElement("MapPicture");
            MapPicture.InnerText = Simulator.mapPictureName;
            map.AppendChild(MapPicture);

            XmlElement ContainsRoads = doc.CreateElement("ContainRoads");
            map.AppendChild(ContainsRoads);

            foreach (Road road in Simulator.RoadManager.GetRoadList())
            {
                XmlElement roadInfo = doc.CreateElement("Road");

                XmlElement ID = doc.CreateElement("ID");
                ID.InnerText = road.roadID + "";
                roadInfo.AppendChild(ID);

                XmlElement Name = doc.CreateElement("Name");
                Name.InnerText = road.roadName;
                roadInfo.AppendChild(Name);

                XmlElement Nodes = doc.CreateElement("Nodes");
                roadInfo.AppendChild(Nodes);

                XmlElement Node;
                foreach (Point p in road.roadNodeList)
                {
                    Node = doc.CreateElement("Node");
                    Node.SetAttribute("X", p.X+"");
                    Node.SetAttribute("Y", p.Y+"");
                    Nodes.AppendChild(Node);
                }

                XmlElement ConnectedRoad = doc.CreateElement("ConnectedRoad");
                if (road.connectedRoadIDList.Count > 0)
                {
                    roadInfo.AppendChild(ConnectedRoad);

                    string connectedRoadID = "";
                    for (int i = 0; i < road.connectedRoadIDList.Count; i++)
                    {
                        connectedRoadID += road.connectedRoadIDList[i];
                        if (i < road.connectedRoadIDList.Count - 1)
                            connectedRoadID += ",";
                    }
                    ConnectedRoad.InnerText = connectedRoadID;
                }
                ContainsRoads.AppendChild(roadInfo);
            }

            XmlElement IntersectionConfiguration = doc.CreateElement("IntersectionConfiguration");
            map.AppendChild(IntersectionConfiguration);

            foreach (Intersection intersection in Simulator.IntersectionManager.GetIntersectionList())
            {
                XmlElement intersectionInfo = doc.CreateElement("Intersection");

                XmlElement ID = doc.CreateElement("ID");
                ID.InnerText = intersection.intersectionID + "";
                Simulator.UI.AddMessage("System", intersection.intersectionID + "");
                intersectionInfo.AppendChild(ID);

                XmlElement Name = doc.CreateElement("Name");
                Name.InnerText = intersection.intersectionName;
                intersectionInfo.AppendChild(Name);

                XmlElement composedRoads = doc.CreateElement("ComposedRoads");
                intersectionInfo.AppendChild(composedRoads);

                XmlElement composedRoad;
                foreach (Road road in intersection.roadList)
                {
                    composedRoad = doc.CreateElement("ComposedRoad");
                    composedRoad.SetAttribute("ID", road.roadID+"");
                    composedRoad.SetAttribute("ConfigNo",road.phaseNo+"");
                    composedRoads.AppendChild(composedRoad);
                }

                IntersectionConfiguration.AppendChild(intersectionInfo);
            }


            doc.Save(Simulator.mapFileFolder+"\\"+Simulator.mapName+".xml");
        }

        public void SaveSimulationFile_XML()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "xml files (*.xml)|*.xml";
            save.Title = "Save Simulation File To";

            if (save.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                XmlElement simulation = doc.CreateElement("Simulation");
                doc.AppendChild(simulation);

                XmlElement simulationName = doc.CreateElement("SimulationName");
                if (Simulator.TaskManager.GetCurrentTask() == null)
                {
                    simulationName.InnerText = "New Simulation";
                }
                else
                {
                    simulationName.InnerText = Simulator.TaskManager.GetCurrentTask().simulationName;
                }
                simulation.AppendChild(simulationName);

                XmlElement intersectionsConfig = doc.CreateElement("IntersectionsConfig");
                simulation.AppendChild(intersectionsConfig);

                //Write Signal Config
                foreach (Intersection intersection in Simulator.IntersectionManager.GetIntersectionList())
                {
                    XmlElement intersectionConfig = doc.CreateElement("Intersection");
                    intersectionsConfig.AppendChild(intersectionConfig);
                    intersectionConfig.SetAttribute("ID", intersection.intersectionID + "");

                    XmlElement signalConfigs = doc.CreateElement("SignalConfigs");
                    intersectionConfig.AppendChild(signalConfigs);

                    int configNO = 0;
                    foreach (SignalConfig sigCon in intersection.signalConfigList)
                    {
                        XmlElement signalConfig = doc.CreateElement("SignalConfig");
                        signalConfigs.AppendChild(signalConfig);
                        signalConfig.SetAttribute("ConfigNO", configNO + "");
                        signalConfig.SetAttribute("Green", sigCon.Green + "");
                        signalConfig.SetAttribute("Yellow", sigCon.Yellow + "");
                        configNO++;
                    }
                }
                //Write Signal Config end

                //Write Vehicle Generate Config
                XmlElement vehicleGenerate = doc.CreateElement("VehicleGenerate");
                simulation.AppendChild(vehicleGenerate);
                foreach (Road geneRoad in Simulator.RoadManager.GetGenerateVehicleRoadList())
                {
                    XmlElement generateRoad = doc.CreateElement("GenerateRoad");
                    vehicleGenerate.AppendChild(generateRoad);
                    generateRoad.SetAttribute("ID", geneRoad.roadID + "");
                    generateRoad.SetAttribute("DefaultLevel", geneRoad.generateLevel_lambda + "");

                    //Write Vehicle Generate  schedule
                    XmlElement generateSchedule = doc.CreateElement("GenerateSchedules");
                    generateRoad.AppendChild(generateSchedule);
                    string[] scheduleTime = geneRoad.generateSchedule.Keys.ToArray<string>();
                    foreach (string time in scheduleTime)
                    {
                        XmlElement schedule = doc.CreateElement("Schedule");
                        generateSchedule.AppendChild(schedule);
                        schedule.SetAttribute("Time", time);
                        schedule.SetAttribute("Level", geneRoad.generateSchedule[time] + "");
                    }
                    //Write Vehicle Generate  schedule end

                    XmlElement drivingPaths = doc.CreateElement("DrivingPaths");
                    generateRoad.AppendChild(drivingPaths);

                    Dictionary<string, DrivingPath> DrivingPaths = Simulator.VehicleManager.GetDrivingPathList()[geneRoad.roadID];
                    DrivingPath[] drivingPathList = DrivingPaths.Values.ToArray<DrivingPath>();
                    foreach (DrivingPath drivingPath in drivingPathList)
                    {
                        XmlElement newPath = doc.CreateElement("Path");
                        drivingPaths.AppendChild(newPath);
                        newPath.SetAttribute("Probability", drivingPath.GetProbability() + "");
                        newPath.SetAttribute("Start", drivingPath.GetStartRoadID() + "");
                        newPath.SetAttribute("Goal", drivingPath.GetGoalRoadID() + "");
                        newPath.SetAttribute("Passing", drivingPath.GetPassingRoadsID() + "");
                    }

                }

                doc.Save(save.FileName);
            }
        }
    }
}
