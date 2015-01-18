using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.SystemObject;

namespace SmartCitySimulator
{
    public partial class SimulatorConfig : Form
    {
        public SimulatorConfig()
        {
            InitializeComponent();
            LoadSimulatorConfig();
        }

        private void LoadSimulatorConfig()
        {
            this.numericUpDown_VehicleGraphicFPS.Value = Simulator.vehicleGraphicFPS;

            this.checkBox_trafficSignalCountdownDisplay.Checked = Simulator.trafficSignalCountdownDisplay;
            this.checkBox_intersectionInformationUpdate.Checked = Simulator.intersectionInformation;
            this.checkBox_roadStateMark.Checked = Simulator.roadStateMark;

            this.checkBox_TestMode.Checked = Simulator.TESTMODE;
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            Simulator.UI.SetVehicleGraphicFPS(Simulator.vehicleGraphicFPS);

            Simulator.TrafficSignalCountdownDisplay(this.checkBox_trafficSignalCountdownDisplay.Checked);
            Simulator.IntersectionInformationUpdate(this.checkBox_intersectionInformationUpdate.Checked);
            Simulator.RoadStateMark(this.checkBox_roadStateMark.Checked);

            Simulator.TESTMODE = this.checkBox_TestMode.Checked;

            this.Close();
        }

        private void numericUpDown_VehicleGraphicFPS_ValueChanged(object sender, EventArgs e)
        {
            Simulator.UI.SetVehicleGraphicFPS((int)this.numericUpDown_VehicleGraphicFPS.Value);
        }
    }
}
