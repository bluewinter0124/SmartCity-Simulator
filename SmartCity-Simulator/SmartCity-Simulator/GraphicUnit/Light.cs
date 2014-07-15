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
        public int trafficLight_ID;
        public int second = 0;
        public int state = 0;
        public static readonly int TRed = 3, Red = 2, Green = 0, Yellow = 1;
        public Road deployRoad;
        public Label ownCounter;

        public Light()
        {
            this.Image = global::SmartCitySimulator.Properties.Resources.Light_Red;
            this.Size = new System.Drawing.Size(SimulatorConfiguration.LightLength, SimulatorConfiguration.LightWidth);
            this.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        public void drawSecondCounter()
        {
            ownCounter = new Label();
            ownCounter.AutoSize = true;
            ownCounter.Visible = true;
            ownCounter.Location = new Point(this.Location.X + this.Size.Width / 2, this.Location.Y + this.Size.Height / 2);
            ownCounter.BackColor = Color.White;
            ownCounter.Text = Convert.ToString(this.second);
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
            this.state = state;
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
                this.Size = new System.Drawing.Size(SimulatorConfiguration.LightLength, SimulatorConfiguration.LightWidth);
            else if (angle == 90)
                this.Size = new System.Drawing.Size(SimulatorConfiguration.LightWidth, SimulatorConfiguration.LightLength);

        }

        protected override void OnClick(EventArgs e)
        {
            String Intersection = deployRoad.locateIntersection;
            TrafficLightSettingModify form = new TrafficLightSettingModify(System.Convert.ToInt32(Intersection));
            form.Text = "Road " + this.deployRoad.roadName;
            form.ShowDialog();

        }
    }
}
