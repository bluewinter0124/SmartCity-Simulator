using SmartTrafficSimulator.SystemManagers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartTrafficSimulator.UI
{
    public partial class DataOutput : Form
    {
        public DataOutput()
        {
            InitializeComponent();
        }

        private void button_selectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            Simulator.DataManager.SetFileSavingPath(folder.SelectedPath);
        }

        private void button_saveTrafficVolumeData_Click(object sender, EventArgs e)
        {
            Simulator.DataManager.TrafficVolumeData_SaveAsExcel(Simulator.DataManager.dataInterval_trafficVolume);
        }
        private void button_saveTrafficData_Click(object sender, EventArgs e)
        {
            Simulator.DataManager.TrafficData_SaveAsExcel();
        }

        private void button_saveOptRecords_Click(object sender, EventArgs e)
        {
            Simulator.DataManager.OptimizationRecord_SaveAsExcel(Simulator.DataManager.dataInterval_optRecords);
        }

        private void button_saveIntersectionStatus_Click(object sender, EventArgs e)
        {
            Simulator.DataManager.IntersectionStatus_SaveAsExcel(Simulator.DataManager.dataInterval_intersectionStatus);
        }

        private void button_saveVehicleData_Click(object sender, EventArgs e)
        {
            Simulator.DataManager.VehicleData_SaveAsExcel(Simulator.DataManager.dataInterval_vehicleData);
        }

        private void DataOutput_Load(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                this.button_saveIntersectionStatus.Enabled = true;
                this.button_saveOptRecords.Enabled = true;
                this.button_saveTrafficVolumeData.Enabled = true;
                this.button_saveVehicleData.Enabled = true;
            }
            else
            {
                this.button_saveIntersectionStatus.Enabled = false;
                this.button_saveOptRecords.Enabled = false;
                this.button_saveTrafficVolumeData.Enabled = false;
                this.button_saveVehicleData.Enabled = false;
            }
            this.numericUpDown_Interval_TrafficVolumeData.Value = Simulator.DataManager.dataInterval_trafficVolume / 60;
            this.numericUpDown_Interval_OptRecords.Value = Simulator.DataManager.dataInterval_optRecords / 60;
            this.numericUpDown_Interval_IntersectionStatus.Value = Simulator.DataManager.dataInterval_intersectionStatus / 60;
            this.numericUpDown_Interval_VehicleData.Value = Simulator.DataManager.dataInterval_vehicleData / 60;
        }

        private void numericUpDown_Interval_TrafficVolumeData_ValueChanged(object sender, EventArgs e)
        {
            Simulator.DataManager.dataInterval_vehicleData = (int)this.numericUpDown_Interval_TrafficVolumeData.Value * 60;
        }

        private void numericUpDown_Interval_OptRecords_ValueChanged(object sender, EventArgs e)
        {
            Simulator.DataManager.dataInterval_optRecords = (int)this.numericUpDown_Interval_OptRecords.Value * 60;
        }

        private void numericUpDown_Interval_IntersectionStatus_ValueChanged(object sender, EventArgs e)
        {
            Simulator.DataManager.dataInterval_intersectionStatus = (int)this.numericUpDown_Interval_IntersectionStatus.Value * 60;
        }

        private void numericUpDown_Interval_VehicleData_ValueChanged(object sender, EventArgs e)
        {
            Simulator.DataManager.dataInterval_vehicleData = (int)this.numericUpDown_Interval_VehicleData.Value * 60;
        }

    }
}
