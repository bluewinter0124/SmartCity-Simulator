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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vehicleData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_vehicleData);
            this.panel1.Location = new System.Drawing.Point(12, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 392);
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
            this.dataGridView_vehicleData.Size = new System.Drawing.Size(868, 392);
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
            // VehicleDataDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 732);
            this.Controls.Add(this.panel1);
            this.Name = "VehicleDataDisplay";
            this.Text = "VehicleDataDisplay";
            this.Load += new System.EventHandler(this.VehicleDataDisplay_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_vehicleData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_vehicleData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn TravelTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn travelSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelayTime;
    }
}