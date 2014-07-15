﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using SmartCitySimulator.Unit;
using SmartCitySimulator.GraphicUnit;
using System.Threading;

namespace SmartCitySimulator.SystemUnit
{
    public class ReadFile
    {
        public void LoadMapFile()
        {
            StreamReader mapFileReader = new StreamReader(SimulatorConfiguration.mapFilePath);
            string newLine;

             while (!mapFileReader.EndOfStream)
             {
                newLine = mapFileReader.ReadLine();

                if (newLine.IndexOf("mapFilename:") != -1)
                    SimulatorConfiguration.mapFilePicturePath = newLine.Substring(newLine.IndexOf(":") + 1);

                else if (newLine.IndexOf("scale:") != -1)
                    SimulatorConfiguration.mapScale = Convert.ToInt16(newLine.Substring(newLine.IndexOf(":") + 1));

                else if (newLine.IndexOf("@") != -1)
                    break;
            }

            while (!mapFileReader.EndOfStream)
            {
                newLine = mapFileReader.ReadLine();

                if (newLine.IndexOf("road") != -1)
                    CreateNewRoad(mapFileReader,SimulatorConfiguration.RoadManager.roadList.Count);

                else if (newLine.IndexOf("intersection") != -1)
                    CreateNewIntersection(mapFileReader,newLine.Split(' ')[1]);

                else if (newLine.IndexOf("@") != -1)
                    break;
            }
                
                SimulatorConfiguration.UI.RoadInfomationInitialize();

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
            SimulatorConfiguration.RoadManager.roadList.Add(newRoad);
        }

        public void CreateNewIntersection(StreamReader mapfile,string intersectionName)
        {
            Intersection newIntersection = new Intersection();
            newIntersection.intersectionName = intersectionName;
            string newLine = mapfile.ReadLine(); //跳過 {
            while (true)
            {
                newLine = mapfile.ReadLine();
                if (newLine.IndexOf("}") != -1)
                    break;
                else
                {
                    string[] temp = newLine.Split(':');
                    SimulatorConfiguration.RoadManager.roadList[System.Convert.ToInt32(temp[1])].order = System.Convert.ToInt32(temp[2]); //設定路的順序
                    newIntersection.roadList.Add(SimulatorConfiguration.RoadManager.roadList[System.Convert.ToInt32(temp[1])]); //將路加入路口
                    SimulatorConfiguration.RoadManager.roadList[System.Convert.ToInt32(temp[1])].locateIntersection = newIntersection.intersectionName; //設定路所在的路口
                    SimulatorConfiguration.UI.AddMessage("System", "Road " + System.Convert.ToInt32(temp[1]) + " is add to Intersection " + newIntersection.intersectionName);

                }
            }
            SimulatorConfiguration.IntersectionManager.IntersectionList.Add(newIntersection);
            SimulatorConfiguration.UI.AddMessage("System", "Intersection : " + newIntersection.intersectionName + " is create complete");
        }



        public void LoadSimulationFile()
        {
            StreamReader simFileReader = new StreamReader(SimulatorConfiguration.simulationFilePath);
            
            while(!simFileReader.EndOfStream)
            {
                string newLine = simFileReader.ReadLine();

                if (newLine.IndexOf("intersection") != -1)
                {
                    int intersectionName = System.Convert.ToInt32(newLine.Split(' ')[1]);
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
                            SimulatorConfiguration.IntersectionManager.IntersectionList[intersectionName].LightSettingList.Add(LightSet_int);
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
                                SimulatorConfiguration.RoadManager.roadList[System.Convert.ToInt32(temp[1])].carGenerateRate = System.Convert.ToInt32(temp[2]);
                                SimulatorConfiguration.RoadManager.GenerateCarRoadList.Add(SimulatorConfiguration.RoadManager.roadList[System.Convert.ToInt32(temp[1])]);
                                SimulatorConfiguration.UI.AddMessage("System", "Road : " + SimulatorConfiguration.RoadManager.roadList[System.Convert.ToInt32(temp[1])].roadName + " GenerateRate set to " + SimulatorConfiguration.RoadManager.roadList[System.Convert.ToInt32(temp[1])].carGenerateRate);
                            }
                    }
                }
            }
                SimulatorConfiguration.IntersectionManager.InitialIntersection();
                SimulatorConfiguration.PrototypeManager.ProtypeInitialize();
        }
    }
}