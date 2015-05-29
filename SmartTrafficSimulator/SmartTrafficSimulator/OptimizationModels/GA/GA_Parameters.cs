using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.OptimizationModels.GA
{
    class GA_Parameters
    {
        public int populationSize = 50;
        public int generationLimit = 50;
        public double reproductionRate = 0.7;
        public double crossoverProbability = 0.7;
        public double mutationProbability = 0.1;

        public double Weight_IAWR = 10;
        public double Weight_TDF = 1;
        public double Weight_CLF = 0;

        public void Config_GAParameter(int popuSize, int generation, double crossover, double mutation)
        {
            this.populationSize = popuSize;
            this.generationLimit = generation;
            this.crossoverProbability = crossover;
            this.mutationProbability = mutation;
        }

        public void Config_FitnessWeight(double IAWR, double TDF, double CLF)
        {
            this.Weight_IAWR = IAWR;
            this.Weight_TDF = TDF;
            this.Weight_CLF = CLF;
        }
    }
}
