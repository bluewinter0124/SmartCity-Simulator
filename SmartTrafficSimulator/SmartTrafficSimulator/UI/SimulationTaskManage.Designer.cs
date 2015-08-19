namespace SmartTrafficSimulator
{
    partial class AutoSimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSimulation));
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.dataGridView_queueState = new System.Windows.Forms.DataGridView();
            this.groupBox_autoSimulationInfo = new System.Windows.Forms.GroupBox();
            this.button_toQueue = new System.Windows.Forms.Button();
            this.listBox_autoSimulationList = new System.Windows.Forms.ListBox();
            this.button_deleteSimulationTask = new System.Windows.Forms.Button();
            this.label_STime = new System.Windows.Forms.Label();
            this.label_ETime = new System.Windows.Forms.Label();
            this.label_repeatTimes = new System.Windows.Forms.Label();
            this.label_startTime = new System.Windows.Forms.Label();
            this.label_endTime = new System.Windows.Forms.Label();
            this.label_repaetTime = new System.Windows.Forms.Label();
            this.label_STR = new System.Windows.Forms.Label();
            this.label_SOR = new System.Windows.Forms.Label();
            this.label_saveTraffic = new System.Windows.Forms.Label();
            this.label_saveOptimization = new System.Windows.Forms.Label();
            this.button_deleteSimulationTaskList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_autoSimulationConfig = new System.Windows.Forms.GroupBox();
            this.checkBox_saveVehicleData = new System.Windows.Forms.CheckBox();
            this.checkBox_saveIntersectionState = new System.Windows.Forms.CheckBox();
            this.button_addNewAutoSimulationTask = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_simulationFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_saveOptimizationRecord = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_saveTrafficRecord = new System.Windows.Forms.CheckBox();
            this.numericUpDown_startHour = new System.Windows.Forms.NumericUpDown();
            this.checkBox_autoSave = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_repeatTimes = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_startMinute = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_stopHour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_stopMinute = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.button_openSimulationFile = new System.Windows.Forms.Button();
            this.simulation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_queueState)).BeginInit();
            this.groupBox_autoSimulationInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_autoSimulationConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_repeatTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_queueState
            // 
            this.dataGridView_queueState.AllowUserToAddRows = false;
            this.dataGridView_queueState.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_queueState.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_queueState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_queueState.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.simulation,
            this.simulationStatus});
            this.dataGridView_queueState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_queueState.Location = new System.Drawing.Point(3, 21);
            this.dataGridView_queueState.Name = "dataGridView_queueState";
            this.dataGridView_queueState.RowTemplate.Height = 24;
            this.dataGridView_queueState.Size = new System.Drawing.Size(406, 520);
            this.dataGridView_queueState.TabIndex = 0;
            // 
            // groupBox_autoSimulationInfo
            // 
            this.groupBox_autoSimulationInfo.Controls.Add(this.dataGridView_queueState);
            this.groupBox_autoSimulationInfo.Location = new System.Drawing.Point(527, 12);
            this.groupBox_autoSimulationInfo.Name = "groupBox_autoSimulationInfo";
            this.groupBox_autoSimulationInfo.Size = new System.Drawing.Size(412, 544);
            this.groupBox_autoSimulationInfo.TabIndex = 27;
            this.groupBox_autoSimulationInfo.TabStop = false;
            this.groupBox_autoSimulationInfo.Text = "Simulation Queue";
            // 
            // button_toQueue
            // 
            this.button_toQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_toQueue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_toQueue.FlatAppearance.BorderSize = 0;
            this.button_toQueue.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_toQueue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_toQueue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_toQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_toQueue.Location = new System.Drawing.Point(364, 180);
            this.button_toQueue.Margin = new System.Windows.Forms.Padding(4);
            this.button_toQueue.Name = "button_toQueue";
            this.button_toQueue.Size = new System.Drawing.Size(141, 35);
            this.button_toQueue.TabIndex = 0;
            this.button_toQueue.Text = "Add to task queue";
            this.button_toQueue.UseVisualStyleBackColor = false;
            this.button_toQueue.Click += new System.EventHandler(this.button_toQueue_Click);
            // 
            // listBox_autoSimulationList
            // 
            this.listBox_autoSimulationList.FormattingEnabled = true;
            this.listBox_autoSimulationList.ItemHeight = 17;
            this.listBox_autoSimulationList.Location = new System.Drawing.Point(6, 24);
            this.listBox_autoSimulationList.Name = "listBox_autoSimulationList";
            this.listBox_autoSimulationList.Size = new System.Drawing.Size(257, 140);
            this.listBox_autoSimulationList.TabIndex = 0;
            this.listBox_autoSimulationList.SelectedIndexChanged += new System.EventHandler(this.listBox_SimulationTaskList_SelectedIndexChanged);
            // 
            // button_deleteSimulationTask
            // 
            this.button_deleteSimulationTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_deleteSimulationTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_deleteSimulationTask.FlatAppearance.BorderSize = 0;
            this.button_deleteSimulationTask.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_deleteSimulationTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_deleteSimulationTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_deleteSimulationTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_deleteSimulationTask.Location = new System.Drawing.Point(14, 180);
            this.button_deleteSimulationTask.Margin = new System.Windows.Forms.Padding(4);
            this.button_deleteSimulationTask.Name = "button_deleteSimulationTask";
            this.button_deleteSimulationTask.Size = new System.Drawing.Size(80, 35);
            this.button_deleteSimulationTask.TabIndex = 22;
            this.button_deleteSimulationTask.Text = "Delete";
            this.button_deleteSimulationTask.UseVisualStyleBackColor = false;
            this.button_deleteSimulationTask.Click += new System.EventHandler(this.button_deleteSimulationTask_Click);
            // 
            // label_STime
            // 
            this.label_STime.AutoSize = true;
            this.label_STime.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_STime.Location = new System.Drawing.Point(270, 24);
            this.label_STime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_STime.Name = "label_STime";
            this.label_STime.Size = new System.Drawing.Size(87, 18);
            this.label_STime.TabIndex = 22;
            this.label_STime.Text = "Start Time : ";
            // 
            // label_ETime
            // 
            this.label_ETime.AutoSize = true;
            this.label_ETime.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_ETime.Location = new System.Drawing.Point(270, 54);
            this.label_ETime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ETime.Name = "label_ETime";
            this.label_ETime.Size = new System.Drawing.Size(82, 18);
            this.label_ETime.TabIndex = 22;
            this.label_ETime.Text = "End Time : ";
            // 
            // label_repeatTimes
            // 
            this.label_repeatTimes.AutoSize = true;
            this.label_repeatTimes.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_repeatTimes.Location = new System.Drawing.Point(270, 84);
            this.label_repeatTimes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_repeatTimes.Name = "label_repeatTimes";
            this.label_repeatTimes.Size = new System.Drawing.Size(109, 18);
            this.label_repeatTimes.TabIndex = 22;
            this.label_repeatTimes.Text = "Repeat Times : ";
            // 
            // label_startTime
            // 
            this.label_startTime.AutoSize = true;
            this.label_startTime.Location = new System.Drawing.Point(361, 24);
            this.label_startTime.Name = "label_startTime";
            this.label_startTime.Size = new System.Drawing.Size(14, 17);
            this.label_startTime.TabIndex = 23;
            this.label_startTime.Text = "-";
            // 
            // label_endTime
            // 
            this.label_endTime.AutoSize = true;
            this.label_endTime.Location = new System.Drawing.Point(361, 54);
            this.label_endTime.Name = "label_endTime";
            this.label_endTime.Size = new System.Drawing.Size(14, 17);
            this.label_endTime.TabIndex = 24;
            this.label_endTime.Text = "-";
            // 
            // label_repaetTime
            // 
            this.label_repaetTime.AutoSize = true;
            this.label_repaetTime.Location = new System.Drawing.Point(402, 84);
            this.label_repaetTime.Name = "label_repaetTime";
            this.label_repaetTime.Size = new System.Drawing.Size(14, 17);
            this.label_repaetTime.TabIndex = 25;
            this.label_repaetTime.Text = "-";
            // 
            // label_STR
            // 
            this.label_STR.AutoSize = true;
            this.label_STR.Location = new System.Drawing.Point(270, 114);
            this.label_STR.Name = "label_STR";
            this.label_STR.Size = new System.Drawing.Size(129, 17);
            this.label_STR.TabIndex = 26;
            this.label_STR.Text = "Save Traffic Record : ";
            // 
            // label_SOR
            // 
            this.label_SOR.AutoSize = true;
            this.label_SOR.Location = new System.Drawing.Point(270, 144);
            this.label_SOR.Name = "label_SOR";
            this.label_SOR.Size = new System.Drawing.Size(172, 17);
            this.label_SOR.TabIndex = 27;
            this.label_SOR.Text = "Save Optimization Record : ";
            // 
            // label_saveTraffic
            // 
            this.label_saveTraffic.AutoSize = true;
            this.label_saveTraffic.Location = new System.Drawing.Point(413, 114);
            this.label_saveTraffic.Name = "label_saveTraffic";
            this.label_saveTraffic.Size = new System.Drawing.Size(14, 17);
            this.label_saveTraffic.TabIndex = 28;
            this.label_saveTraffic.Text = "-";
            // 
            // label_saveOptimization
            // 
            this.label_saveOptimization.AutoSize = true;
            this.label_saveOptimization.Location = new System.Drawing.Point(460, 144);
            this.label_saveOptimization.Name = "label_saveOptimization";
            this.label_saveOptimization.Size = new System.Drawing.Size(14, 17);
            this.label_saveOptimization.TabIndex = 29;
            this.label_saveOptimization.Text = "-";
            // 
            // button_deleteSimulationTaskList
            // 
            this.button_deleteSimulationTaskList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_deleteSimulationTaskList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_deleteSimulationTaskList.FlatAppearance.BorderSize = 0;
            this.button_deleteSimulationTaskList.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_deleteSimulationTaskList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_deleteSimulationTaskList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_deleteSimulationTaskList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_deleteSimulationTaskList.Location = new System.Drawing.Point(139, 180);
            this.button_deleteSimulationTaskList.Margin = new System.Windows.Forms.Padding(4);
            this.button_deleteSimulationTaskList.Name = "button_deleteSimulationTaskList";
            this.button_deleteSimulationTaskList.Size = new System.Drawing.Size(80, 35);
            this.button_deleteSimulationTaskList.TabIndex = 30;
            this.button_deleteSimulationTaskList.Text = "Clear";
            this.button_deleteSimulationTaskList.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_deleteSimulationTaskList);
            this.groupBox1.Controls.Add(this.label_saveOptimization);
            this.groupBox1.Controls.Add(this.label_saveTraffic);
            this.groupBox1.Controls.Add(this.label_SOR);
            this.groupBox1.Controls.Add(this.label_STR);
            this.groupBox1.Controls.Add(this.label_repaetTime);
            this.groupBox1.Controls.Add(this.label_endTime);
            this.groupBox1.Controls.Add(this.label_startTime);
            this.groupBox1.Controls.Add(this.label_repeatTimes);
            this.groupBox1.Controls.Add(this.label_ETime);
            this.groupBox1.Controls.Add(this.label_STime);
            this.groupBox1.Controls.Add(this.button_deleteSimulationTask);
            this.groupBox1.Controls.Add(this.listBox_autoSimulationList);
            this.groupBox1.Controls.Add(this.button_toQueue);
            this.groupBox1.Location = new System.Drawing.Point(12, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 222);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation Task List";
            // 
            // groupBox_autoSimulationConfig
            // 
            this.groupBox_autoSimulationConfig.Controls.Add(this.checkBox_saveVehicleData);
            this.groupBox_autoSimulationConfig.Controls.Add(this.checkBox_saveIntersectionState);
            this.groupBox_autoSimulationConfig.Controls.Add(this.button_addNewAutoSimulationTask);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label7);
            this.groupBox_autoSimulationConfig.Controls.Add(this.textBox_simulationFilePath);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label1);
            this.groupBox_autoSimulationConfig.Controls.Add(this.checkBox_saveOptimizationRecord);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label2);
            this.groupBox_autoSimulationConfig.Controls.Add(this.checkBox_saveTrafficRecord);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_startHour);
            this.groupBox_autoSimulationConfig.Controls.Add(this.checkBox_autoSave);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label3);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_repeatTimes);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_startMinute);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label5);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_stopHour);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_stopMinute);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label4);
            this.groupBox_autoSimulationConfig.Controls.Add(this.button_openSimulationFile);
            this.groupBox_autoSimulationConfig.Location = new System.Drawing.Point(9, 12);
            this.groupBox_autoSimulationConfig.Name = "groupBox_autoSimulationConfig";
            this.groupBox_autoSimulationConfig.Size = new System.Drawing.Size(512, 316);
            this.groupBox_autoSimulationConfig.TabIndex = 24;
            this.groupBox_autoSimulationConfig.TabStop = false;
            this.groupBox_autoSimulationConfig.Text = "New Simulation Task";
            // 
            // checkBox_saveVehicleData
            // 
            this.checkBox_saveVehicleData.AutoSize = true;
            this.checkBox_saveVehicleData.Checked = true;
            this.checkBox_saveVehicleData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_saveVehicleData.Location = new System.Drawing.Point(290, 219);
            this.checkBox_saveVehicleData.Name = "checkBox_saveVehicleData";
            this.checkBox_saveVehicleData.Size = new System.Drawing.Size(102, 21);
            this.checkBox_saveVehicleData.TabIndex = 23;
            this.checkBox_saveVehicleData.Text = "Vehicle Data";
            this.checkBox_saveVehicleData.UseVisualStyleBackColor = true;
            // 
            // checkBox_saveIntersectionState
            // 
            this.checkBox_saveIntersectionState.AutoSize = true;
            this.checkBox_saveIntersectionState.Checked = true;
            this.checkBox_saveIntersectionState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_saveIntersectionState.Location = new System.Drawing.Point(143, 219);
            this.checkBox_saveIntersectionState.Name = "checkBox_saveIntersectionState";
            this.checkBox_saveIntersectionState.Size = new System.Drawing.Size(133, 21);
            this.checkBox_saveIntersectionState.TabIndex = 22;
            this.checkBox_saveIntersectionState.Text = "Intersection State";
            this.checkBox_saveIntersectionState.UseVisualStyleBackColor = true;
            // 
            // button_addNewAutoSimulationTask
            // 
            this.button_addNewAutoSimulationTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_addNewAutoSimulationTask.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_addNewAutoSimulationTask.FlatAppearance.BorderSize = 0;
            this.button_addNewAutoSimulationTask.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addNewAutoSimulationTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_addNewAutoSimulationTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addNewAutoSimulationTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addNewAutoSimulationTask.Location = new System.Drawing.Point(425, 265);
            this.button_addNewAutoSimulationTask.Margin = new System.Windows.Forms.Padding(4);
            this.button_addNewAutoSimulationTask.Name = "button_addNewAutoSimulationTask";
            this.button_addNewAutoSimulationTask.Size = new System.Drawing.Size(80, 35);
            this.button_addNewAutoSimulationTask.TabIndex = 21;
            this.button_addNewAutoSimulationTask.Text = "Add";
            this.button_addNewAutoSimulationTask.UseVisualStyleBackColor = false;
            this.button_addNewAutoSimulationTask.Click += new System.EventHandler(this.button_addNewAutoSimulationTask_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Simulation File : ";
            // 
            // textBox_simulationFilePath
            // 
            this.textBox_simulationFilePath.BackColor = System.Drawing.Color.White;
            this.textBox_simulationFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_simulationFilePath.Location = new System.Drawing.Point(124, 33);
            this.textBox_simulationFilePath.Name = "textBox_simulationFilePath";
            this.textBox_simulationFilePath.ReadOnly = true;
            this.textBox_simulationFilePath.Size = new System.Drawing.Size(294, 18);
            this.textBox_simulationFilePath.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label1.Location = new System.Drawing.Point(7, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Time : ";
            // 
            // checkBox_saveOptimizationRecord
            // 
            this.checkBox_saveOptimizationRecord.AutoSize = true;
            this.checkBox_saveOptimizationRecord.Location = new System.Drawing.Point(290, 192);
            this.checkBox_saveOptimizationRecord.Name = "checkBox_saveOptimizationRecord";
            this.checkBox_saveOptimizationRecord.Size = new System.Drawing.Size(151, 21);
            this.checkBox_saveOptimizationRecord.TabIndex = 14;
            this.checkBox_saveOptimizationRecord.Text = "Optimization Record";
            this.checkBox_saveOptimizationRecord.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.Location = new System.Drawing.Point(7, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Time : ";
            // 
            // checkBox_saveTrafficRecord
            // 
            this.checkBox_saveTrafficRecord.AutoSize = true;
            this.checkBox_saveTrafficRecord.Location = new System.Drawing.Point(143, 192);
            this.checkBox_saveTrafficRecord.Name = "checkBox_saveTrafficRecord";
            this.checkBox_saveTrafficRecord.Size = new System.Drawing.Size(108, 21);
            this.checkBox_saveTrafficRecord.TabIndex = 13;
            this.checkBox_saveTrafficRecord.Text = "Traffic Record";
            this.checkBox_saveTrafficRecord.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_startHour
            // 
            this.numericUpDown_startHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_startHour.Location = new System.Drawing.Point(124, 72);
            this.numericUpDown_startHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_startHour.Name = "numericUpDown_startHour";
            this.numericUpDown_startHour.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown_startHour.TabIndex = 4;
            // 
            // checkBox_autoSave
            // 
            this.checkBox_autoSave.AutoSize = true;
            this.checkBox_autoSave.Checked = true;
            this.checkBox_autoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoSave.Location = new System.Drawing.Point(10, 192);
            this.checkBox_autoSave.Name = "checkBox_autoSave";
            this.checkBox_autoSave.Size = new System.Drawing.Size(88, 21);
            this.checkBox_autoSave.TabIndex = 12;
            this.checkBox_autoSave.Text = "Auto Save";
            this.checkBox_autoSave.UseVisualStyleBackColor = true;
            this.checkBox_autoSave.CheckedChanged += new System.EventHandler(this.checkBox_autoSave_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "：";
            // 
            // numericUpDown_repeatTimes
            // 
            this.numericUpDown_repeatTimes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_repeatTimes.Location = new System.Drawing.Point(152, 150);
            this.numericUpDown_repeatTimes.Name = "numericUpDown_repeatTimes";
            this.numericUpDown_repeatTimes.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown_repeatTimes.TabIndex = 11;
            this.numericUpDown_repeatTimes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDown_startMinute
            // 
            this.numericUpDown_startMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_startMinute.Location = new System.Drawing.Point(224, 72);
            this.numericUpDown_startMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_startMinute.Name = "numericUpDown_startMinute";
            this.numericUpDown_startMinute.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown_startMinute.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label5.Location = new System.Drawing.Point(7, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Repeat Times : ";
            // 
            // numericUpDown_stopHour
            // 
            this.numericUpDown_stopHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_stopHour.Location = new System.Drawing.Point(124, 111);
            this.numericUpDown_stopHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_stopHour.Name = "numericUpDown_stopHour";
            this.numericUpDown_stopHour.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown_stopHour.TabIndex = 7;
            this.numericUpDown_stopHour.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // numericUpDown_stopMinute
            // 
            this.numericUpDown_stopMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_stopMinute.Location = new System.Drawing.Point(224, 111);
            this.numericUpDown_stopMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_stopMinute.Name = "numericUpDown_stopMinute";
            this.numericUpDown_stopMinute.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown_stopMinute.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "：";
            // 
            // button_openSimulationFile
            // 
            this.button_openSimulationFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_openSimulationFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_openSimulationFile.FlatAppearance.BorderSize = 0;
            this.button_openSimulationFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_openSimulationFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_openSimulationFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_openSimulationFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_openSimulationFile.Location = new System.Drawing.Point(425, 24);
            this.button_openSimulationFile.Margin = new System.Windows.Forms.Padding(4);
            this.button_openSimulationFile.Name = "button_openSimulationFile";
            this.button_openSimulationFile.Size = new System.Drawing.Size(80, 35);
            this.button_openSimulationFile.TabIndex = 18;
            this.button_openSimulationFile.Text = "Open";
            this.button_openSimulationFile.UseVisualStyleBackColor = false;
            this.button_openSimulationFile.Click += new System.EventHandler(this.button_openSimulationFile_Click);
            // 
            // simulation
            // 
            this.simulation.HeaderText = "simulationName";
            this.simulation.Name = "simulation";
            // 
            // simulationStatus
            // 
            this.simulationStatus.FillWeight = 40F;
            this.simulationStatus.HeaderText = "Status";
            this.simulationStatus.Name = "simulationStatus";
            // 
            // AutoSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(948, 564);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_autoSimulationInfo);
            this.Controls.Add(this.groupBox_autoSimulationConfig);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoSimulation";
            this.Text = "Simulation Task Management";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_queueState)).EndInit();
            this.groupBox_autoSimulationInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_autoSimulationConfig.ResumeLayout(false);
            this.groupBox_autoSimulationConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_repeatTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopMinute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.DataGridView dataGridView_queueState;
        private System.Windows.Forms.GroupBox groupBox_autoSimulationInfo;
        private System.Windows.Forms.Button button_toQueue;
        private System.Windows.Forms.ListBox listBox_autoSimulationList;
        private System.Windows.Forms.Button button_deleteSimulationTask;
        private System.Windows.Forms.Label label_STime;
        private System.Windows.Forms.Label label_ETime;
        private System.Windows.Forms.Label label_repeatTimes;
        private System.Windows.Forms.Label label_startTime;
        private System.Windows.Forms.Label label_endTime;
        private System.Windows.Forms.Label label_repaetTime;
        private System.Windows.Forms.Label label_STR;
        private System.Windows.Forms.Label label_SOR;
        private System.Windows.Forms.Label label_saveTraffic;
        private System.Windows.Forms.Label label_saveOptimization;
        private System.Windows.Forms.Button button_deleteSimulationTaskList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox_autoSimulationConfig;
        private System.Windows.Forms.Button button_addNewAutoSimulationTask;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_simulationFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_saveOptimizationRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_saveTrafficRecord;
        private System.Windows.Forms.NumericUpDown numericUpDown_startHour;
        private System.Windows.Forms.CheckBox checkBox_autoSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_repeatTimes;
        private System.Windows.Forms.NumericUpDown numericUpDown_startMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_stopHour;
        private System.Windows.Forms.NumericUpDown numericUpDown_stopMinute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_openSimulationFile;
        private System.Windows.Forms.CheckBox checkBox_saveVehicleData;
        private System.Windows.Forms.CheckBox checkBox_saveIntersectionState;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulation;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationStatus;


    }
}