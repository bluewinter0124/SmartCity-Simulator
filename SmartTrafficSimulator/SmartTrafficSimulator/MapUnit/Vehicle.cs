﻿using System;
using System.Windows.Forms;
using System.Drawing;
using SmartTrafficSimulator.Unit;
using SmartTrafficSimulator.SystemObject;
using System.Collections.Generic;
using System.Reflection;

namespace SmartTrafficSimulator.GraphicUnit
{
    public class Vehicle : PictureBox
    {
        public int CAR_STOP = 0, CAR_RUNNING = 1, CAR_CROSSING = 2, CAR_WAITING = 3;

        public int vehicle_ID;
        public int vehicle_type = 1;
        public int vehicle_weight = 1;
        public double vehicle_speed = 80;
        public int vehicle_state = 1;
        public int vehicle_length;
        public int vehicle_width;
        int safeDistance;

        public Road locatedRoad;
        public List<Point> roadPoints;
        public int roadPointsIndex = 0;

        DrivingPath DrivingPath;
        public List<Road> DrivingPathRoads = new List<Road>();
        public int DrivingPathIndex = 0;

        public int stopAtTime = 0;
        public int totalWaitingTime = 0;

        public Vehicle(int ID, int weight, Road startRoad)
        {
            this.safeDistance = Simulator.VehicleManager.vehicleLength / 2;
            this.vehicle_length = Simulator.VehicleManager.vehicleLength;
            this.vehicle_width = Simulator.VehicleManager.vehicleWidth;

            this.BackColor = System.Drawing.Color.Transparent;
            this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle0;
            this.Size = new System.Drawing.Size(vehicle_length, vehicle_width);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;


            vehicle_ID = ID;
            vehicle_weight = weight;
            locatedRoad = startRoad;

            DrivingPath = Simulator.VehicleManager.GetRoadomDrivingPath(startRoad.roadID);

            AddDrivingPathRoad(DrivingPath.GetStartRoadID());

            List<int> passingRoads = DrivingPath.GetPassingRoads();

            for (int i = 0; i < passingRoads.Count; i++)
            {
                this.AddDrivingPathRoad(passingRoads[i]);
            }

            AddDrivingPathRoad(DrivingPath.GetGoalRoadID());

            roadPoints = startRoad.GetRoadPoints();

            setLocation(roadPoints[0]);
            locatedRoad.VehicleEnterRoad(this);
        }

        private delegate void setLocationCallBack(Point locate);

        public void setLocation(Point locate)
        {
            if (this.InvokeRequired)
            {
                setLocationCallBack mySetLocation = new setLocationCallBack(setLocation);
                this.Invoke(mySetLocation, locate);
            }
            else
            {
                this.Location = new Point(locate.X - this.Width / 2, locate.Y - this.Height / 2);
            }
        }

        public Point getLocation()
        {
            return new Point(roadPoints[roadPointsIndex].X, roadPoints[roadPointsIndex].Y);
        }

        public void AddDrivingPathRoad(int RoadID)
        {
            DrivingPathRoads.Add(Simulator.RoadManager.GetRoadByID(RoadID));
        }

        public void setPassingPathList(List<Road> roadList)
        {
            DrivingPathRoads = roadList;
        }

        public void setSpeed(int speed)
        {
            vehicle_speed = speed;
        }

        public Vehicle CheckFrontCar()
        {
            int selfLocate = locatedRoad.onRoadVehicleList.IndexOf(this);
            if (selfLocate > 0)
                return locatedRoad.onRoadVehicleList[selfLocate - 1];
            else
                return null;
        }

        public void Driving()
        {
            //vehicle_speed = IMD.IDM(this, CheckFrontCar());
            double runDistance = (vehicle_speed * 1000 * Simulator.simulationSpeedRate) / (3600 * Simulator.VehicleManager.vehicleRunPerSecond);

            int runPixel = System.Convert.ToInt16(Math.Round(runDistance,0, MidpointRounding.AwayFromZero));

            if (vehicle_state == CAR_RUNNING)
                VehicleRunning(runPixel);
            else if (vehicle_state == CAR_CROSSING)
            { }
            else if (vehicle_state == CAR_WAITING)
            {
                VehicleWaitting(runPixel);
            }
        }

        public void VehicleRunning(int runPixel)
        {
            if (locatedRoad.lightState == 0 || locatedRoad.lightState == 1)//綠
            {
                int goalDistance = (roadPoints.Count - 1) - roadPointsIndex;

                if (goalDistance > runPixel)
                {
                    VehicleMove(runPixel);
                }
                else
                {
                    runPixel -= goalDistance;
                    ToNextRoad(runPixel);
                }

            }
            else if (locatedRoad.lightState == 2 || locatedRoad.lightState == 3) //紅
            {
                int stopDistance = (roadPoints.Count - 1) - roadPointsIndex;
                stopDistance = stopDistance - safeDistance - (locatedRoad.GetWaittingVehicles() * (Simulator.VehicleManager.vehicleLength + safeDistance / 2));

                if (stopDistance > runPixel)
                {
                    VehicleMove(runPixel);
                }
                else
                {
                    if (stopDistance > 0)
                        VehicleMove(stopDistance);
                    vehicle_state = CAR_WAITING; //進入等待
                    stopAtTime = Simulator.SimulationTime;
                }
            }
        }

