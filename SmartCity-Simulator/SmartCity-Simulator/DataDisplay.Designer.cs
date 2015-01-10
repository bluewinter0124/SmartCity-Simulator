namespace SmartCitySimulator
{
    partial class DataDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataDisplay));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_sec = new System.Windows.Forms.Label();
            this.comboBox_Intersections = new System.Windows.Forms.ComboBox();
            this.label_pa = new System.Windows.Forms.Label();
            this.label_2 = new System.Windows.Forms.Label();
            this.label_AWR = new System.Windows.Forms.Label();
            this.label_IAWT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            this.dataGridView_singleRoadData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Road = new System.Windows.Forms.ComboBox();
            this.numericUpDown_startPeriod = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label_endPeriod = new System.Windows.Forms.Label();
            this.numericUpDown_endPeriod = new System.Windows.Forms.NumericUpDown();
            this.button_showRoadHistory = new System.Windows.Forms.Button();
            this.button_optSaveAsTxt = new System.Windows.Forms.Button();
            this.button_optSaveAsExcel = new System.Windows.Forms.Button();
            this.groupBox_optimizationDataOutput = new System.Windows.Forms.GroupBox();
            this.button_selectFolder = new System.Windows.Forms.Button();
            this.button_traSaveAsExcel = new System.Windows.Forms.Button();
            this.button_traSaveAsTxt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_saveAllOptRecord = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_saveAllTrafficRecord = new System.Windows.Forms.Button();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitContainer_data = new System.Windows.Forms.SplitContainer();
            this.splitContainer_intersectionData = new System.Windows.Forms.SplitContainer();
            this.dataGridView_intersectionData = new System.Windows.Forms.DataGridView();
            this.dataGridView_optimizeationData = new System.Windows.Forms.DataGridView();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousCycleRemainVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enterVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassedVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaittingVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleWaittingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalWaittingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptimizeCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptimizeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IAWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IAWRThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optimizedConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageArrivalVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaitingVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaittingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaittingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_singleRoadData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endPeriod)).BeginInit();
            this.groupBox_optimizationDataOutput.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_data)).BeginInit();
            this.splitContainer_data.Panel1.SuspendLayout();
            this.splitContainer_data.Panel2.SuspendLayout();
            this.splitContainer_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_intersectionData)).BeginInit();
            this.splitContainer_intersectionData.Panel1.SuspendLayout();
            this.splitContainer_intersectionData.Panel2.SuspendLayout();
            this.splitContainer_intersectionData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_intersectionData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_optimizeationData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_sec);
            this.groupBox1.Controls.Add(this.comboBox_Intersections);
            this.groupBox1.Controls.Add(this.label_pa);
            this.groupBox1.Controls.Add(this.label_2);
            this.groupBox1.Controls.Add(this.label_AWR);
            this.groupBox1.Controls.Add(this.label_IAWT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(15, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(235, 121);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intersection";
            // 
            // label_sec
            // 
            this.label_sec.AutoSize = true;
            this.label_sec.Location = new System.Drawing.Point(168, 90);
            this.label_sec.Name = "label_sec";
            this.label_sec.Size = new System.Drawing.Size(27, 17);
            this.label_sec.TabIndex = 12;
            this.label_sec.Text = "sec";
            // 
            // comboBox_Intersections
            // 
            this.comboBox_Intersections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Intersections.FormattingEnabled = true;
            this.comboBox_Intersections.Location = new System.Drawing.Point(8, 18);
            this.comboBox_Intersections.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Intersections.Name = "comboBox_Intersections";
            this.comboBox_Intersections.Size = new System.Drawing.Size(221, 25);
            this.comboBox_Intersections.TabIndex = 0;
            this.comboBox_Intersections.SelectedIndexChanged += new System.EventHandler(this.comboBox_Intersections_SelectedIndexChanged);
            // 
            // label_pa
            // 
            this.label_pa.AutoSize = true;
            this.label_pa.Location = new System.Drawing.Point(168, 62);
            this.label_pa.Name = "label_pa";
            this.label_pa.Size = new System.Drawing.Size(19, 17);
            this.label_pa.TabIndex = 11;
            this.label_pa.Text = "%";
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.Location = new System.Drawing.Point(35, 62);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(54, 17);
            this.label_2.TabIndex = 9;
            this.label_2.Text = "IAWR :  ";
            // 
            // label_AWR
            // 
            this.label_AWR.AutoSize = true;
            this.label_AWR.Location = new System.Drawing.Point(108, 62);
            this.label_AWR.Name = "label_AWR";
            this.label_AWR.Size = new System.Drawing.Size(17, 17);
            this.label_AWR.TabIndex = 10;
            this.label_AWR.Text = "- ";
            // 
            // label_IAWT
            // 
            this.label_IAWT.AutoSize = true;
            this.label_IAWT.Location = new System.Drawing.Point(108, 90);
            this.label_IAWT.Name = "label_IAWT";
            this.label_IAWT.Size = new System.Drawing.Size(14, 17);
            this.label_IAWT.TabIndex = 8;
            this.label_IAWT.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "IAWT : ";
            // 
            // button_refresh
            // 
            this.button_refresh.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_refresh.Location = new System.Drawing.Point(552, 22);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(132, 45);
            this.button_refresh.TabIndex = 4;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // dataGridView_singleRoadData
            // 
            this.dataGridView_singleRoadData.AllowUserToAddRows = false;
            this.dataGridView_singleRoadData.AllowUserToDeleteRows = false;
            this.dataGridView_singleRoadData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_singleRoadData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_singleRoadData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_singleRoadData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Period,
            this.previousCycleRemainVehicles,
            this.enterVehicles,
            this.PassedVehicle,
            this.WaittingVehicle,
            this.VehicleWaittingRate,
            this.TotalWaittingTime});
            this.dataGridView_singleRoadData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_singleRoadData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_singleRoadData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_singleRoadData.Name = "dataGridView_singleRoadData";
            this.dataGridView_singleRoadData.ReadOnly = true;
            this.dataGridView_singleRoadData.RowTemplate.Height = 24;
            this.dataGridView_singleRoadData.Size = new System.Drawing.Size(871, 150);
            this.dataGridView_singleRoadData.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Road);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(256, 75);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(290, 59);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Road Traffic Data";
            // 
            // comboBox_Road
            // 
            this.comboBox_Road.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Road.FormattingEnabled = true;
            this.comboBox_Road.Location = new System.Drawing.Point(7, 22);
            this.comboBox_Road.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Road.Name = "comboBox_Road";
            this.comboBox_Road.Size = new System.Drawing.Size(276, 25);
            this.comboBox_Road.TabIndex = 0;
            this.comboBox_Road.SelectedIndexChanged += new System.EventHandler(this.comboBox_road_SelectedIndexChanged);
            // 
            // numericUpDown_startPeriod
            // 
            this.numericUpDown_startPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_startPeriod.Location = new System.Drawing.Point(64, 22);
            this.numericUpDown_startPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_startPeriod.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_startPeriod.Name = "numericUpDown_startPeriod";
            this.numericUpDown_startPeriod.Size = new System.Drawing.Size(61, 25);
            this.numericUpDown_startPeriod.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Start : ";
            // 
            // label_endPeriod
            // 
            this.label_endPeriod.AutoSize = true;
            this.label_endPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_endPeriod.Location = new System.Drawing.Point(164, 25);
            this.label_endPeriod.Name = "label_endPeriod";
            this.label_endPeriod.Size = new System.Drawing.Size(45, 18);
            this.label_endPeriod.TabIndex = 12;
            this.label_endPeriod.Text = "End : ";
            // 
            // numericUpDown_endPeriod
            // 
            this.numericUpDown_endPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_endPeriod.Location = new System.Drawing.Point(215, 22);
            this.numericUpDown_endPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_endPeriod.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_endPeriod.Name = "numericUpDown_endPeriod";
            this.numericUpDown_endPeriod.Size = new System.Drawing.Size(61, 25);
            this.numericUpDown_endPeriod.TabIndex = 13;
            // 
            // button_showRoadHistory
            // 
            this.button_showRoadHistory.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_showRoadHistory.Location = new System.Drawing.Point(552, 86);
            this.button_showRoadHistory.Name = "button_showRoadHistory";
            this.button_showRoadHistory.Size = new System.Drawing.Size(132, 45);
            this.button_showRoadHistory.TabIndex = 16;
            this.button_showRoadHistory.Text = "Show";
            this.button_showRoadHistory.UseVisualStyleBackColor = true;
            this.button_showRoadHistory.Click += new System.EventHandler(this.button_showRoadHistory_Click);
            // 
            // button_optSaveAsTxt
            // 
            this.button_optSaveAsTxt.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button_optSaveAsTxt.Location = new System.Drawing.Point(13, 283);
            this.button_optSaveAsTxt.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_optSaveAsTxt.Name = "button_optSaveAsTxt";
            this.button_optSaveAsTxt.Size = new System.Drawing.Size(158, 42);
            this.button_optSaveAsTxt.TabIndex = 17;
            this.button_optSaveAsTxt.Text = "Save As txt";
            this.button_optSaveAsTxt.UseVisualStyleBackColor = true;
            this.button_optSaveAsTxt.Click += new System.EventHandler(this.button_OptimizationRecordSaveAsTxt_Click);
            // 
            // button_optSaveAsExcel
            // 
            this.button_optSaveAsExcel.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button_optSaveAsExcel.Location = new System.Drawing.Point(13, 337);
            this.button_optSaveAsExcel.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_optSaveAsExcel.Name = "button_optSaveAsExcel";
            this.button_optSaveAsExcel.Size = new System.Drawing.Size(158, 42);
            this.button_optSaveAsExcel.TabIndex = 18;
            this.button_optSaveAsExcel.Text = "Save As Excel";
            this.button_optSaveAsExcel.UseVisualStyleBackColor = true;
            this.button_optSaveAsExcel.Click += new System.EventHandler(this.button_OptimizationRecordSaveAsExcel_Click);
            // 
            // groupBox_optimizationDataOutput
            // 
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_selectFolder);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_traSaveAsExcel);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_traSaveAsTxt);
            this.groupBox_optimizationDataOutput.Controls.Add(this.label3);
            this.groupBox_optimizationDataOutput.Controls.Add(this.label5);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_saveAllOptRecord);
            this.groupBox_optimizationDataOutput.Controls.Add(this.label4);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_saveAllTrafficRecord);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_optSaveAsTxt);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_optSaveAsExcel);
            this.groupBox_optimizationDataOutput.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.groupBox_optimizationDataOutput.Location = new System.Drawing.Point(892, 12);
            this.groupBox_optimizationDataOutput.Name = "groupBox_optimizationDataOutput";
            this.groupBox_optimizationDataOutput.Size = new System.Drawing.Size(184, 559);
            this.groupBox_optimizationDataOutput.TabIndex = 19;
            this.groupBox_optimizationDataOutput.TabStop = false;
            this.groupBox_optimizationDataOutput.Text = "Data Output";
            // 
            // button_selectFolder
            // 
            this.button_selectFolder.Location = new System.Drawing.Point(13, 31);
            this.button_selectFolder.Name = "button_selectFolder";
            this.button_selectFolder.Size = new System.Drawing.Size(158, 42);
            this.button_selectFolder.TabIndex = 29;
            this.button_selectFolder.Text = "Select Folder";
            this.button_selectFolder.UseVisualStyleBackColor = true;
            this.button_selectFolder.Click += new System.EventHandler(this.button_selectFolder_Click);
            // 
            // button_traSaveAsExcel
            // 
            this.button_traSaveAsExcel.Location = new System.Drawing.Point(13, 504);
            this.button_traSaveAsExcel.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_traSaveAsExcel.Name = "button_traSaveAsExcel";
            this.button_traSaveAsExcel.Size = new System.Drawing.Size(158, 42);
            this.button_traSaveAsExcel.TabIndex = 28;
            this.button_traSaveAsExcel.Text = "Save As Excel";
            this.button_traSaveAsExcel.UseVisualStyleBackColor = true;
            this.button_traSaveAsExcel.Click += new System.EventHandler(this.button_TrafficRecordSaveAsExcel_Click);
            // 
            // button_traSaveAsTxt
            // 
            this.button_traSaveAsTxt.Location = new System.Drawing.Point(13, 450);
            this.button_traSaveAsTxt.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_traSaveAsTxt.Name = "button_traSaveAsTxt";
            this.button_traSaveAsTxt.Size = new System.Drawing.Size(158, 42);
            this.button_traSaveAsTxt.TabIndex = 27;
            this.button_traSaveAsTxt.Text = "Save As txt";
            this.button_traSaveAsTxt.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "-       Traffic Record       -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "-      All Intersection     -";
            // 
            // button_saveAllOptRecord
            // 
            this.button_saveAllOptRecord.Location = new System.Drawing.Point(13, 169);
            this.button_saveAllOptRecord.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_saveAllOptRecord.Name = "button_saveAllOptRecord";
            this.button_saveAllOptRecord.Size = new System.Drawing.Size(158, 42);
            this.button_saveAllOptRecord.TabIndex = 24;
            this.button_saveAllOptRecord.Text = "Optimization Record";
            this.button_saveAllOptRecord.UseVisualStyleBackColor = true;
            this.button_saveAllOptRecord.Click += new System.EventHandler(this.button_SaveAllOptimizationRecord);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "- Optimization Record -";
            // 
            // button_saveAllTrafficRecord
            // 
            this.button_saveAllTrafficRecord.Location = new System.Drawing.Point(13, 115);
            this.button_saveAllTrafficRecord.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_saveAllTrafficRecord.Name = "button_saveAllTrafficRecord";
            this.button_saveAllTrafficRecord.Size = new System.Drawing.Size(158, 42);
            this.button_saveAllTrafficRecord.TabIndex = 19;
            this.button_saveAllTrafficRecord.Text = "Traffic Record";
            this.button_saveAllTrafficRecord.UseVisualStyleBackColor = true;
            this.button_saveAllTrafficRecord.Click += new System.EventHandler(this.button_saveAllTrafficRecord_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDown_endPeriod);
            this.groupBox4.Controls.Add(this.label_endPeriod);
            this.groupBox4.Controls.Add(this.numericUpDown_startPeriod);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(256, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(290, 58);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Display Cycle";
            // 
            // splitContainer_data
            // 
            this.splitContainer_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer_data.Location = new System.Drawing.Point(15, 156);
            this.splitContainer_data.Name = "splitContainer_data";
            this.splitContainer_data.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_data.Panel1
            // 
            this.splitContainer_data.Panel1.Controls.Add(this.splitContainer_intersectionData);
            this.splitContainer_data.Panel1MinSize = 300;
            // 
            // splitContainer_data.Panel2
            // 
            this.splitContainer_data.Panel2.Controls.Add(this.dataGridView_singleRoadData);
            this.splitContainer_data.Panel2MinSize = 150;
            this.splitContainer_data.Size = new System.Drawing.Size(871, 550);
            this.splitContainer_data.SplitterDistance = 396;
            this.splitContainer_data.TabIndex = 22;
            // 
            // splitContainer_intersectionData
            // 
            this.splitContainer_intersectionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_intersectionData.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_intersectionData.Name = "splitContainer_intersectionData";
            this.splitContainer_intersectionData.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_intersectionData.Panel1
            // 
            this.splitContainer_intersectionData.Panel1.Controls.Add(this.dataGridView_intersectionData);
            this.splitContainer_intersectionData.Panel1MinSize = 150;
            // 
            // splitContainer_intersectionData.Panel2
            // 
            this.splitContainer_intersectionData.Panel2.Controls.Add(this.dataGridView_optimizeationData);
            this.splitContainer_intersectionData.Panel2MinSize = 200;
            this.splitContainer_intersectionData.Size = new System.Drawing.Size(871, 396);
            this.splitContainer_intersectionData.SplitterDistance = 150;
            this.splitContainer_intersectionData.TabIndex = 0;
            // 
            // dataGridView_intersectionData
            // 
            this.dataGridView_intersectionData.AllowUserToAddRows = false;
            this.dataGridView_intersectionData.AllowUserToDeleteRows = false;
            this.dataGridView_intersectionData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_intersectionData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_intersectionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_intersectionData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoadID,
            this.AverageArrivalVehicle,
            this.AverageWaitingVehicle,
            this.AverageWaittingRate,
            this.AverageWaittingTime});
            this.dataGridView_intersectionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_intersectionData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_intersectionData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_intersectionData.Name = "dataGridView_intersectionData";
            this.dataGridView_intersectionData.ReadOnly = true;
            this.dataGridView_intersectionData.RowTemplate.Height = 24;
            this.dataGridView_intersectionData.Size = new System.Drawing.Size(871, 150);
            this.dataGridView_intersectionData.TabIndex = 0;
            // 
            // dataGridView_optimizeationData
            // 
            this.dataGridView_optimizeationData.AllowUserToAddRows = false;
            this.dataGridView_optimizeationData.AllowUserToDeleteRows = false;
            this.dataGridView_optimizeationData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_optimizeationData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_optimizeationData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_optimizeationData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OptimizeCycle,
            this.OptimizeTime,
            this.IAWR,
            this.IAWRThreshold,
            this.originConfiguration,
            this.optimizedConfiguration});
            this.dataGridView_optimizeationData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_optimizeationData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_optimizeationData.Name = "dataGridView_optimizeationData";
            this.dataGridView_optimizeationData.ReadOnly = true;
            this.dataGridView_optimizeationData.RowTemplate.Height = 24;
            this.dataGridView_optimizeationData.Size = new System.Drawing.Size(871, 242);
            this.dataGridView_optimizeationData.TabIndex = 0;
            // 
            // Period
            // 
            this.Period.FillWeight = 20F;
            this.Period.HeaderText = "Cycle";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // previousCycleRemainVehicles
            // 
            this.previousCycleRemainVehicles.FillWeight = 40F;
            this.previousCycleRemainVehicles.HeaderText = "previous vehicle";
            this.previousCycleRemainVehicles.Name = "previousCycleRemainVehicles";
            this.previousCycleRemainVehicles.ReadOnly = true;
            this.previousCycleRemainVehicles.ToolTipText = "Remain vehicles of previous cycle";
            // 
            // enterVehicles
            // 
            this.enterVehicles.FillWeight = 40F;
            this.enterVehicles.HeaderText = "ArrivalVehicles";
            this.enterVehicles.Name = "enterVehicles";
            this.enterVehicles.ReadOnly = true;
            // 
            // PassedVehicle
            // 
            this.PassedVehicle.FillWeight = 40F;
            this.PassedVehicle.HeaderText = "PassedVehicle";
            this.PassedVehicle.Name = "PassedVehicle";
            this.PassedVehicle.ReadOnly = true;
            // 
            // WaittingVehicle
            // 
            this.WaittingVehicle.FillWeight = 40F;
            this.WaittingVehicle.HeaderText = "WaitingVehicle";
            this.WaittingVehicle.Name = "WaittingVehicle";
            this.WaittingVehicle.ReadOnly = true;
            // 
            // VehicleWaittingRate
            // 
            this.VehicleWaittingRate.FillWeight = 30F;
            this.VehicleWaittingRate.HeaderText = "WR(%)";
            this.VehicleWaittingRate.Name = "VehicleWaittingRate";
            this.VehicleWaittingRate.ReadOnly = true;
            this.VehicleWaittingRate.ToolTipText = "Waiting Rate";
            // 
            // TotalWaittingTime
            // 
            this.TotalWaittingTime.FillWeight = 30F;
            this.TotalWaittingTime.HeaderText = "TWT(sec)";
            this.TotalWaittingTime.Name = "TotalWaittingTime";
            this.TotalWaittingTime.ReadOnly = true;
            this.TotalWaittingTime.ToolTipText = "Total waiting of all vehicle";
            // 
            // OptimizeCycle
            // 
            this.OptimizeCycle.FillWeight = 30F;
            this.OptimizeCycle.HeaderText = "Cycle";
            this.OptimizeCycle.Name = "OptimizeCycle";
            this.OptimizeCycle.ReadOnly = true;
            this.OptimizeCycle.ToolTipText = "Perform optimization cycle";
            // 
            // OptimizeTime
            // 
            this.OptimizeTime.FillWeight = 50F;
            this.OptimizeTime.HeaderText = "Time";
            this.OptimizeTime.Name = "OptimizeTime";
            this.OptimizeTime.ReadOnly = true;
            // 
            // IAWR
            // 
            this.IAWR.FillWeight = 30F;
            this.IAWR.HeaderText = "IAWR";
            this.IAWR.Name = "IAWR";
            this.IAWR.ReadOnly = true;
            this.IAWR.ToolTipText = "IntersectionAverageWaitingRate";
            // 
            // IAWRThreshold
            // 
            this.IAWRThreshold.FillWeight = 30F;
            this.IAWRThreshold.HeaderText = "IAWRT";
            this.IAWRThreshold.Name = "IAWRThreshold";
            this.IAWRThreshold.ReadOnly = true;
            this.IAWRThreshold.ToolTipText = "Optimization Threshold";
            // 
            // originConfiguration
            // 
            this.originConfiguration.FillWeight = 120F;
            this.originConfiguration.HeaderText = "Origin";
            this.originConfiguration.Name = "originConfiguration";
            this.originConfiguration.ReadOnly = true;
            this.originConfiguration.ToolTipText = "Origin Configs";
            // 
            // optimizedConfiguration
            // 
            this.optimizedConfiguration.FillWeight = 120F;
            this.optimizedConfiguration.HeaderText = "Optimized";
            this.optimizedConfiguration.Name = "optimizedConfiguration";
            this.optimizedConfiguration.ReadOnly = true;
            this.optimizedConfiguration.ToolTipText = "Optimized Configs";
            // 
            // RoadID
            // 
            this.RoadID.FillWeight = 25F;
            this.RoadID.HeaderText = "RoadID";
            this.RoadID.Name = "RoadID";
            this.RoadID.ReadOnly = true;
            // 
            // AverageArrivalVehicle
            // 
            this.AverageArrivalVehicle.FillWeight = 50F;
            this.AverageArrivalVehicle.HeaderText = "AvgArrivalVehicle";
            this.AverageArrivalVehicle.Name = "AverageArrivalVehicle";
            this.AverageArrivalVehicle.ReadOnly = true;
            // 
            // AverageWaitingVehicle
            // 
            this.AverageWaitingVehicle.FillWeight = 50F;
            this.AverageWaitingVehicle.HeaderText = "AvgWaitingVehicle";
            this.AverageWaitingVehicle.Name = "AverageWaitingVehicle";
            this.AverageWaitingVehicle.ReadOnly = true;
            // 
            // AverageWaittingRate
            // 
            this.AverageWaittingRate.FillWeight = 60F;
            this.AverageWaittingRate.HeaderText = "AvgWaitingRate (%)";
            this.AverageWaittingRate.Name = "AverageWaittingRate";
            this.AverageWaittingRate.ReadOnly = true;
            // 
            // AverageWaittingTime
            // 
            this.AverageWaittingTime.FillWeight = 60F;
            this.AverageWaittingTime.HeaderText = "AvgWaitingTime (second)";
            this.AverageWaittingTime.Name = "AverageWaittingTime";
            this.AverageWaittingTime.ReadOnly = true;
            // 
            // DataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 717);
            this.Controls.Add(this.button_showRoadHistory);
            this.Controls.Add(this.splitContainer_data);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox_optimizationDataOutput);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataDisplay";
            this.Text = "Traffic Data";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_singleRoadData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endPeriod)).EndInit();
            this.groupBox_optimizationDataOutput.ResumeLayout(false);
            this.groupBox_optimizationDataOutput.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer_data.Panel1.ResumeLayout(false);
            this.splitContainer_data.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_data)).EndInit();
            this.splitContainer_data.ResumeLayout(false);
            this.splitContainer_intersectionData.Panel1.ResumeLayout(false);
            this.splitContainer_intersectionData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_intersectionData)).EndInit();
            this.splitContainer_intersectionData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_intersectionData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_optimizeationData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Intersections;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.DataGridView dataGridView_singleRoadData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_Road;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_IAWT;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.NumericUpDown numericUpDown_startPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_endPeriod;
        private System.Windows.Forms.NumericUpDown numericUpDown_endPeriod;
        private System.Windows.Forms.Label label_sec;
        private System.Windows.Forms.Label label_pa;
        private System.Windows.Forms.Label label_AWR;
        private System.Windows.Forms.Button button_showRoadHistory;
        private System.Windows.Forms.Button button_optSaveAsTxt;
        private System.Windows.Forms.Button button_optSaveAsExcel;
        private System.Windows.Forms.GroupBox groupBox_optimizationDataOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_saveAllOptRecord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_saveAllTrafficRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_traSaveAsExcel;
        private System.Windows.Forms.Button button_traSaveAsTxt;
        private System.Windows.Forms.Button button_selectFolder;
        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer_data;
        private System.Windows.Forms.SplitContainer splitContainer_intersectionData;
        private System.Windows.Forms.DataGridView dataGridView_intersectionData;
        private System.Windows.Forms.DataGridView dataGridView_optimizeationData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousCycleRemainVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn enterVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassedVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaittingVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleWaittingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalWaittingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptimizeCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptimizeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IAWR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IAWRThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn originConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimizedConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageArrivalVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaitingVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaittingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaittingTime;
    }
}