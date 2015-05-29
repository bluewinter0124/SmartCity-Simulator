using SmartTrafficSimulator;
using SmartTrafficSimulator.OptimizationModels.other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.OptimizationModels.GA;

namespace SmartTrafficSimulator.SystemManagers
{
    class AIManager
    {
        public Boolean AIOptimazation = false;

        int optimizationMethodID = 0;
        string optimizationName = "Genetic Algorithm";
        public Dictionary<string, int> optimizationMethodList = new Dictionary<string, int>();
        public Dictionary<string, Boolean> testModeEnable = new Dictionary<string, Boolean>();

        public GA_Parameters GA_Parameters = new GA_Parameters();

        Boolean adaptiveAdjustment = true;
        Boolean AA_threshold = true;
        Boolean AA_interval = true;

        public AIManager()
        {
            optimizationMethodList.Add("Genetic Algorithm", 0);
            testModeEnable.Add("Genetic Algorithm", true);

            optimizationMethodList.Add("Game Theory", 1);
            testModeEnable.Add("Game Theory", false);
        }

        public void AIOn()
        {
            AIOptimazation = true;
            Simulator.UI.RefreshAIStatus();
            Simulator.UI.AddMessage("AI", "On");
            Simulator.UI.AddMessage("AI", "Current optimization method : " + optimizationName);
        }

        public void AIOff()
        {
            AIOptimazation = false;
            Simulator.UI.RefreshAIStatus();
            Simulator.UI.AddMessage("AI", "Off");
        }


        public void SetOptimizationMethod(string optName)
        {
            optimizationName = optName;
            optimizationMethodID = optimizationMethodList[optName];
            Simulator.UI.AddMessage("AI", "Current optimization method : " + optimizationName);
        }

        public int GetoptimizationMethodID()
        {
            return optimizationMethodID;
        }

        public void Config_GA_Parameter(int popuSize, int generation, double crossover, double mutation)
        {
            GA_Parameters.Config_GAParameter(popuSize, generation, crossover, mutation);
        }

        public void Config_GA_FitnessWeight(double IAWR, double TDF, double CLF)
        {
            GA_Parameters.Config_FitnessWeight(IAWR, TDF, CLF);
        }

        public void SetAdaptiveAdjustment(Boolean enable)
        {
            this.adaptiveAdjustment = enable;
        }

        public Boolean EnableAdaptiveAdjustment()
        {
            return adaptiveAdjustment;    
        }

        public void SetThresholdAdjustment(Boolean threshold)
        {
            this.AA_threshold = threshold;
        }

        public void SetIntervalAdjustment(Boolean interval)
        {
            this.AA_interval = interval;
        }

        public Boolean EnableThresholdAdjustment()
        {
            return AA_threshold;
        }

        public Boolean EnableIntervalAdjustment()
        {
            return AA_interval;
        }

    }
}
