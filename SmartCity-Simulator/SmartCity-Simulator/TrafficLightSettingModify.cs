using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SmartCitySimulator.SystemUnit;
using System.Windows.Forms;

namespace SmartCitySimulator
{
    public partial class TrafficLightSettingModify : Form
    {
        public TrafficLightSettingModify(int selectedIntersection)
        {
            InitializeComponent();

            for (int i = 0; i < SimulatorConfiguration.IntersectionManager.IntersectionList.Count(); i++)
            {
                this.comboBox_Intersections.Items.Add(SimulatorConfiguration.IntersectionManager.IntersectionList[i].intersectionName);
            }
            this.comboBox_Intersections.SelectedIndex = selectedIntersection;
            LoadLightSetting(selectedIntersection);
        }

        private void LightSettingModify_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_Insections_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLightSetting(this.comboBox_Intersections.SelectedIndex);
        }
        public void LoadLightSetting(int intersection)
        {
            this.numericUpDown_order_1_green.Visible = false;
            this.numericUpDown_order_1_yellow.Visible = false;
            this.label_order1.Visible = false;
            this.button_order_1_delete.Visible = false;

            this.numericUpDown_order_2_green.Visible = false;
            this.numericUpDown_order_2_yellow.Visible = false;
            this.label_order2.Visible = false;
            this.button_order_2_delete.Visible = false;

            this.numericUpDown_order_3_green.Visible = false;
            this.numericUpDown_order_3_yellow.Visible = false;
            this.label_order3.Visible = false;
            this.button_order_3_delete.Visible = false;

            this.numericUpDown_order_4_green.Visible = false;
            this.numericUpDown_order_4_yellow.Visible = false;
            this.label_order4.Visible = false;
            this.button_order_4_delete.Visible = false;

            for (int i = 0; i < SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList.Count; i++)
            {
                if (i == 0)
                {
                    this.numericUpDown_order_1_green.Value = SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList[i][0];
                    this.numericUpDown_order_1_yellow.Value = SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList[i][1];
                    this.numericUpDown_order_1_green.Visible = true;
                    this.numericUpDown_order_1_yellow.Visible = true;
                    this.label_order1.Visible = true;
                    if (SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList.Count > 1)
                        this.button_order_1_delete.Visible = true;
                }
                else if (i == 1)
                {
                    this.numericUpDown_order_2_green.Value = SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList[i][0];
                    this.numericUpDown_order_2_yellow.Value = SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList[i][1];
                    this.numericUpDown_order_2_green.Visible = true;
                    this.numericUpDown_order_2_yellow.Visible = true;
                    this.label_order2.Visible = true;
                    this.button_order_2_delete.Visible = true;
                }
                else if (i == 2)
                {
                    this.numericUpDown_order_3_green.Value = SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList[i][0];
                    this.numericUpDown_order_3_yellow.Value = SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList[i][1];
                    this.numericUpDown_order_3_green.Visible = true;
                    this.numericUpDown_order_3_yellow.Visible = true;
                    this.label_order3.Visible = true;
                    this.button_order_3_delete.Visible = true;
                }
                else if (i == 3)
                {
                    this.numericUpDown_order_4_green.Value = SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList[i][0];
                    this.numericUpDown_order_4_yellow.Value = SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList[i][1];
                    this.numericUpDown_order_4_green.Visible = true;
                    this.numericUpDown_order_4_yellow.Visible = true;
                    this.label_order4.Visible = true;
                    this.button_order_4_delete.Visible = true;
                }
            }
        }

        private void button_addNewSetting_Click(object sender, EventArgs e)
        {
            int intersection = this.comboBox_Intersections.SelectedIndex;

            int[] newSetting = { (int)this.numericUpDown_newGreen.Value, (int)this.numericUpDown_newYellow.Value};

            SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].AddLightSetting(newSetting);

            LoadLightSetting(intersection);
        }

        private void button_order_1_delete_Click(object sender, EventArgs e)
        {
            DeleteOrder(0);
        }

        private void button_order_2_delete_Click(object sender, EventArgs e)
        {
            DeleteOrder(1);
        }

        private void button_order_3_delete_Click(object sender, EventArgs e)
        {
            DeleteOrder(2);
        }

        private void button_order_4_delete_Click(object sender, EventArgs e)
        {
            DeleteOrder(3);
        }

        public void DeleteOrder(int order)
        { 
            int intersection = this.comboBox_Intersections.SelectedIndex;

            SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].DeleteLightSetting(order);

            LoadLightSetting(intersection);
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            int intersection = this.comboBox_Intersections.SelectedIndex;
            List<int[]> newSettingList = new List<int[]>();

            for (int i = 0; i < SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].LightSettingList.Count; i++)//紅燈的計算
            {
               int[] newSetting = new int[2];
               if(i == 0)
               {
                   newSetting[0] = (int)this.numericUpDown_order_1_green.Value;
                   newSetting[1] = (int)this.numericUpDown_order_1_yellow.Value;
               }
               else if (i == 1) 
               {
                   newSetting[0] = (int)this.numericUpDown_order_2_green.Value;
                   newSetting[1] = (int)this.numericUpDown_order_2_yellow.Value;
               }
               else if (i == 2) 
               {
                   newSetting[0] = (int)this.numericUpDown_order_3_green.Value;
                   newSetting[1] = (int)this.numericUpDown_order_3_yellow.Value;
               }
               else if (i == 3) 
               {
                   newSetting[0] = (int)this.numericUpDown_order_4_green.Value;
                   newSetting[1] = (int)this.numericUpDown_order_4_yellow.Value;
               }
               newSettingList.Add(newSetting);
            }
            SimulatorConfiguration.IntersectionManager.IntersectionList[intersection].ModifyLightSetting(newSettingList);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntersectionSettingModify form = new IntersectionSettingModify(this.comboBox_Intersections.SelectedIndex);
            form.ShowDialog();
        }

    }
}
