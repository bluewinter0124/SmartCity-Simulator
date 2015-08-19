using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Net;
using System.Xml;
using SmartTrafficSimulator.Models;
using SmartTrafficSimulator.UI;
using SmartTrafficSimulator.SystemObject;
using SmartTrafficSimulator.OptimizationModels;
using SmartTrafficSimulator.SystemManagers;


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

            VehicleRunningTimer.Interval = 1000;
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

        public void IntersectionStatusInitialize()
        {
            this.dataGridView_IntersectionsTrafficState.Rows.Clear();
            for (int i = 0; i < Simulator.IntersectionManager.GetNumberOfIntersections(); i++)
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
        private void OpenSimulationFile_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Simulator.mapFileReaded)
            {
                OpenSimulationFile();
            }
            else
            {
                this.AddMessage("System", "Must read the map file, Click the red icon on the left side to read it");
            }
        }

        private void pictureBox_newSimulation_Click(object sender, EventArgs e)
        {
            if (Simulator.mapFileReaded)
            {
                NewSimulationFile();
            }
            else
            {
                this.AddMessage("System", "Must read the map file, Click the red icon on the left side to read it");
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
            if (Simulator.AIManager.trafficOptimazation)
            {
                Simulator.AIManager.AIOff();
            }
            else
            {
                Simulator.AIManager.AIOn();
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
            SimulationReset();
        }

        private void toolStripButton_nextSimulation_Click(object sender, EventArgs e)
        {
            ToNextSimulationTask();
        }

        private void toolStripButton_mapEdit_Click(object sender, EventArgs e)
        {
            MapEditor form = new MapEditor();
            form.Show();
        }

        private void toolStripButton_simulationTaskManagement_Click(object sender, EventArgs e)
        {
            AutoSimulation form = new AutoSimulation();
            form.Show();
        }

        private void toolStripButton_saveSimulationConfiguration_Click(object sender, EventArgs e)
        {
            SimulationFileWriter SFW = new SimulationFileWriter();
            SFW.SaveSimulationFile_XML();
        }
        //Simulator Running buttons end

        //Simulation Config Tools
        private void toolStripButton_trafficSignalConfig_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                TrafficSignalConfig form = new TrafficSignalConfig(0);
                form.Show();
            }
            else
            {
                this.AddMessage("System", "Must read the simulation file, Click the red icon on the left side to read it");
                //this.AddMessage("System", "請先開啟模擬檔，點選檔案或上方模擬檔讀取之紅色圖示");
            }
        }

        private void toolStripButton_intersectionConfig_Click(object sender, EventArgs e)
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

        private void toolStripButton_vehicleGenerateConfig_Click(object sender, EventArgs e)
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

        private void toolStripButton_trafficDataDisplay_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                TrafficDataDisplay form = new TrafficDataDisplay();
                form.Show();
            }
            else
            {
                this.AddMessage("System", "Must read the simulation file, Click the red icon on the left side to read it");
            }
        }
        private void toolStripButton_vehicleDataDisplay_Click(object sender, EventArgs e)
        {
            if (Simulator.simulationFileReaded)
            {
                VehicleDataDisplay form = new VehicleDataDisplay();
                form.Show();
            }
            else
            {
                this.AddMessage("System", "Must read the simulation file, Click the red icon on the left side to read it");
            }
        }

        private void toolStripButton_simulatorConfig_Click(object sender, EventArgs e)
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
            Simulator.RoadStateMark(0);
            SimulatorStart();
        }

        private void toolStripButton_demonstrationMode_Click(object sender, EventArgs e)
        {
            this.SetSimulationSpeed(5);
            this.SetVehicleGraphicFPS(10);
            Simulator.TrafficSignalCountdownDisplay(true);
            Simulator.IntersectionInformationUpdate(true);
            Simulator.RoadStateMark(0);
            SimulatorStart();
        }

        private void toolStripSplitButton_speedAdjust_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            int simulationRate = int.Parse(click.Text);
            SetSimulationSpeed(simulationRate);
        }

        private void toolStripButton_zoom_Click(object sender, EventArgs e)
        {
            if (!Simulator.fullScreen)
            {
                this.splitContainer_main.Panel1Collapsed = true;
                Simulator.fullScreen = true;
                this.toolStripButton_zoom.Image = global::SmartTrafficSimulator.Properties.Resources.Normal2;
                this.toolStripButton_zoom.Text = "Normal Mode";
            }
            else
            {
                this.splitContainer_main.Panel1Collapsed = false;
                Simulator.fullScreen = false;
                this.toolStripButton_zoom.Image = global::SmartTrafficSimulator.Properties.Resources.Full2;
                this.toolStripButton_zoom.Text = "Wide Mode";
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

        public void RefreshSimulationFileStatus()
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
            if (Simulator.AIManager.trafficOptimazation)
                this.pictureBox_AILinkStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Green2;
            else
                this.pictureBox_AILinkStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
        }

        public void RefreshSimulationTime()
        {
            this.label_simulationTime.Text = Simulator.getCurrentTime_Format();
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
            if (Simulator.simulatorRun && Simulator.roadStateMark > 0)
            {
                foreach (Intersection inter in Simulator.IntersectionManager.GetIntersectionList())
                {
                    Pen linePen = Simulator.markPens[Simulator.roadStateMark-1, inter.GetCurrentTrafficState()];
                    
                    //Draw Lines
                    foreach (Road road in inter.roadList)
                    {
                        linePen.Width = System.Convert.ToInt16(road.roadWidth * 0.75);
                        for (int i = 0; i < road.roadNodeList.Count - 1; i++)
                        {
                            e.Graphics.DrawLine(linePen, road.roadNodeList[i], road.roadNodeList[i + 1]);
                        }
                    }
                }
            }//Road state mark(line) end


        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            AIConfig form = new AIConfig();
            form.Show();
        }

        private void toolStripButton_dataOutput_Click(object sender, EventArgs e)
        {
            DataOutput form = new DataOutput();
            form.Show();
        }

        //UI Refresh end
    }

}
