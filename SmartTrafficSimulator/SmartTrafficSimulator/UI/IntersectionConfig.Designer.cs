namespace SmartTrafficSimulator
{
    partial class IntersectionConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntersectionConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_IntersectionConfigApply = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_Intersections = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_OptimizeInterval = new System.Windows.Forms.Label();
            this.radioButton_optByTime = new System.Windows.Forms.RadioButton();
            this.radioButton_optByCycle = new System.Windows.Forms.RadioButton();
            this.numericUpDown_timeInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_IAWRThreshold = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown_cycleInterval = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_timeInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IAWRThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cycleInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button_IntersectionConfigApply);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox_Intersections);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(464, 314);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intersections";
            // 
            // button_IntersectionConfigApply
            // 
            this.button_IntersectionConfigApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_IntersectionConfigApply.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_IntersectionConfigApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_IntersectionConfigApply.FlatAppearance.BorderSize = 0;
            this.button_IntersectionConfigApply.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_IntersectionConfigApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_IntersectionConfigApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_IntersectionConfigApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_IntersectionConfigApply.Location = new System.Drawing.Point(309, 256);
            this.button_IntersectionConfigApply.Margin = new System.Windows.Forms.Padding(4);
            this.button_IntersectionConfigApply.Name = "button_IntersectionConfigApply";
            this.button_IntersectionConfigApply.Size = new System.Drawing.Size(80, 35);
            this.button_IntersectionConfigApply.TabIndex = 5;
            this.button_IntersectionConfigApply.Text = "Apply";
            this.button_IntersectionConfigApply.UseMnemonic = false;
            this.button_IntersectionConfigApply.UseVisualStyleBackColor = false;
            this.button_IntersectionConfigApply.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(330, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "Signal Config";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_Intersections
            // 
            this.comboBox_Intersections.BackColor = System.Drawing.Color.White;
            this.comboBox_Intersections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Intersections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Intersections.FormattingEnabled = true;
            this.comboBox_Intersections.Location = new System.Drawing.Point(8, 23);
            this.comboBox_Intersections.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Intersections.Name = "comboBox_Intersections";
            this.comboBox_Intersections.Size = new System.Drawing.Size(295, 25);
            this.comboBox_Intersections.TabIndex = 0;
            this.comboBox_Intersections.SelectedIndexChanged += new System.EventHandler(this.comboBox_Insections_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_OptimizeInterval);
            this.groupBox3.Controls.Add(this.radioButton_optByTime);
            this.groupBox3.Controls.Add(this.radioButton_optByCycle);
            this.groupBox3.Controls.Add(this.numericUpDown_timeInterval);
            this.groupBox3.Controls.Add(this.numericUpDown_IAWRThreshold);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.numericUpDown_cycleInterval);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(251, 61);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(200, 181);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Optimization";
            // 
            // label_OptimizeInterval
            // 
            this.label_OptimizeInterval.AutoSize = true;
            this.label_OptimizeInterval.Location = new System.Drawing.Point(102, 26);
            this.label_OptimizeInterval.Name = "label_OptimizeInterval";
            this.label_OptimizeInterval.Size = new System.Drawing.Size(16, 17);
            this.label_OptimizeInterval.TabIndex = 10;
            this.label_OptimizeInterval.Text = "1";
            // 
            // radioButton_optByTime
            // 
            this.radioButton_optByTime.AutoSize = true;
            this.radioButton_optByTime.Location = new System.Drawing.Point(10, 87);
            this.radioButton_optByTime.Name = "radioButton_optByTime";
            this.radioButton_optByTime.Size = new System.Drawing.Size(97, 21);
            this.radioButton_optByTime.TabIndex = 9;
            this.radioButton_optByTime.Text = "By Minute : ";
            this.radioButton_optByTime.UseVisualStyleBackColor = true;
            // 
            // radioButton_optByCycle
            // 
            this.radioButton_optByCycle.AutoSize = true;
            this.radioButton_optByCycle.Checked = true;
            this.radioButton_optByCycle.Location = new System.Drawing.Point(10, 55);
            this.radioButton_optByCycle.Name = "radioButton_optByCycle";
            this.radioButton_optByCycle.Size = new System.Drawing.Size(85, 21);
            this.radioButton_optByCycle.TabIndex = 8;
            this.radioButton_optByCycle.TabStop = true;
            this.radioButton_optByCycle.Text = "By Cycle : ";
            this.radioButton_optByCycle.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_timeInterval
            // 
            this.numericUpDown_timeInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_timeInterval.Location = new System.Drawing.Point(122, 86);
            this.numericUpDown_timeInterval.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_timeInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_timeInterval.Name = "numericUpDown_timeInterval";
            this.numericUpDown_timeInterval.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown_timeInterval.TabIndex = 7;
            this.numericUpDown_timeInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_IAWRThreshold
            // 
            this.numericUpDown_IAWRThreshold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_IAWRThreshold.InterceptArrowKeys = false;
            this.numericUpDown_IAWRThreshold.Location = new System.Drawing.Point(122, 139);
            this.numericUpDown_IAWRThreshold.Name = "numericUpDown_IAWRThreshold";
            this.numericUpDown_IAWRThreshold.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown_IAWRThreshold.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "IAWR Threshold : ";
            // 
            // numericUpDown_cycleInterval
            // 
            this.numericUpDown_cycleInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_cycleInterval.Location = new System.Drawing.Point(122, 55);
            this.numericUpDown_cycleInterval.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_cycleInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_cycleInterval.Name = "numericUpDown_cycleInterval";
            this.numericUpDown_cycleInterval.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown_cycleInterval.TabIndex = 1;
            this.numericUpDown_cycleInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Interval : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(8, 61);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(235, 241);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adopted Config";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.comboBox8, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox6, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox7, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 26);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(211, 204);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBox8
            // 
            this.comboBox8.BackColor = System.Drawing.Color.White;
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(160, 157);
            this.comboBox8.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(47, 25);
            this.comboBox8.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(108, 157);
            this.label8.Margin = new System.Windows.Forms.Padding(4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "road8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "road7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "road6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "road5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "road1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "road2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "road3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "road4";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.White;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(56, 55);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(44, 25);
            this.comboBox2.TabIndex = 24;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.White;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(56, 106);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(44, 25);
            this.comboBox3.TabIndex = 25;
            // 
            // comboBox4
            // 
            this.comboBox4.BackColor = System.Drawing.Color.White;
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(56, 157);
            this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(44, 25);
            this.comboBox4.TabIndex = 26;
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.Color.White;
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(160, 4);
            this.comboBox5.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(47, 25);
            this.comboBox5.TabIndex = 27;
            // 
            // comboBox6
            // 
            this.comboBox6.BackColor = System.Drawing.Color.White;
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(160, 55);
            this.comboBox6.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(47, 25);
            this.comboBox6.TabIndex = 28;
            // 
            // comboBox7
            // 
            this.comboBox7.BackColor = System.Drawing.Color.White;
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(160, 106);
            this.comboBox7.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(47, 25);
            this.comboBox7.TabIndex = 29;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 4);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(44, 25);
            this.comboBox1.TabIndex = 22;
            // 
            // IntersectionConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(495, 338);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IntersectionConfig";
            this.Text = "IntersectionConfig";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_timeInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IAWRThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cycleInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Intersections;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_IntersectionConfigApply;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBox7;
        public System.Windows.Forms.ComboBox comboBox6;
        public System.Windows.Forms.ComboBox comboBox5;
        public System.Windows.Forms.ComboBox comboBox4;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown_cycleInterval;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown_IAWRThreshold;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_timeInterval;
        private System.Windows.Forms.RadioButton radioButton_optByTime;
        private System.Windows.Forms.RadioButton radioButton_optByCycle;
        private System.Windows.Forms.Label label_OptimizeInterval;
        private System.Windows.Forms.Button button1;

    }
}