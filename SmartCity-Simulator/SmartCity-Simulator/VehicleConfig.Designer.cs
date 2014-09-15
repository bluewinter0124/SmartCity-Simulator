namespace SmartCitySimulator
{
    partial class VehicleConfig
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
            this.comboBox_generateRoads = new System.Windows.Forms.ComboBox();
            this.groupBox_generateRoads = new System.Windows.Forms.GroupBox();
            this.button_addGenerateRoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_otherRoads = new System.Windows.Forms.ComboBox();
            this.button_removeGenerateRoad = new System.Windows.Forms.Button();
            this.comboBox_generateLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_vehicleConfig = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_CarSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_CarSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_vehicleGraphicDemo = new System.Windows.Forms.PictureBox();
            this.button_applyVehicleConfig = new System.Windows.Forms.Button();
            this.groupBox_generateSchedule = new System.Windows.Forms.GroupBox();
            this.button_addSchedule = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_level = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_minute = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_hour = new System.Windows.Forms.NumericUpDown();
            this.button_removeSchedule = new System.Windows.Forms.Button();
            this.listBox_generateSchedule = new System.Windows.Forms.ListBox();
            this.groupBox_generateRoads.SuspendLayout();
            this.groupBox_vehicleConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vehicleGraphicDemo)).BeginInit();
            this.groupBox_generateSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hour)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_generateRoads
            // 
            this.comboBox_generateRoads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_generateRoads.FormattingEnabled = true;
            this.comboBox_generateRoads.Location = new System.Drawing.Point(76, 30);
            this.comboBox_generateRoads.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_generateRoads.Name = "comboBox_generateRoads";
            this.comboBox_generateRoads.Size = new System.Drawing.Size(125, 25);
            this.comboBox_generateRoads.TabIndex = 0;
            this.comboBox_generateRoads.SelectedIndexChanged += new System.EventHandler(this.comboBox_generateRoad_SelectedIndexChanged);
            // 
            // groupBox_generateRoads
            // 
            this.groupBox_generateRoads.Controls.Add(this.button_addGenerateRoad);
            this.groupBox_generateRoads.Controls.Add(this.label3);
            this.groupBox_generateRoads.Controls.Add(this.comboBox_otherRoads);
            this.groupBox_generateRoads.Controls.Add(this.button_removeGenerateRoad);
            this.groupBox_generateRoads.Controls.Add(this.comboBox_generateLevel);
            this.groupBox_generateRoads.Controls.Add(this.label2);
            this.groupBox_generateRoads.Controls.Add(this.label1);
            this.groupBox_generateRoads.Controls.Add(this.comboBox_generateRoads);
            this.groupBox_generateRoads.Location = new System.Drawing.Point(13, 13);
            this.groupBox_generateRoads.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_generateRoads.Name = "groupBox_generateRoads";
            this.groupBox_generateRoads.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_generateRoads.Size = new System.Drawing.Size(369, 224);
            this.groupBox_generateRoads.TabIndex = 1;
            this.groupBox_generateRoads.TabStop = false;
            this.groupBox_generateRoads.Text = "產生車輛道路";
            // 
            // button_addGenerateRoad
            // 
            this.button_addGenerateRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_addGenerateRoad.Location = new System.Drawing.Point(233, 168);
            this.button_addGenerateRoad.Margin = new System.Windows.Forms.Padding(4);
            this.button_addGenerateRoad.Name = "button_addGenerateRoad";
            this.button_addGenerateRoad.Size = new System.Drawing.Size(90, 35);
            this.button_addGenerateRoad.TabIndex = 7;
            this.button_addGenerateRoad.Text = "加入產生";
            this.button_addGenerateRoad.UseVisualStyleBackColor = true;
            this.button_addGenerateRoad.Click += new System.EventHandler(this.button_addGenerateRoad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "道路ID";
            // 
            // comboBox_otherRoads
            // 
            this.comboBox_otherRoads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_otherRoads.FormattingEnabled = true;
            this.comboBox_otherRoads.Location = new System.Drawing.Point(76, 174);
            this.comboBox_otherRoads.Name = "comboBox_otherRoads";
            this.comboBox_otherRoads.Size = new System.Drawing.Size(125, 25);
            this.comboBox_otherRoads.TabIndex = 5;
            // 
            // button_removeGenerateRoad
            // 
            this.button_removeGenerateRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_removeGenerateRoad.Location = new System.Drawing.Point(233, 23);
            this.button_removeGenerateRoad.Margin = new System.Windows.Forms.Padding(4);
            this.button_removeGenerateRoad.Name = "button_removeGenerateRoad";
            this.button_removeGenerateRoad.Size = new System.Drawing.Size(90, 35);
            this.button_removeGenerateRoad.TabIndex = 4;
            this.button_removeGenerateRoad.Text = "移除此道路";
            this.button_removeGenerateRoad.UseVisualStyleBackColor = true;
            this.button_removeGenerateRoad.Click += new System.EventHandler(this.button_removeGenerateRoad_Click);
            // 
            // comboBox_generateLevel
            // 
            this.comboBox_generateLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_generateLevel.FormattingEnabled = true;
            this.comboBox_generateLevel.Items.AddRange(new object[] {
            "不產生",
            "非常少",
            "少",
            "普通",
            "多",
            "非常多"});
            this.comboBox_generateLevel.Location = new System.Drawing.Point(76, 78);
            this.comboBox_generateLevel.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_generateLevel.Name = "comboBox_generateLevel";
            this.comboBox_generateLevel.Size = new System.Drawing.Size(125, 25);
            this.comboBox_generateLevel.TabIndex = 3;
            this.comboBox_generateLevel.SelectedIndexChanged += new System.EventHandler(this.comboBox_rate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "產生頻率 : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "道路ID : ";
            // 
            // groupBox_vehicleConfig
            // 
            this.groupBox_vehicleConfig.Controls.Add(this.label6);
            this.groupBox_vehicleConfig.Controls.Add(this.numericUpDown_CarSpeed);
            this.groupBox_vehicleConfig.Controls.Add(this.label5);
            this.groupBox_vehicleConfig.Controls.Add(this.button_applyVehicleConfig);
            this.groupBox_vehicleConfig.Controls.Add(this.numericUpDown_CarSize);
            this.groupBox_vehicleConfig.Controls.Add(this.label4);
            this.groupBox_vehicleConfig.Controls.Add(this.pictureBox_vehicleGraphicDemo);
            this.groupBox_vehicleConfig.Location = new System.Drawing.Point(13, 245);
            this.groupBox_vehicleConfig.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_vehicleConfig.Name = "groupBox_vehicleConfig";
            this.groupBox_vehicleConfig.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_vehicleConfig.Size = new System.Drawing.Size(369, 166);
            this.groupBox_vehicleConfig.TabIndex = 2;
            this.groupBox_vehicleConfig.TabStop = false;
            this.groupBox_vehicleConfig.Text = "車輛設定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "實際畫面大小";
            // 
            // numericUpDown_CarSpeed
            // 
            this.numericUpDown_CarSpeed.Location = new System.Drawing.Point(305, 70);
            this.numericUpDown_CarSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_CarSpeed.Name = "numericUpDown_CarSpeed";
            this.numericUpDown_CarSpeed.Size = new System.Drawing.Size(45, 25);
            this.numericUpDown_CarSpeed.TabIndex = 10;
            this.numericUpDown_CarSpeed.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "車輛速度(km/H)";
            // 
            // numericUpDown_CarSize
            // 
            this.numericUpDown_CarSize.Location = new System.Drawing.Point(305, 25);
            this.numericUpDown_CarSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_CarSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_CarSize.Name = "numericUpDown_CarSize";
            this.numericUpDown_CarSize.Size = new System.Drawing.Size(45, 25);
            this.numericUpDown_CarSize.TabIndex = 3;
            this.numericUpDown_CarSize.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_CarSize.ValueChanged += new System.EventHandler(this.numericUpDown_CarLength_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "車輛大小";
            // 
            // pictureBox_vehicleGraphicDemo
            // 
            this.pictureBox_vehicleGraphicDemo.Image = global::SmartCitySimulator.Properties.Resources.car0;
            this.pictureBox_vehicleGraphicDemo.Location = new System.Drawing.Point(14, 25);
            this.pictureBox_vehicleGraphicDemo.Name = "pictureBox_vehicleGraphicDemo";
            this.pictureBox_vehicleGraphicDemo.Size = new System.Drawing.Size(24, 12);
            this.pictureBox_vehicleGraphicDemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_vehicleGraphicDemo.TabIndex = 0;
            this.pictureBox_vehicleGraphicDemo.TabStop = false;
            // 
            // button_applyVehicleConfig
            // 
            this.button_applyVehicleConfig.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_applyVehicleConfig.Location = new System.Drawing.Point(260, 122);
            this.button_applyVehicleConfig.Margin = new System.Windows.Forms.Padding(4);
            this.button_applyVehicleConfig.Name = "button_applyVehicleConfig";
            this.button_applyVehicleConfig.Size = new System.Drawing.Size(90, 35);
            this.button_applyVehicleConfig.TabIndex = 8;
            this.button_applyVehicleConfig.Text = "套用設定";
            this.button_applyVehicleConfig.UseVisualStyleBackColor = true;
            this.button_applyVehicleConfig.Click += new System.EventHandler(this.button_applyConfig_Click);
            // 
            // groupBox_generateSchedule
            // 
            this.groupBox_generateSchedule.Controls.Add(this.button_addSchedule);
            this.groupBox_generateSchedule.Controls.Add(this.label9);
            this.groupBox_generateSchedule.Controls.Add(this.label8);
            this.groupBox_generateSchedule.Controls.Add(this.label7);
            this.groupBox_generateSchedule.Controls.Add(this.numericUpDown_level);
            this.groupBox_generateSchedule.Controls.Add(this.numericUpDown_minute);
            this.groupBox_generateSchedule.Controls.Add(this.numericUpDown_hour);
            this.groupBox_generateSchedule.Controls.Add(this.button_removeSchedule);
            this.groupBox_generateSchedule.Controls.Add(this.listBox_generateSchedule);
            this.groupBox_generateSchedule.Location = new System.Drawing.Point(389, 14);
            this.groupBox_generateSchedule.Name = "groupBox_generateSchedule";
            this.groupBox_generateSchedule.Size = new System.Drawing.Size(235, 397);
            this.groupBox_generateSchedule.TabIndex = 3;
            this.groupBox_generateSchedule.TabStop = false;
            this.groupBox_generateSchedule.Text = "排程設定";
            // 
            // button_addSchedule
            // 
            this.button_addSchedule.Location = new System.Drawing.Point(132, 353);
            this.button_addSchedule.Name = "button_addSchedule";
            this.button_addSchedule.Size = new System.Drawing.Size(90, 35);
            this.button_addSchedule.TabIndex = 8;
            this.button_addSchedule.Text = "加入排程";
            this.button_addSchedule.UseVisualStyleBackColor = true;
            this.button_addSchedule.Click += new System.EventHandler(this.button_addSchedule_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "頻率 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(134, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "分 : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "時 : ";
            // 
            // numericUpDown_level
            // 
            this.numericUpDown_level.Location = new System.Drawing.Point(60, 359);
            this.numericUpDown_level.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_level.Name = "numericUpDown_level";
            this.numericUpDown_level.Size = new System.Drawing.Size(43, 25);
            this.numericUpDown_level.TabIndex = 4;
            // 
            // numericUpDown_minute
            // 
            this.numericUpDown_minute.Location = new System.Drawing.Point(170, 308);
            this.numericUpDown_minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_minute.Name = "numericUpDown_minute";
            this.numericUpDown_minute.Size = new System.Drawing.Size(43, 25);
            this.numericUpDown_minute.TabIndex = 3;
            // 
            // numericUpDown_hour
            // 
            this.numericUpDown_hour.Location = new System.Drawing.Point(60, 308);
            this.numericUpDown_hour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown_hour.Name = "numericUpDown_hour";
            this.numericUpDown_hour.Size = new System.Drawing.Size(43, 25);
            this.numericUpDown_hour.TabIndex = 2;
            // 
            // button_removeSchedule
            // 
            this.button_removeSchedule.Location = new System.Drawing.Point(132, 203);
            this.button_removeSchedule.Name = "button_removeSchedule";
            this.button_removeSchedule.Size = new System.Drawing.Size(90, 35);
            this.button_removeSchedule.TabIndex = 1;
            this.button_removeSchedule.Text = "移除排程";
            this.button_removeSchedule.UseVisualStyleBackColor = true;
            this.button_removeSchedule.Click += new System.EventHandler(this.button_removeSchedule_Click);
            // 
            // listBox_generateSchedule
            // 
            this.listBox_generateSchedule.FormattingEnabled = true;
            this.listBox_generateSchedule.ItemHeight = 17;
            this.listBox_generateSchedule.Items.AddRange(new object[] {
            "no-schedule"});
            this.listBox_generateSchedule.Location = new System.Drawing.Point(17, 23);
            this.listBox_generateSchedule.Name = "listBox_generateSchedule";
            this.listBox_generateSchedule.Size = new System.Drawing.Size(205, 174);
            this.listBox_generateSchedule.TabIndex = 0;
            // 
            // VehicleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 421);
            this.Controls.Add(this.groupBox_generateSchedule);
            this.Controls.Add(this.groupBox_vehicleConfig);
            this.Controls.Add(this.groupBox_generateRoads);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VehicleConfig";
            this.Text = "VehicleGenerateConfig";
            this.groupBox_generateRoads.ResumeLayout(false);
            this.groupBox_generateRoads.PerformLayout();
            this.groupBox_vehicleConfig.ResumeLayout(false);
            this.groupBox_vehicleConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vehicleGraphicDemo)).EndInit();
            this.groupBox_generateSchedule.ResumeLayout(false);
            this.groupBox_generateSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_generateRoads;
        private System.Windows.Forms.GroupBox groupBox_generateRoads;
        private System.Windows.Forms.ComboBox comboBox_generateLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_vehicleConfig;
        private System.Windows.Forms.Button button_removeGenerateRoad;
        private System.Windows.Forms.Button button_addGenerateRoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_otherRoads;
        private System.Windows.Forms.NumericUpDown numericUpDown_CarSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox_vehicleGraphicDemo;
        private System.Windows.Forms.Button button_applyVehicleConfig;
        private System.Windows.Forms.NumericUpDown numericUpDown_CarSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox_generateSchedule;
        private System.Windows.Forms.ListBox listBox_generateSchedule;
        private System.Windows.Forms.Button button_removeSchedule;
        private System.Windows.Forms.Button button_addSchedule;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_level;
        private System.Windows.Forms.NumericUpDown numericUpDown_minute;
        private System.Windows.Forms.NumericUpDown numericUpDown_hour;
    }
}