using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.Unit;
using SmartTrafficSimulator.SystemObject;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace SmartTrafficSimulator.SystemObject
{
    class DataManager
    {
        int FILE_TRAFFICDATA = 0, FILE_OPTIMIZATIONRECORD = 1;

        Dictionary<int, List<CycleRecord>> TrafficData = new Dictionary<int, List<CycleRecord>>();
        Dictionary<int, Dictionary<int,OptimizationRecord>> OptimizationData = new Dictionary<int,Dictionary<int,OptimizationRecord>>();
        List<VehicleRecord> vehicleRecord = new List<VehicleRecord>();

        String savingPath = "";
        int fileNameCounter = 0;

        public void SetFileSavingPath(String savingPath)
        {
            this.savingPath = savingPath;
        }

        public void InitializeDataManager()
        {
            TrafficData = new Dictionary<int, List<CycleRecord>>();
            OptimizationData = new Dictionary<int, Dictionary<int, OptimizationRecord>>();
            vehicleRecord = new List<VehicleRecord>();
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

        public void PutCycleRecord(int roadID, CycleRecord cycleRecord)
        {
            TrafficData[roadID].Add(cycleRecord);
        }

        public void PutOptimizationRecord(int intersectionID, OptimizationRecord optRecord)
        {
            int cycle = optRecord.optimizeCycle;
            OptimizationData[intersectionID].Add(cycle, optRecord);
        }

        public void PutVehicleRecord(VehicleRecord record)
        {
            this.vehicleRecord.Add(record);
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

        public double GetArrivalVehicles(int RoadID, int startCycle, int endCycle)
        {
            if (TrafficData[RoadID].Count == 0)
                return 0;   

            if (startCycle >= TrafficData[RoadID].Count)
                startCycle = TrafficData[RoadID].Count - 1;
            else if (startCycle < 0)
                startCycle = 0;

            if (endCycle >= TrafficData[RoadID].Count || endCycle <= 0)
                endCycle = TrafficData[RoadID].Count - 1;

            double arrivalVehicles = 0;
            int cycles = (endCycle - startCycle) + 1;

            for (int cycle = startCycle; cycle <= endCycle; cycle++)
            {
                arrivalVehicles += TrafficData[RoadID][cycle].arrivedVehicles;
            }

            if (cycles > 0)
                arrivalVehicles /= cycles;

            return Math.Round(arrivalVehicles,2, MidpointRounding.AwayFromZero);
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
                waittingRate += TrafficData[RoadID][cycle].waittingRate;
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
                averageWaittingVehicles += TrafficData[RoadID][cycle].waitingVehicles;
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
                averageWaittingTime += TrafficData[RoadID][cycle].avgWaittingTime;
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
                double arrivalRate = GetArrivalVehicles(roadList[r].roadID, startCycle, endCycle);
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
            double totalArrivalVehicles = 0;

            for (int r = 0; r < roadList.Count; r++)
            {
                double arrivalVehicles = GetArrivalVehicles(roadList[r].roadID, startCycle, endCycle);
                roadWeight.Add(arrivalVehicles);
                totalArrivalVehicles += arrivalVehicles;
            }

            for (int r = 0; r < roadList.Count; r++)
            {
                if (totalArrivalVehicles != 0)
                    roadWeight[r] /= totalArrivalVehicles;
                intersectionAvgWaitingRate += roadWeight[r] * GetAvgWaittingRate(roadList[r].roadID, startCycle, endCycle);
            }

            return Math.Round(intersectionAvgWaitingRate, 2, MidpointRounding.AwayFromZero);
        }

        public Dictionary<int, List<VehicleRecord>> GetVehicleRecord(int interval)
        {  
            int currentTime = Simulator.getCurrentTime();
            int timeZone = (currentTime / interval)+1;
            Dictionary<int, List<VehicleRecord>> data = new Dictionary<int, List<VehicleRecord>>();
            for (int i = 0; i < timeZone; i++)
            {
                List<VehicleRecord> temp = new List<VehicleRecord>();
                data.Add(i, temp);
            }

            foreach (VehicleRecord record in vehicleRecord)
            {
                int zone = (record.exitTime / interval);
                data[zone].Add(record);
            }

            return data;
        }

        public string FileNameGenerate(int fileType)
        {
            string fileName = "";

            if (savingPath.Equals(""))
            {
                SetFileSavingPath(Simulator.mapFileFolder);
            }

            if (fileType == FILE_TRAFFICDATA)
            {
                while (File.Exists(savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationFileName + "_TrafficDara_" + fileNameCounter + ".xlsx"))
                {
                    fileNameCounter++;
                }
                fileName = savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationFileName + "_TrafficDara_" + fileNameCounter + ".xlsx";
            }
            else if (fileType == FILE_OPTIMIZATIONRECORD)
            {
                while (File.Exists(savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationFileName + "_optRecord_" + fileNameCounter + ".xlsx"))
                {
                    fileNameCounter++;
                }
                fileName = savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationFileName + "_optRecord_" + fileNameCounter + ".xlsx";
            }

            return fileName;
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
            }
            sw.Write(sb.ToString());
            sw.Close(); 
        }

        public void AllDataSaveAsExcel(Boolean saveTrafficRecord, Boolean saveOptimizationRecord)
        {
            List<Intersection> intersectionlist = Simulator.IntersectionManager.GetIntersectionList();

            if (saveTrafficRecord)
            {
                TrafficDataSaveAsExcel(intersectionlist);
            }
            if (saveOptimizationRecord)
            {
                OptimizationDataSaveAsExcel(intersectionlist);
            }
        }

        public void OptimizationDataSaveAsExcel(List<Intersection> intersectionList)
        {
            Simulator.UI.SimulatorStop();

            String fileName = FileNameGenerate(this.FILE_OPTIMIZATIONRECORD);

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

            oWB = excel.Workbooks.Add(Missing.Value);

            for (int intersectionIndex = 0; intersectionIndex < intersectionList.Count; intersectionIndex++)
            {
                int intersectionID = intersectionList[intersectionIndex].intersectionID;
                List<OptimizationRecord> optimizationRecordList = GetOptimizationRecords(intersectionID, 0, 0);

                oSheet = (Excel.Worksheet)oWB.Sheets.Add();
                oSheet.Name = "Intersection " + intersectionID;

                //填入模擬地圖與設定
                oSheet.Cells[2][1] = "MapFile:";
                oSheet.Cells[3][1] = Simulator.mapFileName;
                oSheet.Cells[4][1] = "SimulationFile:";
                oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationFileName;

                //設定表格欄位名稱
                oSheet.Cells[2][2] = "Optimization Cycle";
                oSheet.Cells[3][2] = "Optimiation Time";
                oSheet.Cells[4][2] = "IAWR";
                oSheet.Cells[5][2] = "IAWRThreshold";
                oSheet.Cells[6][2] = "OriginConfig";
                oSheet.Cells[7][2] = "OptimizedConfig";

                //填入數據
                for (int i = 0; i < optimizationRecordList.Count; i++)
                {
                    int row = i + 3;
                    oSheet.Cells[2][row] = optimizationRecordList[i].optimizeCycle;
                    oSheet.Cells[3][row] = optimizationRecordList[i].optimizeTime;
                    oSheet.Cells[4][row] = optimizationRecordList[i].IAWR;
                    oSheet.Cells[5][row] = optimizationRecordList[i].IAWRThreshold;
                    oSheet.Cells[6][row] = optimizationRecordList[i].OriginConfigToString();
                    oSheet.Cells[7][row] = optimizationRecordList[i].OptimizedConfigToString();
                }

                //設定為按照內容自動調整欄寬
                oRng = oSheet.get_Range("B1", "G" + optimizationRecordList.Count + 3);
                oRng.EntireColumn.AutoFit();
                oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                
                //須將覆蓋提示關閉
                oSheet.Application.DisplayAlerts = false;
                oSheet.Application.AlertBeforeOverwriting = false;
            }

            oSheet = (Excel.Worksheet)oWB.Sheets[intersectionList.Count + 1];
            oSheet.Delete();

            
            //存檔，在這裡只設定檔案名稱(含路徑)即可
            oWB.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //關閉
            oWB.Close();
            oWB = null;
            excel.Quit();
            excel = null;

            Simulator.UI.SimulatorStart();
        }

        public void TrafficDataSaveAsExcel(List<Intersection> intersectionList)
        {
            Simulator.UI.SimulatorStop();

            Excel.Application excel = new Excel.Application();
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            Excel.Range oRng;
            excel.Visible = false;
            excel.UserControl = false;
            oWB = excel.Workbooks.Add(Missing.Value);

            String fileName = FileNameGenerate(this.FILE_TRAFFICDATA);

            int roadCounter = 0;

            for (int intersectionIndex = 0; intersectionIndex < intersectionList.Count; intersectionIndex++)
            {
                int intersectionID = intersectionList[intersectionIndex].intersectionID;
                List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;
                roadCounter += roadList.Count;

                for (int r = 0; r < roadList.Count; r++)
                {
                    int roadID = roadList[r].roadID;
                    List<CycleRecord> cycleRecordList = TrafficData[roadID];

                    oSheet = (Excel.Worksheet)oWB.Sheets.Add();
                    oSheet.Name = "Road " + roadID;

                    //填入模擬地圖與設定
                    oSheet.Cells[2][1] = "MapFile:";
                    oSheet.Cells[3][1] = Simulator.mapName;
                    oSheet.Cells[4][1] = "SimulationFile:";
                    oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationFileName;
                    oSheet.Cells[6][1] = "Intersection";
                    oSheet.Cells[7][1] = intersectionID;

                    //設定表格欄位名稱
                    oSheet.Cells[2][2] = "Cycle";
                    oSheet.Cells[3][2] = "Previous Cycle Vehicles";
                    oSheet.Cells[4][2] = "Arrived vehicles";
                    oSheet.Cells[5][2] = "Passed Vehicles";
                    oSheet.Cells[6][2] = "Waiting Vehicles";
                    oSheet.Cells[7][2] = "Waiting Rate";
                    oSheet.Cells[8][2] = "Total Waiting Time";

                    //填入數據
                    for (int i = 0; i < cycleRecordList.Count; i++)
                    {
                        int row = i + 3;
                        oSheet.Cells[2][row] = i;
                        oSheet.Cells[3][row] = cycleRecordList[i].previousCycleVehicles;
                        oSheet.Cells[4][row] = cycleRecordList[i].arrivedVehicles;
                        oSheet.Cells[5][row] = cycleRecordList[i].passedVehicles;
                        oSheet.Cells[6][row] = cycleRecordList[i].waitingVehicles;
                        oSheet.Cells[7][row] = cycleRecordList[i].waittingRate;
                        oSheet.Cells[8][row] = cycleRecordList[i].waitingTimeOfAllVehicles;
                    }

                    oRng = oSheet.get_Range("B1", "H" + cycleRecordList.Count + 3);
                    oRng.EntireColumn.AutoFit();
                    oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    oSheet.Application.DisplayAlerts = false;
                    oSheet.Application.AlertBeforeOverwriting = false;
                }
            }

            oSheet = (Excel.Worksheet)oWB.Sheets[roadCounter + 1];
            oSheet.Delete();

            //存檔，在這裡只設定檔案名稱(含路徑)即可
            oWB.SaveAs(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //關閉
            oWB.Close();
            oWB = null;
            excel.Quit();
            excel = null;

            Simulator.UI.SimulatorStart();
        }
    }
}