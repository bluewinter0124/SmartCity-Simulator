namespace SmartCitySimulator
{
    partial class IntersectionData
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
            this.dataGridView_RoadData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Intersections = new System.Windows.Forms.ComboBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.dataGridView_singleRoadData = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Road = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_IAWT = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_2 = new System.Windows.Forms.Label();
            this.numericUpDown_startPeriod = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label_endPeriod = new System.Windows.Forms.Label();
            this.numericUpDown_endPeriod = new System.Windows.Forms.NumericUpDown();
            this.Road = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AveragePassedCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaittingCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageCarWaittingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AverageWaittingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enterCars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassedCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaittingCar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarWaittingRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalWaittingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_pa = new System.Windows.Forms.Label();
            this.label_AWR = new System.Windows.Forms.Label();
            this.label_sec = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadData)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_singleRoadData)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_RoadData
            // 
            this.dataGridView_RoadData.AllowUserToAddRows = false;
            this.dataGridView_RoadData.AllowUserToDeleteRows = false;
            this.dataGridView_RoadData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_RoadData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_RoadData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RoadData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Road,
            this.AveragePassedCar,
            this.AverageWaittingCar,
            this.AverageCarWaittingRate,
            this.AverageWaittingTime});
            this.dataGridView_RoadData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_RoadData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_RoadData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_RoadData.Name = "dataGridView_RoadData";
            this.dataGridView_RoadData.ReadOnly = true;
            this.dataGridView_RoadData.RowTemplate.Height = 24;
            this.dataGridView_RoadData.Size = new System.Drawing.Size(726, 201);
            this.dataGridView_RoadData.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_RoadData);
            this.panel1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.panel1.Location = new System.Drawing.Point(15, 134);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(726, 201);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Intersections);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(329, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選擇路口";
            // 
            // comboBox_Intersections
            // 
            this.comboBox_Intersections.FormattingEnabled = true;
            this.comboBox_Intersections.Location = new System.Drawing.Point(8, 17);
            this.comboBox_Intersections.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Intersections.Name = "comboBox_Intersections";
            this.comboBox_Intersections.Size = new System.Drawing.Size(313, 25);
            this.comboBox_Intersections.TabIndex = 0;
            this.comboBox_Intersections.SelectedIndexChanged += new System.EventHandler(this.comboBox_Intersections_SelectedIndexChanged);
            // 
            // button_refresh
            // 
            this.button_refresh.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.button_refresh.Location = new System.Drawing.Point(647, 25);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(94, 87);
            this.button_refresh.TabIndex = 4;
            this.button_refresh.Text = "更新";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // dataGridView_singleRoadData
            // 
            this.dataGridView_singleRoadData.AllowUserToAddRows = false;
            this.dataGridView_singleRoadData.AllowUserToDeleteRows = false;
            this.dataGridView_singleRoadData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_singleRoadData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_singleRoadData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_singleRoadData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Period,
            this.enterCars,
            this.PassedCar,
            this.WaittingCar,
            this.CarWaittingRate,
            this.TotalWaittingTime});
            this.dataGridView_singleRoadData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_singleRoadData.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_singleRoadData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_singleRoadData.Name = "dataGridView_singleRoadData";
            this.dataGridView_singleRoadData.RowTemplate.Height = 24;
            this.dataGridView_singleRoadData.Size = new System.Drawing.Size(727, 372);
            this.dataGridView_singleRoadData.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_singleRoadData);
            this.panel2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.panel2.Location = new System.Drawing.Point(14, 404);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 372);
            this.panel2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Road);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.groupBox2.Location = new System.Drawing.Point(15, 343);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(297, 53);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "選擇道路";
            // 
            // comboBox_Road
            // 
            this.comboBox_Road.FormattingEnabled = true;
            this.comboBox_Road.Location = new System.Drawing.Point(8, 17);
            this.comboBox_Road.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Road.Name = "comboBox_Road";
            this.comboBox_Road.Size = new System.Drawing.Size(282, 25);
            this.comboBox_Road.TabIndex = 0;
            this.comboBox_Road.SelectedIndexChanged += new System.EventHandler(this.comboBox_road_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "平均等待時間 : ";
            // 
            // label_IAWT
            // 
            this.label_IAWT.AutoSize = true;
            this.label_IAWT.Location = new System.Drawing.Point(136, 61);
            this.label_IAWT.Name = "label_IAWT";
            this.label_IAWT.Size = new System.Drawing.Size(14, 17);
            this.label_IAWT.TabIndex = 8;
            this.label_IAWT.Text = "-";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_sec);
            this.groupBox3.Controls.Add(this.label_pa);
            this.groupBox3.Controls.Add(this.label_AWR);
            this.groupBox3.Controls.Add(this.label_2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label_IAWT);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(368, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(259, 96);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "路口數據";
            // 
            // label_2
            // 
            this.label_2.AutoSize = true;
            this.label_2.Location = new System.Drawing.Point(7, 25);
            this.label_2.Name = "label_2";
            this.label_2.Size = new System.Drawing.Size(94, 17);
            this.label_2.TabIndex = 9;
            this.label_2.Text = "平均等待率     : ";
            // 
            // numericUpDown_startPeriod
            // 
            this.numericUpDown_startPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_startPeriod.Location = new System.Drawing.Point(100, 77);
            this.numericUpDown_startPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_startPeriod.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_startPeriod.Name = "numericUpDown_startPeriod";
            this.numericUpDown_startPeriod.Size = new System.Drawing.Size(61, 25);
            this.numericUpDown_startPeriod.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.Location = new System.Drawing.Point(20, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "起始周期 : ";
            // 
            // label_endPeriod
            // 
            this.label_endPeriod.AutoSize = true;
            this.label_endPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label_endPeriod.Location = new System.Drawing.Point(204, 81);
            this.label_endPeriod.Name = "label_endPeriod";
            this.label_endPeriod.Size = new System.Drawing.Size(75, 18);
            this.label_endPeriod.TabIndex = 12;
            this.label_endPeriod.Text = "結束周期 : ";
            // 
            // numericUpDown_endPeriod
            // 
            this.numericUpDown_endPeriod.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_endPeriod.Location = new System.Drawing.Point(283, 77);
            this.numericUpDown_endPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_endPeriod.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_endPeriod.Name = "numericUpDown_endPeriod";
            this.numericUpDown_endPeriod.Size = new System.Drawing.Size(61, 25);
            this.numericUpDown_endPeriod.TabIndex = 13;
            // 
            // Road
            // 
            this.Road.FillWeight = 15F;
            this.Road.HeaderText = "道路";
            this.Road.Name = "Road";
            this.Road.ReadOnly = true;
            // 
            // AveragePassedCar
            // 
            this.AveragePassedCar.FillWeight = 25F;
            this.AveragePassedCar.HeaderText = "平均進入車輛";
            this.AveragePassedCar.Name = "AveragePassedCar";
            this.AveragePassedCar.ReadOnly = true;
            // 
            // AverageWaittingCar
            // 
            this.AverageWaittingCar.FillWeight = 25F;
            this.AverageWaittingCar.HeaderText = "平均等待車輛";
            this.AverageWaittingCar.Name = "AverageWaittingCar";
            this.AverageWaittingCar.ReadOnly = true;
            // 
            // AverageCarWaittingRate
            // 
            this.AverageCarWaittingRate.FillWeight = 30F;
            this.AverageCarWaittingRate.HeaderText = "平均車輛等待率(%)";
            this.AverageCarWaittingRate.Name = "AverageCarWaittingRate";
            this.AverageCarWaittingRate.ReadOnly = true;
            // 
            // AverageWaittingTime
            // 
            this.AverageWaittingTime.FillWeight = 30F;
            this.AverageWaittingTime.HeaderText = "平均等待時間(sec)";
            this.AverageWaittingTime.Name = "AverageWaittingTime";
            this.AverageWaittingTime.ReadOnly = true;
            // 
            // Period
            // 
            this.Period.FillWeight = 20F;
            this.Period.HeaderText = "周期";
            this.Period.Name = "Period";
            // 
            // enterCars
            // 
            this.enterCars.FillWeight = 30F;
            this.enterCars.HeaderText = "進入車輛";
            this.enterCars.Name = "enterCars";
            // 
            // PassedCar
            // 
            this.PassedCar.FillWeight = 30F;
            this.PassedCar.HeaderText = "通過車輛";
            this.PassedCar.Name = "PassedCar";
            // 
            // WaittingCar
            // 
            this.WaittingCar.FillWeight = 30F;
            this.WaittingCar.HeaderText = "等待車輛";
            this.WaittingCar.Name = "WaittingCar";
            // 
            // CarWaittingRate
            // 
            this.CarWaittingRate.FillWeight = 40F;
            this.CarWaittingRate.HeaderText = "車輛等待率(%)";
            this.CarWaittingRate.Name = "CarWaittingRate";
            // 
            // TotalWaittingTime
            // 
            this.TotalWaittingTime.FillWeight = 40F;
            this.TotalWaittingTime.HeaderText = "總等待時間(sec)";
            this.TotalWaittingTime.Name = "TotalWaittingTime";
            // 
            // label_pa
            // 
            this.label_pa.AutoSize = true;
            this.label_pa.Location = new System.Drawing.Point(185, 25);
            this.label_pa.Name = "label_pa";
            this.label_pa.Size = new System.Drawing.Size(19, 17);
            this.label_pa.TabIndex = 11;
            this.label_pa.Text = "%";
            // 
            // label_AWR
            // 
            this.label_AWR.AutoSize = true;
            this.label_AWR.Location = new System.Drawing.Point(136, 25);
            this.label_AWR.Name = "label_AWR";
            this.label_AWR.Size = new System.Drawing.Size(17, 17);
            this.label_AWR.TabIndex = 10;
            this.label_AWR.Text = "- ";
            // 
            // label_sec
            // 
            this.label_sec.AutoSize = true;
            this.label_sec.Location = new System.Drawing.Point(185, 61);
            this.label_sec.Name = "label_sec";
            this.label_sec.Size = new System.Drawing.Size(27, 17);
            this.label_sec.TabIndex = 12;
            this.label_sec.Text = "sec";
            // 
            // IntersectionData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 792);
            this.Controls.Add(this.numericUpDown_endPeriod);
            this.Controls.Add(this.label_endPeriod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_startPeriod);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IntersectionData";
            this.Text = "RoadData";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RoadData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_singleRoadData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_RoadData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Intersections;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.DataGridView dataGridView_singleRoadData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_Road;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_IAWT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_2;
        private System.Windows.Forms.NumericUpDown numericUpDown_startPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_endPeriod;
        private System.Windows.Forms.NumericUpDown numericUpDown_endPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Road;
        private System.Windows.Forms.DataGridViewTextBoxColumn AveragePassedCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaittingCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageCarWaittingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageWaittingTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn enterCars;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassedCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaittingCar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarWaittingRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalWaittingTime;
        private System.Windows.Forms.Label label_sec;
        private System.Windows.Forms.Label label_pa;
        private System.Windows.Forms.Label label_AWR;
    }
}