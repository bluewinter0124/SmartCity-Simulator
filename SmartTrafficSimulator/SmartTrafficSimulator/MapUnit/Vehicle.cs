using System;
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

        public int generatedTime = 0;
        public int vehicle_ID;
        public int vehicle_type = 1;
        public int vehicle_weight = 1;
        public double vehicle_speed_KMH = 0;
        public int vehicle_speed_MS = 17;
        public int vehicle_state = 1;
        public int vehicle_length;
        public int vehicle_width;
        int safeDistance;

        public Road locatedRoad;
        public List<Point> roadPoints;
        public int locatedPoint = 0;

        DrivingPath drivingPath;
        public List<Road> passingRoads = new List<Road>();
        public int passingRoadIndex = 0;

        public int stoppedTime = 0;
        public int waitingTime_stop = 0;

        public int travelTime = 0;
        public int waitingTime_travel = 0;


        public Vehicle(int ID, int weight, Road startRoad)
        {
            //picturebox setting
            this.BackColor = System.Drawing.Color.Transparent;
            this.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle0;
            this.Size = new System.Drawing.Size(vehicle_length, vehicle_width);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            generatedTime = Simulator.getCurrentTime();
            vehicle_ID = ID;
            vehicle_weight = weight;
            locatedRoad = startRoad;

            this.safeDistance = Simulator.VehicleManager.vehicleLength;
            this.vehicle_length = Simulator.VehicleManager.vehicleLength;
            this.vehicle_width = Simulator.VehicleManager.vehicleWidth;

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
            return new Point(roadPoints[locatedPoint].X, roadPoints[locatedPoint].Y);
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
                distance = (locatedRoad.onRoadVehicleList[selfOrder - 1].locatedPoint - this.locatedPoint) - (vehicle_length / 2);
            }
            else if (selfOrder == 0)
            {
                if (locatedRoad.lightState == 2 || locatedRoad.lightState == 3) //red light
                {
                    distance = (roadPoints.Count-1) - locatedPoint;
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
            int OD = CheckFrontObstacle(); //Obstacle distance
            double brakeTime = vehicle_speed_KMH / Simulator.VehicleManager.vehicleBrakeFactor;
            //brakeTime = Math.Round(brakeTime, 0, MidpointRounding.AwayFromZero);

            double MSD = Math.Round(safeDistance + ((brakeTime * vehicle_speed_KMH * 1000) / 7200 / Simulator.mapScale), 0, MidpointRounding.AwayFromZero); //Max safe distance
            //Simulator.UI.AddMessage("System", "OD" + OD + " MSD : " + MSD);

            if (OD > MSD || OD == -1) //Accelerate or keep current speed
            {
                if (vehicle_speed_KMH < locatedRoad.speedLimit)
                {
                    vehicle_speed_KMH += (Simulator.VehicleManager.vehicleAccelerationFactor);
                    if (vehicle_speed_KMH > locatedRoad.speedLimit)
                    {
                        vehicle_speed_KMH = locatedRoad.speedLimit;
                    }
                }
            }
            else if (OD <= MSD) //Normal brake
            {
                if (vehicle_speed_KMH > 0)
                {
                    vehicle_speed_KMH -= (Simulator.VehicleManager.vehicleBrakeFactor);
                    if (vehicle_speed_KMH < 0)
                    {
                        vehicle_speed_KMH = 0;
                    }
                }
                //Simulator.UI.AddMessage("System", "NB : " + vehicle_speed_KMH);
            }
            else if (OD < (safeDistance / 2)) //Emergency brake
            {
                vehicle_speed_KMH = 0;
            }


            if (vehicle_speed_KMH == 0)
            {
                vehicle_state = CAR_WAITING; //進入等待
                stoppedTime = Simulator.getCurrentTime();
            }
            else
            {
                double vehicleSpeed_PixelSlot = ((vehicle_speed_KMH * 1000 / 3600) / Simulator.mapScale);
                int runPixel = System.Convert.ToInt16(Math.Round(vehicleSpeed_PixelSlot, 0, MidpointRounding.AwayFromZero));

                VehicleMove(runPixel);
            }
        }

        public void VehicleWaitting()
        {
            if (locatedRoad.lightState == 0 || locatedRoad.lightState == 1)//綠 or 黃
            {
                waitingTime_stop += Simulator.getCurrentTime() - stoppedTime;
                vehicle_state = CAR_RUNNING;
                VehicleRunning();
            }
            else if (locatedRoad.lightState == 2 || locatedRoad.lightState == 3)
            {
            }
        }

        public void UploadVehicleWaittingTime()
        {
            if(vehicle_state == CAR_WAITING)
            {
                int currentTime = Simulator.getCurrentTime();
                waitingTime_stop += currentTime - stoppedTime;
                stoppedTime = currentTime;
            }
            waitingTime_travel += waitingTime_stop;

            locatedRoad.AddTotalWaitingTime(vehicle_weight * waitingTime_stop);
            waitingTime_stop = 0;
        }

        public void ToNextRoad(int remainRunPixel)
        {
            UploadVehicleWaittingTime();
            locatedRoad.VehicleExitRoad(this);
            if (locatedRoad.roadType == 0 || locatedRoad.roadType == 1) //目前的為一般道路
            {
                passingRoadIndex++;
                if (passingRoadIndex >= passingRoads.Count)
                {
                    Simulator.VehicleManager.DestoryVehicle(vehicle_ID); 
                }
                else
                {
                    for (int x = 0; x < locatedRoad.connectedRoadList.Count; x++) //尋找連接到下一條路的連接路段
                    {
                        if (locatedRoad.connectedRoadList[x].connectTo == passingRoads[passingRoadIndex].roadID)
                        {
                            locatedRoad = locatedRoad.connectedRoadList[x];
                            locatedPoint = 0;
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
                locatedPoint = 0;
                roadPoints = locatedRoad.GetRoadPointList();
                locatedRoad.VehicleEnterRoad(this);
                VehicleMove(remainRunPixel);
            }
        }

        public void VehicleMove(int runPixel)
        {
            Point before, after;
            before = roadPoints[locatedPoint];

            int goalDistance = (roadPoints.Count - 1) - locatedPoint;

            if (goalDistance > runPixel)
            {
                locatedPoint += runPixel;
            }
            else
            {
                runPixel -= goalDistance;
                ToNextRoad(runPixel);
            }

            after = roadPoints[locatedPoint];
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
            setLocation(roadPoints[locatedPoint]);
        }

        override protected void OnClick(EventArgs e)
        {
            VehicleInformation form = new VehicleInformation(vehicle_ID, locatedRoad.roadName, vehicle_speed_KMH, vehicle_weight, vehicle_state);
            form.ShowDialog();
        }
    }
}