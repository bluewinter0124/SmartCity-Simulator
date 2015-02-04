using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SmartTrafficSimulator.GraphicUnit;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.Unit;
using System.Reflection;
using System.IO;
using System.Net;
using System.Xml;


namespace SmartTrafficSimulator
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();

            //Set double buffer
            PropertyInfo info = this.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            info.SetValue(this, true, null);
            info.SetValue(this.splitContainer_main.Panel2, true, null);
            info.SetValue(dataGridView_IntersectionsTrafficState, true, null);

            this.WindowState = FormWindowState.Maximized;
            splitContainer_main.Panel2.AutoScroll = true;

            SimulatorInfoInitialize();

            MainTimer.Interval = 1000 / Simulator.simulationSpeedRate;
            MainTimer.Tick += new EventHandler(MainTimerTask);

            VehicleRunningTimer.Interval = 1000 / Simulator.VehicleManager.vehicleRunPerSecond;
            VehicleRunningTimer.Tick += new EventHandler(VehicleRunningTimerTask);

            VehicleGraphicTimer.Interval = 1000 / Simulator.vehicleGraphicFPS;
            VehicleGraphicTimer.Tick += new EventHandler(VehicleGraphicTimerTask);
        }

        public void SimulatorInfoInitialize()
        {
            //Display host IP
            String strHostName = Dns.GetHostName();
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                if (ipaddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    label_localIP.Text = ("IP : " + ipaddress);
                    break;
                }
            }

        }

        public void IntersectionStateInitialize()
        {
            this.dataGridView_IntersectionsTrafficState.Rows.Clear();
            for (int i = 0; i < Simulator.IntersectionManager.CountIntersections(); i++)
            {
                this.dataGridView_IntersectionsTrafficState.Rows.Add();
                this.dataGridView_IntersectionsTrafficState.Rows[i].Cells[0].Value = Simulator.IntersectionManager.GetIntersectionByID(i).intersectionID;
                this.dataGridView_IntersectionsTrafficState.Rows[i].Cells[1].Value = 0;
                this.dataGridView_IntersectionsTrafficState.Rows[i].Cells[2].Value = new Bitmap(global::SmartTrafficSimulator.Properties.Resources.State_Green2, 25, 25);
            }
        }


        //left icon event
        private void OpenMapFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMapFile();
        }
        private void OpenSimulationConfigFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Simulator.mapFileReaded)
            {
                OpenSimulationFile();
            }
            else
            {
                this.AddMessage("System", "Must read the map file, Click the red icon on the left side to read it");
                //this.AddMessage("System", "請先開啟地圖檔，點選檔案或上方地圖檔讀取之紅色圖示");
            }
        }

        private void pictureBox_cameraLinkStatus_Click(object sender, EventArgs e)
        {
            Simulator.PrototypeManager.PrototypeManagerStart();
        }

        private void pictureBox_pictureBox_prototypeSync_Click(object sender, EventArgs e)
        {
            Simulator.PrototypeManager.PrototypeSynchronous();
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
        //left icon event end

        //Simulator Running buttons
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
            SimulatorReset();
        }

        private void toolStripButton_nextSimulation_Click(object sender, EventArgs e)
        {
            NextSimulationTask();
        }

        private void toolStripButton_mapEdit_Click(object sender, EventArgs e)
        {
            MapEditor form = new MapEditor();
            form.Show();
        }

        private void toolStripButton_SimulationTaskManagement_Click(object sender, EventArgs e)
        {
            AutoSimulation form = new AutoSimulation();
            form.Show();
        }

        private void toolStripButton_saveSimulationConfiguration_Click(object sender, EventArgs e)
        {

        }
        //Simulator Running buttons end

        //Simulation Config Tools
        private void toolStripButton_TrafficLightConfig_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                TrafficLightConfig form = new TrafficLightConfig(0);
                form.Show();
            }
            else
            {
                this.AddMessage("System", "Must read the simulation file, Click the red icon on the left side to read it");
                //this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_IntersectionConfig_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                IntersectionConfig form = new IntersectionConfig(0);
                form.Show();
            }
            else
            {
                this.AddMessage("System", "Must read the simulation file, Click the red icon on the left side to read it");
                //this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_VehicleGenerateConfig_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                VehicleConfig form = new VehicleConfig();
                form.Show();
            }
            else
            {
                this.AddMessage("System", "Must read the simulation file, Click the red icon on the left side to read it");
                //this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_TrafficDataDisplay_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                DataDisplay form = new DataDisplay();
                form.Show();
            }
            else
            {
                this.AddMessage("System", "Must read the simulation file, Click the red icon on the left side to read it");
                //this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_SimulatorConfig_Click(object sender, EventArgs e)
        {
                SimulatorConfig form = new SimulatorConfig();
                form.Show();
        }
        //Simulation Config Tools end

        //Simulator Tools
        private void toolStripButton_simulationMode_Click(object sender, EventArgs e)
        {
            this.SetSimulationSpeed(50);
            this.SetVehicleGraphicFPS(0);
            Simulator.TrafficSignalCountdownDisplay(false);
            Simulator.IntersectionInformationUpdate(false);
            Simulator.RoadStateMark(false);
            SimulatorStart();
        }

        private void toolStripButton_demonstrationMode_Click(object sender, EventArgs e)
        {
            this.SetSimulationSpeed(1);
            this.SetVehicleGraphicFPS(20);
            Simulator.TrafficSignalCountdownDisplay(true);
            Simulator.IntersectionInformationUpdate(true);
            Simulator.RoadStateMark(true);
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
            if (!Simulator.fullScreen)
            {
                this.splitContainer_main.Panel1Collapsed = true;
                Simulator.fullScreen = true;
                this.toolStripButton_Zoom.Image = global::SmartTrafficSimulator.Properties.Resources.Normal2;
                this.toolStripButton_Zoom.Text = "Normal Mode";
            }
            else
            {
                this.splitContainer_main.Panel1Collapsed = false;
                Simulator.fullScreen = false;
                this.toolStripButton_Zoom.Image = global::SmartTrafficSimulator.Properties.Resources.Full2;
                this.toolStripButton_Zoom.Text = "Wide Mode";
            }
        }

        //toolStripButton end

        //UI state refresh
        public void RefreshMapFileStatus()
        {
            if (Simulator.mapFileReaded)
                this.pictureBox_mapFileStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Green2;
            else
                this.pictureBox_mapFileStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
        }

        public void RefreshSimulationConfigFileStatus()
        {
            if (Simulator.simulationFileReaded)
                this.pictureBox_simulationFileStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Green2;
            else
                this.pictureBox_simulationFileStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
        }

        public void RefreshPrototypeStatus()
        {
            if (Simulator.PrototypeManager.PrototypeConnected)
            {
                this.pictureBox_prototypeStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Green2;
                this.pictureBox_prototypeSync.Image = global::SmartTrafficSimulator.Properties.Resources.Sync;
            }
            else
            {
                if (Simulator.PrototypeManager.WaittingConnection)
                {
                    this.pictureBox_prototypeStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Yellow2;
                }
                else
                {
                    this.pictureBox_prototypeStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
                }
                this.pictureBox_prototypeSync.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
            }
        }

        public void RefreshAIStatus()
        {
            if (Simulator.IntersectionManager.AIOptimazation)
                this.pictureBox_AILinkStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Green2;
            else
                this.pictureBox_AILinkStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
        }

        public void RefreshSimulationTime()
        {
            this.label_simulationTime.Text = Simulator.getCurrentTime();
        }
        //UI state refresh end


        private delegate void RefreshRoadInfomationCallBack(int intersectionID);
        public void RefreshIntersectionState(int intersectionID)
        {
            if (this.InvokeRequired)
            {
                RefreshRoadInfomationCallBack myUpdate = new RefreshRoadInfomationCallBack(RefreshIntersectionState);
                this.Invoke(myUpdate, intersectionID);
            }
            else
            {
                double IAWR = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).GetCurrentIAWR();
                int state = Simulator.IntersectionManager.GetIntersectionByID(intersectionID).GetCurrentTrafficState();

                //set IAWR
                this.dataGridView_IntersectionsTrafficState.Rows[intersectionID].Cells[1].Value = IAWR;

                //Set state 
                Bitmap statePic = new Bitmap(global::SmartTrafficSimulator.Properties.Resources.State_Green2, 25, 25);

                if (state == 1)
                    statePic = new Bitmap(global::SmartTrafficSimulator.Properties.Resources.State_Yellow2, 25, 25);
                else if (state == 2)
                    statePic = new Bitmap(global::SmartTrafficSimulator.Properties.Resources.State_Red2, 25, 25);

                this.dataGridView_IntersectionsTrafficState.Rows[intersectionID].Cells[2].Value = statePic;

                //Refresh mark
                this.splitContainer_main.Panel2.Refresh();
            }
        }

        private void GraphicArea_Paint(object sender, PaintEventArgs e)
        {
            //Road state mark(line)
            if (Simulator.simulatorRun && Simulator.roadStateMark)
            {
                int lineWidth = 20;

                foreach (Intersection inter in Simulator.IntersectionManager.GetIntersectionList())
                {
                    Pen linePen = new Pen(Color.FromArgb(120, 137, 255, 155), lineWidth);

                    //Set Pen Color
                    if (inter.GetCurrentTrafficState() == 1)
                        linePen = new Pen(Color.FromArgb(120, 255, 228, 76), lineWidth);
                    else if (inter.GetCurrentTrafficState() == 2)
                        linePen = new Pen(Color.FromArgb(120, 255, 35, 28), lineWidth);

                    //Draw Lines
                    foreach (Road road in inter.roadList)
                    {
                        for (int i = 0; i < road.roadNode.Count - 1; i++)
                        {
                            e.Graphics.DrawLine(linePen, road.roadNode[i], road.roadNode[i + 1]);
                        }
                    }
                }
            }//Road state mark(line) end


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SimulationFileWriter SFW = new SimulationFileWriter();
            SFW.SaveSimulationFile_XML();
        }

        //UI Refresh end
    }

}
