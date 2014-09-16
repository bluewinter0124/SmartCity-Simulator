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
    public partial class VehicleInformation : Form
    {
        public VehicleInformation(int VehicleID,string CurrentRoad,int VehicleSpeed,int VehicleWeight,int VehicleState)
        {
            InitializeComponent();
            this.Text = "車輛ID : " + VehicleID;
            this.label_currentRoad.Text = CurrentRoad;
            this.label_Speed.Text = VehicleSpeed + "" ;
            this.label_weight.Text = VehicleWeight + "";
            if(VehicleState == 0)
                this.label_state.Text = "Stop";
            else if (VehicleState == 1)
                this.label_state.Text = "Running";
            else if (VehicleState == 2)
                this.label_state.Text = "Cross Intersection";
            else if (VehicleState == 3)
                this.label_state.Text = "Waitting";
        }
    }
}