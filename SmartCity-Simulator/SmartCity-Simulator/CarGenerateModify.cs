using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.SystemUnit;

namespace SmartCitySimulator
{
    public partial class CarGenerateModify : Form
    {
        public CarGenerateModify(int selectedRoad)
        {
            InitializeComponent();
            for (int i = 0; i < SimulatorConfiguration.RoadManager.GenerateCarRoadList.Count; i++)
            {
                this.comboBox_generateRoad.Items.Add(SimulatorConfiguration.RoadManager.GenerateCarRoadList[i].roadName);
            }
            this.comboBox_generateRoad.SelectedIndex = selectedRoad;
            LoadCarGenerateSetting(selectedRoad);
        }

        private void comboBox_generateRoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCarGenerateSetting(this.comboBox_generateRoad.SelectedIndex);
        }

        public void LoadCarGenerateSetting(int generateRoad)
        {
            this.comboBox_rate.SelectedIndex = SimulatorConfiguration.RoadManager.GenerateCarRoadList[generateRoad].carGenerateRate;
        }

        private void comboBox_rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SimulatorConfiguration.RoadManager.GenerateCarRoadList[this.comboBox_generateRoad.SelectedIndex].carGenerateRate = this.comboBox_rate.SelectedIndex;
        }

    }
}
