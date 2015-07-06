using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.OptimizationModels.GA_Yo
{
    class SetResult
    {
        public int SetVec1, SetVec2;
        public Dictionary<int, int> SRcalculat(int PreA1, int PreA2, int result_vec1, int result_vec2)
        {
            float fraction1, fraction2;
            int total=60;
            int tempSetVec1=0, tempSetVec2=0;
            int Result1 = result_vec1;
            int Result2 = result_vec2;
            int max=45;
            int min=15;
            int cycle_time = 1;
            int offset = 10;

            //Simulator.UI.AddMessage("AI", "  Pre1:" + PreA1 + "  Pre2:" + PreA2);

            if (cycle_time == 1)
            {
                fraction1 = (float)Result1 / (Result1 + Result2);
                fraction2 = (float)Result2 / (Result1 + Result2);

                tempSetVec1 = (int)(fraction1 * total);
                tempSetVec2 = (int)(fraction2 * total);
            }
            else if(cycle_time == 0)
            {
                tempSetVec1 = Result1;
                tempSetVec2 = Result2;
            }
            //Console.WriteLine(tempSetVec1 + " " + tempSetVec2);

            if (tempSetVec1 > PreA1 + offset)
                SetVec1 = PreA1 + offset;
            else if (tempSetVec1 < PreA1 - offset)
                SetVec1 = PreA1 - offset;
            else
                SetVec1=tempSetVec1;

            if (tempSetVec2 > PreA2 + offset)
                SetVec2 = PreA2 + offset;
            else if (tempSetVec2 < PreA1 - offset)
                SetVec2 = PreA2 - offset;
            else
                SetVec2=tempSetVec2;


            if(SetVec1>max)
                SetVec1=max;
            else if(SetVec1<min)
                SetVec1=min;

            if(SetVec2>max)
                SetVec2=max;
            else if(SetVec2<min)
                SetVec2=min;


            Dictionary<int, int> result = new Dictionary<int, int>();
            result.Add(0, SetVec1);
            result.Add(1, SetVec2);

            return result;
        }
    }
}
