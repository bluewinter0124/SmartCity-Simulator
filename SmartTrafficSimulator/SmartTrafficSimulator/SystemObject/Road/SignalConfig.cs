using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.SystemObject
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

    public string ToString_Full()
    {
        string temp = "";
        temp += "G:" + Green + " ";
        temp += "Y:" + Yellow + " ";
        temp += "R:" + Red + " ";
        temp += "TR:" + TempRed + " ";
        return temp;
    }
    public string ToString_Short()
    {
        string temp = "";
        temp += "G:" + Green + " ";
        temp += "Y:" + Yellow + " ";

        return temp;
    }


    }
}
