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

        private void button_saveTrafficData_Click(object sender, EventArgs e)
        {
            int interval_sec = (int)this.numericUpDown_Interval_TrafficData.Value * 60;
            Simulator.DataManager.TrafficVolumeData_SaveAsExcel(interval_sec);
        }

        private void button_saveOptRecords_Click(object sender, EventArgs e)
        {
            int interval_sec = (int)this.numericUpDown_Interval_OptRecords.Value * 60;
            Simulator.DataManager.OptimizationRecord_SaveAsExcel(interval_sec);
        }

        private void button_saveIntersectionStatus_Click(object sender, EventArgs e)
        {
            int interval_sec = (int)this.numericUpDown_Interval_IntersectionStatus.Value * 60;
            Simulator.DataManager.IntersectionStatus_SaveAsExcel(interval_sec);
        }

        private void button_saveVehicleData_Click(object sender, EventArgs e)
        {
            int interval_sec = (int)this.numericUpDown_Interval_VehicleData.Value * 60;
            Simulator.DataManager.VehicleData_SaveAsExcel(interval_sec);
        }

        private void DataOutput_Load(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                this.button_saveIntersectionStatus.Enabled = true;
                this.button_saveOptRecords.Enabled = true;
                this.button_saveTrafficData.Enabled = true;
                this.button_saveVehicleData.Enabled = true;
            }
            else
            {
                this.button_saveIntersectionStatus.Enabled = false;
                this.button_saveOptRecords.Enabled = false;
                this.button_saveTrafficData.Enabled = false;
                this.button_saveVehicleData.Enabled = false;
            }
        }
    }
}
