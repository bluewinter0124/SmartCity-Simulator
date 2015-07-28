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
    public partial class IntersectionConfig : Form
    {
        Label[] roadLabel = new Label[8];
        ComboBox[] roadOrder = new ComboBox[8];
        Intersection selectedIntersection;

        int containRoads;

        public IntersectionConfig(int intersectionID)
        {
            InitializeComponent();
            for (int id = 0; id < Simulator.IntersectionManager.GetNumberOfIntersections(); id++)
            {
                this.comboBox_Intersections.Items.Add(id);
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

            this.comboBox_Intersections.SelectedIndex = intersectionID;
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(intersectionID);
           

            LoadIntersectionConfig();
        }

        private void comboBox_Insections_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(this.comboBox_Intersections.SelectedIndex);
            LoadIntersectionConfig();
        }

        public void LoadIntersectionConfig() 
        {
            containRoads = selectedIntersection.roadList.Count;
            int maxConfigNo = selectedIntersection.signalConfigList.Count() - 1;

            for (int i = 0; i < 8; i++)
            {
                if (i < containRoads)
                {
                    roadOrder[i].Items.Clear();
                    for (int a = 0; a <= maxConfigNo; a++)
                    {
                        roadOrder[i].Items.Add(a);
                    }

                    roadLabel[i].Visible = true;
                    roadOrder[i].Visible = true;
                    roadLabel[i].Text = selectedIntersection.roadList[i].roadName;
                    if (maxConfigNo >= selectedIntersection.roadList[i].phaseNo)
                    {
                        roadOrder[i].SelectedIndex = selectedIntersection.roadList[i].phaseNo;
                    }
                    else
                    {
                        roadOrder[i].SelectedIndex = 0;
                    }

                }
                else
                {
                    roadLabel[i].Visible = false;
                    roadOrder[i].Visible = false;
                }
            }
            this.numericUpDown_cycleInterval.Value = selectedIntersection.optimizationInterval_Cycle;
            this.label_OptimizeInterval.Text = selectedIntersection.optimizationInterval_Cycle+"";
            this.numericUpDown_IAWRThreshold.Value = (decimal)selectedIntersection.optimizationThreshold_IAWR;

        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i < containRoads)
                {
                    selectedIntersection.roadList[i].phaseNo = Int32.Parse(roadOrder[i].Text);
                }
            }


            if (this.radioButton_optByCycle.Checked)
            {
                selectedIntersection.optimizationInterval_Cycle = (int)numericUpDown_cycleInterval.Value;
            }
            else if(this.radioButton_optByTime.Checked)
            {
                int intervalTime = (int)numericUpDown_timeInterval.Value;
                int timeToCycle = (intervalTime * 60) / selectedIntersection.GetCycleTime();
                if (timeToCycle < 1)
                    timeToCycle = 1;
                selectedIntersection.optimizationInterval_Cycle = timeToCycle;
            }
            selectedIntersection.optimizationThreshold_IAWR = (double)numericUpDown_IAWRThreshold.Value;

            selectedIntersection.RefreshSignalGraphic();

            LoadIntersectionConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrafficSignalConfig form = new TrafficSignalConfig(selectedIntersection.intersectionID);
            form.Show();
        }

    }
}