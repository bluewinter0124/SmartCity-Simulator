using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.SystemObject;
using SmartCitySimulator.Unit;
using SmartCitySimulator.SystemObject;

namespace SmartCitySimulator
{
    public partial class VehicleConfig : Form
    {
        Road selectedGenerateRoad;
        DrivingPath newDrivingPath;

        public VehicleConfig()
        {
            InitializeComponent();
            selectedGenerateRoad = Simulator.RoadManager.GenerateVehicleRoadList[0];

            LoadGenerateRoads();

            this.numericUpDown_VehicleSize.Value = Simulator.VehicleManager.vehicleSize;
            this.numericUpDown_VehicleSpeed.Value = Simulator.VehicleManager.vehicleSpeed;
        }

        public void LoadGenerateRoads()
        {
            //Clean list of generate road and reload
            this.comboBox_generateRoads.Items.Clear();
            for (int i = 0; i < Simulator.RoadManager.GenerateVehicleRoadList.Count; i++)
            {
                this.comboBox_generateRoads.Items.Add(Simulator.RoadManager.GenerateVehicleRoadList[i].roadID);
            }

            //Chech list and load other config
            if (Simulator.RoadManager.GenerateVehicleRoadList.Count == 0)
            {
                this.comboBox_generateRoads.SelectedIndex = -1;
                this.comboBox_generateLevel.SelectedIndex = 0;
                this.listBox_generateSchedule.Items.Clear();
                this.listBox_generateSchedule.Items.Add("No schedule");
            }
            else
            {
                this.comboBox_generateRoads.SelectedIndex = 0;
                /*LoadVehicleGenerateSetting();
                LoadGenerateSchedule();
                LoadDrivingPath();*/
            }

            //Clean list of other roads and reload
            this.comboBox_otherRoads.Items.Clear();
            for (int i = 0; i < Simulator.RoadManager.roadList.Count; i++)
            {
                if (Simulator.RoadManager.roadList[i].vehicleGenerateLevel == -1)
                { 
                    this.comboBox_otherRoads.Items.Add(Simulator.RoadManager.roadList[i].roadID);
                }   
            }
        }

        private void comboBox_generateRoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGenerateRoad = Simulator.RoadManager.GenerateVehicleRoadList[this.comboBox_generateRoads.SelectedIndex];
            LoadVehicleGenerateSetting();
            LoadGenerateSchedule();
            LoadDrivingPath();
            DrivingPathEditorInitial();
        }

        public void LoadVehicleGenerateSetting()
        {
            this.comboBox_generateLevel.SelectedIndex = selectedGenerateRoad.vehicleGenerateLevel;
        }

        public void LoadGenerateSchedule()
        {
            string[] generateSchedule = selectedGenerateRoad.generateSchedule.Keys.ToArray<string>();
            this.listBox_generateSchedule.Items.Clear();
            if (generateSchedule.Length == 0)
            {
                this.listBox_generateSchedule.Items.Add("No schedule");
            }
            else
            {
                for (int i = 0; i < generateSchedule.Length; i++)
                {
                    string time = generateSchedule[i];
                    int level = selectedGenerateRoad.generateSchedule[time];
                    this.listBox_generateSchedule.Items.Add(time + "  " + level);
                }
            }
        }

        public void LoadDrivingPath()
        {
            this.listBox_DrivingPath.Items.Clear();

            if (Simulator.VehicleManager.DrivingPathList.ContainsKey(selectedGenerateRoad.roadID))
            {
                List<DrivingPath> DrivingPaths = Simulator.VehicleManager.DrivingPathList[selectedGenerateRoad.roadID];

                for (int i = 0; i < DrivingPaths.Count; i++)
                {
                    this.listBox_DrivingPath.Items.Add(DrivingPaths[i].GetName() + "    " + DrivingPaths[i].getProbability());
                }
            }
            else
            {
                this.listBox_DrivingPath.Items.Add("NO Driving Path");
            }
        }

        public void DrivingPathEditorInitial()
        {
            newDrivingPath = new DrivingPath();
            newDrivingPath.setStartRoadID(selectedGenerateRoad.roadID);
            this.textBox_drivingPath.Text = selectedGenerateRoad.roadID+"";
            DrivingPathEditorLoadNextRoad(selectedGenerateRoad.roadID);

            this.button_nextRoad.Enabled = true;
            this.button_addDrivingPath.Enabled = false;
        }

