using System;
using System.Windows.Forms;
using SmartTrafficSimulator.SystemObject;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using SmartTrafficSimulator.SystemManagers;
namespace SmartTrafficSimulator
{
    partial class MainUI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        int vehicleGenerateCounter = 100;

        public SimulationTask currentTask = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void MainTimerTask(Object myObject, EventArgs myEventArgs)
        {
            if (Simulator.getCurrentTime() == currentTask.simulationEndTime)
            {
                SimulationAccomplish();
            }

            Simulator.RoadManager.CheckVehicleGenerationSchedule();
            Simulator.IntersectionManager.AllIntersectionCountDown();

            if (vehicleGenerateCounter >= Simulator.VehicleManager.vehicleGenerateInterval)
            {
                Simulator.VehicleManager.GenerateVehicle();
                vehicleGenerateCounter = 1;
            }
            else
            {
                vehicleGenerateCounter++;
            }

            Simulator.TimeTick();
            RefreshSimulationTime();
        }

        public void VehicleRunningTimerTask(Object myObject, EventArgs myEventArgs)
        {
            Simulator.VehicleManager.AllVehicleRun();
        }

        public void VehicleGraphicTimerTask(Object myObject, EventArgs myEventArgs)
        {
            System.Threading.Thread CGTT = new System.Threading.Thread(Simulator.VehicleManager.RefreshAllVehicleGraphic);
            CGTT.Start();
        }

        public void SimulatorStart()
        {
            if (currentTask == null)
            {
                ToNextSimulationTask();
            }
            else if (!Simulator.simulatorRun && currentTask != null)
            {
                Simulator.UI.AddMessage("System", "Simulator Start");

                Simulator.simulatorRun = true;
                Simulator.simulatorStarted = true;

                MainTimer.Start();
                VehicleRunningTimer.Start();
                VehicleGraphicTimer.Start();

                Simulator.PrototypeManager.PrototypeStart();
            }
        }

        public void SimulatorStop()
        {
            if (Simulator.simulationFileReaded && Simulator.simulatorRun)
            {
                Simulator.UI.AddMessage("System", "Simulator Stop");

                Simulator.simulatorRun = false;

                MainTimer.Stop();
                VehicleRunningTimer.Stop();
                VehicleGraphicTimer.Stop();

                Simulator.PrototypeManager.PrototypeStop();
            }
        }

        public void SimulationInitialize()
        {
            Simulator.DataManager.InitializeSummaryData();
            SimulationReset();
        }

        public void SimulationReset()
        {
            if (Simulator.mapFileReaded && currentTask != null)
            {
                SimulatorStop();

                Simulator.simulatorStarted = false;
                Simulator.simulatorRun = false;

                Simulator.VehicleManager.InitializeVehicleManager();
                Simulator.DataManager.InitializeDataManager(); //一定要先初始化DM
                Simulator.IntersectionManager.InitializeIntersections_Simulation();
                Simulator.RoadManager.InitializeRoads_Simulation();
                Simulator.PrototypeManager.InitialProtype();

                vehicleGenerateCounter = 100;
                IntersectionStatusInitialize();

                if (currentTask.simulationFilePath.Equals(""))
                {
                    Simulator.simulationFileReaded = true;
                }
                else
                {
                    SimulatorFileReader sfr = new SimulatorFileReader();
                    Simulator.simulationFileReaded = sfr.SimulationFileRead_XML(currentTask.simulationFilePath);
                }

                Simulator.setCurrentTime(currentTask.simulationStartTime);
      
                this.RefreshSimulationTime();
                this.RefreshSimulationFileStatus();
            }
        }

        public void SetSimulationTask(SimulationTask simulationTask) //set auto simulation config  
        {
            if (!simulationTask.simulationFilePath.Equals(""))
                Simulator.UI.AddMessage("System", "Load new simulation task , Simulation name : " + simulationTask.simulationName);

            this.currentTask = simulationTask;
            this.currentTask.TaskStart();
            SimulationInitialize();
        }

        public void SimulationAccomplish()
        {
            SimulatorStop();

            Simulator.DataManager.DataSaveAsExcel
            (
                currentTask.saveTrafficRecord, 
                currentTask.saveOptimizationRecord, 
                currentTask.saveIntersectionStatus, 
                currentTask.saveVehicleData
            );

            currentTask.completeTimes++;

            Simulator.UI.AddMessage("System", "Simulation complete (" + currentTask.completeTimes + "/" + currentTask.repeatTimes + ")");

            if (currentTask.completeTimes < currentTask.repeatTimes || currentTask.repeatTimes == -1) //simulation task uncompleted
            {
                SimulationReset();
                SimulatorStart();
            }
            else // task finished , next task
            {
                this.currentTask.TaskFinish();
                Simulator.DataManager.SummaryDataSaveAsExcel
                (
                    currentTask.saveTrafficRecord,
                    currentTask.saveOptimizationRecord,
                    currentTask.saveIntersectionStatus,
                    currentTask.saveVehicleData
                );

                ToNextSimulationTask();
            }
        }

        public void ToNextSimulationTask()
        {
            if (currentTask != null)
            {
                this.currentTask.TaskFinish();
            }

            SimulationTask nextTask = Simulator.TaskManager.GetNextSimulationTask();

            if (nextTask != null)
            {
                SetSimulationTask(nextTask);
                SimulatorStart();
            }
            else
            {
                SimulatorStop();
            }
        }

        public void OpenMapFile()
        {
            OpenFileDialog openFileDialog_map = new OpenFileDialog();
            openFileDialog_map.Filter = "Map Files|*.xml";
            openFileDialog_map.Title = "Select a MapDataFile";
            if (openFileDialog_map.ShowDialog() == DialogResult.OK)
            {
                //Terminate current simulation
                MainTimer.Stop();
                VehicleRunningTimer.Stop();
                VehicleGraphicTimer.Stop();

                //Initial environment
                Simulator.Initialize();
                Simulator.TaskManager.Initialize();

                //Read map file 
                Simulator.mapFilePath = openFileDialog_map.FileName;
                Simulator.mapFileName = openFileDialog_map.SafeFileName.Substring(0, openFileDialog_map.SafeFileName.LastIndexOf("."));
                Simulator.mapFileFolder = Simulator.mapFilePath.Substring(0, Simulator.mapFilePath.LastIndexOf("\\"));

                SimulatorFileReader sfr = new SimulatorFileReader();
                if (Simulator.mapFileReaded = sfr.MapFileRead_XML(openFileDialog_map.FileName))
                {
                    this.AddMessage("System", "Read map file : " + openFileDialog_map.SafeFileName + " success!");

                    Simulator.RoadManager.InitializeRoads_Map();
                    Simulator.IntersectionManager.InitializeIntersections_Map();
                }
                else
                {
                    this.AddMessage("System", "Read map file : " + openFileDialog_map.SafeFileName + " fail,the format may be wrong");
                }
                RefreshMapFileStatus();
            }
        }

