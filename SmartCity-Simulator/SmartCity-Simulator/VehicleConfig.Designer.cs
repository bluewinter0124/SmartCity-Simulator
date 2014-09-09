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
            this.comboBox_generateRoad = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_AddRoad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_OtherRoad = new System.Windows.Forms.ComboBox();
            this.button_removeRoad = new System.Windows.Forms.Button();
            this.comboBox_rate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_CarSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_CarSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_CarGraphicDemo = new System.Windows.Forms.PictureBox();
            this.button_applyConfig = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_addSchedule = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_level = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_minute = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_hour = new System.Windows.Forms.NumericUpDown();
            this.button_removeSchedule = new System.Windows.Forms.Button();
            this.listBox_generateSchedule = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CarGraphicDemo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hour)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_generateRoad
            // 
            this.comboBox_generateRoad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_generateRoad.FormattingEnabled = true;
            this.comboBox_generateRoad.Location = new System.Drawing.Point(76, 30);
            this.comboBox_generateRoad.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_generateRoad.Name = "comboBox_generateRoad";
            this.comboBox_generateRoad.Size = new System.Drawing.Size(201, 25);
            this.comboBox_generateRoad.TabIndex = 0;
            this.comboBox_generateRoad.SelectedIndexChanged += new System.EventHandler(this.comboBox_generateRoad_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_AddRoad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_OtherRoad);
            this.groupBox1.Controls.Add(this.button_removeRoad);
            this.groupBox1.Controls.Add(this.comboBox_rate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_generateRoad);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(427, 224);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "車輛產生道路";
            // 
            // button_AddRoad
            // 
            this.button_AddRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_AddRoad.Location = new System.Drawing.Point(298, 168);
            this.button_AddRoad.Margin = new System.Windows.Forms.Padding(4);
            this.button_AddRoad.Name = "button_AddRoad";
            this.button_AddRoad.Size = new System.Drawing.Size(100, 35);
            this.button_AddRoad.TabIndex = 7;
            this.button_AddRoad.Text = "新增道路";
            this.button_AddRoad.UseVisualStyleBackColor = true;
            this.button_AddRoad.Click += new System.EventHandler(this.button_AddRoad_Click);
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
            // comboBox_OtherRoad
            // 
            this.comboBox_OtherRoad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OtherRoad.FormattingEnabled = true;
            this.comboBox_OtherRoad.Location = new System.Drawing.Point(76, 174);
            this.comboBox_OtherRoad.Name = "comboBox_OtherRoad";
            this.comboBox_OtherRoad.Size = new System.Drawing.Size(202, 25);
            this.comboBox_OtherRoad.TabIndex = 5;
            // 
            // button_removeRoad
            // 
            this.button_removeRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_removeRoad.Location = new System.Drawing.Point(298, 23);
            this.button_removeRoad.Margin = new System.Windows.Forms.Padding(4);
            this.button_removeRoad.Name = "button_removeRoad";
            this.button_removeRoad.Size = new System.Drawing.Size(100, 35);
            this.button_removeRoad.TabIndex = 4;
            this.button_removeRoad.Text = "移除此道路";
            this.button_removeRoad.UseVisualStyleBackColor = true;
            this.button_removeRoad.Click += new System.EventHandler(this.button_RemoveRoad_Click);
            // 
            // comboBox_rate
            // 
            this.comboBox_rate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rate.FormattingEnabled = true;
            this.comboBox_rate.Items.AddRange(new object[] {
            "不產生",
            "非常少",
            "少",
            "普通",
            "多",
            "非常多"});
            this.comboBox_rate.Location = new System.Drawing.Point(76, 78);
            this.comboBox_rate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_rate.Name = "comboBox_rate";
            this.comboBox_rate.Size = new System.Drawing.Size(201, 25);
            this.comboBox_rate.TabIndex = 3;
            this.comboBox_rate.SelectedIndexChanged += new System.EventHandler(this.comboBox_rate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "產生頻率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "道路ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericUpDown_CarSpeed);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDown_CarSize);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pictureBox_CarGraphicDemo);
            this.groupBox2.Location = new System.Drawing.Point(13, 245);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(427, 115);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "車輛設定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "實際畫面大小";
            // 
            // numericUpDown_CarSpeed
            // 
            this.numericUpDown_CarSpeed.Location = new System.Drawing.Point(353, 71);
            this.numericUpDown_CarSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_CarSpeed.Name = "numericUpDown_CarSpeed";
            this.numericUpDown_CarSpeed.Size = new System.Drawing.Size(58, 25);
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
            this.label5.Location = new System.Drawing.Point(248, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "車輛速度(km/H)";
            // 
            // numericUpDown_CarSize
            // 
            this.numericUpDown_CarSize.Location = new System.Drawing.Point(353, 26);
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
            this.numericUpDown_CarSize.Size = new System.Drawing.Size(58, 25);
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
            this.label4.Location = new System.Drawing.Point(248, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "車輛大小";
            // 
            // pictureBox_CarGraphicDemo
            // 
            this.pictureBox_CarGraphicDemo.Image = global::SmartCitySimulator.Properties.Resources.car0;
            this.pictureBox_CarGraphicDemo.Location = new System.Drawing.Point(14, 25);
            this.pictureBox_CarGraphicDemo.Name = "pictureBox_CarGraphicDemo";
            this.pictureBox_CarGraphicDemo.Size = new System.Drawing.Size(24, 12);
            this.pictureBox_CarGraphicDemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CarGraphicDemo.TabIndex = 0;
            this.pictureBox_CarGraphicDemo.TabStop = false;
            // 
            // button_applyConfig
            // 
            this.button_applyConfig.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_applyConfig.Location = new System.Drawing.Point(570, 367);
            this.button_applyConfig.Margin = new System.Windows.Forms.Padding(4);
            this.button_applyConfig.Name = "button_applyConfig";
            this.button_applyConfig.Size = new System.Drawing.Size(100, 35);
            this.button_applyConfig.TabIndex = 8;
            this.button_applyConfig.Text = "套用設定";
            this.button_applyConfig.UseVisualStyleBackColor = true;
            this.button_applyConfig.Click += new System.EventHandler(this.button_applyConfig_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_addSchedule);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDown_level);
            this.groupBox3.Controls.Add(this.numericUpDown_minute);
            this.groupBox3.Controls.Add(this.numericUpDown_hour);
            this.groupBox3.Controls.Add(this.button_removeSchedule);
            this.groupBox3.Controls.Add(this.listBox_generateSchedule);
            this.groupBox3.Location = new System.Drawing.Point(448, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 347);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "排程設定";
            // 
            // button_addSchedule
            // 
            this.button_addSchedule.Location = new System.Drawing.Point(122, 290);
            this.button_addSchedule.Name = "button_addSchedule";
            this.button_addSchedule.Size = new System.Drawing.Size(100, 35);
            this.button_addSchedule.TabIndex = 8;
            this.button_addSchedule.Text = "加入排程";
            this.button_addSchedule.UseVisualStyleBackColor = true;
            this.button_addSchedule.Click += new System.EventHandler(this.button_addSchedule_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "頻率 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(143, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "分 : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "時 : ";
            // 
            // numericUpDown_level
            // 
            this.numericUpDown_level.Location = new System.Drawing.Point(57, 297);
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
            this.numericUpDown_minute.Location = new System.Drawing.Point(179, 239);
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
            this.numericUpDown_hour.Location = new System.Drawing.Point(57, 239);
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
            this.button_removeSchedule.Location = new System.Drawing.Point(122, 189);
            this.button_removeSchedule.Name = "button_removeSchedule";
            this.button_removeSchedule.Size = new System.Drawing.Size(100, 35);
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
            this.listBox_generateSchedule.Size = new System.Drawing.Size(205, 157);
            this.listBox_generateSchedule.TabIndex = 0;
            // 
            // VehicleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 412);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_applyConfig);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VehicleConfig";
            this.Text = "CarGenerateConfig";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CarGraphicDemo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_generateRoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_rate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_removeRoad;
        private System.Windows.Forms.Button button_AddRoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_OtherRoad;
        private System.Windows.Forms.NumericUpDown numericUpDown_CarSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox_CarGraphicDemo;
        private System.Windows.Forms.Button button_applyConfig;
        private System.Windows.Forms.NumericUpDown numericUpDown_CarSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
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