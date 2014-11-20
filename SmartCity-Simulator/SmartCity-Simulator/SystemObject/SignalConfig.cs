using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemObject
{
    public class SignalConfig
    {
        public int Green;
        public int Yellow;
        public int Red = 0;
        public int TempRed = 0;


    public SignalConfig(int green,int yellow)
    {
        this.Green = green;
        this.Yellow = yellow;
    }

    public int GetCycleTime()
    {
        return Green + Yellow + Red;
    }

    public void UsedTempRed()
    {
        TempRed = 0;
    }

    }
}
