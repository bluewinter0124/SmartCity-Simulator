using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCitySimulator.SystemUnit;

namespace SmartCitySimulator
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
            SimulatorConfiguration.UI = new MainUI();
            SimulatorConfiguration.prototypeConnector = new PrototypeManager();
            SimulatorConfiguration.prototypeConnector.start();
            Application.Run(SimulatorConfiguration.UI);

          
        }
    }
}
