using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.SystemObject;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using SmartTrafficSimulator.SystemManagers;


class DataManager
{
    int FILE_TRAFFICDATA = 0, FILE_OPTIMIZATIONRECORD = 1, FILE_INTERSECTIONSTATUS = 2, FILE_VEHICLEDATA = 3;
    int FILE_OPTIMIZATIONRECORD_SUMMARY = 21, FILE_INTERSECTIONSTATUS_SUMMARY = 22;

    //Data
    Dictionary<int, List<CycleRecord>> CycleRecords = new Dictionary<int, List<CycleRecord>>();
    Dictionary<int, Dictionary<int, OptimizationRecord>> OptimizationRecords = new Dictionary<int, Dictionary<int, OptimizationRecord>>();
    List<VehicleRecord> vehicleRecords = new List<VehicleRecord>();


    //Data output
    String savingPath = "";
    int fileNameCounter = 0;

    List<Dictionary<int, int>> simulationSummary_OptimizationRecord; //simulation times -> zone -> total optimization times of all intersection
    List<Dictionary<int, double>> simulationSummary_IntersectionStatus; //simulation times -> zone -> average IAWR
    public int dataInterval_trafficVolume = 1800;
    public int dataInterval_optRecords = 1800;
    public int dataInterval_intersectionStatus = 1800;
    public int dataInterval_vehicleData = 1800;


    public void InitializeDataManager()
    {
        CycleRecords = new Dictionary<int, List<CycleRecord>>();
        OptimizationRecords = new Dictionary<int, Dictionary<int, OptimizationRecord>>();
        vehicleRecords = new List<VehicleRecord>();
    }

    public void InitializeSummaryData()
    {
        simulationSummary_OptimizationRecord = new List<Dictionary<int, int>>();
        simulationSummary_IntersectionStatus = new List<Dictionary<int, double>>();
    }

    public void SetFileSavingPath(String savingPath)
    {
        this.savingPath = savingPath;
    }

    public void RegisterRoad(int roadID)
    {
        List<CycleRecord> trafficRecord = new List<CycleRecord>();
        CycleRecords.Add(roadID, trafficRecord);
    }

    public void RegisterIntersection(int intersectionID)
    {
        Dictionary<int, OptimizationRecord> optimizationRecord = new Dictionary<int, OptimizationRecord>();
        OptimizationRecords.Add(intersectionID, optimizationRecord);
    }

    public void AddCycleRecord(int roadID, CycleRecord cycleRecord)
    {
        CycleRecords[roadID].Add(cycleRecord);
    }

    public void AddOptimizationRecord(int intersectionID, OptimizationRecord optRecord)
    {
        int cycle = optRecord.optimizeCycle;
        OptimizationRecords[intersectionID].Add(cycle, optRecord);
    }

    public void AddVehicleRecord(VehicleRecord record)
    {
        this.vehicleRecords.Add(record);
    }

    public CycleRecord GetCycleRecord(int roadID, int cycle)
    {
        return CycleRecords[roadID][cycle];
    }

    public List<OptimizationRecord> GetOptimizationRecords(int intersectionID, int startCycle, int endCycle)
    {
        int maxCycle = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).currentCycle;

        if (startCycle > maxCycle)
            startCycle = maxCycle;

        else if (startCycle < 0)
            startCycle = 0;

        if (endCycle > maxCycle || endCycle <= 0)
            endCycle = maxCycle;

        List<OptimizationRecord> searchResult = new List<OptimizationRecord>();

        for (int cycle = startCycle; cycle <= endCycle; cycle++)
        {
            if (OptimizationRecords[intersectionID].ContainsKey(cycle))
                searchResult.Add(OptimizationRecords[intersectionID][cycle]);
        }

