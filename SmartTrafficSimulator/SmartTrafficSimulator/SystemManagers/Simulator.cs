using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartTrafficSimulator.Unit;
using SmartTrafficSimulator.GraphicUnit;
using SmartTrafficSimulator.SystemManagers;

namespace SmartTrafficSimulator.SystemObject
{
    class Simulator
    {
        public static Boolean TESTMODE = false;

        public static MainUI UI = null;
        public static int SimulationTime = 0; //模擬器內時鐘(以秒為單位)

        //Manager
        public static RoadManager RoadManager = new RoadManager();
        public static IntersectionManager IntersectionManager = new IntersectionManager();
        public static VehicleManager VehicleManager = new VehicleManager();
        public static DataManager DataManager = new DataManager();
        public static PrototypeManager PrototypeManager = new PrototypeManager();
        public static TaskManager TaskManager = new TaskManager();

        //Running information
        public static Boolean mapFileReaded = false;
        public static Boolean simulationFileReaded = false;
        public static Boolean simulatorRun = false;     //run or stop
        public static Boolean simulatorStarted = false; //startrd
        public static int simulationSpeedRate = 1;           //simulator speed up

        //Griphic 
        public static int vehicleGraphicFPS = 1;
        public static Boolean trafficSignalCountdownDisplay = true;
        public static Boolean intersectionInformation = true;
        public static Boolean roadStateMark = false;

        //Window Size
        public static Boolean fullScreen = false;

        //Traffic Signal Size
        public static int signalLength = 50;
        public static int signalWidth = 5;

        //File Read 執行後填入
        public static String mapPicturePath = "";              //地圖圖片路徑
        public static String mapFilePath = "";                     //地圖檔路徑
        public static String mapFileName = "";                     //地圖檔名稱
        public static String mapFileFolder = "";                   //地圖檔所在資料夾
        public static String simulationFilePath = "";              //模擬檔路徑
        public static String simulationFileName = "";              //模擬檔名稱

          public static void Initialize()
        {
            RoadManager = new RoadManager();
            IntersectionManager = new IntersectionManager();
            DataManager = new DataManager();
            VehicleManager = new VehicleManager();

            mapPicturePath = "";
            mapFilePath = "";
            mapFileFolder = "";
            simulationFileName = "";
            simulationFilePath = "";

            simulatorRun = false;
            simulatorStarted = false;

            mapFileReaded = false;
            simulationFileReaded = false;
            RestartSimulationTime();
        }

        public static void RestartSimulationTime()
        {
            SimulationTime = 0;
        }

        public static void setSimulationRate(int rate)
        {
            simulationSpeedRate = rate;
        }

        public static void setCurrentTime(int second)
        {
            SimulationTime = second;
        }

        public static void setCurrentTime(int hour, int minute, int second)
        {
            SimulationTime = (second + minute * 60 + hour * 3600);
        }

        public static string getCurrentTime()
        {
            int hour = SimulationTime / 3600;

            int minute = (SimulationTime % 3600) / 60;

            int second = (SimulationTime % 3600) % 60;

            return ToSimulatorTimeFormat(hour,minute,second);
        }

        public static string ToSimulatorTimeFormat(int hour,int minute,int second)
        {
            string time = "";
            if (hour < 10)
                time += "0" + hour + ":";
            else
                time += hour + ":";

            if (minute < 10)
                time += "0" + minute + ":";
            else
                time += minute + ":";

            if (second < 10)
                time += "0" + second;
            else
                time += second;

            return time;
        }
        public static string ToSimulatorTimeFormat_Second(int time_second)
        {
            int hour = time_second / 3600;
            int minute = (time_second % 3600) / 60;
            int second = time_second % 60;

            string time = "";
            if (hour < 10)
                time += "0" + hour + ":";
            else
                time += hour + ":";

            if (minute < 10)
                time += "0" + minute + ":";
            else
                time += minute + ":";

            if (second < 10)
                time += "0" + second;
            else
                time += second;

            return time;
        }

        public static void VehicleGraphicOn(int fps) 
        {
            vehicleGraphicFPS = fps;
        }
        public static void VehicleGraphicOff()
        {
            vehicleGraphicFPS = 0;
        }

        public static void TrafficSignalCountdownDisplay(Boolean isOn)
        {
            trafficSignalCountdownDisplay = isOn;
        }

        public static void IntersectionInformationUpdate(Boolean isOn)
        {
            intersectionInformation = isOn;
        }

        public static void RoadStateMark(Boolean isOn)
        {
            roadStateMark = isOn;
            Simulator.UI.splitContainer_main.Panel2.Refresh();
        }

    }
}
