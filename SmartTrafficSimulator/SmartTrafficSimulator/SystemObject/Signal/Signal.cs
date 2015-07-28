using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartTrafficSimulator.SystemObject;
using System.Drawing;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.SystemObject
{
    public class Signal : PictureBox
    {
        int GREEN = 0, Yellow = 1, RED = 2, TEMPRED = 3;

        public int trafficSignal_ID;

        public int Second = 0;
        public int State = 0;

        public int defaultWidth = 5;
        public int defaultHeight = 20;

        public Road deployRoad;
        public Label ownCounter;

        public Signal()
        {
            this.Image = global::SmartTrafficSimulator.Properties.Resources.Light_Red;
            this.Size = new System.Drawing.Size(defaultHeight, defaultWidth);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        public void drawSecondCounter()
        {
            ownCounter = new Label();
            ownCounter.AutoSize = true;
            ownCounter.Visible = true;
            ownCounter.Location = new Point(this.Location.X + this.Size.Width / 2, this.Location.Y + this.Size.Height / 2);
            ownCounter.BackColor = Color.White;
            ownCounter.Text = Convert.ToString(this.Second);
            ownCounter.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        }

        private delegate void setLocationCallBack(Point locate);

        public void setSize(int width,int height)
        {
            this.Size = new System.Drawing.Size(height, width);
        }

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
                drawSecondCounter();
            }
        }

        public void setSignalState(int state) //換成state燈號
        {
            this.State = state;
            if (state == 3)
                this.Image = global::SmartTrafficSimulator.Properties.Resources.Light_Red;
            if (state == 2)
                this.Image = global::SmartTrafficSimulator.Properties.Resources.Light_Red;
            if (state == 0)
                this.Image = global::SmartTrafficSimulator.Properties.Resources.Light_Green;
            if (state == 1)
                this.Image = global::SmartTrafficSimulator.Properties.Resources.Light_Yellow;
        }

        private delegate void setLightSecondCallBack(int sec);

        public void setSignalSecond(int sec)
        {
            if (this.InvokeRequired)
            {
                setLightSecondCallBack d = new setLightSecondCallBack(setSignalSecond);
                this.Invoke(d, sec);
            }
            else
            {
                this.ownCounter.Text = sec + "";
            }
        }

        public void SignalRotate(int angle)
        {
            if (angle == 0)
                this.Size = new System.Drawing.Size(Simulator.signalLength, Simulator.signalWidth);
            else if (angle == 90)
                this.Size = new System.Drawing.Size(Simulator.signalWidth, Simulator.signalLength);

        }

        protected override void OnClick(EventArgs e)
        {
            TrafficSignalConfig form = new TrafficSignalConfig(System.Convert.ToInt32(deployRoad.belongsIntersection.intersectionID));
            form.Text = "Road " + this.deployRoad.roadName;
            form.ShowDialog();

        }
    }
}
