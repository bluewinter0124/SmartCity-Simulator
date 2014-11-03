using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.GraphicUnit;
using System.Threading;
using SmartCitySimulator.SystemObject;
using SmartCitySimulator.Unit;
using System.Reflection;
using System.IO;


namespace SmartCitySimulator
{
    public partial class MainUI : Form
    {
        private SimulationFileRead readFile;
        public Graphics graphics;
        int vehicleGenerateCounter = 100;
        
        public MainUI()
        {
            InitializeComponent();
            PropertyInfo info = this.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            info.SetValue(this.splitContainer1.Panel2, true, null);
            info.SetValue(dataGridView_IntersectionsTrafficState, true, null);

            this.WindowState = FormWindowState.Maximized;
            splitContainer1.Panel2.AutoScroll = true;

            readFile = new SimulationFileRead();
            SimulatorInfoInitialize();

            MainTimer.Interval = 1000 / Simulator.simulationRate;
            MainTimer.Tick += new EventHandler(MainTimerTask);

            VehicleTimer.Interval = 1000 / Simulator.VehicleManager.vehicleRunPerSecond;
            VehicleTimer.Tick += new EventHandler(VehicleTimerTask);

            VehicleGraphicTimer.Interval = 1000 / Simulator.vehicleGraphicFPS;
            VehicleGraphicTimer.Tick += new EventHandler(VehicleGraphicTimerTask);

            UIInformationTimer.Interval = 1000 / Simulator.UIGraphicFPS;
            UIInformationTimer.Tick += new EventHandler(UIInformationTimerTask);
        }

        public void MainTimerTask(Object myObject,EventArgs myEventArgs)
        {
            Simulator.RoadManager.CheckVehicleGenerationSchedule();
            Simulator.IntersectionManager.AllIntersectionCountDown();

            if (vehicleGenerateCounter >= 6)
            {
                Simulator.VehicleManager.GenerateVehicle();
                vehicleGenerateCounter = 1;
            }
            else
            {
                vehicleGenerateCounter++;
            }

            Simulator.SimulationTime++;
            RefreshSimulationTime();
        }

        public void VehicleTimerTask(Object myObject, EventArgs myEventArgs)
        {
            /*Thread CTT = new Thread(Simulator.VehicleManager.AllVehicleRun);
            CTT.Start();*/
            Simulator.VehicleManager.AllVehicleRun(); //old
        }

        public void VehicleGraphicTimerTask(Object myObject, EventArgs myEventArgs)
        {
            Thread CGTT = new Thread(Simulator.VehicleManager.RefreshAllVehicleGraphic);
            CGTT.Start();
        }

        public void UIInformationTimerTask(Object myObject, EventArgs myEventArgs)
        {
            //Simulator.UI.RefreshRoadInfomation(1); //0 =  不計權重 , 1 = 計算權重 
        }

        private void toolStripButton_simRun_Click(object sender, EventArgs e)
        {
            SimulatorRun();
        }

        
        private void toolStripButton_simStop_Click(object sender, EventArgs e)
        {
            SimulatorStop();
        }

        private void OpenMapFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_map = new OpenFileDialog();
            openFileDialog_map.Filter = "Map Files|*.txt";
            openFileDialog_map.Title = "Select a MapDataFile";
            if (openFileDialog_map.ShowDialog() == DialogResult.OK)
            {
                MainTimer.Stop();
                VehicleTimer.Stop();
                VehicleGraphicTimer.Stop();
                UIInformationTimer.Stop();

                Simulator.Initialize();

                this.AddMessage("System", "開啟地圖檔 : " + openFileDialog_map.SafeFileName);
                Simulator.mapFilePath = openFileDialog_map.FileName;
                Simulator.mapFileName = openFileDialog_map.SafeFileName.Substring(0, openFileDialog_map.SafeFileName.LastIndexOf("."));
                Simulator.mapFileFolder = Simulator.mapFilePath.Substring(0, Simulator.mapFilePath.LastIndexOf("\\"));

                readFile.LoadMapFile();

                Simulator.RoadManager.MapFormation();

                Bitmap image = new Bitmap(Simulator.mapPicturePath);
                Simulator.UI.splitContainer1.Panel2.BackgroundImage = image;

                Simulator.mapFileRead = true;
                RefreshMapFileStatus();
            }
        }

