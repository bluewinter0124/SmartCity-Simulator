﻿namespace SmartCitySimulator
{
    partial class TrafficLightConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Intersections = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown_order_4_yellow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_order_4_green = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_order_3_yellow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_order_3_green = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_order_2_yellow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_order_2_green = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_order_1_yellow = new System.Windows.Forms.NumericUpDown();
            this.label_order2 = new System.Windows.Forms.Label();
            this.label_order3 = new System.Windows.Forms.Label();
            this.label_order4 = new System.Windows.Forms.Label();
            this.label_order1 = new System.Windows.Forms.Label();
            this.numericUpDown_order_1_green = new System.Windows.Forms.NumericUpDown();
            this.button_order_1_delete = new System.Windows.Forms.Button();
            this.button_order_2_delete = new System.Windows.Forms.Button();
            this.button_order_3_delete = new System.Windows.Forms.Button();
            this.button_order_4_delete = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_addNewSetting = new System.Windows.Forms.Button();
            this.numericUpDown_newYellow = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_newGreen = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button_change = new System.Windows.Forms.Button();
            this.button_confirm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_4_yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_4_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_3_yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_3_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_2_yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_2_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_1_yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_1_green)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_newYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_newGreen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Intersections);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(16, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(472, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "路口";
            // 
            // comboBox_Intersections
            // 
            this.comboBox_Intersections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Intersections.FormattingEnabled = true;
            this.comboBox_Intersections.Location = new System.Drawing.Point(9, 20);
            this.comboBox_Intersections.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_Intersections.Name = "comboBox_Intersections";
            this.comboBox_Intersections.Size = new System.Drawing.Size(455, 25);
            this.comboBox_Intersections.TabIndex = 0;
            this.comboBox_Intersections.SelectedIndexChanged += new System.EventHandler(this.comboBox_Insections_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(16, 71);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(472, 233);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "秒數設置";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_order_4_yellow, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_order_4_green, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_order_3_yellow, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_order_3_green, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_order_2_yellow, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_order_2_delete, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_order_2_green, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_order_1_yellow, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_order2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_order3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_order4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_order_1_green, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_order1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_order_4_delete, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_order_1_delete, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_order_3_delete, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 189);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericUpDown_order_4_yellow
            // 
            this.numericUpDown_order_4_yellow.Location = new System.Drawing.Point(216, 145);
            this.numericUpDown_order_4_yellow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_order_4_yellow.Name = "numericUpDown_order_4_yellow";
            this.numericUpDown_order_4_yellow.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown_order_4_yellow.TabIndex = 18;
            this.numericUpDown_order_4_yellow.Visible = false;
            // 
            // numericUpDown_order_4_green
            // 
            this.numericUpDown_order_4_green.Location = new System.Drawing.Point(95, 145);
            this.numericUpDown_order_4_green.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_order_4_green.Name = "numericUpDown_order_4_green";
            this.numericUpDown_order_4_green.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown_order_4_green.TabIndex = 17;
            this.numericUpDown_order_4_green.Visible = false;
            // 
            // numericUpDown_order_3_yellow
            // 
            this.numericUpDown_order_3_yellow.Location = new System.Drawing.Point(216, 98);
            this.numericUpDown_order_3_yellow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_order_3_yellow.Name = "numericUpDown_order_3_yellow";
            this.numericUpDown_order_3_yellow.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown_order_3_yellow.TabIndex = 15;
            this.numericUpDown_order_3_yellow.Visible = false;
            // 
            // numericUpDown_order_3_green
            // 
            this.numericUpDown_order_3_green.Location = new System.Drawing.Point(95, 98);
            this.numericUpDown_order_3_green.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_order_3_green.Name = "numericUpDown_order_3_green";
            this.numericUpDown_order_3_green.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown_order_3_green.TabIndex = 14;
            this.numericUpDown_order_3_green.Visible = false;
            // 
            // numericUpDown_order_2_yellow
            // 
            this.numericUpDown_order_2_yellow.Location = new System.Drawing.Point(216, 51);
            this.numericUpDown_order_2_yellow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_order_2_yellow.Name = "numericUpDown_order_2_yellow";
            this.numericUpDown_order_2_yellow.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown_order_2_yellow.TabIndex = 12;
            this.numericUpDown_order_2_yellow.Visible = false;
            // 
            // numericUpDown_order_2_green
            // 
            this.numericUpDown_order_2_green.Location = new System.Drawing.Point(95, 51);
            this.numericUpDown_order_2_green.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_order_2_green.Name = "numericUpDown_order_2_green";
            this.numericUpDown_order_2_green.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown_order_2_green.TabIndex = 11;
            this.numericUpDown_order_2_green.Visible = false;
            // 
            // numericUpDown_order_1_yellow
            // 
            this.numericUpDown_order_1_yellow.Location = new System.Drawing.Point(216, 4);
            this.numericUpDown_order_1_yellow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_order_1_yellow.Name = "numericUpDown_order_1_yellow";
            this.numericUpDown_order_1_yellow.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown_order_1_yellow.TabIndex = 9;
            this.numericUpDown_order_1_yellow.Visible = false;
            // 
            // label_order2
            // 
            this.label_order2.AutoSize = true;
            this.label_order2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_order2.Location = new System.Drawing.Point(4, 51);
            this.label_order2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label_order2.Name = "label_order2";
            this.label_order2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label_order2.Size = new System.Drawing.Size(63, 26);
            this.label_order2.TabIndex = 5;
            this.label_order2.Text = "順序 : 2";
            this.label_order2.Visible = false;
            // 
            // label_order3
            // 
            this.label_order3.AutoSize = true;
            this.label_order3.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_order3.Location = new System.Drawing.Point(4, 98);
            this.label_order3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label_order3.Name = "label_order3";
            this.label_order3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label_order3.Size = new System.Drawing.Size(63, 26);
            this.label_order3.TabIndex = 6;
            this.label_order3.Text = "順序 : 3";
            this.label_order3.Visible = false;
            // 
            // label_order4
            // 
            this.label_order4.AutoSize = true;
            this.label_order4.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_order4.Location = new System.Drawing.Point(4, 145);
            this.label_order4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label_order4.Name = "label_order4";
            this.label_order4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label_order4.Size = new System.Drawing.Size(63, 26);
            this.label_order4.TabIndex = 7;
            this.label_order4.Text = "順序 : 4";
            this.label_order4.Visible = false;
            // 
            // label_order1
            // 
            this.label_order1.AutoSize = true;
            this.label_order1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_order1.Location = new System.Drawing.Point(4, 4);
            this.label_order1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.label_order1.Name = "label_order1";
            this.label_order1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.label_order1.Size = new System.Drawing.Size(63, 26);
            this.label_order1.TabIndex = 4;
            this.label_order1.Text = "順序 : 1";
            this.label_order1.Visible = false;
            // 
            // numericUpDown_order_1_green
            // 
            this.numericUpDown_order_1_green.Location = new System.Drawing.Point(95, 4);
            this.numericUpDown_order_1_green.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_order_1_green.Name = "numericUpDown_order_1_green";
            this.numericUpDown_order_1_green.Size = new System.Drawing.Size(83, 25);
            this.numericUpDown_order_1_green.TabIndex = 8;
            this.numericUpDown_order_1_green.Visible = false;
            // 
            // button_order_1_delete
            // 
            this.button_order_1_delete.Location = new System.Drawing.Point(337, 4);
            this.button_order_1_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_order_1_delete.Name = "button_order_1_delete";
            this.button_order_1_delete.Size = new System.Drawing.Size(100, 35);
            this.button_order_1_delete.TabIndex = 0;
            this.button_order_1_delete.Text = "刪除";
            this.button_order_1_delete.UseVisualStyleBackColor = true;
            this.button_order_1_delete.Visible = false;
            this.button_order_1_delete.Click += new System.EventHandler(this.button_order_1_delete_Click);
            // 
            // button_order_2_delete
            // 
            this.button_order_2_delete.Location = new System.Drawing.Point(337, 51);
            this.button_order_2_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_order_2_delete.Name = "button_order_2_delete";
            this.button_order_2_delete.Size = new System.Drawing.Size(100, 35);
            this.button_order_2_delete.TabIndex = 1;
            this.button_order_2_delete.Text = "刪除";
            this.button_order_2_delete.UseVisualStyleBackColor = true;
            this.button_order_2_delete.Visible = false;
            this.button_order_2_delete.Click += new System.EventHandler(this.button_order_2_delete_Click);
            // 
            // button_order_3_delete
            // 
            this.button_order_3_delete.Location = new System.Drawing.Point(337, 98);
            this.button_order_3_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_order_3_delete.Name = "button_order_3_delete";
            this.button_order_3_delete.Size = new System.Drawing.Size(100, 35);
            this.button_order_3_delete.TabIndex = 2;
            this.button_order_3_delete.Text = "刪除";
            this.button_order_3_delete.UseVisualStyleBackColor = true;
            this.button_order_3_delete.Visible = false;
            this.button_order_3_delete.Click += new System.EventHandler(this.button_order_3_delete_Click);
            // 
            // button_order_4_delete
            // 
            this.button_order_4_delete.Location = new System.Drawing.Point(337, 145);
            this.button_order_4_delete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_order_4_delete.Name = "button_order_4_delete";
            this.button_order_4_delete.Size = new System.Drawing.Size(100, 35);
            this.button_order_4_delete.TabIndex = 3;
            this.button_order_4_delete.Text = "刪除";
            this.button_order_4_delete.UseVisualStyleBackColor = true;
            this.button_order_4_delete.Visible = false;
            this.button_order_4_delete.Click += new System.EventHandler(this.button_order_4_delete_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_addNewSetting);
            this.groupBox3.Controls.Add(this.numericUpDown_newYellow);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numericUpDown_newGreen);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(16, 312);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(472, 61);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "新增";
            // 
            // button_addNewSetting
            // 
            this.button_addNewSetting.Location = new System.Drawing.Point(346, 18);
            this.button_addNewSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_addNewSetting.Name = "button_addNewSetting";
            this.button_addNewSetting.Size = new System.Drawing.Size(100, 35);
            this.button_addNewSetting.TabIndex = 19;
            this.button_addNewSetting.Text = "新增";
            this.button_addNewSetting.UseVisualStyleBackColor = true;
            this.button_addNewSetting.Click += new System.EventHandler(this.button_addNewSetting_Click);
            // 
            // numericUpDown_newYellow
            // 
            this.numericUpDown_newYellow.Location = new System.Drawing.Point(239, 22);
            this.numericUpDown_newYellow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_newYellow.Name = "numericUpDown_newYellow";
            this.numericUpDown_newYellow.Size = new System.Drawing.Size(92, 25);
            this.numericUpDown_newYellow.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "黃燈 : ";
            // 
            // numericUpDown_newGreen
            // 
            this.numericUpDown_newGreen.Location = new System.Drawing.Point(59, 20);
            this.numericUpDown_newGreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_newGreen.Name = "numericUpDown_newGreen";
            this.numericUpDown_newGreen.Size = new System.Drawing.Size(92, 25);
            this.numericUpDown_newGreen.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "綠燈 : ";
            // 
            // button_change
            // 
            this.button_change.Location = new System.Drawing.Point(16, 394);
            this.button_change.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(100, 35);
            this.button_change.TabIndex = 3;
            this.button_change.Text = "路口設置";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_confirm
            // 
            this.button_confirm.Location = new System.Drawing.Point(388, 394);
            this.button_confirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(100, 35);
            this.button_confirm.TabIndex = 4;
            this.button_confirm.Text = "套用";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // TrafficLightConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 441);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TrafficLightConfig";
            this.Text = "TrafficSignalConfig";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_4_yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_4_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_3_yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_3_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_2_yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_2_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_1_yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_order_1_green)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_newYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_newGreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Intersections;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericUpDown_order_4_yellow;
        private System.Windows.Forms.NumericUpDown numericUpDown_order_4_green;
        private System.Windows.Forms.NumericUpDown numericUpDown_order_3_yellow;
        private System.Windows.Forms.NumericUpDown numericUpDown_order_3_green;
        private System.Windows.Forms.NumericUpDown numericUpDown_order_2_yellow;
        private System.Windows.Forms.NumericUpDown numericUpDown_order_2_green;
        private System.Windows.Forms.NumericUpDown numericUpDown_order_1_yellow;
        private System.Windows.Forms.Label label_order2;
        private System.Windows.Forms.Label label_order3;
        private System.Windows.Forms.Label label_order4;
        private System.Windows.Forms.Label label_order1;
        private System.Windows.Forms.NumericUpDown numericUpDown_order_1_green;
        private System.Windows.Forms.Button button_order_1_delete;
        private System.Windows.Forms.Button button_order_2_delete;
        private System.Windows.Forms.Button button_order_3_delete;
        private System.Windows.Forms.Button button_order_4_delete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_addNewSetting;
        private System.Windows.Forms.NumericUpDown numericUpDown_newYellow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_newGreen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_change;
        private System.Windows.Forms.Button button_confirm;
    }
}