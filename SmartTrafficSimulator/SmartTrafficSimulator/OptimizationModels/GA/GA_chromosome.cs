using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.OptimizationModels.GA
{
    class GA_chromosome
    {
        Dictionary<int,int> greenTime = new Dictionary<int,int>();
        List<RoadInfo> roadInfos;

        double fitness = -1;
        double Weight_IAWR = 0;
        double Weight_TDF = 0;
        double Weight_CLF = 0;

        int phases = 0;
        int maxGreen = 0;
        int minGreen = 0;

        //RT
        Boolean reservationTimeEnable = false;
        Dictionary<int, int> reservationTime = new Dictionary<int, int>();
        public GA_chromosome(int phases, int minGreen, int maxGreen, List<RoadInfo> roadInfos,Boolean reservationTimeEnable)
        {
            this.phases = phases;
            this.maxGreen = maxGreen;
            this.minGreen = minGreen;

            this.reservationTimeEnable = reservationTimeEnable;
            this.roadInfos = roadInfos;

            //Set rst of each phase
            if(reservationTimeEnable)
            {
                foreach (RoadInfo ri in roadInfos)
                {
                    int RT = ri.GetReservationTime();
                    if (reservationTime.ContainsKey(ri.phaseNo))
                    {
                        if (reservationTime[ri.phaseNo] < RT)
                        {
                            reservationTime[ri.phaseNo] = RT;
                        }
                    }
                    else
                    {
                        reservationTime.Add(ri.phaseNo, RT);
                    }
                }
            }
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            //Set rst of each phase end

            //Chromosome generate
            int green = minGreen; //default
            for (int phaseNo = 0; phaseNo < phases; phaseNo++)
            {
                if (reservationTimeEnable)
                {
                    int RT = reservationTime[phaseNo];
                    if (RT <= minGreen)
                    {
                        green = rand.Next(maxGreen - minGreen) + 1 + minGreen;
                    }
                    else if (RT > minGreen && RT < maxGreen)
                    {
                        green = rand.Next(maxGreen - RT) + 1 + RT;
                    }
                    else if (RT >= maxGreen)
                    {
                        green = maxGreen;
                    }
                }
                else
                {
                    green = rand.Next(maxGreen - minGreen + 1) + minGreen;
                }
                greenTime.Add(phaseNo, green);
            }
            //Chromosome generate end
        }

        public void SetFitnessWeight(double IAWR,double TDF,double CLF)
        {
            this.Weight_IAWR = IAWR;
            this.Weight_TDF = TDF;
            this.Weight_CLF = CLF;
            CalculateFitness();
        }

        public void CalculateFitness()
        {
            double totalVehicles_min = 0;
            double avgVehicle_min = 0;
            foreach (RoadInfo ri in roadInfos)
            {
                totalVehicles_min += ri.avgArrivalRate_min;
            }

            double IAWR = 0;

            foreach (RoadInfo ri in roadInfos)
            {
                int phaseNo = ri.phaseNo;
                double weight = ri.avgArrivalRate_min / totalVehicles_min;
                IAWR += (weight * ri.GetEstimatedWaitingRate(GetGreen(phaseNo), GetRed(phaseNo)));
                avgVehicle_min += (weight * ri.avgArrivalRate_min);
            }


            double greenTimeSum = 0;
            foreach (int time in greenTime.Values)
            {
                greenTimeSum += time;
            }

            double greenTimeMean = greenTimeSum / phases;
            
            double RMSD = 0;
            foreach (double time in greenTime.Values)
            {
                RMSD += Math.Pow(greenTimeMean - time, 2);
            }
            RMSD /= phases;
            RMSD = Math.Sqrt(RMSD);

            double timeDiffFactor = RMSD / (maxGreen - minGreen);

            double cycleLengthFactor = (greenTimeSum - (minGreen * phases)) / ((maxGreen - minGreen) * phases);

            fitness = (IAWR * Weight_IAWR) + (timeDiffFactor * Weight_TDF) + (cycleLengthFactor * Weight_CLF);

            fitness = Math.Round(fitness, 5, MidpointRounding.AwayFromZero);
        }

        public int ChromosomeLength()
        {
            return greenTime.Count;
        }

        public void SetGreen(int phase,int green)
        {
            greenTime[phase] = green;
            CalculateFitness();
        }

        public int GetGreen(int phase)
        {
            return greenTime[phase];
        }

        public int GetRed(int phase)
        {
            int totalGreen = 0;
            foreach (int g in greenTime.Values.ToArray<int>())
            {
                totalGreen += g;
            }
            return totalGreen - greenTime[phase];
        }

        public double GetFitness()
        {
            if(fitness == -1)
                CalculateFitness();

            return fitness;
        }

        public string PrintChromosome()
        {
            string chrom_string = "";
            foreach (int green in greenTime.Values.ToArray<int>())
            {
                chrom_string += (green + " ");
            }
            return chrom_string;
        }

        public Dictionary<int, int> GetAllGreenTime()
        {
            return greenTime;
        }
    }
}
