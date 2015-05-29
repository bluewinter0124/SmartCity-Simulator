namespace SmartTrafficSimulator.UI
{
    partial class VehicleDataDisplay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_vehicleData = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TravelTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.travelSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelayTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_refresh = new System.Windows.Forms.Button();
            this.numericUpDown_displayInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_totalVehicle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vehicleData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_displayInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_vehicleData);
            this.panel1.Location = new System.Drawing.Point(12, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 444);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView_vehicleData
            // 
            this.dataGridView_vehicleData.AllowUserToAddRows = false;
            this.dataGridView_vehicleData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_vehicleData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_vehicleData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_vehicleData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_vehicleData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView_vehicleData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_vehicleData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_vehicleData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_vehicleData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.TravelTime,
            this.travelSpeed,
            this.DelayTime});
            this.dataGridView_vehicleData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_vehicleData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_vehicleData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_vehicleData.Name = "dataGridView_vehicleData";
            this.dataGridView_vehicleData.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_vehicleData.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_vehicleData.RowTemplate.Height = 24;
            this.dataGridView_vehicleData.Size = new System.Drawing.Size(868, 444);
            this.dataGridView_vehicleData.TabIndex = 1;
            // 
            // Time
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Time.DefaultCellStyle = dataGridViewCellStyle3;
            this.Time.FillWeight = 40F;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TravelTime
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.TravelTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.TravelTime.FillWeight = 20F;
            this.TravelTime.HeaderText = "Travel Time";
            this.TravelTime.Name = "TravelTime";
            this.TravelTime.ReadOnly = true;
            // 
            // travelSpeed
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.travelSpeed.DefaultCellStyle = dataGridViewCellStyle5;
            this.travelSpeed.FillWeight = 20F;
            this.travelSpeed.HeaderText = "Travel Speed";
            this.travelSpeed.Name = "travelSpeed";
            this.travelSpeed.ReadOnly = true;
            // 
            // DelayTime
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DelayTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.DelayTime.FillWeight = 20F;
            this.DelayTime.HeaderText = "Delay Time";
            this.DelayTime.Name = "DelayTime";
            this.DelayTime.ReadOnly = true;
            // 
            // button_refresh
            // 
            this.button_refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_refresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.button_refresh.FlatAppearance.BorderSize = 0;
            this.button_refresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_refresh.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_refresh.Location = new System.Drawing.Point(754, 13);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(126, 35);
            this.button_refresh.TabIndex = 5;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = false;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // numericUpDown_displayInterval
            // 
            this.numericUpDown_displayInterval.BackColor = System.Drawing.Color.White;
            this.numericUpDown_displayInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_displayInterval.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_displayInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_displayInterval.Location = new System.Drawing.Point(140, 21);
            this.numericUpDown_displayInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_displayInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_displayInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_displayInterval.Name = "numericUpDown_displayInterval";
            this.numericUpDown_displayInterval.Size = new System.Drawing.Size(61, 21);
            this.numericUpDown_displayInterval.TabIndex = 14;
            this.numericUpDown_displayInterval.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_displayInterval.ValueChanged += new System.EventHandler(this.numericUpDown_displayInterval_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Display Interval : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label1.Location = new System.Drawing.Point(207, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Total Vehicle : ";
            // 
            // label_totalVehicle
            // 
            this.label_totalVehicle.AutoSize = true;
            this.label_totalVehicle.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_totalVehicle.Location = new System.Drawing.Point(120, 62);
            this.label_totalVehicle.Name = "label_totalVehicle";
            this.label_totalVehicle.Size = new System.Drawing.Size(14, 18);
            this.label_totalVehicle.TabIndex = 18;
            this.label_totalVehicle.Text = "-";
            // 
            // VehicleDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 568);
            this.Controls.Add(this.label_totalVehicle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_displayInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.panel1);
            this.Name = "VehicleDataDisplay";
            this.Text = "VehicleDataDisplay";
            this.Load += new System.EventHandler(this.VehicleDataDisplay_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vehicleData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_displayInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_vehicleData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn TravelTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn travelSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayTime;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.NumericUpDown numericUpDown_displayInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_totalVehicle;
    }
}