namespace SmartTrafficSimulator
{
    partial class VehicleConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehicleConfig));
            this.comboBox_generateRoads = new System.Windows.Forms.ComboBox();
            this.groupBox_generateRoads = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown_volum = new System.Windows.Forms.NumericUpDown();
            this.button_testGenerate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_addGenerateRoad = new System.Windows.Forms.Button();
            this.comboBox_otherRoads = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_removeGenerateRoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_vehicleConfig = new System.Windows.Forms.GroupBox();
            this.numericUpDown_brakeFactor = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_accelerationFactor = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_vehicleMaxSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button_applyVehicleConfig = new System.Windows.Forms.Button();
            this.numericUpDown_vehicleSize = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_vehicleGraphicDemo = new System.Windows.Forms.PictureBox();
            this.groupBox_generateSchedule = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button_addSchedule = new System.Windows.Forms.Button();
            this.numericUpDown_hour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_minute = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_level = new System.Windows.Forms.NumericUpDown();
            this.button_removeSchedule = new System.Windows.Forms.Button();
            this.listBox_generateSchedule = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_drivingPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox_nextRoad = new System.Windows.Forms.ComboBox();
            this.numericUpDown_drivingPathProbability = new System.Windows.Forms.NumericUpDown();
            this.button_nextRoad = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_addDrivingPath = new System.Windows.Forms.Button();
            this.button_removePath = new System.Windows.Forms.Button();
            this.listBox_DrivingPath = new System.Windows.Forms.ListBox();
            this.groupBox_generateRoads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_volum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox_vehicleConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_brakeFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_accelerationFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_vehicleMaxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_vehicleSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vehicleGraphicDemo)).BeginInit();
            this.groupBox_generateSchedule.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_level)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_drivingPathProbability)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_generateRoads
            // 
            this.comboBox_generateRoads.BackColor = System.Drawing.Color.White;
            this.comboBox_generateRoads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_generateRoads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_generateRoads.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_generateRoads.FormattingEnabled = true;
            this.comboBox_generateRoads.Location = new System.Drawing.Point(75, 29);
            this.comboBox_generateRoads.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox_generateRoads.Name = "comboBox_generateRoads";
            this.comboBox_generateRoads.Size = new System.Drawing.Size(161, 25);
            this.comboBox_generateRoads.TabIndex = 0;
            this.comboBox_generateRoads.SelectedIndexChanged += new System.EventHandler(this.comboBox_generateRoad_SelectedIndexChanged);
            // 
            // groupBox_generateRoads
            // 
            this.groupBox_generateRoads.Controls.Add(this.label13);
            this.groupBox_generateRoads.Controls.Add(this.numericUpDown_volum);
            this.groupBox_generateRoads.Controls.Add(this.button_testGenerate);
            this.groupBox_generateRoads.Controls.Add(this.groupBox2);
            this.groupBox_generateRoads.Controls.Add(this.button_removeGenerateRoad);
            this.groupBox_generateRoads.Controls.Add(this.label2);
            this.groupBox_generateRoads.Controls.Add(this.label1);
            this.groupBox_generateRoads.Controls.Add(this.comboBox_generateRoads);
            this.groupBox_generateRoads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_generateRoads.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_generateRoads.Location = new System.Drawing.Point(13, 12);
            this.groupBox_generateRoads.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox_generateRoads.Name = "groupBox_generateRoads";
            this.groupBox_generateRoads.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox_generateRoads.Size = new System.Drawing.Size(369, 224);
            this.groupBox_generateRoads.TabIndex = 1;
            this.groupBox_generateRoads.TabStop = false;
            this.groupBox_generateRoads.Text = "Generator Road";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(140, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 17);
            this.label13.TabIndex = 12;
            this.label13.Text = "Vehicle / min";
            // 
            // numericUpDown_volum
            // 
            this.numericUpDown_volum.BackColor = System.Drawing.Color.White;
            this.numericUpDown_volum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_volum.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_volum.Location = new System.Drawing.Point(75, 78);
            this.numericUpDown_volum.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_volum.Name = "numericUpDown_volum";
            this.numericUpDown_volum.Size = new System.Drawing.Size(64, 21);
            this.numericUpDown_volum.TabIndex = 11;
            this.numericUpDown_volum.ValueChanged += new System.EventHandler(this.numericUpDown_volum_ValueChanged);
            // 
            // button_testGenerate
            // 
            this.button_testGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_testGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_testGenerate.FlatAppearance.BorderSize = 0;
            this.button_testGenerate.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_testGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_testGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_testGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_testGenerate.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_testGenerate.Location = new System.Drawing.Point(261, 73);
            this.button_testGenerate.Margin = new System.Windows.Forms.Padding(5);
            this.button_testGenerate.Name = "button_testGenerate";
            this.button_testGenerate.Size = new System.Drawing.Size(90, 35);
            this.button_testGenerate.TabIndex = 9;
            this.button_testGenerate.Text = "Generate";
            this.button_testGenerate.UseVisualStyleBackColor = false;
            this.button_testGenerate.Click += new System.EventHandler(this.button_testGenerate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_addGenerateRoad);
            this.groupBox2.Controls.Add(this.comboBox_otherRoads);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(8, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 86);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New";
            // 
            // button_addGenerateRoad
            // 
            this.button_addGenerateRoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_addGenerateRoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_addGenerateRoad.FlatAppearance.BorderSize = 0;
            this.button_addGenerateRoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addGenerateRoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_addGenerateRoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addGenerateRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addGenerateRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_addGenerateRoad.Location = new System.Drawing.Point(251, 25);
            this.button_addGenerateRoad.Margin = new System.Windows.Forms.Padding(5);
            this.button_addGenerateRoad.Name = "button_addGenerateRoad";
            this.button_addGenerateRoad.Size = new System.Drawing.Size(90, 35);
            this.button_addGenerateRoad.TabIndex = 7;
            this.button_addGenerateRoad.Text = "Add";
            this.button_addGenerateRoad.UseVisualStyleBackColor = false;
            this.button_addGenerateRoad.Click += new System.EventHandler(this.button_addGenerateRoad_Click);
            // 
            // comboBox_otherRoads
            // 
            this.comboBox_otherRoads.BackColor = System.Drawing.Color.White;
            this.comboBox_otherRoads.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_otherRoads.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_otherRoads.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_otherRoads.FormattingEnabled = true;
            this.comboBox_otherRoads.Location = new System.Drawing.Point(69, 31);
            this.comboBox_otherRoads.Name = "comboBox_otherRoads";
            this.comboBox_otherRoads.Size = new System.Drawing.Size(125, 25);
            this.comboBox_otherRoads.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "RoadID";
            // 
            // button_removeGenerateRoad
            // 
            this.button_removeGenerateRoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_removeGenerateRoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_removeGenerateRoad.FlatAppearance.BorderSize = 0;
            this.button_removeGenerateRoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_removeGenerateRoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_removeGenerateRoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_removeGenerateRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_removeGenerateRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_removeGenerateRoad.Location = new System.Drawing.Point(261, 24);
            this.button_removeGenerateRoad.Margin = new System.Windows.Forms.Padding(5);
            this.button_removeGenerateRoad.Name = "button_removeGenerateRoad";
            this.button_removeGenerateRoad.Size = new System.Drawing.Size(90, 35);
            this.button_removeGenerateRoad.TabIndex = 4;
            this.button_removeGenerateRoad.Text = "Remove";
            this.button_removeGenerateRoad.UseVisualStyleBackColor = false;
            this.button_removeGenerateRoad.Click += new System.EventHandler(this.button_removeGenerateRoad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(8, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Volume : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "RoadID : ";
            // 
            // groupBox_vehicleConfig
            // 
            this.groupBox_vehicleConfig.Controls.Add(this.numericUpDown_brakeFactor);
            this.groupBox_vehicleConfig.Controls.Add(this.numericUpDown_accelerationFactor);
            this.groupBox_vehicleConfig.Controls.Add(this.label12);
            this.groupBox_vehicleConfig.Controls.Add(this.label11);
            this.groupBox_vehicleConfig.Controls.Add(this.label6);
            this.groupBox_vehicleConfig.Controls.Add(this.numericUpDown_vehicleMaxSpeed);
            this.groupBox_vehicleConfig.Controls.Add(this.label5);
            this.groupBox_vehicleConfig.Controls.Add(this.button_applyVehicleConfig);
            this.groupBox_vehicleConfig.Controls.Add(this.numericUpDown_vehicleSize);
            this.groupBox_vehicleConfig.Controls.Add(this.label4);
            this.groupBox_vehicleConfig.Controls.Add(this.pictureBox_vehicleGraphicDemo);
            this.groupBox_vehicleConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_vehicleConfig.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_vehicleConfig.Location = new System.Drawing.Point(13, 245);
            this.groupBox_vehicleConfig.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox_vehicleConfig.Name = "groupBox_vehicleConfig";
            this.groupBox_vehicleConfig.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox_vehicleConfig.Size = new System.Drawing.Size(369, 202);
            this.groupBox_vehicleConfig.TabIndex = 2;
            this.groupBox_vehicleConfig.TabStop = false;
            this.groupBox_vehicleConfig.Text = "Vehicle Custom";
            // 
            // numericUpDown_brakeFactor
            // 
            this.numericUpDown_brakeFactor.BackColor = System.Drawing.Color.White;
            this.numericUpDown_brakeFactor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_brakeFactor.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_brakeFactor.Location = new System.Drawing.Point(305, 119);
            this.numericUpDown_brakeFactor.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDown_brakeFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_brakeFactor.Name = "numericUpDown_brakeFactor";
            this.numericUpDown_brakeFactor.Size = new System.Drawing.Size(45, 21);
            this.numericUpDown_brakeFactor.TabIndex = 15;
            this.numericUpDown_brakeFactor.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDown_accelerationFactor
            // 
            this.numericUpDown_accelerationFactor.BackColor = System.Drawing.Color.White;
            this.numericUpDown_accelerationFactor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_accelerationFactor.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_accelerationFactor.Location = new System.Drawing.Point(304, 94);
            this.numericUpDown_accelerationFactor.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDown_accelerationFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_accelerationFactor.Name = "numericUpDown_accelerationFactor";
            this.numericUpDown_accelerationFactor.Size = new System.Drawing.Size(45, 21);
            this.numericUpDown_accelerationFactor.TabIndex = 14;
            this.numericUpDown_accelerationFactor.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(191, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Brake Factor : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(151, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Acceleration Factor : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(8, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "- Preview -";
            // 
            // numericUpDown_vehicleMaxSpeed
            // 
            this.numericUpDown_vehicleMaxSpeed.BackColor = System.Drawing.Color.White;
            this.numericUpDown_vehicleMaxSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_vehicleMaxSpeed.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_vehicleMaxSpeed.Location = new System.Drawing.Point(305, 70);
            this.numericUpDown_vehicleMaxSpeed.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDown_vehicleMaxSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_vehicleMaxSpeed.Name = "numericUpDown_vehicleMaxSpeed";
            this.numericUpDown_vehicleMaxSpeed.Size = new System.Drawing.Size(45, 21);
            this.numericUpDown_vehicleMaxSpeed.TabIndex = 10;
            this.numericUpDown_vehicleMaxSpeed.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numericUpDown_vehicleMaxSpeed.ValueChanged += new System.EventHandler(this.numericUpDown_VehicleSpeed_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(155, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Max Speed (km/H) : ";
            // 
            // button_applyVehicleConfig
            // 
            this.button_applyVehicleConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_applyVehicleConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_applyVehicleConfig.FlatAppearance.BorderSize = 0;
            this.button_applyVehicleConfig.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_applyVehicleConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_applyVehicleConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_applyVehicleConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_applyVehicleConfig.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_applyVehicleConfig.Location = new System.Drawing.Point(261, 156);
            this.button_applyVehicleConfig.Margin = new System.Windows.Forms.Padding(5);
            this.button_applyVehicleConfig.Name = "button_applyVehicleConfig";
            this.button_applyVehicleConfig.Size = new System.Drawing.Size(90, 35);
            this.button_applyVehicleConfig.TabIndex = 8;
            this.button_applyVehicleConfig.Text = "Apply";
            this.button_applyVehicleConfig.UseVisualStyleBackColor = false;
            this.button_applyVehicleConfig.Click += new System.EventHandler(this.button_applyConfig_Click);
            // 
            // numericUpDown_vehicleSize
            // 
            this.numericUpDown_vehicleSize.BackColor = System.Drawing.Color.White;
            this.numericUpDown_vehicleSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_vehicleSize.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_vehicleSize.Location = new System.Drawing.Point(305, 25);
            this.numericUpDown_vehicleSize.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_vehicleSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_vehicleSize.Name = "numericUpDown_vehicleSize";
            this.numericUpDown_vehicleSize.Size = new System.Drawing.Size(45, 21);
            this.numericUpDown_vehicleSize.TabIndex = 3;
            this.numericUpDown_vehicleSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_vehicleSize.ValueChanged += new System.EventHandler(this.numericUpDown_VehicleLength_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(184, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Size : ";
            // 
            // pictureBox_vehicleGraphicDemo
            // 
            this.pictureBox_vehicleGraphicDemo.Image = global::SmartTrafficSimulator.Properties.Resources.vehicle0;
            this.pictureBox_vehicleGraphicDemo.Location = new System.Drawing.Point(14, 25);
            this.pictureBox_vehicleGraphicDemo.Name = "pictureBox_vehicleGraphicDemo";
            this.pictureBox_vehicleGraphicDemo.Size = new System.Drawing.Size(24, 12);
            this.pictureBox_vehicleGraphicDemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_vehicleGraphicDemo.TabIndex = 0;
            this.pictureBox_vehicleGraphicDemo.TabStop = false;
            // 
            // groupBox_generateSchedule
            // 
            this.groupBox_generateSchedule.Controls.Add(this.groupBox4);
            this.groupBox_generateSchedule.Controls.Add(this.button_removeSchedule);
            this.groupBox_generateSchedule.Controls.Add(this.listBox_generateSchedule);
            this.groupBox_generateSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_generateSchedule.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_generateSchedule.Location = new System.Drawing.Point(389, 12);
            this.groupBox_generateSchedule.Name = "groupBox_generateSchedule";
            this.groupBox_generateSchedule.Size = new System.Drawing.Size(242, 436);
            this.groupBox_generateSchedule.TabIndex = 3;
            this.groupBox_generateSchedule.TabStop = false;
            this.groupBox_generateSchedule.Text = "Schedule";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.button_addSchedule);
            this.groupBox4.Controls.Add(this.numericUpDown_hour);
            this.groupBox4.Controls.Add(this.numericUpDown_minute);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.numericUpDown_level);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox4.Location = new System.Drawing.Point(6, 269);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 161);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "New Schedule";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(132, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Vehicle / min";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(6, 71);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 17);
            this.label14.TabIndex = 9;
            this.label14.Text = "Volume : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(6, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Hour : ";
            // 
            // button_addSchedule
            // 
            this.button_addSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_addSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_addSchedule.FlatAppearance.BorderSize = 0;
            this.button_addSchedule.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addSchedule.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_addSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addSchedule.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_addSchedule.Location = new System.Drawing.Point(70, 114);
            this.button_addSchedule.Name = "button_addSchedule";
            this.button_addSchedule.Size = new System.Drawing.Size(90, 35);
            this.button_addSchedule.TabIndex = 8;
            this.button_addSchedule.Text = "Add";
            this.button_addSchedule.UseVisualStyleBackColor = false;
            this.button_addSchedule.Click += new System.EventHandler(this.button_addSchedule_Click);
            // 
            // numericUpDown_hour
            // 
            this.numericUpDown_hour.BackColor = System.Drawing.Color.White;
            this.numericUpDown_hour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_hour.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_hour.Location = new System.Drawing.Point(59, 34);
            this.numericUpDown_hour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown_hour.Name = "numericUpDown_hour";
            this.numericUpDown_hour.Size = new System.Drawing.Size(43, 21);
            this.numericUpDown_hour.TabIndex = 2;
            // 
            // numericUpDown_minute
            // 
            this.numericUpDown_minute.BackColor = System.Drawing.Color.White;
            this.numericUpDown_minute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_minute.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_minute.Location = new System.Drawing.Point(176, 34);
            this.numericUpDown_minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_minute.Name = "numericUpDown_minute";
            this.numericUpDown_minute.Size = new System.Drawing.Size(43, 21);
            this.numericUpDown_minute.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(109, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Minute : ";
            // 
            // numericUpDown_level
            // 
            this.numericUpDown_level.BackColor = System.Drawing.Color.White;
            this.numericUpDown_level.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_level.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_level.Location = new System.Drawing.Point(84, 69);
            this.numericUpDown_level.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_level.Name = "numericUpDown_level";
            this.numericUpDown_level.Size = new System.Drawing.Size(46, 21);
            this.numericUpDown_level.TabIndex = 4;
            // 
            // button_removeSchedule
            // 
            this.button_removeSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_removeSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_removeSchedule.FlatAppearance.BorderSize = 0;
            this.button_removeSchedule.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_removeSchedule.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_removeSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_removeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_removeSchedule.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_removeSchedule.Location = new System.Drawing.Point(75, 231);
            this.button_removeSchedule.Name = "button_removeSchedule";
            this.button_removeSchedule.Size = new System.Drawing.Size(90, 35);
            this.button_removeSchedule.TabIndex = 1;
            this.button_removeSchedule.Text = "Remove";
            this.button_removeSchedule.UseVisualStyleBackColor = false;
            this.button_removeSchedule.Click += new System.EventHandler(this.button_removeSchedule_Click);
            // 
            // listBox_generateSchedule
            // 
            this.listBox_generateSchedule.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_generateSchedule.FormattingEnabled = true;
            this.listBox_generateSchedule.ItemHeight = 17;
            this.listBox_generateSchedule.Items.AddRange(new object[] {
            "no-schedule"});
            this.listBox_generateSchedule.Location = new System.Drawing.Point(6, 19);
            this.listBox_generateSchedule.Name = "listBox_generateSchedule";
            this.listBox_generateSchedule.Size = new System.Drawing.Size(230, 208);
            this.listBox_generateSchedule.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.button_removePath);
            this.groupBox1.Controls.Add(this.listBox_DrivingPath);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(637, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 436);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drive Path";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_drivingPath);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBox_nextRoad);
            this.groupBox3.Controls.Add(this.numericUpDown_drivingPathProbability);
            this.groupBox3.Controls.Add(this.button_nextRoad);
            this.groupBox3.Controls.Add(this.button_clear);
            this.groupBox3.Controls.Add(this.button_addDrivingPath);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(6, 269);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 161);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New Path";
            // 
            // textBox_drivingPath
            // 
            this.textBox_drivingPath.BackColor = System.Drawing.Color.White;
            this.textBox_drivingPath.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_drivingPath.Location = new System.Drawing.Point(6, 29);
            this.textBox_drivingPath.Name = "textBox_drivingPath";
            this.textBox_drivingPath.ReadOnly = true;
            this.textBox_drivingPath.Size = new System.Drawing.Size(313, 25);
            this.textBox_drivingPath.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(13, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Probability : ";
            // 
            // comboBox_nextRoad
            // 
            this.comboBox_nextRoad.BackColor = System.Drawing.Color.White;
            this.comboBox_nextRoad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_nextRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_nextRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_nextRoad.FormattingEnabled = true;
            this.comboBox_nextRoad.Location = new System.Drawing.Point(7, 73);
            this.comboBox_nextRoad.Name = "comboBox_nextRoad";
            this.comboBox_nextRoad.Size = new System.Drawing.Size(108, 25);
            this.comboBox_nextRoad.TabIndex = 11;
            // 
            // numericUpDown_drivingPathProbability
            // 
            this.numericUpDown_drivingPathProbability.BackColor = System.Drawing.Color.White;
            this.numericUpDown_drivingPathProbability.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown_drivingPathProbability.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_drivingPathProbability.Location = new System.Drawing.Point(101, 124);
            this.numericUpDown_drivingPathProbability.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_drivingPathProbability.Name = "numericUpDown_drivingPathProbability";
            this.numericUpDown_drivingPathProbability.Size = new System.Drawing.Size(41, 21);
            this.numericUpDown_drivingPathProbability.TabIndex = 14;
            this.numericUpDown_drivingPathProbability.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_nextRoad
            // 
            this.button_nextRoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_nextRoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_nextRoad.FlatAppearance.BorderSize = 0;
            this.button_nextRoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_nextRoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_nextRoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_nextRoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_nextRoad.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_nextRoad.Location = new System.Drawing.Point(127, 67);
            this.button_nextRoad.Name = "button_nextRoad";
            this.button_nextRoad.Size = new System.Drawing.Size(89, 35);
            this.button_nextRoad.TabIndex = 12;
            this.button_nextRoad.Text = "Next Road";
            this.button_nextRoad.UseVisualStyleBackColor = false;
            this.button_nextRoad.Click += new System.EventHandler(this.button_nextRoad_Click);
            // 
            // button_clear
            // 
            this.button_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_clear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_clear.FlatAppearance.BorderSize = 0;
            this.button_clear.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_clear.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_clear.Location = new System.Drawing.Point(229, 66);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(89, 35);
            this.button_clear.TabIndex = 13;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = false;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_addDrivingPath
            // 
            this.button_addDrivingPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_addDrivingPath.Enabled = false;
            this.button_addDrivingPath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_addDrivingPath.FlatAppearance.BorderSize = 0;
            this.button_addDrivingPath.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addDrivingPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_addDrivingPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_addDrivingPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addDrivingPath.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_addDrivingPath.Location = new System.Drawing.Point(229, 114);
            this.button_addDrivingPath.Name = "button_addDrivingPath";
            this.button_addDrivingPath.Size = new System.Drawing.Size(89, 35);
            this.button_addDrivingPath.TabIndex = 9;
            this.button_addDrivingPath.Text = "Add";
            this.button_addDrivingPath.UseVisualStyleBackColor = false;
            this.button_addDrivingPath.Click += new System.EventHandler(this.button_addDrivingPath_Click);
            // 
            // button_removePath
            // 
            this.button_removePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.button_removePath.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.button_removePath.FlatAppearance.BorderSize = 0;
            this.button_removePath.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_removePath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.button_removePath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.button_removePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_removePath.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_removePath.Location = new System.Drawing.Point(123, 233);
            this.button_removePath.Name = "button_removePath";
            this.button_removePath.Size = new System.Drawing.Size(89, 35);
            this.button_removePath.TabIndex = 9;
            this.button_removePath.Text = "Remove";
            this.button_removePath.UseVisualStyleBackColor = false;
            this.button_removePath.Click += new System.EventHandler(this.button_removePath_Click);
            // 
            // listBox_DrivingPath
            // 
            this.listBox_DrivingPath.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox_DrivingPath.FormattingEnabled = true;
            this.listBox_DrivingPath.ItemHeight = 17;
            this.listBox_DrivingPath.Items.AddRange(new object[] {
            "no-DrivingPath"});
            this.listBox_DrivingPath.Location = new System.Drawing.Point(6, 19);
            this.listBox_DrivingPath.Name = "listBox_DrivingPath";
            this.listBox_DrivingPath.Size = new System.Drawing.Size(324, 208);
            this.listBox_DrivingPath.TabIndex = 0;
            // 
            // VehicleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(981, 454);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_generateSchedule);
            this.Controls.Add(this.groupBox_vehicleConfig);
            this.Controls.Add(this.groupBox_generateRoads);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "VehicleConfig";
            this.Text = "VehicleGenerateConfig";
            this.groupBox_generateRoads.ResumeLayout(false);
            this.groupBox_generateRoads.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_volum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_vehicleConfig.ResumeLayout(false);
            this.groupBox_vehicleConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_brakeFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_accelerationFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_vehicleMaxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_vehicleSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_vehicleGraphicDemo)).EndInit();
            this.groupBox_generateSchedule.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_level)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_drivingPathProbability)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_generateRoads;
        private System.Windows.Forms.GroupBox groupBox_generateRoads;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_vehicleConfig;
        private System.Windows.Forms.Button button_removeGenerateRoad;
        private System.Windows.Forms.Button button_addGenerateRoad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_otherRoads;
        private System.Windows.Forms.NumericUpDown numericUpDown_vehicleSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox_vehicleGraphicDemo;
        private System.Windows.Forms.Button button_applyVehicleConfig;
        private System.Windows.Forms.NumericUpDown numericUpDown_vehicleMaxSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox_generateSchedule;
        private System.Windows.Forms.ListBox listBox_generateSchedule;
        private System.Windows.Forms.Button button_removeSchedule;
        private System.Windows.Forms.Button button_addSchedule;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_level;
        private System.Windows.Forms.NumericUpDown numericUpDown_minute;
        private System.Windows.Forms.NumericUpDown numericUpDown_hour;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox_DrivingPath;
        private System.Windows.Forms.ComboBox comboBox_nextRoad;
        private System.Windows.Forms.TextBox textBox_drivingPath;
        private System.Windows.Forms.Button button_removePath;
        private System.Windows.Forms.Button button_addDrivingPath;
        private System.Windows.Forms.Button button_nextRoad;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_drivingPathProbability;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numericUpDown_brakeFactor;
        private System.Windows.Forms.NumericUpDown numericUpDown_accelerationFactor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_testGenerate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown_volum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
    }
}