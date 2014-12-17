namespace SmartCitySimulator
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
            this.button_switch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_startHour = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_startMinute = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_stopMinute = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_stopHour = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_simulationTimes = new System.Windows.Forms.NumericUpDown();
            this.checkBox_autoSave = new System.Windows.Forms.CheckBox();
            this.checkBox_saveTrafficRecord = new System.Windows.Forms.CheckBox();
            this.checkBox_saveOptimizationRecord = new System.Windows.Forms.CheckBox();
            this.groupBox_autoSimulationConfig = new System.Windows.Forms.GroupBox();
            this.button_addNewAutoSimulationTask = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_simulationFilePath = new System.Windows.Forms.TextBox();
            this.button_openSimulationFile = new System.Windows.Forms.Button();
            this.groupBox_autoSimulationInfo = new System.Windows.Forms.GroupBox();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_deleteSimulationTaskList = new System.Windows.Forms.Button();
            this.label_saveOptimization = new System.Windows.Forms.Label();
            this.label_saveTraffic = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_repaetTime = new System.Windows.Forms.Label();
            this.label_endTime = new System.Windows.Forms.Label();
            this.label_startTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_deleteSimulationTask = new System.Windows.Forms.Button();
            this.listBox_autoSimulationList = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.simulation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simulationState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_simulationTimes)).BeginInit();
            this.groupBox_autoSimulationConfig.SuspendLayout();
            this.groupBox_autoSimulationInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_switch
            // 
            this.button_switch.Location = new System.Drawing.Point(425, 180);
            this.button_switch.Margin = new System.Windows.Forms.Padding(4);
            this.button_switch.Name = "button_switch";
            this.button_switch.Size = new System.Drawing.Size(80, 35);
            this.button_switch.TabIndex = 0;
            this.button_switch.Text = "Start";
            this.button_switch.UseVisualStyleBackColor = true;
            this.button_switch.Click += new System.EventHandler(this.button_switch_Click);
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
            // numericUpDown_startHour
            // 
            this.numericUpDown_startHour.Location = new System.Drawing.Point(124, 72);
            this.numericUpDown_startHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_startHour.Name = "numericUpDown_startHour";
            this.numericUpDown_startHour.Size = new System.Drawing.Size(67, 25);
            this.numericUpDown_startHour.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "：";
            // 
            // numericUpDown_startMinute
            // 
            this.numericUpDown_startMinute.Location = new System.Drawing.Point(224, 72);
            this.numericUpDown_startMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_startMinute.Name = "numericUpDown_startMinute";
            this.numericUpDown_startMinute.Size = new System.Drawing.Size(67, 25);
            this.numericUpDown_startMinute.TabIndex = 6;
            // 
            // numericUpDown_stopMinute
            // 
            this.numericUpDown_stopMinute.Location = new System.Drawing.Point(224, 111);
            this.numericUpDown_stopMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_stopMinute.Name = "numericUpDown_stopMinute";
            this.numericUpDown_stopMinute.Size = new System.Drawing.Size(67, 25);
            this.numericUpDown_stopMinute.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "：";
            // 
            // numericUpDown_stopHour
            // 
            this.numericUpDown_stopHour.Location = new System.Drawing.Point(124, 111);
            this.numericUpDown_stopHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_stopHour.Name = "numericUpDown_stopHour";
            this.numericUpDown_stopHour.Size = new System.Drawing.Size(67, 25);
            this.numericUpDown_stopHour.TabIndex = 7;
            this.numericUpDown_stopHour.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label5.Location = new System.Drawing.Point(7, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Simulation Times : ";
            // 
            // numericUpDown_simulationTimes
            // 
            this.numericUpDown_simulationTimes.Location = new System.Drawing.Point(152, 150);
            this.numericUpDown_simulationTimes.Name = "numericUpDown_simulationTimes";
            this.numericUpDown_simulationTimes.Size = new System.Drawing.Size(67, 25);
            this.numericUpDown_simulationTimes.TabIndex = 11;
            this.numericUpDown_simulationTimes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBox_autoSave
            // 
            this.checkBox_autoSave.AutoSize = true;
            this.checkBox_autoSave.Checked = true;
            this.checkBox_autoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoSave.Location = new System.Drawing.Point(10, 192);
            this.checkBox_autoSave.Name = "checkBox_autoSave";
            this.checkBox_autoSave.Size = new System.Drawing.Size(95, 22);
            this.checkBox_autoSave.TabIndex = 12;
            this.checkBox_autoSave.Text = "Auto Save";
            this.checkBox_autoSave.UseVisualStyleBackColor = true;
            this.checkBox_autoSave.CheckedChanged += new System.EventHandler(this.checkBox_autoSave_CheckedChanged);
            // 
            // checkBox_saveTrafficRecord
            // 
            this.checkBox_saveTrafficRecord.AutoSize = true;
            this.checkBox_saveTrafficRecord.Checked = true;
            this.checkBox_saveTrafficRecord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_saveTrafficRecord.Location = new System.Drawing.Point(143, 192);
            this.checkBox_saveTrafficRecord.Name = "checkBox_saveTrafficRecord";
            this.checkBox_saveTrafficRecord.Size = new System.Drawing.Size(120, 22);
            this.checkBox_saveTrafficRecord.TabIndex = 13;
            this.checkBox_saveTrafficRecord.Text = "Traffic Record";
            this.checkBox_saveTrafficRecord.UseVisualStyleBackColor = true;
            // 
            // checkBox_saveOptimizationRecord
            // 
            this.checkBox_saveOptimizationRecord.AutoSize = true;
            this.checkBox_saveOptimizationRecord.Checked = true;
            this.checkBox_saveOptimizationRecord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_saveOptimizationRecord.Location = new System.Drawing.Point(290, 192);
            this.checkBox_saveOptimizationRecord.Name = "checkBox_saveOptimizationRecord";
            this.checkBox_saveOptimizationRecord.Size = new System.Drawing.Size(166, 22);
            this.checkBox_saveOptimizationRecord.TabIndex = 14;
            this.checkBox_saveOptimizationRecord.Text = "Optimization Record";
            this.checkBox_saveOptimizationRecord.UseVisualStyleBackColor = true;
            // 
            // groupBox_autoSimulationConfig
            // 
            this.groupBox_autoSimulationConfig.Controls.Add(this.button_addNewAutoSimulationTask);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label7);
            this.groupBox_autoSimulationConfig.Controls.Add(this.textBox_simulationFilePath);
            this.groupBox_autoSimulationConfig.Controls.Add(this.button_openSimulationFile);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label1);
            this.groupBox_autoSimulationConfig.Controls.Add(this.checkBox_saveOptimizationRecord);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label2);
            this.groupBox_autoSimulationConfig.Controls.Add(this.checkBox_saveTrafficRecord);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_startHour);
            this.groupBox_autoSimulationConfig.Controls.Add(this.checkBox_autoSave);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label3);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_simulationTimes);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_startMinute);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label5);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_stopHour);
            this.groupBox_autoSimulationConfig.Controls.Add(this.numericUpDown_stopMinute);
            this.groupBox_autoSimulationConfig.Controls.Add(this.label4);
            this.groupBox_autoSimulationConfig.Enabled = false;
            this.groupBox_autoSimulationConfig.Location = new System.Drawing.Point(12, 12);
            this.groupBox_autoSimulationConfig.Name = "groupBox_autoSimulationConfig";
            this.groupBox_autoSimulationConfig.Size = new System.Drawing.Size(512, 277);
            this.groupBox_autoSimulationConfig.TabIndex = 15;
            this.groupBox_autoSimulationConfig.TabStop = false;
            this.groupBox_autoSimulationConfig.Text = "New Auto Simulation Config";
            // 
            // button_addNewAutoSimulationTask
            // 
            this.button_addNewAutoSimulationTask.Location = new System.Drawing.Point(425, 235);
            this.button_addNewAutoSimulationTask.Margin = new System.Windows.Forms.Padding(4);
            this.button_addNewAutoSimulationTask.Name = "button_addNewAutoSimulationTask";
            this.button_addNewAutoSimulationTask.Size = new System.Drawing.Size(80, 35);
            this.button_addNewAutoSimulationTask.TabIndex = 21;
            this.button_addNewAutoSimulationTask.Text = "Add";
            this.button_addNewAutoSimulationTask.UseVisualStyleBackColor = true;
            this.button_addNewAutoSimulationTask.Click += new System.EventHandler(this.button_addNewAutoSimulationTask_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Simulation File : ";
            // 
            // textBox_simulationFilePath
            // 
            this.textBox_simulationFilePath.Location = new System.Drawing.Point(124, 33);
            this.textBox_simulationFilePath.Name = "textBox_simulationFilePath";
            this.textBox_simulationFilePath.ReadOnly = true;
            this.textBox_simulationFilePath.Size = new System.Drawing.Size(294, 25);
            this.textBox_simulationFilePath.TabIndex = 19;
            // 
            // button_openSimulationFile
            // 
            this.button_openSimulationFile.Location = new System.Drawing.Point(425, 28);
            this.button_openSimulationFile.Margin = new System.Windows.Forms.Padding(4);
            this.button_openSimulationFile.Name = "button_openSimulationFile";
            this.button_openSimulationFile.Size = new System.Drawing.Size(80, 35);
            this.button_openSimulationFile.TabIndex = 18;
            this.button_openSimulationFile.Text = "Open";
            this.button_openSimulationFile.UseVisualStyleBackColor = true;
            this.button_openSimulationFile.Click += new System.EventHandler(this.button_openSimulationFile_Click);
            // 
            // groupBox_autoSimulationInfo
            // 
            this.groupBox_autoSimulationInfo.Controls.Add(this.dataGridView1);
            this.groupBox_autoSimulationInfo.Location = new System.Drawing.Point(530, 12);
            this.groupBox_autoSimulationInfo.Name = "groupBox_autoSimulationInfo";
            this.groupBox_autoSimulationInfo.Size = new System.Drawing.Size(412, 505);
            this.groupBox_autoSimulationInfo.TabIndex = 16;
            this.groupBox_autoSimulationInfo.TabStop = false;
            this.groupBox_autoSimulationInfo.Text = "Auto Simulation Queue";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_deleteSimulationTaskList);
            this.groupBox1.Controls.Add(this.label_saveOptimization);
            this.groupBox1.Controls.Add(this.label_saveTraffic);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label_repaetTime);
            this.groupBox1.Controls.Add(this.label_endTime);
            this.groupBox1.Controls.Add(this.label_startTime);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.button_deleteSimulationTask);
            this.groupBox1.Controls.Add(this.listBox_autoSimulationList);
            this.groupBox1.Controls.Add(this.button_switch);
            this.groupBox1.Location = new System.Drawing.Point(12, 295);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 222);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Simulation List";
            // 
            // button_deleteSimulationTaskList
            // 
            this.button_deleteSimulationTaskList.Location = new System.Drawing.Point(139, 180);
            this.button_deleteSimulationTaskList.Margin = new System.Windows.Forms.Padding(4);
            this.button_deleteSimulationTaskList.Name = "button_deleteSimulationTaskList";
            this.button_deleteSimulationTaskList.Size = new System.Drawing.Size(80, 35);
            this.button_deleteSimulationTaskList.TabIndex = 30;
            this.button_deleteSimulationTaskList.Text = "Clear";
            this.button_deleteSimulationTaskList.UseVisualStyleBackColor = true;
            this.button_deleteSimulationTaskList.Click += new System.EventHandler(this.button_deleteSimulationTaskList_Click);
            // 
            // label_saveOptimization
            // 
            this.label_saveOptimization.AutoSize = true;
            this.label_saveOptimization.Location = new System.Drawing.Point(460, 144);
            this.label_saveOptimization.Name = "label_saveOptimization";
            this.label_saveOptimization.Size = new System.Drawing.Size(14, 18);
            this.label_saveOptimization.TabIndex = 29;
            this.label_saveOptimization.Text = "-";
            // 
            // label_saveTraffic
            // 
            this.label_saveTraffic.AutoSize = true;
            this.label_saveTraffic.Location = new System.Drawing.Point(413, 114);
            this.label_saveTraffic.Name = "label_saveTraffic";
            this.label_saveTraffic.Size = new System.Drawing.Size(14, 18);
            this.label_saveTraffic.TabIndex = 28;
            this.label_saveTraffic.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(270, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(193, 18);
            this.label12.TabIndex = 27;
            this.label12.Text = "Save Optimization Record : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 18);
            this.label11.TabIndex = 26;
            this.label11.Text = "Save Traffic Record : ";
            // 
            // label_repaetTime
            // 
            this.label_repaetTime.AutoSize = true;
            this.label_repaetTime.Location = new System.Drawing.Point(402, 84);
            this.label_repaetTime.Name = "label_repaetTime";
            this.label_repaetTime.Size = new System.Drawing.Size(14, 18);
            this.label_repaetTime.TabIndex = 25;
            this.label_repaetTime.Text = "-";
            // 
            // label_endTime
            // 
            this.label_endTime.AutoSize = true;
            this.label_endTime.Location = new System.Drawing.Point(361, 54);
            this.label_endTime.Name = "label_endTime";
            this.label_endTime.Size = new System.Drawing.Size(14, 18);
            this.label_endTime.TabIndex = 24;
            this.label_endTime.Text = "-";
            // 
            // label_startTime
            // 
            this.label_startTime.AutoSize = true;
            this.label_startTime.Location = new System.Drawing.Point(361, 24);
            this.label_startTime.Name = "label_startTime";
            this.label_startTime.Size = new System.Drawing.Size(14, 18);
            this.label_startTime.TabIndex = 23;
            this.label_startTime.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label10.Location = new System.Drawing.Point(270, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 18);
            this.label10.TabIndex = 22;
            this.label10.Text = "Simulation Times : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label9.Location = new System.Drawing.Point(270, 54);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "End Time : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label8.Location = new System.Drawing.Point(270, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 18);
            this.label8.TabIndex = 22;
            this.label8.Text = "Start Time : ";
            // 
            // button_deleteSimulationTask
            // 
            this.button_deleteSimulationTask.Location = new System.Drawing.Point(14, 180);
            this.button_deleteSimulationTask.Margin = new System.Windows.Forms.Padding(4);
            this.button_deleteSimulationTask.Name = "button_deleteSimulationTask";
            this.button_deleteSimulationTask.Size = new System.Drawing.Size(80, 35);
            this.button_deleteSimulationTask.TabIndex = 22;
            this.button_deleteSimulationTask.Text = "Delete";
            this.button_deleteSimulationTask.UseVisualStyleBackColor = true;
            this.button_deleteSimulationTask.Click += new System.EventHandler(this.button_deleteSimulationTask_Click);
            // 
            // listBox_autoSimulationList
            // 
            this.listBox_autoSimulationList.FormattingEnabled = true;
            this.listBox_autoSimulationList.ItemHeight = 17;
            this.listBox_autoSimulationList.Location = new System.Drawing.Point(6, 24);
            this.listBox_autoSimulationList.Name = "listBox_autoSimulationList";
            this.listBox_autoSimulationList.Size = new System.Drawing.Size(257, 140);
            this.listBox_autoSimulationList.TabIndex = 0;
            this.listBox_autoSimulationList.SelectedIndexChanged += new System.EventHandler(this.listBox_autoSimulationList_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.simulation,
            this.simulationState});
            this.dataGridView1.Location = new System.Drawing.Point(7, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(399, 480);
            this.dataGridView1.TabIndex = 0;
            // 
            // simulation
            // 
            this.simulation.HeaderText = "simulationName";
            this.simulation.Name = "simulation";
            // 
            // simulationState
            // 
            this.simulationState.FillWeight = 40F;
            this.simulationState.HeaderText = "State";
            this.simulationState.Name = "simulationState";
            // 
            // AutoSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 529);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_autoSimulationInfo);
            this.Controls.Add(this.groupBox_autoSimulationConfig);
            this.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoSimulation";
            this.Text = "Auto Simulation";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_simulationTimes)).EndInit();
            this.groupBox_autoSimulationConfig.ResumeLayout(false);
            this.groupBox_autoSimulationConfig.PerformLayout();
            this.groupBox_autoSimulationInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_switch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_startHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_startMinute;
        private System.Windows.Forms.NumericUpDown numericUpDown_stopMinute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_stopHour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_simulationTimes;
        private System.Windows.Forms.CheckBox checkBox_autoSave;
        private System.Windows.Forms.CheckBox checkBox_saveTrafficRecord;
        private System.Windows.Forms.CheckBox checkBox_saveOptimizationRecord;
        private System.Windows.Forms.GroupBox groupBox_autoSimulationConfig;
        private System.Windows.Forms.GroupBox groupBox_autoSimulationInfo;
        private System.Windows.Forms.Timer timer_refresh;
        private System.Windows.Forms.Button button_addNewAutoSimulationTask;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_simulationFilePath;
        private System.Windows.Forms.Button button_openSimulationFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_deleteSimulationTask;
        private System.Windows.Forms.ListBox listBox_autoSimulationList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_saveOptimization;
        private System.Windows.Forms.Label label_saveTraffic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_repaetTime;
        private System.Windows.Forms.Label label_endTime;
        private System.Windows.Forms.Label label_startTime;
        private System.Windows.Forms.Button button_deleteSimulationTaskList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulation;
        private System.Windows.Forms.DataGridViewTextBoxColumn simulationState;
    }
}