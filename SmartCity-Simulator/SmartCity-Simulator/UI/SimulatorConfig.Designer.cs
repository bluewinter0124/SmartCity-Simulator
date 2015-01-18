﻿namespace SmartCitySimulator
{
    partial class SimulatorConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulatorConfig));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_TestMode = new System.Windows.Forms.CheckBox();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_VehicleGraphicFPS = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_roadStateMark = new System.Windows.Forms.CheckBox();
            this.checkBox_intersectionInformationUpdate = new System.Windows.Forms.CheckBox();
            this.checkBox_trafficSignalCountdownDisplay = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_VehicleGraphicFPS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_TestMode);
            this.groupBox2.Location = new System.Drawing.Point(13, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Simulator";
            // 
            // checkBox_TestMode
            // 
            this.checkBox_TestMode.AutoSize = true;
            this.checkBox_TestMode.Location = new System.Drawing.Point(11, 24);
            this.checkBox_TestMode.Name = "checkBox_TestMode";
            this.checkBox_TestMode.Size = new System.Drawing.Size(191, 21);
            this.checkBox_TestMode.TabIndex = 1;
            this.checkBox_TestMode.Text = "Test Mode(Detail Message)";
            this.checkBox_TestMode.UseVisualStyleBackColor = true;
            // 
            // button_Confirm
            // 
            this.button_Confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_Confirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_Confirm.FlatAppearance.BorderSize = 0;
            this.button_Confirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_Confirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Confirm.Location = new System.Drawing.Point(172, 281);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(100, 35);
            this.button_Confirm.TabIndex = 2;
            this.button_Confirm.Text = "Confirm";
            this.button_Confirm.UseVisualStyleBackColor = false;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vehicle";
            // 
            // numericUpDown_VehicleGraphicFPS
            // 
            this.numericUpDown_VehicleGraphicFPS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_VehicleGraphicFPS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_VehicleGraphicFPS.Location = new System.Drawing.Point(126, 29);
            this.numericUpDown_VehicleGraphicFPS.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_VehicleGraphicFPS.Name = "numericUpDown_VehicleGraphicFPS";
            this.numericUpDown_VehicleGraphicFPS.Size = new System.Drawing.Size(62, 21);
            this.numericUpDown_VehicleGraphicFPS.TabIndex = 1;
            this.numericUpDown_VehicleGraphicFPS.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_VehicleGraphicFPS.ValueChanged += new System.EventHandler(this.numericUpDown_VehicleGraphicFPS_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "FPS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_roadStateMark);
            this.groupBox1.Controls.Add(this.checkBox_intersectionInformationUpdate);
            this.groupBox1.Controls.Add(this.checkBox_trafficSignalCountdownDisplay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown_VehicleGraphicFPS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(259, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Graphic Display Config";
            // 
            // checkBox_roadStateMark
            // 
            this.checkBox_roadStateMark.AutoSize = true;
            this.checkBox_roadStateMark.Location = new System.Drawing.Point(11, 124);
            this.checkBox_roadStateMark.Name = "checkBox_roadStateMark";
            this.checkBox_roadStateMark.Size = new System.Drawing.Size(127, 21);
            this.checkBox_roadStateMark.TabIndex = 7;
            this.checkBox_roadStateMark.Text = "Road State Mark";
            this.checkBox_roadStateMark.UseVisualStyleBackColor = true;
            // 
            // checkBox_intersectionInformationUpdate
            // 
            this.checkBox_intersectionInformationUpdate.AutoSize = true;
            this.checkBox_intersectionInformationUpdate.Location = new System.Drawing.Point(11, 97);
            this.checkBox_intersectionInformationUpdate.Name = "checkBox_intersectionInformationUpdate";
            this.checkBox_intersectionInformationUpdate.Size = new System.Drawing.Size(222, 21);
            this.checkBox_intersectionInformationUpdate.TabIndex = 6;
            this.checkBox_intersectionInformationUpdate.Text = "Intersection Information Update";
            this.checkBox_intersectionInformationUpdate.UseVisualStyleBackColor = true;
            // 
            // checkBox_trafficSignalCountdownDisplay
            // 
            this.checkBox_trafficSignalCountdownDisplay.AutoSize = true;
            this.checkBox_trafficSignalCountdownDisplay.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_trafficSignalCountdownDisplay.Location = new System.Drawing.Point(11, 70);
            this.checkBox_trafficSignalCountdownDisplay.Name = "checkBox_trafficSignalCountdownDisplay";
            this.checkBox_trafficSignalCountdownDisplay.Size = new System.Drawing.Size(185, 21);
            this.checkBox_trafficSignalCountdownDisplay.TabIndex = 5;
            this.checkBox_trafficSignalCountdownDisplay.Text = "Signal Countdown Display";
            this.checkBox_trafficSignalCountdownDisplay.UseVisualStyleBackColor = false;
            // 
            // SimulatorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(282, 326);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SimulatorConfig";
            this.Text = "SimulatorConfig";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_VehicleGraphicFPS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_TestMode;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_VehicleGraphicFPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_trafficSignalCountdownDisplay;
        private System.Windows.Forms.CheckBox checkBox_roadStateMark;
        private System.Windows.Forms.CheckBox checkBox_intersectionInformationUpdate;

    }
}