using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;
using SmartCitySimulator.SystemObject;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace SmartCitySimulator.SystemObject
{
    class DataManager
    {
        Dictionary<int, List<CycleRecord>> TrafficData;
        Dictionary<int, Dictionary<int,OptimizationRecord>> OptimizationData;

        public void InitializeDataManager()
        {
            TrafficData = new Dictionary<int, List<CycleRecord>>();
            OptimizationData = new Dictionary<int, Dictionary<int, OptimizationRecord>>();
        }

        public void RegisterRoad(int roadID)
        { 
            List<CycleRecord> trafficRecord = new List<CycleRecord>();
            TrafficData.Add(roadID,trafficRecord);
        }

        public void RegisterIntersection(int intersectionID)
        {
            Dictionary<int, OptimizationRecord> optimizationRecord = new Dictionary<int, OptimizationRecord>();
            OptimizationData.Add(intersectionID, optimizationRecord);
        }

        public void StoreCycleRecord(int roadID, CycleRecord cycleRecord)
        {
            TrafficData[roadID].Add(cycleRecord);
        }

        public void StoreOptimizationRecord(int intersectionID, OptimizationRecord optRecord)
        {
            int cycle = optRecord.optimizeCycle;
            OptimizationData[intersectionID].Add(cycle, optRecord);
        }

        public CycleRecord GetCycleRecord(int roadID, int cycle)
        {
            return TrafficData[roadID][cycle];
        }

        public OptimizationRecord GetOptimizationRecord(int roadID, int cycle)
        {
            if (OptimizationData[roadID].ContainsKey(cycle))
                return OptimizationData[roadID][cycle];
            else
                return null;
        }

        public List<OptimizationRecord> GetOptimizationRecords(int intersectionID, int startCycle, int endCycle)
        {
            int maxCycle = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).currentCycle;
            List<OptimizationRecord> searchResult = new List<OptimizationRecord>();

            if (startCycle > maxCycle)
                startCycle = maxCycle;

            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle > maxCycle || endCycle <= 0)
                endCycle = maxCycle;

            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                if (OptimizationData[intersectionID].ContainsKey(cycle))
                    searchResult.Add(OptimizationData[intersectionID][cycle]);
            }

            return searchResult;
        }

        public int CountTrafficRecords(int roadID)
        {
            return TrafficData[roadID].Count;
        }

        public int CountOptimizationRecords(int roadID)
        {
            return OptimizationData[roadID].Keys.Count();
        }

        public double GetArrivalRate(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;

            double arrivalRate = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                arrivalRate += TrafficData[RoadID][cycle].arrivedVehicles;
            }

            if (cycles > 0)
                arrivalRate /= cycles;

            return Math.Round(arrivalRate,2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingRate(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;

            double waittingRate = 0;
            int cycles = (endCycle - startCycle) + 1;

            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                waittingRate += TrafficData[RoadID][cycle].WaittingRate;
            }

            if (cycles > 0)
                waittingRate = ((waittingRate *100) / cycles);

            return Math.Round(waittingRate, 2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingVehicles(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;

            double averageWaittingVehicles = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                averageWaittingVehicles += TrafficData[RoadID][cycle].WaitingVehicles;
            }

            if (cycles > 0)
                averageWaittingVehicles /= cycles;

            return Math.Round(averageWaittingVehicles, 2, MidpointRounding.AwayFromZero);
        }

        public double GetAvgWaittingTime(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;


            double averageWaittingTime = 0;
            int cycles = (endCycle - startCycle) + 1;
            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                averageWaittingTime += TrafficData[RoadID][cycle].AvgWaittingTime;
            }
            if (cycles > 0)
                averageWaittingTime /= cycles;

            return Math.Round(averageWaittingTime,2,MidpointRounding.AwayFromZero);
        }

        public double GetIntersectionAvgWaitingTime(int intersectionID, int startCycle, int endCycle)
        {
            if (startCycle > endCycle)
                startCycle = endCycle;
            else if (startCycle < 0)
                startCycle = 0;

            List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;
            List<double> roadWeight = new List<double>();
            double intersectionAvgWaitingTime = 0;
            double totalArrivalRate = 0;

            for (int r = 0; r < roadList.Count; r++)
            {
                double arrivalRate = GetArrivalRate(roadList[r].roadID, startCycle, endCycle);
                roadWeight.Add(arrivalRate);
                totalArrivalRate += arrivalRate;
            }

            for (int r = 0; r < roadList.Count; r++)
            {
                if (totalArrivalRate != 0)
                    roadWeight[r] /= totalArrivalRate;
                intersectionAvgWaitingTime += roadWeight[r] * GetAvgWaittingTime(roadList[r].roadID, startCycle, endCycle);
            }

            return Math.Round(intersectionAvgWaitingTime, 2, MidpointRounding.AwayFromZero);
        }

        public double GetIntersectionAvgWaitingRate(int intersectionID, int startCycle, int endCycle)
        {
            if (startCycle > endCycle)
                startCycle = endCycle;
            else if (startCycle < 0)
                startCycle = 0;

            List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;
            List<double> roadWeight = new List<double>();
            double intersectionAvgWaitingRate = 0;
            double totalArrivalRate = 0;

            for (int r = 0; r < roadList.Count; r++)
            {
                double arrivalRate = GetArrivalRate(roadList[r].roadID, startCycle, endCycle);
                roadWeight.Add(arrivalRate);
                totalArrivalRate += arrivalRate;
            }

            for (int r = 0; r < roadList.Count; r++)
            {
                if (totalArrivalRate != 0)
                    roadWeight[r] /= totalArrivalRate;
                intersectionAvgWaitingRate += roadWeight[r] * GetAvgWaittingRate(roadList[r].roadID, startCycle, endCycle);
            }

            return Math.Round(intersectionAvgWaitingRate, 2, MidpointRounding.AwayFromZero);
        }

        public void OptimizationDataSaveAsTxt(int intersectionID)
        {
            List<OptimizationRecord> optimizationRecordList = GetOptimizationRecords(intersectionID, 0, 0);
            String fileName = Simulator.mapFileFolder + "\\" + Simulator.mapFileName + "_Intersection" + intersectionID + ".txt";
            File.Create(fileName).Close();

            StreamWriter sw = new StreamWriter(fileName);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < optimizationRecordList.Count; i++)
            {
                sb.AppendLine(optimizationRecordList[i].ToSaveFormat());
                //sw.WriteLine(optimizationRecordList[i].ToSaveFormat());        
            }
            sw.Write(sb.ToString());
            sw.Close(); 
        
        }

        public void OptimizationDataSaveAsExcel(int intersectionID)
        {
            List<OptimizationRecord> optimizationRecordList = GetOptimizationRecords(intersectionID, 0, 0);
            String fileName = Simulator.mapFileFolder + "\\" + Simulator.mapFileName + "_Intersection" + intersectionID + ".xlsx";

            //設定必要的物件
            //按照順序
            //分別是Application -> Workbook -> Worksheet -> Range -> Cell

            Excel.Application excel = new Excel.Application();
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            Excel.Range oRng;
 
            //如果需要讓使用者從程式的開始執行後
            //就可以操作Excel
            //則將下列屬性改為true
            excel.Visible = false;
            excel.UserControl = false;
 
            //產生一個Workbook物件，並加入Application
            oWB = excel.Workbooks.Add(Missing.Value);
 
            //設定工作表
            oSheet = (Excel.Worksheet)oWB.ActiveSheet;

            oSheet.Cells[2][1] = "MapFile:";
            oSheet.Cells[3][1] = Simulator.mapFileName;
            oSheet.Cells[4][1] = "SimulationFile:";
            oSheet.Cells[5][1] = Simulator.simulationFileName;

            oSheet.Cells[2][2] = "OptimizationCycle";
            oSheet.Cells[3][2] = "Optimiation Time";
            oSheet.Cells[4][2] = "IAWR";
            oSheet.Cells[5][2] = "IAWRThreshold";
            oSheet.Cells[6][2] = "OriginConfig";
            oSheet.Cells[7][2] = "OptimizedConfig";

            for (int i = 0; i < optimizationRecordList.Count; i++)
            {
                int row = i+3;
                oSheet.Cells[2][row] = optimizationRecordList[i].optimizeCycle;
                oSheet.Cells[3][row] = optimizationRecordList[i].optimizeTime;
                oSheet.Cells[4][row] = optimizationRecordList[i].IAWR;
                oSheet.Cells[5][row] = optimizationRecordList[i].IAWRThreshold;
                oSheet.Cells[6][row] = optimizationRecordList[i].OriginConfigToString();
                oSheet.Cells[7][row] = optimizationRecordList[i].OptimizedConfigToString();
            }

            //設定為按照內容自動調整欄寬
            oRng = oSheet.get_Range("B1", "G" + optimizationRecordList.Count+3);
            oRng.EntireColumn.AutoFit();
            oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
 
            //存檔
            //在這裡只設定檔案名稱(含路徑)即可

            oSheet.Application.DisplayAlerts = false;
            oSheet.Application.AlertBeforeOverwriting = false;

            oWB.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Excel.XlSaveAsAccessMode.xlShared, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
 
            oWB.Close();
            oWB = null;
 
            excel.Quit();
            excel = null;
        }
    }
}