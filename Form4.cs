using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Cafe_Uni_Project.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cafe_Uni_Project
{
    public partial class Form4 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        string primarykeyvalue;

        public Form4()
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

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();  
            Login.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtRanking.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Focus();
                    MessageBox.Show("Username should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(txtRanking.Text))
                {
                    txtRanking.Focus();
                    MessageBox.Show("Ranking should not be left blank", "Attention");
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to update this ranking record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (reader != null && !reader.IsClosed)
                        {
                            reader.Close();
                        }

                        conn.Open();

                        string query = "UPDATE tblGeneralStatus AS GS " +
                             "INNER JOIN tblPersonalRecords AS PR ON GS.PRID = PR.PRID " +
                             "SET GS.Ranking = @ranking " +
                             "WHERE PR.Username = @oldUsername";

                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ranking", txtRanking.Text);
                        cmd.Parameters.AddWithValue("@oldUsername", primarykeyvalue);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully");
                        }
                        else
                        {
                            MessageBox.Show("Record not found or updating failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in updating record: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        // Refresh DataGridView
                        dgvTopPerformerRefresh();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this ranking record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();

                    string query = "DELETE FROM tblGeneralStatus " +
                         "WHERE PRID IN (" +
                         "    SELECT GS.PRID " +
                         "    FROM tblGeneralStatus AS GS " +
                         "    INNER JOIN tblPersonalRecords AS PR ON GS.PRID = PR.PRID " +
                         "    WHERE PR.Username = @oldUsername)";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@oldUsername", primarykeyvalue);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Record not found or deletion failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in deleting record: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    // Refresh DataGridView
                    dgvTopPerformerRefresh();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtRanking.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Focus();
                    MessageBox.Show("Username should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(txtRanking.Text))
                {
                    txtRanking.Focus();
                    MessageBox.Show("Ranking should not be left blank", "Attention");
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save this ranking record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (reader != null && !reader.IsClosed)
                        {
                            reader.Close();
                        }

                        conn.Open();

                        string query = "INSERT INTO tblGeneralStatus (PRID, Ranking) " +
               "SELECT PRID, @ranking " +
               "FROM tblPersonalRecords " +
               "WHERE Username = @username";

                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@ranking", txtRanking.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record saved successfully");
                        }
                        else
                        {
                            MessageBox.Show("Record not found or saving failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in saving record: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        // Refresh DataGridView
                        dgvTopPerformerRefresh();
                    }
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();

                string query = "SELECT PR.Username, PR.First_Name, " +
                    "PR.Last_Name, PR.Middle_Name, " +
                    "GS.Rank FROM tblPersonalRecords PR " +
                    "INNER JOIN tblGeneralStatus GS " +
                    "ON PR.PRID = GS.PRID " +
                    "ORDER BY GS.Rank ASC " +
                    "LIMIT 10 ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable TopPerformers = new DataTable();
                TopPerformers.Load(reader);
                dgvTopPerformers.DataSource = TopPerformers;

                // Set the same Microsoft Sans Serif font for both regular and alternating rows
                dgvTopPerformers.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                dgvTopPerformers.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font

                if (dgvTopPerformers.Rows.Count > 0)
                {
                    dgvTopPerformers.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                    dgvTopPerformers.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
                }

                // Formatting the DataGridView
                dgvTopPerformers.Columns[0].HeaderText = "Username";
                dgvTopPerformers.Columns[1].HeaderText = "First Name";
                dgvTopPerformers.Columns[2].HeaderText = "Last Name";
                dgvTopPerformers.Columns[3].HeaderText = "Middle Name";
                dgvTopPerformers.Columns[4].HeaderText = "Rank";
                dgvTopPerformers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set the Rank column to sort automatically
                dgvTopPerformers.Columns["Rank"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top performer records: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            LoadData();

            if (lblUsername.Text != "Admin")
            {
                panelAdmin.Visible = false;
                btnReports.Visible = false;
                btnRecruitment.Visible = false;
                pbreport.Visible = false;
                pbeval.Visible = false;
            }
        }

        public void LoadData()
        {
            // Data for start Date
            try
            {
                // Clear existing data in the chart
                chartEmployeeDates.Series["Date of Recruitment"].Points.Clear();

                conn.Open();

                // Query to get the number of employees who started each year
                string query = @"
                    SELECT 
                    YEAR(StartDate) AS StartYear, 
                    COUNT(*) AS EmployeesStarted
                    FROM tblPersonalRecords
                    WHERE StartDate IS NOT NULL
                    GROUP BY YEAR(StartDate)
                    ORDER BY StartYear";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                // Iterate through the data and add points to the chart
                while (reader.Read())
                {
                    int startYear = reader.GetInt32("StartYear");
                    int employeesStarted = reader.GetInt32("EmployeesStarted");

                    // Add the data to the chart
                    chartEmployeeDates.Series["Date of Recruitment"].Points.AddXY(startYear, employeesStarted);
                }

                // Set the chart type to Line
                chartEmployeeDates.Series["Date of Recruitment"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                // Optional: Set color for the line
                chartEmployeeDates.Series["Date of Recruitment"].Color = Color.Plum;

                // Optional: Set line width
                chartEmployeeDates.Series["Date of Recruitment"].BorderWidth = 3;

                // Optional: Set marker for each point
                chartEmployeeDates.Series["Date of Recruitment"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                chartEmployeeDates.Series["Date of Recruitment"].MarkerSize = 8;

                // Set the X-axis and Y-axis titles
                chartEmployeeDates.ChartAreas[0].AxisX.Title = "Year";
                chartEmployeeDates.ChartAreas[0].AxisY.Title = "Employees Started";

                // Set the background color of the chart area
                chartEmployeeDates.ChartAreas[0].BackColor = Color.LightYellow;

                // Enable gridlines for the X-axis and Y-axis
                //chartEmployeeDates.ChartAreas[0].AxisX.GridLineStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                chartEmployeeDates.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
                //chartEmployeeDates.ChartAreas[0].AxisY.GridLineStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                chartEmployeeDates.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;

                // Set a border around the chart area
                chartEmployeeDates.ChartAreas[0].BorderColor = Color.Black;
                chartEmployeeDates.ChartAreas[0].BorderWidth = 2;
                chartEmployeeDates.ChartAreas[0].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading employee start dates: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            // Data for total employee and total recruits
            try
            {
                // Retrieve total number of employees
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();
                string query = "SELECT COUNT(*) FROM tblPersonalRecords";
                cmd = new MySqlCommand(query, conn);
                int numberOfEmployees = Convert.ToInt32(cmd.ExecuteScalar());
                //txtTotalEmployees.Text = numberOfEmployees.ToString();

                // Retrieve total number of recruits
                query = "SELECT COUNT(Standing) FROM tblEmployeeStatus WHERE Standing = 'Recruit'";
                cmd = new MySqlCommand(query, conn);
                int numberOfRecruit = Convert.ToInt32(cmd.ExecuteScalar());
                //txtTotalRecruit.Text = numberOfRecruit.ToString();

                // Display data in the pie chart
                chartEmployeeStats.Series["EmployeeStats"].Points.Clear();  // Clear existing data

                // Add data points to the pie chart
                chartEmployeeStats.Series["EmployeeStats"].Points.AddXY("Employees", numberOfEmployees);
                chartEmployeeStats.Series["EmployeeStats"].Points.AddXY("Recruits", numberOfRecruit);

                // Set the chart type to Pie
                chartEmployeeStats.Series["EmployeeStats"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                // Optional: Set colors for the chart
                chartEmployeeStats.Series["EmployeeStats"].Points[0].Color = Color.LightCoral;
                chartEmployeeStats.Series["EmployeeStats"].Points[1].Color = Color.PowderBlue;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading employee data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

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

            // Data for highest earnings
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();

                string query = "SELECT Earnings FROM tblPayroll " +
                    "ORDER BY Earnings DESC " +
                    "LIMIT 1 ";

                cmd = new MySqlCommand(query, conn);

                // Execute the query and get the result
                int highestEarnings = Convert.ToInt32(cmd.ExecuteScalar());

                txtHighestEarnings.Text = highestEarnings.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading the highest earnings: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void dgvTopPerformerRefresh()
        {
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
                    "ORDER BY GS.Rank ASC " +
                    "LIMIT 10 ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable TopPerformers = new DataTable();
                TopPerformers.Load(reader);
                dgvTopPerformers.DataSource = TopPerformers;

                // Set the same Microsoft Sans Serif font for both regular and alternating rows
                dgvTopPerformers.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                dgvTopPerformers.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font

                if (dgvTopPerformers.Rows.Count > 0)
                {
                    dgvTopPerformers.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                    dgvTopPerformers.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
                }

                // Formatting the DataGridView
                dgvTopPerformers.Columns[0].HeaderText = "Username";
                dgvTopPerformers.Columns[1].HeaderText = "First Name";
                dgvTopPerformers.Columns[2].HeaderText = "Last Name";
                dgvTopPerformers.Columns[3].HeaderText = "Middle Name";
                dgvTopPerformers.Columns[4].HeaderText = "Ranking";
                dgvTopPerformers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set the Ranking column to sort automatically
                dgvTopPerformers.Columns["Ranking"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top performer records. Please check the database connection and try again.\nDetails: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                Clear();
            }
        }

        private void dgvTopPerformers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index;
                index = e.RowIndex;
                DataGridViewRow row = dgvTopPerformers.Rows[index];
                string primaryKey = dgvTopPerformers.Rows[e.RowIndex].Cells[0].Value.ToString();
                primarykeyvalue = primaryKey;

                txtUsername.Text = row.Cells[0].Value.ToString();
                txtRanking.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            MessageBox.Show("Username and Ranking Cleared");
        }

        public void Clear()
        {
            txtUsername.Clear();
            txtRanking.Clear();
        }
    }
}
