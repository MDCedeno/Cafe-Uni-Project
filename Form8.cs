using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Cafe_Uni_Project.Form1;

namespace Cafe_Uni_Project
{
    public partial class Form8 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        public Form8()
        {
            InitializeComponent();
            lblUsername.Text = globalvariable.globalusername;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 Dashboard = new Form4();
            Dashboard.ShowDialog();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Personal = new Form2();
            Personal.ShowDialog();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 Tracker = new Form5();
            Tracker.ShowDialog();
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 Payroll = new Form6();
            Payroll.ShowDialog();
        }

        private void btnEmployeeStatus_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 Status = new Form7();
            Status.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 Reports = new Form8();
            Reports.ShowDialog();
        }

        private void btnRecruitment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 Recruit = new Form9();
            Recruit.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.ShowDialog();
        }

        public void LoadData()
        {
            // Data for user picture
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();

                // Query to retrieve the user picture from the database
                string query = "SELECT Picture FROM tblPersonalRecords WHERE Username = @username";

                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", lblUsername.Text);

                // Execute the query to retrieve the picture data
                byte[] imageData = (byte[])cmd.ExecuteScalar();

                // Convert the byte array to a memory stream
                MemoryStream ms = new MemoryStream(imageData);

                // Set the picture box image from the memory stream
                pbUserPicture.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading the user picture: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // For employee of the month
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();

                // Query to calculate attendance and fetch the employee with the most attendance in the current month
                string query = @"
            SELECT PR.PRID, PR.First_Name, PR.Last_Name, COUNT(A.RecordID) AS TotalAttendance
            FROM tblAttendancerecord A
            INNER JOIN tblPersonalRecords PR ON A.PRID = PR.PRID
            GROUP BY PR.PRID, PR.First_Name, PR.Last_Name
            ORDER BY TotalAttendance DESC
            LIMIT 3"; // Only retrieve the top 3 employee

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable TopEmployee = new DataTable();
                TopEmployee.Load(reader);

                // Bind the result to the DataGridView
                dgvEmpoftheMonth.DataSource = TopEmployee;

                // Set the same Microsoft Sans Serif font for both regular and alternating rows
                dgvEmpoftheMonth.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                dgvEmpoftheMonth.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font

                if (dgvEmpoftheMonth.Rows.Count > 0)
                {
                    dgvEmpoftheMonth.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                    dgvEmpoftheMonth.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee of the month record: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            // For employee rankings
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();

                string query = "SELECT PR.Username, PR.First_Name, " +
                    "PR.Last_Name, PR.Middle_Name, " +
                    "GS.Ranking FROM tblPersonalRecords PR " +
                    "INNER JOIN tblGeneralStatus GS " +
                    "ON PR.PRID = GS.PRID " +
                    "ORDER BY GS.Ranking ASC ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable TopPerformers = new DataTable();
                TopPerformers.Load(reader);
                dgvRankings.DataSource = TopPerformers;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ranking records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            // For employee earnings
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();

                string query = "SELECT PR.Username, PR.First_Name, " +
                    "PR.Last_Name, PR.Middle_Name, " +
                    "P.Earnings FROM tblPersonalRecords PR " +
                    "INNER JOIN tblPayroll P " +
                    "ON PR.PRID = P.PRID " +
                    "ORDER BY P.Earnings DESC ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable Payroll = new DataTable();
                Payroll.Load(reader);
                dgvEarnings.DataSource = Payroll;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading earning records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            LoadData();

            if (lblUsername.Text != "Admin")
            {
                btnReports.Visible = false;
                btnRecruitment.Visible = false;
                pbreport.Visible = false;
                pbeval.Visible = false;
            }
        }
    }
}
