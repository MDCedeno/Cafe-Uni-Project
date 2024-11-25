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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Cafe_Uni_Project.Form1;

namespace Cafe_Uni_Project
{
    public partial class Form5 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        string primarykeyvalue;

        public Form5()
        {
            InitializeComponent();
            lblUsername.Text = globalvariable.globalusername;
            txtDate.Text = DateTime.Now.ToString(("MMMM dd yyyy"));
            txtTime.Text = DateTime.Now.ToString(("h:mm tt"));
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

        private void btnTimeIn_Click(object sender, EventArgs e)
        {
            txtTimeIn.Text = DateTime.Now.ToString("h:mm tt");
        }

        private void btnTimeOut_Click(object sender, EventArgs e)
        {
            txtTimeOut.Text = DateTime.Now.ToString("h:mm tt");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Database Connection
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtTimeIn.Text) /*|| string.IsNullOrWhiteSpace(txtTimeOut.Text)*/ || string.IsNullOrWhiteSpace(dtpDate.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Focus();
                    MessageBox.Show("Username should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(txtTimeIn.Text))
                {
                    txtTimeIn.Focus();
                    MessageBox.Show("Time In should not be left blank", "Attention");
                }
                /*
                else if (string.IsNullOrWhiteSpace(txtTimeOut.Text))
                {
                    txtTimeOut.Focus();
                    MessageBox.Show("Time Out should not be left blank", "Attention");
                }
                */
                else if (string.IsNullOrWhiteSpace(dtpDate.Text))
                {
                    dtpDate.Focus();
                    MessageBox.Show("Record Date should not be left blank", "Attention");
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save this attendance record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (reader != null && !reader.IsClosed)
                        {
                            reader.Close();
                        }

                        conn.Open();

                        string query = "INSERT INTO tblAttendanceRecord (PRID, Time_In, Time_Out, Date) " +
               "SELECT PRID, @timeIn, @timeOut, @date " +
               "FROM tblPersonalRecords " +
               "WHERE Username = @username";

                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@timeIn", txtTimeIn.Text);
                        cmd.Parameters.AddWithValue("@timeOut", txtTimeOut.Text);
                        cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date.ToString("yyyyMMdd"));

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
                        dgvAttendanceTrackerRefresh();
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            MessageBox.Show("Username, Time In, Time Out, Record Date and RecordID Cleared");
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (lblUsername.Text == "Admin")
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();
                    string query = "SELECT AT.RecordID, PR.Username, PR.First_Name, " +
                        "PR.Last_Name, PR.Middle_Name, " +
                        "AT.Time_In, AT.Time_Out, AT.Date FROM tblPersonalRecords PR " +
                        "INNER JOIN tblAttendanceRecord AT " +
                        "ON PR.PRID = AT.PRID " +
                        "ORDER BY AT.RecordID DESC";

                    cmd = new MySqlCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    DataTable AttendanceTracker = new DataTable();
                    AttendanceTracker.Load(reader);
                    dgvAttendanceTracker.DataSource = AttendanceTracker;

                    // Set the same Microsoft Sans Serif font for both regular and alternating rows
                    dgvAttendanceTracker.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    dgvAttendanceTracker.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading attendance tracker records: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                LoadData();
            }
            else
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();
                    string query = "SELECT AT.RecordID, PR.Username, PR.First_Name, " +
                        "PR.Last_Name, PR.Middle_Name, " +
                        "AT.Time_In, AT.Time_Out, AT.Date FROM tblPersonalRecords PR " +
                        "INNER JOIN tblAttendanceRecord AT " +
                        "ON PR.PRID = AT.PRID " +
                        "Where PR.Username = @username ";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", lblUsername.Text);
                    reader = cmd.ExecuteReader();

                    DataTable AttendanceTracker = new DataTable();
                    AttendanceTracker.Load(reader);
                    dgvAttendanceTracker.DataSource = AttendanceTracker;

                    // Set the same Microsoft Sans Serif font for both regular and alternating rows
                    dgvAttendanceTracker.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    dgvAttendanceTracker.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading attendance tracker records: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                LoadData();

                btnReports.Visible = false;
                btnRecruitment.Visible = false;
                pbreport.Visible = false;
                pbeval.Visible = false;
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

        public void dgvAttendanceTrackerRefresh()
        {
            if (lblUsername.Text == "Admin")
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();
                    string query = "SELECT AT.RecordID, PR.Username, PR.First_Name, " +
                        "PR.Last_Name, PR.Middle_Name, " +
                        "AT.Time_In, AT.Time_Out, AT.Date FROM tblPersonalRecords PR " +
                        "INNER JOIN tblAttendanceRecord AT " +
                        "ON PR.PRID = AT.PRID " +
                        "ORDER BY AT.RecordID DESC";

                    cmd = new MySqlCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    DataTable AttendanceTracker = new DataTable();
                    AttendanceTracker.Load(reader);
                    dgvAttendanceTracker.DataSource = AttendanceTracker;

                    // Set the same Microsoft Sans Serif font for both regular and alternating rows
                    dgvAttendanceTracker.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    dgvAttendanceTracker.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading attendance tracker records: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    Clear();
                }
            }
            else
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();
                    string query = "SELECT AT.RecordID, PR.Username, PR.First_Name, " +
                        "PR.Last_Name, PR.Middle_Name, " +
                        "AT.Time_In, AT.Time_Out, AT.Date FROM tblPersonalRecords PR " +
                        "INNER JOIN tblAttendanceRecord AT " +
                        "ON PR.PRID = AT.PRID " +
                        "Where PR.Username = @username ";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", lblUsername.Text);
                    reader = cmd.ExecuteReader();

                    DataTable AttendanceTracker = new DataTable();
                    AttendanceTracker.Load(reader);
                    dgvAttendanceTracker.DataSource = AttendanceTracker;

                    // Set the same Microsoft Sans Serif font for both regular and alternating rows
                    dgvAttendanceTracker.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
                    dgvAttendanceTracker.AlternatingRowsDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular); // Disable alternating bold font
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading attendance tracker records: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    Clear();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtTimeIn.Text) || string.IsNullOrWhiteSpace(txtTimeOut.Text) || string.IsNullOrWhiteSpace(dtpDate.Text) || string.IsNullOrWhiteSpace(txtRecordID.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Focus();
                    MessageBox.Show("Username should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(txtTimeIn.Text))
                {
                    txtTimeIn.Focus();
                    MessageBox.Show("Time In should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(txtTimeOut.Text))
                {
                    txtTimeOut.Focus();
                    MessageBox.Show("Time Out should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(dtpDate.Text))
                {
                    dtpDate.Focus();
                    MessageBox.Show("Record Date should not be left blank", "Attention");
                }
                else if (string.IsNullOrWhiteSpace(txtRecordID.Text))
                {
                    txtRecordID.Focus();
                    MessageBox.Show("Record Date should not be left blank", "Attention");
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to update this attendance record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (reader != null && !reader.IsClosed)
                        {
                            reader.Close();
                        }

                        conn.Open();

                        string query = "UPDATE tblAttendanceRecord AS AT " +
                             "INNER JOIN tblPersonalRecords AS PR ON AT.PRID = PR.PRID " +
                             "SET AT.Time_In = @timeIn, AT.Time_Out = @timeOut, AT.Date = @date " +
                             "WHERE AT.RecordID = @recordID ";

                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@timeIn", txtTimeIn.Text);
                        cmd.Parameters.AddWithValue("@timeOut", txtTimeOut.Text);
                        cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date.ToString("yyyyMMdd"));
                        //cmd.Parameters.AddWithValue("@oldUsername", primarykeyvalue);
                        cmd.Parameters.AddWithValue("@recordID", txtRecordID.Text);

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
                        dgvAttendanceTrackerRefresh();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this attendance record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();

                    string query = "DELETE FROM tblAttendanceRecord " +
                                   "WHERE RecordID = @recordID ";
                         
                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@recordID", txtRecordID.Text);

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
                    dgvAttendanceTrackerRefresh();
                }
            }
        }

        public void Clear()
        {
            txtUsername.Clear();
            txtRecordID.Clear();
            txtTimeIn.Clear();
            txtTimeOut.Clear();
            dtpDate.ResetText();
        }

        private void dgvAttendanceTracker_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index;
                index = e.RowIndex;
                DataGridViewRow row = dgvAttendanceTracker.Rows[index];
                string primaryKey = dgvAttendanceTracker.Rows[e.RowIndex].Cells[0].Value.ToString();
                primarykeyvalue = primaryKey;

                txtRecordID.Text = row.Cells[0].Value.ToString();
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtTimeIn.Text = row.Cells[5].Value.ToString();
                txtTimeOut.Text = row.Cells[6].Value.ToString();
                dtpDate.Text = row.Cells[7].Value.ToString();
            }
        }
    }
}
