using SmartTrafficSimulator.SystemManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartTrafficSimulator.OptimizationModels
{
    public partial class AIConfig : Form
    {
        public AIConfig()
        {
            InitializeComponent();
        }

        private void comboBox_optimizationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string optName = comboBox_optimizationMethod.Text;
            if (Simulator.AIManager.optimizationMethodList.ContainsKey(optName))
            {
                Simulator.AIManager.SetOptimizationMethod(optName);
            }
            else
            {
                Simulator.AIManager.SetOptimizationMethod("Genetic Algorithm");
            }

            Boolean testMode = Simulator.AIManager.testModeEnable[optName];
            this.button_testMode.Enabled = testMode;
        }

        private void AIConfig_Load(object sender, EventArgs e)
        {
            this.comboBox_optimizationMethod.Items.Clear();
            foreach (string optName in Simulator.AIManager.optimizationMethodList.Keys.ToArray<string>())
            {
                this.comboBox_optimizationMethod.Items.Add(optName);
            }

            this.comboBox_optimizationMethod.SelectedIndex = Simulator.AIManager.GetoptimizationMethodID();

            this.checkBox_adaptiveAdjustment.Checked = Simulator.AIManager.GetEnableAdaptiveAdjustment();
            this.checkBox_threshold.Checked = Simulator.AIManager.GetEnableThresholdAdjustment();
            this.checkBox_interval.Checked = Simulator.AIManager.GetEnableIntervalAdjustment();
            this.checkBox_trafficVolumePredection.Checked = Simulator.AIManager.GetEnableTrafficVolumePredection();
        }

        private void button_testMode_Click(object sender, EventArgs e)
        {
            string optName = comboBox_optimizationMethod.Text;
            if (optName.Equals("Genetic Algorithm"))
            {
                GA_TestMode form = new GA_TestMode();
                form.Show();
            }
        }

        private void checkBox_adaptiveAdjustment_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_adaptiveAdjustment.Checked)
            {
                this.checkBox_threshold.Enabled = true;
                this.checkBox_interval.Enabled = true;
                Simulator.AIManager.SetAdaptiveAdjustment(true);
            }
            else if (!this.checkBox_adaptiveAdjustment.Checked)
            {
                this.checkBox_threshold.Checked = false;
                this.checkBox_interval.Checked = false;

                this.checkBox_threshold.Enabled = false;
                this.checkBox_interval.Enabled = false;
                Simulator.AIManager.SetAdaptiveAdjustment(false);
                Simulator.AIManager.SetThresholdAdjustment(false);
                Simulator.AIManager.SetIntervalAdjustment(false);
            }
        }

        private void checkBox_threshold_CheckedChanged(object sender, EventArgs e)
        {
            Simulator.AIManager.SetThresholdAdjustment(this.checkBox_threshold.Checked);
        }

        private void checkBox_interval_CheckedChanged(object sender, EventArgs e)
        {
            Simulator.AIManager.SetIntervalAdjustment(this.checkBox_interval.Checked);
        }

        private void checkBox_trafficVolumePredection_CheckedChanged(object sender, EventArgs e)
        {
            Simulator.AIManager.SetTrafficVolumePredection(this.checkBox_trafficVolumePredection.Checked);
        }
    }
}