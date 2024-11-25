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
    public partial class Form6 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        string primarykeyvalue;

        int earnings, deductions, netpay;
        int standardpay, overtimepay, holidaypay, bonus, addpay;
        int tax, insurance, loan;

        public Form6()
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
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPayrollID.Text) || string.IsNullOrWhiteSpace(txtStandardPay.Text) || string.IsNullOrWhiteSpace(txtOvertimePay.Text) || string.IsNullOrWhiteSpace(txtHolidayPay.Text) || string.IsNullOrWhiteSpace(txtBonus.Text) || string.IsNullOrWhiteSpace(txtAddPay.Text) || string.IsNullOrWhiteSpace(txtTax.Text) || string.IsNullOrWhiteSpace(txtInsurance.Text) || string.IsNullOrWhiteSpace(txtLoan.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtPayrollID.Text))
                {
                    txtPayrollID.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtStandardPay.Text))
                {
                    txtStandardPay.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtOvertimePay.Text))
                {
                    txtOvertimePay.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtHolidayPay.Text))
                {
                    txtHolidayPay.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtBonus.Text))
                {
                    txtBonus.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtAddPay.Text))
                {
                    txtAddPay.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtTax.Text))
                {
                    txtTax.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtInsurance.Text))
                {
                    txtInsurance.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtLoan.Text))
                {
                    txtLoan.Focus();
                    Attention();
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to update this payroll record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (reader != null && !reader.IsClosed)
                        {
                            reader.Close();
                        }

                        conn.Open();

                        string query = "UPDATE tblPayroll AS P " +
                             "INNER JOIN tblPersonalRecords AS PR ON P.PRID = PR.PRID " +
                             "SET P.Standard_Pay = @standardpay, P.Overtime_Pay = @overtimepay, P.Holiday_Pay = @holidaypay, " +
                             "P.Bonus = @bonus, P.Add_Pay = @addpay, P.Tax = @tax, P.Insurance = @insurance, " +
                             "P.Loan = @loan, P.Earnings = @earnings, P.Deductions = @deductions, P.Net_Pay = @netpay " +
                             "WHERE P.PayrollID = @payrollID ";

                        cmd = new MySqlCommand(query, conn);

                        // Pending derived value
                        cmd.Parameters.AddWithValue("@standardpay", txtStandardPay.Text);
                        cmd.Parameters.AddWithValue("@overtimepay", txtOvertimePay.Text);
                        cmd.Parameters.AddWithValue("@holidaypay", txtHolidayPay.Text);
                        cmd.Parameters.AddWithValue("@bonus", txtBonus.Text);
                        cmd.Parameters.AddWithValue("@addpay", txtAddPay.Text);
                        cmd.Parameters.AddWithValue("@tax", txtTax.Text);
                        cmd.Parameters.AddWithValue("@insurance", txtInsurance.Text);
                        cmd.Parameters.AddWithValue("@loan", txtLoan.Text);

                        // Derived value
                        cmd.Parameters.AddWithValue("@earnings", txtEarnings.Text);
                        cmd.Parameters.AddWithValue("@deductions", txtDeductions.Text);
                        cmd.Parameters.AddWithValue("@netpay", txtNetPay.Text);

                        cmd.Parameters.AddWithValue("@payrollID", txtPayrollID.Text);
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);

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
                        dgvPayrollRefresh();
                    }
                }
            }
        }

        private void Attention()
        {
            MessageBox.Show("This should not be left blank", "Attention");
        }

        private void txtStandardPay_Leave(object sender, EventArgs e)
        {
            standardpay = Convert.ToInt32(txtStandardPay.Text);
            overtimepay = Convert.ToInt32(txtOvertimePay.Text);
            holidaypay = Convert.ToInt32(txtHolidayPay.Text);
            bonus = Convert.ToInt32(txtBonus.Text);
            addpay = Convert.ToInt32(txtAddPay.Text);
            earnings = standardpay + overtimepay + holidaypay + bonus + addpay;

            tax = Convert.ToInt32(txtTax.Text);
            insurance = Convert.ToInt32(txtInsurance.Text);
            loan = Convert.ToInt32(txtLoan.Text);
            deductions = tax + insurance + loan;

            netpay = earnings - deductions;

            txtEarnings.Text = earnings.ToString();
            txtDeductions.Text = deductions.ToString();
            txtNetPay.Text = netpay.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this payroll record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();

                    string query = "DELETE FROM tblPayroll " +
                                   "WHERE PayrollID = @payrollID ";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@payrollID", txtPayrollID.Text);

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
                    dgvPayrollRefresh();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the current form?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Clear();
                MessageBox.Show("Form Cleared");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtStandardPay.Text) || string.IsNullOrWhiteSpace(txtOvertimePay.Text) || string.IsNullOrWhiteSpace(txtHolidayPay.Text) || string.IsNullOrWhiteSpace(txtBonus.Text) || string.IsNullOrWhiteSpace(txtAddPay.Text) || string.IsNullOrWhiteSpace(txtTax.Text) || string.IsNullOrWhiteSpace(txtInsurance.Text) || string.IsNullOrWhiteSpace(txtLoan.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    txtUsername.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtStandardPay.Text))
                {
                    txtStandardPay.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtOvertimePay.Text))
                {
                    txtOvertimePay.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtHolidayPay.Text))
                {
                    txtHolidayPay.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtBonus.Text))
                {
                    txtBonus.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtAddPay.Text))
                {
                    txtAddPay.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtTax.Text))
                {
                    txtTax.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtInsurance.Text))
                {
                    txtInsurance.Focus();
                    Attention();
                }
                else if (string.IsNullOrWhiteSpace(txtLoan.Text))
                {
                    txtLoan.Focus();
                    Attention();
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save this payroll record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (reader != null && !reader.IsClosed)
                        {
                            reader.Close();
                        }

                        conn.Open();

                        string query = "INSERT INTO tblPayroll (PRID, Standard_Pay, Overtime_Pay, Holiday_Pay, Bonus, Add_Pay, Earnings, Tax, Insurance, Loan, Deductions, Net_Pay) " +
                                       "SELECT PRID, @standardpay, @overtimepay, @holidaypay, @bonus, @addpay, @earnings, @tax, @insurance, @loan, @deductions, @netpay " +
                                       "FROM tblPersonalRecords " +
                                       "WHERE Username = @username";

                        cmd = new MySqlCommand(query, conn);

                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        // Pending derived value
                        cmd.Parameters.AddWithValue("@standardpay", txtStandardPay.Text);
                        cmd.Parameters.AddWithValue("@overtimepay", txtOvertimePay.Text);
                        cmd.Parameters.AddWithValue("@holidaypay", txtHolidayPay.Text);
                        cmd.Parameters.AddWithValue("@bonus", txtBonus.Text);
                        cmd.Parameters.AddWithValue("@addpay", txtAddPay.Text);
                        cmd.Parameters.AddWithValue("@tax", txtTax.Text);
                        cmd.Parameters.AddWithValue("@insurance", txtInsurance.Text);
                        cmd.Parameters.AddWithValue("@loan", txtLoan.Text);

                        // Derived value
                        cmd.Parameters.AddWithValue("@earnings", txtEarnings.Text);
                        cmd.Parameters.AddWithValue("@deductions", txtDeductions.Text);
                        cmd.Parameters.AddWithValue("@netpay", txtNetPay.Text);

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
                        dgvPayrollRefresh();
                    }
                }
            }
        }

        public void dgvPayrollRefresh()
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
                    string query = "SELECT P.PayrollID, PR.Username, PR.First_Name, " +
                        "PR.Last_Name, PR.Middle_Name, " +
                        "P.Standard_Pay, P.Overtime_Pay, P.Holiday_Pay, P.Bonus, P.Add_Pay, P.Earnings, " +
                        "P.Tax, P.Insurance, P.Loan, P.Deductions, P.Net_Pay " +
                        "FROM tblPersonalRecords AS PR " +
                        "INNER JOIN tblPayroll AS P " +
                        "ON PR.PRID = P.PRID " +
                        "ORDER BY PR.First_Name ASC ";

                    cmd = new MySqlCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    DataTable Payroll = new DataTable();
                    Payroll.Load(reader);
                    dgvPayroll.DataSource = Payroll;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payroll records: " + ex.Message);
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
                    string query = "SELECT P.PayrollID, PR.Username, PR.First_Name, " +
                        "PR.Last_Name, PR.Middle_Name, " +
                        "P.Standard_Pay, P.Overtime_Pay, P.Holiday_Pay, P.Bonus, P.Add_Pay, P.Earnings, " +
                        "P.Tax, P.Insurance, P.Loan, P.Deductions, P.Net_Pay " +
                        "FROM tblPersonalRecords AS PR " +
                        "INNER JOIN tblPayroll AS P " +
                        "ON PR.PRID = P.PRID " +
                        "Where PR.Username = @username ";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", lblUsername.Text);
                    reader = cmd.ExecuteReader();

                    DataTable Payroll = new DataTable();
                    Payroll.Load(reader);
                    dgvPayroll.DataSource = Payroll;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payroll records: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    Clear();
                }
            }
        }

        public void Clear()
        {
            txtPayrollID.Clear();
            txtUsername.Clear();

            txtEarnings.Clear();
            txtDeductions.Clear();
            txtNetPay.Clear();

            txtStandardPay.Clear();
            txtOvertimePay.Clear();
            txtHolidayPay.Clear();
            txtBonus.Clear();
            txtAddPay.Clear();
            txtTax.Clear();
            txtInsurance.Clear();
            txtLoan.Clear();
        }

        private void dgvPayroll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index;
                index = e.RowIndex;
                DataGridViewRow row = dgvPayroll.Rows[index];
                string primaryKey = dgvPayroll.Rows[e.RowIndex].Cells[0].Value.ToString();
                primarykeyvalue = primaryKey;

                txtPayrollID.Text = row.Cells[0].Value.ToString();
                txtUsername.Text = row.Cells[1].Value.ToString();
                txtStandardPay.Text = row.Cells[5].Value.ToString();
                txtOvertimePay.Text = row.Cells[6].Value.ToString();
                txtHolidayPay.Text = row.Cells[7].Value.ToString();
                txtBonus.Text = row.Cells[8].Value.ToString();
                txtAddPay.Text = row.Cells[9].Value.ToString();
                txtEarnings.Text = row.Cells[10].Value.ToString();
                txtTax.Text = row.Cells[11].Value.ToString();
                txtInsurance.Text = row.Cells[12].Value.ToString();
                txtLoan.Text = row.Cells[13].Value.ToString();
                txtDeductions.Text = row.Cells[14].Value.ToString();
                txtNetPay.Text = row.Cells[15].Value.ToString();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            txtStandardPay.Text = "0";
            txtOvertimePay.Text = "0";
            txtHolidayPay.Text= "0";
            txtBonus.Text = "0";
            txtAddPay.Text = "0";
            txtTax.Text = "0";
            txtInsurance.Text = "0";
            txtLoan.Text = "0";

            if (lblUsername.Text == "Admin")
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();

                    string query = "SELECT P.PayrollID, PR.Username, PR.First_Name, " +
                        "PR.Last_Name, PR.Middle_Name, " +
                        "P.Standard_Pay, P.Overtime_Pay, P.Holiday_Pay, P.Bonus, P.Add_Pay, P.Earnings, " +
                        "P.Tax, P.Insurance, P.Loan, P.Deductions, P.Net_Pay " +
                        "FROM tblPersonalRecords PR " +
                        "INNER JOIN tblPayroll P " +
                        "ON PR.PRID = P.PRID " +
                        "ORDER BY PR.Last_Name ASC ";

                    cmd = new MySqlCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    DataTable Payroll = new DataTable();
                    Payroll.Load(reader);
                    dgvPayroll.DataSource = Payroll;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payroll records: " + ex.Message);
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

                    string query = "SELECT P.PayrollID, PR.Username, PR.First_Name, " +
                        "PR.Last_Name, PR.Middle_Name, " +
                        "P.Standard_Pay, P.Overtime_Pay, P.Holiday_Pay, P.Bonus, P.Add_Pay, P.Earnings, " +
                        "P.Tax, P.Insurance, P.Loan, P.Deductions, P.Net_Pay " +
                        "FROM tblPersonalRecords PR " +
                        "INNER JOIN tblPayroll P " +
                        "ON PR.PRID = P.PRID " +
                        "Where PR.Username = @username ";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", lblUsername.Text);
                    reader = cmd.ExecuteReader();

                    DataTable Payroll = new DataTable();
                    Payroll.Load(reader);
                    dgvPayroll.DataSource = Payroll;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payroll records: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                LoadData();

                panelAdmin.Visible = false;
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
    }
}
