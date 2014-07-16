using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartCitySimulator
{
    public partial class CarInformation : Form
    {
        public CarInformation(int CarID,string CurrentRoad,int CarSpeed,int CarWeight,int CarState)
        {
            InitializeComponent();
            this.Text = "車輛ID : " + CarID;
            this.label_currentRoad.Text = CurrentRoad;
            this.label_Speed.Text = CarSpeed + "" ;
            this.label_weight.Text = CarWeight + "";
            if(CarState == 0)
                this.label_state.Text = "Stop";
            else if (CarState == 1)
                this.label_state.Text = "Running";
            else if (CarState == 2)
                this.label_state.Text = "Cross Intersection";
            else if (CarState == 3)
                this.label_state.Text = "Waitting";

        }

       
    }
}
