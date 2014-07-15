using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCitySimulator.Unit;
using System.Drawing;
using SmartCitySimulator.GraphicUnit;

namespace SmartCitySimulator.SystemUnit
{
    class SimulatorConfiguration
    {
        public static MainUI UI = null;
        public static PrototypeManager prototypeConnector = null;

        public static Boolean simulatorRun = false; //SIM是否暫停
        public static Boolean simulatorStarted = false;//是否開始執行

        public static int simulationTime = 0; //模擬器內時間計數器
        public static int simulationRate = 1; //模擬倍速

        public static Boolean FullScreen = false;

        public static String mapFilePicturePath = ""; //地圖名稱
        public static String mapFilePath = "";
        public static int mapScale = 0;
        public static String simulationFile = ""; // 模擬檔名稱
        public static String simulationFilePath = "";

        public static RoadManager RoadManager= new RoadManager();
        public static IntersectionManager IntersectionManager = new IntersectionManager();
        public static CarManager CarManager = new CarManager();
        public static PrototypeManager PrototypeManager = new PrototypeManager();

        //public static MapInfo MapInfo = null;

        public static Image[] light_image = 
        {
            SmartCitySimulator.Properties.Resources.Light_Red, 
            SmartCitySimulator.Properties.Resources.Light_Green1, 
            SmartCitySimulator.Properties.Resources.Light_Yellow 
        };

        public static int carLength = 30;
        public static int carWidth = 15;

        public static int LightLength = 50;
        public static int LightWidth = 5;

        public static Boolean InitialIntersection = false;


        public static void setSimulationSpeed(int speed)
        {
            simulationRate = speed;
        }

    }
}
