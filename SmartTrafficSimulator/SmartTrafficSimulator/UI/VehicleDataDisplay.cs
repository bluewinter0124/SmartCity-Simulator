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

namespace SmartTrafficSimulator.UI
{
    public partial class VehicleDataDisplay : Form
    {
        int startTime = 0;
        int endTime = 0;
        int displayInterval = 1800;

        public VehicleDataDisplay()
        {
            InitializeComponent();
        }



        private void VehicleDataDisplay_Load(object sender, EventArgs e)
        {
            this.dataGridView_vehicleData.Rows.Clear();
            //displayInterval = Simulator.DataManager.GetVehicleDataInterval();
            
            Dictionary<int, List<VehicleRecord>> data = Simulator.DataManager.GetVehicleData_Interval(displayInterval);
            //Dictionary<int, double> data = Simulator.DataManager.GetIAWR_Interval(1,displayInterval);

            int totalVehicle = 0;
            int[] zones = data.Keys.ToArray<int>();

            foreach (int zone in zones)
            {
                int startTime =zone * displayInterval;
                int endTime = ((zone + 1) * displayInterval) - 1;

                double avgTravelTime = 0;
                double avgTravelSpeed = 0;
                double avgDelayTime = 0;

                foreach (VehicleRecord record in data[zone])
                {
                    /*int row = this.dataGridView_vehicleData.Rows.Add();
                    this.dataGridView_vehicleData.Rows[row].Cells[0].Value = Simulator.ToSimulatorTimeFormat_Second(startTime) + " ~ " + Simulator.ToSimulatorTimeFormat_Second(endTime);
                    this.dataGridView_vehicleData.Rows[row].Cells[1].Value = record.travelTime_Sec;
                    this.dataGridView_vehicleData.Rows[row].Cells[2].Value = record.travelSpeed_KMH;
                    this.dataGridView_vehicleData.Rows[row].Cells[3].Value = record.delayTime_Sec;*/
                    avgTravelTime += record.travelTime_Sec;
                    avgTravelSpeed += record.travelSpeed_KMH;
                    avgDelayTime += record.delayTime_Sec;
                    totalVehicle++;
                }

                if (data[zone].Count > 0)
                {
                    avgTravelTime = Math.Round(avgTravelTime / data[zone].Count, 2, MidpointRounding.AwayFromZero);
                    avgTravelSpeed = Math.Round((avgTravelSpeed) / data[zone].Count, 2, MidpointRounding.AwayFromZero);
                    avgDelayTime = Math.Round(avgDelayTime / data[zone].Count, 2, MidpointRounding.AwayFromZero);
                }

                int row = this.dataGridView_vehicleData.Rows.Add();
                this.dataGridView_vehicleData.Rows[row].Cells[0].Value = Simulator.getZoneRange_Format(zone, displayInterval);
                this.dataGridView_vehicleData.Rows[row].Cells[1].Value = avgTravelTime;
                this.dataGridView_vehicleData.Rows[row].Cells[2].Value = avgTravelSpeed;
                this.dataGridView_vehicleData.Rows[row].Cells[3].Value = avgDelayTime;

                this.label_totalVehicle.Text = totalVehicle+"";
                /*int row = this.dataGridView_vehicleData.Rows.Add();
                this.dataGridView_vehicleData.Rows[row].Cells[0].Value = Simulator.getZoneRange_Format(zone,displayInterval);
                this.dataGridView_vehicleData.Rows[row].Cells[1].Value = data[zone];
                this.dataGridView_vehicleData.Rows[row].Cells[2].Value = data[zone];
                this.dataGridView_vehicleData.Rows[row].Cells[3].Value = data[zone];*/
            }

        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            VehicleDataDisplay_Load(sender, e);
        }

        private void numericUpDown_displayInterval_ValueChanged(object sender, EventArgs e)
        {
            displayInterval = (int)this.numericUpDown_displayInterval.Value * 60;
            //Simulator.DataManager.SetVehicleDataInterval((int)this.numericUpDown_displayInterval.Value * 60);
        }
    }
}
