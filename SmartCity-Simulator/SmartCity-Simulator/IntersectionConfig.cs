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
    public partial class IntersectionConfig : Form
    {
        Label[] roadLabel = new Label[8];
        ComboBox[] roadOrder = new ComboBox[8];
        Intersection selectedIntersection;

        int Roads;
        int MaxOrder;

        public IntersectionConfig(int intersectionID)
        {
            
            InitializeComponent();
            for (int id = 0; id < Simulator.IntersectionManager.GetTotalIntersections(); id++)
            {
                this.comboBox_Insections.Items.Add(id);
            }
            roadLabel[0] = this.label1;
            roadLabel[1] = this.label2;
            roadLabel[2] = this.label3;
            roadLabel[3] = this.label4;
            roadLabel[4] = this.label5;
            roadLabel[5] = this.label6;
            roadLabel[6] = this.label7;
            roadLabel[7] = this.label8;

            roadOrder[0] = this.comboBox1;
            roadOrder[1] = this.comboBox2;
            roadOrder[2] = this.comboBox3;
            roadOrder[3] = this.comboBox4;
            roadOrder[4] = this.comboBox5;
            roadOrder[5] = this.comboBox6;
            roadOrder[6] = this.comboBox7;
            roadOrder[7] = this.comboBox8;

            this.comboBox_Insections.SelectedIndex = intersectionID;
            LoadIntersectionSetting(intersectionID);
        }

        private void comboBox_Insections_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIntersectionSetting(this.comboBox_Insections.SelectedIndex);
        }

        public void LoadIntersectionSetting(int intersectionID) 
        {
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(intersectionID);
            MaxOrder = selectedIntersection.LightSettingList.Count;
            Roads = selectedIntersection.roadList.Count;

            for (int i = 0; i < 8; i++)
            {
                if (i < Roads)
                {
                    roadOrder[i].Items.Clear();
                    for (int a = 0; a < MaxOrder; a++)
                    {
                        roadOrder[i].Items.Add(a);
                    }

                    roadLabel[i].Visible = true;
                    roadOrder[i].Visible = true;
                    roadLabel[i].Text = selectedIntersection.roadList[i].roadName;
                    roadOrder[i].SelectedIndex = selectedIntersection.roadList[i].order;

                }
                else
                {
                    roadLabel[i].Visible = false;
                    roadOrder[i].Visible = false;
                }
            }

            this.numericUpDown_optimizeInterval.Value = selectedIntersection.optimizeInerval;
            this.numericUpDown_IAWRThreshold.Value = (decimal)selectedIntersection.IAWRThreshold;

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i < Roads)
                {
                    selectedIntersection.roadList[i].order = Int32.Parse(roadOrder[i].Text);
                }
            }
            selectedIntersection.optimizeInerval = (int)numericUpDown_optimizeInterval.Value;
            selectedIntersection.IAWRThreshold = (double)numericUpDown_IAWRThreshold.Value;

            selectedIntersection.RefreshLightGraphicDisplay();
        }

    }
}