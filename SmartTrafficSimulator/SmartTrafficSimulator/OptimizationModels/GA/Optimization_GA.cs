using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalOptimization_GA
{
    class Optimization_GA
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());

        // GA constrain
        int maxGreen;
        int minGreen;
        int phases;
        Boolean cycleLengthFixed;
        List<RoadInfo> roadInfos;

        Boolean reservationTimeEnable = false;
        // GA parameter

        List<GA_chromosome> chromPool = new List<GA_chromosome>();
        int populationSize = 50;
        int generationLimit = 50;
        double reproductionRate = 0.7;
        double crossoverProbability = 0.7;
        double mutationProbability = 0.1;

        int currentGeneration = 0;
        GA_chromosome bestChromosome = null;
        List<string> fitnessRecord;
        // GA parameter

        public Dictionary<int,int> Optimize(Boolean cycleLengthFixed, int phases, int minGreen, int maxGreen, List<RoadInfo> roadInfos)
        {
            currentGeneration = 0;
            bestChromosome = null;
            fitnessRecord = new List<string>();

            this.cycleLengthFixed = cycleLengthFixed;
            this.phases = phases;
            this.maxGreen = maxGreen;
            this.minGreen = minGreen;
            this.roadInfos = roadInfos;
            
            //GA process
            InitializePool();
            //PrintChromosomePool();

            do{
                Reproduction_Repeat();
                //Reproduction();
                //PrintChromosomePool();

                Crossover();
                //PrintChromosomePool();

                Mutation();

                GenerateNewChromosome();
                //PrintChromosomePool();

                EvaluateFitness();

                currentGeneration++;
            }while (currentGeneration < generationLimit);

            /*
            foreach (string s in fitnessRecord)
            {
                System.Console.WriteLine(s);
            }
            */

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
                chromPool.Add(new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable));
            }

            //PrintChromosomePool();
        }

        public void Reproduction()
        {
            List<GA_chromosome> newChromPool = new List<GA_chromosome>();
            int newPopulation = System.Convert.ToInt16(populationSize * reproductionRate);

            for (int i = 0; i < newPopulation; i++)
            {
                GA_chromosome ch = TournamentSelection(5);
                newChromPool.Add(ch);
                chromPool.Remove(ch);
            }

            /*foreach (GA_chromosome ch in newChromPool)
            {
                System.Console.WriteLine(ch.PrintChromosome() + "     " + ch.GetFitness());
            }*/

            chromPool = newChromPool;
        }

        public void Reproduction_Repeat()
        {
            List<GA_chromosome> newChromPool = new List<GA_chromosome>();

            for (int i = 0; i < populationSize; i++)
            {
                GA_chromosome ch = TournamentSelection(5);
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

            for (int i = 0; i < compQuantity; i++)
            {
                compChroms.Add(chromPool[(startIndex + i * interval) % chromPool.Count]); 
            }

            bestFitnessChrom = compChroms[0];

            foreach (GA_chromosome chrom in compChroms)
            {
                if (chrom.GetFitness() < bestFitnessChrom.GetFitness())
                {
                    bestFitnessChrom = chrom;
                }
            }

            /*
            foreach (GA_chromosome ch in compChroms)
            {
                System.Console.WriteLine("C : " + ch.PrintChromosome() + "     " + ch.GetFitness());
            }
            System.Console.WriteLine("B : " + bestFitnessChrom.PrintChromosome() + "     " + bestFitnessChrom.GetFitness());
            System.Console.WriteLine();
            */

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

                if (rand.Next(100) + 1 <= crossoverProbability * 100)
                {
                    GA_chromosome CA = new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable);
                    GA_chromosome CB = new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable);

                    //decide crossover point
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
                    /*System.Console.WriteLine("A : " + chA.PrintChromosome());
                    System.Console.WriteLine("B : " + chB.PrintChromosome());
                    System.Console.WriteLine("C : " + chC.PrintChromosome());
                    System.Console.WriteLine("D : " + chD.PrintChromosome());*/

                    newChromPool.Add(CA);
                    newChromPool.Add(CB);
                }
                else
                {
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
                if (rand.Next(100) + 1 <= mutationProbability * 100)
                {
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

            foreach (GA_chromosome chrom in chromPool)
            {
                if (chrom.GetFitness() < bestChrom_currentPool.GetFitness())
                {
                    bestChrom_currentPool = chrom;
                }
            }

            if (bestChromosome == null || bestChrom_currentPool.GetFitness() < bestChromosome.GetFitness())
            {
                if (bestChromosome == null)
                    bestChromosome = new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable);

                for (int p = 0; p < phases; p++)
                {
                    bestChromosome.SetGreen(p, bestChrom_currentPool.GetGreen(p));
                }

                fitnessRecord.Add("Generation :" + currentGeneration + "  Chromosome : " + bestChromosome.PrintChromosome() + "  fitness : " + bestChromosome.GetFitness());
            }

            System.Console.WriteLine("Generation :" + currentGeneration);
            System.Console.WriteLine("Best Chromosome in pool : " + bestChrom_currentPool.PrintChromosome() + "     " + bestChrom_currentPool.GetFitness());
            System.Console.WriteLine("Best Chromosome ever : " + bestChromosome.PrintChromosome() + "     " + bestChromosome.GetFitness());
            System.Console.WriteLine();
        }

        public void GenerateNewChromosome()
        {
            int generatedQuantity = populationSize - chromPool.Count;

            for (int i = 0; i < generatedQuantity; i++)
            {
                chromPool.Add(new GA_chromosome(phases, minGreen, maxGreen, roadInfos, reservationTimeEnable));
            }
        }

    }
}