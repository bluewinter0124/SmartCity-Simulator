using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartTrafficSimulator.SystemObject
{
    public class SimulationTask
    {
        public string simulationFilePath;
        public string simulationName;
        public int startTime = 0;
        public int endTime = 0;
        public int repeatTimes = 0;
        public Boolean Save_TrafficRecord = false;
        public Boolean Save_OptimizationRecord = false;

        public SimulationTask(string simulationFilePath,string simulationName,int startTime_Second,int endTime_Second,int repeatTimes,Boolean saveTrafficRecord,Boolean saveOptimizationRecord)
        {
            this.simulationFilePath = simulationFilePath;
            this.simulationName = simulationName;
            this.startTime = startTime_Second;
            this.endTime = endTime_Second;
            this.repeatTimes = repeatTimes;
            this.Save_TrafficRecord = saveTrafficRecord;
            this.Save_OptimizationRecord = saveOptimizationRecord;
        }

        public string GetName()
        {
            return simulationName;
        }
    }
}
