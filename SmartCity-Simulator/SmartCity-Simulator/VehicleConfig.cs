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
    public partial class VehicleConfig : Form
    {
        Road selectedGenerationRoad;

        public VehicleConfig()
        {
            InitializeComponent();
            selectedGenerationRoad = Simulator.RoadManager.GenerateCarRoadList[0];
            LoadGenerationRoads();

            this.numericUpDown_CarSize.Value = Simulator.CarManager.carSize;
            this.numericUpDown_CarSpeed.Value = Simulator.CarManager.carSpeed;
        }

        public void LoadGenerationRoads()
        {
            this.comboBox_generateRoad.Items.Clear();
            for (int i = 0; i < Simulator.RoadManager.GenerateCarRoadList.Count; i++)
            {
                this.comboBox_generateRoad.Items.Add(Simulator.RoadManager.GenerateCarRoadList[i].roadID);
            }
            if (Simulator.RoadManager.GenerateCarRoadList.Count == 0)
            {
                this.comboBox_generateRoad.SelectedIndex = -1;
                this.comboBox_rate.SelectedIndex = 0;
                this.listBox_generateSchedule.Items.Clear();
                this.listBox_generateSchedule.Items.Add("No schedule");
            }
            else
            {
                this.comboBox_generateRoad.SelectedIndex = 0;
                LoadCarGenerateSetting();
                LoadGenerationSchedule();
            }

            this.comboBox_OtherRoad.Items.Clear();
            for (int i = 0; i < Simulator.RoadManager.roadList.Count; i++)
            {
                if (Simulator.RoadManager.roadList[i].carGenerationLevel == -1)
                { 
                    this.comboBox_OtherRoad.Items.Add(Simulator.RoadManager.roadList[i].roadID);
                }   
            }
        }

        private void comboBox_generateRoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedGenerationRoad = Simulator.RoadManager.GenerateCarRoadList[this.comboBox_generateRoad.SelectedIndex];
            LoadCarGenerateSetting();
            LoadGenerationSchedule();
        }

        public void LoadCarGenerateSetting()
        {
            this.comboBox_rate.SelectedIndex = selectedGenerationRoad.carGenerationLevel;
        }

        public void LoadGenerationSchedule()
        {
            string[] generateSchedule = selectedGenerationRoad.generationSchedule.Keys.ToArray<string>();
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
                    int level = selectedGenerationRoad.generationSchedule[time];
                    this.listBox_generateSchedule.Items.Add(time + " " + level);
                }
            }
        }

        private void comboBox_rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Simulator.RoadManager.GenerateCarRoadList.Count != 0)
                selectedGenerationRoad.carGenerationLevel = this.comboBox_rate.SelectedIndex;
        }

        private void numericUpDown_CarLength_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)this.numericUpDown_CarSize.Value;
            this.pictureBox_CarGraphicDemo.Height = size;
            this.pictureBox_CarGraphicDemo.Width = size * 2;
            
        }

        private void button_applyConfig_Click(object sender, EventArgs e)
        {
            Simulator.CarManager.SetCarSize((int)this.numericUpDown_CarSize.Value);
            Simulator.CarManager.SetCarSpeedKMH((int)this.numericUpDown_CarSpeed.Value);
        }

        private void button_RemoveRoad_Click(object sender, EventArgs e)
        {
            if (this.comboBox_generateRoad.SelectedIndex >= 0)
            {
                int roadID = System.Convert.ToInt16(this.comboBox_generateRoad.Text);
                Simulator.RoadManager.RemoveCarGenerateRoad(roadID);
                LoadGenerationRoads();
            }
        }

        private void button_AddRoad_Click(object sender, EventArgs e)
        {
            if(this.comboBox_OtherRoad.SelectedIndex >= 0)
            {
                int roadID = System.Convert.ToInt16(this.comboBox_OtherRoad.Text);
                Simulator.RoadManager.AddCarGenerateRoad(roadID);
                LoadGenerationRoads();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_removeSchedule_Click(object sender, EventArgs e)
        {
            int scheduleIndex = this.listBox_generateSchedule.SelectedIndex;
            string time = (this.listBox_generateSchedule.Items[scheduleIndex]+"").Split(' ')[0];
            selectedGenerationRoad.RemoveGenerationSchedule(time);
            LoadGenerationSchedule();
        }

        private void button_addSchedule_Click(object sender, EventArgs e)
        {
            int hour = (int)this.numericUpDown_hour.Value;
            int minute = (int)this.numericUpDown_minute.Value;

            string time = Simulator.ToSimulatorTime(hour, minute, 0);
            int level = (int)this.numericUpDown_level.Value;

            selectedGenerationRoad.AddGenerationSchedule(time, level);

            LoadGenerationSchedule();

        }

    }
}