using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.SystemManagers;

namespace SmartCitySimulator
{
    public partial class CarConfig : Form
    {
        public CarConfig()
        {
            InitializeComponent();
            LoadGenerationRoad(0);
        }

        public void LoadGenerationRoad(int selectedRoad)
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
            }
            else
            {
                this.comboBox_generateRoad.SelectedIndex = selectedRoad;
                LoadCarGenerateSetting(selectedRoad);
            }

            this.comboBox_OtherRoad.Items.Clear();
            for (int i = 0; i < Simulator.RoadManager.roadList.Count; i++)
            {
                if (Simulator.RoadManager.roadList[i].carGenerationLevel == -1)
                { 
                    this.comboBox_OtherRoad.Items.Add(Simulator.RoadManager.roadList[i].roadID);
                }   
            }

            this.numericUpDown_CarSize.Value = Simulator.CarManager.carSize;
            this.numericUpDown_CarSpeed.Value = Simulator.CarManager.carSpeed;
        }

        private void comboBox_generateRoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCarGenerateSetting(this.comboBox_generateRoad.SelectedIndex);
        }

        public void LoadCarGenerateSetting(int generateRoad)
        {
            this.comboBox_rate.SelectedIndex = Simulator.RoadManager.GenerateCarRoadList[generateRoad].carGenerationLevel;
        }

        private void comboBox_rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Simulator.RoadManager.GenerateCarRoadList.Count != 0)
                Simulator.RoadManager.GenerateCarRoadList[this.comboBox_generateRoad.SelectedIndex].carGenerationLevel = this.comboBox_rate.SelectedIndex;
        }

        private void numericUpDown_CarLength_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)this.numericUpDown_CarSize.Value;
            this.pictureBox_CarGraphicDemo.Height = size;
            this.pictureBox_CarGraphicDemo.Width = size * 2;
            
        }

        private void button_apply_Click(object sender, EventArgs e)
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
                LoadGenerationRoad(0);
            }
        }

        private void button_AddRoad_Click(object sender, EventArgs e)
        {
            if(this.comboBox_OtherRoad.SelectedIndex >= 0)
            {
                int roadID = System.Convert.ToInt16(this.comboBox_OtherRoad.Text);
                Simulator.RoadManager.AddCarGenerateRoad(roadID);
                LoadGenerationRoad(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}