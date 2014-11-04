namespace SmartCitySimulator
{
    partial class TrafficDataDisplay
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
            this.dataGridView_intersectionData = new System.Windows.Forms.DataGridView();
            this.Road = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AveragePassedVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaittingVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageVehicleWaittingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaittingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Intersections = new System.Windows.Forms.ComboBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.dataGridView_singleRoadData = new System.Windows.Forms.DataGridView();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousCycleRemainVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enterVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassedVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaittingVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleWaittingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalWaittingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Road = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_IAWT = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_sec = new System.Windows.Forms.Label();
            this.label_pa = new System.Windows.Forms.Label();
            this.label_AWR = new System.Windows.Forms.Label();
            this.label_2 = new System.Windows.Forms.Label();
            this.numericUpDown_startPeriod = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label_endPeriod = new System.Windows.Forms.Label();
            this.numericUpDown_endPeriod = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_optimizeationData = new System.Windows.Forms.DataGridView();
            this.OptimizeCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptimizeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IAWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IAWRThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optimizedConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_showRoadHistory = new System.Windows.Forms.Button();
            this.button_optSaveAsTxt = new System.Windows.Forms.Button();
            this.button_optSaveAsExcel = new System.Windows.Forms.Button();
            this.groupBox_optimizationDataOutput = new System.Windows.Forms.GroupBox();
            this.button_trafficSaveAsExcel = new System.Windows.Forms.Button();
            this.button_trafficSaveAsTxt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_allSaveAsExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_allSaveAsTxt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_intersectionData)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_singleRoadData)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endPeriod)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_optimizeationData)).BeginInit();
            this.groupBox_optimizationDataOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_intersectionData
            // 
            this.dataGridView_intersectionData.AllowUserToAddRows = false;
            this.dataGridView_intersectionData.AllowUserToDeleteRows = false;
            this.dataGridView_intersectionData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_intersectionData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_intersectionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_intersectionData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Road,
            this.AveragePassedVehicle,
            this.AverageWaittingVehicle,
            this.AverageVehicleWaittingRate,
            this.AverageWaittingTime});
            this.dataGridView_intersectionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_intersectionData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_intersectionData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_intersectionData.Name = "dataGridView_intersectionData";
            this.dataGridView_intersectionData.ReadOnly = true;
            this.dataGridView_intersectionData.RowTemplate.Height = 24;
            this.dataGridView_intersectionData.Size = new System.Drawing.Size(862, 138);
            this.dataGridView_intersectionData.TabIndex = 0;
            // 
            // Road
            // 
            this.Road.FillWeight = 15F;
            this.Road.HeaderText = "道路";
            this.Road.Name = "Road";
            this.Road.ReadOnly = true;
            // 
            // AveragePassedVehicle
            // 
            this.AveragePassedVehicle.FillWeight = 25F;
            this.AveragePassedVehicle.HeaderText = "平均進入車輛";
            this.AveragePassedVehicle.Name = "AveragePassedVehicle";
            this.AveragePassedVehicle.ReadOnly = true;
            // 
            // AverageWaittingVehicle
            // 
            this.AverageWaittingVehicle.FillWeight = 25F;
            this.AverageWaittingVehicle.HeaderText = "平均等待車輛";
            this.AverageWaittingVehicle.Name = "AverageWaittingVehicle";
            this.AverageWaittingVehicle.ReadOnly = true;
            // 
            // AverageVehicleWaittingRate
            // 
            this.AverageVehicleWaittingRate.FillWeight = 30F;
            this.AverageVehicleWaittingRate.HeaderText = "平均車輛等待率(%)";
            this.AverageVehicleWaittingRate.Name = "AverageVehicleWaittingRate";
            this.AverageVehicleWaittingRate.ReadOnly = true;
            // 
            // AverageWaittingTime
            // 
            this.AverageWaittingTime.FillWeight = 30F;
            this.AverageWaittingTime.HeaderText = "平均等待時間(sec)";
            this.AverageWaittingTime.Name = "AverageWaittingTime";
            this.AverageWaittingTime.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_intersectionData);
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.panel1.Location = new System.Drawing.Point(15, 134);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 138);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Intersections);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(329, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選擇路口";
            // 
            // comboBox_Intersections
            // 
            this.comboBox_Intersections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Intersections.FormattingEnabled = true;
            this.comboBox_Intersections.Location = new System.Drawing.Point(8, 18);
            this.comboBox_Intersections.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Intersections.Name = "comboBox_Intersections";
            this.comboBox_Intersections.Size = new System.Drawing.Size(313, 25);
            this.comboBox_Intersections.TabIndex = 0;
            this.comboBox_Intersections.SelectedIndexChanged += new System.EventHandler(this.comboBox_Intersections_SelectedIndexChanged);
            // 
            // button_refresh
            // 
            this.button_refresh.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button_refresh.Location = new System.Drawing.Point(766, 23);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(111, 89);
            this.button_refresh.TabIndex = 4;
            this.button_refresh.Text = "更新";
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
            this.dataGridView_singleRoadData.Size = new System.Drawing.Size(863, 200);
            this.dataGridView_singleRoadData.TabIndex = 5;
            // 
            // Period
            // 
            this.Period.FillWeight = 20F;
            this.Period.HeaderText = "周期";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // previousCycleRemainVehicles
            // 
            this.previousCycleRemainVehicles.FillWeight = 30F;
            this.previousCycleRemainVehicles.HeaderText = "前週期車輛";
            this.previousCycleRemainVehicles.Name = "previousCycleRemainVehicles";
            this.previousCycleRemainVehicles.ReadOnly = true;
            // 
            // enterVehicles
            // 
            this.enterVehicles.FillWeight = 30F;
            this.enterVehicles.HeaderText = "進入車輛";
            this.enterVehicles.Name = "enterVehicles";
            this.enterVehicles.ReadOnly = true;
            // 
            // PassedVehicle
            // 
            this.PassedVehicle.FillWeight = 30F;
            this.PassedVehicle.HeaderText = "通過車輛";
            this.PassedVehicle.Name = "PassedVehicle";
            this.PassedVehicle.ReadOnly = true;
            // 
            // WaittingVehicle
            // 
            this.WaittingVehicle.FillWeight = 30F;
            this.WaittingVehicle.HeaderText = "等待車輛";
            this.WaittingVehicle.Name = "WaittingVehicle";
            this.WaittingVehicle.ReadOnly = true;
            // 
            // VehicleWaittingRate
            // 
            this.VehicleWaittingRate.FillWeight = 40F;
            this.VehicleWaittingRate.HeaderText = "車輛等待率(%)";
            this.VehicleWaittingRate.Name = "VehicleWaittingRate";
            this.VehicleWaittingRate.ReadOnly = true;
            // 
            // TotalWaittingTime
            // 
            this.TotalWaittingTime.FillWeight = 40F;
            this.TotalWaittingTime.HeaderText = "總等待時間(sec)";
            this.TotalWaittingTime.Name = "TotalWaittingTime";
            this.TotalWaittingTime.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_singleRoadData);
            this.panel2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.panel2.Location = new System.Drawing.Point(14, 579);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 200);
            this.panel2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Road);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.groupBox2.Location = new System.Drawing.Point(15, 518);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(307, 53);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "選擇道路";
            // 
            // comboBox_Road
            // 
            this.comboBox_Road.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Road.FormattingEnabled = true;
            this.comboBox_Road.Location = new System.Drawing.Point(8, 20);
            this.comboBox_Road.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Road.Name = "comboBox_Road";
            this.comboBox_Road.Size = new System.Drawing.Size(282, 25);
            this.comboBox_Road.TabIndex = 0;
            this.comboBox_Road.SelectedIndexChanged += new System.EventHandler(this.comboBox_road_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "平均等待時間 : ";
            // 
            // label_IAWT
            // 
            this.label_IAWT.AutoSize = true;
            this.label_IAWT.Location = new System.Drawing.Point(136, 61);
            this.label_IAWT.Name = "label_IAWT";
            this.label_IAWT.Size = new System.Drawing.Size(14, 17);
            this.label_IAWT.TabIndex = 8;
            this.label_IAWT.Text = "-";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_sec);
            this.groupBox3.Controls.Add(this.label_pa);
            this.groupBox3.Controls.Add(this.label_AWR);
            this.groupBox3.Controls.Add(this.label_2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label_IAWT);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(359, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(401, 96);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "路口數據";
            // 
            // label_sec
            // 
            this.label_sec.AutoSize = true;
            this.label_sec.Location = new System.Drawing.Point(185, 61);
            this.label_sec.Name = "label_sec";
            this.label_sec.Size = new System.Drawing.Size(27, 17);
            this.label_sec.TabIndex = 12;
            this.label_sec.Text = "sec";
            // 
            // label_pa
            // 
            this.label_pa.AutoSize = true;
            this.label_pa.Location = new System.Drawing.Point(185, 25);
            this.label_pa.Name = "label_pa";
            this.label_pa.Size = new System.Drawing.Size(19, 17);
            this.label_pa.TabIndex = 11;
            this.label_pa.Text = "%";
            // 
            // label_AWR
            // 
            this.label_AWR.AutoSize = true;
            this.label_AWR.Location = new System.Drawing.Point(136, 25);
            this.label_AWR.Name = "label_AWR";
            this.label_AWR.Size = new System.Drawing.Size(17, 17);
            this.label_AWR.TabIndex = 10;
            this.label_AWR.Text = "- ";
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.Location = new System.Drawing.Point(7, 25);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(94, 17);
            this.label_2.TabIndex = 9;
            this.label_2.Text = "平均等待率     : ";
            // 
            // numericUpDown_startPeriod
            // 
            this.numericUpDown_startPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_startPeriod.Location = new System.Drawing.Point(100, 77);
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
            this.label2.Location = new System.Drawing.Point(20, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "起始周期 : ";
            // 
            // label_endPeriod
            // 
            this.label_endPeriod.AutoSize = true;
            this.label_endPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_endPeriod.Location = new System.Drawing.Point(204, 81);
            this.label_endPeriod.Name = "label_endPeriod";
            this.label_endPeriod.Size = new System.Drawing.Size(75, 18);
            this.label_endPeriod.TabIndex = 12;
            this.label_endPeriod.Text = "結束周期 : ";
            // 
            // numericUpDown_endPeriod
            // 
            this.numericUpDown_endPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_endPeriod.Location = new System.Drawing.Point(283, 77);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView_optimizeationData);
            this.panel3.Location = new System.Drawing.Point(14, 279);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(863, 232);
            this.panel3.TabIndex = 14;
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
            this.dataGridView_optimizeationData.Size = new System.Drawing.Size(863, 232);
            this.dataGridView_optimizeationData.TabIndex = 0;
            // 
            // OptimizeCycle
            // 
            this.OptimizeCycle.FillWeight = 50F;
            this.OptimizeCycle.HeaderText = "週期";
            this.OptimizeCycle.Name = "OptimizeCycle";
            this.OptimizeCycle.ReadOnly = true;
            // 
            // OptimizeTime
            // 
            this.OptimizeTime.FillWeight = 50F;
            this.OptimizeTime.HeaderText = "時間";
            this.OptimizeTime.Name = "OptimizeTime";
            this.OptimizeTime.ReadOnly = true;
            // 
            // IAWR
            // 
            this.IAWR.FillWeight = 30F;
            this.IAWR.HeaderText = "IAWR";
            this.IAWR.Name = "IAWR";
            this.IAWR.ReadOnly = true;
            // 
            // IAWRThreshold
            // 
            this.IAWRThreshold.FillWeight = 60F;
            this.IAWRThreshold.HeaderText = "IAWR門檻";
            this.IAWRThreshold.Name = "IAWRThreshold";
            this.IAWRThreshold.ReadOnly = true;
            // 
            // originConfiguration
            // 
            this.originConfiguration.FillWeight = 125F;
            this.originConfiguration.HeaderText = "優化前設定";
            this.originConfiguration.Name = "originConfiguration";
            this.originConfiguration.ReadOnly = true;
            // 
            // optimizedConfiguration
            // 
            this.optimizedConfiguration.FillWeight = 125F;
            this.optimizedConfiguration.HeaderText = "優化後設定";
            this.optimizedConfiguration.Name = "optimizedConfiguration";
            this.optimizedConfiguration.ReadOnly = true;
            // 
            // button_showRoadHistory
            // 
            this.button_showRoadHistory.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button_showRoadHistory.Location = new System.Drawing.Point(367, 530);
            this.button_showRoadHistory.Name = "button_showRoadHistory";
            this.button_showRoadHistory.Size = new System.Drawing.Size(100, 35);
            this.button_showRoadHistory.TabIndex = 16;
            this.button_showRoadHistory.Text = "顯示";
            this.button_showRoadHistory.UseVisualStyleBackColor = true;
            this.button_showRoadHistory.Click += new System.EventHandler(this.button_showRoadHistory_Click);
            // 
            // button_optSaveAsTxt
            // 
            this.button_optSaveAsTxt.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button_optSaveAsTxt.Location = new System.Drawing.Point(13, 220);
            this.button_optSaveAsTxt.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_optSaveAsTxt.Name = "button_optSaveAsTxt";
            this.button_optSaveAsTxt.Size = new System.Drawing.Size(158, 42);
            this.button_optSaveAsTxt.TabIndex = 17;
            this.button_optSaveAsTxt.Text = "Save As txt";
            this.button_optSaveAsTxt.UseVisualStyleBackColor = true;
            this.button_optSaveAsTxt.Click += new System.EventHandler(this.button_optSaveTofile_Click);
            // 
            // button_optSaveAsExcel
            // 
            this.button_optSaveAsExcel.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button_optSaveAsExcel.Location = new System.Drawing.Point(13, 274);
            this.button_optSaveAsExcel.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_optSaveAsExcel.Name = "button_optSaveAsExcel";
            this.button_optSaveAsExcel.Size = new System.Drawing.Size(158, 42);
            this.button_optSaveAsExcel.TabIndex = 18;
            this.button_optSaveAsExcel.Text = "Save As Excel";
            this.button_optSaveAsExcel.UseVisualStyleBackColor = true;
            this.button_optSaveAsExcel.Click += new System.EventHandler(this.button_optSaveAsExcel_Click);
            // 
            // groupBox_optimizationDataOutput
            // 
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_trafficSaveAsExcel);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_trafficSaveAsTxt);
            this.groupBox_optimizationDataOutput.Controls.Add(this.label3);
            this.groupBox_optimizationDataOutput.Controls.Add(this.label5);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_allSaveAsExcel);
            this.groupBox_optimizationDataOutput.Controls.Add(this.label4);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_allSaveAsTxt);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_optSaveAsTxt);
            this.groupBox_optimizationDataOutput.Controls.Add(this.button_optSaveAsExcel);
            this.groupBox_optimizationDataOutput.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.groupBox_optimizationDataOutput.Location = new System.Drawing.Point(892, 16);
            this.groupBox_optimizationDataOutput.Name = "groupBox_optimizationDataOutput";
            this.groupBox_optimizationDataOutput.Size = new System.Drawing.Size(184, 495);
            this.groupBox_optimizationDataOutput.TabIndex = 19;
            this.groupBox_optimizationDataOutput.TabStop = false;
            this.groupBox_optimizationDataOutput.Text = "Data Output";
            // 
            // button_trafficSaveAsExcel
            // 
            this.button_trafficSaveAsExcel.Location = new System.Drawing.Point(13, 441);
            this.button_trafficSaveAsExcel.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_trafficSaveAsExcel.Name = "button_trafficSaveAsExcel";
            this.button_trafficSaveAsExcel.Size = new System.Drawing.Size(158, 42);
            this.button_trafficSaveAsExcel.TabIndex = 28;
            this.button_trafficSaveAsExcel.Text = "Save As Excel";
            this.button_trafficSaveAsExcel.UseVisualStyleBackColor = true;
            this.button_trafficSaveAsExcel.Click += new System.EventHandler(this.button_trafficSaveAsExcel_Click);
            // 
            // button_trafficSaveAsTxt
            // 
            this.button_trafficSaveAsTxt.Location = new System.Drawing.Point(13, 387);
            this.button_trafficSaveAsTxt.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_trafficSaveAsTxt.Name = "button_trafficSaveAsTxt";
            this.button_trafficSaveAsTxt.Size = new System.Drawing.Size(158, 42);
            this.button_trafficSaveAsTxt.TabIndex = 27;
            this.button_trafficSaveAsTxt.Text = "Save As txt";
            this.button_trafficSaveAsTxt.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "-       Traffic Record       -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "-      All Intersection     -";
            // 
            // button_allSaveAsExcel
            // 
            this.button_allSaveAsExcel.Location = new System.Drawing.Point(13, 106);
            this.button_allSaveAsExcel.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_allSaveAsExcel.Name = "button_allSaveAsExcel";
            this.button_allSaveAsExcel.Size = new System.Drawing.Size(158, 42);
            this.button_allSaveAsExcel.TabIndex = 24;
            this.button_allSaveAsExcel.Text = "Save As Excel";
            this.button_allSaveAsExcel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "- Optimization Record -";
            // 
            // button_allSaveAsTxt
            // 
            this.button_allSaveAsTxt.Location = new System.Drawing.Point(13, 52);
            this.button_allSaveAsTxt.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.button_allSaveAsTxt.Name = "button_allSaveAsTxt";
            this.button_allSaveAsTxt.Size = new System.Drawing.Size(158, 42);
            this.button_allSaveAsTxt.TabIndex = 19;
            this.button_allSaveAsTxt.Text = "Save As txt";
            this.button_allSaveAsTxt.UseVisualStyleBackColor = true;
            // 
            // TrafficDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 792);
            this.Controls.Add(this.groupBox_optimizationDataOutput);
            this.Controls.Add(this.button_showRoadHistory);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.numericUpDown_endPeriod);
            this.Controls.Add(this.label_endPeriod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_startPeriod);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrafficDataDisplay";
            this.Text = "Data";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_intersectionData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_singleRoadData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endPeriod)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_optimizeationData)).EndInit();
            this.groupBox_optimizationDataOutput.ResumeLayout(false);
            this.groupBox_optimizationDataOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_intersectionData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Intersections;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.DataGridView dataGridView_singleRoadData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_Road;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_IAWT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.NumericUpDown numericUpDown_startPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_endPeriod;
        private System.Windows.Forms.NumericUpDown numericUpDown_endPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Road;
        private System.Windows.Forms.DataGridViewTextBoxColumn AveragePassedVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaittingVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageVehicleWaittingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaittingTime;
        private System.Windows.Forms.Label label_sec;
        private System.Windows.Forms.Label label_pa;
        private System.Windows.Forms.Label label_AWR;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView_optimizeationData;
        private System.Windows.Forms.Button button_showRoadHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptimizeCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptimizeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IAWR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IAWRThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn originConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimizedConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousCycleRemainVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn enterVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassedVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaittingVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleWaittingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalWaittingTime;
        private System.Windows.Forms.Button button_optSaveAsTxt;
        private System.Windows.Forms.Button button_optSaveAsExcel;
        private System.Windows.Forms.GroupBox groupBox_optimizationDataOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_allSaveAsExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_allSaveAsTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_trafficSaveAsExcel;
        private System.Windows.Forms.Button button_trafficSaveAsTxt;
    }
}