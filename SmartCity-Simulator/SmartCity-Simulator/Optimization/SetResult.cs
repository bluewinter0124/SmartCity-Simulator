using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace signalAI
{
    class SetResult
    {
        public int SetVec1, SetVec2;
        public void SRcalculat(int PreA1, int PreA2, Map_initial MapIni, TSC_GA GTopt1, TSC_GA GTopt2, Result ResultCal1, Result ResultCal2)
        {
            float fraction1, fraction2;
            //int total=PreA1+PreA2;
            int total = 60;
            int tempSetVec1, tempSetVec2;
            int Result1 = ResultCal1.final_ans;
            int Result2 = ResultCal2.final_ans;
            int max=GTopt1.GTmax;
            int min=GTopt1.GTmin;

            fraction1=(float)Result1/(Result1+Result2);
            fraction2=(float)Result2/(Result1+Result2);

            tempSetVec1=(int)(fraction1*total);
            tempSetVec2=(int)(fraction2*total);

            //Console.WriteLine(tempSetVec1 + " " + tempSetVec2);

            if(tempSetVec1>PreA1+10)
                SetVec1=PreA1+10;
            else if(tempSetVec1<PreA1-10)
                SetVec1=PreA1-10;
            else
                SetVec1=tempSetVec1;

            if(tempSetVec2>PreA2+10)
                SetVec2=PreA2+10;
            else if(tempSetVec2<PreA1-10)
                SetVec2=PreA2-10;
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

            MapIni.past[0,GTopt1.self_id] = SetVec1;
            MapIni.past[1,GTopt1.self_id] = SetVec2;

            return;
        }

    }
}
