using System;
using System.Windows.Forms;
using System.Drawing;
using SmartTrafficSimulator.SystemObject;
using System.Collections.Generic;
using System.Reflection;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.SystemObject
{
    public class Vehicle : PictureBox
    {
        public int CAR_STOP = 0, CAR_RUNNING = 1, CAR_CROSSING = 2, CAR_WAITING = 3;

        public int createdTime = 0;
        public int vehicle_ID;
        public int vehicle_type = 1;
        public int vehicle_weight = 1;
        public double vehicle_speed_KMH = 0;
        public int vehicle_speed_MS = 17;
        public int vehicle_state = 1;
        public int vehicle_length;
        public int vehicle_GraphicLength;
        public int vehicle_GraphicWidth;
        public int safeDistance;

        DrivingPath drivingPath;
        public List<Road> passingRoads = new List<Road>();
        public int passingRoadIndex = 0;

        public Road locatedRoad;
        public List<Point> roadPoints;
        public int location = 0;

        public int stoppedTime = 0;
        public int waitingTime_road = 0;

        public int travelTime_total = 0;
        public int travelTime_waiting = 0;
        public int travelDistace_pixel = 0;


        public Vehicle(int ID, int weight, Road startRoad)
        {
            //picturebox setting
            this.BackColor = System.Drawing.Color.Transparent;
            this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle0;
            this.Size = new System.Drawing.Size(vehicle_GraphicLength, vehicle_GraphicWidth);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            createdTime = Simulator.getCurrentTime();
            vehicle_ID = ID;
            vehicle_weight = weight;
            locatedRoad = startRoad;

            this.vehicle_length = System.Convert.ToInt16(Simulator.VehicleManager.vehicleLength);
            this.safeDistance = this.vehicle_length*3;
            this.vehicle_GraphicLength = Simulator.VehicleManager.vehicleGraphicSize * 2;
            this.vehicle_GraphicWidth = Simulator.VehicleManager.vehicleGraphicSize;

            this.SetDrivingPath(Simulator.VehicleManager.GetRoadomDrivingPath(startRoad.roadID));

            this.roadPoints = startRoad.GetRoadPointList();

            this.setLocation(roadPoints[0]);
            this.locatedRoad.VehicleEnterRoad(this);
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
            return new Point(roadPoints[location].X, roadPoints[location].Y);
        }

        public void SetDrivingPath(DrivingPath drivingPath)
        {
            this.drivingPath = drivingPath;
            passingRoads.Clear();

            AddPassingRoad(drivingPath.GetStartRoadID());

            foreach (int passingRoadID in drivingPath.GetPassingRoads())
            {
                AddPassingRoad(passingRoadID);
            }

            AddPassingRoad(drivingPath.GetGoalRoadID());
        }

        public void AddPassingRoad(int RoadID)
        {
            passingRoads.Add(Simulator.RoadManager.GetRoadByID(RoadID));
        }

        public void SetPassingPathList(List<Road> roadList)
        {
            passingRoads = roadList;
        }

        public void SetSpeedKMH(int KMH)
        {
            vehicle_speed_KMH = KMH;
        }

        public Vehicle CheckFrontCar()
        {
            int selfLocate = locatedRoad.onRoadVehicleList.IndexOf(this);
            if (selfLocate > 0)
                return locatedRoad.onRoadVehicleList[selfLocate - 1];
            else
                return null;
        }

        public int CheckFrontObstacle()
        {
            int distance = -1; //-1 = no obstacle in front

            int selfOrder = locatedRoad.onRoadVehicleList.IndexOf(this);

            if (selfOrder > 0)
            {
                distance = (locatedRoad.onRoadVehicleList[selfOrder - 1].location - this.location) - (vehicle_length / 2);
            }
            else if (selfOrder == 0)
            {
                if (locatedRoad.signalState != 0) //red light
                {
                    distance = (roadPoints.Count-1) - location;
                }
            }

            //Simulator.UI.AddMessage("System", "OD : " + distance);

            return distance;
        }

        public void Driving()
        {
            /*double vehicleSpeed_PixelSlot = ((vehicle_speed_KMH * 1000 * Simulator.simulationSpeedRate) / (Simulator.VehicleManager.vehicleRunPerSecond * 3600)) / Simulator.mapScale;
            int runPixel = System.Convert.ToInt16(Math.Round(vehicleSpeed_PixelSlot, 0, MidpointRounding.AwayFromZero));*/

            if (vehicle_state == CAR_RUNNING)
            {
                VehicleRunning();
            }
            else if (vehicle_state == CAR_CROSSING)
            { }
            else if (vehicle_state == CAR_WAITING)
            {
                VehicleWaitting();
            }
        }

        public void VehicleRunning()
        {
            //double nextSpeed = VehicleDriveModels.Normal(this, CheckFrontObstacle());
            double nextSpeed = IntelligentDriverModel.SpeedCalculation(this, CheckFrontCar());

            int runPixel = System.Convert.ToInt16(Math.Round(((((vehicle_speed_KMH + nextSpeed) / 2) * 10 / 36) / Simulator.mapScale), 0, MidpointRounding.AwayFromZero));

            VehicleMove(runPixel);

            this.vehicle_speed_KMH = nextSpeed;

            if (nextSpeed == 0)
            {
                vehicle_state = CAR_WAITING; //進入等待
                stoppedTime = Simulator.getCurrentTime();
            }
        }

        public void VehicleWaitting()
        {
            if (locatedRoad.signalState == 0 || locatedRoad.signalState == 1)//綠 or 黃
            {
                waitingTime_road += Simulator.getCurrentTime() - stoppedTime;
                vehicle_state = CAR_RUNNING;
                VehicleRunning();
            }
            else if (locatedRoad.signalState == 2 || locatedRoad.signalState == 3)
            {
            }
        }

        public void UploadVehicleWaittingTime()
        {
            if(vehicle_state == CAR_WAITING)
            {
                int currentTime = Simulator.getCurrentTime();
                waitingTime_road += currentTime - stoppedTime;
                stoppedTime = currentTime;
            }
            travelTime_waiting += waitingTime_road;

            locatedRoad.AddTotalWaitingTime(vehicle_weight * waitingTime_road);
            waitingTime_road = 0;
        }

        public void ToNextRoad(int remainRunPixel)
        {
            UploadVehicleWaittingTime();
            travelDistace_pixel += locatedRoad.GetRoadLength();
            locatedRoad.VehicleExitRoad(this);
            if (locatedRoad.roadType == 0 || locatedRoad.roadType == 1) //目前的為一般道路
            {
                passingRoadIndex++;
                if (passingRoadIndex >= passingRoads.Count)
                {
                    travelTime_total = Simulator.getCurrentTime() - createdTime;
                    Simulator.VehicleManager.DestoryVehicle(vehicle_ID); 
                }
                else
                {
                    for (int x = 0; x < locatedRoad.intermediateRoadList.Count; x++) //尋找連接到下一條路的連接路段
                    {
                        if (locatedRoad.intermediateRoadList[x].connectRoad.roadID == passingRoads[passingRoadIndex].roadID)
                        {
                            locatedRoad = locatedRoad.intermediateRoadList[x];
                            location = 0;
                            roadPoints = locatedRoad.GetRoadPointList();
                            locatedRoad.VehicleEnterRoad(this);
                            VehicleMove(remainRunPixel);
                        }
                    }
                }
            }

            else if (locatedRoad.roadType == 2)//目前的為連接道路
            {
                locatedRoad = passingRoads[passingRoadIndex];
                location = 0;
                roadPoints = locatedRoad.GetRoadPointList();
                locatedRoad.VehicleEnterRoad(this);
                VehicleMove(remainRunPixel);
            }
        }

        public void VehicleMove(int runPixel)
        {
            Point before, after;
            before = roadPoints[location];

            int goalDistance = (roadPoints.Count - 1) - location;

            if (goalDistance > runPixel)
            {
                location += runPixel;
            }
            else
            {
                runPixel -= goalDistance;
                ToNextRoad(runPixel);
            }

            after = roadPoints[location];
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
                        this.Size = new System.Drawing.Size(vehicle_GraphicLength, vehicle_GraphicLength);
                    }
                    else if (vectorY == 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle0;
                        this.Size = new System.Drawing.Size(vehicle_GraphicLength, vehicle_GraphicWidth);
                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle45;
                        this.Size = new System.Drawing.Size(vehicle_GraphicLength, vehicle_GraphicLength);
                    }
                }
                else if (vectorX == 0)
                {
                    if (vectorY > 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle270;
                        this.Size = new System.Drawing.Size(vehicle_GraphicWidth, vehicle_GraphicLength);
                    }
                    else if (vectorY == 0)
                    {

                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle90;
                        this.Size = new System.Drawing.Size(vehicle_GraphicWidth, vehicle_GraphicLength);
                    }
                }
                else if (vectorX < 0)
                {
                    if (vectorY > 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle225;
                        this.Size = new System.Drawing.Size(vehicle_GraphicLength, vehicle_GraphicLength);
                    }
                    else if (vectorY == 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle180;
                        this.Size = new System.Drawing.Size(vehicle_GraphicLength, vehicle_GraphicWidth);
                    }
                    else if (vectorY < 0)
                    {
                        this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle135;
                        this.Size = new System.Drawing.Size(vehicle_GraphicLength, vehicle_GraphicLength);
                    }
                }
            }
        }

        public void RefreshVehicleGraphic()
        {
            setLocation(roadPoints[location]);
        }

        override protected void OnClick(EventArgs e)
        {
            VehicleInformation form = new VehicleInformation(this);
            form.ShowDialog();
        }
    }
}