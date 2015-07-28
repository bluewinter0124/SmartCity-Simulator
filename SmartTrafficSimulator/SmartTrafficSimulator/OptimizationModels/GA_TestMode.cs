using Optimization;
using SmartTrafficSimulator.OptimizationModels.GA;
using SmartTrafficSimulator.SystemManagers;
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
    public partial class GA_TestMode : Form
    {
        TrafficOptimization TO;
        GA_Parameters testPara = new GA_Parameters();

        List<string> results = new List<string>();
        public GA_TestMode()
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

            testPara.Config_GAParameter(population, generation, crossover, mutation);
            testPara.Config_FitnessWeight(IAWRW, TDFW, CLFW);

            TO = new TrafficOptimization(minGreen,maxGreen,fixedCycle);
            TO.setPhases(phase);

            TO.optimization_GA.SetGAParameter(testPara);

            double V1 = (double)numericUpDown_V1.Value;
            double V2 = (double)numericUpDown_V2.Value;
            double V3 = (double)numericUpDown_V3.Value;
            double V4 = (double)numericUpDown_V4.Value;

            int P1 = (int)numericUpDown_P1.Value;
            int P2 = (int)numericUpDown_P2.Value;
            int P3 = (int)numericUpDown_P3.Value;
            int P4 = (int)numericUpDown_P4.Value;

            TO.AddRoad(1, P1, 60, 60, V1,0, 0, 0);
            TO.AddRoad(2, P2, 60, 60, V2,0, 0, 0);
            TO.AddRoad(3, P3, 60, 60, V3,0, 0, 0);
            TO.AddRoad(4, P4, 60, 60, V4,0, 0, 0);

            int testTimes = (int)numericUpDown_testTimes.Value;
            StartTest(testTimes);
        }

        public void StartTest(int times)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//引用stopwatch物件
            double avgCostTime = 0;


            for (int t = 0; t < times; t++)
            {
                sw.Reset();
                sw.Start();

                TO.Optimization();

                sw.Stop();

                string costTime = sw.Elapsed.TotalMilliseconds.ToString();
                avgCostTime += System.Convert.ToDouble(costTime);

                List<string> record = TO.GetRecord_GA();
                string result = record[record.Count - 1];
                results.Add(result);
                /*foreach (string re in record)
                {
                    this.dataGridView1.Rows[this.dataGridView1.Rows.Add()].Cells[0].Value = re;
                }*/
                int row = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[row].Cells[0].Value = result;
                this.dataGridView1.Rows[row].Cells[1].Value = costTime;
            }

            avgCostTime = Math.Round(avgCostTime /= times, 0, MidpointRounding.AwayFromZero);
            int row2 = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[row2].Cells[0].Value = "Avg";
            this.dataGridView1.Rows[row2].Cells[1].Value = avgCostTime;

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void OptimizationTest_Load(object sender, EventArgs e)
        {
            testPara.populationSize = Simulator.AIManager.GA_Parameters.populationSize;
            testPara.generationLimit = Simulator.AIManager.GA_Parameters.generationLimit;
            testPara.crossoverProbability = Simulator.AIManager.GA_Parameters.crossoverProbability;
            testPara.mutationProbability = Simulator.AIManager.GA_Parameters.mutationProbability;

            testPara.Weight_IAWR = Simulator.AIManager.GA_Parameters.Weight_IAWR;
            testPara.Weight_TDF = Simulator.AIManager.GA_Parameters.Weight_TDF;
            testPara.Weight_CLF = Simulator.AIManager.GA_Parameters.Weight_CLF;

            numericUpDown_population.Value = Simulator.AIManager.GA_Parameters.populationSize;
            numericUpDown_generation.Value = Simulator.AIManager.GA_Parameters.generationLimit;
            numericUpDown_crossover.Value = (decimal)Simulator.AIManager.GA_Parameters.crossoverProbability;
            numericUpDown_mutation.Value = (decimal)Simulator.AIManager.GA_Parameters.mutationProbability;

            numericUpDown_IAWRW.Value = (decimal)Simulator.AIManager.GA_Parameters.Weight_IAWR;
            numericUpDown_TDFW.Value = (decimal)Simulator.AIManager.GA_Parameters.Weight_TDF;
            numericUpDown_CLFW.Value = (decimal)Simulator.AIManager.GA_Parameters.Weight_CLF;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            int population = (int)numericUpDown_population.Value;
            int generation = (int)numericUpDown_generation.Value;
            double crossover = (double)numericUpDown_crossover.Value;
            double mutation = (double)numericUpDown_mutation.Value;

            double IAWRW = (double)numericUpDown_IAWRW.Value;
            double TDFW = (double)numericUpDown_TDFW.Value;
            double CLFW = (double)numericUpDown_CLFW.Value;

            Simulator.AIManager.GA_Parameters.Config_GAParameter(population, generation, crossover, mutation);
            Simulator.AIManager.GA_Parameters.Config_FitnessWeight(IAWRW, TDFW, CLFW);
        }
    }
}
