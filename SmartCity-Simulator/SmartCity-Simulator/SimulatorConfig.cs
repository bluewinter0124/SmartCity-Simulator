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
            this.numericUpDown_UIGraphicFPS.Value = Simulator.UIGraphicFPS;
            Console.WriteLine(this.checkBox_TestMode.Checked);
            this.checkBox_TestMode.Checked = Simulator.TESTMODE;
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            Simulator.vehicleGraphicFPS = (int)this.numericUpDown_VehicleGraphicFPS.Value;
            Simulator.UI.SetVehicleGraphicFPS(Simulator.vehicleGraphicFPS);

            Simulator.UIGraphicFPS = (int)this.numericUpDown_UIGraphicFPS.Value;
            Simulator.UI.SetUIGraphicFPS(Simulator.UIGraphicFPS);

            Simulator.TESTMODE = this.checkBox_TestMode.Checked;

            this.Close();
        }

        private void numericUpDown_VehicleGraphicFPS_ValueChanged(object sender, EventArgs e)
        {
            Simulator.UI.SetVehicleGraphicFPS((int)this.numericUpDown_VehicleGraphicFPS.Value);
        }
    }
}
