using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.OptimizationModels.OptimizationAdjustment
{
    class AdaptiveAdjustment
    {
        public double ThresholdAdjustment(double currentIAWR,double currentThreshold,int selfStability)
        {
            double maxIncreaseRate = 0.1;
            double newIAWRThreshold;

            if (selfStability == 0) //Optimize
            {
                newIAWRThreshold = currentIAWR * (1 + maxIncreaseRate);
            }
            else //No optimize
            {
                if (selfStability <= 5)
                {
                    newIAWRThreshold = (currentThreshold * (10 - selfStability) + (currentIAWR * selfStability)) / 10;
                }
                else
                {
                    newIAWRThreshold = (currentThreshold + currentIAWR) / 2;
                }
            }

            return Math.Round(newIAWRThreshold, 2, MidpointRounding.AwayFromZero);     
        }

        public int IntervalAdjustment(int minOptimizationInterval,int maxOptimizationInterval,int selfStability, double adjStability)
        {
            double curveFactor = 6;

            double newInterval = ((curveFactor + (selfStability + 1) * (adjStability + 1)) / (curveFactor + (selfStability + 1))) * minOptimizationInterval;

            return (int)Math.Round(newInterval, 0, MidpointRounding.AwayFromZero);

        }
    }
}