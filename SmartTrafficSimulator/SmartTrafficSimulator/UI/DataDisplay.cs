using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.Unit;

namespace SmartTrafficSimulator
{
    public partial class DataDisplay : Form
    {
        Boolean showRoadHistory = false;
        Intersection selectedIntersection;

        public DataDisplay()
        {
            InitializeComponent();

            for (int id = 0; id < Simulator.IntersectionManager.CountIntersections(); id++)
            {
                    this.comboBox_Intersections.Items.Add(id);
            }

            this.comboBox_Intersections.SelectedIndex = 0;
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(System.Convert.ToInt16(this.comboBox_Intersections.Text));
            
            this.timer_refresh.Interval = 5000;
            this.timer_refresh.Tick += new EventHandler(RefreshTask);
            this.timer_refresh.Start();
        }

        public void RefreshTask(Object myObject, EventArgs myEventArgs)
        {
            LoadIntersectionTrafficData();
        }

        private void comboBox_Intersections_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(System.Convert.ToInt16(this.comboBox_Intersections.Text));
            LoadIntersectionTrafficData();
        }

        public void LoadIntersectionTrafficData() 
        {
            int intersectionID = selectedIntersection.intersectionID;

            int startCycle = (int)this.numericUpDown_startPeriod.Value;
            int endCycle = (int)this.numericUpDown_endPeriod.Value;

            int selectedRoadIndex = this.comboBox_Road.SelectedIndex;

            this.comboBox_Road.Items.Clear();
            this.dataGridView_intersectionData.Rows.Clear();
            this.dataGridView_optimizeationData.Rows.Clear();

            List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;

            for (int i = 0; i < roadList.Count; i++)
            {
                this.dataGridView_intersectionData.Rows.Add();
                this.dataGridView_intersectionData.Rows[i].Cells[0].Value = roadList[i].roadName;
                this.comboBox_Road.Items.Add(roadList[i].roadName);
            }

            for (int roadIndex = 0; roadIndex < roadList.Count; roadIndex++)
            {
                this.dataGridView_intersectionData.Rows[roadIndex].Cells[0].Value = roadList[roadIndex].roadID;
                this.dataGridView_intersectionData.Rows[roadIndex].Cells[1].Value = Simulator.DataManager.GetArrivalVehicles(roadList[roadIndex].roadID, startCycle, endCycle);
                this.dataGridView_intersectionData.Rows[roadIndex].Cells[2].Value = Simulator.DataManager.GetAvgWaittingVehicles(roadList[roadIndex].roadID, startCycle, endCycle);
                this.dataGridView_intersectionData.Rows[roadIndex].Cells[3].Value = Simulator.DataManager.GetAvgWaittingRate(roadList[roadIndex].roadID, startCycle, endCycle);
                this.dataGridView_intersectionData.Rows[roadIndex].Cells[4].Value = Simulator.DataManager.GetAvgWaittingTime(roadList[roadIndex].roadID, startCycle, endCycle); 
            }

            this.label_AWR.Text = Simulator.DataManager.GetIntersectionAvgWaitingRate(intersectionID, startCycle, endCycle) +"";
            this.label_IAWT.Text = Simulator.DataManager.GetIntersectionAvgWaitingTime(intersectionID, startCycle, endCycle) + "";

            LoadOptimizationData();

            this.comboBox_Road.SelectedIndex = selectedRoadIndex;
            if (this.comboBox_Road.SelectedIndex >= roadList.Count || this.comboBox_Road.SelectedIndex < 0)
                this.comboBox_Road.SelectedIndex = 0;

            LoadRoadTrafficData(System.Convert.ToInt16(this.comboBox_Road.Text));
        }

