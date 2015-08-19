using SmartTrafficSimulator.SystemManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTrafficSimulator.OptimizationModels.GA
{
    class Optimization_GA
    {
        // GA constrain
        int maxGreen;
        int minGreen;
        int phases;
        Boolean cycleLengthFixed;
        List<RoadInfo> roadInfos;

        Boolean reservationTimeEnable = false;
        
        // GA parameter
        GA_Parameters GA_Para;
        int populationSize;
        int generationLimit;
        double reproductionRate;
        int numOfReproductionSeletedChro = 5;
        double crossoverProbability;
        double mutationProbability;

        double Weight_IAWR ;
        double Weight_TDF;
        double Weight_CLF;

        //Run time variable
        List<GA_chromosome> chromPool = new List<GA_chromosome>();
        int currentGeneration = 0;
        GA_chromosome bestChromosome = null;

        //Other
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        List<string> optimizationRecords;


        public void SetGAParameter(GA_Parameters para)
        {
            this.GA_Para = para;
        }

        public void SetGAParametersByAIManager()
        {
            if (GA_Para == null)
            {
                GA_Para = Simulator.AIManager.GA_Parameters;
            }

            this.populationSize = GA_Para.populationSize;
            this.generationLimit = GA_Para.generationLimit;
            this.crossoverProbability = GA_Para.crossoverProbability;
            this.mutationProbability = GA_Para.mutationProbability;
            this.Weight_IAWR = GA_Para.Weight_IAWR;
            this.Weight_TDF = GA_Para.Weight_TDF;
            this.Weight_CLF = GA_Para.Weight_CLF;
        }

        public List<string> GetOptimizationRecoeds()
        {
            return optimizationRecords;
        }

        public Dictionary<int,int> Optimize(Boolean cycleLengthFixed, int phases, int minGreen, int maxGreen, List<RoadInfo> roadInfos)
        {
            SetGAParametersByAIManager();

            currentGeneration = 0;
            bestChromosome = null;
            optimizationRecords = new List<string>();

            this.cycleLengthFixed = cycleLengthFixed;
            this.phases = phases;
            this.maxGreen = maxGreen;
            this.minGreen = minGreen;
            this.roadInfos = roadInfos;
            
            //GA process
            InitializePool();

            do{
                Reproduction_RestoreSeletedChro();
                //Reproduction();

                Crossover();

                Mutation();

                GenerateNewChromosome();

                EvaluateFitness();

                currentGeneration++;
            }while (currentGeneration < generationLimit);

            return bestChromosome.GetAllGreenTime();
        }

        public void PrintChromosomePool()
        {
            foreach (GA_chromosome ch in chromPool)
            {
                System.Console.WriteLine(ch.PrintChromosome() + "     " + ch.GetFitness());
            }
            System.Console.WriteLine();
        }

        public void InitializePool()
        {
            chromPool.Clear();
            for (int i = 0; i < populationSize; i++)
            {
                GA_chromosome newChrom = new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable);
                newChrom.SetFitnessWeight(Weight_IAWR, Weight_TDF, Weight_CLF);
                chromPool.Add(newChrom);
            }
        }

        public void Reproduction_RemoveSeletedChro()
        {
            List<GA_chromosome> newChromPool = new List<GA_chromosome>();
            int newPopulation = System.Convert.ToInt16(populationSize * reproductionRate);

            for (int i = 0; i < newPopulation; i++)
            {
                GA_chromosome ch = TournamentSelection(numOfReproductionSeletedChro);
                newChromPool.Add(ch);
                chromPool.Remove(ch);
            }

            chromPool = newChromPool;
        }

        public void Reproduction_RestoreSeletedChro()
        {
            List<GA_chromosome> newChromPool = new List<GA_chromosome>();

            for (int i = 0; i < populationSize; i++)
            {
                GA_chromosome ch = TournamentSelection(numOfReproductionSeletedChro);
                newChromPool.Add(ch);
            }

            chromPool = newChromPool;
        }

        public GA_chromosome TournamentSelection(int compQuantity)
        {
            GA_chromosome bestFitnessChrom = null;

            List<GA_chromosome> compChroms = new List<GA_chromosome>();

            rand = new Random(Guid.NewGuid().GetHashCode());
            int startIndex = rand.Next(chromPool.Count);
            int interval = rand.Next(chromPool.Count / compQuantity);
            if (interval < 1)
                interval = 1;

            //Random select 5 chromosomes to tournament
            for (int i = 0; i < compQuantity; i++)
            {
                compChroms.Add(chromPool[(startIndex + i * interval) % chromPool.Count]); 
            }

            bestFitnessChrom = compChroms[0];

            //Find best chromosome
            foreach (GA_chromosome chrom in compChroms)
            {
                if (chrom.GetFitness() < bestFitnessChrom.GetFitness())
                {
                    bestFitnessChrom = chrom;
                }
            }

            return bestFitnessChrom;
        }

        public GA_chromosome RouletteWheelSelection()
        {
            GA_chromosome bestFitnessChrom;

            return bestFitnessChrom = null;
        }

        public void Crossover()
        {
            List<GA_chromosome> newChromPool = new List<GA_chromosome>();

            while (chromPool.Count >= 2)
            {
                GA_chromosome PA = chromPool[rand.Next(chromPool.Count)];
                chromPool.Remove(PA);

                GA_chromosome PB = chromPool[rand.Next(chromPool.Count)];
                chromPool.Remove(PB);

                //Decide crossover
                if (rand.Next(100) + 1 <= crossoverProbability * 100)
                {
                    GA_chromosome CA = new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable);
                    GA_chromosome CB = new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable);
                    CA.SetFitnessWeight(Weight_IAWR, Weight_TDF, Weight_CLF);
                    CB.SetFitnessWeight(Weight_IAWR, Weight_TDF, Weight_CLF);

                    //Decide crossover point
                    int crossoverPoint = 0;
                    if (phases > 2)
                    {
                        crossoverPoint = rand.Next(phases - 1);
                    }

                    //Crossover start
                    for (int i = 0; i < phases; i++)
                    {
                        if (i <= crossoverPoint)
                        {
                            CA.SetGreen(i, PA.GetGreen(i));
                            CB.SetGreen(i, PB.GetGreen(i));
                        }
                        else
                        {
                            CA.SetGreen(i, PB.GetGreen(i));
                            CB.SetGreen(i, PA.GetGreen(i));
                        }
                    }

                    //Put child chromosome to new pool
                    newChromPool.Add(CA);
                    newChromPool.Add(CB);
                }
                else
                {
                    //Put parent chromosome to new pool
                    newChromPool.Add(PA);
                    newChromPool.Add(PB);
                }
            }

            chromPool = newChromPool;
        }

        public void Mutation()
        {
            foreach (GA_chromosome chro in chromPool)
            {
                //Decide mutation
                if (rand.Next(100) + 1 <= mutationProbability * 100)
                {
                    //Randomly add +-10 to each green time
                    for (int i = 0; i < phases; i++)
                    {
                        int addTime = rand.Next(21) - 10;
                        int newGreen = chro.GetGreen(i) + addTime;

                        if (newGreen > maxGreen)
                            newGreen = maxGreen;
                        else if (newGreen < minGreen)
                            newGreen = minGreen;
                        
                        chro.SetGreen(i, newGreen);
                    }
                }
            }
        }

        public void EvaluateFitness()
        {
            GA_chromosome bestChrom_currentPool = chromPool[0];

            //Find best chromosome of this generation
            foreach (GA_chromosome chrom in chromPool)
            {
                if (chrom.GetFitness() < bestChrom_currentPool.GetFitness())
                {
                    bestChrom_currentPool = chrom;
                }
            }

            //Compare the best chromosome of this generation and best chromosome of all generation, 
            //if this is first generation, set the best chromosome of this generation as the best chromesome of all generation.
            if (bestChromosome == null || bestChrom_currentPool.GetFitness() < bestChromosome.GetFitness())
            {
                if (bestChromosome == null)
                { 
                    bestChromosome = new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable);
                    bestChromosome.SetFitnessWeight(Weight_IAWR, Weight_TDF, Weight_CLF);
                }

                for (int p = 0; p < phases; p++)
                {
                    bestChromosome.SetGreen(p, bestChrom_currentPool.GetGreen(p));
                }

                optimizationRecords.Add("Generation :" + currentGeneration + "  Chromosome : " + bestChromosome.PrintChromosome() + "  fitness : " + bestChromosome.GetFitness());
            }
        }

        public void GenerateNewChromosome()
        {
            int generatedQuantity = populationSize - chromPool.Count;

            //Generate lack of chromosome, until satisfied the population size.
            for (int i = 0; i < generatedQuantity; i++)
            {
                GA_chromosome newChrom = new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable);
                newChrom.SetFitnessWeight(Weight_IAWR, Weight_TDF, Weight_CLF);
                chromPool.Add(newChrom);
            }
        }

    }
}