        public void VehicleWaitting(int runPixel)
        {
            if (locatedRoad.lightState == 0 || locatedRoad.lightState == 1)//綠 or 黃
            {
                totalWaitingTime += Simulator.SimulationTime - stopAtTime;
                vehicle_state = CAR_RUNNING;
                VehicleRunning(runPixel);
            }
            else if (locatedRoad.lightState == 2 || locatedRoad.lightState == 3)
            {
            }
        }

        public void UploadVehicleWaittingTime()
        {
            if(vehicle_state == CAR_WAITING)
            {
                totalWaitingTime += Simulator.SimulationTime - stopAtTime;
            }
            locatedRoad.AddWaitingTimeOfAllVehicles(vehicle_weight * totalWaitingTime);

            totalWaitingTime = 0;
            stopAtTime = Simulator.SimulationTime;
        }

        public void ToNextRoad(int remainRunPixel)
        {
            UploadVehicleWaittingTime();
            locatedRoad.VehicleExitRoad(this);
            if (locatedRoad.roadType == 0 || locatedRoad.roadType == 1) //目前的為一般道路
            {
                DrivingPathIndex++;
                if (DrivingPathIndex >= DrivingPathRoads.Count)
                {
                    Simulator.VehicleManager.DestoryVehicle(vehicle_ID); 
                }
                else
                {
                    for (int x = 0; x < locatedRoad.connectedRoadList.Count; x++) //尋找連接到下一條路的連接路段
                    {
                        if (locatedRoad.connectedRoadList[x].connectTo == DrivingPathRoads[DrivingPathIndex].roadID)
                        {
                            locatedRoad = locatedRoad.connectedRoadList[x];
                            roadPointsIndex = 0;
                            roadPoints = locatedRoad.GetRoadPoints();
                            locatedRoad.VehicleEnterRoad(this);
                            VehicleRunning(remainRunPixel);
                        }
                    }
                }
            }

            else if (locatedRoad.roadType == 2)//目前的為連接道路
            {
                locatedRoad = DrivingPathRoads[DrivingPathIndex];
                roadPointsIndex = 0;
                roadPoints = locatedRoad.GetRoadPoints();
                locatedRoad.VehicleEnterRoad(this);
                VehicleRunning(remainRunPixel);
            }
        }

        public void VehicleMove(int pixel)
        {
            Point before, after;
            before = roadPoints[roadPointsIndex];
            roadPointsIndex += pixel;
            after = roadPoints[roadPointsIndex];

            VehicleRotation(before, after);

        }

        public void VehicleRotation(Point before, Point after)
        {
            if (Simulator.vehicleGraphicFPS > 0)
            {
                double vectorX = after.X - before.X;
                double vectorY = after.Y - before.Y;

               
                if (vectorX > 0)
                {
                    if (vectorY > 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle315;
                        this.Size = new System.Drawing.Size(vehicle_length, vehicle_length);
                    }
                    else if (vectorY == 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle0;
                        this.Size = new System.Drawing.Size(vehicle_length, vehicle_width);
                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle45;
                        this.Size = new System.Drawing.Size(vehicle_length, vehicle_length);
                    }
                }
                else if (vectorX == 0)
                {
                    if (vectorY > 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle270;
                        this.Size = new System.Drawing.Size(vehicle_width, vehicle_length);
                    }
                    else if (vectorY == 0)
                    {

                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle90;
                        this.Size = new System.Drawing.Size(vehicle_width, vehicle_length);
                    }
                }
                else if (vectorX < 0)
                {
                    if (vectorY > 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle225;
                        this.Size = new System.Drawing.Size(vehicle_length, vehicle_length);
                    }
                    else if (vectorY == 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle180;
                        this.Size = new System.Drawing.Size(vehicle_length, vehicle_width);
                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle135;
                        this.Size = new System.Drawing.Size(vehicle_length, vehicle_length);
                    }
                }
            }
        }

        public void RefreshVehicleGraphic()
        {
            setLocation(roadPoints[roadPointsIndex]);
        }

        override protected void OnClick(EventArgs e)
        {
            VehicleInformation form = new VehicleInformation(vehicle_ID, locatedRoad.roadName, vehicle_speed, vehicle_weight, vehicle_state);
            form.ShowDialog();
        }
    }
}