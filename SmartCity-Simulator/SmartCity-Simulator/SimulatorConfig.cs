using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.SystemManagers;

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
            this.numericUpDown_CarGraphicFPS.Value = Simulator.carGraphicFPS;
            this.numericUpDown_UIGraphicFPS.Value = Simulator.UIGraphicFPS;
            Console.WriteLine(this.checkBox_TestMode.Checked);
            this.checkBox_TestMode.Checked = Simulator.TESTMODE;
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            Simulator.carGraphicFPS = (int)this.numericUpDown_CarGraphicFPS.Value;
            Simulator.UI.SetCarGraphicFPS(Simulator.carGraphicFPS);

            Simulator.UIGraphicFPS = (int)this.numericUpDown_UIGraphicFPS.Value;
            Simulator.UI.SetUIGraphicFPS(Simulator.UIGraphicFPS);

            Simulator.TESTMODE = this.checkBox_TestMode.Checked;

            this.Close();
        }

        private void numericUpDown_CarGraphicFPS_ValueChanged(object sender, EventArgs e)
        {
            Simulator.carGraphicFPS = (int)this.numericUpDown_CarGraphicFPS.Value;
            Simulator.UI.SetCarGraphicFPS(Simulator.carGraphicFPS);
        }
    }
}
