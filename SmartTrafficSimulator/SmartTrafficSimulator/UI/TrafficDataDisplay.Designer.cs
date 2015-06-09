namespace SmartTrafficSimulator
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrafficDataDisplay));
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
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.previousCycleRemainVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enterVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassedVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaittingVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleWaittingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalWaittingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Road = new System.Windows.Forms.ComboBox();
            this.button_showRoadHistory = new System.Windows.Forms.Button();
            this.numericUpDown_startPeriod = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label_endPeriod = new System.Windows.Forms.Label();
            this.numericUpDown_endPeriod = new System.Windows.Forms.NumericUpDown();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitContainer_data = new System.Windows.Forms.SplitContainer();
            this.splitContainer_intersectionData = new System.Windows.Forms.SplitContainer();
            this.dataGridView_intersectionData = new System.Windows.Forms.DataGridView();
            this.RoadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageArrivalRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaitingVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaittingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaittingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_optimizeationData = new System.Windows.Forms.DataGridView();
            this.OptimizeCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptimizeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IAWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IAWRThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optimizedConfiguration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_intersectionAndRoad = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_singleRoadData)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endPeriod)).BeginInit();
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
            this.groupBox_intersectionAndRoad.SuspendLayout();
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
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(6, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(419, 127);
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
            this.comboBox_Intersections.BackColor = System.Drawing.Color.White;
            this.comboBox_Intersections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Intersections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Intersections.ForeColor = System.Drawing.SystemColors.WindowText;
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
            this.button_refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_refresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_refresh.FlatAppearance.BorderSize = 0;
            this.button_refresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_refresh.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_refresh.Location = new System.Drawing.Point(289, 16);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(126, 35);
            this.button_refresh.TabIndex = 4;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // dataGridView_singleRoadData
            // 
            this.dataGridView_singleRoadData.AllowUserToAddRows = false;
            this.dataGridView_singleRoadData.AllowUserToDeleteRows = false;
            this.dataGridView_singleRoadData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_singleRoadData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_singleRoadData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView_singleRoadData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_singleRoadData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dataGridView_singleRoadData.Size = new System.Drawing.Size(887, 155);
            this.dataGridView_singleRoadData.TabIndex = 5;
            // 
            // Period
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Period.DefaultCellStyle = dataGridViewCellStyle2;
            this.Period.FillWeight = 20F;
            this.Period.HeaderText = "Cycle";
            this.Period.Name = "Period";
            this.Period.ReadOnly = true;
            // 
            // previousCycleRemainVehicles
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.previousCycleRemainVehicles.DefaultCellStyle = dataGridViewCellStyle3;
            this.previousCycleRemainVehicles.FillWeight = 40F;
            this.previousCycleRemainVehicles.HeaderText = "Previous vehicle";
            this.previousCycleRemainVehicles.Name = "previousCycleRemainVehicles";
            this.previousCycleRemainVehicles.ReadOnly = true;
            this.previousCycleRemainVehicles.ToolTipText = "Remain vehicles of previous cycle";
            // 
            // enterVehicles
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.enterVehicles.DefaultCellStyle = dataGridViewCellStyle4;
            this.enterVehicles.FillWeight = 40F;
            this.enterVehicles.HeaderText = "ArrivalVehicles";
            this.enterVehicles.Name = "enterVehicles";
            this.enterVehicles.ReadOnly = true;
            // 
            // PassedVehicle
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.PassedVehicle.DefaultCellStyle = dataGridViewCellStyle5;
            this.PassedVehicle.FillWeight = 40F;
            this.PassedVehicle.HeaderText = "PassedVehicle";
            this.PassedVehicle.Name = "PassedVehicle";
            this.PassedVehicle.ReadOnly = true;
            // 
            // WaittingVehicle
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.WaittingVehicle.DefaultCellStyle = dataGridViewCellStyle6;
            this.WaittingVehicle.FillWeight = 40F;
            this.WaittingVehicle.HeaderText = "WaitingVehicle";
            this.WaittingVehicle.Name = "WaittingVehicle";
            this.WaittingVehicle.ReadOnly = true;
            // 
            // VehicleWaittingRate
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.VehicleWaittingRate.DefaultCellStyle = dataGridViewCellStyle7;
            this.VehicleWaittingRate.FillWeight = 30F;
            this.VehicleWaittingRate.HeaderText = "WR(%)";
            this.VehicleWaittingRate.Name = "VehicleWaittingRate";
            this.VehicleWaittingRate.ReadOnly = true;
            this.VehicleWaittingRate.ToolTipText = "Waiting Rate";
            // 
            // TotalWaittingTime
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.TotalWaittingTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.TotalWaittingTime.FillWeight = 30F;
            this.TotalWaittingTime.HeaderText = "TWT(sec)";
            this.TotalWaittingTime.Name = "TotalWaittingTime";
            this.TotalWaittingTime.ReadOnly = true;
            this.TotalWaittingTime.ToolTipText = "Waiting time of all vehicle in this cycle";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Road);
            this.groupBox2.Controls.Add(this.button_showRoadHistory);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(431, 90);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(463, 60);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Road Traffic Data";
            // 
            // comboBox_Road
            // 
            this.comboBox_Road.BackColor = System.Drawing.Color.White;
            this.comboBox_Road.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Road.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Road.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Road.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboBox_Road.FormattingEnabled = true;
            this.comboBox_Road.Location = new System.Drawing.Point(7, 22);
            this.comboBox_Road.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Road.Name = "comboBox_Road";
            this.comboBox_Road.Size = new System.Drawing.Size(276, 25);
            this.comboBox_Road.TabIndex = 0;
            this.comboBox_Road.SelectedIndexChanged += new System.EventHandler(this.comboBox_road_SelectedIndexChanged);
            // 
            // button_showRoadHistory
            // 
            this.button_showRoadHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_showRoadHistory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_showRoadHistory.FlatAppearance.BorderSize = 0;
            this.button_showRoadHistory.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_showRoadHistory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_showRoadHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_showRoadHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_showRoadHistory.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_showRoadHistory.Location = new System.Drawing.Point(289, 16);
            this.button_showRoadHistory.Name = "button_showRoadHistory";
            this.button_showRoadHistory.Size = new System.Drawing.Size(126, 35);
            this.button_showRoadHistory.TabIndex = 16;
            this.button_showRoadHistory.Text = "Show";
            this.button_showRoadHistory.UseVisualStyleBackColor = false;
            this.button_showRoadHistory.Click += new System.EventHandler(this.button_showRoadHistory_Click);
            // 
            // numericUpDown_startPeriod
            // 
            this.numericUpDown_startPeriod.BackColor = System.Drawing.Color.White;
            this.numericUpDown_startPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_startPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_startPeriod.Location = new System.Drawing.Point(64, 22);
            this.numericUpDown_startPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_startPeriod.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_startPeriod.Name = "numericUpDown_startPeriod";
            this.numericUpDown_startPeriod.Size = new System.Drawing.Size(61, 21);
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
            this.numericUpDown_endPeriod.BackColor = System.Drawing.Color.White;
            this.numericUpDown_endPeriod.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_endPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_endPeriod.Location = new System.Drawing.Point(215, 22);
            this.numericUpDown_endPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_endPeriod.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_endPeriod.Name = "numericUpDown_endPeriod";
            this.numericUpDown_endPeriod.Size = new System.Drawing.Size(61, 21);
            this.numericUpDown_endPeriod.TabIndex = 13;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDown_endPeriod);
            this.groupBox4.Controls.Add(this.label_endPeriod);
            this.groupBox4.Controls.Add(this.button_refresh);
            this.groupBox4.Controls.Add(this.numericUpDown_startPeriod);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(431, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(464, 60);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Display Cycle";
            // 
            // splitContainer_data
            // 
            this.splitContainer_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_data.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.splitContainer_data.Location = new System.Drawing.Point(6, 157);
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
            this.splitContainer_data.Size = new System.Drawing.Size(889, 575);
            this.splitContainer_data.SplitterDistance = 414;
            this.splitContainer_data.TabIndex = 22;
            // 
            // splitContainer_intersectionData
            // 
            this.splitContainer_intersectionData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.splitContainer_intersectionData.Size = new System.Drawing.Size(889, 414);
            this.splitContainer_intersectionData.SplitterDistance = 156;
            this.splitContainer_intersectionData.TabIndex = 0;
            // 
            // dataGridView_intersectionData
            // 
            this.dataGridView_intersectionData.AllowUserToAddRows = false;
            this.dataGridView_intersectionData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_intersectionData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_intersectionData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_intersectionData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_intersectionData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView_intersectionData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_intersectionData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView_intersectionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_intersectionData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoadID,
            this.AverageArrivalRate,
            this.AverageWaitingVehicle,
            this.AverageWaittingRate,
            this.AverageWaittingTime});
            this.dataGridView_intersectionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_intersectionData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_intersectionData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_intersectionData.Name = "dataGridView_intersectionData";
            this.dataGridView_intersectionData.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_intersectionData.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView_intersectionData.RowTemplate.Height = 24;
            this.dataGridView_intersectionData.Size = new System.Drawing.Size(887, 154);
            this.dataGridView_intersectionData.TabIndex = 0;
            // 
            // RoadID
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.RoadID.DefaultCellStyle = dataGridViewCellStyle11;
            this.RoadID.FillWeight = 20F;
            this.RoadID.HeaderText = "RoadID";
            this.RoadID.Name = "RoadID";
            this.RoadID.ReadOnly = true;
            this.RoadID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AverageArrivalRate
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.AverageArrivalRate.DefaultCellStyle = dataGridViewCellStyle12;
            this.AverageArrivalRate.FillWeight = 60F;
            this.AverageArrivalRate.HeaderText = "AvgArrivalRate (veh/min)";
            this.AverageArrivalRate.Name = "AverageArrivalRate";
            this.AverageArrivalRate.ReadOnly = true;
            this.AverageArrivalRate.ToolTipText = "Arrival vehicles per minute";
            // 
            // AverageWaitingVehicle
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            this.AverageWaitingVehicle.DefaultCellStyle = dataGridViewCellStyle13;
            this.AverageWaitingVehicle.FillWeight = 50F;
            this.AverageWaitingVehicle.HeaderText = "AvgWaitingVehicle";
            this.AverageWaitingVehicle.Name = "AverageWaitingVehicle";
            this.AverageWaitingVehicle.ReadOnly = true;
            // 
            // AverageWaittingRate
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            this.AverageWaittingRate.DefaultCellStyle = dataGridViewCellStyle14;
            this.AverageWaittingRate.FillWeight = 40F;
            this.AverageWaittingRate.HeaderText = "AvgWaitingRate (%)";
            this.AverageWaittingRate.Name = "AverageWaittingRate";
            this.AverageWaittingRate.ReadOnly = true;
            // 
            // AverageWaittingTime
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.AverageWaittingTime.DefaultCellStyle = dataGridViewCellStyle15;
            this.AverageWaittingTime.FillWeight = 50F;
            this.AverageWaittingTime.HeaderText = "AvgWaitingTime (second)";
            this.AverageWaittingTime.Name = "AverageWaittingTime";
            this.AverageWaittingTime.ReadOnly = true;
            // 
            // dataGridView_optimizeationData
            // 
            this.dataGridView_optimizeationData.AllowUserToAddRows = false;
            this.dataGridView_optimizeationData.AllowUserToDeleteRows = false;
            this.dataGridView_optimizeationData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_optimizeationData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_optimizeationData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView_optimizeationData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_optimizeationData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
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
            this.dataGridView_optimizeationData.Size = new System.Drawing.Size(887, 252);
            this.dataGridView_optimizeationData.TabIndex = 0;
            // 
            // OptimizeCycle
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            this.OptimizeCycle.DefaultCellStyle = dataGridViewCellStyle18;
            this.OptimizeCycle.FillWeight = 30F;
            this.OptimizeCycle.HeaderText = "Cycle";
            this.OptimizeCycle.Name = "OptimizeCycle";
            this.OptimizeCycle.ReadOnly = true;
            this.OptimizeCycle.ToolTipText = "Perform optimization cycle";
            // 
            // OptimizeTime
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            this.OptimizeTime.DefaultCellStyle = dataGridViewCellStyle19;
            this.OptimizeTime.FillWeight = 50F;
            this.OptimizeTime.HeaderText = "Time";
            this.OptimizeTime.Name = "OptimizeTime";
            this.OptimizeTime.ReadOnly = true;
            // 
            // IAWR
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.IAWR.DefaultCellStyle = dataGridViewCellStyle20;
            this.IAWR.FillWeight = 30F;
            this.IAWR.HeaderText = "IAWR";
            this.IAWR.Name = "IAWR";
            this.IAWR.ReadOnly = true;
            this.IAWR.ToolTipText = "IntersectionAverageWaitingRate";
            // 
            // IAWRThreshold
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            this.IAWRThreshold.DefaultCellStyle = dataGridViewCellStyle21;
            this.IAWRThreshold.FillWeight = 30F;
            this.IAWRThreshold.HeaderText = "IAWRT";
            this.IAWRThreshold.Name = "IAWRThreshold";
            this.IAWRThreshold.ReadOnly = true;
            this.IAWRThreshold.ToolTipText = "Optimization Threshold";
            // 
            // originConfiguration
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
            this.originConfiguration.DefaultCellStyle = dataGridViewCellStyle22;
            this.originConfiguration.FillWeight = 120F;
            this.originConfiguration.HeaderText = "Origin";
            this.originConfiguration.Name = "originConfiguration";
            this.originConfiguration.ReadOnly = true;
            this.originConfiguration.ToolTipText = "Origin Configs";
            // 
            // optimizedConfiguration
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            this.optimizedConfiguration.DefaultCellStyle = dataGridViewCellStyle23;
            this.optimizedConfiguration.FillWeight = 120F;
            this.optimizedConfiguration.HeaderText = "Optimized";
            this.optimizedConfiguration.Name = "optimizedConfiguration";
            this.optimizedConfiguration.ReadOnly = true;
            this.optimizedConfiguration.ToolTipText = "Optimized Configs";
            // 
            // groupBox_intersectionAndRoad
            // 
            this.groupBox_intersectionAndRoad.Controls.Add(this.groupBox1);
            this.groupBox_intersectionAndRoad.Controls.Add(this.splitContainer_data);
            this.groupBox_intersectionAndRoad.Controls.Add(this.groupBox2);
            this.groupBox_intersectionAndRoad.Controls.Add(this.groupBox4);
            this.groupBox_intersectionAndRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.groupBox_intersectionAndRoad.Location = new System.Drawing.Point(12, 12);
            this.groupBox_intersectionAndRoad.Name = "groupBox_intersectionAndRoad";
            this.groupBox_intersectionAndRoad.Size = new System.Drawing.Size(901, 738);
            this.groupBox_intersectionAndRoad.TabIndex = 23;
            this.groupBox_intersectionAndRoad.TabStop = false;
            this.groupBox_intersectionAndRoad.Text = "Intersection/Road";
            // 
            // TrafficDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(925, 756);
            this.Controls.Add(this.groupBox_intersectionAndRoad);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrafficDataDisplay";
            this.Text = "TrafficDataDisplay";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_singleRoadData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endPeriod)).EndInit();
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
            this.groupBox_intersectionAndRoad.ResumeLayout(false);
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
        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer_data;
        private System.Windows.Forms.SplitContainer splitContainer_intersectionData;
        private System.Windows.Forms.DataGridView dataGridView_intersectionData;
        private System.Windows.Forms.DataGridView dataGridView_optimizeationData;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptimizeCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptimizeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IAWR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IAWRThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn originConfiguration;
        private System.Windows.Forms.DataGridViewTextBoxColumn optimizedConfiguration;
        private System.Windows.Forms.GroupBox groupBox_intersectionAndRoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn previousCycleRemainVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn enterVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassedVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaittingVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleWaittingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalWaittingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageArrivalRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaitingVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaittingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaittingTime;
    }
}