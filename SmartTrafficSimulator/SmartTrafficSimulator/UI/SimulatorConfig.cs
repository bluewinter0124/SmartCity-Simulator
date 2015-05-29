using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator
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
            if (Simulator.roadStateMark == 0)
            {
                this.radioButton_roadStateMark_None.Checked = true;
            }
            else if (Simulator.roadStateMark == 1)
            {
                this.radioButton_roadStateMark_Gray.Checked = true;
            }
            else if (Simulator.roadStateMark == 2)
            {
                this.radioButton_roadStateMark_Color.Checked = true;
            }

            this.checkBox_TestMode.Checked = Simulator.TESTMODE;
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            Simulator.UI.SetVehicleGraphicFPS(Simulator.vehicleGraphicFPS);

            Simulator.TrafficSignalCountdownDisplay(this.checkBox_trafficSignalCountdownDisplay.Checked);
            Simulator.IntersectionInformationUpdate(this.checkBox_intersectionInformationUpdate.Checked);
            if (this.radioButton_roadStateMark_None.Checked)
            {
                Simulator.RoadStateMark(0);
            }
            else if (this.radioButton_roadStateMark_Gray.Checked)
            {
                Simulator.RoadStateMark(1);
            }
            else if (this.radioButton_roadStateMark_Color.Checked)
            {
                Simulator.RoadStateMark(2);
            }

            Simulator.TESTMODE = this.checkBox_TestMode.Checked;

            this.Close();
        }

        private void numericUpDown_VehicleGraphicFPS_ValueChanged(object sender, EventArgs e)
        {
            Simulator.UI.SetVehicleGraphicFPS((int)this.numericUpDown_VehicleGraphicFPS.Value);
        }
    }
}
