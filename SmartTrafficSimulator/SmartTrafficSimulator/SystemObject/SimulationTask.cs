using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SmartTrafficSimulator.SystemObject
{
    public class SimulationTask
    {
        public string simulationFilePath;
        public string simulationFileName;
        public int startTime = 0;
        public int endTime = 0;
        public int repeatTimes = 0;
        public Boolean Save_TrafficRecord = false;
        public Boolean Save_OptimizationRecord = false;

        public SimulationTask(string simulationFilePath,int startTime_Second,int endTime_Second,int repeatTimes,Boolean saveTrafficRecord,Boolean saveOptimizationRecord)
        {
            this.simulationFilePath = simulationFilePath;
            
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(simulationFilePath);

            this.simulationFileName = XmlDoc.SelectSingleNode("Simulation/SimulationName").InnerText;

            this.startTime = startTime_Second;
            this.endTime = endTime_Second;
            this.repeatTimes = repeatTimes;
            this.Save_TrafficRecord = saveTrafficRecord;
            this.Save_OptimizationRecord = saveOptimizationRecord;
        }

        public string GetSimulationName()
        {
            return simulationFileName;
        }

    }
}
