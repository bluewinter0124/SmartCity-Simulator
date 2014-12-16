using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using SmartCitySimulator.Unit;
using SmartCitySimulator.GraphicUnit;
using System.Threading;
using SmartCitySimulator.SystemObject;

namespace SmartCitySimulator.SystemObject
{
    public class SimulationFileRead
    {
        public void LoadMapFile()
        {
            StreamReader mapFileReader = new StreamReader(Simulator.mapFilePath);
            string newLine;

             while (!mapFileReader.EndOfStream)
             {
                newLine = mapFileReader.ReadLine();

                if (newLine.IndexOf("mapFilename") != -1)
                    Simulator.mapPicturePath = newLine.Substring(newLine.IndexOf(" ") + 1);

                else if (newLine.IndexOf("@") != -1)
                    break;
            }

            while (!mapFileReader.EndOfStream)
            {
                newLine = mapFileReader.ReadLine();

                if (newLine.IndexOf("Road") != -1 || newLine.IndexOf("road") != -1)
                    CreateNewRoad(mapFileReader,Simulator.RoadManager.roadList.Count);

                else if (newLine.IndexOf("Intersection") != -1 || newLine.IndexOf("intersection") != -1)
                    CreateNewIntersection(mapFileReader,System.Convert.ToInt16(newLine.Split(' ')[1]));

                else if (newLine.IndexOf("@") != -1)
                    break;
            } 
        }


        public void CreateNewRoad(StreamReader mapfile,int roadID)
        {
            Road newRoad = new Road(roadID);
            string newLine;

            while (true)
            {
                newLine = mapfile.ReadLine();
                if (newLine.IndexOf("Path") != -1 || newLine.IndexOf("path") != -1)
                {
                    string[] nodes = newLine.Split(' ')[1].Split(';');
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        int x = System.Convert.ToInt32(nodes[i].Split(',')[0]);
                        int y = System.Convert.ToInt32(nodes[i].Split(',')[1]);
                        Point node = new Point(x,y);
                        newRoad.addRoadNode(node);
                    }
                }
                else if (newLine.IndexOf("Connect") != -1 || newLine.IndexOf("connect") != -1)
                {
                    string[] connectRoads = newLine.Split(' ')[1].Split(',');
                    for (int i = 0; i < connectRoads.Length; i++)
                    {
                        int connectRoadID = System.Convert.ToInt32(connectRoads[i]);
                        newRoad.addConnectRoad(connectRoadID);
                    }
                }
                else if (newLine.IndexOf("}") != -1)
                {
                    break;
                }
            }
            Simulator.RoadManager.roadList.Add(newRoad);
        }

        public void CreateNewIntersection(StreamReader mapfile,int intersectionID)
        {
            Simulator.IntersectionManager.AddNewIntersection(intersectionID);
            string newLine = mapfile.ReadLine(); //跳過 {
            while (true)
            {
                newLine = mapfile.ReadLine();
                if (newLine.IndexOf("}") != -1)
                    break;
                else if (newLine.IndexOf("Road") != -1 || newLine.IndexOf("road") != -1)
                {
                    string[] roadConfig = newLine.Split(' ');
                    int roadID = System.Convert.ToInt32(roadConfig[1]);
                    int roadOrder = System.Convert.ToInt32(roadConfig[2]);
                    Simulator.RoadManager.GetRoadByID(roadID).order = roadOrder;
                    Simulator.IntersectionManager.AddRoadToIntersection(intersectionID, roadID);
                    
                    if(Simulator.TESTMODE)
                        Simulator.UI.AddMessage("System", "Road " + System.Convert.ToInt32(roadConfig[1]) + " is add to Intersection " + intersectionID);

                }
            }
            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Intersection : " + intersectionID + " is create complete");
        }



        public void LoadSimulationFile()
        {
            StreamReader simFileReader = new StreamReader(Simulator.simulationFilePath);
            
            while(!simFileReader.EndOfStream)
            {
                string newLine = simFileReader.ReadLine();

                if (newLine.IndexOf("IntersectionConfig") != -1 || newLine.IndexOf("intersectionConfig") != -1)
                {
                    int intersectionID = System.Convert.ToInt32(newLine.Split(' ')[1]);
                    newLine = simFileReader.ReadLine();//跳過{
                    while (true)
                    {
                        newLine = simFileReader.ReadLine();
                        if (newLine.IndexOf("}") != -1)
                            break;
                        else
                        {
                            string[] temp = newLine.Split(' ');
                            string[] lightSet = temp[1].Split(':');
                            SignalConfig newConfig = new SignalConfig(System.Convert.ToInt32(lightSet[0]), System.Convert.ToInt32(lightSet[1]));
                            Simulator.IntersectionManager.GetIntersectionByID(intersectionID).AddNewLightSetting(newConfig);
                        }
                    }
                }

                if (newLine.IndexOf("VehicleGenerate") != -1)
                {
                    int roadID = System.Convert.ToInt32(newLine.Split(' ')[1]);
                    Simulator.RoadManager.AddVehicleGenerateRoad(roadID);
                    while (true)
                    {
                        Road generateRoad = Simulator.RoadManager.GetRoadByID(roadID);
                        newLine = simFileReader.ReadLine();
                        if (newLine.IndexOf("}") != -1)
                            break;
                        if (newLine.IndexOf("{") != -1)
                            continue;
                        else if (newLine.IndexOf("Start") != -1)
                        {
                            int level = System.Convert.ToInt32(newLine.Split(' ')[1]);
                            generateRoad.ChangeGenerateLevel(level);
                        }
                        else if (newLine.IndexOf("Schedule") != -1)
                        {
                            string[] temp = newLine.Split(' ');
                            string time = temp[1];
                            int level = System.Convert.ToInt32(temp[2]);
                            generateRoad.AddGenerateSchedule(time, level);
                        }
                    }
                }

                if (newLine.IndexOf("DrivingPath") != -1)
                {
                    int startRoadID = System.Convert.ToInt32(newLine.Split(' ')[1]);
                    
                    while (true)
                    {
                        newLine = simFileReader.ReadLine();

                        if (newLine.IndexOf("}") != -1)
                            break;
                        if (newLine.IndexOf("{") != -1)
                            continue;
                        if (newLine.IndexOf("Path") != -1)
                        {
                            string[] temp = newLine.Split(' ');
                            string[] passingRoad = temp[1].Split(',');
                            int probability = System.Convert.ToInt32(temp[2]);
                            
                            DrivingPath newDrivingPath = new DrivingPath();

                            newDrivingPath.setStartRoadID(startRoadID);
                            for (int i = 0; i < passingRoad.Length-1; i++)
                            {
                                newDrivingPath.AddPassingRoad(System.Convert.ToInt32(passingRoad[i]));
                            }
                            newDrivingPath.setGoalRoadID(System.Convert.ToInt32(passingRoad[passingRoad.Length - 1]));

                            newDrivingPath.setProbability(probability);

                            Simulator.VehicleManager.AddDrivingPath(newDrivingPath);
                        }
                    }
                }

            }
            Simulator.simulationConfigRead = true;
            Simulator.UI.RefreshSimulationConfigFileStatus();
        }//function end
    }
}
