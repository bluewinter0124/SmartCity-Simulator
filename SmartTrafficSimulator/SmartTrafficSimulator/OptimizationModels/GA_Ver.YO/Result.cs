using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.OptimizationModels.GA_Yo
{
    class Result
    {
        public int final_ans;

        private int id;
        private int vector;
        private int self_id, right_id, left_id;

        public void RCmain(TSC_GA GTopt)
        {
            id = GTopt.id;
            vector = GTopt.vector;
            self_id = GTopt.self_id;
            right_id = GTopt.right_id;
            left_id = GTopt.left_id;

            calculate(GTopt);

            return;
        }

        public void calculate(TSC_GA GTopt)
        {
            /*if(right_id!=0&&MapIni.reff[vector,right_id-1]==0)
            {
                MapIni.reff[vector,right_id-1]=GTopt.result[1];
            }
            else if(right_id!=0)
            {
                MapIni.reff[vector,right_id-1]=(MapIni.reff[vector,right_id-1]+GTopt.result[1])/2;
            }

            if(left_id!=0&&MapIni.reff[vector,left_id-1]==0)
            {
                MapIni.reff[vector,left_id-1]=GTopt.result[2];
            }
            else if(left_id!=0)
            {
                MapIni.reff[vector,left_id-1]=(MapIni.reff[vector,left_id-1]+GTopt.result[2])/2;
            }



            if(MapIni.reff[vector,self_id-1]==0)
            {
                final_ans = GTopt.result[0];
            }
            else
            {
                final_ans = (GTopt.result[0]*3 + MapIni.reff[vector,self_id-1])/4;
            }*/

            final_ans = GTopt.result[0];

            return;
        }

        public void rt()
        {
            return;
        }

    }
}
