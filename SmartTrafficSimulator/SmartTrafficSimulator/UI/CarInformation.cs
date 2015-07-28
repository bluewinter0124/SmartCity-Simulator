using SmartTrafficSimulator.SystemManagers;
using SmartTrafficSimulator.SystemObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartTrafficSimulator
{
    public partial class VehicleInformation : Form
    {
        public VehicleInformation(Vehicle vehicle)
        {
            InitializeComponent();
            this.Text = "車輛ID : " + vehicle.vehicle_ID;
            this.label_locatedRoad.Text = vehicle.locatedRoad.roadID+"";
            this.label_Speed.Text = vehicle.vehicle_speed_KMH + "";
            this.label_weight.Text = vehicle.vehicle_weight + "";

            if (vehicle.vehicle_state == 0)
                this.label_state.Text = "Stop";
            else if (vehicle.vehicle_state == 1)
            {
                this.label_state.Text = "Running";
                this.label_delayTime.Text = vehicle.travelTime_waiting + "";
            }
            else if (vehicle.vehicle_state == 2)
                this.label_state.Text = "Cross Intersection";
            else if (vehicle.vehicle_state == 3)
            {
                this.label_state.Text = "Waitting";
                this.label_delayTime.Text = vehicle.travelTime_waiting + (Simulator.getCurrentTime() - vehicle.stoppedTime) + "";
            }

            this.label_travelTime.Text = Simulator.getCurrentTime() - vehicle.createdTime +"";
            this.label_travelDistance.Text = vehicle.travelDistace_pixel + vehicle.location + "";

            double avgSpeed = (vehicle.travelDistace_pixel * Simulator.mapScale) / (Simulator.getCurrentTime() - vehicle.createdTime);
            avgSpeed = Math.Round(avgSpeed * 3.6, 2, MidpointRounding.AwayFromZero);
            this.label_avgSpeed.Text = avgSpeed + "";
        }

        private void VehicleInformation_Load(object sender, EventArgs e)
        {

        }
    }
}