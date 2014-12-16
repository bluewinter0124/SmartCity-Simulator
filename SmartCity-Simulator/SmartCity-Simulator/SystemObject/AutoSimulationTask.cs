using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCitySimulator.SystemObject
{
    public class AutoSimulationTask
    {
        public string simulationFilePath;
        public string simulationName;
        public int startTime = 0;
        public int endTime = 0;
        public int repeatTimes = 0;
        public Boolean autoSave_TrafficRecord = false;
        public Boolean autoSave_OptimizationRecord = false;

        public AutoSimulationTask(string simulationFilePath,string simulationName,int startTime_Second,int endTime_Second,int repeatTimes,Boolean saveTrafficRecord,Boolean saveOptimizationRecord)
        {
            this.simulationFilePath = simulationFilePath;
            this.simulationName = simulationName;
            this.startTime = startTime_Second;
            this.endTime = endTime_Second;
            this.repeatTimes = repeatTimes;
            this.autoSave_TrafficRecord = saveTrafficRecord;
            this.autoSave_OptimizationRecord = saveOptimizationRecord;
        }

        public string ToString()
        {
            return simulationName;
        }
    }
}
