using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SmartTrafficSimulator.SystemObject;

namespace SmartTrafficSimulator.SystemManagers
{
    class Simulator
    {
        public static Boolean TESTMODE = false;

        public static MainUI UI = null;
        static int SimulationTime = 0; //模擬器內時鐘(以秒為單位)

        //Managers
        public static RoadManager RoadManager = new RoadManager();
        public static IntersectionManager IntersectionManager = new IntersectionManager();
        public static VehicleManager VehicleManager = new VehicleManager();
        public static DataManager DataManager = new DataManager();
        public static PrototypeManager PrototypeManager = new PrototypeManager();
        public static TaskManager TaskManager = new TaskManager();
        public static AIManager AIManager = new AIManager();

        //Running information
        public static Boolean mapFileReaded = false;
        public static Boolean simulationFileReaded = false;
        public static Boolean simulatorRun = false;     //run or stop
        public static Boolean simulatorStarted = false; //startrd
        public static int simulationSpeedRate = 1;           //simulator speed up

        //Griphic related
        public static int vehicleGraphicFPS = 1;
        public static Boolean trafficSignalCountdownDisplay = true;
        public static Boolean intersectionInformation = true;
        public static int roadStateMark = 0; // 0 = none , 1 = greyscale , 2 = color (green,yellow,red)
        public static int markLineWidth = 25;
        public static Pen[,] markPens = 
        {
            {   //gray scale pens
                new Pen(Color.FromArgb(255, 230, 230, 230), markLineWidth),
                new Pen(Color.FromArgb(255, 150, 150, 150), markLineWidth),
                new Pen(Color.FromArgb(255, 50, 50, 50), markLineWidth)
            },
            {   //color pens
                new Pen(Color.FromArgb(120, 137, 255, 155), markLineWidth),
                new Pen(Color.FromArgb(120, 255, 228, 76), markLineWidth),
                new Pen(Color.FromArgb(120, 255, 35, 28), markLineWidth)
            }
        };


        //Window Size
        public static Boolean fullScreen = false;

        //Map size 
        public static double mapScale = 1; // 1 pixel = ? M
        public static int signalLength = 20;
        public static int signalWidth = 4;

        //Fill after read file
        public static String mapFilePath = "";                     //地圖檔路徑
        public static String mapFileFolder = "";                   //地圖檔所在資料夾
        public static String mapPictureName = "";              //地圖圖片檔名
        public static String mapPicturePath = "";           //地圖圖片路徑
        public static String mapFileName = "";                     //地圖檔名稱
        public static String mapName = "";   

        //public static String simulationFilePath = "";              //模擬檔路徑
        //public static String simulationFileName = "";              //模擬檔名稱

          public static void Initialize()
        {
            RoadManager = new RoadManager();
            IntersectionManager = new IntersectionManager();
            DataManager = new DataManager();
            VehicleManager = new VehicleManager();

            mapPicturePath = "";
            mapFilePath = "";
            mapFileFolder = "";

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

        public static void TimeTick()
        {
            SimulationTime++;
        }

        public static void setCurrentTime(int second)
        {
            SimulationTime = second;
        }

        public static void setCurrentTime(int hour, int minute, int second)
        {
            SimulationTime = (second + minute * 60 + hour * 3600);
        }

        public static int getCurrentTime()
        {
            return SimulationTime;
        }

        public static string getCurrentTime_Format()
        {
            int hour = SimulationTime / 3600;

            int minute = (SimulationTime % 3600) / 60;

            int second = (SimulationTime % 3600) % 60;

            return getTimeFormat(hour,minute,second);
        }

        public static string getTimeFormat(int hour,int minute,int second)
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
        public static string SecondToTimeFormat(int time_second)
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

        public static string getZoneRange_Format(int zone,int zoneSize)
        {
            int startTime =zone *  zoneSize;
            int endTime = ((zone + 1) *  zoneSize) - 1;
            string zoneRange = SecondToTimeFormat(startTime) + " ~ " + SecondToTimeFormat(endTime);

            return zoneRange;
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

        public static void RoadStateMark(int mode)
        {
            roadStateMark = mode;
            Simulator.UI.splitContainer_main.Panel2.Refresh();
        }

    }
}
