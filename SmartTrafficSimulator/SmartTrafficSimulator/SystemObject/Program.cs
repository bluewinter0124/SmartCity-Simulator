using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartTrafficSimulator.SystemObject;

namespace SmartTrafficSimulator
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Simulator.UI = new MainUI();
            Application.Run(Simulator.UI);
        }
    }
}
