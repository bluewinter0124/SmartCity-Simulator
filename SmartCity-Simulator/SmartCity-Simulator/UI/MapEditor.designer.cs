namespace SmartTrafficSimulator
{
    partial class MapEditor
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
            this.splitContainer_MapEditor = new System.Windows.Forms.SplitContainer();
            this.button_Save = new System.Windows.Forms.Button();
            this.tabControl_MapEditor = new System.Windows.Forms.TabControl();
            this.tabPage_Road = new System.Windows.Forms.TabPage();
            this.groupBox_RoadDetailInfo = new System.Windows.Forms.GroupBox();
            this.button_DeleteConnection = new System.Windows.Forms.Button();
            this.button_CreatePath = new System.Windows.Forms.Button();
            this.button_CreateConnection = new System.Windows.Forms.Button();
            this.dataGridView_RoadConnection = new System.Windows.Forms.DataGridView();
            this.Column_Connection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_OrderOfPath = new System.Windows.Forms.DataGridView();
            this.Column_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Coordinate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_RoadConnection = new System.Windows.Forms.Label();
            this.button_DeletePath = new System.Windows.Forms.Button();
            this.textBox_PathY = new System.Windows.Forms.TextBox();
            this.label_PathY = new System.Windows.Forms.Label();
            this.label_PathX = new System.Windows.Forms.Label();
            this.textBox_PathX = new System.Windows.Forms.TextBox();
            this.dinate = new System.Windows.Forms.Label();
            this.button_Down = new System.Windows.Forms.Button();
            this.button_Up = new System.Windows.Forms.Button();
            this.label_OrderOfRoadPath = new System.Windows.Forms.Label();
            this.dataGridView_RoadBasicInfo = new System.Windows.Forms.DataGridView();
            this.Column_RoadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RoadName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_ReviseName = new System.Windows.Forms.Button();
            this.button_DeleteRoad = new System.Windows.Forms.Button();
            this.button_CreateRoad = new System.Windows.Forms.Button();
            this.tabPage_Intersection = new System.Windows.Forms.TabPage();
            this.textBox_TrafficLightSetting = new System.Windows.Forms.TextBox();
            this.label_TrafficLightSetting = new System.Windows.Forms.Label();
            this.dataGridView_IntersectionID = new System.Windows.Forms.DataGridView();
            this.Column_IntersectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_IntersectionInfo = new System.Windows.Forms.DataGridView();
            this.Column1_RoadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TrafficLightSetting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_DeleteConnectionRoad = new System.Windows.Forms.Button();
            this.label_ChooseIntersection = new System.Windows.Forms.Label();
            this.button_CreateConnectionRoad = new System.Windows.Forms.Button();
            this.button_DeleteIntersection = new System.Windows.Forms.Button();
            this.button_CreateIntersection = new System.Windows.Forms.Button();
            this.label_Position = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MapEditor)).BeginInit();
            this.splitContainer_MapEditor.Panel1.SuspendLayout();
            this.splitContainer_MapEditor.Panel2.SuspendLayout();
            this.splitContainer_MapEditor.SuspendLayout();
            this.tabControl_MapEditor.SuspendLayout();
            this.tabPage_Road.SuspendLayout();
            this.groupBox_RoadDetailInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderOfPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadBasicInfo)).BeginInit();
            this.tabPage_Intersection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer_MapEditor
            // 
            this.splitContainer_MapEditor.BackColor = System.Drawing.Color.White;
            this.splitContainer_MapEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_MapEditor.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.splitContainer_MapEditor.IsSplitterFixed = true;
            this.splitContainer_MapEditor.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_MapEditor.Name = "splitContainer_MapEditor";
            // 
            // splitContainer_MapEditor.Panel1
            // 
            this.splitContainer_MapEditor.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer_MapEditor.Panel1.Controls.Add(this.button_Save);
            this.splitContainer_MapEditor.Panel1.Controls.Add(this.tabControl_MapEditor);
            this.splitContainer_MapEditor.Panel1MinSize = 300;
            // 
            // splitContainer_MapEditor.Panel2
            // 
            this.splitContainer_MapEditor.Panel2.AutoScroll = true;
            this.splitContainer_MapEditor.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer_MapEditor.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer_MapEditor.Panel2.Controls.Add(this.label_Position);
            this.splitContainer_MapEditor.Panel2.Click += new System.EventHandler(this.splitContainer_MapEditor_Panel2_Click);
            this.splitContainer_MapEditor.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GetMousePosition);
            this.splitContainer_MapEditor.Panel2MinSize = 700;
            this.splitContainer_MapEditor.Size = new System.Drawing.Size(1619, 626);
            this.splitContainer_MapEditor.SplitterDistance = 300;
            this.splitContainer_MapEditor.SplitterWidth = 1;
            this.splitContainer_MapEditor.TabIndex = 0;
            this.splitContainer_MapEditor.TabStop = false;
            // 
            // button_Save
            // 
            this.button_Save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Save.Location = new System.Drawing.Point(0, 603);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(300, 23);
            this.button_Save.TabIndex = 2;
            this.button_Save.TabStop = false;
            this.button_Save.Text = "儲存";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // tabControl_MapEditor
            // 
            this.tabControl_MapEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl_MapEditor.Controls.Add(this.tabPage_Road);
            this.tabControl_MapEditor.Controls.Add(this.tabPage_Intersection);
            this.tabControl_MapEditor.Location = new System.Drawing.Point(3, 3);
            this.tabControl_MapEditor.Name = "tabControl_MapEditor";
            this.tabControl_MapEditor.SelectedIndex = 0;
            this.tabControl_MapEditor.Size = new System.Drawing.Size(297, 594);
            this.tabControl_MapEditor.TabIndex = 0;
            // 
            // tabPage_Road
            // 
            this.tabPage_Road.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_Road.Controls.Add(this.groupBox_RoadDetailInfo);
            this.tabPage_Road.Controls.Add(this.dataGridView_RoadBasicInfo);
            this.tabPage_Road.Controls.Add(this.button_ReviseName);
            this.tabPage_Road.Controls.Add(this.button_DeleteRoad);
            this.tabPage_Road.Controls.Add(this.button_CreateRoad);
            this.tabPage_Road.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Road.Name = "tabPage_Road";
            this.tabPage_Road.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Road.Size = new System.Drawing.Size(289, 568);
            this.tabPage_Road.TabIndex = 0;
            this.tabPage_Road.Text = "道路";
            // 
            // groupBox_RoadDetailInfo
            // 
            this.groupBox_RoadDetailInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_RoadDetailInfo.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_DeleteConnection);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_CreatePath);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_CreateConnection);
            this.groupBox_RoadDetailInfo.Controls.Add(this.dataGridView_RoadConnection);
            this.groupBox_RoadDetailInfo.Controls.Add(this.dataGridView_OrderOfPath);
            this.groupBox_RoadDetailInfo.Controls.Add(this.label_RoadConnection);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_DeletePath);
            this.groupBox_RoadDetailInfo.Controls.Add(this.textBox_PathY);
            this.groupBox_RoadDetailInfo.Controls.Add(this.label_PathY);
            this.groupBox_RoadDetailInfo.Controls.Add(this.label_PathX);
            this.groupBox_RoadDetailInfo.Controls.Add(this.textBox_PathX);
            this.groupBox_RoadDetailInfo.Controls.Add(this.dinate);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_Down);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_Up);
            this.groupBox_RoadDetailInfo.Controls.Add(this.label_OrderOfRoadPath);
            this.groupBox_RoadDetailInfo.Location = new System.Drawing.Point(7, 215);
            this.groupBox_RoadDetailInfo.Name = "groupBox_RoadDetailInfo";
            this.groupBox_RoadDetailInfo.Size = new System.Drawing.Size(276, 347);
            this.groupBox_RoadDetailInfo.TabIndex = 4;
            this.groupBox_RoadDetailInfo.TabStop = false;
            this.groupBox_RoadDetailInfo.Text = "道路詳細資訊";
            // 
            // button_DeleteConnection
            // 
            this.button_DeleteConnection.Location = new System.Drawing.Point(163, 225);
            this.button_DeleteConnection.Name = "button_DeleteConnection";
            this.button_DeleteConnection.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteConnection.TabIndex = 16;
            this.button_DeleteConnection.TabStop = false;
            this.button_DeleteConnection.Text = "刪除連接";
            this.button_DeleteConnection.UseVisualStyleBackColor = true;
            this.button_DeleteConnection.Click += new System.EventHandler(this.button_DeleteConnection_Click);
            // 
            // button_CreatePath
            // 
            this.button_CreatePath.Location = new System.Drawing.Point(8, 14);
            this.button_CreatePath.Name = "button_CreatePath";
            this.button_CreatePath.Size = new System.Drawing.Size(75, 23);
            this.button_CreatePath.TabIndex = 15;
            this.button_CreatePath.TabStop = false;
            this.button_CreatePath.Text = "新增路徑";
            this.button_CreatePath.UseVisualStyleBackColor = true;
            this.button_CreatePath.Click += new System.EventHandler(this.button_CreatePath_Click);
            // 
            // button_CreateConnection
            // 
            this.button_CreateConnection.Location = new System.Drawing.Point(65, 225);
            this.button_CreateConnection.Name = "button_CreateConnection";
            this.button_CreateConnection.Size = new System.Drawing.Size(75, 23);
            this.button_CreateConnection.TabIndex = 14;
            this.button_CreateConnection.TabStop = false;
            this.button_CreateConnection.Text = "新增連接";
            this.button_CreateConnection.UseVisualStyleBackColor = true;
            this.button_CreateConnection.Click += new System.EventHandler(this.button_CreateConnection_Click);
            // 
            // dataGridView_RoadConnection
            // 
            this.dataGridView_RoadConnection.AllowUserToAddRows = false;
            this.dataGridView_RoadConnection.AllowUserToDeleteRows = false;
            this.dataGridView_RoadConnection.AllowUserToResizeColumns = false;
            this.dataGridView_RoadConnection.AllowUserToResizeRows = false;
            this.dataGridView_RoadConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_RoadConnection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RoadConnection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Connection});
            this.dataGridView_RoadConnection.Location = new System.Drawing.Point(8, 256);
            this.dataGridView_RoadConnection.Name = "dataGridView_RoadConnection";
            this.dataGridView_RoadConnection.RowTemplate.Height = 24;
            this.dataGridView_RoadConnection.Size = new System.Drawing.Size(262, 85);
            this.dataGridView_RoadConnection.TabIndex = 13;
            this.dataGridView_RoadConnection.TabStop = false;
            // 
            // Column_Connection
            // 
            this.Column_Connection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Connection.HeaderText = "連接道路";
            this.Column_Connection.Name = "Column_Connection";
            this.Column_Connection.ReadOnly = true;
            // 
            // dataGridView_OrderOfPath
            // 
            this.dataGridView_OrderOfPath.AllowUserToAddRows = false;
            this.dataGridView_OrderOfPath.AllowUserToDeleteRows = false;
            this.dataGridView_OrderOfPath.AllowUserToResizeColumns = false;
            this.dataGridView_OrderOfPath.AllowUserToResizeRows = false;
            this.dataGridView_OrderOfPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_OrderOfPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OrderOfPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Order,
            this.Column_Coordinate});
            this.dataGridView_OrderOfPath.Location = new System.Drawing.Point(8, 71);
            this.dataGridView_OrderOfPath.Name = "dataGridView_OrderOfPath";
            this.dataGridView_OrderOfPath.ReadOnly = true;
            this.dataGridView_OrderOfPath.RowTemplate.Height = 24;
            this.dataGridView_OrderOfPath.Size = new System.Drawing.Size(262, 105);
            this.dataGridView_OrderOfPath.TabIndex = 12;
            this.dataGridView_OrderOfPath.TabStop = false;
            this.dataGridView_OrderOfPath.SelectionChanged += new System.EventHandler(this.dataGridView_OrderOfPath_SelectionChanged);
            // 
            // Column_Order
            // 
            this.Column_Order.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Order.HeaderText = "路徑順序";
            this.Column_Order.Name = "Column_Order";
            this.Column_Order.ReadOnly = true;
            this.Column_Order.Width = 78;
            // 
            // Column_Coordinate
            // 
            this.Column_Coordinate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Coordinate.HeaderText = "路徑座標";
            this.Column_Coordinate.Name = "Column_Coordinate";
            this.Column_Coordinate.ReadOnly = true;
            // 
            // label_RoadConnection
            // 
            this.label_RoadConnection.AutoSize = true;
            this.label_RoadConnection.Location = new System.Drawing.Point(6, 230);
            this.label_RoadConnection.Name = "label_RoadConnection";
            this.label_RoadConnection.Size = new System.Drawing.Size(53, 12);
            this.label_RoadConnection.TabIndex = 10;
            this.label_RoadConnection.Text = "連接道路";
            // 
            // button_DeletePath
            // 
            this.button_DeletePath.Location = new System.Drawing.Point(100, 14);
            this.button_DeletePath.Name = "button_DeletePath";
            this.button_DeletePath.Size = new System.Drawing.Size(75, 23);
            this.button_DeletePath.TabIndex = 9;
            this.button_DeletePath.TabStop = false;
            this.button_DeletePath.Text = "刪除路徑";
            this.button_DeletePath.UseVisualStyleBackColor = true;
            this.button_DeletePath.Click += new System.EventHandler(this.button_DeletePath_Click);
            // 
            // textBox_PathY
            // 
            this.textBox_PathY.Location = new System.Drawing.Point(181, 182);
            this.textBox_PathY.Name = "textBox_PathY";
            this.textBox_PathY.Size = new System.Drawing.Size(57, 22);
            this.textBox_PathY.TabIndex = 8;
            this.textBox_PathY.TabStop = false;
            // 
            // label_PathY
            // 
            this.label_PathY.AutoSize = true;
            this.label_PathY.Location = new System.Drawing.Point(162, 185);
            this.label_PathY.Name = "label_PathY";
            this.label_PathY.Size = new System.Drawing.Size(13, 12);
            this.label_PathY.TabIndex = 7;
            this.label_PathY.Text = "Y";
            // 
            // label_PathX
            // 
            this.label_PathX.AutoSize = true;
            this.label_PathX.Location = new System.Drawing.Point(65, 185);
            this.label_PathX.Name = "label_PathX";
            this.label_PathX.Size = new System.Drawing.Size(13, 12);
            this.label_PathX.TabIndex = 6;
            this.label_PathX.Text = "X";
            // 
            // textBox_PathX
            // 
            this.textBox_PathX.Location = new System.Drawing.Point(85, 182);
            this.textBox_PathX.Name = "textBox_PathX";
            this.textBox_PathX.Size = new System.Drawing.Size(57, 22);
            this.textBox_PathX.TabIndex = 5;
            this.textBox_PathX.TabStop = false;
            // 
            // dinate
            // 
            this.dinate.AutoSize = true;
            this.dinate.Location = new System.Drawing.Point(6, 185);
            this.dinate.Name = "dinate";
            this.dinate.Size = new System.Drawing.Size(53, 12);
            this.dinate.TabIndex = 4;
            this.dinate.Text = "座標調整";
            // 
            // button_Down
            // 
            this.button_Down.Location = new System.Drawing.Point(181, 43);
            this.button_Down.Name = "button_Down";
            this.button_Down.Size = new System.Drawing.Size(64, 23);
            this.button_Down.TabIndex = 3;
            this.button_Down.TabStop = false;
            this.button_Down.Text = "↓";
            this.button_Down.UseVisualStyleBackColor = true;
            this.button_Down.Click += new System.EventHandler(this.button_Down_Click);
            // 
            // button_Up
            // 
            this.button_Up.Location = new System.Drawing.Point(85, 43);
            this.button_Up.Name = "button_Up";
            this.button_Up.Size = new System.Drawing.Size(64, 23);
            this.button_Up.TabIndex = 2;
            this.button_Up.TabStop = false;
            this.button_Up.Text = "↑";
            this.button_Up.UseVisualStyleBackColor = true;
            this.button_Up.Click += new System.EventHandler(this.button_Up_Click);
            // 
            // label_OrderOfRoadPath
            // 
            this.label_OrderOfRoadPath.AutoSize = true;
            this.label_OrderOfRoadPath.Location = new System.Drawing.Point(6, 48);
            this.label_OrderOfRoadPath.Name = "label_OrderOfRoadPath";
            this.label_OrderOfRoadPath.Size = new System.Drawing.Size(53, 12);
            this.label_OrderOfRoadPath.TabIndex = 0;
            this.label_OrderOfRoadPath.Text = "道路順序";
            // 
            // dataGridView_RoadBasicInfo
            // 
            this.dataGridView_RoadBasicInfo.AllowUserToAddRows = false;
            this.dataGridView_RoadBasicInfo.AllowUserToDeleteRows = false;
            this.dataGridView_RoadBasicInfo.AllowUserToResizeColumns = false;
            this.dataGridView_RoadBasicInfo.AllowUserToResizeRows = false;
            this.dataGridView_RoadBasicInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_RoadBasicInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RoadBasicInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_RoadID,
            this.Column_RoadName});
            this.dataGridView_RoadBasicInfo.Location = new System.Drawing.Point(15, 36);
            this.dataGridView_RoadBasicInfo.Name = "dataGridView_RoadBasicInfo";
            this.dataGridView_RoadBasicInfo.RowTemplate.Height = 24;
            this.dataGridView_RoadBasicInfo.Size = new System.Drawing.Size(262, 173);
            this.dataGridView_RoadBasicInfo.TabIndex = 3;
            this.dataGridView_RoadBasicInfo.SelectionChanged += new System.EventHandler(this.dataGridView_RoadBasicInfo_SelectionChanged);
            // 
            // Column_RoadID
            // 
            this.Column_RoadID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column_RoadID.HeaderText = "道路編號";
            this.Column_RoadID.Name = "Column_RoadID";
            this.Column_RoadID.Width = 78;
            // 
            // Column_RoadName
            // 
            this.Column_RoadName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_RoadName.HeaderText = "道路名稱";
            this.Column_RoadName.Name = "Column_RoadName";
            // 
            // button_ReviseName
            // 
            this.button_ReviseName.Location = new System.Drawing.Point(177, 6);
            this.button_ReviseName.Name = "button_ReviseName";
            this.button_ReviseName.Size = new System.Drawing.Size(75, 23);
            this.button_ReviseName.TabIndex = 2;
            this.button_ReviseName.TabStop = false;
            this.button_ReviseName.Text = "修改名稱";
            this.button_ReviseName.UseVisualStyleBackColor = true;
            this.button_ReviseName.Click += new System.EventHandler(this.button_ReviseName_Click);
            // 
            // button_DeleteRoad
            // 
            this.button_DeleteRoad.Location = new System.Drawing.Point(96, 6);
            this.button_DeleteRoad.Name = "button_DeleteRoad";
            this.button_DeleteRoad.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteRoad.TabIndex = 1;
            this.button_DeleteRoad.TabStop = false;
            this.button_DeleteRoad.Text = "刪除道路";
            this.button_DeleteRoad.UseVisualStyleBackColor = true;
            this.button_DeleteRoad.Click += new System.EventHandler(this.button_DeleteRoad_Click);
            // 
            // button_CreateRoad
            // 
            this.button_CreateRoad.Location = new System.Drawing.Point(15, 6);
            this.button_CreateRoad.Name = "button_CreateRoad";
            this.button_CreateRoad.Size = new System.Drawing.Size(75, 23);
            this.button_CreateRoad.TabIndex = 0;
            this.button_CreateRoad.TabStop = false;
            this.button_CreateRoad.Text = "新增道路";
            this.button_CreateRoad.UseVisualStyleBackColor = true;
            this.button_CreateRoad.Click += new System.EventHandler(this.button_CreateRoad_Click);
            // 
            // tabPage_Intersection
            // 
            this.tabPage_Intersection.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_Intersection.Controls.Add(this.textBox_TrafficLightSetting);
            this.tabPage_Intersection.Controls.Add(this.label_TrafficLightSetting);
            this.tabPage_Intersection.Controls.Add(this.dataGridView_IntersectionID);
            this.tabPage_Intersection.Controls.Add(this.dataGridView_IntersectionInfo);
            this.tabPage_Intersection.Controls.Add(this.button_DeleteConnectionRoad);
            this.tabPage_Intersection.Controls.Add(this.label_ChooseIntersection);
            this.tabPage_Intersection.Controls.Add(this.button_CreateConnectionRoad);
            this.tabPage_Intersection.Controls.Add(this.button_DeleteIntersection);
            this.tabPage_Intersection.Controls.Add(this.button_CreateIntersection);
            this.tabPage_Intersection.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Intersection.Name = "tabPage_Intersection";
            this.tabPage_Intersection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Intersection.Size = new System.Drawing.Size(289, 568);
            this.tabPage_Intersection.TabIndex = 1;
            this.tabPage_Intersection.Text = "路口";
            // 
            // textBox_TrafficLightSetting
            // 
            this.textBox_TrafficLightSetting.Location = new System.Drawing.Point(93, 421);
            this.textBox_TrafficLightSetting.Name = "textBox_TrafficLightSetting";
            this.textBox_TrafficLightSetting.Size = new System.Drawing.Size(100, 22);
            this.textBox_TrafficLightSetting.TabIndex = 9;
            this.textBox_TrafficLightSetting.TextChanged += new System.EventHandler(this.textBox_TrafficLightSetting_TextChanged);
            // 
            // label_TrafficLightSetting
            // 
            this.label_TrafficLightSetting.AutoSize = true;
            this.label_TrafficLightSetting.Location = new System.Drawing.Point(19, 424);
            this.label_TrafficLightSetting.Name = "label_TrafficLightSetting";
            this.label_TrafficLightSetting.Size = new System.Drawing.Size(65, 12);
            this.label_TrafficLightSetting.TabIndex = 8;
            this.label_TrafficLightSetting.Text = "紅綠燈設定";
            // 
            // dataGridView_IntersectionID
            // 
            this.dataGridView_IntersectionID.AllowUserToAddRows = false;
            this.dataGridView_IntersectionID.AllowUserToDeleteRows = false;
            this.dataGridView_IntersectionID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IntersectionID.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_IntersectionID});
            this.dataGridView_IntersectionID.Location = new System.Drawing.Point(21, 44);
            this.dataGridView_IntersectionID.Name = "dataGridView_IntersectionID";
            this.dataGridView_IntersectionID.RowTemplate.Height = 24;
            this.dataGridView_IntersectionID.Size = new System.Drawing.Size(240, 150);
            this.dataGridView_IntersectionID.TabIndex = 7;
            this.dataGridView_IntersectionID.TabStop = false;
            this.dataGridView_IntersectionID.SelectionChanged += new System.EventHandler(this.dataGridView_IntersectionID_SelectionChanged);
            // 
            // Column_IntersectionID
            // 
            this.Column_IntersectionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_IntersectionID.HeaderText = "路口編號";
            this.Column_IntersectionID.Name = "Column_IntersectionID";
            // 
            // dataGridView_IntersectionInfo
            // 
            this.dataGridView_IntersectionInfo.AllowUserToAddRows = false;
            this.dataGridView_IntersectionInfo.AllowUserToDeleteRows = false;
            this.dataGridView_IntersectionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IntersectionInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1_RoadID,
            this.Column_TrafficLightSetting});
            this.dataGridView_IntersectionInfo.Location = new System.Drawing.Point(21, 252);
            this.dataGridView_IntersectionInfo.Name = "dataGridView_IntersectionInfo";
            this.dataGridView_IntersectionInfo.RowTemplate.Height = 24;
            this.dataGridView_IntersectionInfo.Size = new System.Drawing.Size(240, 150);
            this.dataGridView_IntersectionInfo.TabIndex = 6;
            // 
            // Column1_RoadID
            // 
            this.Column1_RoadID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1_RoadID.HeaderText = "道路編號";
            this.Column1_RoadID.Name = "Column1_RoadID";
            // 
            // Column_TrafficLightSetting
            // 
            this.Column_TrafficLightSetting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_TrafficLightSetting.HeaderText = "紅綠燈設定";
            this.Column_TrafficLightSetting.Name = "Column_TrafficLightSetting";
            // 
            // button_DeleteConnectionRoad
            // 
            this.button_DeleteConnectionRoad.Location = new System.Drawing.Point(155, 214);
            this.button_DeleteConnectionRoad.Name = "button_DeleteConnectionRoad";
            this.button_DeleteConnectionRoad.Size = new System.Drawing.Size(106, 23);
            this.button_DeleteConnectionRoad.TabIndex = 5;
            this.button_DeleteConnectionRoad.Text = "刪除連接道路";
            this.button_DeleteConnectionRoad.UseVisualStyleBackColor = true;
            this.button_DeleteConnectionRoad.Click += new System.EventHandler(this.button_DeleteConnectionRoad_Click);
            // 
            // label_ChooseIntersection
            // 
            this.label_ChooseIntersection.AutoSize = true;
            this.label_ChooseIntersection.Location = new System.Drawing.Point(19, 16);
            this.label_ChooseIntersection.Name = "label_ChooseIntersection";
            this.label_ChooseIntersection.Size = new System.Drawing.Size(53, 12);
            this.label_ChooseIntersection.TabIndex = 4;
            this.label_ChooseIntersection.Text = "路口選擇";
            // 
            // button_CreateConnectionRoad
            // 
            this.button_CreateConnectionRoad.Location = new System.Drawing.Point(21, 214);
            this.button_CreateConnectionRoad.Name = "button_CreateConnectionRoad";
            this.button_CreateConnectionRoad.Size = new System.Drawing.Size(106, 23);
            this.button_CreateConnectionRoad.TabIndex = 2;
            this.button_CreateConnectionRoad.Text = "新增連接道路";
            this.button_CreateConnectionRoad.UseVisualStyleBackColor = true;
            this.button_CreateConnectionRoad.Click += new System.EventHandler(this.button_CreateConnectionRoad_Click);
            // 
            // button_DeleteIntersection
            // 
            this.button_DeleteIntersection.Location = new System.Drawing.Point(186, 11);
            this.button_DeleteIntersection.Name = "button_DeleteIntersection";
            this.button_DeleteIntersection.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteIntersection.TabIndex = 1;
            this.button_DeleteIntersection.Text = "刪除路口";
            this.button_DeleteIntersection.UseVisualStyleBackColor = true;
            this.button_DeleteIntersection.Click += new System.EventHandler(this.button_DeleteIntersection_Click);
            // 
            // button_CreateIntersection
            // 
            this.button_CreateIntersection.Location = new System.Drawing.Point(93, 11);
            this.button_CreateIntersection.Name = "button_CreateIntersection";
            this.button_CreateIntersection.Size = new System.Drawing.Size(75, 23);
            this.button_CreateIntersection.TabIndex = 0;
            this.button_CreateIntersection.Text = "新增路口";
            this.button_CreateIntersection.UseVisualStyleBackColor = true;
            this.button_CreateIntersection.Click += new System.EventHandler(this.button_CreateIntersection_Click);
            // 
            // label_Position
            // 
            this.label_Position.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Position.AutoSize = true;
            this.label_Position.BackColor = System.Drawing.Color.White;
            this.label_Position.Font = new System.Drawing.Font("新細明體", 18F);
            this.label_Position.Location = new System.Drawing.Point(0, 602);
            this.label_Position.Name = "label_Position";
            this.label_Position.Size = new System.Drawing.Size(83, 24);
            this.label_Position.TabIndex = 0;
            this.label_Position.Text = "Position";
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1619, 626);
            this.Controls.Add(this.splitContainer_MapEditor);
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.splitContainer_MapEditor.Panel1.ResumeLayout(false);
            this.splitContainer_MapEditor.Panel2.ResumeLayout(false);
            this.splitContainer_MapEditor.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MapEditor)).EndInit();
            this.splitContainer_MapEditor.ResumeLayout(false);
            this.tabControl_MapEditor.ResumeLayout(false);
            this.tabPage_Road.ResumeLayout(false);
            this.groupBox_RoadDetailInfo.ResumeLayout(false);
            this.groupBox_RoadDetailInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderOfPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadBasicInfo)).EndInit();
            this.tabPage_Intersection.ResumeLayout(false);
            this.tabPage_Intersection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Position;
        public System.Windows.Forms.SplitContainer splitContainer_MapEditor;
        private System.Windows.Forms.TabControl tabControl_MapEditor;
        private System.Windows.Forms.TabPage tabPage_Road;
        private System.Windows.Forms.TabPage tabPage_Intersection;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.DataGridView dataGridView_RoadBasicInfo;
        private System.Windows.Forms.Button button_ReviseName;
        private System.Windows.Forms.Button button_DeleteRoad;
        private System.Windows.Forms.Button button_CreateRoad;
        private System.Windows.Forms.GroupBox groupBox_RoadDetailInfo;
        private System.Windows.Forms.Button button_Down;
        private System.Windows.Forms.Button button_Up;
        private System.Windows.Forms.Label label_OrderOfRoadPath;
        private System.Windows.Forms.Label dinate;
        private System.Windows.Forms.TextBox textBox_PathY;
        private System.Windows.Forms.Label label_PathY;
        private System.Windows.Forms.Label label_PathX;
        private System.Windows.Forms.TextBox textBox_PathX;
        private System.Windows.Forms.Button button_DeletePath;
        private System.Windows.Forms.Label label_RoadConnection;
        private System.Windows.Forms.DataGridView dataGridView_RoadConnection;
        private System.Windows.Forms.DataGridView dataGridView_OrderOfPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Coordinate;
        private System.Windows.Forms.Button button_CreateConnection;
        private System.Windows.Forms.Button button_CreatePath;
        private System.Windows.Forms.Button button_DeleteConnection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Connection;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RoadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RoadName;
        private System.Windows.Forms.Button button_CreateConnectionRoad;
        private System.Windows.Forms.Button button_DeleteIntersection;
        private System.Windows.Forms.Button button_CreateIntersection;
        private System.Windows.Forms.Label label_ChooseIntersection;
        private System.Windows.Forms.DataGridView dataGridView_IntersectionInfo;
        private System.Windows.Forms.Button button_DeleteConnectionRoad;
        private System.Windows.Forms.DataGridView dataGridView_IntersectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IntersectionID;
        private System.Windows.Forms.TextBox textBox_TrafficLightSetting;
        private System.Windows.Forms.Label label_TrafficLightSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_RoadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TrafficLightSetting;
    }
}