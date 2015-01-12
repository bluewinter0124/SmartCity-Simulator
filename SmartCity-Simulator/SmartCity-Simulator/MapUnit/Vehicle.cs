using System;
using System.Windows.Forms;
using System.Drawing;
using SmartCitySimulator.Unit;
using SmartCitySimulator.SystemObject;
using System.Collections.Generic;
using System.Reflection;

namespace SmartCitySimulator.GraphicUnit
{
    public class Vehicle : PictureBox
    {
        public int CAR_STOP = 0, CAR_RUNNING = 1, CAR_CROSSING = 2, CAR_WAITING = 3;

        public int vehicle_ID;
        public int vehicle_type = 1;
        public int vehicle_weight = 1;
        public int vehicle_speed = 1;
        public int vehicle_state = 1;

        int safeDistance = 1;
        int length = 1;
        int width = 1;

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
            this.length = Simulator.VehicleManager.vehicleLength;
            this.width = Simulator.VehicleManager.vehicleWidth;

            this.BackColor = System.Drawing.Color.Transparent;
            this.Image = global::SmartCitySimulator.Properties.Resources.vehicle0;
            this.Size = new System.Drawing.Size(length, width);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;


            vehicle_ID = ID;
            vehicle_weight = weight;
            locatedRoad = startRoad;

            DrivingPath = Simulator.VehicleManager.GetDrivingPath(startRoad.roadID);

            AddDrivingPathRoad(DrivingPath.getStartRoadID());

            List<int> passingRoads = DrivingPath.getPassingRoads();

            for (int i = 0; i < passingRoads.Count; i++)
            {
                this.AddDrivingPathRoad(passingRoads[i]);
            }

            AddDrivingPathRoad(DrivingPath.getGoalRoadID());

            roadPoints = startRoad.getRoadPoints();

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
            return new Point(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2);
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

        public void Driving()
        {
            int runDistance = vehicle_speed * Simulator.simulationRate;
            if (vehicle_state == CAR_RUNNING)
                VehicleRunning(runDistance);
            else if (vehicle_state == CAR_CROSSING)
            { }
            else if (vehicle_state == CAR_WAITING)
            {
                VehicleWaitting(runDistance);
            }
        }

        public void VehicleRunning(int runDistance)
        {
            if (locatedRoad.lightState == 0 || locatedRoad.lightState == 1)//綠
            {
                int goalDistance = (roadPoints.Count - 1) - roadPointsIndex;

                if (goalDistance > runDistance)
                {
                    VehicleMove(runDistance);
                }
                else
                {
                    runDistance -= goalDistance;
                    ToNextRoad(runDistance);
                }

            }
            else if (locatedRoad.lightState == 2 || locatedRoad.lightState == 3) //紅
            {
                int stopDistance = (roadPoints.Count - 1) - roadPointsIndex;
                stopDistance = stopDistance - safeDistance - (locatedRoad.WaittingVehicles() * (Simulator.VehicleManager.vehicleLength + safeDistance / 2));

                if (stopDistance > runDistance)
                {
                    VehicleMove(runDistance);
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

        public void VehicleWaitting(int runDistance)
        {
            if (locatedRoad.lightState == 0 || locatedRoad.lightState == 1)//綠 or 黃
            {
                totalWaitingTime += Simulator.SimulationTime - stopAtTime;
                vehicle_state = CAR_RUNNING;
                VehicleRunning(runDistance);
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

        public void ToNextRoad(int remainDistance)
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
                            roadPoints = locatedRoad.getRoadPoints();
                            locatedRoad.VehicleEnterRoad(this);
                            VehicleRunning(remainDistance);
                        }
                    }
                }
            }

            else if (locatedRoad.roadType == 2)//目前的為連接道路
            {
                locatedRoad = DrivingPathRoads[DrivingPathIndex];
                roadPointsIndex = 0;
                roadPoints = locatedRoad.getRoadPoints();
                locatedRoad.VehicleEnterRoad(this);
                VehicleRunning(remainDistance);
            }
        }

        public void VehicleMove(int distance)
        {
            Point before, after;
            before = roadPoints[roadPointsIndex];
            roadPointsIndex += distance;
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
                        this.Image = global::SmartCitySimulator.Properties.Resources.vehicle315;
                        this.Size = new System.Drawing.Size(length, length);
                    }
                    else if (vectorY == 0)
                    {
                        this.Image = global::SmartCitySimulator.Properties.Resources.vehicle0;
                        this.Size = new System.Drawing.Size(length, width);
                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartCitySimulator.Properties.Resources.vehicle45;
                        this.Size = new System.Drawing.Size(length, length);
                    }
                }
                else if (vectorX == 0)
                {
                    if (vectorY > 0)
                    {
                        this.Image = global::SmartCitySimulator.Properties.Resources.vehicle270;
                        this.Size = new System.Drawing.Size(width, length);
                    }
                    else if (vectorY == 0)
                    {

                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartCitySimulator.Properties.Resources.vehicle90;
                        this.Size = new System.Drawing.Size(width, length);
                    }
                }
                else if (vectorX < 0)
                {
                    if (vectorY > 0)
                    {
                        this.Image = global::SmartCitySimulator.Properties.Resources.vehicle225;
                        this.Size = new System.Drawing.Size(length, length);
                    }
                    else if (vectorY == 0)
                    {
                        this.Image = global::SmartCitySimulator.Properties.Resources.vehicle180;
                        this.Size = new System.Drawing.Size(length, width);
                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartCitySimulator.Properties.Resources.vehicle135;
                        this.Size = new System.Drawing.Size(length, length);
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