﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SmartCitySimulator.SystemObject;
using System.Windows.Forms;
using SmartCitySimulator.Unit;

namespace SmartCitySimulator
{
    public partial class TrafficLightConfig : Form
    {
        Intersection selectedIntersection;
        public TrafficLightConfig(int intersectionID)
        {
            InitializeComponent();

            for (int i = 0; i < Simulator.IntersectionManager.CountIntersections(); i++)
            {
                this.comboBox_Intersections.Items.Add(i);
            }
            this.comboBox_Intersections.SelectedIndex = intersectionID;
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(intersectionID);
            LoadLightSetting();
        }

        private void comboBox_Insections_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(this.comboBox_Intersections.SelectedIndex);
            LoadLightSetting();
        }
        public void LoadLightSetting()
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

            int intersectionID = selectedIntersection.intersectionID;

            for (int i = 0; i < selectedIntersection.signalConfigList.Count; i++)
            {
                if (i == 0)
                {
                    this.numericUpDown_order_1_green.Value = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList[i].Green;
                    this.numericUpDown_order_1_yellow.Value = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList[i].Yellow;
                    this.numericUpDown_order_1_green.Visible = true;
                    this.numericUpDown_order_1_yellow.Visible = true;
                    this.label_order1.Visible = true;
                    if (Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList.Count > 1)
                        this.button_order_1_delete.Visible = true;
                }
                else if (i == 1)
                {
                    this.numericUpDown_order_2_green.Value = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList[i].Green;
                    this.numericUpDown_order_2_yellow.Value = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList[i].Yellow;
                    this.numericUpDown_order_2_green.Visible = true;
                    this.numericUpDown_order_2_yellow.Visible = true;
                    this.label_order2.Visible = true;
                    this.button_order_2_delete.Visible = true;
                }
                else if (i == 2)
                {
                    this.numericUpDown_order_3_green.Value = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList[i].Green;
                    this.numericUpDown_order_3_yellow.Value = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList[i].Yellow;
                    this.numericUpDown_order_3_green.Visible = true;
                    this.numericUpDown_order_3_yellow.Visible = true;
                    this.label_order3.Visible = true;
                    this.button_order_3_delete.Visible = true;
                }
                else if (i == 3)
                {
                    this.numericUpDown_order_4_green.Value = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList[i].Green;
                    this.numericUpDown_order_4_yellow.Value = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList[i].Yellow;
                    this.numericUpDown_order_4_green.Visible = true;
                    this.numericUpDown_order_4_yellow.Visible = true;
                    this.label_order4.Visible = true;
                    this.button_order_4_delete.Visible = true;
                }
            }
        }

        private void button_addNewSetting_Click(object sender, EventArgs e)
        {
            if (selectedIntersection.signalConfigList.Count < 4)
            {
                SignalConfig newConfig = new SignalConfig((int)this.numericUpDown_newGreen.Value, (int)this.numericUpDown_newYellow.Value);

                selectedIntersection.AddNewLightSetting(newConfig);

                LoadLightSetting();
            }
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
            int intersectionID = this.comboBox_Intersections.SelectedIndex;

            Simulator.IntersectionManager.GetIntersectionByID(intersectionID).DeleteLightSetting(order);

            LoadLightSetting();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            int intersectionID = this.comboBox_Intersections.SelectedIndex;
            List<SignalConfig> newConfigList = new List<SignalConfig>();

            for (int i = 0; i < Simulator.IntersectionManager.GetIntersectionByID(intersectionID).signalConfigList.Count; i++)//紅燈的計算
            {
                int[] config = new int[2];
                if(i == 0)
                {
                    config[0] = (int)this.numericUpDown_order_1_green.Value;
                    config[1] = (int)this.numericUpDown_order_1_yellow.Value;
                }
                else if (i == 1) 
                {
                    config[0] = (int)this.numericUpDown_order_2_green.Value;
                    config[1] = (int)this.numericUpDown_order_2_yellow.Value;
                }
                else if (i == 2) 
                {
                    config[0] = (int)this.numericUpDown_order_3_green.Value;
                    config[1] = (int)this.numericUpDown_order_3_yellow.Value;
                }
                else if (i == 3) 
                {
                    config[0] = (int)this.numericUpDown_order_4_green.Value;
                    config[1] = (int)this.numericUpDown_order_4_yellow.Value;
                }
                SignalConfig newConfig = new SignalConfig(config[0], config[1]);
                newConfigList.Add(newConfig);
            }
            Simulator.IntersectionManager.GetIntersectionByID(intersectionID).SetIntersectionLightConfig(newConfigList);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntersectionConfig form = new IntersectionConfig(this.comboBox_Intersections.SelectedIndex);
            form.ShowDialog();
        }

    }
}