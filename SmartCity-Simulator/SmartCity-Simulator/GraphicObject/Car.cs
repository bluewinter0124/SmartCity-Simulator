using System;
using System.Windows.Forms;
using System.Drawing;
using SmartCitySimulator.Unit;
using SmartCitySimulator.SystemUnit;
using System.Collections.Generic;
using System.Reflection;

namespace SmartCitySimulator.GraphicUnit
{
    public class Car : PictureBox
    {
        public int car_ID;
        public int car_type = 1;
        public int car_weight = 1;
        public int car_speed = 1;
        public int car_state = 1;
        public int CAR_STOP = 0, CAR_RUN = 1, CAR_CROSSING = 2, CAR_WAITING = 3;
        int safeDistance = 15;

        int length = 30;
        int width = 15;

        public Road locateRoad;
        public List<Point> roadPathPoint;
        public int roadPathPointIndex = 0;

        public List<Road> Path;
        public int PathIndex = 0;

        public int waitTime = 0;

        public Car(int ID, int weight, Road startRoad)
        {
            this.safeDistance = Simulator.CarManager.carLength / 2;
            this.length = Simulator.CarManager.carLength;
            this.width = Simulator.CarManager.carWidth;

            this.BackColor = System.Drawing.Color.Transparent;
            this.Image = global::SmartCitySimulator.Properties.Resources.car0;
            this.Size = new System.Drawing.Size(length, width);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            Path = new List<Road>();

            car_ID = ID;
            car_weight = weight;
            locateRoad = startRoad;
            roadPathPoint = startRoad.getRoadPath();
            setLocation(roadPathPoint[0]);
            locateRoad.CarEnterRoad(this);

            if (startRoad.roadID == 13)
            {
                AddPath(Simulator.RoadManager.roadList[13]);
                AddPath(Simulator.RoadManager.roadList[23]);
            }
            if (startRoad.roadID == 14)
            {
                AddPath(Simulator.RoadManager.roadList[14]);
                AddPath(Simulator.RoadManager.roadList[16]);
            }
            if (startRoad.roadID == 17)
            {
                AddPath(Simulator.RoadManager.roadList[17]);
                AddPath(Simulator.RoadManager.roadList[15]);
            }
            if (startRoad.roadID == 22)
            {
                AddPath(Simulator.RoadManager.roadList[22]);
                AddPath(Simulator.RoadManager.roadList[12]);
            }

            /*Random Random = new Random();
            int PathNo = Random.Next(3);

            if (startRoad.roadID == 0)
            {
                if (PathNo == 0)
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[0]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[2]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[4]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[13]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[23]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[28]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[33]);

                }
                else if (PathNo == 1)
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[0]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[9]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[31]);
                }
                else 
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[0]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[2]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[4]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[6]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[18]);
                }

            }
            else if (startRoad.roadID == 19)
            {
                if (PathNo == 0)
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[19]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[17]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[15]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[10]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[3]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[1]);
                }
                else if (PathNo == 1)
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[19]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[17]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[15]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[21]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[31]);
                }
                else
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[19]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[7]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[5]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[3]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[1]);
                }

            }
            else if (startRoad.roadID == 30)
            {
                if (PathNo == 0)
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[30]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[8]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[1]);
                }
                else if (PathNo == 1)
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[30]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[26]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[28]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[24]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[18]);
                }
                else
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[30]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[20]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[14]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[16]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[18]);
                }

            }
            else if (startRoad.roadID == 32)
            {
                if (PathNo == 0)
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[32]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[24]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[18]);
                }
                else if (PathNo == 1)
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[32]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[29]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[27]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[8]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[1]);
                }
                else
                {
                    AddPath(SimulatorConfiguration.RoadManager.roadList[32]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[29]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[22]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[12]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[5]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[3]);
                    AddPath(SimulatorConfiguration.RoadManager.roadList[1]);
                }
            }*/

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

        public void AddPath(Road road)
        {
            Path.Add(road);
        }

        public void Drive()
        {
            int runDistance = car_speed * Simulator.simulationRate;
            if (car_state == 1)
                CarRunning(runDistance);
            else if (car_state == 2)
            { }
            else if (car_state == 3)
            {
                CarWaitting(runDistance);
            }
        }

        public void CarRunning(int runDistance)
        {
            if (locateRoad.lightState == 0 || locateRoad.lightState == 1)//綠
            {
                int goalDistance = (roadPathPoint.Count - 1) - roadPathPointIndex;

                if (goalDistance > runDistance)
                {
                    CarMove(runDistance);
                }
                else
                {
                    runDistance -= goalDistance;
                    ToNextRoad(runDistance);
                }

            }
            else if (locateRoad.lightState == 2 || locateRoad.lightState == 3) //紅
            {
                int stopDistance = (roadPathPoint.Count - 1) - roadPathPointIndex;
                stopDistance = stopDistance - safeDistance - (locateRoad.WaittingCars() * (Simulator.CarManager.carLength + safeDistance / 2));

                if (stopDistance > runDistance)
                {
                    CarMove(runDistance);
                }
                else
                {
                    if (stopDistance > 0)
                        CarMove(stopDistance);
                    car_state = 3; //進入等待
                    waitTime = Simulator.simulatorTime;
                }
            }
        }

        public void CarWaitting(int runDistance)
        {
            if (locateRoad.lightState == 0 || locateRoad.lightState == 1)//綠
            {
                //SimulatorConfiguration.UI.AddMessage("System", "Car" + car_ID + "Waitting : " + (SimulatorConfiguration.simulationTime - waitTime));
                car_state = 1;
                CarRunning(runDistance);
            }
            else if (locateRoad.lightState == 2 || locateRoad.lightState == 3)
            {
            }
        }

        public void UploadCarWaittingTime()
        {
            int waittingTime = Simulator.simulatorTime - waitTime;
            locateRoad.WaitingTimeOfAllCars += (car_weight * waittingTime);
            locateRoad.WaitingCars += car_weight;
            waitTime = 0;
        }

        public void ToNextRoad(int remainDistance)
        {
            locateRoad.CarExitRoad(this);
            if (locateRoad.roadType == 0 || locateRoad.roadType == 1) //目前的為一般道路
            {
                PathIndex++;
                if (PathIndex >= Path.Count)
                {
                    Simulator.UI.RemoveCar(this);
                }
                else
                {
                    for (int x = 0; x < locateRoad.connectedPathList.Count; x++) //尋找連接到下一條路的連接路段
                    {
                        if (locateRoad.connectedPathList[x].connectTo == Path[PathIndex].roadID)
                        {
                            locateRoad = locateRoad.connectedPathList[x];
                            roadPathPointIndex = 0;
                            roadPathPoint = locateRoad.getRoadPath();
                            locateRoad.CarEnterRoad(this);
                            CarRunning(remainDistance);
                        }
                    }
                }
            }

            else if (locateRoad.roadType == 2)//目前的為連接道路
            {
                locateRoad = Path[PathIndex];
                roadPathPointIndex = 0;
                roadPathPoint = locateRoad.getRoadPath();
                locateRoad.CarEnterRoad(this);
                CarRunning(remainDistance);
            }
        }



        public void CarMove(int distance)
        {
            Point before, after;
            before = roadPathPoint[roadPathPointIndex];
            roadPathPointIndex += distance;
            after = roadPathPoint[roadPathPointIndex];

            CarRotation(before, after);

        }

        public void CarRotation(Point before, Point after)
        {
            double vectorX = after.X - before.X;
            double vectorY = after.Y - before.Y;


            if (vectorX > 0)
            {
                if (vectorY > 0)
                {
                    this.Image = global::SmartCitySimulator.Properties.Resources.car315;
                    this.Size = new System.Drawing.Size(length, length);
                }
                else if (vectorY == 0)
                {
                    this.Image = global::SmartCitySimulator.Properties.Resources.car0;
                    this.Size = new System.Drawing.Size(length,width);
                }
                else if (vectorY < 0)
                {
                    this.Image = global::SmartCitySimulator.Properties.Resources.car45;
                    this.Size = new System.Drawing.Size(length,length);
                }
            }
            else if (vectorX == 0)
            {
                if (vectorY > 0)
                {
                    this.Image = global::SmartCitySimulator.Properties.Resources.car270;
                    this.Size = new System.Drawing.Size(width,length);
                }
                else if (vectorY == 0)
                {

                }
                else if (vectorY < 0)
                {
                    this.Image = global::SmartCitySimulator.Properties.Resources.car90;
                    this.Size = new System.Drawing.Size(width,length);
                }
            }
            else if (vectorX < 0)
            {
                if (vectorY > 0)
                {
                    this.Image = global::SmartCitySimulator.Properties.Resources.car225;
                    this.Size = new System.Drawing.Size(length,length);
                }
                else if (vectorY == 0)
                {
                    this.Image = global::SmartCitySimulator.Properties.Resources.car180;
                    this.Size = new System.Drawing.Size(length,width);
                }
                else if (vectorY < 0)
                {
                    this.Image = global::SmartCitySimulator.Properties.Resources.car135;
                    this.Size = new System.Drawing.Size(length,length);
                }
            }
        }

        public void RefreshCarGraphic()
        {
            setLocation(roadPathPoint[roadPathPointIndex]);
        }

        override protected void OnClick(EventArgs e)
        {
            CarInformation form = new CarInformation(car_ID, locateRoad.roadName, car_speed, car_weight, car_state);
            form.ShowDialog();
        }
    }
}