        public void OpenSimulationFile()
        { 
            OpenFileDialog openFileDialog_sim = new OpenFileDialog();
            openFileDialog_sim.Filter = "Simulation Files|*.xml";
            openFileDialog_sim.Title = "Select a Simulation File";

            if (openFileDialog_sim.ShowDialog() == DialogResult.OK)
            {
                SimulationTask newTask = new SimulationTask(openFileDialog_sim.FileName, 0, 86400, -1, false, false,false,false);
                Simulator.TaskManager.SetCurrentTask(newTask);
                SetSimulationTask(newTask);
            }
        }

        public void NewSimulationFile()
        {
            SimulationTask newTask = new SimulationTask("", 0, 86400, -1, false, false, false, false);
            Simulator.TaskManager.SetCurrentTask(newTask);
            SetSimulationTask(newTask);
        }

        public void SetMapBackground(String mapPicturePath)
        {
            if (File.Exists(mapPicturePath))
            {
                Bitmap image = new Bitmap(mapPicturePath);
                Simulator.UI.splitContainer_main.Panel2.BackgroundImage = image;
            }
        }

        public void SetSimulationSpeed(int simulationRate)
        {
            Simulator.setSimulationRate(simulationRate);
            MainTimer.Interval = 1000 / simulationRate;
            VehicleRunningTimer.Interval = 1000 / simulationRate;
        }

        public void SetVehicleRunTask(int vehicleRunPerSecond)
        {
            VehicleRunningTimer.Interval = 1000 / vehicleRunPerSecond;
        }

        public void SetVehicleGraphicFPS(int FPS)
        {
            if (FPS == 0)
            {
                VehicleGraphicTimer.Stop();
                Simulator.VehicleGraphicOff();
            }
            else
            {
                VehicleGraphicTimer.Start();
                VehicleGraphicTimer.Interval = 1000 / FPS;
                Simulator.VehicleGraphicOn(FPS);
            }
        }

        private delegate void AddMessageCallBack(String messageType, string input);
        public void AddMessage(String messageType, string input)
        {
            if (this.InvokeRequired)
            {
                AddMessageCallBack myUpdate = new AddMessageCallBack(AddMessage);
                this.Invoke(myUpdate, messageType, input);
            }
            else
            {
                switch (messageType)
                {
                    case "Prototype":
                        this.textBox_prototype.AppendText(input + "\n");
                        break;
                    case "AI":
                        this.textBox_AI.AppendText(input + "\n");
                        break;
                    case "System":
                        this.textBox_system.AppendText(input + "\n");
                        break;
                }
                this.textBox_all.AppendText(messageType + " : " + input + "\n");
            }
        }

        private delegate void AddVehicleCallBack(Vehicle vehicle);
        public void AddVehicle(Vehicle vehicle)
        {
            if (this.InvokeRequired)
            {
                AddVehicleCallBack myAddVehicle = new AddVehicleCallBack(AddVehicle);
                this.Invoke(myAddVehicle, vehicle);
            }
            else
            {             
                if(Simulator.vehicleGraphicFPS > 0)
                    this.splitContainer_main.Panel2.Controls.Add(vehicle);
            }
        }

