using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Cafe_Uni_Project.Form1;

namespace Cafe_Uni_Project
{
    public partial class Form2 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        int validate = 0;
        string primarykeyvalue;

        public Form2()
        {
            InitializeComponent();
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
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

        private void Form2_Load(object sender, EventArgs e)
        {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();

                    string query = "SELECT Username, Password, First_Name, Last_Name, Middle_Name, Age, " +
                        "Address, Educational_Attainment, Gender, Birthdate, Skills, Email, " +
                        "Contact_Number, Picture FROM tblPersonalRecords";

                    cmd = new MySqlCommand(query, conn);
                    reader = cmd.ExecuteReader();

                    DataTable PersonalRecords = new DataTable();
                    PersonalRecords.Load(reader);
                    dgvPersonalRecords.DataSource = PersonalRecords;

                    // Set the size mode of the Picture column to Stretch
                    if (dgvPersonalRecords.Columns["Picture"] is DataGridViewImageColumn pictureColumn)
                    {
                        pictureColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading personal records: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                LoadData();

                if (lblUsername.Text != "Admin")
                {
                    // If the user is not "Admin", load the user's information directly
                    LoadUserData(lblUsername.Text);

                    btnUpload.Visible = false;
                    panelAdmin.Visible = false;
                    btnReports.Visible = false;
                    btnRecruitment.Visible = false;
                }
        }

        private void LoadUserData(string username)
        {
            try
            {
                conn.Open();
                string query = "SELECT Username, Password, First_Name, Last_Name, Middle_Name, Age, " +
                    "Address, Educational_Attainment, Gender, Birthdate, Skills, Email, " +
                    "Contact_Number, Picture FROM tblPersonalRecords WHERE Username = @username";

                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Populate the form fields with user information
                    txtUsername.Text = reader["Username"].ToString();
                    txtPassword.Text = reader["Password"].ToString();
                    txtFirstname.Text = reader["First_Name"].ToString();
                    txtLastname.Text = reader["Last_Name"].ToString();
                    txtMiddlename.Text = reader["Middle_Name"].ToString();
                    txtAge.Text = reader["Age"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtEducation.Text = reader["Educational_Attainment"].ToString();
                    txtGender.Text = reader["Gender"].ToString();
                    dtpBirthdate.Text = reader["Birthdate"].ToString();
                    txtSkills.Text = reader["Skills"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtContact.Text = reader["Contact_Number"].ToString();

                    // Load the user's picture
                    byte[] imageData = (byte[])reader["Picture"];
                    MemoryStream ms = new MemoryStream(imageData);
                    pbPicture.Image = Image.FromStream(ms);
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user data: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void dgvPersonalRecordRefresh()
        {
            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }

                conn.Open();
                string query = "SELECT Username, Password, First_Name, Last_Name, Middle_Name, Age, " +
                    "Address, Educational_Attainment, Gender, Birthdate, Skills, Email, " +
                    "Contact_Number, Picture FROM tblPersonalRecords";

                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable PersonalRecords = new DataTable();
                PersonalRecords.Load(reader);
                dgvPersonalRecords.DataSource = PersonalRecords;

                // Set the size mode of the Picture column to Stretch
                if (dgvPersonalRecords.Columns["Picture"] is DataGridViewImageColumn pictureColumn)
                {
                    pictureColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading personal records: " + ex.Message);
            }
            finally
            {
                conn.Close();
                Clear();
            }
        }

        private void dgvPersonalRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int index;
                index = e.RowIndex;
                DataGridViewRow row = dgvPersonalRecords.Rows[index];
                string primaryKey = dgvPersonalRecords.Rows[e.RowIndex].Cells[0].Value.ToString();
                primarykeyvalue = primaryKey;

                txtUsername.Text = row.Cells[0].Value.ToString();
                txtPassword.Text = row.Cells[1].Value.ToString();
                txtFirstname.Text = row.Cells[2].Value.ToString();
                txtLastname.Text = row.Cells[3].Value.ToString();
                txtMiddlename.Text = row.Cells[4].Value.ToString();
                txtAge.Text = row.Cells[5].Value.ToString();
                txtAddress.Text = row.Cells[6].Value.ToString();
                txtEducation.Text = row.Cells[7].Value.ToString();
                txtGender.Text = row.Cells[8].Value.ToString();
                dtpBirthdate.Text = row.Cells[9].Value.ToString();
                txtSkills.Text = row.Cells[10].Value.ToString();
                txtEmail.Text = row.Cells[11].Value.ToString();
                txtContact.Text = row.Cells[12].Value.ToString();

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
                    cmd.Parameters.AddWithValue("@username", primarykeyvalue);

                    // Execute the query to retrieve the picture data
                    byte[] imageData = (byte[])cmd.ExecuteScalar();

                    // Convert the byte array to a memory stream
                    MemoryStream ms = new MemoryStream(imageData);

                    // Set the picture box image from the memory stream
                    pbPicture.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in loading the record picture: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update this personal record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();

                    // Convert the image to byte array
                    byte[] imageBytes = ImageToByteArray(pbPicture.Image);

                    string query = "UPDATE tblPersonalRecords SET " +
                "Username = @username, " +
                "Password = @password, " +
                "First_Name = @firstname, " +
                "Last_Name = @lastname, " +
                "Middle_Name = @middlename, " +
                "Birthdate = @birthdate, " +
                "Age = @age, " +
                "Gender = @gender, " +
                "Address = @address, " +
                "Educational_Attainment = @education, " +
                "Skills = @skills, " +
                "Email = @email, " +
                "Contact_Number = @contact, " +
                "Picture = @picture " +
                "WHERE Username = @oldUsername";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtLastname.Text);
                    cmd.Parameters.AddWithValue("@middlename", txtMiddlename.Text);
                    cmd.Parameters.AddWithValue("@birthdate", dtpBirthdate.Value.Date.ToString("yyyyMMdd"));
                    cmd.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@gender", txtGender.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@education", txtEducation.Text);
                    cmd.Parameters.AddWithValue("@skills", txtSkills.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@picture", imageBytes);
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
                    dgvPersonalRecordRefresh();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this personal record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();
                    string query = "DELETE FROM tblPersonalRecords WHERE Username = '"+primarykeyvalue+"'";
                    
                    cmd = new MySqlCommand(query, conn);
                    //reader = cmd.ExecuteReader();

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
                    dgvPersonalRecordRefresh();
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

        public void Clear()
        {
                txtGender.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtFirstname.Clear();
                txtLastname.Clear();
                txtMiddlename.Clear();
                txtEmail.Clear();
                dtpBirthdate.ResetText();
                txtContact.Clear();
                txtAddress.Clear();
                txtAge.Clear();
                txtSkills.Clear();
                txtEducation.Clear();
                pbPicture.Image = null;

                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                validate = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this personal record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (reader != null && !reader.IsClosed)
                    {
                        reader.Close();
                    }

                    conn.Open();

                    // Convert the image to byte array
                    byte[] imageBytes = ImageToByteArray(pbPicture.Image);

                    string query = "INSERT INTO tblPersonalRecords (Username, Password," +
                        " First_Name, Last_Name, Middle_Name, Birthdate, Age, Gender, Address, Educational_Attainment," +
                        " Skills, Email , Contact_Number, Picture) VALUES (@username, @password, @firstname, @lastname, @middlename," +
                        " @birthdate, @age, @gender, @address, @education, @skills, @email, @contact, @picture)";

                    cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text);
                    cmd.Parameters.AddWithValue("@lastname", txtLastname.Text);
                    cmd.Parameters.AddWithValue("@middlename", txtMiddlename.Text);
                    cmd.Parameters.AddWithValue("@birthdate", dtpBirthdate.Value.Date.ToString("yyyyMMdd"));
                    cmd.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@gender", txtGender.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@education", txtEducation.Text);
                    cmd.Parameters.AddWithValue("@skills", txtSkills.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@picture", imageBytes);

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
                    dgvPersonalRecordRefresh();
                }
            }
        }

        // Method to convert image to byte array
        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg); // You can change the ImageFormat as per your requirement
            return ms.ToArray();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Choose image (*.jpg; *.png; *.gif ) | *.jpg; *.png; *.gif";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pbPicture.Image = System.Drawing.Image.FromFile(dlg.FileName);
            }
            validate = validate + 1;
            if (validate >= 1)
            {
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void dtpBirthdate_Leave(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            var age = today.Year - dtpBirthdate.Value.Year;
            txtAge.Text = age.ToString();
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
                MemoryStream memory = new MemoryStream(imageData);

                // Set the picture box image from the memory stream
                pbUserPicture.Image = Image.FromStream(memory);
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
