using Optimization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartTrafficSimulator.OptimizationModels
{
    public partial class OptimizationTest : Form
    {
        TrafficOptimization TO;

        List<string> results = new List<string>();
        public OptimizationTest()
        {
            InitializeComponent();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {

            int maxGreen = (int)numericUpDown_maxGreen.Value;
            int minGreen = (int)numericUpDown_minGreen.Value;
            int phase = (int)numericUpDown_phase.Value;
            Boolean fixedCycle = checkBox_fixedCycle.Checked;

            int population = (int)numericUpDown_population.Value;
            int generation = (int)numericUpDown_generation.Value;
            double crossover = (double)numericUpDown_crossover.Value;
            double mutation = (double)numericUpDown_mutation.Value;

            double IAWRW = (double)numericUpDown_IAWRW.Value;
            double TDFW = (double)numericUpDown_TDFW.Value;
            double CLFW = (double)numericUpDown_CLFW.Value;

            TO = new TrafficOptimization(minGreen,maxGreen,fixedCycle);
            TO.setPhases(phase);
            TO.Config_GA_Parameter(population, generation, crossover, mutation);
            TO.Config_GA_FitnessWeight(IAWRW, TDFW, CLFW);

            double V1 = (double)numericUpDown_V1.Value;
            double V2 = (double)numericUpDown_V2.Value;
            double V3 = (double)numericUpDown_V3.Value;
            double V4 = (double)numericUpDown_V4.Value;

            int P1 = (int)numericUpDown_P1.Value;
            int P2 = (int)numericUpDown_P2.Value;
            int P3 = (int)numericUpDown_P3.Value;
            int P4 = (int)numericUpDown_P4.Value;

            TO.AddRoad(1, P1, 60, 60, V1, 0, 0);
            TO.AddRoad(2, P2, 60, 60, V2, 0, 0);
            TO.AddRoad(3, P3, 60, 60, V3, 0, 0);
            TO.AddRoad(4, P4, 60, 60, V4, 0, 0);

            int testTimes = (int)numericUpDown_testTimes.Value;
            StartTest(testTimes);
        }

        public void StartTest(int times)
        {
            for (int t = 0; t < times; t++)
            {
                TO.Optimization_GA();

                List<string> record = TO.GetRecord_GA();
                string result = record[record.Count - 1];
                results.Add(result);
                /*foreach (string re in record)
                {
                    this.dataGridView1.Rows[this.dataGridView1.Rows.Add()].Cells[0].Value = re;
                }*/
                this.dataGridView1.Rows[this.dataGridView1.Rows.Add()].Cells[0].Value = result;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }
    }
}