        public void DrivingPathEditorLoadNextRoad(int currentRoadID)
        {
            this.comboBox_nextRoad.Items.Clear();
            List<int> nextRoadList = Simulator.RoadManager.GetRoadByID(currentRoadID).getConnectedRoadIDList();

            if (nextRoadList.Count > 0)
            {
                for (int i = 0; i < nextRoadList.Count; i++)
                {
                    this.comboBox_nextRoad.Items.Add(nextRoadList[i]);
                }
                this.comboBox_nextRoad.SelectedIndex = 0;
            }
            else
            {
                newDrivingPath.RemovePassingRoad(currentRoadID);
                newDrivingPath.setGoalRoadID(currentRoadID);
                this.button_nextRoad.Enabled = false;
                this.button_addDrivingPath.Enabled = true;
            }
        }

        private void comboBox_rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Simulator.RoadManager.GenerateVehicleRoadList.Count != 0)
            {
                selectedGenerateRoad.ChangeGenerateLevel(this.comboBox_generateLevel.SelectedIndex);
            }
        }

        private void numericUpDown_VehicleLength_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)this.numericUpDown_VehicleSize.Value;
            this.pictureBox_vehicleGraphicDemo.Height = size;
            this.pictureBox_vehicleGraphicDemo.Width = size * 2;  
        }

        private void button_applyConfig_Click(object sender, EventArgs e)
        {
            Simulator.VehicleManager.SetVehicleSize((int)this.numericUpDown_VehicleSize.Value);
            Simulator.VehicleManager.SetVehicleSpeedKMH((int)this.numericUpDown_VehicleSpeed.Value);
        }

        private void button_removeGenerateRoad_Click(object sender, EventArgs e)
        {
            if (this.comboBox_generateRoads.SelectedIndex >= 0)
            {
                int roadID = System.Convert.ToInt16(this.comboBox_generateRoads.Text);
                Simulator.RoadManager.RemoveVehicleGenerateRoad(roadID);
                LoadGenerateRoads();
            }
        }

        private void button_addGenerateRoad_Click(object sender, EventArgs e)
        {
            if(this.comboBox_otherRoads.SelectedIndex >= 0) 
            {
                int roadID = System.Convert.ToInt16(this.comboBox_otherRoads.Text);
                Simulator.RoadManager.AddVehicleGenerateRoad(roadID);
                LoadGenerateRoads();
            }
        }

        private void button_removeSchedule_Click(object sender, EventArgs e)
        {
            int scheduleIndex = this.listBox_generateSchedule.SelectedIndex;
            if (scheduleIndex >= 0)
            {
                string time = (this.listBox_generateSchedule.Items[scheduleIndex] + "").Split(' ')[0];
                selectedGenerateRoad.RemoveGenerateSchedule(time);
                LoadGenerateSchedule();
            }
        }

        private void button_addSchedule_Click(object sender, EventArgs e)
        {
            int hour = (int)this.numericUpDown_hour.Value;
            int minute = (int)this.numericUpDown_minute.Value;

            string time = Simulator.ToSimulatorTimeFormat(hour, minute, 0);
            int level = (int)this.numericUpDown_level.Value;

            selectedGenerateRoad.AddGenerateSchedule(time, level);

            LoadGenerateSchedule();
        }

        private void button_removePath_Click(object sender, EventArgs e)
        {
            int pathIndex = this.listBox_DrivingPath.SelectedIndex;
            if (pathIndex >= 0)
            {
                string name = (this.listBox_DrivingPath.Items[pathIndex] + "").Split(' ')[0];
                Simulator.VehicleManager.RemoveDrivingPath(selectedGenerateRoad.roadID, pathIndex, name);
            }

            LoadDrivingPath();
        }

        private void button_nextRoad_Click(object sender, EventArgs e)
        {
            int nextRoadID = System.Convert.ToInt16(this.comboBox_nextRoad.Text);
            newDrivingPath.AddPassingRoad(nextRoadID);
            this.textBox_drivingPath.Text += ("-" + nextRoadID);
            DrivingPathEditorLoadNextRoad(nextRoadID);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            DrivingPathEditorInitial();
        }

        private void button_addDrivingPath_Click(object sender, EventArgs e)
        {
            int weight = (int)this.numericUpDown_drivingPathWeight.Value;
            newDrivingPath.setProbability(weight);
            Simulator.VehicleManager.AddDrivingPath(newDrivingPath);
            LoadDrivingPath();
            DrivingPathEditorInitial();
        }

    }
}