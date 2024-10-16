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
    public partial class Form7 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        string primarykeyvalue;

        public Form7()
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtStanding.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Focus();
                    MessageBox.Show("Username should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(txtStanding.Text))
                {
                    txtStanding.Focus();
                    MessageBox.Show("Standing should not be left blank", "Attention");
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to update this standing record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (reader != null && !reader.IsClosed)
                        {
                            reader.Close();
                        }

                        conn.Open();

                        string query = "UPDATE tblEmployeeStatus AS ES " +
                             "INNER JOIN tblPersonalRecords AS PR ON ES.PRID = PR.PRID " +
                             "SET ES.Standing = @standing " +
                             "WHERE PR.Username = @oldUsername";

                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@standing", txtStanding.Text);
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
                        dgvEmployeeStandingRefresh();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this standing record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();

                    string query = "DELETE FROM tblEmployeeStatus " +
                         "WHERE PRID IN (" +
                         "    SELECT ES.PRID " +
                         "    FROM tblEmployeeStatus AS ES " +
                         "    INNER JOIN tblPersonalRecords AS PR ON ES.PRID = PR.PRID " +
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
                    dgvEmployeeStandingRefresh();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            MessageBox.Show("Username and Standing Cleared");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtStanding.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Focus();
                    MessageBox.Show("Username should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(txtStanding.Text))
                {
                    txtStanding.Focus();
                    MessageBox.Show("Standing should not be left blank", "Attention");
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save this standing record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (reader != null && !reader.IsClosed)
                        {
                            reader.Close();
                        }

                        conn.Open();

                        string query = "INSERT INTO tblEmployeeStatus (PRID, Standing) " +
                                       "SELECT PRID, @standing " +
                                       "FROM tblPersonalRecords " +
                                       "WHERE Username = @username";

                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@standing", txtStanding.Text);

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
                        dgvEmployeeStandingRefresh();
                    }
                }
            }
        }

        public void Clear()
        {
            txtUsername.Clear();
            txtStanding.Clear();
        }

        private void dgvEmployeeStanding_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index;
                index = e.RowIndex;
                DataGridViewRow row = dgvEmployeeStanding.Rows[index];
                string primaryKey = dgvEmployeeStanding.Rows[e.RowIndex].Cells[0].Value.ToString();
                primarykeyvalue = primaryKey;

                txtUsername.Text = row.Cells[0].Value.ToString();
                txtStanding.Text = row.Cells[4].Value.ToString();
            }
        }

        public void dgvEmployeeStandingRefresh()
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
                    "ES.Standing FROM tblPersonalRecords AS PR " +
                    "INNER JOIN tblEmployeeStatus AS ES " +
                    "ON PR.PRID = ES.PRID ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable EmployeeStanding = new DataTable();
                EmployeeStanding.Load(reader);
                dgvEmployeeStanding.DataSource = EmployeeStanding;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top performer records: " + ex.Message);
            }
            finally
            {
                conn.Close();
                Clear();
            }
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

        private void Form7_Load(object sender, EventArgs e)
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
                    "ES.Standing FROM tblPersonalRecords AS PR " +
                    "INNER JOIN tblEmployeeStatus AS ES " +
                    "ON PR.PRID = ES.PRID ";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable EmployeeStanding = new DataTable();
                EmployeeStanding.Load(reader);
                dgvEmployeeStanding.DataSource = EmployeeStanding;
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
            }
        }
    }
}
