using SmartTrafficSimulator;
using SmartTrafficSimulator.OptimizationModels.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.OptimizationModels.GA;

namespace SmartTrafficSimulator.SystemManagers
{
    class AIManager
    {
        public Boolean trafficOptimazation = false;

        int optimizationMethodID = 0;
        string optimizationName = "Genetic Algorithm";
        public Dictionary<string, int> optimizationMethodList = new Dictionary<string, int>();
        public Dictionary<string, Boolean> testModeEnable = new Dictionary<string, Boolean>();

        public GA_Parameters GA_Parameters = new GA_Parameters();

        Boolean adaptiveAdjustment = true;
        Boolean AA_threshold = true;
        Boolean AA_interval = true;

        Boolean trafficVolumePredection = false;

        public AIManager()
        {
            optimizationMethodList.Add("Genetic Algorithm", 0);
            testModeEnable.Add("Genetic Algorithm", true);

            optimizationMethodList.Add("Game Theory", 1);
            testModeEnable.Add("Game Theory", false);

            optimizationMethodList.Add("Genetic Algorithm Ver.YO", 2);
            testModeEnable.Add("Genetic Algorithm Ver.YO", false);
        }

        public void AIOn()
        {
            trafficOptimazation = true;
            Simulator.UI.RefreshAIStatus();
            Simulator.UI.AddMessage("AI", "On");
            Simulator.UI.AddMessage("AI", "Current optimization method : " + optimizationName);
        }

        public void AIOff()
        {
            trafficOptimazation = false;
            Simulator.UI.RefreshAIStatus();
            Simulator.UI.AddMessage("AI", "Off");
        }


        public void SetOptimizationMethod(string optName)
        {
            optimizationName = optName;
            optimizationMethodID = optimizationMethodList[optName];
            //Simulator.UI.AddMessage("AI", "Current optimization method : " + optimizationName);
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

        public void SetAdaptiveAdjustment(Boolean isEnable)
        {
            this.adaptiveAdjustment = isEnable;
        }

        public Boolean GetEnableAdaptiveAdjustment()
        {
            return adaptiveAdjustment;    
        }

        public void SetThresholdAdjustment(Boolean isEnable)
        {
            this.AA_threshold = isEnable;
        }

        public void SetIntervalAdjustment(Boolean isEnable)
        {
            this.AA_interval = isEnable;
        }

        public Boolean GetEnableThresholdAdjustment()
        {
            return AA_threshold;
        }

        public Boolean GetEnableIntervalAdjustment()
        {
            return AA_interval;
        }

        public void SetTrafficVolumePredection(Boolean isEnable)
        {
            this.trafficVolumePredection = isEnable;
        }

        public Boolean GetEnableTrafficVolumePredection()
        {
            return trafficVolumePredection;
        }
    }
}
