using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.OptimizationModels.GA_Yo
{
    class Map_initial
    {
        public int [,,]neighbor = new int[2,9,3];
        public int [,]reff = new int[2,9];
        public int [,]past = new int[2,9];

		public void MImain()
        {
	        initial();
	        nbinitial();
	        return;
        }

        public void initial()
        {
	        int i,j;

            for(i=0;i<2;i++)
            {
                for(j=0;j<9;j++)
                {
                    reff[i,j]=0;
                    past[i,j]=0;
                }
            }

            return;
        }

        public void nbinitial()
        {
            int i, j, k;

            int[,,] temp = new int[2,9,3]{{{1,2,0},{2,3,1},{3,0,2},{4,5,0},{5,6,4},{6,0,5},{7,8,0},{8,9,7},{9,0,8}},
                               {{1,5,0},{2,6,0},{3,0,0},{4,7,0},{5,8,1},{6,9,2},{7,0,4},{8,0,5},{9,0,6}}};

            for(i=0;i<2;i++)
            {
                for(j=0;j<9;j++)
                {
                    for(k=0;k<3;k++)
                    {
                        neighbor[i,j,k]=temp[i,j,k];

                    }
                }
            }

            return;
        }
    }
}
