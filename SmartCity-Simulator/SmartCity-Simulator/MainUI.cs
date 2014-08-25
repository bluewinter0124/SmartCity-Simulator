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
using SmartCitySimulator.SystemManagers;
using SmartCitySimulator.Unit;
using System.Reflection;


namespace SmartCitySimulator
{
    public partial class MainUI : Form
    {
        private SimulationFileRead readFile;
        public Graphics graphics;
        int carGenerateCounter = 100;
        
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

            CarTimer.Interval = 1000 / Simulator.CarManager.carRunPerSecond;
            CarTimer.Tick += new EventHandler(CarTimerTask);

            CarGraphicTimer.Interval = 1000 / Simulator.carGraphicFPS;
            CarGraphicTimer.Tick += new EventHandler(CarGraphicTimerTask);

            UIInformationTimer.Interval = 1000 / Simulator.UIGraphicFPS;
            UIInformationTimer.Tick += new EventHandler(UIInformationTimerTask);
        }

        public void MainTimerTask(Object myObject,EventArgs myEventArgs)
        {
            
            Simulator.IntersectionManager.AllIntersectionCountDown();

            if (carGenerateCounter >= 6)
            {
                Simulator.CarManager.GenerateCar();
                carGenerateCounter = 1;
            }
            else
            {
                carGenerateCounter++;
            }

            Simulator.SimulationTime++;
            RefreshSimulationTime();
        }

        public void CarTimerTask(Object myObject, EventArgs myEventArgs)
        {
            /*Thread CTT = new Thread(Simulator.CarManager.AllCarRun);
            CTT.Start();*/
            Simulator.CarManager.AllCarRun(); //old
        }

        public void CarGraphicTimerTask(Object myObject, EventArgs myEventArgs)
        {
            Thread CGTT = new Thread(Simulator.CarManager.RefreshAllCarGraphic);
            CGTT.Start();
        }

        public void UIInformationTimerTask(Object myObject, EventArgs myEventArgs)
        {
            //Simulator.UI.RefreshRoadInfomation(1); //0 =  不計權重 , 1 = 計算權重 
        }

        private void toolStripButton_simRun_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationConfigRead)
            {
                Simulator.UI.AddMessage("System", "Simulator Start");

                Simulator.simulatorRun = true;

                MainTimer.Start();
                CarTimer.Start();
                CarGraphicTimer.Start();
                UIInformationTimer.Start();

                Simulator.PrototypeManager.PrototypeStart();
            }
        }

        private void toolStripButton_simStop_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationConfigRead)
            {
                Simulator.UI.AddMessage("System", "Simulator Stop");

                Simulator.simulatorRun = false;

                MainTimer.Stop();
                CarTimer.Stop();
                CarGraphicTimer.Stop();
                UIInformationTimer.Stop();

                Simulator.PrototypeManager.PrototypeStop();
            }
        }

        private void OpenMapFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_map = new OpenFileDialog();
            openFileDialog_map.Filter = "Map Files|*.txt";
            openFileDialog_map.Title = "Select a MapDataFile";
            if (openFileDialog_map.ShowDialog() == DialogResult.OK)
            {
                MainTimer.Stop();
                CarTimer.Stop();
                CarGraphicTimer.Stop();
                UIInformationTimer.Stop();

                Simulator.Initialize();

                this.AddMessage("System", "開啟地圖檔 " + openFileDialog_map.SafeFileName);
                Simulator.mapFilePath = openFileDialog_map.FileName;
               
                readFile.LoadMapFile();

                Simulator.RoadManager.MapFormation();

                Bitmap image = new Bitmap(Simulator.mapFilePicturePath);
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
                    Simulator.CarManager.InitializeCarManager();
                    IntersectionStateInitialize();

                    this.AddMessage("System", "開啟模擬檔 " + openFileDialog_sim.SafeFileName);
                    Simulator.simulationFilePath = openFileDialog_sim.FileName;
                    
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

        private void toolStripButton_CarGenerateConfig_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationConfigRead)
            {
                CarConfig form = new CarConfig();
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

        private void SetSimulatorSpeed(object sender, EventArgs e)
        {
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            Simulator.setSimulationRate(int.Parse(click.Text));

            MainTimer.Interval = 1000 / Simulator.simulationRate;
        }

        public void SetCarRunPerSecond(int carRunPerSecond)
        {
            CarTimer.Interval = 1000 / carRunPerSecond;
        }

        public void SetCarGraphicFPS(int FPS)
        {
            CarGraphicTimer.Interval = 1000 / FPS;
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
                Simulator.DataManager.InitializeDataManager(); //一定要先初始化DM
                Simulator.IntersectionManager.InitializeIntersectionsManager();
                Simulator.RoadManager.InitializeRoadsManager();
                Simulator.CarManager.InitializeCarManager();
                IntersectionStateInitialize();

                readFile.LoadSimulationFile();

                Simulator.IntersectionManager.InitializeLightStates();

                Simulator.PrototypeManager.ProtypeInitialize();

                Simulator.RestartSimulationTime();
            }
        }

    }

}
