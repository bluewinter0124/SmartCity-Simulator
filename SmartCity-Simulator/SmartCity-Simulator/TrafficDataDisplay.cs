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
    public partial class TrafficDataDisplay : Form
    {

        List<List<string>> AllHistoryData = new List<List<string>>();
        int startPeriod;
        int endPeriod;


        public TrafficDataDisplay()
        {
            InitializeComponent();

            for (int i = 0; i < Simulator.IntersectionManager.IntersectionList.Count(); i++)
            {
                this.comboBox_Intersections.Items.Add(Simulator.IntersectionManager.IntersectionList[i].intersectionName);
            }
            this.comboBox_Intersections.SelectedIndex = 0;
        }

        public void LoadIntersectionHistoryData(int intersection) 
        {
            int oldRoadIndex = this.comboBox_Road.SelectedIndex;
            startPeriod = (int)this.numericUpDown_startPeriod.Value;
            endPeriod = (int)this.numericUpDown_endPeriod.Value;

            this.comboBox_Road.Items.Clear();
            this.dataGridView_RoadData.Rows.Clear();

            AllHistoryData.Clear();
            for (int i = 0; i < Simulator.IntersectionManager.IntersectionList[intersection].roadList.Count; i++)
            {
                this.dataGridView_RoadData.Rows.Add();
                this.dataGridView_RoadData.Rows[i].Cells[0].Value = Simulator.IntersectionManager.IntersectionList[intersection].roadList[i].roadName;
                this.comboBox_Road.Items.Add(Simulator.IntersectionManager.IntersectionList[intersection].roadList[i].roadName);
                AllHistoryData.Add(Simulator.IntersectionManager.IntersectionList[intersection].roadList[i].getHistoryData());
            }

            this.comboBox_Road.SelectedIndex = oldRoadIndex;

            double TEC = 0, IAWR = 0,IAWT = 0;
            double[] road_WR = new double[AllHistoryData.Count]; //等待率
            double[] road_WT = new double[AllHistoryData.Count]; //等待時間
            double[] road_EC = new double[AllHistoryData.Count]; //進入車輛

            for (int x = 0; x < AllHistoryData.Count; x++)
            {
                List <string> historyData = AllHistoryData[x];
                int srartIndex = startPeriod;
                int endIndex = endPeriod;

                if (startPeriod >= historyData.Count)
                    srartIndex = historyData.Count - 1;
                else if (startPeriod < 0)
                    srartIndex = 0;

                if (endPeriod >= historyData.Count || endPeriod <= 0)
                    endIndex = historyData.Count - 1;

                double Period = 0,AEC = 0, AWC = 0, AWT = 0, AWR = 0;

                for (int y = 0; y <= historyData.Count; y++)
                {
                    if (y < srartIndex || y > endIndex)
                        continue;

                    Period++;
                    String[] temp = historyData[y].Split(',');

                    double TLT,EC,TWC,TWT;
                    TLT = System.Convert.ToDouble(temp[0].Split(':')[1]);
                    EC = System.Convert.ToDouble(temp[1].Split(':')[1]);
                    TWC = System.Convert.ToDouble(temp[3].Split(':')[1]);
                    TWT = System.Convert.ToDouble(temp[4].Split(':')[1]);

                    AEC += ((EC / TLT) * 60);
                    AWC += ((TWC / TLT) * 60);

                    if (System.Convert.ToDouble(temp[1].Split(':')[1]) != 0)
                    {
                        AWT += (System.Convert.ToDouble(temp[4].Split(':')[1]) / System.Convert.ToDouble(temp[1].Split(':')[1]));
                        AWR += (System.Convert.ToDouble(temp[3].Split(':')[1]) / System.Convert.ToDouble(temp[1].Split(':')[1])) * 100;
                    }
                    if (System.Convert.ToDouble(temp[3].Split(':')[1]) > System.Convert.ToDouble(temp[1].Split(':')[1]))
                        AWR += 100;

                }
                if (Period > 0)
                {
                    AEC = AEC / Period;
                    AWC = AWC / Period;
                    AWT = AWT / Period;
                    AWR = AWR / Period;
                }

                this.dataGridView_RoadData.Rows[x].Cells[1].Value = Math.Round(AEC,2,MidpointRounding.AwayFromZero);
                this.dataGridView_RoadData.Rows[x].Cells[2].Value = Math.Round(AWC, 2, MidpointRounding.AwayFromZero);
                this.dataGridView_RoadData.Rows[x].Cells[3].Value = Math.Round(AWR, 2, MidpointRounding.AwayFromZero);
                this.dataGridView_RoadData.Rows[x].Cells[4].Value = Math.Round(AWT, 2, MidpointRounding.AwayFromZero);

                road_EC[x] = AEC;
                road_WT[x] = AWT;
                road_WR[x] = AWR;
                TEC += AEC;
                
            }

            if (TEC != 0)
            {
                for (int z = 0; z < AllHistoryData.Count; z++)
                {
                    double weight = road_EC[z] / TEC;
                    IAWR += (weight * road_WR[z]);
                    IAWT += (weight * road_WT[z]);
                }
            }

            this.label_AWR.Text = Math.Round(IAWR, 2, MidpointRounding.AwayFromZero) +"";
            this.label_IAWT.Text = Math.Round(IAWT, 2, MidpointRounding.AwayFromZero) +"";


            if (this.comboBox_Road.SelectedIndex >= AllHistoryData.Count || this.comboBox_Road.SelectedIndex < 0)
                this.comboBox_Road.SelectedIndex = 0;

            LoadRoadHistoryData(this.comboBox_Road.SelectedIndex);

        }

        public void LoadRoadHistoryData(int road)
        {
            List<string> historyData = AllHistoryData[road];
            this.dataGridView_singleRoadData.Rows.Clear();

            int srartIndex = startPeriod;
            int endIndex = endPeriod;

            if (startPeriod >= historyData.Count)
                srartIndex = historyData.Count - 1;
            else if (startPeriod < 0)
                srartIndex = 0;

            if (endPeriod >= historyData.Count || endPeriod <= 0)
                endIndex = historyData.Count - 1;

            for (int x = 0; x < historyData.Count; x++)
            {
                int dataNo = historyData.Count - 1 - x;

                if (dataNo < srartIndex || dataNo > endIndex)
                    continue;


                this.dataGridView_singleRoadData.Rows.Add();
                String[] temp = historyData[dataNo].Split(',');
                int topRowsIndex = this.dataGridView_singleRoadData.Rows.Count - 1;

                this.dataGridView_singleRoadData.Rows[topRowsIndex].Cells[0].Value = dataNo;
                this.dataGridView_singleRoadData.Rows[topRowsIndex].Cells[1].Value = Math.Round(System.Convert.ToDouble(temp[1].Split(':')[1]), 2, MidpointRounding.AwayFromZero);
                this.dataGridView_singleRoadData.Rows[topRowsIndex].Cells[2].Value = Math.Round(System.Convert.ToDouble(temp[2].Split(':')[1]), 2, MidpointRounding.AwayFromZero);
                this.dataGridView_singleRoadData.Rows[topRowsIndex].Cells[3].Value = Math.Round(System.Convert.ToDouble(temp[3].Split(':')[1]), 2, MidpointRounding.AwayFromZero);
                
                if (System.Convert.ToDouble(temp[1].Split(':')[1]) != 0)
                    this.dataGridView_singleRoadData.Rows[topRowsIndex].Cells[4].Value = Math.Round(System.Convert.ToDouble(temp[3].Split(':')[1]) / System.Convert.ToDouble(temp[1].Split(':')[1]), 2, MidpointRounding.AwayFromZero);
                else
                    this.dataGridView_singleRoadData.Rows[topRowsIndex].Cells[4].Value = 0;

                this.dataGridView_singleRoadData.Rows[topRowsIndex].Cells[5].Value = Math.Round( System.Convert.ToDouble(temp[4].Split(':')[1]), 2, MidpointRounding.AwayFromZero);
            }
        }

        private void comboBox_Intersections_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIntersectionHistoryData(this.comboBox_Intersections.SelectedIndex);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadIntersectionHistoryData(this.comboBox_Intersections.SelectedIndex);
        }

        private void comboBox_road_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoadHistoryData(this.comboBox_Road.SelectedIndex);
        }

        /*
                double TLT = 0;
                for (int y = 0; y < historyData.Count; y++)
                {
                    String[] temp = historyData[y].Split(',');
                    TLT += System.Convert.ToDouble(temp[0].Split(':')[1]);
                    AEC += System.Convert.ToDouble(temp[1].Split(':')[1]);
                    AWC += System.Convert.ToDouble(temp[3].Split(':')[1]);
                    AWT += System.Convert.ToDouble(temp[4].Split(':')[1]);
                }
                if(AEC!=0)
                    AWT = AWT / AEC;
                if(TLT != 0)
                {
                    AEC = AEC / TLT * 60;
                    AWC = AWC / TLT * 60;
                }*/
    }
}
