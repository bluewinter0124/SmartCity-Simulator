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
            this.tabControl_MapEditor = new System.Windows.Forms.TabControl();
            this.tabPage_Road = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_DeleteConnection = new System.Windows.Forms.Button();
            this.button_CreateConnection = new System.Windows.Forms.Button();
            this.dataGridView_RoadConnection = new System.Windows.Forms.DataGridView();
            this.Column_Connection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_RoadDetailInfo = new System.Windows.Forms.GroupBox();
            this.label_Position = new System.Windows.Forms.Label();
            this.button_addNode = new System.Windows.Forms.Button();
            this.dataGridView_OrderOfPath = new System.Windows.Forms.DataGridView();
            this.button_deleteNode = new System.Windows.Forms.Button();
            this.textBox_PathY = new System.Windows.Forms.TextBox();
            this.label_PathY = new System.Windows.Forms.Label();
            this.label_PathX = new System.Windows.Forms.Label();
            this.textBox_PathX = new System.Windows.Forms.TextBox();
            this.dinate = new System.Windows.Forms.Label();
            this.button_orderDown = new System.Windows.Forms.Button();
            this.button_orderUp = new System.Windows.Forms.Button();
            this.dataGridView_RoadBasicInfo = new System.Windows.Forms.DataGridView();
            this.button_ReviseName = new System.Windows.Forms.Button();
            this.button_DeleteRoad = new System.Windows.Forms.Button();
            this.button_CreateRoad = new System.Windows.Forms.Button();
            this.tabPage_Intersection = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_DeleteConnectionRoad = new System.Windows.Forms.Button();
            this.textBox_TrafficLightSetting = new System.Windows.Forms.TextBox();
            this.label_TrafficLightSetting = new System.Windows.Forms.Label();
            this.button_CreateConnectionRoad = new System.Windows.Forms.Button();
            this.dataGridView_IntersectionInfo = new System.Windows.Forms.DataGridView();
            this.Column1_RoadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_TrafficLightSetting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_IntersectionID = new System.Windows.Forms.DataGridView();
            this.Column_IntersectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_DeleteIntersection = new System.Windows.Forms.Button();
            this.button_CreateIntersection = new System.Windows.Forms.Button();
            this.tabPage_other = new System.Windows.Forms.TabPage();
            this.button_Save = new System.Windows.Forms.Button();
            this.Column_RoadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_RoadName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Coordinate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MapEditor)).BeginInit();
            this.splitContainer_MapEditor.Panel1.SuspendLayout();
            this.splitContainer_MapEditor.SuspendLayout();
            this.tabControl_MapEditor.SuspendLayout();
            this.tabPage_Road.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadConnection)).BeginInit();
            this.groupBox_RoadDetailInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderOfPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadBasicInfo)).BeginInit();
            this.tabPage_Intersection.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionID)).BeginInit();
            this.tabPage_other.SuspendLayout();
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
            this.splitContainer_MapEditor.Panel1.Controls.Add(this.tabControl_MapEditor);
            this.splitContainer_MapEditor.Panel1MinSize = 300;
            // 
            // splitContainer_MapEditor.Panel2
            // 
            this.splitContainer_MapEditor.Panel2.AutoScroll = true;
            this.splitContainer_MapEditor.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer_MapEditor.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer_MapEditor.Panel2.Click += new System.EventHandler(this.splitContainer_MapEditor_Panel2_Click);
            this.splitContainer_MapEditor.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GetMousePosition);
            this.splitContainer_MapEditor.Panel2MinSize = 700;
            this.splitContainer_MapEditor.Size = new System.Drawing.Size(1619, 696);
            this.splitContainer_MapEditor.SplitterDistance = 300;
            this.splitContainer_MapEditor.SplitterWidth = 1;
            this.splitContainer_MapEditor.TabIndex = 0;
            this.splitContainer_MapEditor.TabStop = false;
            // 
            // tabControl_MapEditor
            // 
            this.tabControl_MapEditor.Controls.Add(this.tabPage_Road);
            this.tabControl_MapEditor.Controls.Add(this.tabPage_Intersection);
            this.tabControl_MapEditor.Controls.Add(this.tabPage_other);
            this.tabControl_MapEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_MapEditor.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl_MapEditor.Location = new System.Drawing.Point(0, 0);
            this.tabControl_MapEditor.Name = "tabControl_MapEditor";
            this.tabControl_MapEditor.SelectedIndex = 0;
            this.tabControl_MapEditor.Size = new System.Drawing.Size(300, 696);
            this.tabControl_MapEditor.TabIndex = 0;
            // 
            // tabPage_Road
            // 
            this.tabPage_Road.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_Road.Controls.Add(this.groupBox1);
            this.tabPage_Road.Controls.Add(this.groupBox_RoadDetailInfo);
            this.tabPage_Road.Controls.Add(this.dataGridView_RoadBasicInfo);
            this.tabPage_Road.Controls.Add(this.button_ReviseName);
            this.tabPage_Road.Controls.Add(this.button_DeleteRoad);
            this.tabPage_Road.Controls.Add(this.button_CreateRoad);
            this.tabPage_Road.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Road.Name = "tabPage_Road";
            this.tabPage_Road.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Road.Size = new System.Drawing.Size(292, 666);
            this.tabPage_Road.TabIndex = 0;
            this.tabPage_Road.Text = "Road";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.button_DeleteConnection);
            this.groupBox1.Controls.Add(this.button_CreateConnection);
            this.groupBox1.Controls.Add(this.dataGridView_RoadConnection);
            this.groupBox1.Location = new System.Drawing.Point(6, 471);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Road Connection";
            // 
            // button_DeleteConnection
            // 
            this.button_DeleteConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_DeleteConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_DeleteConnection.FlatAppearance.BorderSize = 0;
            this.button_DeleteConnection.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_DeleteConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_DeleteConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_DeleteConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DeleteConnection.Location = new System.Drawing.Point(200, 24);
            this.button_DeleteConnection.Name = "button_DeleteConnection";
            this.button_DeleteConnection.Size = new System.Drawing.Size(70, 25);
            this.button_DeleteConnection.TabIndex = 16;
            this.button_DeleteConnection.TabStop = false;
            this.button_DeleteConnection.Text = "Delete";
            this.button_DeleteConnection.UseVisualStyleBackColor = false;
            this.button_DeleteConnection.Click += new System.EventHandler(this.button_DeleteConnection_Click);
            // 
            // button_CreateConnection
            // 
            this.button_CreateConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_CreateConnection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_CreateConnection.FlatAppearance.BorderSize = 0;
            this.button_CreateConnection.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_CreateConnection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_CreateConnection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_CreateConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CreateConnection.Location = new System.Drawing.Point(9, 24);
            this.button_CreateConnection.Name = "button_CreateConnection";
            this.button_CreateConnection.Size = new System.Drawing.Size(70, 25);
            this.button_CreateConnection.TabIndex = 14;
            this.button_CreateConnection.TabStop = false;
            this.button_CreateConnection.Text = "New";
            this.button_CreateConnection.UseVisualStyleBackColor = false;
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
            this.dataGridView_RoadConnection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_RoadConnection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RoadConnection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Connection});
            this.dataGridView_RoadConnection.Location = new System.Drawing.Point(8, 55);
            this.dataGridView_RoadConnection.Name = "dataGridView_RoadConnection";
            this.dataGridView_RoadConnection.RowTemplate.Height = 24;
            this.dataGridView_RoadConnection.Size = new System.Drawing.Size(262, 116);
            this.dataGridView_RoadConnection.TabIndex = 13;
            this.dataGridView_RoadConnection.TabStop = false;
            // 
            // Column_Connection
            // 
            this.Column_Connection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Connection.HeaderText = "Connected Road";
            this.Column_Connection.Name = "Column_Connection";
            this.Column_Connection.ReadOnly = true;
            // 
            // groupBox_RoadDetailInfo
            // 
            this.groupBox_RoadDetailInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_RoadDetailInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_RoadDetailInfo.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_RoadDetailInfo.Controls.Add(this.label_Position);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_addNode);
            this.groupBox_RoadDetailInfo.Controls.Add(this.dataGridView_OrderOfPath);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_deleteNode);
            this.groupBox_RoadDetailInfo.Controls.Add(this.textBox_PathY);
            this.groupBox_RoadDetailInfo.Controls.Add(this.label_PathY);
            this.groupBox_RoadDetailInfo.Controls.Add(this.label_PathX);
            this.groupBox_RoadDetailInfo.Controls.Add(this.textBox_PathX);
            this.groupBox_RoadDetailInfo.Controls.Add(this.dinate);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_orderDown);
            this.groupBox_RoadDetailInfo.Controls.Add(this.button_orderUp);
            this.groupBox_RoadDetailInfo.Location = new System.Drawing.Point(6, 215);
            this.groupBox_RoadDetailInfo.Name = "groupBox_RoadDetailInfo";
            this.groupBox_RoadDetailInfo.Size = new System.Drawing.Size(280, 250);
            this.groupBox_RoadDetailInfo.TabIndex = 4;
            this.groupBox_RoadDetailInfo.TabStop = false;
            this.groupBox_RoadDetailInfo.Text = "Road Nodes";
            // 
            // label_Position
            // 
            this.label_Position.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Position.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_Position.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Position.Location = new System.Drawing.Point(7, 53);
            this.label_Position.Name = "label_Position";
            this.label_Position.Size = new System.Drawing.Size(273, 20);
            this.label_Position.TabIndex = 0;
            this.label_Position.Text = "Position : ";
            // 
            // button_addNode
            // 
            this.button_addNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_addNode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_addNode.FlatAppearance.BorderSize = 0;
            this.button_addNode.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addNode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_addNode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addNode.Location = new System.Drawing.Point(11, 20);
            this.button_addNode.Name = "button_addNode";
            this.button_addNode.Size = new System.Drawing.Size(70, 25);
            this.button_addNode.TabIndex = 15;
            this.button_addNode.TabStop = false;
            this.button_addNode.Text = "New ";
            this.button_addNode.UseVisualStyleBackColor = false;
            this.button_addNode.Click += new System.EventHandler(this.button_CreatePath_Click);
            // 
            // dataGridView_OrderOfPath
            // 
            this.dataGridView_OrderOfPath.AllowUserToAddRows = false;
            this.dataGridView_OrderOfPath.AllowUserToDeleteRows = false;
            this.dataGridView_OrderOfPath.AllowUserToResizeColumns = false;
            this.dataGridView_OrderOfPath.AllowUserToResizeRows = false;
            this.dataGridView_OrderOfPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_OrderOfPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_OrderOfPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_OrderOfPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Order,
            this.Column_Coordinate});
            this.dataGridView_OrderOfPath.Location = new System.Drawing.Point(8, 81);
            this.dataGridView_OrderOfPath.Name = "dataGridView_OrderOfPath";
            this.dataGridView_OrderOfPath.ReadOnly = true;
            this.dataGridView_OrderOfPath.RowTemplate.Height = 24;
            this.dataGridView_OrderOfPath.Size = new System.Drawing.Size(266, 122);
            this.dataGridView_OrderOfPath.TabIndex = 12;
            this.dataGridView_OrderOfPath.TabStop = false;
            this.dataGridView_OrderOfPath.SelectionChanged += new System.EventHandler(this.dataGridView_OrderOfPath_SelectionChanged);
            // 
            // button_deleteNode
            // 
            this.button_deleteNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_deleteNode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_deleteNode.FlatAppearance.BorderSize = 0;
            this.button_deleteNode.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_deleteNode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_deleteNode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_deleteNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_deleteNode.Location = new System.Drawing.Point(200, 20);
            this.button_deleteNode.Name = "button_deleteNode";
            this.button_deleteNode.Size = new System.Drawing.Size(70, 25);
            this.button_deleteNode.TabIndex = 9;
            this.button_deleteNode.TabStop = false;
            this.button_deleteNode.Text = "Delete";
            this.button_deleteNode.UseVisualStyleBackColor = false;
            this.button_deleteNode.Click += new System.EventHandler(this.button_DeletePath_Click);
            // 
            // textBox_PathY
            // 
            this.textBox_PathY.Location = new System.Drawing.Point(213, 209);
            this.textBox_PathY.Name = "textBox_PathY";
            this.textBox_PathY.Size = new System.Drawing.Size(57, 25);
            this.textBox_PathY.TabIndex = 8;
            this.textBox_PathY.TabStop = false;
            // 
            // label_PathY
            // 
            this.label_PathY.AutoSize = true;
            this.label_PathY.Location = new System.Drawing.Point(191, 212);
            this.label_PathY.Name = "label_PathY";
            this.label_PathY.Size = new System.Drawing.Size(16, 17);
            this.label_PathY.TabIndex = 7;
            this.label_PathY.Text = "Y";
            // 
            // label_PathX
            // 
            this.label_PathX.AutoSize = true;
            this.label_PathX.Location = new System.Drawing.Point(99, 212);
            this.label_PathX.Name = "label_PathX";
            this.label_PathX.Size = new System.Drawing.Size(16, 17);
            this.label_PathX.TabIndex = 6;
            this.label_PathX.Text = "X";
            // 
            // textBox_PathX
            // 
            this.textBox_PathX.Location = new System.Drawing.Point(121, 209);
            this.textBox_PathX.Name = "textBox_PathX";
            this.textBox_PathX.Size = new System.Drawing.Size(57, 25);
            this.textBox_PathX.TabIndex = 5;
            this.textBox_PathX.TabStop = false;
            // 
            // dinate
            // 
            this.dinate.AutoSize = true;
            this.dinate.Location = new System.Drawing.Point(8, 212);
            this.dinate.Name = "dinate";
            this.dinate.Size = new System.Drawing.Size(85, 17);
            this.dinate.TabIndex = 4;
            this.dinate.Text = "Coordinate : ";
            // 
            // button_orderDown
            // 
            this.button_orderDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_orderDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_orderDown.FlatAppearance.BorderSize = 0;
            this.button_orderDown.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_orderDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_orderDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_orderDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_orderDown.Location = new System.Drawing.Point(145, 20);
            this.button_orderDown.Name = "button_orderDown";
            this.button_orderDown.Size = new System.Drawing.Size(40, 25);
            this.button_orderDown.TabIndex = 3;
            this.button_orderDown.TabStop = false;
            this.button_orderDown.Text = "↓";
            this.button_orderDown.UseVisualStyleBackColor = false;
            this.button_orderDown.Click += new System.EventHandler(this.button_Down_Click);
            // 
            // button_orderUp
            // 
            this.button_orderUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_orderUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_orderUp.FlatAppearance.BorderSize = 0;
            this.button_orderUp.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_orderUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_orderUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_orderUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_orderUp.Location = new System.Drawing.Point(93, 20);
            this.button_orderUp.Name = "button_orderUp";
            this.button_orderUp.Size = new System.Drawing.Size(40, 25);
            this.button_orderUp.TabIndex = 2;
            this.button_orderUp.TabStop = false;
            this.button_orderUp.Text = "↑";
            this.button_orderUp.UseVisualStyleBackColor = false;
            this.button_orderUp.Click += new System.EventHandler(this.button_Up_Click);
            // 
            // dataGridView_RoadBasicInfo
            // 
            this.dataGridView_RoadBasicInfo.AllowUserToAddRows = false;
            this.dataGridView_RoadBasicInfo.AllowUserToDeleteRows = false;
            this.dataGridView_RoadBasicInfo.AllowUserToResizeColumns = false;
            this.dataGridView_RoadBasicInfo.AllowUserToResizeRows = false;
            this.dataGridView_RoadBasicInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_RoadBasicInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_RoadBasicInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RoadBasicInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_RoadID,
            this.Column_RoadName});
            this.dataGridView_RoadBasicInfo.Location = new System.Drawing.Point(15, 36);
            this.dataGridView_RoadBasicInfo.Name = "dataGridView_RoadBasicInfo";
            this.dataGridView_RoadBasicInfo.RowTemplate.Height = 24;
            this.dataGridView_RoadBasicInfo.Size = new System.Drawing.Size(265, 173);
            this.dataGridView_RoadBasicInfo.TabIndex = 3;
            this.dataGridView_RoadBasicInfo.SelectionChanged += new System.EventHandler(this.dataGridView_RoadBasicInfo_SelectionChanged);
            // 
            // button_ReviseName
            // 
            this.button_ReviseName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_ReviseName.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_ReviseName.FlatAppearance.BorderSize = 0;
            this.button_ReviseName.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_ReviseName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_ReviseName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_ReviseName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ReviseName.Location = new System.Drawing.Point(207, 6);
            this.button_ReviseName.Name = "button_ReviseName";
            this.button_ReviseName.Size = new System.Drawing.Size(70, 25);
            this.button_ReviseName.TabIndex = 2;
            this.button_ReviseName.TabStop = false;
            this.button_ReviseName.Text = "Rename";
            this.button_ReviseName.UseVisualStyleBackColor = false;
            this.button_ReviseName.Click += new System.EventHandler(this.button_ReviseName_Click);
            // 
            // button_DeleteRoad
            // 
            this.button_DeleteRoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_DeleteRoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_DeleteRoad.FlatAppearance.BorderSize = 0;
            this.button_DeleteRoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_DeleteRoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_DeleteRoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_DeleteRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DeleteRoad.Location = new System.Drawing.Point(115, 6);
            this.button_DeleteRoad.Name = "button_DeleteRoad";
            this.button_DeleteRoad.Size = new System.Drawing.Size(70, 25);
            this.button_DeleteRoad.TabIndex = 1;
            this.button_DeleteRoad.TabStop = false;
            this.button_DeleteRoad.Text = "Delete";
            this.button_DeleteRoad.UseVisualStyleBackColor = false;
            this.button_DeleteRoad.Click += new System.EventHandler(this.button_DeleteRoad_Click);
            // 
            // button_CreateRoad
            // 
            this.button_CreateRoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_CreateRoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_CreateRoad.FlatAppearance.BorderSize = 0;
            this.button_CreateRoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_CreateRoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_CreateRoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_CreateRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CreateRoad.Location = new System.Drawing.Point(16, 6);
            this.button_CreateRoad.Name = "button_CreateRoad";
            this.button_CreateRoad.Size = new System.Drawing.Size(70, 25);
            this.button_CreateRoad.TabIndex = 0;
            this.button_CreateRoad.TabStop = false;
            this.button_CreateRoad.Text = "New";
            this.button_CreateRoad.UseVisualStyleBackColor = false;
            this.button_CreateRoad.Click += new System.EventHandler(this.button_CreateRoad_Click);
            // 
            // tabPage_Intersection
            // 
            this.tabPage_Intersection.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_Intersection.Controls.Add(this.groupBox2);
            this.tabPage_Intersection.Controls.Add(this.dataGridView_IntersectionID);
            this.tabPage_Intersection.Controls.Add(this.button_DeleteIntersection);
            this.tabPage_Intersection.Controls.Add(this.button_CreateIntersection);
            this.tabPage_Intersection.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Intersection.Name = "tabPage_Intersection";
            this.tabPage_Intersection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Intersection.Size = new System.Drawing.Size(292, 666);
            this.tabPage_Intersection.TabIndex = 1;
            this.tabPage_Intersection.Text = "Intersection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_DeleteConnectionRoad);
            this.groupBox2.Controls.Add(this.textBox_TrafficLightSetting);
            this.groupBox2.Controls.Add(this.label_TrafficLightSetting);
            this.groupBox2.Controls.Add(this.button_CreateConnectionRoad);
            this.groupBox2.Controls.Add(this.dataGridView_IntersectionInfo);
            this.groupBox2.Location = new System.Drawing.Point(6, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 281);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Composed Road";
            // 
            // button_DeleteConnectionRoad
            // 
            this.button_DeleteConnectionRoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_DeleteConnectionRoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_DeleteConnectionRoad.FlatAppearance.BorderSize = 0;
            this.button_DeleteConnectionRoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_DeleteConnectionRoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_DeleteConnectionRoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_DeleteConnectionRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DeleteConnectionRoad.Location = new System.Drawing.Point(191, 24);
            this.button_DeleteConnectionRoad.Name = "button_DeleteConnectionRoad";
            this.button_DeleteConnectionRoad.Size = new System.Drawing.Size(80, 25);
            this.button_DeleteConnectionRoad.TabIndex = 5;
            this.button_DeleteConnectionRoad.Text = "Delete";
            this.button_DeleteConnectionRoad.UseVisualStyleBackColor = false;
            this.button_DeleteConnectionRoad.Click += new System.EventHandler(this.button_DeleteConnectionRoad_Click);
            // 
            // textBox_TrafficLightSetting
            // 
            this.textBox_TrafficLightSetting.Location = new System.Drawing.Point(84, 228);
            this.textBox_TrafficLightSetting.Name = "textBox_TrafficLightSetting";
            this.textBox_TrafficLightSetting.Size = new System.Drawing.Size(100, 25);
            this.textBox_TrafficLightSetting.TabIndex = 9;
            this.textBox_TrafficLightSetting.TextChanged += new System.EventHandler(this.textBox_TrafficLightSetting_TextChanged);
            // 
            // label_TrafficLightSetting
            // 
            this.label_TrafficLightSetting.AutoSize = true;
            this.label_TrafficLightSetting.Location = new System.Drawing.Point(10, 231);
            this.label_TrafficLightSetting.Name = "label_TrafficLightSetting";
            this.label_TrafficLightSetting.Size = new System.Drawing.Size(57, 17);
            this.label_TrafficLightSetting.TabIndex = 8;
            this.label_TrafficLightSetting.Text = "Config : ";
            // 
            // button_CreateConnectionRoad
            // 
            this.button_CreateConnectionRoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_CreateConnectionRoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_CreateConnectionRoad.FlatAppearance.BorderSize = 0;
            this.button_CreateConnectionRoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_CreateConnectionRoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_CreateConnectionRoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_CreateConnectionRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CreateConnectionRoad.Location = new System.Drawing.Point(6, 24);
            this.button_CreateConnectionRoad.Name = "button_CreateConnectionRoad";
            this.button_CreateConnectionRoad.Size = new System.Drawing.Size(80, 25);
            this.button_CreateConnectionRoad.TabIndex = 2;
            this.button_CreateConnectionRoad.Text = "Add";
            this.button_CreateConnectionRoad.UseVisualStyleBackColor = false;
            this.button_CreateConnectionRoad.Click += new System.EventHandler(this.button_CreateConnectionRoad_Click);
            // 
            // dataGridView_IntersectionInfo
            // 
            this.dataGridView_IntersectionInfo.AllowUserToAddRows = false;
            this.dataGridView_IntersectionInfo.AllowUserToDeleteRows = false;
            this.dataGridView_IntersectionInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_IntersectionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IntersectionInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1_RoadID,
            this.Column_TrafficLightSetting});
            this.dataGridView_IntersectionInfo.Location = new System.Drawing.Point(6, 55);
            this.dataGridView_IntersectionInfo.Name = "dataGridView_IntersectionInfo";
            this.dataGridView_IntersectionInfo.RowTemplate.Height = 24;
            this.dataGridView_IntersectionInfo.Size = new System.Drawing.Size(265, 150);
            this.dataGridView_IntersectionInfo.TabIndex = 6;
            // 
            // Column1_RoadID
            // 
            this.Column1_RoadID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1_RoadID.HeaderText = "Road ID";
            this.Column1_RoadID.Name = "Column1_RoadID";
            // 
            // Column_TrafficLightSetting
            // 
            this.Column_TrafficLightSetting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_TrafficLightSetting.HeaderText = "Config No.";
            this.Column_TrafficLightSetting.Name = "Column_TrafficLightSetting";
            // 
            // dataGridView_IntersectionID
            // 
            this.dataGridView_IntersectionID.AllowUserToAddRows = false;
            this.dataGridView_IntersectionID.AllowUserToDeleteRows = false;
            this.dataGridView_IntersectionID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_IntersectionID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IntersectionID.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_IntersectionID});
            this.dataGridView_IntersectionID.Location = new System.Drawing.Point(6, 44);
            this.dataGridView_IntersectionID.Name = "dataGridView_IntersectionID";
            this.dataGridView_IntersectionID.RowTemplate.Height = 24;
            this.dataGridView_IntersectionID.Size = new System.Drawing.Size(277, 150);
            this.dataGridView_IntersectionID.TabIndex = 7;
            this.dataGridView_IntersectionID.TabStop = false;
            this.dataGridView_IntersectionID.SelectionChanged += new System.EventHandler(this.dataGridView_IntersectionID_SelectionChanged);
            // 
            // Column_IntersectionID
            // 
            this.Column_IntersectionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_IntersectionID.HeaderText = "Intersection ID";
            this.Column_IntersectionID.Name = "Column_IntersectionID";
            // 
            // button_DeleteIntersection
            // 
            this.button_DeleteIntersection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_DeleteIntersection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_DeleteIntersection.FlatAppearance.BorderSize = 0;
            this.button_DeleteIntersection.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_DeleteIntersection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_DeleteIntersection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_DeleteIntersection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DeleteIntersection.Location = new System.Drawing.Point(203, 13);
            this.button_DeleteIntersection.Name = "button_DeleteIntersection";
            this.button_DeleteIntersection.Size = new System.Drawing.Size(80, 25);
            this.button_DeleteIntersection.TabIndex = 1;
            this.button_DeleteIntersection.Text = "Delete";
            this.button_DeleteIntersection.UseVisualStyleBackColor = false;
            this.button_DeleteIntersection.Click += new System.EventHandler(this.button_DeleteIntersection_Click);
            // 
            // button_CreateIntersection
            // 
            this.button_CreateIntersection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_CreateIntersection.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_CreateIntersection.FlatAppearance.BorderSize = 0;
            this.button_CreateIntersection.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_CreateIntersection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_CreateIntersection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_CreateIntersection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CreateIntersection.Location = new System.Drawing.Point(6, 13);
            this.button_CreateIntersection.Name = "button_CreateIntersection";
            this.button_CreateIntersection.Size = new System.Drawing.Size(80, 25);
            this.button_CreateIntersection.TabIndex = 0;
            this.button_CreateIntersection.Text = "New";
            this.button_CreateIntersection.UseVisualStyleBackColor = false;
            this.button_CreateIntersection.Click += new System.EventHandler(this.button_CreateIntersection_Click);
            // 
            // tabPage_other
            // 
            this.tabPage_other.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_other.Controls.Add(this.button_Save);
            this.tabPage_other.Location = new System.Drawing.Point(4, 26);
            this.tabPage_other.Name = "tabPage_other";
            this.tabPage_other.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_other.Size = new System.Drawing.Size(292, 666);
            this.tabPage_other.TabIndex = 2;
            this.tabPage_other.Text = "Other";
            // 
            // button_Save
            // 
            this.button_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_Save.FlatAppearance.BorderSize = 0;
            this.button_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_Save.Location = new System.Drawing.Point(6, 6);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(277, 40);
            this.button_Save.TabIndex = 2;
            this.button_Save.TabStop = false;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // Column_RoadID
            // 
            this.Column_RoadID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column_RoadID.HeaderText = "Road ID";
            this.Column_RoadID.Name = "Column_RoadID";
            this.Column_RoadID.ReadOnly = true;
            this.Column_RoadID.Width = 81;
            // 
            // Column_RoadName
            // 
            this.Column_RoadName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_RoadName.HeaderText = "Road Name";
            this.Column_RoadName.Name = "Column_RoadName";
            // 
            // Column_Order
            // 
            this.Column_Order.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column_Order.HeaderText = "Order";
            this.Column_Order.Name = "Column_Order";
            this.Column_Order.ReadOnly = true;
            this.Column_Order.Width = 69;
            // 
            // Column_Coordinate
            // 
            this.Column_Coordinate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Coordinate.HeaderText = "Coordinate";
            this.Column_Coordinate.Name = "Column_Coordinate";
            this.Column_Coordinate.ReadOnly = true;
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1619, 696);
            this.Controls.Add(this.splitContainer_MapEditor);
            this.Name = "MapEditor";
            this.Text = "MapEditor";
            this.splitContainer_MapEditor.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MapEditor)).EndInit();
            this.splitContainer_MapEditor.ResumeLayout(false);
            this.tabControl_MapEditor.ResumeLayout(false);
            this.tabPage_Road.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadConnection)).EndInit();
            this.groupBox_RoadDetailInfo.ResumeLayout(false);
            this.groupBox_RoadDetailInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OrderOfPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadBasicInfo)).EndInit();
            this.tabPage_Intersection.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IntersectionID)).EndInit();
            this.tabPage_other.ResumeLayout(false);
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
        private System.Windows.Forms.Button button_orderDown;
        private System.Windows.Forms.Button button_orderUp;
        private System.Windows.Forms.Label dinate;
        private System.Windows.Forms.TextBox textBox_PathY;
        private System.Windows.Forms.Label label_PathY;
        private System.Windows.Forms.Label label_PathX;
        private System.Windows.Forms.TextBox textBox_PathX;
        private System.Windows.Forms.Button button_deleteNode;
        private System.Windows.Forms.DataGridView dataGridView_RoadConnection;
        private System.Windows.Forms.DataGridView dataGridView_OrderOfPath;
        private System.Windows.Forms.Button button_CreateConnection;
        private System.Windows.Forms.Button button_addNode;
        private System.Windows.Forms.Button button_DeleteConnection;
        private System.Windows.Forms.Button button_CreateConnectionRoad;
        private System.Windows.Forms.Button button_DeleteIntersection;
        private System.Windows.Forms.Button button_CreateIntersection;
        private System.Windows.Forms.DataGridView dataGridView_IntersectionInfo;
        private System.Windows.Forms.Button button_DeleteConnectionRoad;
        private System.Windows.Forms.DataGridView dataGridView_IntersectionID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Connection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IntersectionID;
        private System.Windows.Forms.TextBox textBox_TrafficLightSetting;
        private System.Windows.Forms.Label label_TrafficLightSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1_RoadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_TrafficLightSetting;
        private System.Windows.Forms.TabPage tabPage_other;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Coordinate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RoadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_RoadName;
    }
}