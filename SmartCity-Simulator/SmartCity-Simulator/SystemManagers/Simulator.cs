using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;
using System.Drawing;
using SmartCitySimulator.GraphicUnit;

namespace SmartCitySimulator.SystemManagers
{
    class Simulator
    {
        public static Boolean TESTMODE = false;

        public static MainUI UI = null;
        public static int SimulationTime = 0; //模擬器內時鐘(以秒為單位)

        //各個Manager
        public static RoadManager RoadManager = new RoadManager();
        public static IntersectionManager IntersectionManager = new IntersectionManager();
        public static VehicleManager CarManager = new VehicleManager();
        public static DataManager DataManager = new DataManager();
        public static PrototypeManager PrototypeManager = new PrototypeManager();

        //執行相關
        public static Boolean mapFileRead = false;
        public static Boolean simulationConfigRead = false;
        

        public static Boolean simulatorRun = false; //SIM是否暫停
        public static Boolean simulatorStarted = false;//是否開始執行
        public static int simulationRate = 1; //模擬倍速
        public static int carGraphicFPS = 1;
        public static int UIGraphicFPS = 2;

        //顯示相關
        public static Boolean FullScreen = false;

        //紅綠燈長寬
        public static int LightLength = 50;
        public static int LightWidth = 5;

        //File Read 執行後填入
        public static String mapFilePicturePath = ""; //地圖名稱
        public static String mapFilePath = "";
        public static String simulationFile = ""; // 模擬檔名稱
        public static String simulationFilePath = "";

          public static void Initialize()
        {
            RoadManager = new RoadManager();
            IntersectionManager = new IntersectionManager();
            DataManager = new DataManager();
            CarManager = new VehicleManager();

            mapFilePicturePath = "";
            mapFilePath = "";
            simulationFile = "";
            simulationFilePath = "";

            simulatorRun = false;

            simulatorStarted = false;

            mapFileRead = false;
            simulationConfigRead = false;
            RestartSimulationTime();
        }

        public static void RestartSimulationTime()
        {
            SimulationTime = 0;
        }

        public static void setSimulationRate(int rate)
        {
            simulationRate = rate;
        }

        public static string getCurrentTime()
        {
            int hour = SimulationTime / 3600;
            int minute = (SimulationTime % 3600) / 60;
            int second = (SimulationTime % 3600) % 60;
            string time = hour + " : " + minute + " : " + second;

            return time;
        }

    }
}