        private delegate void RemoveVehicleCallBack(Vehicle vehicle);
        public void RemoveVehicle(Vehicle vehicle)
        {
            if (this.InvokeRequired)
            {
                RemoveVehicleCallBack myRemoveVehicle = new RemoveVehicleCallBack(RemoveVehicle);
                this.Invoke(myRemoveVehicle, vehicle);
            }
            else
            {
                    this.splitContainer_main.Panel2.Controls.Remove(vehicle);
            }
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer_main = new System.Windows.Forms.SplitContainer();
            this.groupBox_system = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MapFileStatus = new System.Windows.Forms.Label();
            this.pictureBox_mapFileStatus = new System.Windows.Forms.PictureBox();
            this.label_localIP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AiLinkStatus = new System.Windows.Forms.Label();
            this.label_simulationTime = new System.Windows.Forms.Label();
            this.cameraLinkStatus = new System.Windows.Forms.Label();
            this.pictureBox_AILinkStatus = new System.Windows.Forms.PictureBox();
            this.pictureBox_prototypeStatus = new System.Windows.Forms.PictureBox();
            this.simulationFileStatus = new System.Windows.Forms.Label();
            this.pictureBox_prototypeSync = new System.Windows.Forms.PictureBox();
            this.pictureBox_simulationFileStatus = new System.Windows.Forms.PictureBox();
            this.pictureBox_newSimulation = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView_IntersectionsTrafficState = new System.Windows.Forms.DataGridView();
            this.IntersectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IAWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrafficFlowState = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl_Message = new System.Windows.Forms.TabControl();
            this.tabPage_All = new System.Windows.Forms.TabPage();
            this.textBox_all = new System.Windows.Forms.TextBox();
            this.tabPage_System = new System.Windows.Forms.TabPage();
            this.textBox_system = new System.Windows.Forms.TextBox();
            this.tabPage_Prototype = new System.Windows.Forms.TabPage();
            this.textBox_prototype = new System.Windows.Forms.TextBox();
            this.tabPage_AI = new System.Windows.Forms.TabPage();
            this.textBox_AI = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip_Main = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.開啟ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地圖ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟模擬檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.離開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.結束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.路口設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.燈號設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStrip_main = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_start = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_pause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_restart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_nextSimulation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton_speedAdjust = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_mapEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_simulationTaskManagement = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_saveSimulationConfiguration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_trafficSignalConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_intersectionConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_vehicleRelatedConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_trafficDataDisplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_vehicleDataDisplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_dataOutput = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_simulationMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_demonstrationMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_zoom = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_simulatorConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟地圖檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開啟模擬設定檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_Run = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Stop = new System.Windows.Forms.ToolStripButton();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.VehicleRunningTimer = new System.Windows.Forms.Timer(this.components);
            this.VehicleGraphicTimer = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
            this.splitContainer_main.Panel1.SuspendLayout();
            this.splitContainer_main.SuspendLayout();
            this.groupBox_system.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapFileStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AILinkStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prototypeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prototypeSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_simulationFileStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_newSimulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionsTrafficState)).BeginInit();
            this.tabControl_Message.SuspendLayout();
            this.tabPage_All.SuspendLayout();
            this.tabPage_System.SuspendLayout();
            this.tabPage_Prototype.SuspendLayout();
            this.tabPage_AI.SuspendLayout();
            this.toolStrip_main.SuspendLayout();
            this.menuStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer_main
            // 
            this.splitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_main.Location = new System.Drawing.Point(0, 57);
            this.splitContainer_main.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer_main.Name = "splitContainer_main";
            // 
            // splitContainer_main.Panel1
            // 
            this.splitContainer_main.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer_main.Panel1.Controls.Add(this.groupBox_system);
            this.splitContainer_main.Panel1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.splitContainer_main.Panel1MinSize = 250;
            // 
            // splitContainer_main.Panel2
            // 
            this.splitContainer_main.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer_main.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer_main.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphicArea_Paint);
            this.splitContainer_main.Panel2MinSize = 800;
            this.splitContainer_main.Size = new System.Drawing.Size(1635, 663);
            this.splitContainer_main.SplitterDistance = 311;
            this.splitContainer_main.SplitterWidth = 8;
            this.splitContainer_main.TabIndex = 2;
            this.splitContainer_main.TabStop = false;
            // 
            // groupBox_system
            // 
            this.groupBox_system.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_system.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox_system.Controls.Add(this.tableLayoutPanel1);
            this.groupBox_system.Controls.Add(this.dataGridView_IntersectionsTrafficState);
            this.groupBox_system.Controls.Add(this.tabControl_Message);
            this.groupBox_system.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_system.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.groupBox_system.Location = new System.Drawing.Point(0, 0);
            this.groupBox_system.Name = "groupBox_system";
            this.groupBox_system.Size = new System.Drawing.Size(311, 663);
            this.groupBox_system.TabIndex = 0;
            this.groupBox_system.TabStop = false;
            this.groupBox_system.Text = "Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.13793F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.51724F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.MapFileStatus, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_mapFileStatus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_localIP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.AiLinkStatus, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label_simulationTime, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cameraLinkStatus, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_AILinkStatus, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_prototypeStatus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.simulationFileStatus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_prototypeSync, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_simulationFileStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_newSimulation, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 231);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // MapFileStatus
            // 
            this.MapFileStatus.AutoSize = true;
            this.MapFileStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.MapFileStatus.Location = new System.Drawing.Point(5, 36);
            this.MapFileStatus.Margin = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.MapFileStatus.Name = "MapFileStatus";
            this.MapFileStatus.Size = new System.Drawing.Size(66, 18);
            this.MapFileStatus.TabIndex = 8;
            this.MapFileStatus.Text = "Map File";
            // 
            // pictureBox_mapFileStatus
            // 
            this.pictureBox_mapFileStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
            this.pictureBox_mapFileStatus.Location = new System.Drawing.Point(162, 33);
            this.pictureBox_mapFileStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_mapFileStatus.Name = "pictureBox_mapFileStatus";
            this.pictureBox_mapFileStatus.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_mapFileStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_mapFileStatus.TabIndex = 7;
            this.pictureBox_mapFileStatus.TabStop = false;
            this.pictureBox_mapFileStatus.Click += new System.EventHandler(this.OpenMapFile_ToolStripMenuItem_Click);
            // 
            // label_localIP
            // 
            this.label_localIP.AutoSize = true;
            this.label_localIP.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_localIP.Location = new System.Drawing.Point(5, 5);
            this.label_localIP.Margin = new System.Windows.Forms.Padding(5);
            this.label_localIP.Name = "label_localIP";
            this.label_localIP.Size = new System.Drawing.Size(31, 18);
            this.label_localIP.TabIndex = 0;
            this.label_localIP.Text = "IP : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.Location = new System.Drawing.Point(3, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Time";
            // 
            // AiLinkStatus
            // 
            this.AiLinkStatus.AutoSize = true;
            this.AiLinkStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.AiLinkStatus.Location = new System.Drawing.Point(5, 176);
            this.AiLinkStatus.Margin = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.AiLinkStatus.Name = "AiLinkStatus";
            this.AiLinkStatus.Size = new System.Drawing.Size(72, 18);
            this.AiLinkStatus.TabIndex = 4;
            this.AiLinkStatus.Text = "AI Enable";
            // 
            // label_simulationTime
            // 
            this.label_simulationTime.AutoSize = true;
            this.label_simulationTime.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_simulationTime.Location = new System.Drawing.Point(160, 206);
            this.label_simulationTime.Margin = new System.Windows.Forms.Padding(3);
            this.label_simulationTime.Name = "label_simulationTime";
            this.label_simulationTime.Size = new System.Drawing.Size(62, 18);
            this.label_simulationTime.TabIndex = 11;
            this.label_simulationTime.Text = "00:00:00";
            // 
            // cameraLinkStatus
            // 
            this.cameraLinkStatus.AutoSize = true;
            this.cameraLinkStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cameraLinkStatus.Location = new System.Drawing.Point(5, 141);
            this.cameraLinkStatus.Margin = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.cameraLinkStatus.Name = "cameraLinkStatus";
            this.cameraLinkStatus.Size = new System.Drawing.Size(104, 18);
            this.cameraLinkStatus.TabIndex = 2;
            this.cameraLinkStatus.Text = "Prototype Link";
            // 
            // pictureBox_AILinkStatus
            // 
            this.pictureBox_AILinkStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
            this.pictureBox_AILinkStatus.Location = new System.Drawing.Point(162, 173);
            this.pictureBox_AILinkStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_AILinkStatus.Name = "pictureBox_AILinkStatus";
            this.pictureBox_AILinkStatus.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_AILinkStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_AILinkStatus.TabIndex = 5;
            this.pictureBox_AILinkStatus.TabStop = false;
            this.pictureBox_AILinkStatus.Click += new System.EventHandler(this.pictureBox_AILinkStatus_Click);
            // 
            // pictureBox_prototypeStatus
            // 
            this.pictureBox_prototypeStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
            this.pictureBox_prototypeStatus.Location = new System.Drawing.Point(162, 138);
            this.pictureBox_prototypeStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_prototypeStatus.Name = "pictureBox_prototypeStatus";
            this.pictureBox_prototypeStatus.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_prototypeStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_prototypeStatus.TabIndex = 3;
            this.pictureBox_prototypeStatus.TabStop = false;
            this.pictureBox_prototypeStatus.Click += new System.EventHandler(this.pictureBox_cameraLinkStatus_Click);
            // 
            // simulationFileStatus
            // 
            this.simulationFileStatus.AutoSize = true;
            this.simulationFileStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.simulationFileStatus.Location = new System.Drawing.Point(5, 71);
            this.simulationFileStatus.Margin = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.simulationFileStatus.Name = "simulationFileStatus";
            this.simulationFileStatus.Size = new System.Drawing.Size(108, 18);
            this.simulationFileStatus.TabIndex = 9;
            this.simulationFileStatus.Text = "Simulation File";
            // 
            // pictureBox_prototypeSync
            // 
            this.pictureBox_prototypeSync.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
            this.pictureBox_prototypeSync.Location = new System.Drawing.Point(236, 138);
            this.pictureBox_prototypeSync.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_prototypeSync.Name = "pictureBox_prototypeSync";
            this.pictureBox_prototypeSync.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_prototypeSync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_prototypeSync.TabIndex = 12;
            this.pictureBox_prototypeSync.TabStop = false;
            this.pictureBox_prototypeSync.Click += new System.EventHandler(this.pictureBox_pictureBox_prototypeSync_Click);
            // 
            // pictureBox_simulationFileStatus
            // 
            this.pictureBox_simulationFileStatus.Image = global::SmartTrafficSimulator.Properties.Resources.State_Red2;
            this.pictureBox_simulationFileStatus.Location = new System.Drawing.Point(162, 68);
            this.pictureBox_simulationFileStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_simulationFileStatus.Name = "pictureBox_simulationFileStatus";
            this.pictureBox_simulationFileStatus.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_simulationFileStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_simulationFileStatus.TabIndex = 6;
            this.pictureBox_simulationFileStatus.TabStop = false;
            this.pictureBox_simulationFileStatus.Click += new System.EventHandler(this.OpenSimulationFile_ToolStripMenuItem_Click);
            // 
            // pictureBox_newSimulation
            // 
            this.pictureBox_newSimulation.Image = global::SmartTrafficSimulator.Properties.Resources.State_Blue2;
            this.pictureBox_newSimulation.Location = new System.Drawing.Point(162, 103);
            this.pictureBox_newSimulation.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_newSimulation.Name = "pictureBox_newSimulation";
            this.pictureBox_newSimulation.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_newSimulation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_newSimulation.TabIndex = 13;
            this.pictureBox_newSimulation.TabStop = false;
            this.pictureBox_newSimulation.Click += new System.EventHandler(this.pictureBox_newSimulation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label3.Location = new System.Drawing.Point(5, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "New Simulation";
            // 
            // dataGridView_IntersectionsTrafficState
            // 
            this.dataGridView_IntersectionsTrafficState.AllowUserToAddRows = false;
            this.dataGridView_IntersectionsTrafficState.AllowUserToDeleteRows = false;
            this.dataGridView_IntersectionsTrafficState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_IntersectionsTrafficState.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_IntersectionsTrafficState.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_IntersectionsTrafficState.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView_IntersectionsTrafficState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_IntersectionsTrafficState.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_IntersectionsTrafficState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IntersectionsTrafficState.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IntersectionID,
            this.IAWR,
            this.TrafficFlowState});
            this.dataGridView_IntersectionsTrafficState.Location = new System.Drawing.Point(6, 585);
            this.dataGridView_IntersectionsTrafficState.Name = "dataGridView_IntersectionsTrafficState";
            this.dataGridView_IntersectionsTrafficState.ReadOnly = true;
            this.dataGridView_IntersectionsTrafficState.RowTemplate.Height = 24;
            this.dataGridView_IntersectionsTrafficState.Size = new System.Drawing.Size(299, 72);
            this.dataGridView_IntersectionsTrafficState.TabIndex = 8;
            // 
            // IntersectionID
            // 
            this.IntersectionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.NullValue = "0";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.IntersectionID.DefaultCellStyle = dataGridViewCellStyle7;
            this.IntersectionID.FillWeight = 50F;
            this.IntersectionID.HeaderText = "Intersection";
            this.IntersectionID.Name = "IntersectionID";
            this.IntersectionID.ReadOnly = true;
            // 
            // IAWR
            // 
            this.IAWR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.NullValue = "0.0";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.IAWR.DefaultCellStyle = dataGridViewCellStyle8;
            this.IAWR.FillWeight = 25F;
            this.IAWR.HeaderText = "IAWR";
            this.IAWR.Name = "IAWR";
            this.IAWR.ReadOnly = true;
            // 
            // TrafficFlowState
            // 
            this.TrafficFlowState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle9.NullValue")));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.TrafficFlowState.DefaultCellStyle = dataGridViewCellStyle9;
            this.TrafficFlowState.FillWeight = 40F;
            this.TrafficFlowState.HeaderText = "Traffic Flow";
            this.TrafficFlowState.Image = global::SmartTrafficSimulator.Properties.Resources.State_Green2;
            this.TrafficFlowState.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.TrafficFlowState.Name = "TrafficFlowState";
            this.TrafficFlowState.ReadOnly = true;
            this.TrafficFlowState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tabControl_Message
            // 
            this.tabControl_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Message.Controls.Add(this.tabPage_All);
            this.tabControl_Message.Controls.Add(this.tabPage_System);
            this.tabControl_Message.Controls.Add(this.tabPage_Prototype);
            this.tabControl_Message.Controls.Add(this.tabPage_AI);
            this.tabControl_Message.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl_Message.Location = new System.Drawing.Point(6, 281);
            this.tabControl_Message.Name = "tabControl_Message";
            this.tabControl_Message.SelectedIndex = 0;
            this.tabControl_Message.Size = new System.Drawing.Size(299, 298);
            this.tabControl_Message.TabIndex = 7;
            // 
            // tabPage_All
            // 
            this.tabPage_All.Controls.Add(this.textBox_all);
            this.tabPage_All.Location = new System.Drawing.Point(4, 26);
            this.tabPage_All.Name = "tabPage_All";
            this.tabPage_All.Size = new System.Drawing.Size(291, 268);
            this.tabPage_All.TabIndex = 0;
            this.tabPage_All.Text = "All";
            this.tabPage_All.UseVisualStyleBackColor = true;
            // 
            // textBox_all
            // 
            this.textBox_all.BackColor = System.Drawing.Color.White;
            this.textBox_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_all.Location = new System.Drawing.Point(0, 0);
            this.textBox_all.Multiline = true;
            this.textBox_all.Name = "textBox_all";
            this.textBox_all.ReadOnly = true;
            this.textBox_all.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_all.Size = new System.Drawing.Size(291, 268);
            this.textBox_all.TabIndex = 1;
            // 
            // tabPage_System
            // 
            this.tabPage_System.Controls.Add(this.textBox_system);
            this.tabPage_System.Location = new System.Drawing.Point(4, 26);
            this.tabPage_System.Name = "tabPage_System";
            this.tabPage_System.Size = new System.Drawing.Size(291, 268);
            this.tabPage_System.TabIndex = 3;
            this.tabPage_System.Text = "System";
            this.tabPage_System.UseVisualStyleBackColor = true;
            // 
            // textBox_system
            // 
            this.textBox_system.BackColor = System.Drawing.Color.White;
            this.textBox_system.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_system.Location = new System.Drawing.Point(0, 0);
            this.textBox_system.Multiline = true;
            this.textBox_system.Name = "textBox_system";
            this.textBox_system.ReadOnly = true;
            this.textBox_system.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_system.Size = new System.Drawing.Size(291, 268);
            this.textBox_system.TabIndex = 0;
            // 
            // tabPage_Prototype
            // 
            this.tabPage_Prototype.Controls.Add(this.textBox_prototype);
            this.tabPage_Prototype.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Prototype.Name = "tabPage_Prototype";
            this.tabPage_Prototype.Size = new System.Drawing.Size(291, 268);
            this.tabPage_Prototype.TabIndex = 1;
            this.tabPage_Prototype.Text = "Prototype";
            this.tabPage_Prototype.UseVisualStyleBackColor = true;
            // 
            // textBox_prototype
            // 
            this.textBox_prototype.BackColor = System.Drawing.Color.White;
            this.textBox_prototype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_prototype.Location = new System.Drawing.Point(0, 0);
            this.textBox_prototype.Multiline = true;
            this.textBox_prototype.Name = "textBox_prototype";
            this.textBox_prototype.ReadOnly = true;
            this.textBox_prototype.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_prototype.Size = new System.Drawing.Size(291, 268);
            this.textBox_prototype.TabIndex = 0;
            // 
            // tabPage_AI
            // 
            this.tabPage_AI.Controls.Add(this.textBox_AI);
            this.tabPage_AI.Controls.Add(this.textBox1);
            this.tabPage_AI.Location = new System.Drawing.Point(4, 26);
            this.tabPage_AI.Name = "tabPage_AI";
            this.tabPage_AI.Size = new System.Drawing.Size(291, 268);
            this.tabPage_AI.TabIndex = 2;
            this.tabPage_AI.Text = "AI";
            this.tabPage_AI.UseVisualStyleBackColor = true;
            // 
            // textBox_AI
            // 
            this.textBox_AI.BackColor = System.Drawing.Color.White;
            this.textBox_AI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_AI.Location = new System.Drawing.Point(0, 0);
            this.textBox_AI.Multiline = true;
            this.textBox_AI.Name = "textBox_AI";
            this.textBox_AI.ReadOnly = true;
            this.textBox_AI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_AI.Size = new System.Drawing.Size(291, 268);
            this.textBox_AI.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(291, 268);
            this.textBox1.TabIndex = 0;
            // 
            // contextMenuStrip_Main
            // 
            this.contextMenuStrip_Main.Name = "contextMenuStrip1";
            this.contextMenuStrip_Main.Size = new System.Drawing.Size(61, 4);
            // 
            // 開啟ToolStripMenuItem
            // 
            this.開啟ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地圖ToolStripMenuItem,
            this.開啟模擬檔ToolStripMenuItem,
            this.toolStripSeparator1,
            this.離開ToolStripMenuItem,
            this.toolStripSeparator2,
            this.結束ToolStripMenuItem});
            this.開啟ToolStripMenuItem.Name = "開啟ToolStripMenuItem";
            this.開啟ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.開啟ToolStripMenuItem.Text = "檔案";
            // 
            // 地圖ToolStripMenuItem
            // 
            this.地圖ToolStripMenuItem.Name = "地圖ToolStripMenuItem";
            this.地圖ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.地圖ToolStripMenuItem.Text = "開啟地圖";
            // 
            // 開啟模擬檔ToolStripMenuItem
            // 
            this.開啟模擬檔ToolStripMenuItem.Name = "開啟模擬檔ToolStripMenuItem";
            this.開啟模擬檔ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.開啟模擬檔ToolStripMenuItem.Text = "開啟模擬檔";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // 離開ToolStripMenuItem
            // 
            this.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem";
            this.離開ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.離開ToolStripMenuItem.Text = "儲存模擬檔";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // 結束ToolStripMenuItem
            // 
            this.結束ToolStripMenuItem.Name = "結束ToolStripMenuItem";
            this.結束ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.結束ToolStripMenuItem.Text = "結束";
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.路口設定ToolStripMenuItem,
            this.燈號設定ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.功能ToolStripMenuItem.Text = "功能";
            // 
            // 路口設定ToolStripMenuItem
            // 
            this.路口設定ToolStripMenuItem.Name = "路口設定ToolStripMenuItem";
            this.路口設定ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.路口設定ToolStripMenuItem.Text = "路口設定";
            // 
            // 燈號設定ToolStripMenuItem
            // 
            this.燈號設定ToolStripMenuItem.Name = "燈號設定ToolStripMenuItem";
            this.燈號設定ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.燈號設定ToolStripMenuItem.Text = "燈號設定";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "State";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // toolStrip_main
            // 
            this.toolStrip_main.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip_main.CanOverflow = false;
            this.toolStrip_main.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_start,
            this.toolStripButton_pause,
            this.toolStripButton_restart,
            this.toolStripButton_nextSimulation,
            this.toolStripSplitButton_speedAdjust,
            this.toolStripSeparator4,
            this.toolStripButton_mapEdit,
            this.toolStripButton_simulationTaskManagement,
            this.toolStripButton_saveSimulationConfiguration,
            this.toolStripSeparator7,
            this.toolStripButton_trafficSignalConfig,
            this.toolStripButton_intersectionConfig,
            this.toolStripButton_vehicleRelatedConfig,
            this.toolStripSeparator8,
            this.toolStripButton_trafficDataDisplay,
            this.toolStripButton_vehicleDataDisplay,
            this.toolStripButton_dataOutput,
            this.toolStripSeparator5,
            this.toolStripButton_simulationMode,
            this.toolStripButton_demonstrationMode,
            this.toolStripButton_zoom,
            this.toolStripButton_simulatorConfig,
            this.toolStripSeparator6,
            this.toolStripButton1});
            this.toolStrip_main.Location = new System.Drawing.Point(0, 25);
            this.toolStrip_main.Name = "toolStrip_main";
            this.toolStrip_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_main.Size = new System.Drawing.Size(1635, 32);
            this.toolStrip_main.TabIndex = 1;
            this.toolStrip_main.Text = "工具列";
            // 
            // toolStripButton_start
            // 
            this.toolStripButton_start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_start.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_start.Image")));
            this.toolStripButton_start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_start.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_start.Name = "toolStripButton_start";
            this.toolStripButton_start.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_start.Text = "Start";
            this.toolStripButton_start.Click += new System.EventHandler(this.toolStripButton_simRun_Click);
            // 
            // toolStripButton_pause
            // 
            this.toolStripButton_pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_pause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_pause.Image")));
            this.toolStripButton_pause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_pause.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_pause.Name = "toolStripButton_pause";
            this.toolStripButton_pause.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_pause.Text = "Stop";
            this.toolStripButton_pause.Click += new System.EventHandler(this.toolStripButton_simStop_Click);
            // 
            // toolStripButton_restart
            // 
            this.toolStripButton_restart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_restart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_restart.Image")));
            this.toolStripButton_restart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_restart.Name = "toolStripButton_restart";
            this.toolStripButton_restart.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_restart.Text = "Restart";
            this.toolStripButton_restart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton_restart.Click += new System.EventHandler(this.toolStripButton_restart_Click);
            // 
            // toolStripButton_nextSimulation
            // 
            this.toolStripButton_nextSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_nextSimulation.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_nextSimulation.Image")));
            this.toolStripButton_nextSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_nextSimulation.Name = "toolStripButton_nextSimulation";
            this.toolStripButton_nextSimulation.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_nextSimulation.Text = "NextSimulation";
            this.toolStripButton_nextSimulation.Click += new System.EventHandler(this.toolStripButton_nextSimulation_Click);
            // 
            // toolStripSplitButton_speedAdjust
            // 
            this.toolStripSplitButton_speedAdjust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton_speedAdjust.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.toolStripSplitButton_speedAdjust.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_speedAdjust.Image")));
            this.toolStripSplitButton_speedAdjust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_speedAdjust.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripSplitButton_speedAdjust.Name = "toolStripSplitButton_speedAdjust";
            this.toolStripSplitButton_speedAdjust.Size = new System.Drawing.Size(41, 30);
            this.toolStripSplitButton_speedAdjust.Text = "Speed Adjust";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem4.Text = "1";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripSplitButton_speedAdjust_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem5.Text = "2";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripSplitButton_speedAdjust_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem6.Text = "5";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripSplitButton_speedAdjust_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem7.Text = "10";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripSplitButton_speedAdjust_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem8.Text = "20";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripSplitButton_speedAdjust_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem9.Text = "50";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripSplitButton_speedAdjust_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton_mapEdit
            // 
            this.toolStripButton_mapEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_mapEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_mapEdit.Image")));
            this.toolStripButton_mapEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_mapEdit.Name = "toolStripButton_mapEdit";
            this.toolStripButton_mapEdit.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_mapEdit.Text = "MapEdit";
            this.toolStripButton_mapEdit.Click += new System.EventHandler(this.toolStripButton_mapEdit_Click);
            // 
            // toolStripButton_simulationTaskManagement
            // 
            this.toolStripButton_simulationTaskManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_simulationTaskManagement.Image = global::SmartTrafficSimulator.Properties.Resources.SimulationTaskManagement;
            this.toolStripButton_simulationTaskManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_simulationTaskManagement.Name = "toolStripButton_simulationTaskManagement";
            this.toolStripButton_simulationTaskManagement.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_simulationTaskManagement.Text = "SimulationTaskManagement";
            this.toolStripButton_simulationTaskManagement.Click += new System.EventHandler(this.toolStripButton_simulationTaskManagement_Click);
            // 
            // toolStripButton_saveSimulationConfiguration
            // 
            this.toolStripButton_saveSimulationConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_saveSimulationConfiguration.Image = global::SmartTrafficSimulator.Properties.Resources.Simulation_Save;
            this.toolStripButton_saveSimulationConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_saveSimulationConfiguration.Name = "toolStripButton_saveSimulationConfiguration";
            this.toolStripButton_saveSimulationConfiguration.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_saveSimulationConfiguration.Text = "SaveSimulationConfiguration";
            this.toolStripButton_saveSimulationConfiguration.Click += new System.EventHandler(this.toolStripButton_saveSimulationConfiguration_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton_trafficSignalConfig
            // 
            this.toolStripButton_trafficSignalConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_trafficSignalConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_trafficSignalConfig.Image")));
            this.toolStripButton_trafficSignalConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_trafficSignalConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_trafficSignalConfig.Name = "toolStripButton_trafficSignalConfig";
            this.toolStripButton_trafficSignalConfig.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_trafficSignalConfig.Text = "Signal Config";
            this.toolStripButton_trafficSignalConfig.Click += new System.EventHandler(this.toolStripButton_trafficSignalConfig_Click);
            // 
            // toolStripButton_intersectionConfig
            // 
            this.toolStripButton_intersectionConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_intersectionConfig.Image = global::SmartTrafficSimulator.Properties.Resources.IntersectionConfig2;
            this.toolStripButton_intersectionConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_intersectionConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_intersectionConfig.Name = "toolStripButton_intersectionConfig";
            this.toolStripButton_intersectionConfig.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_intersectionConfig.Text = "Intersection Config";
            this.toolStripButton_intersectionConfig.Click += new System.EventHandler(this.toolStripButton_intersectionConfig_Click);
            // 
            // toolStripButton_vehicleRelatedConfig
            // 
            this.toolStripButton_vehicleRelatedConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_vehicleRelatedConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_vehicleRelatedConfig.Image")));
            this.toolStripButton_vehicleRelatedConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_vehicleRelatedConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_vehicleRelatedConfig.Name = "toolStripButton_vehicleRelatedConfig";
            this.toolStripButton_vehicleRelatedConfig.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_vehicleRelatedConfig.Text = "Vehicle Config";
            this.toolStripButton_vehicleRelatedConfig.Click += new System.EventHandler(this.toolStripButton_vehicleGenerateConfig_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton_trafficDataDisplay
            // 
            this.toolStripButton_trafficDataDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_trafficDataDisplay.Image = global::SmartTrafficSimulator.Properties.Resources.trafficData;
            this.toolStripButton_trafficDataDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_trafficDataDisplay.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_trafficDataDisplay.Name = "toolStripButton_trafficDataDisplay";
            this.toolStripButton_trafficDataDisplay.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_trafficDataDisplay.Text = "Traffic Data";
            this.toolStripButton_trafficDataDisplay.Click += new System.EventHandler(this.toolStripButton_trafficDataDisplay_Click);
            // 
            // toolStripButton_vehicleDataDisplay
            // 
            this.toolStripButton_vehicleDataDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_vehicleDataDisplay.Image = global::SmartTrafficSimulator.Properties.Resources.vehicleData;
            this.toolStripButton_vehicleDataDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_vehicleDataDisplay.Name = "toolStripButton_vehicleDataDisplay";
            this.toolStripButton_vehicleDataDisplay.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_vehicleDataDisplay.Text = "Vehicle Data";
            this.toolStripButton_vehicleDataDisplay.Click += new System.EventHandler(this.toolStripButton_vehicleDataDisplay_Click);
            // 
            // toolStripButton_dataOutput
            // 
            this.toolStripButton_dataOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_dataOutput.Image = global::SmartTrafficSimulator.Properties.Resources.DataSave;
            this.toolStripButton_dataOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_dataOutput.Name = "toolStripButton_dataOutput";
            this.toolStripButton_dataOutput.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_dataOutput.Text = "Data Output";
            this.toolStripButton_dataOutput.Click += new System.EventHandler(this.toolStripButton_dataOutput_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton_simulationMode
            // 
            this.toolStripButton_simulationMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_simulationMode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_simulationMode.Image")));
            this.toolStripButton_simulationMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_simulationMode.Name = "toolStripButton_simulationMode";
            this.toolStripButton_simulationMode.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_simulationMode.Text = "Simulation Mode";
            this.toolStripButton_simulationMode.Click += new System.EventHandler(this.toolStripButton_simulationMode_Click);
            // 
            // toolStripButton_demonstrationMode
            // 
            this.toolStripButton_demonstrationMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_demonstrationMode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_demonstrationMode.Image")));
            this.toolStripButton_demonstrationMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_demonstrationMode.Name = "toolStripButton_demonstrationMode";
            this.toolStripButton_demonstrationMode.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_demonstrationMode.Text = "Demonstration Mode";
            this.toolStripButton_demonstrationMode.Click += new System.EventHandler(this.toolStripButton_demonstrationMode_Click);
            // 
            // toolStripButton_zoom
            // 
            this.toolStripButton_zoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_zoom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_zoom.Image")));
            this.toolStripButton_zoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_zoom.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_zoom.Name = "toolStripButton_zoom";
            this.toolStripButton_zoom.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_zoom.Text = "Wide Mode";
            this.toolStripButton_zoom.Click += new System.EventHandler(this.toolStripButton_zoom_Click);
            // 
            // toolStripButton_simulatorConfig
            // 
            this.toolStripButton_simulatorConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_simulatorConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_simulatorConfig.Image")));
            this.toolStripButton_simulatorConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_simulatorConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_simulatorConfig.Name = "toolStripButton_simulatorConfig";
            this.toolStripButton_simulatorConfig.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_simulatorConfig.Text = "Simulator Config";
            this.toolStripButton_simulatorConfig.Click += new System.EventHandler(this.toolStripButton_simulatorConfig_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::SmartTrafficSimulator.Properties.Resources.AITest;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.關於ToolStripMenuItem1});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip_main.Size = new System.Drawing.Size(1635, 25);
            this.menuStrip_main.TabIndex = 0;
            this.menuStrip_main.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟地圖檔ToolStripMenuItem,
            this.開啟模擬設定檔ToolStripMenuItem});
            this.檔案ToolStripMenuItem.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.檔案ToolStripMenuItem.Text = "File";
            // 
            // 開啟地圖檔ToolStripMenuItem
            // 
            this.開啟地圖檔ToolStripMenuItem.Name = "開啟地圖檔ToolStripMenuItem";
            this.開啟地圖檔ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.開啟地圖檔ToolStripMenuItem.Text = "Open Map File";
            this.開啟地圖檔ToolStripMenuItem.Click += new System.EventHandler(this.OpenMapFile_ToolStripMenuItem_Click);
            // 
            // 開啟模擬設定檔ToolStripMenuItem
            // 
            this.開啟模擬設定檔ToolStripMenuItem.Name = "開啟模擬設定檔ToolStripMenuItem";
            this.開啟模擬設定檔ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.開啟模擬設定檔ToolStripMenuItem.Text = "Open Simulation File";
            this.開啟模擬設定檔ToolStripMenuItem.Click += new System.EventHandler(this.OpenSimulationFile_ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.工具ToolStripMenuItem.Text = "Function";
            // 
            // 關於ToolStripMenuItem1
            // 
            this.關於ToolStripMenuItem1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.關於ToolStripMenuItem1.Name = "關於ToolStripMenuItem1";
            this.關於ToolStripMenuItem1.Size = new System.Drawing.Size(60, 21);
            this.關於ToolStripMenuItem1.Text = "Config";
            // 
            // toolStripButton_Run
            // 
            this.toolStripButton_Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Run.Name = "toolStripButton_Run";
            this.toolStripButton_Run.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_Run.Text = "Run";
            // 
            // toolStripButton_Stop
            // 
            this.toolStripButton_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Stop.Name = "toolStripButton_Stop";
            this.toolStripButton_Stop.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_Stop.Text = "Stop";
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle10.NullValue")));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewImageColumn2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewImageColumn2.FillWeight = 40F;
            this.dataGridViewImageColumn2.HeaderText = "Traffic Flow";
            this.dataGridViewImageColumn2.Image = global::SmartTrafficSimulator.Properties.Resources.State_Green2;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1635, 720);
            this.Controls.Add(this.splitContainer_main);
            this.Controls.Add(this.toolStrip_main);
            this.Controls.Add(this.menuStrip_main);
            this.MainMenuStrip = this.menuStrip_main;
            this.Name = "MainUI";
            this.Text = "SmartTrafficSimulator V3.0.1";
            this.splitContainer_main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
            this.splitContainer_main.ResumeLayout(false);
            this.groupBox_system.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapFileStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AILinkStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prototypeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prototypeSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_simulationFileStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_newSimulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionsTrafficState)).EndInit();
            this.tabControl_Message.ResumeLayout(false);
            this.tabPage_All.ResumeLayout(false);
            this.tabPage_All.PerformLayout();
            this.tabPage_System.ResumeLayout(false);
            this.tabPage_System.PerformLayout();
            this.tabPage_Prototype.ResumeLayout(false);
            this.tabPage_Prototype.PerformLayout();
            this.tabPage_AI.ResumeLayout(false);
            this.tabPage_AI.PerformLayout();
            this.toolStrip_main.ResumeLayout(false);
            this.toolStrip_main.PerformLayout();
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private SystemController systemController;
        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem 開啟ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地圖ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip_main;
        public System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.GroupBox groupBox_system;
        private System.Windows.Forms.TextBox textBox_all;
        private ToolStripButton toolStripButton_Run;
        private ToolStripButton toolStripButton_Stop;
        private TabControl tabControl_Message;
        private TabPage tabPage_All;
        private TabPage tabPage_Prototype;
        private TabPage tabPage_AI;
        private TabPage tabPage_System;
        private TextBox textBox_prototype;
        private TextBox textBox_AI;
        private TextBox textBox1;
        private TextBox textBox_system;
        private ToolStripMenuItem 開啟模擬檔ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 離開ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem 結束ToolStripMenuItem;
        private ToolStripMenuItem 路口設定ToolStripMenuItem;
        private ToolStripMenuItem 燈號設定ToolStripMenuItem;
        private ToolStripMenuItem 關於ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ContextMenuStrip contextMenuStrip_Main;
        private DataGridView dataGridView_IntersectionsTrafficState;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private ToolStripMenuItem 檔案ToolStripMenuItem;
        private ToolStripMenuItem 開啟地圖檔ToolStripMenuItem;
        private ToolStripMenuItem 開啟模擬設定檔ToolStripMenuItem;
        private ToolStripButton toolStripButton_start;
        private ToolStripButton toolStripButton_pause;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSplitButton toolStripSplitButton_speedAdjust;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripButton toolStripButton_trafficSignalConfig;
        private ToolStripButton toolStripButton_intersectionConfig;
        private ToolStripButton toolStripButton_vehicleRelatedConfig;
        private ToolStripSeparator toolStripSeparator5;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox_AILinkStatus;
        private PictureBox pictureBox_mapFileStatus;
        private PictureBox pictureBox_prototypeStatus;
        private Label AiLinkStatus;
        protected Label label_localIP;
        private PictureBox pictureBox_simulationFileStatus;
        private Label cameraLinkStatus;
        protected Label MapFileStatus;
        protected Label simulationFileStatus;
        private ToolStripButton toolStripButton_zoom;
        public Timer MainTimer;
        private Timer VehicleRunningTimer;
        private Timer VehicleGraphicTimer;
        private ToolStripButton toolStripButton_trafficDataDisplay;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripButton toolStripButton_simulatorConfig;
        private Label label2;
        private Label label_simulationTime;
        private ToolStripButton toolStripButton_restart;
        private ToolStripButton toolStripButton_simulationMode;
        private ToolStripButton toolStripButton_demonstrationMode;
        private ToolStripButton toolStripButton_mapEdit;
        private ToolStripButton toolStripButton_saveSimulationConfiguration;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton toolStripButton_simulationTaskManagement;
        private PictureBox pictureBox_prototypeSync;
        private ToolStripMenuItem 工具ToolStripMenuItem;
        private ToolStripMenuItem 關於ToolStripMenuItem1;
        private ToolStripButton toolStripButton_nextSimulation;
        private DataGridViewTextBoxColumn IntersectionID;
        private DataGridViewTextBoxColumn IAWR;
        private DataGridViewImageColumn TrafficFlowState;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton toolStripButton_vehicleDataDisplay;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private PictureBox pictureBox_newSimulation;
        protected Label label3;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton_dataOutput;

        public System.Windows.Forms.PaintEventHandler panel1_Paint { get; set; }
    }
}

