namespace SmartCitySimulator
{
    partial class CarConfig
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
            this.button_RemoveRoad = new System.Windows.Forms.Button();
            this.comboBox_rate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_CarSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button_apply = new System.Windows.Forms.Button();
            this.numericUpDown_CarSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_CarGraphicDemo = new System.Windows.Forms.PictureBox();
            this.button_GenerateSchedule = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CarGraphicDemo)).BeginInit();
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
            this.groupBox1.Controls.Add(this.button_GenerateSchedule);
            this.groupBox1.Controls.Add(this.button_AddRoad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_OtherRoad);
            this.groupBox1.Controls.Add(this.button_RemoveRoad);
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
            this.button_AddRoad.Location = new System.Drawing.Point(298, 171);
            this.button_AddRoad.Margin = new System.Windows.Forms.Padding(4);
            this.button_AddRoad.Name = "button_AddRoad";
            this.button_AddRoad.Size = new System.Drawing.Size(96, 29);
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
            // button_RemoveRoad
            // 
            this.button_RemoveRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_RemoveRoad.Location = new System.Drawing.Point(298, 26);
            this.button_RemoveRoad.Margin = new System.Windows.Forms.Padding(4);
            this.button_RemoveRoad.Name = "button_RemoveRoad";
            this.button_RemoveRoad.Size = new System.Drawing.Size(96, 29);
            this.button_RemoveRoad.TabIndex = 4;
            this.button_RemoveRoad.Text = "移除此道路";
            this.button_RemoveRoad.UseVisualStyleBackColor = true;
            this.button_RemoveRoad.Click += new System.EventHandler(this.button_RemoveRoad_Click);
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
            this.groupBox2.Controls.Add(this.button_apply);
            this.groupBox2.Controls.Add(this.numericUpDown_CarSize);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.pictureBox_CarGraphicDemo);
            this.groupBox2.Location = new System.Drawing.Point(13, 245);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(427, 170);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "車輛設定";
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
            // button_apply
            // 
            this.button_apply.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_apply.Location = new System.Drawing.Point(315, 122);
            this.button_apply.Margin = new System.Windows.Forms.Padding(4);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(96, 29);
            this.button_apply.TabIndex = 8;
            this.button_apply.Text = "套用設定";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
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
            // button_GenerateSchedule
            // 
            this.button_GenerateSchedule.Location = new System.Drawing.Point(298, 75);
            this.button_GenerateSchedule.Name = "button_GenerateSchedule";
            this.button_GenerateSchedule.Size = new System.Drawing.Size(96, 29);
            this.button_GenerateSchedule.TabIndex = 8;
            this.button_GenerateSchedule.Text = "排程設定";
            this.button_GenerateSchedule.UseVisualStyleBackColor = true;
            this.button_GenerateSchedule.Click += new System.EventHandler(this.button1_Click);
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
            // CarConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 424);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CarConfig";
            this.Text = "CarGenerateModify";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CarSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CarGraphicDemo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_generateRoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_rate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_RemoveRoad;
        private System.Windows.Forms.Button button_AddRoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_OtherRoad;
        private System.Windows.Forms.NumericUpDown numericUpDown_CarSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox_CarGraphicDemo;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.NumericUpDown numericUpDown_CarSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_GenerateSchedule;
        private System.Windows.Forms.Label label6;
    }
}