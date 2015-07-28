using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator
{
    public partial class VehicleConfig : Form
    {
        Road selectedGenerateRoad = null;
        DrivingPath newDrivingPath;

        public VehicleConfig()
        {
            InitializeComponent();
            if(Simulator.RoadManager.GetGenerateVehicleRoadList().Count > 0)
                selectedGenerateRoad = Simulator.RoadManager.GetGenerateVehicleRoadList()[0];

            LoadGenerateRoads();

            this.numericUpDown_vehicleSize.Value = Simulator.VehicleManager.vehicleGraphicSize;
            this.numericUpDown_vehicleMaxSpeed.Value = (decimal)Simulator.VehicleManager.vehicleMaxSpeed_KMH;
            this.numericUpDown_accelerationFactor.Value = (decimal)Simulator.VehicleManager.vehicleAccelerationFactor_KMH;
            this.numericUpDown_brakeFactor.Value = (decimal)Simulator.VehicleManager.vehicleBrakeFactor_KMH;
        }

        public void LoadGenerateRoads()
        {
            //Clean list of generate road and reload
            this.comboBox_generateRoads.Items.Clear();
            for (int i = 0; i < Simulator.RoadManager.GetGenerateVehicleRoadList().Count; i++)
            {
                this.comboBox_generateRoads.Items.Add(Simulator.RoadManager.GetGenerateVehicleRoadList()[i].roadID);
            }

            //Check list and load other config
            if (Simulator.RoadManager.GetGenerateVehicleRoadList().Count == 0)
            {
                this.comboBox_generateRoads.SelectedIndex = -1;
                this.numericUpDown_volum.Value = 0;
                this.listBox_generateSchedule.Items.Clear();
                this.listBox_generateSchedule.Items.Add("No schedule");
            }
            else
            {
                this.comboBox_generateRoads.SelectedIndex = 0;
            }

            //Clean list of other roads and reload
            this.comboBox_otherRoads.Items.Clear();
            for (int i = 0; i < Simulator.RoadManager.GetRoadList().Count; i++)
            {
                if (Simulator.RoadManager.GetRoadList()[i].generateLevel_lambda == -1)
                { 
                    this.comboBox_otherRoads.Items.Add(Simulator.RoadManager.GetRoadList()[i].roadID);
                }   
            }
        }

        private void comboBox_generateRoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGenerateRoad = Simulator.RoadManager.GetGenerateVehicleRoadList()[this.comboBox_generateRoads.SelectedIndex];
            LoadVehicleGenerateSetting();
            LoadGenerateSchedule();
            LoadDrivingPath();
            DrivingPathEditorInitial();
        }

        public void LoadVehicleGenerateSetting()
        {
            this.numericUpDown_volum.Value = (decimal)selectedGenerateRoad.generateLevel_lambda;
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

            if (Simulator.VehicleManager.GetDrivingPathList().ContainsKey(selectedGenerateRoad.roadID))
            {
                Dictionary<string,DrivingPath> DrivingPaths = Simulator.VehicleManager.GetDrivingPathList()[selectedGenerateRoad.roadID];

                DrivingPath[] drivingPaths = DrivingPaths.Values.ToArray<DrivingPath>();
                foreach (DrivingPath drivingPath in drivingPaths)
                {
                    this.listBox_DrivingPath.Items.Add(drivingPath.GetName() + "    " + drivingPath.GetProbability());
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
            newDrivingPath.SetStartRoadID(selectedGenerateRoad.roadID);
            this.textBox_drivingPath.Text = selectedGenerateRoad.roadID+"";
            DrivingPathEditorLoadNextRoad(selectedGenerateRoad.roadID);

            this.button_nextRoad.Enabled = true;
            this.button_addDrivingPath.Enabled = false;
        }

        public void DrivingPathEditorLoadNextRoad(int currentRoadID)
        {
            this.comboBox_nextRoad.Items.Clear();
            List<int> nextRoadList = Simulator.RoadManager.GetRoadByID(currentRoadID).GetConnectedRoadIDList();

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
                newDrivingPath.SetGoalRoadID(currentRoadID);
                this.button_nextRoad.Enabled = false;
                this.button_addDrivingPath.Enabled = true;
            }
        }

        private void numericUpDown_volum_ValueChanged(object sender, EventArgs e)
        {
            selectedGenerateRoad.SetGenerateLevel((int)this.numericUpDown_volum.Value);
        }

        private void numericUpDown_VehicleLength_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)this.numericUpDown_vehicleSize.Value;
            this.pictureBox_vehicleGraphicDemo.Height = System.Convert.ToInt16(size);
            this.pictureBox_vehicleGraphicDemo.Width = System.Convert.ToInt16(size * 2);

        }

        private void button_applyConfig_Click(object sender, EventArgs e)
        {
            Simulator.VehicleManager.SetVehicleGraphicSize((int)this.numericUpDown_vehicleSize.Value);
            Simulator.VehicleManager.SetVehicleSpeedKMH((int)this.numericUpDown_vehicleMaxSpeed.Value);
            Simulator.VehicleManager.SetVehicleAccelerationFactor((int)this.numericUpDown_accelerationFactor.Value);
            Simulator.VehicleManager.SetVehicleBrakeFactor((int)this.numericUpDown_brakeFactor.Value);
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

            string time = Simulator.getTimeFormat(hour, minute, 0);
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
                Simulator.VehicleManager.RemoveDrivingPath(selectedGenerateRoad.roadID, name);
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
            int probability = (int)this.numericUpDown_drivingPathProbability.Value;
            newDrivingPath.SetProbability(probability);
            Simulator.VehicleManager.AddDrivingPath(newDrivingPath);
            LoadDrivingPath();
            DrivingPathEditorInitial();
        }

        private void numericUpDown_VehicleSpeed_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button_testGenerate_Click(object sender, EventArgs e)
        {
            Simulator.VehicleManager.CreateVehicle(selectedGenerateRoad, 1);
        }

        

    }
}