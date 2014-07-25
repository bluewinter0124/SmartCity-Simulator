using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.Unit;
using System.Drawing;
using SmartCitySimulator.SystemUnit;

namespace SmartCitySimulator.GraphicUnit
{
    public class Light : PictureBox
    {
        int GREEN = 0, Yellow = 1, RED = 2, TEMPRED = 3;

        public int trafficLight_ID;

        public int Second = 0;
        public int State = 0;

        public Road deployRoad;
        public Label ownCounter;

        public Light()
        {
            this.Image = global::SmartCitySimulator.Properties.Resources.Light_Red;
            this.Size = new System.Drawing.Size(Simulator.LightLength, Simulator.LightWidth);
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

        public void setLightState(int state) //換成state燈號
        {
            this.State = state;
            if (state == 3)
                this.Image = global::SmartCitySimulator.Properties.Resources.Light_Red;
            if (state == 2)
                this.Image = global::SmartCitySimulator.Properties.Resources.Light_Red;
            if (state == 0)
                this.Image = global::SmartCitySimulator.Properties.Resources.Light_Green1;
            if (state == 1)
                this.Image = global::SmartCitySimulator.Properties.Resources.Light_Yellow;
        }

        private delegate void setLightSecondCallBack(int sec);

        public void setLightSecond(int sec)
        {
            if (this.InvokeRequired)
            {
                setLightSecondCallBack d = new setLightSecondCallBack(setLightSecond);
                this.Invoke(d, sec);
            }
            else
            {
                this.ownCounter.Text = sec + "";
            }
        }

        public void LightRotate(int angle)
        {
            if (angle == 0)
                this.Size = new System.Drawing.Size(Simulator.LightLength, Simulator.LightWidth);
            else if (angle == 90)
                this.Size = new System.Drawing.Size(Simulator.LightWidth, Simulator.LightLength);

        }

        protected override void OnClick(EventArgs e)
        {
            int Intersection = deployRoad.locateIntersection;
            TrafficLightConfig form = new TrafficLightConfig(System.Convert.ToInt32(Intersection));
            form.Text = "Road " + this.deployRoad.roadName;
            form.ShowDialog();

        }
    }
}
