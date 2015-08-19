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

namespace SmartTrafficSimulator
{
    public partial class AutoSimulation : Form
    {
        public AutoSimulation()
        {
            InitializeComponent();
            this.timer_refresh.Interval = 60000;
            this.timer_refresh.Tick += new EventHandler(RefreshTask);
            this.timer_refresh.Start();
            LoadSimulationTask();
        }

        public void RefreshTask(Object myObject, EventArgs myEventArgs)
        {
            LoadSimulationTask();
        }

        public void LoadSimulationTask()
        {
            LoadAutoSimulationTaskList();

            /*if (Simulator.autoSimulation)
            {
                this.button_switch.Text = "Stop";
                this.groupBox_autoSimulationConfig.Enabled = false;
            }
            else
            {
                this.button_switch.Text = "Start";
                this.groupBox_autoSimulationConfig.Enabled = true;
            }*/

            this.dataGridView_queueState.Rows.Clear();
            SimulationTask[] finishTasks = Simulator.TaskManager.GetFinishQueue().ToArray<SimulationTask>();
            SimulationTask currentTask = Simulator.TaskManager.GetCurrentTask();
            SimulationTask[] waitingTasks = Simulator.TaskManager.GetSimulationQueue().ToArray<SimulationTask>();

            int row;
            foreach(SimulationTask finishTask in finishTasks)
            {
                if (finishTask != null)
                {
                    row = this.dataGridView_queueState.Rows.Add();
                    this.dataGridView_queueState.Rows[row].Cells[0].Value = finishTask.simulationName;
                    this.dataGridView_queueState.Rows[row].Cells[1].Value = finishTask.GetTaskStatus();
                }
            }
            if (currentTask != null)
            {
                row = this.dataGridView_queueState.Rows.Add();
                this.dataGridView_queueState.Rows[row].Cells[0].Value = currentTask.simulationName;
                this.dataGridView_queueState.Rows[row].Cells[1].Value = currentTask.GetTaskStatus();
            }
            foreach (SimulationTask waitingTask in waitingTasks)
            {
                if (waitingTask != null)
                {
                    row = this.dataGridView_queueState.Rows.Add();
                    this.dataGridView_queueState.Rows[row].Cells[0].Value = waitingTask.simulationName;
                    this.dataGridView_queueState.Rows[row].Cells[1].Value = waitingTask.GetTaskStatus();
                }
            }
        }

        private void button_toQueue_Click(object sender, EventArgs e)
        {
            Simulator.TaskManager.TaskListToQueue();
            LoadSimulationTask();
        }

        private void checkBox_autoSave_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_autoSave.Checked)
            {
                this.checkBox_saveOptimizationRecord.Enabled = true;
                this.checkBox_saveTrafficRecord.Enabled = true;
                this.checkBox_saveIntersectionState.Enabled = true;
                this.checkBox_saveVehicleData.Enabled = true;
            }
            else
            {
                this.checkBox_saveOptimizationRecord.Enabled = false;
                this.checkBox_saveTrafficRecord.Enabled = false;
                this.checkBox_saveIntersectionState.Enabled = false;
                this.checkBox_saveVehicleData.Enabled = false;
            }
        }

        private void button_openSimulationFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Simulation Files|*.xml";
            openFileDialog.Title = "Select a Simulation File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox_simulationFilePath.Text = openFileDialog.FileName;
            }
        }

        private void button_addNewAutoSimulationTask_Click(object sender, EventArgs e)
        {
            if (!this.textBox_simulationFilePath.Text.Equals(""))
            {
                string filePath = this.textBox_simulationFilePath.Text;
                int autoSimulationStartTime = (int)this.numericUpDown_startHour.Value * 3600 + (int)this.numericUpDown_startMinute.Value * 60;
                int autoSimulationStopTime = (int)this.numericUpDown_stopHour.Value * 3600 + (int)this.numericUpDown_stopMinute.Value * 60;
                int repeatTimes = (int)this.numericUpDown_repeatTimes.Value;
                Boolean saveTrafficRecoed;
                Boolean saveOptimizationRecord;
                Boolean saveIntersectionState;
                Boolean saveVehicleData;

                if (this.checkBox_autoSave.Checked)
                {
                    saveTrafficRecoed = this.checkBox_saveTrafficRecord.Checked;
                    saveOptimizationRecord = this.checkBox_saveOptimizationRecord.Checked;
                    saveIntersectionState = this.checkBox_saveIntersectionState.Checked;
                    saveVehicleData = this.checkBox_saveVehicleData.Checked;
                }
                else
                {
                    saveTrafficRecoed = false;
                    saveOptimizationRecord = false;
                    saveIntersectionState = false;
                    saveVehicleData = false;
                }

                SimulationTask newAutoSimulationTask = new SimulationTask(filePath, autoSimulationStartTime, autoSimulationStopTime, repeatTimes, saveTrafficRecoed, saveOptimizationRecord, saveIntersectionState,saveVehicleData);

                Simulator.TaskManager.AddSimulationTask(newAutoSimulationTask);

                this.textBox_simulationFilePath.Text = "";

                LoadAutoSimulationTaskList();
            }
        }

        public void LoadAutoSimulationTaskList()
        {
            this.listBox_autoSimulationList.Items.Clear();

            foreach(SimulationTask task in Simulator.TaskManager.GetSimulationTaskList())
                this.listBox_autoSimulationList.Items.Add(task.simulationName);
        }

        private void listBox_SimulationTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Simulator.TaskManager.GetSimulationTaskList().Count > 0)
            {
                SimulationTask task = Simulator.TaskManager.GetSimulationTaskList()[this.listBox_autoSimulationList.SelectedIndex];

                this.label_startTime.Text = Simulator.SecondToTimeFormat(task.simulationStartTime);
                this.label_endTime.Text = Simulator.SecondToTimeFormat(task.simulationEndTime);
                this.label_repaetTime.Text = task.repeatTimes + "";

                if (task.saveTrafficRecord)
                    this.label_saveTraffic.Text = "Yes";
                else
                    this.label_saveTraffic.Text = "No";

                if (task.saveOptimizationRecord)
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
                Simulator.TaskManager.DeleteSimulationTask(this.listBox_autoSimulationList.SelectedIndex);
                LoadAutoSimulationTaskList();
            }
        }
    }
}
