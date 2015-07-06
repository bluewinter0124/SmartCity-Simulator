namespace SmartTrafficSimulator.OptimizationModels
{
    partial class AIConfig
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
            this.comboBox_optimizationMethod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_adaptiveAdjustment = new System.Windows.Forms.CheckBox();
            this.checkBox_threshold = new System.Windows.Forms.CheckBox();
            this.checkBox_interval = new System.Windows.Forms.CheckBox();
            this.button_testMode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_trafficVolumePredection = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_optimizationMethod
            // 
            this.comboBox_optimizationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_optimizationMethod.FormattingEnabled = true;
            this.comboBox_optimizationMethod.Location = new System.Drawing.Point(160, 17);
            this.comboBox_optimizationMethod.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_optimizationMethod.Name = "comboBox_optimizationMethod";
            this.comboBox_optimizationMethod.Size = new System.Drawing.Size(183, 25);
            this.comboBox_optimizationMethod.TabIndex = 0;
            this.comboBox_optimizationMethod.SelectedIndexChanged += new System.EventHandler(this.comboBox_optimizationMethod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Optimization Method";
            // 
            // checkBox_adaptiveAdjustment
            // 
            this.checkBox_adaptiveAdjustment.AutoSize = true;
            this.checkBox_adaptiveAdjustment.Location = new System.Drawing.Point(6, 24);
            this.checkBox_adaptiveAdjustment.Name = "checkBox_adaptiveAdjustment";
            this.checkBox_adaptiveAdjustment.Size = new System.Drawing.Size(155, 21);
            this.checkBox_adaptiveAdjustment.TabIndex = 2;
            this.checkBox_adaptiveAdjustment.Text = "Adaptive Adjustment";
            this.checkBox_adaptiveAdjustment.UseVisualStyleBackColor = true;
            this.checkBox_adaptiveAdjustment.CheckedChanged += new System.EventHandler(this.checkBox_adaptiveAdjustment_CheckedChanged);
            // 
            // checkBox_threshold
            // 
            this.checkBox_threshold.AutoSize = true;
            this.checkBox_threshold.Location = new System.Drawing.Point(6, 52);
            this.checkBox_threshold.Name = "checkBox_threshold";
            this.checkBox_threshold.Size = new System.Drawing.Size(87, 21);
            this.checkBox_threshold.TabIndex = 3;
            this.checkBox_threshold.Text = "Threshold";
            this.checkBox_threshold.UseVisualStyleBackColor = true;
            this.checkBox_threshold.CheckedChanged += new System.EventHandler(this.checkBox_threshold_CheckedChanged);
            // 
            // checkBox_interval
            // 
            this.checkBox_interval.AutoSize = true;
            this.checkBox_interval.Location = new System.Drawing.Point(6, 79);
            this.checkBox_interval.Name = "checkBox_interval";
            this.checkBox_interval.Size = new System.Drawing.Size(73, 21);
            this.checkBox_interval.TabIndex = 4;
            this.checkBox_interval.Text = "Interval";
            this.checkBox_interval.UseVisualStyleBackColor = true;
            this.checkBox_interval.CheckedChanged += new System.EventHandler(this.checkBox_interval_CheckedChanged);
            // 
            // button_testMode
            // 
            this.button_testMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_testMode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_testMode.FlatAppearance.BorderSize = 0;
            this.button_testMode.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_testMode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_testMode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_testMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_testMode.Location = new System.Drawing.Point(378, 11);
            this.button_testMode.Margin = new System.Windows.Forms.Padding(4);
            this.button_testMode.Name = "button_testMode";
            this.button_testMode.Size = new System.Drawing.Size(80, 35);
            this.button_testMode.TabIndex = 20;
            this.button_testMode.Text = "Test";
            this.button_testMode.UseVisualStyleBackColor = false;
            this.button_testMode.Click += new System.EventHandler(this.button_testMode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_adaptiveAdjustment);
            this.groupBox1.Controls.Add(this.checkBox_threshold);
            this.groupBox1.Controls.Add(this.checkBox_interval);
            this.groupBox1.Location = new System.Drawing.Point(16, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 119);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intersection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_trafficVolumePredection);
            this.groupBox2.Location = new System.Drawing.Point(243, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 118);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Traffic Volume";
            // 
            // checkBox_trafficVolumePredection
            // 
            this.checkBox_trafficVolumePredection.AutoSize = true;
            this.checkBox_trafficVolumePredection.Location = new System.Drawing.Point(7, 23);
            this.checkBox_trafficVolumePredection.Name = "checkBox_trafficVolumePredection";
            this.checkBox_trafficVolumePredection.Size = new System.Drawing.Size(181, 21);
            this.checkBox_trafficVolumePredection.TabIndex = 0;
            this.checkBox_trafficVolumePredection.Text = "Traffic Volume Predection";
            this.checkBox_trafficVolumePredection.UseVisualStyleBackColor = true;
            this.checkBox_trafficVolumePredection.CheckedChanged += new System.EventHandler(this.checkBox_trafficVolumePredection_CheckedChanged);
            // 
            // AIConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 306);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_testMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_optimizationMethod);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AIConfig";
            this.Text = "AIConfig";
            this.Load += new System.EventHandler(this.AIConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_optimizationMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_adaptiveAdjustment;
        private System.Windows.Forms.CheckBox checkBox_threshold;
        private System.Windows.Forms.CheckBox checkBox_interval;
        private System.Windows.Forms.Button button_testMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_trafficVolumePredection;
    }
}