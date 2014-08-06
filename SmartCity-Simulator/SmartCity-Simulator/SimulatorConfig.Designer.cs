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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Simulator = new System.Windows.Forms.TabPage();
            this.tabPage_Cars = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Simulator);
            this.tabControl1.Controls.Add(this.tabPage_Cars);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(714, 546);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Simulator
            // 
            this.tabPage_Simulator.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_Simulator.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage_Simulator.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Simulator.Name = "tabPage_Simulator";
            this.tabPage_Simulator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Simulator.Size = new System.Drawing.Size(706, 520);
            this.tabPage_Simulator.TabIndex = 0;
            this.tabPage_Simulator.Text = "模擬器";
            // 
            // tabPage_Cars
            // 
            this.tabPage_Cars.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage_Cars.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabPage_Cars.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Cars.Name = "tabPage_Cars";
            this.tabPage_Cars.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Cars.Size = new System.Drawing.Size(706, 520);
            this.tabPage_Cars.TabIndex = 1;
            this.tabPage_Cars.Text = "車輛";
            // 
            // SimulatorConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 546);
            this.Controls.Add(this.tabControl1);
            this.Name = "SimulatorConfig";
            this.Text = "SimulatorConfig";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Simulator;
        private System.Windows.Forms.TabPage tabPage_Cars;
    }
}