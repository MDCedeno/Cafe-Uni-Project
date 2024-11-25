namespace Cafe_Uni_Project
{
    partial class Form4
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartEmployeeStats = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartEmployeeDates = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtRanking = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHighestEarnings = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvTopPerformers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pbeval = new System.Windows.Forms.PictureBox();
            this.pbreport = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.btnRecruitment = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnEmployeeStatus = new System.Windows.Forms.Button();
            this.btnPayroll = new System.Windows.Forms.Button();
            this.btnAttendance = new System.Windows.Forms.Button();
            this.btnPersonal = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblStanding = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pbUserPicture = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeDates)).BeginInit();
            this.panelAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPerformers)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbreport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.chartEmployeeStats);
            this.panel2.Controls.Add(this.chartEmployeeDates);
            this.panel2.Controls.Add(this.txtHighestEarnings);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dgvTopPerformers);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panelAdmin);
            this.panel2.Location = new System.Drawing.Point(172, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 621);
            this.panel2.TabIndex = 4;
            // 
            // chartEmployeeStats
            // 
            this.chartEmployeeStats.BackColor = System.Drawing.Color.Transparent;
            this.chartEmployeeStats.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartEmployeeStats.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEmployeeStats.Legends.Add(legend1);
            this.chartEmployeeStats.Location = new System.Drawing.Point(45, 419);
            this.chartEmployeeStats.Name = "chartEmployeeStats";
            this.chartEmployeeStats.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.Name = "EmployeeStats";
            this.chartEmployeeStats.Series.Add(series1);
            this.chartEmployeeStats.Size = new System.Drawing.Size(477, 190);
            this.chartEmployeeStats.TabIndex = 97;
            this.chartEmployeeStats.Text = "chart1";
            // 
            // chartEmployeeDates
            // 
            this.chartEmployeeDates.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartEmployeeDates.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartEmployeeDates.Legends.Add(legend2);
            this.chartEmployeeDates.Location = new System.Drawing.Point(1, 251);
            this.chartEmployeeDates.Name = "chartEmployeeDates";
            this.chartEmployeeDates.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "Date of Recruitment";
            this.chartEmployeeDates.Series.Add(series2);
            this.chartEmployeeDates.Size = new System.Drawing.Size(540, 171);
            this.chartEmployeeDates.TabIndex = 98;
            this.chartEmployeeDates.Text = "Date of Recruitment";
            // 
            // panelAdmin
            // 
            this.panelAdmin.Controls.Add(this.btnUpdate);
            this.panelAdmin.Controls.Add(this.btnSave);
            this.panelAdmin.Controls.Add(this.btnDelete);
            this.panelAdmin.Controls.Add(this.label3);
            this.panelAdmin.Controls.Add(this.btnClear);
            this.panelAdmin.Controls.Add(this.txtUsername);
            this.panelAdmin.Controls.Add(this.txtRanking);
            this.panelAdmin.Controls.Add(this.label5);
            this.panelAdmin.Location = new System.Drawing.Point(124, 515);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(169, 72);
            this.panelAdmin.TabIndex = 96;
            this.panelAdmin.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.PowderBlue;
            this.btnUpdate.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(142, 26);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 34);
            this.btnUpdate.TabIndex = 86;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Aquamarine;
            this.btnSave.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(433, 26);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 34);
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(239, 26);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 34);
            this.btnDelete.TabIndex = 87;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(2, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 88;
            this.label3.Text = "Username:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Plum;
            this.btnClear.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(336, 26);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 34);
            this.btnClear.TabIndex = 92;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(62, 18);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(76, 20);
            this.txtUsername.TabIndex = 89;
            // 
            // txtRanking
            // 
            this.txtRanking.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRanking.Location = new System.Drawing.Point(61, 46);
            this.txtRanking.Margin = new System.Windows.Forms.Padding(2);
            this.txtRanking.Name = "txtRanking";
            this.txtRanking.Size = new System.Drawing.Size(76, 20);
            this.txtRanking.TabIndex = 91;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(2, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 90;
            this.label5.Text = "Ranking:";
            // 
            // txtHighestEarnings
            // 
            this.txtHighestEarnings.BackColor = System.Drawing.Color.White;
            this.txtHighestEarnings.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighestEarnings.Location = new System.Drawing.Point(217, 494);
            this.txtHighestEarnings.Margin = new System.Windows.Forms.Padding(2);
            this.txtHighestEarnings.Name = "txtHighestEarnings";
            this.txtHighestEarnings.ReadOnly = true;
            this.txtHighestEarnings.Size = new System.Drawing.Size(76, 20);
            this.txtHighestEarnings.TabIndex = 94;
            this.txtHighestEarnings.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(121, 497);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 81;
            this.label6.Text = "HIGHEST EARNINGS:";
            this.label6.Visible = false;
            // 
            // dgvTopPerformers
            // 
            this.dgvTopPerformers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopPerformers.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Impact", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopPerformers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTopPerformers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopPerformers.Location = new System.Drawing.Point(9, 22);
            this.dgvTopPerformers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTopPerformers.Name = "dgvTopPerformers";
            this.dgvTopPerformers.ReadOnly = true;
            this.dgvTopPerformers.RowHeadersWidth = 51;
            this.dgvTopPerformers.RowTemplate.Height = 24;
            this.dgvTopPerformers.Size = new System.Drawing.Size(513, 224);
            this.dgvTopPerformers.TabIndex = 12;
            this.dgvTopPerformers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTopPerformers_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "TOP PERFORMERS:";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(27, 568);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(93, 34);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PapayaWhip;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.pbeval);
            this.panel1.Controls.Add(this.pbreport);
            this.panel1.Controls.Add(this.pictureBox11);
            this.panel1.Controls.Add(this.pictureBox12);
            this.panel1.Controls.Add(this.pictureBox13);
            this.panel1.Controls.Add(this.pictureBox14);
            this.panel1.Controls.Add(this.btnRecruitment);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnEmployeeStatus);
            this.panel1.Controls.Add(this.btnPayroll);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnAttendance);
            this.panel1.Controls.Add(this.btnPersonal);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.lblStanding);
            this.panel1.Controls.Add(this.lblUsername);
            this.panel1.Controls.Add(this.pbUserPicture);
            this.panel1.Location = new System.Drawing.Point(2, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 621);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.White;
            this.pictureBox8.Location = new System.Drawing.Point(3, 462);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(55, 49);
            this.pictureBox8.TabIndex = 38;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Visible = false;
            // 
            // pbeval
            // 
            this.pbeval.BackColor = System.Drawing.Color.Transparent;
            this.pbeval.Image = global::Cafe_Uni_Project.Properties.Resources.Evaluation;
            this.pbeval.Location = new System.Drawing.Point(3, 418);
            this.pbeval.Name = "pbeval";
            this.pbeval.Size = new System.Drawing.Size(55, 49);
            this.pbeval.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbeval.TabIndex = 37;
            this.pbeval.TabStop = false;
            // 
            // pbreport
            // 
            this.pbreport.BackColor = System.Drawing.Color.Transparent;
            this.pbreport.Image = global::Cafe_Uni_Project.Properties.Resources.Reports;
            this.pbreport.Location = new System.Drawing.Point(3, 372);
            this.pbreport.Name = "pbreport";
            this.pbreport.Size = new System.Drawing.Size(55, 49);
            this.pbreport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbreport.TabIndex = 36;
            this.pbreport.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.Image = global::Cafe_Uni_Project.Properties.Resources.Status;
            this.pictureBox11.Location = new System.Drawing.Point(3, 326);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(55, 49);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 35;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = global::Cafe_Uni_Project.Properties.Resources.Attendance;
            this.pictureBox12.Location = new System.Drawing.Point(3, 280);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(55, 48);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox12.TabIndex = 34;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.Image = global::Cafe_Uni_Project.Properties.Resources.Records;
            this.pictureBox13.Location = new System.Drawing.Point(3, 233);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(55, 49);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 33;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.NavajoWhite;
            this.pictureBox14.Image = global::Cafe_Uni_Project.Properties.Resources.Dashboard;
            this.pictureBox14.Location = new System.Drawing.Point(3, 187);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(55, 49);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 32;
            this.pictureBox14.TabStop = false;
            // 
            // btnRecruitment
            // 
            this.btnRecruitment.BackColor = System.Drawing.Color.White;
            this.btnRecruitment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecruitment.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecruitment.Location = new System.Drawing.Point(63, 418);
            this.btnRecruitment.Margin = new System.Windows.Forms.Padding(2);
            this.btnRecruitment.Name = "btnRecruitment";
            this.btnRecruitment.Size = new System.Drawing.Size(102, 49);
            this.btnRecruitment.TabIndex = 9;
            this.btnRecruitment.Text = "Employee Evaluation";
            this.btnRecruitment.UseVisualStyleBackColor = false;
            this.btnRecruitment.Click += new System.EventHandler(this.btnRecruitment_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.White;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Location = new System.Drawing.Point(63, 372);
            this.btnReports.Margin = new System.Windows.Forms.Padding(2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(102, 49);
            this.btnReports.TabIndex = 8;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnEmployeeStatus
            // 
            this.btnEmployeeStatus.BackColor = System.Drawing.Color.White;
            this.btnEmployeeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeStatus.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeStatus.Location = new System.Drawing.Point(63, 326);
            this.btnEmployeeStatus.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmployeeStatus.Name = "btnEmployeeStatus";
            this.btnEmployeeStatus.Size = new System.Drawing.Size(102, 49);
            this.btnEmployeeStatus.TabIndex = 7;
            this.btnEmployeeStatus.Text = "Employee Status";
            this.btnEmployeeStatus.UseVisualStyleBackColor = false;
            this.btnEmployeeStatus.Click += new System.EventHandler(this.btnEmployeeStatus_Click);
            // 
            // btnPayroll
            // 
            this.btnPayroll.BackColor = System.Drawing.Color.White;
            this.btnPayroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayroll.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayroll.Location = new System.Drawing.Point(63, 462);
            this.btnPayroll.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayroll.Name = "btnPayroll";
            this.btnPayroll.Size = new System.Drawing.Size(102, 49);
            this.btnPayroll.TabIndex = 6;
            this.btnPayroll.Text = "Payroll";
            this.btnPayroll.UseVisualStyleBackColor = false;
            this.btnPayroll.Visible = false;
            this.btnPayroll.Click += new System.EventHandler(this.btnPayroll_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.White;
            this.btnAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttendance.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.Location = new System.Drawing.Point(63, 280);
            this.btnAttendance.Margin = new System.Windows.Forms.Padding(2);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(102, 49);
            this.btnAttendance.TabIndex = 5;
            this.btnAttendance.Text = "Attendance Tracker";
            this.btnAttendance.UseVisualStyleBackColor = false;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnPersonal
            // 
            this.btnPersonal.BackColor = System.Drawing.Color.White;
            this.btnPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonal.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonal.Location = new System.Drawing.Point(63, 233);
            this.btnPersonal.Margin = new System.Windows.Forms.Padding(2);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(102, 49);
            this.btnPersonal.TabIndex = 4;
            this.btnPersonal.Text = "Personal Records";
            this.btnPersonal.UseVisualStyleBackColor = false;
            this.btnPersonal.Click += new System.EventHandler(this.btnPersonal_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Location = new System.Drawing.Point(63, 187);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(102, 49);
            this.btnDashboard.TabIndex = 3;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lblStanding
            // 
            this.lblStanding.AutoSize = true;
            this.lblStanding.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStanding.Location = new System.Drawing.Point(2, 162);
            this.lblStanding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStanding.Name = "lblStanding";
            this.lblStanding.Size = new System.Drawing.Size(56, 15);
            this.lblStanding.TabIndex = 2;
            this.lblStanding.Text = "Username:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Impact", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(86, 162);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(54, 15);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // pbUserPicture
            // 
            this.pbUserPicture.BackColor = System.Drawing.Color.White;
            this.pbUserPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbUserPicture.Location = new System.Drawing.Point(3, 3);
            this.pbUserPicture.Margin = new System.Windows.Forms.Padding(2);
            this.pbUserPicture.Name = "pbUserPicture";
            this.pbUserPicture.Size = new System.Drawing.Size(144, 156);
            this.pbUserPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUserPicture.TabIndex = 0;
            this.pbUserPicture.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Cafe_Uni_Project.Properties.Resources.Backround;
            this.ClientSize = new System.Drawing.Size(714, 611);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(730, 650);
            this.MinimumSize = new System.Drawing.Size(730, 650);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeDates)).EndInit();
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopPerformers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbeval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbreport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRecruitment;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnEmployeeStatus;
        private System.Windows.Forms.Button btnPayroll;
        private System.Windows.Forms.Button btnAttendance;
        private System.Windows.Forms.Button btnPersonal;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label lblStanding;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox pbUserPicture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTopPerformers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtRanking;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtHighestEarnings;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pbeval;
        private System.Windows.Forms.PictureBox pbreport;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEmployeeStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEmployeeDates;
    }
}