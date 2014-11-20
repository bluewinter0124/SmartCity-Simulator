using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemObject;
using SmartCitySimulator.Unit;
using System.Reflection;
using System.IO;
using System.Net;


namespace SmartCitySimulator
{
    public partial class MainUI : Form
    {
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

            VehicleRunningTimer.Interval = 1000 / Simulator.VehicleManager.vehicleRunPerSecond;
            VehicleRunningTimer.Tick += new EventHandler(VehicleRunningTimerTask);

            VehicleGraphicTimer.Interval = 1000 / Simulator.vehicleGraphicFPS;
            VehicleGraphicTimer.Tick += new EventHandler(VehicleGraphicTimerTask);
        }
        public void SimulatorInfoInitialize()
        {
            String strHostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostByName(strHostName);
            IPAddress localIP = iphostentry.AddressList[0];

            label_localIP.Text = ("IP : " + localIP.ToString());
            Console.WriteLine(localIP);
        }

        public void IntersectionStateInitialize()
        {
            this.dataGridView_IntersectionsTrafficState.Rows.Clear();
            int intersections = Simulator.IntersectionManager.CountIntersections();
            for (int i = 0; i < intersections; i++)
            {
                this.dataGridView_IntersectionsTrafficState.Rows.Add();
                this.dataGridView_IntersectionsTrafficState.Rows[i].Cells[0].Value = Simulator.IntersectionManager.GetIntersectionByID(i).intersectionID;
                this.dataGridView_IntersectionsTrafficState.Rows[i].Cells[1].Value = 0;
                this.dataGridView_IntersectionsTrafficState.Rows[i].Cells[2].Value = global::SmartCitySimulator.Properties.Resources.State_Green;
            }
        }

        //left 4 picture box
        private void OpenMapFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMapFile();
        }
        private void OpenSimulationConfigFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Simulator.mapFileRead)
            {
                OpenSimulationFile();
            }
            else
            {
                this.AddMessage("System", "請先開啟地圖檔，點選檔案或上方地圖檔讀取之紅色圖示");
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
        //left 4 picture box end 

        //toolStripButton
        private void toolStripButton_simRun_Click(object sender, EventArgs e)
        {
            SimulatorStart();
        }

        private void toolStripButton_simStop_Click(object sender, EventArgs e)
        {
            SimulatorStop();
        }

        private void toolStripButton_restart_Click(object sender, EventArgs e)
        {
            SimulatorRestart();
        }

        private void toolStripButton_autoSimulation_Click(object sender, EventArgs e)
        {
            AutoSimulation form = new AutoSimulation();
            form.Show();
            //AutoSimulation(300,600,5,true,true);
        }

        private void toolStripButton_mapEdit_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton_saveSimulationConfiguration_Click(object sender, EventArgs e)
        {

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

        private void toolStripButton_simulationMode_Click(object sender, EventArgs e)
        {
            this.SetSimulationSpeed(50);
            this.SetVehicleGraphicFPS(0);
            Simulator.TrafficSignalGraphicOff();
            SimulatorStart();
        }

        private void toolStripButton_demonstrationMode_Click(object sender, EventArgs e)
        {
            this.SetSimulationSpeed(1);
            this.SetVehicleGraphicFPS(20);
            Simulator.TrafficSignalGraphicOn();
            SimulatorStart();
        }

        private void toolStripSplitButton_SpeedAdjust_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            int simulationRate = int.Parse(click.Text);
            SetSimulationSpeed(simulationRate);
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

        //toolStripButton end

        //UI Refresh
        public void RefreshMapFileStatus()
        {
            if (Simulator.mapFileRead)
                this.pictureBox_mapFileStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Green;
            else
                this.pictureBox_mapFileStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Red;
        }

        public void RefreshSimulationConfigFileStatus()
        {
            if (Simulator.simulationConfigRead)
                this.pictureBox_simulationFileStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Green;
            else
                this.pictureBox_simulationFileStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Red;
        }

        public void RefreshPrototypeStatus()
        {
            if (Simulator.PrototypeManager.PrototypeConnected)
                this.pictureBox_prototypeStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Green;
            else
            {
                if (Simulator.PrototypeManager.WaittingConnection)
                    this.pictureBox_prototypeStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Yellow;
                else
                    this.pictureBox_prototypeStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Red;
            }
        }

        public void RefreshAIStatus()
        {
            if (Simulator.IntersectionManager.AIOptimazation)
                this.pictureBox_AILinkStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Green;
            else
                this.pictureBox_AILinkStatus.Image = global::SmartCitySimulator.Properties.Resources.State_Red;
        }
        public void RefreshSimulationTime()
        {
            this.label_simulationTime.Text = Simulator.getCurrentTime();
        }

        private delegate void RefreshRoadInfomationCallBack(int intersectionID, double IAWR, int state);
        public void RefreshIntersectionState(int intersectionID, double IAWR, int state)// 0 = noweight , 1 weight
        {
            if (this.InvokeRequired)
            {
                RefreshRoadInfomationCallBack myUpdate = new RefreshRoadInfomationCallBack(RefreshIntersectionState);
                this.Invoke(myUpdate, intersectionID, IAWR, state);
            }
            else
            {
                this.dataGridView_IntersectionsTrafficState.Rows[intersectionID].Cells[1].Value = IAWR;
                if (state == 0)
                    this.dataGridView_IntersectionsTrafficState.Rows[intersectionID].Cells[2].Value = global::SmartCitySimulator.Properties.Resources.State_Green;
                else if (state == 1)
                    this.dataGridView_IntersectionsTrafficState.Rows[intersectionID].Cells[2].Value = global::SmartCitySimulator.Properties.Resources.State_Yellow;
                else if (state == 2)
                    this.dataGridView_IntersectionsTrafficState.Rows[intersectionID].Cells[2].Value = global::SmartCitySimulator.Properties.Resources.State_Red;
            }
        }
        //UI Refresh end
    }

}
