using SmartCitySimulator.Unit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemObject
{
    class SimulatorFileReader
    {
        StreamReader fileReader;
        string newLine;

        public Boolean MapFileRead(String filePath)
        {
            fileReader = new StreamReader(filePath);
            
            newLine = "";

            while (!fileReader.EndOfStream)
            {
                newLine = fileReader.ReadLine();

                if(newLine.IndexOf("mapFilename") != -1)
                {
                    if(!MapFileRead_MapPictureRead())
                    {
                        Simulator.UI.AddMessage("System", "Map picture not found!");
                        return false;
                    }
                }

                if (newLine.IndexOf("Road") != -1 || newLine.IndexOf("road") != -1)
                {
                    if (!MapFileRead_NewRoad())
                    {
                        Simulator.UI.AddMessage("System", "Map file format error!");
                        return false;
                    }
                }

                if (newLine.IndexOf("Intersection") != -1 || newLine.IndexOf("intersection") != -1)
                {
                    if (!MapFileRead_NewIntersection())
                    {
                        Simulator.UI.AddMessage("System", "Map file format error!");
                        return false;
                    }
                }
            }

            Simulator.UI.AddMessage("System", "Map file read complete");
            return true;
        }

        public Boolean MapFileRead_MapPictureRead()
        {
            string picturePath = newLine.Substring(newLine.IndexOf(" ") + 1);
            if (File.Exists(picturePath))
            {
                Simulator.mapPicturePath = picturePath;
                Simulator.UI.SetMapBackground(picturePath);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean MapFileRead_NewRoad()
        {
            int newRoadID = Simulator.RoadManager.CreateNewRoad();
            Road newRoad = Simulator.RoadManager.GetRoadByID(newRoadID);

            while (true)
            {
                newLine = fileReader.ReadLine();

                if (newLine.IndexOf("Path") != -1 || newLine.IndexOf("path") != -1)
                {
                    string[] nodes = newLine.Split(' ')[1].Split(';');
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        int x = System.Convert.ToInt32(nodes[i].Split(',')[0]);
                        int y = System.Convert.ToInt32(nodes[i].Split(',')[1]);
                        Point node = new Point(x, y);
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
            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Road : " + newRoadID + " is create complete");

            return true;

        }

        public Boolean MapFileRead_NewIntersection()
        {
            int intersectionID = System.Convert.ToInt16(newLine.Split(' ')[1]);
            Simulator.IntersectionManager.AddNewIntersection(intersectionID);

            newLine = fileReader.ReadLine(); //跳過 {

            while (true)
            {
                newLine = fileReader.ReadLine();
                
                if (newLine.IndexOf("Road") != -1 || newLine.IndexOf("road") != -1)
                {
                    string[] roadConfig = newLine.Split(' ');
                    int roadID = System.Convert.ToInt32(roadConfig[1]);
                    int roadConfigOrder = System.Convert.ToInt32(roadConfig[2]);
                    Simulator.RoadManager.GetRoadByID(roadID).order = roadConfigOrder;
                    Simulator.IntersectionManager.AddRoadToIntersection(intersectionID, roadID);

                    if (Simulator.TESTMODE)
                        Simulator.UI.AddMessage("System", "Road " + System.Convert.ToInt32(roadConfig[1]) + " is add to Intersection " + intersectionID);

                }
                else if (newLine.IndexOf("}") != -1)
                {
                    break;
                }
            }
            if (Simulator.TESTMODE)
                Simulator.UI.AddMessage("System", "Intersection : " + intersectionID + " is create complete");

            return true;
        }



    }


}
