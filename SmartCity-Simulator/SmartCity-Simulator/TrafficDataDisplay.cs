using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.SystemManagers;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator
{
    public partial class TrafficDataDisplay : Form
    {
        Boolean showRoadHistory = false;

        public TrafficDataDisplay()
        {
            InitializeComponent();

            for (int id = 0; id < Simulator.IntersectionManager.GetTotalIntersections(); id++)
            {
                    this.comboBox_Intersections.Items.Add(id);
            }
            this.comboBox_Intersections.SelectedIndex = 0;
        }

        public void LoadIntersectionHistoryData(int intersectionID) 
        {
            int startCycle = (int)this.numericUpDown_startPeriod.Value;
            int endCycle = (int)this.numericUpDown_endPeriod.Value;

            this.comboBox_Road.Items.Clear();
            this.dataGridView_RoadData.Rows.Clear();

            List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;

            for (int i = 0; i < Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList.Count; i++)
            {
                this.dataGridView_RoadData.Rows.Add();
                this.dataGridView_RoadData.Rows[i].Cells[0].Value = roadList[i].roadName;
                this.comboBox_Road.Items.Add(roadList[i].roadName);
            }

            for (int roadIndex = 0; roadIndex < roadList.Count; roadIndex++)
            {
                this.dataGridView_RoadData.Rows[roadIndex].Cells[0].Value = roadList[roadIndex].roadID;
                this.dataGridView_RoadData.Rows[roadIndex].Cells[1].Value = Simulator.DataManager.GetArrivalRate(roadList[roadIndex].roadID, startCycle, endCycle);
                this.dataGridView_RoadData.Rows[roadIndex].Cells[2].Value = Simulator.DataManager.GetAvgWaittingCars(roadList[roadIndex].roadID, startCycle, endCycle);
                this.dataGridView_RoadData.Rows[roadIndex].Cells[3].Value = Simulator.DataManager.GetAvgWaittingRate(roadList[roadIndex].roadID, startCycle, endCycle);
                this.dataGridView_RoadData.Rows[roadIndex].Cells[4].Value = Simulator.DataManager.GetAvgWaittingTime(roadList[roadIndex].roadID, startCycle, endCycle); 
            }

            this.label_AWR.Text = Simulator.DataManager.GetIntersectionAvgWaitingRate(intersectionID, startCycle, endCycle) +"";
            this.label_IAWT.Text = Simulator.DataManager.GetIntersectionAvgWaitingTime(intersectionID, startCycle, endCycle) + "";

            if (this.comboBox_Road.SelectedIndex >= roadList.Count || this.comboBox_Road.SelectedIndex < 0)
                this.comboBox_Road.SelectedIndex = 0;

                LoadRoadHistoryData(System.Convert.ToInt16(this.comboBox_Road.Text));
        }

        public void LoadRoadHistoryData(int roadID)
        {
            this.dataGridView_singleRoadData.Rows.Clear();
            if (showRoadHistory)
            {
                int startCycle = (int)this.numericUpDown_startPeriod.Value;
                int endCycle = (int)this.numericUpDown_endPeriod.Value;

                if (startCycle > endCycle && endCycle != 0)
                    startCycle = endCycle;

                if (endCycle == 0 || endCycle >= Simulator.DataManager.CountRecords(roadID))
                    endCycle = Simulator.DataManager.CountRecords(roadID) - 1;



                for (int cycle = 0; (cycle + startCycle) <= endCycle; cycle++)
                {
                    this.dataGridView_singleRoadData.Rows.Add();

                    CycleRecord cycleRecord = Simulator.DataManager.GetRecord(roadID, cycle + startCycle);

                    this.dataGridView_singleRoadData.Rows[cycle].Cells[0].Value = (cycle + startCycle);
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[1].Value = cycleRecord.arrivedCars;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[2].Value = cycleRecord.passedCars;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[3].Value = cycleRecord.WaitingCars;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[4].Value = cycleRecord.WaittingRate;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[5].Value = cycleRecord.WaitingTimeOfAllCars;
                }
            }
        }

        private void comboBox_Intersections_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIntersectionHistoryData(this.comboBox_Intersections.SelectedIndex);
            showRoadHistory = false;
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadIntersectionHistoryData(this.comboBox_Intersections.SelectedIndex);
        }

        private void comboBox_road_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoadHistoryData(System.Convert.ToInt16(this.comboBox_Road.Text));
        }

        private void button_showRoadHistory_Click(object sender, EventArgs e)
        {
            if (!showRoadHistory)
            {
                showRoadHistory = true;
                this.button_showRoadHistory.Text = "關閉";
            }
            else 
            {
                showRoadHistory = false;
                this.button_showRoadHistory.Text = "顯示";
            }
            LoadRoadHistoryData(System.Convert.ToInt16(this.comboBox_Road.Text));
        }
    }
}
