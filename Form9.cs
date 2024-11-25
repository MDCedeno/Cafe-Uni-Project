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
    public partial class Form9 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        public Form9()
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

        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();

                string query = "SELECT PRID, Username, First_Name, Last_Name, Middle_Name, Age, " +
                        "Address, Educational_Attainment, Gender, Birthdate, Skills, Email, " +
                        "Contact_Number, Picture FROM tblPersonalRecords " +
                        "ORDER BY PRID DESC " +
                        "LIMIT 5 ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable PersonalRecords = new DataTable();
                PersonalRecords.Load(reader);
                dgvRecruitment.DataSource = PersonalRecords;

                // Set the size mode of the Picture column to Stretch
                if (dgvRecruitment.Columns["Picture"] is DataGridViewImageColumn pictureColumn)
                {
                    pictureColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recent recruit records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            LoadData();

            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();

                string query = "SELECT PR.Username, PR.First_Name, " +
                    "PR.Last_Name, PR.Middle_Name, GS.PRID, " +
                    "GS.Rank, GS.Ranking FROM tblPersonalRecords PR " +
                    "INNER JOIN tblGeneralStatus GS " +
                    "ON PR.PRID = GS.PRID " +
                    "ORDER BY GS.Rank ASC ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable TopPerformers = new DataTable();
                TopPerformers.Load(reader);
                dgvEvalranking.DataSource = TopPerformers;

                // Set the same Microsoft Sans Serif font for both regular and alternating rows
                dgvEvalranking.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                dgvEvalranking.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font

                if (dgvEvalranking.Rows.Count > 0)
                {
                    dgvEvalranking.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                    dgvEvalranking.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
                }

                // Formatting the DataGridView
                dgvEvalranking.Columns[0].HeaderText = "Username";
                dgvEvalranking.Columns[1].HeaderText = "First Name";
                dgvEvalranking.Columns[2].HeaderText = "Last Name";
                dgvEvalranking.Columns[3].HeaderText = "Middle Name";
                dgvEvalranking.Columns[4].HeaderText = "Rank";
                dgvEvalranking.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set the Rank column to sort automatically
                dgvEvalranking.Columns["Rank"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top performer records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            if (lblUsername.Text != "Admin")
            {
                btnReports.Visible = false;
                btnRecruitment.Visible = false;
                pbreport.Visible = false;
                pbeval.Visible = false;
            }
        }

        private void SaveEvaluation()
        {
            try
            {
                if (dgvEvalranking.CurrentRow == null)
                {
                    throw new Exception("Please select an employee to evaluate.");
                }

                // Get selected PRID
                int prid = GetSelectedEmployeePRID();

                conn.Open();

                // Calculate the ranking score based on the criteria
                int score = (int)(nudPunctuality.Value + nudPositiveAttitude.Value +
                                  nudCommunication.Value + nudAdaptability.Value + nudWorkQuality.Value);

                if (score < 0 || score > 15) // Validate the score range (5 categories * max 3 points = 15)
                {
                    throw new Exception("Invalid score. Ensure each criterion is scored between 0 and 3.");
                }

                // Insert or update the score in tblgeneralstatus
                string checkQuery = "SELECT COUNT(*) FROM tblgeneralstatus WHERE PRID = @PRID";
                cmd = new MySqlCommand(checkQuery, conn);
                cmd.Parameters.AddWithValue("@PRID", prid);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                string query;
                if (count > 0)
                {
                    // Update the score for the employee
                    query = "UPDATE tblgeneralstatus SET Ranking = @Ranking WHERE PRID = @PRID";
                }
                else
                {
                    // Insert a new record for the employee
                    query = "INSERT INTO tblgeneralstatus (PRID, Ranking) VALUES (@PRID, @Ranking)";
                }

                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PRID", prid);
                cmd.Parameters.AddWithValue("@Ranking", score);
                cmd.ExecuteNonQuery();

                // Recalculate and update rankings
                UpdateRankings();

                MessageBox.Show("Evaluation saved successfully, and rankings updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving evaluation: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    dgvEvalrankingRefresh();
                }
            }
        }

        private void UpdateRankings()
        {
            try
            {
                // Retrieve all employees and sort by score in descending order
                string selectQuery = "SELECT PRID, Ranking FROM tblgeneralstatus ORDER BY Ranking DESC";
                cmd = new MySqlCommand(selectQuery, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable rankingTable = new DataTable();
                adapter.Fill(rankingTable);

                // Update rank based on position in the sorted list
                int rank = 1;
                foreach (DataRow row in rankingTable.Rows)
                {
                    int prid = Convert.ToInt32(row["PRID"]);

                    string updateRankQuery = "UPDATE tblgeneralstatus SET Rank = @Rank WHERE PRID = @PRID";
                    MySqlCommand updateCmd = new MySqlCommand(updateRankQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Rank", rank);
                    updateCmd.Parameters.AddWithValue("@PRID", prid);
                    updateCmd.ExecuteNonQuery();

                    rank++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating rankings: " + ex.Message);
            }
        }

        private int GetSelectedEmployeePRID()
        {
            if (dgvEvalranking.CurrentRow != null)
            {
                return Convert.ToInt32(dgvEvalranking.CurrentRow.Cells["PRID"].Value);
            }
            throw new Exception("No employee selected.");
        }

        private void btnSaveEvaluation_Click(object sender, EventArgs e)
        {
            try
            {
                SaveEvaluation();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvEvalranking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index;
                index = e.RowIndex;
                DataGridViewRow row = dgvEvalranking.Rows[index];

                tbEmployeeName.Text = row.Cells[2].Value.ToString();
                tbEmployeeStanding.Text = row.Cells[4].Value.ToString();
            }
        }

        public void dgvEvalrankingRefresh()
        {
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();
                string query = "SELECT PR.Username, PR.First_Name, " +
                    "PR.Last_Name, PR.Middle_Name, GS.PRID, " +
                    "GS.Rank, GS.Ranking FROM tblPersonalRecords PR " +
                    "INNER JOIN tblGeneralStatus GS " +
                    "ON PR.PRID = GS.PRID " +
                    "ORDER BY GS.Rank ASC ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable TopPerformers = new DataTable();
                TopPerformers.Load(reader);
                dgvEvalranking.DataSource = TopPerformers;

                // Set the same Microsoft Sans Serif font for both regular and alternating rows
                dgvEvalranking.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                dgvEvalranking.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font

                if (dgvEvalranking.Rows.Count > 0)
                {
                    dgvEvalranking.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                    dgvEvalranking.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admin evaluation records. Please check the database connection and try again.\nDetails: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