        public void LoadOptimizationData()
        {
            int intersectionID = selectedIntersection.intersectionID;

            int startCycle = (int)this.numericUpDown_startPeriod.Value;
            int endCycle = (int)this.numericUpDown_endPeriod.Value;

            List<OptimizationRecord> optimizations = Simulator.DataManager.GetOptimizationRecords(intersectionID,startCycle,endCycle);

            for (int optimizationNo = 0; optimizationNo < optimizations.Count; optimizationNo++)
            {
                this.dataGridView_optimizeationData.Rows.Add();
                this.dataGridView_optimizeationData.Rows[optimizationNo].Cells[0].Value = optimizations[optimizationNo].optimizeCycle;
                this.dataGridView_optimizeationData.Rows[optimizationNo].Cells[1].Value = optimizations[optimizationNo].optimizeTime;
                this.dataGridView_optimizeationData.Rows[optimizationNo].Cells[2].Value = optimizations[optimizationNo].IAWR;
                this.dataGridView_optimizeationData.Rows[optimizationNo].Cells[3].Value = optimizations[optimizationNo].IAWRThreshold;
                this.dataGridView_optimizeationData.Rows[optimizationNo].Cells[4].Value = optimizations[optimizationNo].OriginConfigToString();
                this.dataGridView_optimizeationData.Rows[optimizationNo].Cells[5].Value = optimizations[optimizationNo].OptimizedConfigToString();
            }

        }

        public void LoadRoadTrafficData(int roadID)
        {
            this.dataGridView_singleRoadData.Rows.Clear();
            if (showRoadHistory)
            {
                int startCycle = (int)this.numericUpDown_startPeriod.Value;
                int endCycle = (int)this.numericUpDown_endPeriod.Value;

                if (startCycle > endCycle && endCycle != 0)
                    startCycle = endCycle;

                if (endCycle == 0 || endCycle >= Simulator.DataManager.CountTrafficRecords(roadID))
                    endCycle = Simulator.DataManager.CountTrafficRecords(roadID) - 1;

                for (int cycle = 0; (cycle + startCycle) <= endCycle; cycle++)
                {
                    this.dataGridView_singleRoadData.Rows.Add();

                    CycleRecord cycleRecord = Simulator.DataManager.GetCycleRecord(roadID, cycle + startCycle);

                    this.dataGridView_singleRoadData.Rows[cycle].Cells[0].Value = (cycle + startCycle);
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[1].Value = cycleRecord.previousCycleVehicles;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[2].Value = cycleRecord.arrivedVehicles;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[3].Value = cycleRecord.passedVehicles;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[4].Value = cycleRecord.waitingVehicles;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[5].Value = cycleRecord.waittingRate;
                    this.dataGridView_singleRoadData.Rows[cycle].Cells[6].Value = cycleRecord.waitingTimeOfAllVehicles;
                }
            }
        }


        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadIntersectionTrafficData();
        }

        private void comboBox_road_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoadTrafficData(System.Convert.ToInt16(this.comboBox_Road.Text));
        }

        private void button_showRoadHistory_Click(object sender, EventArgs e)
        {
            if (!showRoadHistory)
            {
                showRoadHistory = true;
                this.button_showRoadHistory.Text = "Hide";
                this.splitContainer_data.Panel2Collapsed = false;
            }
            else 
            {
                showRoadHistory = false;
                this.button_showRoadHistory.Text = "Show";
                this.splitContainer_data.Panel2Collapsed = true;
            }
            LoadRoadTrafficData(System.Convert.ToInt16(this.comboBox_Road.Text));
        }


        private void button_SaveAllOptimizationRecord(object sender, EventArgs e)
        {
            Simulator.DataManager.AllDataSaveAsExcel(false, true);
        }
        private void button_saveAllTrafficRecord_Click(object sender, EventArgs e)
        {
            Simulator.DataManager.AllDataSaveAsExcel(true, false);
        }

        private void button_OptimizationRecordSaveAsTxt_Click(object sender, EventArgs e)
        {
            Simulator.DataManager.OptimizationDataSaveAsTxt(selectedIntersection.intersectionID);
        }

        private void button_OptimizationRecordSaveAsExcel_Click(object sender, EventArgs e)
        {
            List<Intersection> intersectionlist = new List<Intersection>();
            intersectionlist.Add(selectedIntersection);
            Simulator.DataManager.OptimizationDataSaveAsExcel(intersectionlist);
        }

        private void button_TrafficRecordSaveAsExcel_Click(object sender, EventArgs e)
        {
            List<Intersection> intersectionlist = new List<Intersection>();
            intersectionlist.Add(selectedIntersection);
            Simulator.DataManager.TrafficDataSaveAsExcel(intersectionlist);
        }

        private void button_selectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            Simulator.DataManager.SetFileSavingPath(folder.SelectedPath);
        }
    }
}
