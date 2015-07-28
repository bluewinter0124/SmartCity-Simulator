using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.SystemObject;
using System.Windows.Forms;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator
{
    public partial class TrafficSignalConfig : Form
    {
        Intersection selectedIntersection;
        List<NumericUpDown> Green = new List<NumericUpDown>();
        List<NumericUpDown> Yellow = new List<NumericUpDown>();
        List<Button> Delete = new List<Button>();
        List<Label> ConfigNumber = new List<Label>();


        public TrafficSignalConfig(int intersectionID)
        {
            InitializeComponent();

            Green.Add(this.numericUpDown_order_1_green);
            Green.Add(this.numericUpDown_order_2_green);
            Green.Add(this.numericUpDown_order_3_green);
            Green.Add(this.numericUpDown_order_4_green);

            Yellow.Add(this.numericUpDown_order_1_yellow);
            Yellow.Add(this.numericUpDown_order_2_yellow);
            Yellow.Add(this.numericUpDown_order_3_yellow);
            Yellow.Add(this.numericUpDown_order_4_yellow);

            Delete.Add(this.button_order_1_delete);
            Delete.Add(this.button_order_2_delete);
            Delete.Add(this.button_order_3_delete);
            Delete.Add(this.button_order_4_delete);

            ConfigNumber.Add(this.label_config1);
            ConfigNumber.Add(this.label_config2);
            ConfigNumber.Add(this.label_config3);
            ConfigNumber.Add(this.label_config4);


            for (int i = 0; i < Simulator.IntersectionManager.GetNumberOfIntersections(); i++)
            {
                this.comboBox_Intersections.Items.Add(i);
            }
            this.comboBox_Intersections.SelectedIndex = intersectionID;
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(intersectionID);
            LoadSignalSetting();
        }

        private void comboBox_Insections_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIntersection = Simulator.IntersectionManager.GetIntersectionByID(this.comboBox_Intersections.SelectedIndex);
            LoadSignalSetting();
        }
        public void LoadSignalSetting()
        {

            foreach (NumericUpDown nud in Green)
            {
                nud.Visible = false;
            }
            foreach (NumericUpDown nud in Yellow)
            {
                nud.Visible = false;
            }
            foreach (Button but in Delete)
            {
                but.Visible = false;
            }
            foreach (Label lab in ConfigNumber)
            {
                lab.Visible = false;
            }

            for (int i = 0; i < selectedIntersection.signalConfigList.Count; i++)
            {
                Green[i].Value = selectedIntersection.signalConfigList[i].Green;
                Yellow[i].Value = selectedIntersection.signalConfigList[i].Yellow;
                Green[i].Visible = true;
                Yellow[i].Visible = true;
                Delete[i].Visible = true;
                ConfigNumber[i].Visible = true;

                if (!Simulator.simulatorStarted)
                {
                    Delete[i].Enabled = true;
                }
                else
                {
                    Delete[i].Enabled = false;
                }
            }

            if (Simulator.simulatorStarted)
            {
                this.button_addNewSetting.Enabled = false;
            }

            if (selectedIntersection.signalConfigList.Count <= 1)
            {
                this.button_order_1_delete.Enabled = false;
            }
        }

        private void button_addNewSetting_Click(object sender, EventArgs e)
        {
            if (selectedIntersection.signalConfigList.Count < 4 && !Simulator.simulatorStarted)
            {
                SignalConfig newConfig = new SignalConfig((int)this.numericUpDown_newGreen.Value, (int)this.numericUpDown_newYellow.Value);

                selectedIntersection.AddNewSignalSetting(newConfig);
            }
            LoadSignalSetting();
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
            if (!Simulator.simulatorStarted)
            {
                selectedIntersection.DeleteSignalSetting(order);
            }
            LoadSignalSetting();
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
            Simulator.IntersectionManager.GetIntersectionByID(intersectionID).SetIntersectionSignalConfig(newConfigList);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntersectionConfig form = new IntersectionConfig(this.comboBox_Intersections.SelectedIndex);
            form.ShowDialog();
        }

    }
}
