﻿using SmartCitySimulator.SystemObject;
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
        string simulationName = "";
        public AutoSimulation()
        {
            InitializeComponent();
            this.timer_refresh.Interval = 60000;
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
            LoadAutoSimulationTaskList();

            if (Simulator.autoSimulation)
            {
                this.button_switch.Text = "Stop";
                this.groupBox_autoSimulationConfig.Enabled = false;
            }
            else
            {
                this.button_switch.Text = "Start";
                this.groupBox_autoSimulationConfig.Enabled = true;
            }

            this.dataGridView1.Rows.Clear();
            AutoSimulationTask[] finishTasks = Simulator.UI.autoSimulationFinishQueue.ToArray<AutoSimulationTask>();
            AutoSimulationTask currentTask = Simulator.UI.currentAutoSimulationTask;
            AutoSimulationTask[] waitingTasks = Simulator.UI.autoSimulationQueue.ToArray<AutoSimulationTask>();

            int row;
            foreach(AutoSimulationTask finishTask in finishTasks)
            {
                if (finishTask != null)
                {
                    row = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[row].Cells[0].Value = finishTask.simulationName;
                    this.dataGridView1.Rows[row].Cells[1].Value = "Finish";
                }
            }
            if (currentTask != null)
            {
                row = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[row].Cells[0].Value = currentTask.simulationName;
                this.dataGridView1.Rows[row].Cells[1].Value = "Running";
            }
            foreach (AutoSimulationTask waitingTask in waitingTasks)
            {
                if (waitingTask != null)
                {
                    row = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[row].Cells[0].Value = waitingTask.simulationName;
                    this.dataGridView1.Rows[row].Cells[1].Value = "Waiting";
                }
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
                if (Simulator.autoSimulationTaskList.Count > 0)
                {
                    foreach (AutoSimulationTask task in Simulator.autoSimulationTaskList)
                    {
                        Simulator.UI.AddAutoSimulationTask(task);
                    }
                    Simulator.CleanAutoSimulationTaskList();
                }
                Simulator.UI.AutoSimulationStart();
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

        private void button_openSimulationFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Simulation Files|*.txt";
            openFileDialog.Title = "Select a Simulation File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox_simulationFilePath.Text = openFileDialog.FileName;
                this.simulationName = openFileDialog.SafeFileName;
            }
        }

        private void button_addNewAutoSimulationTask_Click(object sender, EventArgs e)
        {
            if (!this.textBox_simulationFilePath.Text.Equals(""))
            {
                string filePath = this.textBox_simulationFilePath.Text;
                int autoSimulationStartTime = (int)this.numericUpDown_startHour.Value * 3600 + (int)this.numericUpDown_startMinute.Value * 60;
                int autoSimulationStopTime = (int)this.numericUpDown_stopHour.Value * 3600 + (int)this.numericUpDown_stopMinute.Value * 60;
                int repeatTimes = (int)this.numericUpDown_simulationTimes.Value;
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

                AutoSimulationTask newAutoSimulationTask = new AutoSimulationTask(filePath, simulationName, autoSimulationStartTime, autoSimulationStopTime, repeatTimes, autoSaveTrafficRecoed, autoSaveOptimizationRecord);

                Simulator.AddAutoSimulationTask(newAutoSimulationTask);

                LoadAutoSimulationTaskList();
            }
        }

        public void LoadAutoSimulationTaskList()
        {
            this.listBox_autoSimulationList.Items.Clear();

            foreach(AutoSimulationTask task in Simulator.autoSimulationTaskList)
                this.listBox_autoSimulationList.Items.Add(task.simulationName);
        }

        private void listBox_autoSimulationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Simulator.autoSimulationTaskList.Count > 0)
            {
                AutoSimulationTask task = Simulator.autoSimulationTaskList[this.listBox_autoSimulationList.SelectedIndex];

                this.label_startTime.Text = Simulator.ToSimulatorTimeFormat_Second(task.startTime);
                this.label_endTime.Text = Simulator.ToSimulatorTimeFormat_Second(task.endTime);
                this.label_repaetTime.Text = task.repeatTimes + "";

                if (task.autoSave_TrafficRecord)
                    this.label_saveTraffic.Text = "Yes";
                else
                    this.label_saveTraffic.Text = "No";

                if (task.autoSave_OptimizationRecord)
                    this.label_saveOptimization.Text = "Yes";
                else
                    this.label_saveOptimization.Text = "No";
            }
        }

        private void button_deleteSimulationTask_Click(object sender, EventArgs e)
        {
            int index = this.listBox_autoSimulationList.SelectedIndex;
            if(index >= 0)
            {
                Simulator.DeleteAutoSimulationTask(this.listBox_autoSimulationList.SelectedIndex);
                LoadAutoSimulationTaskList();
            }
        }

        private void button_deleteSimulationTaskList_Click(object sender, EventArgs e)
        {
            Simulator.CleanAutoSimulationTaskList();
            LoadAutoSimulationTaskList();
        }
    }
}
