namespace SmartTrafficSimulator
{
    partial class VehicleInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehicleInformation));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_state = new System.Windows.Forms.Label();
            this.label_weight = new System.Windows.Forms.Label();
            this.label_Speed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_locatedRoad = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_travelTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_travelDistance = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_delayTime = new System.Windows.Forms.Label();
            this.label_10 = new System.Windows.Forms.Label();
            this.label_avgSpeed = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label_avgSpeed, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_10, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_delayTime, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_travelDistance, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_travelTime, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_state, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_weight, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_Speed, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_locatedRoad, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 139);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label_state
            // 
            this.label_state.AutoSize = true;
            this.label_state.Location = new System.Drawing.Point(160, 106);
            this.label_state.Margin = new System.Windows.Forms.Padding(4);
            this.label_state.Name = "label_state";
            this.label_state.Size = new System.Drawing.Size(44, 17);
            this.label_state.TabIndex = 7;
            this.label_state.Text = "label9";
            // 
            // label_weight
            // 
            this.label_weight.AutoSize = true;
            this.label_weight.Location = new System.Drawing.Point(160, 72);
            this.label_weight.Margin = new System.Windows.Forms.Padding(4);
            this.label_weight.Name = "label_weight";
            this.label_weight.Size = new System.Drawing.Size(44, 17);
            this.label_weight.TabIndex = 6;
            this.label_weight.Text = "label8";
            // 
            // label_Speed
            // 
            this.label_Speed.AutoSize = true;
            this.label_Speed.Location = new System.Drawing.Point(160, 38);
            this.label_Speed.Margin = new System.Windows.Forms.Padding(4);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(44, 17);
            this.label_Speed.TabIndex = 5;
            this.label_Speed.Text = "label7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Located Road";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Speed (KM/H)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vehicle Weight";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Driving State";
            // 
            // label_locatedRoad
            // 
            this.label_locatedRoad.AutoSize = true;
            this.label_locatedRoad.Location = new System.Drawing.Point(160, 4);
            this.label_locatedRoad.Margin = new System.Windows.Forms.Padding(4);
            this.label_locatedRoad.Name = "label_locatedRoad";
            this.label_locatedRoad.Size = new System.Drawing.Size(44, 17);
            this.label_locatedRoad.TabIndex = 4;
            this.label_locatedRoad.Text = "label6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Traval Time (Sec)";
            // 
            // label_travelTime
            // 
            this.label_travelTime.AutoSize = true;
            this.label_travelTime.Location = new System.Drawing.Point(420, 4);
            this.label_travelTime.Margin = new System.Windows.Forms.Padding(4);
            this.label_travelTime.Name = "label_travelTime";
            this.label_travelTime.Size = new System.Drawing.Size(74, 17);
            this.label_travelTime.TabIndex = 9;
            this.label_travelTime.Text = "Travel time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Travel Distance (M)";
            // 
            // label_travelDistance
            // 
            this.label_travelDistance.AutoSize = true;
            this.label_travelDistance.Location = new System.Drawing.Point(420, 38);
            this.label_travelDistance.Margin = new System.Windows.Forms.Padding(4);
            this.label_travelDistance.Name = "label_travelDistance";
            this.label_travelDistance.Size = new System.Drawing.Size(97, 17);
            this.label_travelDistance.TabIndex = 11;
            this.label_travelDistance.Text = "Travel distance";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 72);
            this.label9.Margin = new System.Windows.Forms.Padding(4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "Delay Time (Sec)";
            // 
            // label_delayTime
            // 
            this.label_delayTime.AutoSize = true;
            this.label_delayTime.Location = new System.Drawing.Point(420, 72);
            this.label_delayTime.Margin = new System.Windows.Forms.Padding(4);
            this.label_delayTime.Name = "label_delayTime";
            this.label_delayTime.Size = new System.Drawing.Size(74, 17);
            this.label_delayTime.TabIndex = 13;
            this.label_delayTime.Text = "Delay Time";
            // 
            // label_10
            // 
            this.label_10.AutoSize = true;
            this.label_10.Location = new System.Drawing.Point(264, 106);
            this.label_10.Margin = new System.Windows.Forms.Padding(4);
            this.label_10.Name = "label_10";
            this.label_10.Size = new System.Drawing.Size(114, 17);
            this.label_10.TabIndex = 14;
            this.label_10.Text = "Avg Speed (KMH)";
            // 
            // label_avgSpeed
            // 
            this.label_avgSpeed.AutoSize = true;
            this.label_avgSpeed.Location = new System.Drawing.Point(420, 106);
            this.label_avgSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.label_avgSpeed.Name = "label_avgSpeed";
            this.label_avgSpeed.Size = new System.Drawing.Size(72, 17);
            this.label_avgSpeed.TabIndex = 15;
            this.label_avgSpeed.Text = "Avg Speed";
            // 
            // VehicleInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(566, 213);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VehicleInformation";
            this.RightToLeftLayout = true;
            this.Text = "Car ID : ";
            this.Load += new System.EventHandler(this.VehicleInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_state;
        private System.Windows.Forms.Label label_weight;
        private System.Windows.Forms.Label label_Speed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_locatedRoad;
        private System.Windows.Forms.Label label_avgSpeed;
        private System.Windows.Forms.Label label_10;
        private System.Windows.Forms.Label label_delayTime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_travelDistance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_travelTime;
        private System.Windows.Forms.Label label4;
    }
}