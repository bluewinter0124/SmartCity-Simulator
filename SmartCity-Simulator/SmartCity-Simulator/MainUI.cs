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
using SmartCitySimulator.SystemUnit;
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
            info.SetValue(dataGridView_RoadState, true, null);

            this.WindowState = FormWindowState.Maximized;
            splitContainer1.Panel2.AutoScroll = true;

            readFile = new SimulationFileRead();
            SimulatorInfoInitialize();

            MainTimer.Interval = 1000 / Simulator.simulationRate;
            MainTimer.Tick += new EventHandler(MainTimerTask);

            CarTimer.Interval = 1000 / Simulator.carRunPerSecond;
            CarTimer.Tick += new EventHandler(CarTimerTask);

            CarGraphicTimer.Interval = 1000 / Simulator.carGraphicFrameRate;
            CarGraphicTimer.Tick += new EventHandler(CarGraphicTimerTask);

            UIInformationTimer.Interval = 1000 / Simulator.UIGraphicFrameRate;
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

            Simulator.simulatorTime++;
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
            Simulator.UI.RefreshRoadInfomation(1); //0 =  不計權重 , 1 = 計算權重 
        }

        private void toolStripButton_simRun_Click(object sender, EventArgs e)
        {
            Simulator.UI.AddMessage("System", "Simulator Start");

            Simulator.simulatorRun = true;
            Simulator.simulatorStarted = true;
            MainTimer.Start();
            CarTimer.Start();
            CarGraphicTimer.Start();
            UIInformationTimer.Start();

            Simulator.PrototypeManager.PrototypeStart();
        }

        private void toolStripButton_simStop_Click(object sender, EventArgs e)
        {
            Simulator.UI.AddMessage("System", "Simulator Stop");

            Simulator.simulatorRun = false;
            MainTimer.Stop();
            CarTimer.Stop();
            CarGraphicTimer.Stop();
            UIInformationTimer.Stop();

            Simulator.PrototypeManager.PrototypeStop();
        }


        private void 開啟地圖檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_map = new OpenFileDialog();
            openFileDialog_map.Filter = "Map Files|*.txt";
            openFileDialog_map.Title = "Select a MapDataFile";
            if (openFileDialog_map.ShowDialog() == DialogResult.OK)
            {
                this.AddMessage("System", "開啟地圖檔 " + openFileDialog_map.SafeFileName);
                Simulator.mapFilePath = openFileDialog_map.FileName;
               
                readFile.LoadMapFile();

                Simulator.RoadManager.AllRoadInitialize();

                Bitmap image = new Bitmap(Simulator.mapFilePicturePath);
                Simulator.UI.splitContainer1.Panel2.BackgroundImage = image;

                ChangeMapFileStatus(true);
            }
        }

        private void 開啟模擬設定檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_sim = new OpenFileDialog();
            openFileDialog_sim.Filter = "Simulation Files|*.txt";
            openFileDialog_sim.Title = "Select a Simulation File";
            
            if (openFileDialog_sim.ShowDialog() == DialogResult.OK)
            {
                this.AddMessage("System", "開啟模擬檔 " + openFileDialog_sim.SafeFileName);
                Simulator.simulationFilePath = openFileDialog_sim.FileName;
                readFile.LoadSimulationFile();
                ChangeSimulationFileStatus(true);
            }
        }

        private void toolStripButton_TrafficLightConfig_Click(object sender, EventArgs e)
        {
            TrafficLightConfig form = new TrafficLightConfig(0);
            form.ShowDialog();
        }

        private void toolStripButton_IntersectionConfig_Click(object sender, EventArgs e)
        {
            IntersectionConfig form = new IntersectionConfig(0);
            form.ShowDialog();
        }

        private void toolStripButton_CarGenerateConfig_Click(object sender, EventArgs e)
        {
            CarGenerateConfig form = new CarGenerateConfig(0);
            form.ShowDialog();
        }

        private void setSimulatorSpeed(object sender, EventArgs e)
        {
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            Simulator.setSimulationRate(int.Parse(click.Text));

            MainTimer.Interval = 1000 / Simulator.simulationRate;
        }

        private void toolStripButton_TrafficDataDisplay_Click(object sender, EventArgs e)
        {
            TrafficDataDisplay form = new TrafficDataDisplay();
            form.ShowDialog();
        }

        private void toolStripButton_SimulatorConfig_Click(object sender, EventArgs e)
        {

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
    }

}
