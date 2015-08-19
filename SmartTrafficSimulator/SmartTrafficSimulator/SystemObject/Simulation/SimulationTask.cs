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
        public string simulationName;
        
        public int simulationStartTime = 0;
        public int simulationEndTime = 0;
        
        public int taskStatus = 0; //0 = waiting , 1 = running , 2 = finished 
        public int completeTimes = 0;
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

                this.simulationName = XmlDoc.SelectSingleNode("Simulation/SimulationName").InnerText;
            }
            else
            {
                this.simulationName = "New";
            }
            this.simulationStartTime = startTime_Second;
            this.simulationEndTime = endTime_Second;
            this.repeatTimes = repeatTimes;
            this.saveTrafficRecord = saveTrafficRecord;
            this.saveOptimizationRecord = saveOptimizationRecord;
            this.saveIntersectionStatus = saveIntersectionStatus;
            this.saveVehicleData = saveVehicleData;
        }

        public string GetSimulationName()
        {
            return simulationName;
        }

        public void TaskStart()
        {
            taskStatus = 1;
        }
        public void TaskFinish()
        {
            taskStatus = 2;
        }

        public string GetTaskStatus()
        {
            string status = "";
            if (taskStatus == 0)
            {
                status += "Waiting";
            }
            else if (taskStatus == 1)
            {
                status += "Running (" + completeTimes + "/" + repeatTimes +")";
            }
            else if (taskStatus == 2)
            {
                status += "Finished (" + completeTimes + "/" + repeatTimes + ")";
            }

            return status;
        }

    }
}
