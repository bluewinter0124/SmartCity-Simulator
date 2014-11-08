using System;
using System.Windows.Forms;
using SmartCitySimulator.GraphicUnit;
using SmartCitySimulator.SystemObject;
using System.Drawing;
namespace SmartCitySimulator
{
    partial class MainUI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        SimulationFileRead readFile;
        int vehicleGenerateCounter = 100;

        int autoSimulationStartTime;
        int autoSimulationStopTime;
        int autoSimulationTimes;
        Boolean autoSaveTrafficRecoed;
        Boolean autoSaveOptimizationRecord;


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
            if (Simulator.SimulationTime == autoSimulationStopTime)
            {
                AutoSimulationAccomplish();
            }

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
            if (Simulator.simulationConfigRead)
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
            if (Simulator.simulationConfigRead)
            {
                Simulator.UI.AddMessage("System", "Simulator Stop");

                Simulator.simulatorRun = false;

                MainTimer.Stop();
                VehicleRunningTimer.Stop();
                VehicleGraphicTimer.Stop();

                Simulator.PrototypeManager.PrototypeStop();
            }
        }

        public void SimulatorRestart()
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


                if (Simulator.autoSimulation)
                {
                    Simulator.setCurrentTime(autoSimulationStartTime);
                }
                else
                {
                    Simulator.RestartSimulationTime();
                }
                RefreshSimulationTime();
            }
        }

        public void AutoSimulation(int startTime,int stopTime,int times,Boolean trafficSave,Boolean optimizationSave)
        {
            this.autoSimulationStartTime = startTime;
            this.autoSimulationStopTime = stopTime;
            this.autoSimulationTimes = times;
            this.autoSaveTrafficRecoed = trafficSave;
            this.autoSaveOptimizationRecord = optimizationSave;

            Simulator.AutoSimulationInitialize();
            Simulator.AutoSimulationOn();
            AutoSimulationStart();
        }

        public void AutoSimulationStart()
        {
            if (Simulator.simulatorStarted)
            {
                SimulatorRestart();
            }
            else
            {
                Simulator.setCurrentTime(autoSimulationStartTime);
                RefreshSimulationTime();
            }

            SimulatorStart();
        }

        public void AutoSimulationAccomplish()
        {
            SimulatorStop();
            Simulator.DataManager.SaveAllData(this.autoSaveTrafficRecoed,this.autoSaveOptimizationRecord);

            Simulator.autoSimulationAccomplish++;

            if (Simulator.autoSimulationAccomplish < autoSimulationTimes)
            {
                AutoSimulationStart();
            }
            else
            {
                AutoSimulationStop();
            }
        }

        public void AutoSimulationStop()
        {
            Simulator.AutoSimulationOff();
            SimulatorStop();
        }

        public void OpenMapFile()
        {
            OpenFileDialog openFileDialog_map = new OpenFileDialog();
            openFileDialog_map.Filter = "Map Files|*.txt";
            openFileDialog_map.Title = "Select a MapDataFile";
            if (openFileDialog_map.ShowDialog() == DialogResult.OK)
            {
                MainTimer.Stop();
                VehicleRunningTimer.Stop();
                VehicleGraphicTimer.Stop();

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

        public void OpenSimulationFile()
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

        public void SetSimulationSpeed(int simulationRate)
        {
            Simulator.setSimulationRate(simulationRate);
            MainTimer.Interval = 1000 / Simulator.simulationRate;
        }

        public void SetVehicleRunTask(int vehicleRunPerSecond)
        {
            VehicleRunningTimer.Interval = 1000 / vehicleRunPerSecond;
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
                this.splitContainer1.Panel2.Controls.Add(vehicle);
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
                this.splitContainer1.Panel2.Controls.Remove(vehicle);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox_system = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox_AILinkStatus = new System.Windows.Forms.PictureBox();
            this.pictureBox_mapFileStatus = new System.Windows.Forms.PictureBox();
            this.pictureBox_prototypeStatus = new System.Windows.Forms.PictureBox();
            this.AiLinkStatus = new System.Windows.Forms.Label();
            this.label_localIP = new System.Windows.Forms.Label();
            this.pictureBox_simulationFileStatus = new System.Windows.Forms.PictureBox();
            this.cameraLinkStatus = new System.Windows.Forms.Label();
            this.MapFileStatus = new System.Windows.Forms.Label();
            this.simulationFileStatus = new System.Windows.Forms.Label();
            this.label_simulationTime = new System.Windows.Forms.Label();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_start = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_pause = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_restart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_autoSimulation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_mapEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_saveSimulationConfiguration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_TrafficLightConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_IntersectionConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_VehicleGenerateConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_TrafficDataDisplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_demonstrationMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_simulationMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton_SpeedAdjust = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_SimulatorConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Zoom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox_system.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AILinkStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapFileStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prototypeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_simulationFileStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionsTrafficState)).BeginInit();
            this.tabControl_Message.SuspendLayout();
            this.tabPage_All.SuspendLayout();
            this.tabPage_System.SuspendLayout();
            this.tabPage_Prototype.SuspendLayout();
            this.tabPage_AI.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_system);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer1.Panel2MinSize = 800;
            this.splitContainer1.Size = new System.Drawing.Size(1635, 664);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            // 
            // groupBox_system
            // 
            this.groupBox_system.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox_system.Controls.Add(this.tableLayoutPanel1);
            this.groupBox_system.Controls.Add(this.dataGridView_IntersectionsTrafficState);
            this.groupBox_system.Controls.Add(this.tabControl_Message);
            this.groupBox_system.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_system.Location = new System.Drawing.Point(0, 0);
            this.groupBox_system.Name = "groupBox_system";
            this.groupBox_system.Size = new System.Drawing.Size(303, 664);
            this.groupBox_system.TabIndex = 0;
            this.groupBox_system.TabStop = false;
            this.groupBox_system.Text = "系統資訊";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.62069F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.37931F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_AILinkStatus, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_mapFileStatus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_prototypeStatus, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.AiLinkStatus, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_localIP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_simulationFileStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cameraLinkStatus, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.MapFileStatus, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.simulationFileStatus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_simulationTime, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 185);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.Location = new System.Drawing.Point(3, 151);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "模擬器時間";
            // 
            // pictureBox_AILinkStatus
            // 
            this.pictureBox_AILinkStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_AILinkStatus.Image")));
            this.pictureBox_AILinkStatus.Location = new System.Drawing.Point(145, 123);
            this.pictureBox_AILinkStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_AILinkStatus.Name = "pictureBox_AILinkStatus";
            this.pictureBox_AILinkStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_AILinkStatus.TabIndex = 5;
            this.pictureBox_AILinkStatus.TabStop = false;
            this.pictureBox_AILinkStatus.Click += new System.EventHandler(this.pictureBox_AILinkStatus_Click);
            // 
            // pictureBox_mapFileStatus
            // 
            this.pictureBox_mapFileStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_mapFileStatus.Image")));
            this.pictureBox_mapFileStatus.Location = new System.Drawing.Point(145, 33);
            this.pictureBox_mapFileStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_mapFileStatus.Name = "pictureBox_mapFileStatus";
            this.pictureBox_mapFileStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_mapFileStatus.TabIndex = 7;
            this.pictureBox_mapFileStatus.TabStop = false;
            this.pictureBox_mapFileStatus.Click += new System.EventHandler(this.OpenMapFile_ToolStripMenuItem_Click);
            // 
            // pictureBox_prototypeStatus
            // 
            this.pictureBox_prototypeStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_prototypeStatus.Image")));
            this.pictureBox_prototypeStatus.Location = new System.Drawing.Point(145, 93);
            this.pictureBox_prototypeStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_prototypeStatus.Name = "pictureBox_prototypeStatus";
            this.pictureBox_prototypeStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_prototypeStatus.TabIndex = 3;
            this.pictureBox_prototypeStatus.TabStop = false;
            this.pictureBox_prototypeStatus.Click += new System.EventHandler(this.pictureBox_cameraLinkStatus_Click);
            // 
            // AiLinkStatus
            // 
            this.AiLinkStatus.AutoSize = true;
            this.AiLinkStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.AiLinkStatus.Location = new System.Drawing.Point(5, 123);
            this.AiLinkStatus.Margin = new System.Windows.Forms.Padding(5);
            this.AiLinkStatus.Name = "AiLinkStatus";
            this.AiLinkStatus.Size = new System.Drawing.Size(50, 18);
            this.AiLinkStatus.TabIndex = 4;
            this.AiLinkStatus.Text = "AI啟動";
            // 
            // label_localIP
            // 
            this.label_localIP.AutoSize = true;
            this.label_localIP.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_localIP.Location = new System.Drawing.Point(5, 5);
            this.label_localIP.Margin = new System.Windows.Forms.Padding(5);
            this.label_localIP.Name = "label_localIP";
            this.label_localIP.Size = new System.Drawing.Size(63, 18);
            this.label_localIP.TabIndex = 0;
            this.label_localIP.Text = "本機 IP : ";
            // 
            // pictureBox_simulationFileStatus
            // 
            this.pictureBox_simulationFileStatus.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_simulationFileStatus.Image")));
            this.pictureBox_simulationFileStatus.Location = new System.Drawing.Point(145, 63);
            this.pictureBox_simulationFileStatus.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox_simulationFileStatus.Name = "pictureBox_simulationFileStatus";
            this.pictureBox_simulationFileStatus.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_simulationFileStatus.TabIndex = 6;
            this.pictureBox_simulationFileStatus.TabStop = false;
            this.pictureBox_simulationFileStatus.Click += new System.EventHandler(this.OpenSimulationConfigFile_ToolStripMenuItem_Click);
            // 
            // cameraLinkStatus
            // 
            this.cameraLinkStatus.AutoSize = true;
            this.cameraLinkStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cameraLinkStatus.Location = new System.Drawing.Point(5, 93);
            this.cameraLinkStatus.Margin = new System.Windows.Forms.Padding(5);
            this.cameraLinkStatus.Name = "cameraLinkStatus";
            this.cameraLinkStatus.Size = new System.Drawing.Size(101, 18);
            this.cameraLinkStatus.TabIndex = 2;
            this.cameraLinkStatus.Text = "Prototype連線";
            // 
            // MapFileStatus
            // 
            this.MapFileStatus.AutoSize = true;
            this.MapFileStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.MapFileStatus.Location = new System.Drawing.Point(5, 33);
            this.MapFileStatus.Margin = new System.Windows.Forms.Padding(5);
            this.MapFileStatus.Name = "MapFileStatus";
            this.MapFileStatus.Size = new System.Drawing.Size(78, 18);
            this.MapFileStatus.TabIndex = 8;
            this.MapFileStatus.Text = "地圖檔讀取";
            // 
            // simulationFileStatus
            // 
            this.simulationFileStatus.AutoSize = true;
            this.simulationFileStatus.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.simulationFileStatus.Location = new System.Drawing.Point(5, 63);
            this.simulationFileStatus.Margin = new System.Windows.Forms.Padding(5);
            this.simulationFileStatus.Name = "simulationFileStatus";
            this.simulationFileStatus.Size = new System.Drawing.Size(78, 18);
            this.simulationFileStatus.TabIndex = 9;
            this.simulationFileStatus.Text = "模擬檔讀取";
            // 
            // label_simulationTime
            // 
            this.label_simulationTime.AutoSize = true;
            this.label_simulationTime.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_simulationTime.Location = new System.Drawing.Point(143, 151);
            this.label_simulationTime.Margin = new System.Windows.Forms.Padding(3);
            this.label_simulationTime.Name = "label_simulationTime";
            this.label_simulationTime.Size = new System.Drawing.Size(62, 17);
            this.label_simulationTime.TabIndex = 11;
            this.label_simulationTime.Text = "00:00:00";
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
            this.dataGridView_IntersectionsTrafficState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IntersectionsTrafficState.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IntersectionID,
            this.IAWR,
            this.TrafficFlowState});
            this.dataGridView_IntersectionsTrafficState.Location = new System.Drawing.Point(6, 585);
            this.dataGridView_IntersectionsTrafficState.Name = "dataGridView_IntersectionsTrafficState";
            this.dataGridView_IntersectionsTrafficState.ReadOnly = true;
            this.dataGridView_IntersectionsTrafficState.RowTemplate.Height = 24;
            this.dataGridView_IntersectionsTrafficState.Size = new System.Drawing.Size(297, 73);
            this.dataGridView_IntersectionsTrafficState.TabIndex = 8;
            // 
            // IntersectionID
            // 
            this.IntersectionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IntersectionID.DataPropertyName = "SimulatorConfiguration.id";
            this.IntersectionID.FillWeight = 30F;
            this.IntersectionID.HeaderText = "路口";
            this.IntersectionID.Name = "IntersectionID";
            this.IntersectionID.ReadOnly = true;
            this.IntersectionID.Width = 90;
            // 
            // IAWR
            // 
            this.IAWR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IAWR.FillWeight = 30F;
            this.IAWR.HeaderText = "IAWR";
            this.IAWR.Name = "IAWR";
            this.IAWR.ReadOnly = true;
            this.IAWR.Width = 40;
            // 
            // TrafficFlowState
            // 
            this.TrafficFlowState.FillWeight = 30F;
            this.TrafficFlowState.HeaderText = "TrafficFlow";
            this.TrafficFlowState.Name = "TrafficFlowState";
            this.TrafficFlowState.ReadOnly = true;
            this.TrafficFlowState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TrafficFlowState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabControl_Message
            // 
            this.tabControl_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Message.Controls.Add(this.tabPage_All);
            this.tabControl_Message.Controls.Add(this.tabPage_System);
            this.tabControl_Message.Controls.Add(this.tabPage_Prototype);
            this.tabControl_Message.Controls.Add(this.tabPage_AI);
            this.tabControl_Message.Location = new System.Drawing.Point(6, 226);
            this.tabControl_Message.Name = "tabControl_Message";
            this.tabControl_Message.SelectedIndex = 0;
            this.tabControl_Message.Size = new System.Drawing.Size(294, 353);
            this.tabControl_Message.TabIndex = 7;
            // 
            // tabPage_All
            // 
            this.tabPage_All.Controls.Add(this.textBox_all);
            this.tabPage_All.Location = new System.Drawing.Point(4, 22);
            this.tabPage_All.Name = "tabPage_All";
            this.tabPage_All.Size = new System.Drawing.Size(286, 327);
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
            this.textBox_all.Size = new System.Drawing.Size(286, 327);
            this.textBox_all.TabIndex = 1;
            // 
            // tabPage_System
            // 
            this.tabPage_System.Controls.Add(this.textBox_system);
            this.tabPage_System.Location = new System.Drawing.Point(4, 22);
            this.tabPage_System.Name = "tabPage_System";
            this.tabPage_System.Size = new System.Drawing.Size(286, 327);
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
            this.textBox_system.Size = new System.Drawing.Size(286, 327);
            this.textBox_system.TabIndex = 0;
            // 
            // tabPage_Prototype
            // 
            this.tabPage_Prototype.Controls.Add(this.textBox_prototype);
            this.tabPage_Prototype.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Prototype.Name = "tabPage_Prototype";
            this.tabPage_Prototype.Size = new System.Drawing.Size(286, 327);
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
            this.textBox_prototype.Size = new System.Drawing.Size(286, 327);
            this.textBox_prototype.TabIndex = 0;
            // 
            // tabPage_AI
            // 
            this.tabPage_AI.Controls.Add(this.textBox_AI);
            this.tabPage_AI.Controls.Add(this.textBox1);
            this.tabPage_AI.Location = new System.Drawing.Point(4, 22);
            this.tabPage_AI.Name = "tabPage_AI";
            this.tabPage_AI.Size = new System.Drawing.Size(286, 327);
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
            this.textBox_AI.Size = new System.Drawing.Size(286, 327);
            this.textBox_AI.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(286, 327);
            this.textBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
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
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_start,
            this.toolStripButton_pause,
            this.toolStripButton_restart,
            this.toolStripButton_autoSimulation,
            this.toolStripSeparator4,
            this.toolStripButton_mapEdit,
            this.toolStripButton_saveSimulationConfiguration,
            this.toolStripSeparator7,
            this.toolStripButton_TrafficLightConfig,
            this.toolStripButton_IntersectionConfig,
            this.toolStripButton_VehicleGenerateConfig,
            this.toolStripButton_TrafficDataDisplay,
            this.toolStripSeparator5,
            this.toolStripButton_demonstrationMode,
            this.toolStripButton_simulationMode,
            this.toolStripSplitButton_SpeedAdjust,
            this.toolStripButton_SimulatorConfig,
            this.toolStripButton_Zoom,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1635, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "工具列";
            // 
            // toolStripButton_start
            // 
            this.toolStripButton_start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_start.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_start.Image")));
            this.toolStripButton_start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_start.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_start.Name = "toolStripButton_start";
            this.toolStripButton_start.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_start.Text = "模擬器開始";
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
            this.toolStripButton_pause.Text = "模擬器暫停";
            this.toolStripButton_pause.Click += new System.EventHandler(this.toolStripButton_simStop_Click);
            // 
            // toolStripButton_restart
            // 
            this.toolStripButton_restart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_restart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_restart.Image")));
            this.toolStripButton_restart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_restart.Name = "toolStripButton_restart";
            this.toolStripButton_restart.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_restart.Text = "重新開始模擬";
            this.toolStripButton_restart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton_restart.Click += new System.EventHandler(this.toolStripButton_restart_Click);
            // 
            // toolStripButton_autoSimulation
            // 
            this.toolStripButton_autoSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_autoSimulation.Image = global::SmartCitySimulator.Properties.Resources.AutoSimulation;
            this.toolStripButton_autoSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_autoSimulation.Name = "toolStripButton_autoSimulation";
            this.toolStripButton_autoSimulation.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_autoSimulation.Text = "AutoSimulation";
            this.toolStripButton_autoSimulation.Click += new System.EventHandler(this.toolStripButton_autoSimulation_Click);
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
            // toolStripButton_saveSimulationConfiguration
            // 
            this.toolStripButton_saveSimulationConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_saveSimulationConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_saveSimulationConfiguration.Image")));
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
            // toolStripButton_TrafficLightConfig
            // 
            this.toolStripButton_TrafficLightConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_TrafficLightConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_TrafficLightConfig.Image")));
            this.toolStripButton_TrafficLightConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TrafficLightConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_TrafficLightConfig.Name = "toolStripButton_TrafficLightConfig";
            this.toolStripButton_TrafficLightConfig.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_TrafficLightConfig.Text = "紅綠燈設定";
            this.toolStripButton_TrafficLightConfig.Click += new System.EventHandler(this.toolStripButton_TrafficLightConfig_Click);
            // 
            // toolStripButton_IntersectionConfig
            // 
            this.toolStripButton_IntersectionConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_IntersectionConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_IntersectionConfig.Image")));
            this.toolStripButton_IntersectionConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_IntersectionConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_IntersectionConfig.Name = "toolStripButton_IntersectionConfig";
            this.toolStripButton_IntersectionConfig.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_IntersectionConfig.Text = "路口相關設定";
            this.toolStripButton_IntersectionConfig.Click += new System.EventHandler(this.toolStripButton_IntersectionConfig_Click);
            // 
            // toolStripButton_VehicleGenerateConfig
            // 
            this.toolStripButton_VehicleGenerateConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_VehicleGenerateConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_VehicleGenerateConfig.Image")));
            this.toolStripButton_VehicleGenerateConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_VehicleGenerateConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_VehicleGenerateConfig.Name = "toolStripButton_VehicleGenerateConfig";
            this.toolStripButton_VehicleGenerateConfig.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_VehicleGenerateConfig.Text = "車輛相關設定";
            this.toolStripButton_VehicleGenerateConfig.Click += new System.EventHandler(this.toolStripButton_VehicleGenerateConfig_Click);
            // 
            // toolStripButton_TrafficDataDisplay
            // 
            this.toolStripButton_TrafficDataDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_TrafficDataDisplay.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_TrafficDataDisplay.Image")));
            this.toolStripButton_TrafficDataDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TrafficDataDisplay.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_TrafficDataDisplay.Name = "toolStripButton_TrafficDataDisplay";
            this.toolStripButton_TrafficDataDisplay.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_TrafficDataDisplay.Text = "統計資料";
            this.toolStripButton_TrafficDataDisplay.Click += new System.EventHandler(this.toolStripButton_TrafficDataDisplay_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton_demonstrationMode
            // 
            this.toolStripButton_demonstrationMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_demonstrationMode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_demonstrationMode.Image")));
            this.toolStripButton_demonstrationMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_demonstrationMode.Name = "toolStripButton_demonstrationMode";
            this.toolStripButton_demonstrationMode.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_demonstrationMode.Text = "DemonstrationMode";
            this.toolStripButton_demonstrationMode.Click += new System.EventHandler(this.toolStripButton_demonstrationMode_Click);
            // 
            // toolStripButton_simulationMode
            // 
            this.toolStripButton_simulationMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_simulationMode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_simulationMode.Image")));
            this.toolStripButton_simulationMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_simulationMode.Name = "toolStripButton_simulationMode";
            this.toolStripButton_simulationMode.Size = new System.Drawing.Size(29, 29);
            this.toolStripButton_simulationMode.Text = "SimulationMode";
            this.toolStripButton_simulationMode.Click += new System.EventHandler(this.toolStripButton_simulationMode_Click);
            // 
            // toolStripSplitButton_SpeedAdjust
            // 
            this.toolStripSplitButton_SpeedAdjust.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton_SpeedAdjust.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.toolStripSplitButton_SpeedAdjust.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_SpeedAdjust.Image")));
            this.toolStripSplitButton_SpeedAdjust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_SpeedAdjust.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripSplitButton_SpeedAdjust.Name = "toolStripSplitButton_SpeedAdjust";
            this.toolStripSplitButton_SpeedAdjust.Size = new System.Drawing.Size(41, 30);
            this.toolStripSplitButton_SpeedAdjust.Text = "模擬速度調整";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem4.Text = "1";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripSplitButton_SpeedAdjust_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem5.Text = "2";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripSplitButton_SpeedAdjust_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem6.Text = "5";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripSplitButton_SpeedAdjust_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem7.Text = "10";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripSplitButton_SpeedAdjust_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem8.Text = "20";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripSplitButton_SpeedAdjust_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(90, 22);
            this.toolStripMenuItem9.Text = "50";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripSplitButton_SpeedAdjust_Click);
            // 
            // toolStripButton_SimulatorConfig
            // 
            this.toolStripButton_SimulatorConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SimulatorConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_SimulatorConfig.Image")));
            this.toolStripButton_SimulatorConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SimulatorConfig.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_SimulatorConfig.Name = "toolStripButton_SimulatorConfig";
            this.toolStripButton_SimulatorConfig.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_SimulatorConfig.Text = "模擬器設定";
            this.toolStripButton_SimulatorConfig.Click += new System.EventHandler(this.toolStripButton_SimulatorConfig_Click);
            // 
            // toolStripButton_Zoom
            // 
            this.toolStripButton_Zoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Zoom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Zoom.Image")));
            this.toolStripButton_Zoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Zoom.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStripButton_Zoom.Name = "toolStripButton_Zoom";
            this.toolStripButton_Zoom.Size = new System.Drawing.Size(29, 30);
            this.toolStripButton_Zoom.Text = "全螢幕模式";
            this.toolStripButton_Zoom.Click += new System.EventHandler(this.toolStripButton_Zoom_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.檔案ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.關於ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1635, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 檔案ToolStripMenuItem
            // 
            this.檔案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開啟地圖檔ToolStripMenuItem,
            this.開啟模擬設定檔ToolStripMenuItem});
            this.檔案ToolStripMenuItem.Name = "檔案ToolStripMenuItem";
            this.檔案ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.檔案ToolStripMenuItem.Text = "檔案";
            // 
            // 開啟地圖檔ToolStripMenuItem
            // 
            this.開啟地圖檔ToolStripMenuItem.Name = "開啟地圖檔ToolStripMenuItem";
            this.開啟地圖檔ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.開啟地圖檔ToolStripMenuItem.Text = "開啟地圖檔";
            this.開啟地圖檔ToolStripMenuItem.Click += new System.EventHandler(this.OpenMapFile_ToolStripMenuItem_Click);
            // 
            // 開啟模擬設定檔ToolStripMenuItem
            // 
            this.開啟模擬設定檔ToolStripMenuItem.Name = "開啟模擬設定檔ToolStripMenuItem";
            this.開啟模擬設定檔ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.開啟模擬設定檔ToolStripMenuItem.Text = "開啟模擬設定檔";
            this.開啟模擬設定檔ToolStripMenuItem.Click += new System.EventHandler(this.OpenSimulationConfigFile_ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.工具ToolStripMenuItem.Text = "功能";
            // 
            // 關於ToolStripMenuItem1
            // 
            this.關於ToolStripMenuItem1.Name = "關於ToolStripMenuItem1";
            this.關於ToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.關於ToolStripMenuItem1.Text = "設置";
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
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1635, 720);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainUI";
            this.Text = "SmartCitySimulator V2.11";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox_system.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AILinkStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mapFileStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_prototypeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_simulationFileStatus)).EndInit();
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private SystemController systemController;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 開啟ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地圖ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.SplitContainer splitContainer1;
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
        private ContextMenuStrip contextMenuStrip1;
        private DataGridView dataGridView_IntersectionsTrafficState;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private ToolStripMenuItem 檔案ToolStripMenuItem;
        private ToolStripMenuItem 開啟地圖檔ToolStripMenuItem;
        private ToolStripMenuItem 開啟模擬設定檔ToolStripMenuItem;
        private ToolStripMenuItem 工具ToolStripMenuItem;
        private ToolStripButton toolStripButton_start;
        private ToolStripButton toolStripButton_pause;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSplitButton toolStripSplitButton_SpeedAdjust;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripButton toolStripButton_TrafficLightConfig;
        private ToolStripButton toolStripButton_IntersectionConfig;
        private ToolStripButton toolStripButton_VehicleGenerateConfig;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem 關於ToolStripMenuItem1;
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
        private ToolStripButton toolStripButton_Zoom;
        public Timer MainTimer;
        private Timer VehicleRunningTimer;
        private Timer VehicleGraphicTimer;
        private ToolStripButton toolStripButton_TrafficDataDisplay;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripButton toolStripButton_SimulatorConfig;
        private ToolStripSeparator toolStripSeparator6;
        private DataGridViewTextBoxColumn IntersectionID;
        private DataGridViewTextBoxColumn IAWR;
        private DataGridViewImageColumn TrafficFlowState;
        private Label label2;
        private Label label_simulationTime;
        private ToolStripButton toolStripButton_restart;
        private ToolStripButton toolStripButton_simulationMode;
        private ToolStripButton toolStripButton_demonstrationMode;
        private ToolStripButton toolStripButton_mapEdit;
        private ToolStripButton toolStripButton_saveSimulationConfiguration;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton toolStripButton_autoSimulation;

        public System.Windows.Forms.PaintEventHandler panel1_Paint { get; set; }
    }
}

