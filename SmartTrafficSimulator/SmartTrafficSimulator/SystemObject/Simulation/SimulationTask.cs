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
        public Boolean saveTrafficRecord = false;
        public Boolean saveOptimizationRecord = false;
        public Boolean saveIntersectionStatus = false;
        public Boolean saveVehicleData = false;


        public SimulationTask(string simulationFilePath,int startTime_Second,int endTime_Second,int repeatTimes,Boolean saveTrafficRecord,Boolean saveOptimizationRecord,Boolean saveIntersectionStatus,Boolean saveVehicleData)
        {
            this.simulationFilePath = simulationFilePath;

            if (!simulationFilePath.Equals(""))
            {
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(simulationFilePath);

                this.simulationFileName = XmlDoc.SelectSingleNode("Simulation/SimulationName").InnerText;
            }
            else
            {
                this.simulationFileName = "New";
            }
            this.startTime = startTime_Second;
            this.endTime = endTime_Second;
            this.repeatTimes = repeatTimes;
            this.saveTrafficRecord = saveTrafficRecord;
            this.saveOptimizationRecord = saveOptimizationRecord;
            this.saveIntersectionStatus = saveIntersectionStatus;
            this.saveVehicleData = saveVehicleData;
        }

        public string GetSimulationName()
        {
            return simulationFileName;
        }

    }
}