        return searchResult;
    }

    public int GetNumOfTrafficRecords(int roadID)
    {
        return CycleRecords[roadID].Count;
    }

    public int GetNumOfOptimizationRecords(int roadID)
    {
        return OptimizationRecords[roadID].Keys.Count();
    }

    public double GetArrivalVehicles(int RoadID, int startCycle, int endCycle)
    {
        if (CycleRecords[RoadID].Count == 0)
            return 0;

        int maxCycle = CycleRecords[RoadID].Count - 1;

        if (startCycle > maxCycle)
            startCycle = maxCycle;
        else if (startCycle < 0)
            startCycle = 0;

        if (endCycle > maxCycle || endCycle <= 0)
            endCycle = maxCycle;

        double arrivalVehicles = 0;

        for (int cycle = startCycle; cycle <= endCycle; cycle++)
        {
            arrivalVehicles += CycleRecords[RoadID][cycle].arrivalVehicles;
        }

        return arrivalVehicles;
    }

    public double GetAvgArrivalVehicles(int RoadID, int startCycle, int endCycle)
    {
        if (CycleRecords[RoadID].Count == 0)
            return 0;

        int maxCycle = CycleRecords[RoadID].Count - 1;

        if (startCycle > maxCycle)
            startCycle = maxCycle;
        else if (startCycle < 0)
            startCycle = 0;

        if (endCycle > maxCycle || endCycle <= 0)
            endCycle = maxCycle;

        double arrivalVehicles = 0;
        int cycles = (endCycle - startCycle) + 1;

        for (int cycle = startCycle; cycle <= endCycle; cycle++)
        {
            arrivalVehicles += CycleRecords[RoadID][cycle].arrivalVehicles;
        }

        if (cycles > 0)
            arrivalVehicles /= cycles;

        return Math.Round(arrivalVehicles, 2, MidpointRounding.AwayFromZero);
    }

    public double GetAvgArrivalRate_min(int RoadID, int startCycle, int endCycle)
    {
        if (CycleRecords[RoadID].Count == 0)
            return 0;

        int maxCycle = CycleRecords[RoadID].Count - 1;

        if (startCycle > maxCycle)
            startCycle = maxCycle;
        else if (startCycle < 0)
            startCycle = 0;

        if (endCycle > maxCycle || endCycle <= 0)
            endCycle = maxCycle;

        double arrivalRate = 0;
        int cycles = (endCycle - startCycle) + 1;

        for (int cycle = startCycle; cycle <= endCycle; cycle++)
        {
            arrivalRate += CycleRecords[RoadID][cycle].arrivalRate_min;
        }

        if (cycles > 0)
            arrivalRate /= cycles;

        return Math.Round(arrivalRate, 2, MidpointRounding.AwayFromZero);
    }

    public double GetAvgDepartureRate_min(int RoadID, int startCycle, int endCycle)
    {
        if (CycleRecords[RoadID].Count == 0)
            return 0;

        int maxCycle = CycleRecords[RoadID].Count - 1;

        if (startCycle > maxCycle)
            startCycle = maxCycle;
        else if (startCycle < 0)
            startCycle = 0;

        if (endCycle > maxCycle || endCycle <= 0)
            endCycle = maxCycle;

        double departureRate = 0;
        int cycles = (endCycle - startCycle) + 1;

        for (int cycle = startCycle; cycle <= endCycle; cycle++)
        {
            departureRate += CycleRecords[RoadID][cycle].departureRate_min;
        }

        if (cycles > 0)
            departureRate /= cycles;

        return Math.Round(departureRate, 2, MidpointRounding.AwayFromZero);
    }


    public double GetAvgWaittingRate(int RoadID, int startCycle, int endCycle)
    {
        if (CycleRecords[RoadID].Count == 0)
            return 0;

        int maxCycle = CycleRecords[RoadID].Count - 1;

        if (startCycle > maxCycle)
            startCycle = maxCycle;
        else if (startCycle < 0)
            startCycle = 0;

        if (endCycle > maxCycle || endCycle <= 0)
            endCycle = maxCycle;

        double waittingRate = 0;
        int cycles = (endCycle - startCycle) + 1;

        for (int cycle = startCycle; cycle <= endCycle; cycle++)
        {
            waittingRate += CycleRecords[RoadID][cycle].waittingRate;
        }

        if (cycles > 0)
            waittingRate = waittingRate / cycles;

        return Math.Round(waittingRate, 4, MidpointRounding.AwayFromZero);
    }

    public double GetAvgWaittingVehicles(int RoadID, int startCycle, int endCycle)
    {
        if (CycleRecords[RoadID].Count == 0)
            return 0;

        int maxCycle = CycleRecords[RoadID].Count - 1;

        if (startCycle > maxCycle)
            startCycle = maxCycle;
        else if (startCycle < 0)
            startCycle = 0;

        if (endCycle > maxCycle || endCycle <= 0)
            endCycle = maxCycle;

        double averageWaittingVehicles = 0;
        int cycles = (endCycle - startCycle) + 1;
        for (int cycle = startCycle; cycle <= endCycle; cycle++)
        {
            averageWaittingVehicles += CycleRecords[RoadID][cycle].waitingVehicles;
        }

        if (cycles > 0)
            averageWaittingVehicles /= cycles;

        return Math.Round(averageWaittingVehicles, 2, MidpointRounding.AwayFromZero);
    }


    public double GetAvgWaittingTime(int RoadID, int startCycle, int endCycle)
    {
        if (CycleRecords[RoadID].Count == 0)
            return 0;

        int maxCycle = CycleRecords[RoadID].Count - 1;

        if (startCycle > maxCycle)
            startCycle = maxCycle;
        else if (startCycle < 0)
            startCycle = 0;

        if (endCycle > maxCycle || endCycle <= 0)
            endCycle = maxCycle;


        double averageWaittingTime = 0;
        int cycles = (endCycle - startCycle) + 1;
        for (int cycle = startCycle; cycle <= endCycle; cycle++)
        {
            averageWaittingTime += CycleRecords[RoadID][cycle].avgWaittingTime;
        }
        if (cycles > 0)
            averageWaittingTime /= cycles;

        return Math.Round(averageWaittingTime, 2, MidpointRounding.AwayFromZero);
    }

    public double GetIntersectionAvgWaitingTime(int intersectionID, int startCycle, int endCycle)
    {
        if (startCycle > endCycle && endCycle != 0)
        {
            startCycle = endCycle;
        }
        else if (startCycle < 0)
        { 
            startCycle = 0;
        }
            

        List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;
        List<double> roadWeight = new List<double>();
        double intersectionAvgWaitingTime = 0;
        double totalArrivalRate = 0;

        for (int r = 0; r < roadList.Count; r++)
        {
            double arrivalRate = GetAvgArrivalRate_min(roadList[r].roadID, startCycle, endCycle);
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
        if (startCycle > endCycle && endCycle != 0)
        {
            startCycle = endCycle;
        }
        else if (startCycle < 0)
        {
            startCycle = 0;
        }

        List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;
        List<double> roadWeight = new List<double>();
        double intersectionAvgWaitingRate = 0;
        double totalArrivalRate = 0;

        for (int r = 0; r < roadList.Count; r++)
        {
            double arrivalRate = GetAvgArrivalRate_min(roadList[r].roadID, startCycle, endCycle);
            roadWeight.Add(arrivalRate);
            totalArrivalRate += arrivalRate;
        }

        for (int r = 0; r < roadList.Count; r++)
        {
            if (totalArrivalRate != 0)
                roadWeight[r] /= totalArrivalRate;
            intersectionAvgWaitingRate += roadWeight[r] * GetAvgWaittingRate(roadList[r].roadID, startCycle, endCycle);
        }

        return Math.Round(intersectionAvgWaitingRate, 4, MidpointRounding.AwayFromZero);
    }

    public Dictionary<int, Dictionary<int, double>> GetArrivalVehicleData_Interval(int intersectionID, int interval_sec)
    {
        List<int> cycleEneTime = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).cycleEneTime;
        List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;

        Dictionary<int, Dictionary<int, double>> data = new Dictionary<int, Dictionary<int, double>>(); //zone -> roadID -> arrival vehicle

        Dictionary<int, List<int>> cycleToZone = new Dictionary<int, List<int>>();

        for (int c = 0; c < cycleEneTime.Count; c++)
        {
            int zone = cycleEneTime[c] / interval_sec;
            if (cycleToZone.ContainsKey(zone))
            {
                cycleToZone[zone].Add(c);
            }
            else
            {
                List<int> cycleNumber = new List<int>();
                cycleNumber.Add(c);
                cycleToZone.Add(zone, cycleNumber);
            }
        }

        int[] zones = cycleToZone.Keys.ToArray<int>();

        foreach (int zone in zones)
        {
            List<int> cycleNumbers = cycleToZone[zone];
            int startCycle = cycleNumbers[0];
            int endCycle = cycleNumbers[cycleNumbers.Count - 1];

            data.Add(zone,new Dictionary<int, double>());
            foreach (Road road in roadList)
            { 
                double arrivalVehicle = GetArrivalVehicles(road.roadID,startCycle,endCycle);
                data[zone].Add(road.roadID, arrivalVehicle);
            }
        }

        return data;
    }

    public Dictionary<int, Dictionary<int, double>> GetArrivalRateData_Interval(int intersectionID, int interval_sec)
    {
        List<int> cycleEneTime = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).cycleEneTime;
        List<Road> roadList = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).roadList;

        Dictionary<int, Dictionary<int, double>> data = new Dictionary<int, Dictionary<int, double>>(); //zone -> roadID -> arrival vehicle

        Dictionary<int, List<int>> cycleToZone = new Dictionary<int, List<int>>();

        for (int c = 0; c < cycleEneTime.Count; c++)
        {
            int zone = cycleEneTime[c] / interval_sec;
            if (cycleToZone.ContainsKey(zone))
            {
                cycleToZone[zone].Add(c);
            }
            else
            {
                List<int> cycleNumber = new List<int>();
                cycleNumber.Add(c);
                cycleToZone.Add(zone, cycleNumber);
            }
        }

        int[] zones = cycleToZone.Keys.ToArray<int>();

        foreach (int zone in zones)
        {
            List<int> cycleNumbers = cycleToZone[zone];
            int startCycle = cycleNumbers[0];
            int endCycle = cycleNumbers[cycleNumbers.Count - 1];

            data.Add(zone, new Dictionary<int, double>());
            foreach (Road road in roadList)
            {
                double totalCycleTime = 0;
                int roadID = roadList[0].roadID;
                for (int c = startCycle; c <= endCycle; c++)
                {
                    totalCycleTime += this.CycleRecords[roadID][c].cycleTime;
                }
                double arrivalVehicles = GetArrivalVehicles(road.roadID, startCycle, endCycle);
                double arrivalRate_min;

                if (totalCycleTime <= 0)
                {
                    arrivalRate_min = 0;
                }
                else
                {
                    arrivalRate_min = (arrivalVehicles / totalCycleTime) * interval_sec;
                    arrivalRate_min = Math.Round(arrivalVehicles, 0, MidpointRounding.AwayFromZero);
                }

                data[zone].Add(road.roadID, arrivalRate_min);
            }
        }

        return data;
    }

    public Dictionary<int, double> GetIAWR_Interval(int intersectionID,int interval_sec)
    {
        List<int> cycleEneTime = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).cycleEneTime;
        Dictionary<int, double> data = new Dictionary<int,double>();

        Dictionary<int, List<int>> cycleToZone = new Dictionary<int, List<int>>();

        for (int c = 0; c < cycleEneTime.Count;c++)
        {
            int zone = cycleEneTime[c] / interval_sec;
            if (cycleToZone.ContainsKey(zone))
            {
                cycleToZone[zone].Add(c);
            }
            else
            {
                List<int> cycleNumber = new List<int>();
                cycleNumber.Add(c);
                cycleToZone.Add(zone, cycleNumber);
            }
        }

        int[] zones = cycleToZone.Keys.ToArray<int>();

        foreach (int zone in zones)
        {
            List<int> cycleNumbers = cycleToZone[zone];
            int startCycle = cycleNumbers[0];
            int endCycle = cycleNumbers[cycleNumbers.Count - 1];
            data.Add(zone, GetIntersectionAvgWaitingRate(intersectionID, startCycle, endCycle));
        }

        return data;
    }

    public Dictionary<int, List<OptimizationRecord>> GetOptimizationRecoeds_Interval(int intersectionID, int interval_sec)
    {
        List<int> cycleEneTime = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).cycleEneTime;
        Dictionary<int, List<OptimizationRecord>> data = new Dictionary<int, List<OptimizationRecord>>();

        Dictionary<int, List<int>> cycleToZone = new Dictionary<int, List<int>>();


        for (int c = 0; c < cycleEneTime.Count; c++)
        {
            int zone = cycleEneTime[c] / interval_sec;
            if (cycleToZone.ContainsKey(zone))
            {
                cycleToZone[zone].Add(c);
            }
            else
            {
                List<int> cycleNumber = new List<int>();
                cycleNumber.Add(c);
                cycleToZone.Add(zone, cycleNumber);
            }
        }

        int[] zones = cycleToZone.Keys.ToArray<int>();

        foreach (int zone in zones)
        {
            List<int> cycleNumbers = cycleToZone[zone];
            int startCycle = cycleNumbers[0];
            int endCycle = cycleNumbers[cycleNumbers.Count - 1];
            data.Add(zone, GetOptimizationRecords(intersectionID, startCycle, endCycle));
        }

        return data;
    }


    public Dictionary<int, List<VehicleRecord>> GetVehicleData_Interval(int interval_sec)
    {
        int currentTime = Simulator.getCurrentTime();
        int timeZone = (currentTime / interval_sec) + 1;
        Dictionary<int, List<VehicleRecord>> data = new Dictionary<int, List<VehicleRecord>>();

        foreach (VehicleRecord record in vehicleRecords)
        {
            int zone = (record.exitTime / interval_sec);
            if (data.ContainsKey(zone))
            {
                data[zone].Add(record);
            }
            else
            {
                List<VehicleRecord> vehicleRecord_zone = new List<VehicleRecord>();
                vehicleRecord_zone.Add(record);
                data.Add(zone, vehicleRecord_zone);
            }
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
            while (File.Exists(savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_TrafficDara_" + fileNameCounter + ".xlsx"))
            {
                fileNameCounter++;
            }
            fileName = savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_TrafficDara_" + fileNameCounter + ".xlsx";
        }

        else if (fileType == FILE_OPTIMIZATIONRECORD)
        {
            while (File.Exists(savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_OptRecord_" + fileNameCounter + ".xlsx"))
            {
                fileNameCounter++;
            }
            fileName = savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_OptRecord_" + fileNameCounter + ".xlsx";
        }
        else if (fileType == FILE_OPTIMIZATIONRECORD_SUMMARY)
        {
            while (File.Exists(savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_OptRecordSummary_" + fileNameCounter + ".xlsx"))
            {
                fileNameCounter++;
            }
            fileName = savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_OptRecordSummary_" + fileNameCounter + ".xlsx";
        }

        else if (fileType == FILE_INTERSECTIONSTATUS)
        {
            while (File.Exists(savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_IntersectionStatus_" + fileNameCounter + ".xlsx"))
            {
                fileNameCounter++;
            }
            fileName = savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_IntersectionStatus_" + fileNameCounter + ".xlsx";
        }
        else if (fileType == FILE_INTERSECTIONSTATUS_SUMMARY)
        {
            while (File.Exists(savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_IntersectionStatusSummary_" + fileNameCounter + ".xlsx"))
            {
                fileNameCounter++;
            }
            fileName = savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_IntersectionStatusSummary_" + fileNameCounter + ".xlsx";
        }

        else if (fileType == FILE_VEHICLEDATA)
        {
            while (File.Exists(savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_VehicleData_" + fileNameCounter + ".xlsx"))
            {
                fileNameCounter++;
            }
            fileName = savingPath + "\\" + Simulator.mapFileName + "_" + Simulator.TaskManager.GetCurrentTask().simulationName + "_VehicleData_" + fileNameCounter + ".xlsx";
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

    public void DataSaveAsExcel(Boolean saveTrafficRecord, Boolean saveOptimizationRecord,Boolean saveIntersectionStatus,Boolean saveVehicleData)
    {
        List<Intersection> intersectionlist = Simulator.IntersectionManager.GetIntersectionList();

        if (saveTrafficRecord)
        {
            //TrafficDataSaveAsExcel(intersectionlist);
            TrafficVolumeData_SaveAsExcel(this.dataInterval_trafficVolume);
        }
        if (saveOptimizationRecord)
        {
            OptimizationRecord_SaveAsExcel(this.dataInterval_optRecords);
        }
        if (saveIntersectionStatus)
        {
            IntersectionStatus_SaveAsExcel(this.dataInterval_intersectionStatus);
        }
        if (saveVehicleData)
        {
            VehicleData_SaveAsExcel(this.dataInterval_vehicleData);
        }
    }

    public void SummaryDataSaveAsExcel(Boolean saveTrafficRecord, Boolean saveOptimizationRecord, Boolean saveIntersectionState, Boolean saveVehicleData)
    {
        if (saveOptimizationRecord)
        {
            this.OptimizationRecord_Summary_SaveAsExcel(this.dataInterval_optRecords);
        }
        if (saveIntersectionState)
        {
            this.IntersectionState_Summary_SaveAsExcel(this.dataInterval_intersectionStatus);
        }
    }

    public void TrafficData_SaveAsExcel()
    {
        List<Intersection> intersectionList = Simulator.IntersectionManager.GetIntersectionList();

        if(Simulator.simulatorRun)
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
                List<CycleRecord> cycleRecordList = CycleRecords[roadID];

                oSheet = (Excel.Worksheet)oWB.Sheets.Add();
                oSheet.Name = "Road " + roadID;

                //填入模擬地圖與設定
                oSheet.Cells[2][1] = "MapFile:";
                oSheet.Cells[3][1] = Simulator.mapName;
                oSheet.Cells[4][1] = "SimulationFile:";
                oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationName;
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
                    oSheet.Cells[4][row] = cycleRecordList[i].arrivalVehicles;
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

    public void TrafficVolumeData_SaveAsExcel(int dataInterval)
    {
        List<Intersection> intersectionList = Simulator.IntersectionManager.GetIntersectionList();

        if (Simulator.simulatorRun)
            Simulator.UI.SimulatorStop();

        String fileName = FileNameGenerate(this.FILE_TRAFFICDATA);

        Excel.Application excel = new Excel.Application();
        Excel.Workbook oWB;
        Excel.Worksheet oSheet;
        Excel.Range oRng;

        excel.Visible = false;
        excel.UserControl = false;

        oWB = excel.Workbooks.Add(Missing.Value);

        oSheet = (Excel.Worksheet)oWB.Sheets.Add();
        oSheet.Name = "Intersection State";

        //填入模擬地圖與設定
        oSheet.Cells[2][1] = "MapFile:";
        oSheet.Cells[3][1] = Simulator.mapFileName;
        oSheet.Cells[4][1] = "SimulationFile:";
        oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationName;

        Dictionary<int, Dictionary<int, Dictionary<int, double>>> data = new Dictionary<int, Dictionary<int, Dictionary<int, double>>>();

        //設定表格欄位名稱
        oSheet.Cells[2][2] = "Time";

        int colume = 3;
        foreach (Intersection inte in intersectionList)
        {
            data.Add(inte.intersectionID, GetArrivalVehicleData_Interval(inte.intersectionID, dataInterval));
            foreach(Road road in inte.roadList)
            {
                oSheet.Cells[colume++][2] = "Road " + road.roadID;
            }
        }

        int[] zones = data[intersectionList[0].intersectionID].Keys.ToArray<int>();

        int row = 3;
        foreach (int zone in zones)
        {
            oSheet.Cells[2][row] = Simulator.getZoneRange_Format(zone, dataInterval);
            colume = 3;
            foreach (Intersection inte in intersectionList)
            {
                foreach (Road road in inte.roadList)
                {
                    oSheet.Cells[colume++][row] = data[inte.intersectionID][zone][road.roadID];
                }
            }
            row++;
        }


        //設定為按照內容自動調整欄寬
        oRng = oSheet.get_Range("B1", "Z" + zones.Length + 3);
        oRng.EntireColumn.AutoFit();
        oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        //須將覆蓋提示關閉
        oSheet.Application.DisplayAlerts = false;
        oSheet.Application.AlertBeforeOverwriting = false;


        oSheet = (Excel.Worksheet)oWB.Sheets[2];
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

    public void OptimizationRecord_SaveAsExcel(int dataInterval)
    {
        List<Intersection> intersectionList = Simulator.IntersectionManager.GetIntersectionList();

        if (Simulator.simulatorRun)
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

        int row;

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
            oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationName;

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
                row = i + 3;
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

        
        oSheet = (Excel.Worksheet)oWB.Sheets.Add();
        oSheet.Name = "Total Optimization Times";

        //填入模擬地圖與設定
        oSheet.Cells[2][1] = "MapFile:";
        oSheet.Cells[3][1] = Simulator.mapFileName;
        oSheet.Cells[4][1] = "SimulationFile:";
        oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationName;

        oSheet.Cells[2][2] = "Time";

        Dictionary<int, Dictionary<int, List<OptimizationRecord>>> data = new Dictionary<int, Dictionary<int, List<OptimizationRecord>>>();

        int colume = 3;
        foreach (Intersection inte in intersectionList)
        {
            data.Add(inte.intersectionID, GetOptimizationRecoeds_Interval(inte.intersectionID, dataInterval));
            oSheet.Cells[colume++][2] = "Intersection " + inte.intersectionID; 
        }
        oSheet.Cells[colume++][2] = "Total";

        Dictionary<int, int> allzoneOptTimes = new Dictionary<int, int>();

        int[] zones = data[intersectionList[0].intersectionID].Keys.ToArray<int>();

        row = 3;
        foreach (int zone in zones)
        {
            oSheet.Cells[2][row] = Simulator.getZoneRange_Format(zone, dataInterval);
            colume = 3;
            int zoneOptTimes = 0;

            foreach (Intersection inte in intersectionList)
            {
                int optTimes = 0;
                foreach (OptimizationRecord or in data[inte.intersectionID][zone])
                {
                    optTimes += or.optimizationTimes;
                }
                oSheet.Cells[colume++][row] = optTimes;
                zoneOptTimes += optTimes;
            }
            oSheet.Cells[colume++][row] = zoneOptTimes;
            allzoneOptTimes.Add(zone, zoneOptTimes);

            row++;
        }

        simulationSummary_OptimizationRecord.Add(allzoneOptTimes);
        

        //設定為按照內容自動調整欄寬
        oRng = oSheet.get_Range("B1", "Z" + zones.Length + 3);
        oRng.EntireColumn.AutoFit();
        oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        //須將覆蓋提示關閉
        oSheet.Application.DisplayAlerts = false;
        oSheet.Application.AlertBeforeOverwriting = false;
        
        oSheet = (Excel.Worksheet)oWB.Sheets[intersectionList.Count + 2];
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

    public void OptimizationRecord_Summary_SaveAsExcel(int dataInterval)
    {
        if (Simulator.simulatorRun)
            Simulator.UI.SimulatorStop();

        String fileName = FileNameGenerate(this.FILE_OPTIMIZATIONRECORD_SUMMARY);

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
        oSheet = (Excel.Worksheet)oWB.Sheets.Add();
        oSheet.Name = "Optimization Times Summary";


        //填入模擬地圖與設定
        oSheet.Cells[2][1] = "MapFile:";
        oSheet.Cells[3][1] = Simulator.mapFileName;
        oSheet.Cells[4][1] = "SimulationFile:";
        oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationName;
        oSheet.Cells[6][1] = "Simulation Times:";
        oSheet.Cells[7][1] = Simulator.TaskManager.GetCurrentTask().repeatTimes;

        oSheet.Cells[2][2] = "Time";

        Dictionary<int, Dictionary<int, List<OptimizationRecord>>> data = new Dictionary<int, Dictionary<int, List<OptimizationRecord>>>();

        int colume = 3;
        for (int s = 0; s < simulationSummary_OptimizationRecord.Count; s++)
        {
            oSheet.Cells[colume++][2] = "Simulation " + s;
        }

        int[] zones = simulationSummary_OptimizationRecord[0].Keys.ToArray<int>();

        int row = 3;
        foreach (int zone in zones)
        {
            oSheet.Cells[2][row] = Simulator.getZoneRange_Format(zone, dataInterval);
            colume = 3;

            foreach (Dictionary<int,int> optTimes in simulationSummary_OptimizationRecord)
            {
                oSheet.Cells[colume++][row] = optTimes[zone];
            }

            row++;
        }

        //設定為按照內容自動調整欄寬
        oRng = oSheet.get_Range("B1", "Z" + zones.Length + 3);
        oRng.EntireColumn.AutoFit();
        oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        //須將覆蓋提示關閉
        oSheet.Application.DisplayAlerts = false;
        oSheet.Application.AlertBeforeOverwriting = false;

        oSheet = (Excel.Worksheet)oWB.Sheets[2];
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

    public void IntersectionStatus_SaveAsExcel(int dataInterval)
    {
        List<Intersection> intersectionList = Simulator.IntersectionManager.GetIntersectionList();

        if (Simulator.simulatorRun)
            Simulator.UI.SimulatorStop();

        String fileName = FileNameGenerate(this.FILE_INTERSECTIONSTATUS);

        Excel.Application excel = new Excel.Application();
        Excel.Workbook oWB;
        Excel.Worksheet oSheet;
        Excel.Range oRng;

        excel.Visible = false;
        excel.UserControl = false;

        oWB = excel.Workbooks.Add(Missing.Value);

        oSheet = (Excel.Worksheet)oWB.Sheets.Add();
        oSheet.Name = "Intersection State";

        //填入模擬地圖與設定
        oSheet.Cells[2][1] = "MapFile:";
        oSheet.Cells[3][1] = Simulator.mapFileName;
        oSheet.Cells[4][1] = "SimulationFile:";
        oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationName;


        Dictionary<int, Dictionary<int, double>> data = new Dictionary<int, Dictionary<int, double>>();
        //設定表格欄位名稱
        oSheet.Cells[2][2] = "Time";

        int colume = 3;
        foreach (Intersection inte in intersectionList)
        {
            int intersectionID = inte.intersectionID;
            oSheet.Cells[colume++][2] = "Intersection" + intersectionID;
            data.Add(intersectionID, GetIAWR_Interval(intersectionID, dataInterval));
        }
        oSheet.Cells[colume++][2] = "Average";

        Dictionary<int, double> allAverageIAWR = new Dictionary<int, double>();
        
        int[] zones = data[intersectionList[0].intersectionID].Keys.ToArray<int>();
        
        int row = 3;
        foreach(int zone in zones)
        {
            oSheet.Cells[2][row] = Simulator.getZoneRange_Format(zone, dataInterval);
            colume = 3;
            double averageIAWR = 0;

            foreach(Intersection i in intersectionList)
            {
                double IAWR = data[i.intersectionID][zone]*100;
                oSheet.Cells[colume++][row] = IAWR;
                averageIAWR += IAWR;
            }
            averageIAWR = Math.Round((averageIAWR / intersectionList.Count), 2, MidpointRounding.AwayFromZero);
            oSheet.Cells[colume++][row] = averageIAWR;

            allAverageIAWR.Add(zone, averageIAWR);

            row++;
        }

        simulationSummary_IntersectionStatus.Add(allAverageIAWR);

        //設定為按照內容自動調整欄寬
        oRng = oSheet.get_Range("B1", "Z" + zones.Length + 3);
        oRng.EntireColumn.AutoFit();
        oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        //須將覆蓋提示關閉
        oSheet.Application.DisplayAlerts = false;
        oSheet.Application.AlertBeforeOverwriting = false;
        
        oSheet = (Excel.Worksheet)oWB.Sheets[2];
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

    public void IntersectionState_Summary_SaveAsExcel(int dataInterval)
    {
        if (Simulator.simulatorRun)
            Simulator.UI.SimulatorStop();

        String fileName = FileNameGenerate(this.FILE_INTERSECTIONSTATUS_SUMMARY);

        Excel.Application excel = new Excel.Application();
        Excel.Workbook oWB;
        Excel.Worksheet oSheet;
        Excel.Range oRng;
        excel.Visible = false;
        excel.UserControl = false;

        oWB = excel.Workbooks.Add(Missing.Value);
        oSheet = (Excel.Worksheet)oWB.Sheets.Add();
        oSheet.Name = "Intersection State Summary";

        //填入模擬地圖與設定
        oSheet.Cells[2][1] = "MapFile:";
        oSheet.Cells[3][1] = Simulator.mapFileName;
        oSheet.Cells[4][1] = "SimulationFile:";
        oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationName;
        oSheet.Cells[6][1] = "Simulation Times:";
        oSheet.Cells[7][1] = Simulator.TaskManager.GetCurrentTask().repeatTimes;

        oSheet.Cells[2][2] = "Time";

        Dictionary<int, Dictionary<int, List<OptimizationRecord>>> data = new Dictionary<int, Dictionary<int, List<OptimizationRecord>>>();

        int colume = 3;
        for (int s = 0; s < simulationSummary_IntersectionStatus.Count; s++)
        {
            oSheet.Cells[colume++][2] = "Simulation " + s;
        }

        int[] zones = simulationSummary_IntersectionStatus[0].Keys.ToArray<int>();

        int row = 3;
        foreach (int zone in zones)
        {
            oSheet.Cells[2][row] = Simulator.getZoneRange_Format(zone, dataInterval);
            colume = 3;

            foreach (Dictionary<int, double> optTimes in simulationSummary_IntersectionStatus)
            {
                oSheet.Cells[colume++][row] = optTimes[zone];
            }

            row++;
        }

        //設定為按照內容自動調整欄寬
        oRng = oSheet.get_Range("B1", "Z" + zones.Length + 3);
        oRng.EntireColumn.AutoFit();
        oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        //須將覆蓋提示關閉
        oSheet.Application.DisplayAlerts = false;
        oSheet.Application.AlertBeforeOverwriting = false;

        oSheet = (Excel.Worksheet)oWB.Sheets[2];
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

    public void VehicleData_SaveAsExcel(int dataInterval)
    {
        if (Simulator.simulatorRun)
            Simulator.UI.SimulatorStop();

        String fileName = FileNameGenerate(this.FILE_VEHICLEDATA);

        Excel.Application excel = new Excel.Application();
        Excel.Workbook oWB;
        Excel.Worksheet oSheet;
        Excel.Range oRng;

        excel.Visible = false;
        excel.UserControl = false;

        oWB = excel.Workbooks.Add(Missing.Value);

        oSheet = (Excel.Worksheet)oWB.Sheets.Add();
        oSheet.Name = "Vehicle Data";

        //填入模擬地圖與設定
        oSheet.Cells[2][1] = "MapFile:";
        oSheet.Cells[3][1] = Simulator.mapFileName;
        oSheet.Cells[4][1] = "SimulationFile:";
        oSheet.Cells[5][1] = Simulator.TaskManager.GetCurrentTask().simulationName;

        //設定表格欄位名稱
        oSheet.Cells[2][2] = "Time";
        oSheet.Cells[3][2] = "Travel Time";
        oSheet.Cells[4][2] = "Travel Speed";
        oSheet.Cells[5][2] = "Delay Time";

        Dictionary<int, List<VehicleRecord>> data = Simulator.DataManager.GetVehicleData_Interval(dataInterval);

        int[] zones = data.Keys.ToArray<int>();

        int row = 3;
        foreach (int zone in zones)
        {
            double avgTravelTime = 0;
            double avgTravelSpeed = 0;
            double avgDelayTime = 0;

            foreach (VehicleRecord record in data[zone])
            {
                avgTravelTime += record.travelTime_Sec;
                avgTravelSpeed += record.travelSpeed_KMH;
                avgDelayTime += record.delayTime_Sec;
            }

            if (data[zone].Count > 0)
            {
                avgTravelTime = Math.Round(avgTravelTime / data[zone].Count, 2, MidpointRounding.AwayFromZero);
                avgTravelSpeed = Math.Round((avgTravelSpeed) / data[zone].Count, 2, MidpointRounding.AwayFromZero);
                avgDelayTime = Math.Round(avgDelayTime / data[zone].Count, 2, MidpointRounding.AwayFromZero);
            }


            oSheet.Cells[2][row] = Simulator.getZoneRange_Format(zone, dataInterval);
            oSheet.Cells[3][row] = avgTravelTime;
            oSheet.Cells[4][row] = avgTravelSpeed;
            oSheet.Cells[5][row] = avgDelayTime;

            row++;
        }

        //設定為按照內容自動調整欄寬
        oRng = oSheet.get_Range("B1", "Z" + zones.Length + 3);
        oRng.EntireColumn.AutoFit();
        oRng.EntireColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

        //須將覆蓋提示關閉
        oSheet.Application.DisplayAlerts = false;
        oSheet.Application.AlertBeforeOverwriting = false;


        oSheet = (Excel.Worksheet)oWB.Sheets[2];
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
