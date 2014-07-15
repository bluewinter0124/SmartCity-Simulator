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
        private ReadFile readFile;
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

            readFile = new ReadFile();
            SimulatorInfoInitialize();

            MainTimer.Interval = 500;
            MainTimer.Tick += new EventHandler(MainTimerTask);

            CarTimer.Interval = 50;
            CarTimer.Tick += new EventHandler(CarTimerTask);

            CarGraphicTimer.Interval = 1000;
            CarGraphicTimer.Tick += new EventHandler(CarGraphicTimerTask);

            UIInformationTimer.Interval = 500;
            UIInformationTimer.Tick += new EventHandler(UIInformationTimerTask);
        }

        public void MainTimerTask(Object myObject,EventArgs myEventArgs)
        {
            
            SimulatorConfiguration.IntersectionManager.AllIntersectionCountDown();

            if (carGenerateCounter >= 6)
            {
                SimulatorConfiguration.CarManager.GenerateCar();
                carGenerateCounter = 1;
            }
            else
            {
                carGenerateCounter++;
            }

            SimulatorConfiguration.simulationTime++;
        }

        public void CarTimerTask(Object myObject, EventArgs myEventArgs)
        {
            /*Thread CTT = new Thread(SimulatorConfiguration.CarManager.AllCarRun);
            CTT.Start();*/
            SimulatorConfiguration.CarManager.AllCarRun(); //old
        }

        public void CarGraphicTimerTask(Object myObject, EventArgs myEventArgs)
        {
            Thread CGTT = new Thread(SimulatorConfiguration.CarManager.AllCarRefresh);
            CGTT.Start();
        }

        public void UIInformationTimerTask(Object myObject, EventArgs myEventArgs)
        {
            SimulatorConfiguration.UI.RefreshRoadInfomation(1); //0 =  不計權重 , 1 = 計算權重 
        }

        private void toolStripButton_simRun_Click(object sender, EventArgs e)
        {
            SimulatorConfiguration.UI.AddMessage("System", "Simulator Start");

            SimulatorConfiguration.simulatorRun = true;
            SimulatorConfiguration.simulatorStarted = true;
            MainTimer.Start();
            CarTimer.Start();
            CarGraphicTimer.Start();
            UIInformationTimer.Start();

            SimulatorConfiguration.PrototypeManager.PrototypeStart();
        }

        private void toolStripButton_simStop_Click(object sender, EventArgs e)
        {
            SimulatorConfiguration.UI.AddMessage("System", "Simulator Stop");

            SimulatorConfiguration.simulatorRun = false;
            MainTimer.Stop();
            CarTimer.Stop();
            CarGraphicTimer.Stop();
            UIInformationTimer.Stop();

            SimulatorConfiguration.PrototypeManager.PrototypeStop();
        }


        private void 開啟地圖檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_map = new OpenFileDialog();
            openFileDialog_map.Filter = "Map Files|*.txt";
            openFileDialog_map.Title = "Select a MapDataFile";
            if (openFileDialog_map.ShowDialog() == DialogResult.OK)
            {
                this.AddMessage("System", "開啟地圖檔 " + openFileDialog_map.SafeFileName);
                SimulatorConfiguration.mapFilePath = openFileDialog_map.FileName;
               
                readFile.LoadMapFile();

                SimulatorConfiguration.RoadManager.AllRoadInitialize();

                Bitmap image = new Bitmap(SimulatorConfiguration.mapFilePicturePath);
                SimulatorConfiguration.UI.splitContainer1.Panel2.BackgroundImage = image;

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
                SimulatorConfiguration.simulationFilePath = openFileDialog_sim.FileName;
                readFile.LoadSimulationFile();
                ChangeSimulationFileStatus(true);
            }
        }

        private void setSimulatorSpeed(object sender, EventArgs e)
        {
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            if (click.Text.Equals("1/2"))
                SimulatorConfiguration.setSimulationSpeed(1);
            else
            {
                SimulatorConfiguration.setSimulationSpeed(int.Parse(click.Text));
            }

            MainTimer.Interval = 1000 / SimulatorConfiguration.simulationRate;
            //CarTimer.Interval = SimulatorConfiguration.SimulatoeSecond / 4;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TrafficLightSettingModify form = new TrafficLightSettingModify(0);
            form.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (!SimulatorConfiguration.FullScreen)
            {
                this.splitContainer1.Panel1Collapsed = true;
                SimulatorConfiguration.FullScreen = true;
                this.toolStripButton4.Image = global::SmartCitySimulator.Properties.Resources.Normal;
                this.toolStripButton4.Text = "正常模式";
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = false;
                SimulatorConfiguration.FullScreen = false;
                this.toolStripButton4.Image = global::SmartCitySimulator.Properties.Resources.Full;
                this.toolStripButton4.Text = "全螢幕模式";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            IntersectionSettingModify form = new IntersectionSettingModify(0);
            form.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CarGenerateModify form = new CarGenerateModify(0);
            form.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            IntersectionData form = new IntersectionData();
            form.ShowDialog();
        }

    }

}
