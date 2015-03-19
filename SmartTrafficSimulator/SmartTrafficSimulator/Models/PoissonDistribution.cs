using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SmartTrafficSimulator.Models
{
    class PoissonDistribution
    {
        double lambda;

        public PoissonDistribution(double lambda)
        {
        this.lambda = lambda;
        }

        public void SetLambda(double lambda)
        {
            this.lambda = lambda;
        }

        public decimal ProbabilityMassFunction(int k)
        {
            //(l^k / k! ) * e^-l
            //l = lamda
            int kFactorial = Factorial(k);
            double numerator = Math.Pow(Math.E, - lambda) * Math.Pow(lambda, (double)k);

            decimal p = (decimal)numerator / kFactorial;
            return p;
        }

        public decimal CummulitiveDistributionFunction(int k)
        {
            double e = Math.Pow(Math.E, -lambda);
            int i = 0;
            double sum = 0.0;
            while (i <= k)
            {
                double n = Math.Pow(lambda, i) / Factorial(i);
                sum += n;
                i++;
            }
            decimal cdf = (decimal)e * (decimal)sum;
            return cdf;
        }

        private int Factorial(int n)
        {
            int count = n;
            int factorial = 1;
            while (count >= 2)
            {
                factorial *= count;
                count --;
            }
            return factorial;
        }
    }
}
