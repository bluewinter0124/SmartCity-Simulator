using SmartCitySimulator.SystemObject;
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
    public partial class AutoSimulation : Form
    {
        public AutoSimulation()
        {
            InitializeComponent();
            this.timer_refresh.Interval = 3000;
            this.timer_refresh.Tick += new EventHandler(RefreshTask);
            this.timer_refresh.Start();
            LoadAutoSimulation();
        }

        public void RefreshTask(Object myObject, EventArgs myEventArgs)
        {
            LoadAutoSimulation();
        }

        public void LoadAutoSimulation()
        {
            if (Simulator.autoSimulation)
            {
                this.button_switch.Text = "Stop";
                this.groupBox_autoSimulationConfig.Enabled = false;
                this.groupBox_autoSimulationInfo.Enabled = true;
                this.label_accomplishTimes.Text = Simulator.autoSimulationAccomplish + "";
            }
            else
            {
                this.button_switch.Text = "Start";
                this.groupBox_autoSimulationConfig.Enabled = true;
                this.groupBox_autoSimulationInfo.Enabled = false;
            }
        }

        private void button_switch_Click(object sender, EventArgs e)
        {
            if (Simulator.autoSimulation)
            {
                Simulator.UI.AutoSimulationStop();
            }
            else
            {
                int autoSimulationStartTime = (int)this.numericUpDown_startHour.Value * 3600 + (int)this.numericUpDown_startMinute.Value * 60;
                int autoSimulationStopTime = (int)this.numericUpDown_stopHour.Value * 3600 + (int)this.numericUpDown_stopMinute.Value * 60;
                int autoSimulationTimes = (int)this.numericUpDown_simulationTimes.Value;
                Boolean autoSaveTrafficRecoed;
                Boolean autoSaveOptimizationRecord;

                if (this.checkBox_autoSave.Checked)
                {
                    autoSaveTrafficRecoed = this.checkBox_saveTrafficRecord.Checked;
                    autoSaveOptimizationRecord = this.checkBox_saveOptimizationRecord.Checked;
                }
                else
                {
                    autoSaveTrafficRecoed = false;
                    autoSaveOptimizationRecord = false;
                }

                Simulator.UI.AutoSimulation(autoSimulationStartTime, autoSimulationStopTime, autoSimulationTimes, autoSaveTrafficRecoed, autoSaveOptimizationRecord);
                Simulator.UI.SetSimulationSpeed(50);
                Simulator.UI.SetVehicleGraphicFPS(0);
            }
            LoadAutoSimulation();
        }

        private void checkBox_autoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_autoSave.Checked)
            {
                this.checkBox_saveOptimizationRecord.Enabled = true;
                this.checkBox_saveTrafficRecord.Enabled = true;
            }
            else
            {
                this.checkBox_saveOptimizationRecord.Enabled = false;
                this.checkBox_saveTrafficRecord.Enabled = false;
            }
        }
    }
}
