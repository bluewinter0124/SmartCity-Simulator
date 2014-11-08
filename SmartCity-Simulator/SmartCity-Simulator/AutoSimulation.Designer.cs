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
            this.groupBox_autoSimulationInfo = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_accomplishTimes = new System.Windows.Forms.Label();
            this.timer_refresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_stopHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_simulationTimes)).BeginInit();
            this.groupBox_autoSimulationConfig.SuspendLayout();
            this.groupBox_autoSimulationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_switch
            // 
            this.button_switch.Location = new System.Drawing.Point(223, 230);
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
            this.label1.Location = new System.Drawing.Point(7, 30);
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
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Time : ";
            // 
            // numericUpDown_startHour
            // 
            this.numericUpDown_startHour.Location = new System.Drawing.Point(124, 27);
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
            this.label3.Location = new System.Drawing.Point(197, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "：";
            // 
            // numericUpDown_startMinute
            // 
            this.numericUpDown_startMinute.Location = new System.Drawing.Point(224, 27);
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
            this.numericUpDown_stopMinute.Location = new System.Drawing.Point(224, 67);
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
            this.label4.Location = new System.Drawing.Point(197, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "：";
            // 
            // numericUpDown_stopHour
            // 
            this.numericUpDown_stopHour.Location = new System.Drawing.Point(124, 67);
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
            this.label5.Location = new System.Drawing.Point(7, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Simulation Times : ";
            // 
            // numericUpDown_simulationTimes
            // 
            this.numericUpDown_simulationTimes.Location = new System.Drawing.Point(152, 108);
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
            this.checkBox_autoSave.Location = new System.Drawing.Point(10, 151);
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
            this.checkBox_saveTrafficRecord.Location = new System.Drawing.Point(143, 151);
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
            this.checkBox_saveOptimizationRecord.Location = new System.Drawing.Point(290, 151);
            this.checkBox_saveOptimizationRecord.Name = "checkBox_saveOptimizationRecord";
            this.checkBox_saveOptimizationRecord.Size = new System.Drawing.Size(166, 22);
            this.checkBox_saveOptimizationRecord.TabIndex = 14;
            this.checkBox_saveOptimizationRecord.Text = "Optimization Record";
            this.checkBox_saveOptimizationRecord.UseVisualStyleBackColor = true;
            // 
            // groupBox_autoSimulationConfig
            // 
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
            this.groupBox_autoSimulationConfig.Size = new System.Drawing.Size(512, 211);
            this.groupBox_autoSimulationConfig.TabIndex = 15;
            this.groupBox_autoSimulationConfig.TabStop = false;
            this.groupBox_autoSimulationConfig.Text = "Auto Simulation Config";
            // 
            // groupBox_autoSimulationInfo
            // 
            this.groupBox_autoSimulationInfo.Controls.Add(this.label_accomplishTimes);
            this.groupBox_autoSimulationInfo.Controls.Add(this.label6);
            this.groupBox_autoSimulationInfo.Location = new System.Drawing.Point(12, 272);
            this.groupBox_autoSimulationInfo.Name = "groupBox_autoSimulationInfo";
            this.groupBox_autoSimulationInfo.Size = new System.Drawing.Size(512, 129);
            this.groupBox_autoSimulationInfo.TabIndex = 16;
            this.groupBox_autoSimulationInfo.TabStop = false;
            this.groupBox_autoSimulationInfo.Text = "Auto Simulation Info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label6.Location = new System.Drawing.Point(7, 32);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Accomplish Times : ";
            // 
            // label_accomplishTimes
            // 
            this.label_accomplishTimes.AutoSize = true;
            this.label_accomplishTimes.Location = new System.Drawing.Point(149, 32);
            this.label_accomplishTimes.Name = "label_accomplishTimes";
            this.label_accomplishTimes.Size = new System.Drawing.Size(44, 18);
            this.label_accomplishTimes.TabIndex = 16;
            this.label_accomplishTimes.Text = "times";
            // 
            // AutoSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 412);
            this.Controls.Add(this.button_switch);
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
            this.groupBox_autoSimulationInfo.PerformLayout();
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
        private System.Windows.Forms.Label label_accomplishTimes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer_refresh;
    }
}