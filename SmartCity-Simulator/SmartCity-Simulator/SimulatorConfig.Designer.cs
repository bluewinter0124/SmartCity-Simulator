namespace SmartCitySimulator
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
            this.checkBox_trafficSignalGraphicOn = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_VehicleGraphicFPS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_TestMode);
            this.groupBox2.Location = new System.Drawing.Point(13, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "其他";
            // 
            // checkBox_TestMode
            // 
            this.checkBox_TestMode.AutoSize = true;
            this.checkBox_TestMode.Location = new System.Drawing.Point(11, 24);
            this.checkBox_TestMode.Name = "checkBox_TestMode";
            this.checkBox_TestMode.Size = new System.Drawing.Size(136, 21);
            this.checkBox_TestMode.TabIndex = 1;
            this.checkBox_TestMode.Text = "測試模式/測試訊息";
            this.checkBox_TestMode.UseVisualStyleBackColor = true;
            // 
            // button_Confirm
            // 
            this.button_Confirm.Location = new System.Drawing.Point(172, 238);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(100, 35);
            this.button_Confirm.TabIndex = 2;
            this.button_Confirm.Text = "確定";
            this.button_Confirm.UseVisualStyleBackColor = true;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "車輛顯示";
            // 
            // numericUpDown_VehicleGraphicFPS
            // 
            this.numericUpDown_VehicleGraphicFPS.Location = new System.Drawing.Point(126, 29);
            this.numericUpDown_VehicleGraphicFPS.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_VehicleGraphicFPS.Name = "numericUpDown_VehicleGraphicFPS";
            this.numericUpDown_VehicleGraphicFPS.Size = new System.Drawing.Size(62, 25);
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
            this.groupBox1.Controls.Add(this.checkBox_trafficSignalGraphicOn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDown_VehicleGraphicFPS);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(259, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "圖形相關";
            // 
            // checkBox_trafficSignalGraphicOn
            // 
            this.checkBox_trafficSignalGraphicOn.AutoSize = true;
            this.checkBox_trafficSignalGraphicOn.Location = new System.Drawing.Point(11, 70);
            this.checkBox_trafficSignalGraphicOn.Name = "checkBox_trafficSignalGraphicOn";
            this.checkBox_trafficSignalGraphicOn.Size = new System.Drawing.Size(118, 21);
            this.checkBox_trafficSignalGraphicOn.TabIndex = 5;
            this.checkBox_trafficSignalGraphicOn.Text = "紅綠燈倒數顯示";
            this.checkBox_trafficSignalGraphicOn.UseVisualStyleBackColor = true;
            // 
            // SimulatorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 283);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
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
        private System.Windows.Forms.CheckBox checkBox_trafficSignalGraphicOn;

    }
}