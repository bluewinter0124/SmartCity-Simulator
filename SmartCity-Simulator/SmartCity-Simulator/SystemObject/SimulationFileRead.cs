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

namespace SmartCitySimulator.SystemManagers
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

                if (newLine.IndexOf("mapFilename:") != -1)
                    Simulator.mapFilePicturePath = newLine.Substring(newLine.IndexOf(":") + 1);

                else if (newLine.IndexOf("@") != -1)
                    break;
            }

            while (!mapFileReader.EndOfStream)
            {
                newLine = mapFileReader.ReadLine();

                if (newLine.IndexOf("road") != -1)
                    CreateNewRoad(mapFileReader,Simulator.RoadManager.roadList.Count);

                else if (newLine.IndexOf("intersection") != -1)
                    CreateNewIntersection(mapFileReader,System.Convert.ToInt16(newLine.Split(' ')[1]));

                else if (newLine.IndexOf("@") != -1)
                    break;
            }
                
                Simulator.UI.IntersectionStateInitialize();

        }


        public void CreateNewRoad(StreamReader mapfile,int roadID)
        {
            Road newRoad = new Road(roadID);
            string newLine;

            while (true)
            {
                newLine = mapfile.ReadLine();
                if (newLine.IndexOf("path") != -1 || newLine.IndexOf("Path") != -1)
                {
                    string[] nodes = newLine.Split(':')[1].Split(';');
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        int x = System.Convert.ToInt32(nodes[i].Split(',')[0]);
                        int y = System.Convert.ToInt32(nodes[i].Split(',')[1]);
                        Point node = new Point(x,y);
                        newRoad.addRoadNode(node);
                    }
                }
                else if (newLine.IndexOf("connect") != -1 || newLine.IndexOf("Connect") != -1)
                {
                    string[] connectRoads = newLine.Split(':')[1].Split(',');
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
                else
                {
                    string[] temp = newLine.Split(':');
                    int roadID = System.Convert.ToInt32(temp[1]);
                    int roadOrder = System.Convert.ToInt32(temp[2]);
                    Simulator.RoadManager.GetRoadByID(roadID).order = roadOrder;
                    Simulator.IntersectionManager.AddRoadToIntersection(intersectionID, roadID);
                    Simulator.UI.AddMessage("System", "Road " + System.Convert.ToInt32(temp[1]) + " is add to Intersection " + intersectionID);

                }
            }
            Simulator.UI.AddMessage("System", "Intersection : " + intersectionID + " is create complete");
        }



        public void LoadSimulationFile()
        {
            StreamReader simFileReader = new StreamReader(Simulator.simulationFilePath);
            
            while(!simFileReader.EndOfStream)
            {
                string newLine = simFileReader.ReadLine();

                if (newLine.IndexOf("intersection") != -1)
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
                            int[] LightSet_int = {System.Convert.ToInt32(lightSet[0]), System.Convert.ToInt32(lightSet[1]), System.Convert.ToInt32(lightSet[2]), System.Convert.ToInt32(lightSet[3]) };
                            Simulator.IntersectionManager.GetIntersectionByID(intersectionID).LightSettingList.Add(LightSet_int);
                        }
                    }
                }

                if (newLine.IndexOf("CarGenerate") != -1)
                {
                    while (true)
                    {
                        newLine = simFileReader.ReadLine();
                        if (newLine.IndexOf("}") != -1)
                            break;
                        else
                            if (newLine.IndexOf("Road") != -1)
                            {
                                string[] temp = newLine.Split(':');
                                int roadID = System.Convert.ToInt32(temp[1]);
                                int carGenerationLevel = System.Convert.ToInt32(temp[2]);
                                Simulator.RoadManager.AddCarGenerateRoad(roadID);
                                Simulator.RoadManager.SetCarGenerationRate(roadID, carGenerationLevel);
                                Simulator.UI.AddMessage("System", "Road : " + Simulator.RoadManager.roadList[System.Convert.ToInt32(temp[1])].roadName + " GenerateRate set to " + Simulator.RoadManager.roadList[System.Convert.ToInt32(temp[1])].carGenerationRate);
                            }
                    }
                }
            }
                Simulator.IntersectionManager.InitializeLightStates();
                Simulator.PrototypeManager.ProtypeInitialize();
        }
    }
}