        private void OpenSimulationConfigFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Simulator.mapFileRead)
            {
                OpenFileDialog openFileDialog_sim = new OpenFileDialog();
                openFileDialog_sim.Filter = "Simulation Files|*.txt";
                openFileDialog_sim.Title = "Select a Simulation File";

                if (openFileDialog_sim.ShowDialog() == DialogResult.OK)
                {
                    Simulator.DataManager.InitializeDataManager(); //一定要先初始化DM
                    Simulator.IntersectionManager.InitializeIntersectionsManager();
                    Simulator.RoadManager.InitializeRoadsManager();
                    Simulator.VehicleManager.InitializeVehicleManager();
                    IntersectionStateInitialize();

                    this.AddMessage("System", "開啟模擬檔 " + openFileDialog_sim.SafeFileName);
                    Simulator.simulationFilePath = openFileDialog_sim.FileName;
                    Simulator.simulationFileName = openFileDialog_sim.SafeFileName;

                    readFile.LoadSimulationFile();

                    Simulator.simulationConfigRead = true;

                    Simulator.IntersectionManager.InitializeLightStates();

                    Simulator.PrototypeManager.ProtypeInitialize();

                    RefreshSimulationConfigFileStatus();

                    Simulator.RestartSimulationTime();
                }
            }
            else
            {
                this.AddMessage("System", "請先開啟地圖檔，點選檔案或上方地圖檔讀取之紅色圖示");
            }

        }

        private void toolStripButton_TrafficLightConfig_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationConfigRead)
            {
                TrafficLightConfig form = new TrafficLightConfig(0);
                form.Show();
            }
            else
            {
                this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_IntersectionConfig_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationConfigRead)
            {
                IntersectionConfig form = new IntersectionConfig(0);
                form.Show();
            }
            else
            {
                this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_VehicleGenerateConfig_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationConfigRead)
            {
                VehicleConfig form = new VehicleConfig();
                form.Show();
            }
            else
            {
                this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_TrafficDataDisplay_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationConfigRead)
            {
                TrafficDataDisplay form = new TrafficDataDisplay();
                form.Show();
            }
            else
            {
                this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_SimulatorConfig_Click(object sender, EventArgs e)
        {
                SimulatorConfig form = new SimulatorConfig();
                form.Show();
        }
        public void SimulatorRun()
        {
            if (Simulator.simulationConfigRead)
            {
                Simulator.UI.AddMessage("System", "Simulator Run");

                Simulator.simulatorRun = true;
                Simulator.simulatorStarted = true;

                MainTimer.Start();
                VehicleTimer.Start();
                VehicleGraphicTimer.Start();
                UIInformationTimer.Start();

                Simulator.PrototypeManager.PrototypeStart();
            }
        }

        public void SimulatorStop()
        {
            if (Simulator.simulationConfigRead)
            {
                Simulator.UI.AddMessage("System", "Simulator Stop");

                Simulator.simulatorRun = false;

                MainTimer.Stop();
                VehicleTimer.Stop();
                VehicleGraphicTimer.Stop();
                UIInformationTimer.Stop();

                Simulator.PrototypeManager.PrototypeStop();
            }
        }

        private void toolStripSplitButton_SpeedAdjust_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            int simulationRate = int.Parse(click.Text);
            SetSimulationSpeed(simulationRate);
        }

        public void SetSimulationSpeed(int simulationRate)
        {
            Simulator.setSimulationRate(simulationRate);
            MainTimer.Interval = 1000 / Simulator.simulationRate;
        }

        public void SetVehicleRunPerSecond(int vehicleRunPerSecond)
        {
            VehicleTimer.Interval = 1000 / vehicleRunPerSecond;
        }

        public void SetVehicleGraphicFPS(int FPS)
        {
            Simulator.vehicleGraphicFPS = FPS;
            if (FPS == 0)
            {
                VehicleGraphicTimer.Stop();
            }
            else
            {
                VehicleGraphicTimer.Start();
                VehicleGraphicTimer.Interval = 1000 / FPS;
            }
        }

        public void SetUIGraphicFPS(int FPS)
        {
            UIInformationTimer.Interval = 1000 / FPS;
        }

        private void toolStripButton_Zoom_Click(object sender, EventArgs e)
        {
            if (!Simulator.FullScreen)
            {
                this.splitContainer1.Panel1Collapsed = true;
                Simulator.FullScreen = true;
                this.toolStripButton_Zoom.Image = global::SmartCitySimulator.Properties.Resources.Normal;
                this.toolStripButton_Zoom.Text = "正常模式";
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = false;
                Simulator.FullScreen = false;
                this.toolStripButton_Zoom.Image = global::SmartCitySimulator.Properties.Resources.Full;
                this.toolStripButton_Zoom.Text = "全螢幕模式";
            }
        }

        private void pictureBox_cameraLinkStatus_Click(object sender, EventArgs e)
        {
            Simulator.PrototypeManager.PrototypeManagerStart();
        }

        private void pictureBox_AILinkStatus_Click(object sender, EventArgs e)
        {
            if (Simulator.IntersectionManager.AIOptimazation)
            {
                Simulator.IntersectionManager.AIOff();
            }
            else
            {
                Simulator.IntersectionManager.AIOn();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Simulator.mapFileRead)
            {
                Simulator.simulatorStarted = false;
                SimulatorStop();
                vehicleGenerateCounter = 100;

                Simulator.simulatorRun = false;

                Simulator.DataManager.InitializeDataManager(); //一定要先初始化DM
                Simulator.IntersectionManager.InitializeIntersectionsManager();
                Simulator.RoadManager.InitializeRoadsManager();
                Simulator.VehicleManager.InitializeVehicleManager();
                IntersectionStateInitialize();

                readFile.LoadSimulationFile();

                Simulator.IntersectionManager.InitializeLightStates();

                Simulator.PrototypeManager.ProtypeInitialize();

                Simulator.RestartSimulationTime();
            }
        }

        private void toolStripButton_simulationMode_Click(object sender, EventArgs e)
        {
            this.SetSimulationSpeed(50);
            this.SetVehicleGraphicFPS(0);
        }

    }

}
