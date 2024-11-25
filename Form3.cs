using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
    public partial class Form3 : Form
    {
        String gender = "";
        int validate = 0;

        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;

        public Form3()
        {
            InitializeComponent();
            btnSign.Enabled = false;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtMiddlename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        public void RadioButtons()
        {
            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked)
            {
                gender = "Female";
            }

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            RadioButtons();
            // Database Connection
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
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text);
                cmd.Parameters.AddWithValue("@lastname", txtLastname.Text);
                cmd.Parameters.AddWithValue("@middlename", txtMiddlename.Text);
                cmd.Parameters.AddWithValue("@birthdate", dtpBirthdate.Value.Date.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@age", txtAge.Text);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@education", cbEducation.SelectedItem);
                cmd.Parameters.AddWithValue("@skills", txtSkills.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@picture", imageBytes);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Congratulations, your account has been successfully created");
                    this.Hide();
                    Form1 Login = new Form1();
                    Login.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Something went wrong, User sign up failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in sign up process: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        // Method to convert image to byte array
        private byte[] ImageToByteArray(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg); // You can change the ImageFormat as per your requirement
            return ms.ToArray();
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clear the existing form?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Clear();
            }
        }

        public void Clear()
        {
            if (MessageBox.Show("Are you sure you want to clear the current form?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rbMale.Checked = false;
                rbFemale.Checked = false;
                txtUsername.Clear();
                txtPass.Clear();
                txtFirstname.Clear();
                txtLastname.Clear();
                txtMiddlename.Clear();
                txtEmail.Clear();
                dtpBirthdate.ResetText();
                txtContact.Clear();
                txtAddress.Clear();
                txtAge.Clear();
                txtSkills.Clear();
                cbEducation.SelectedIndex = 0;
                pbPicture.Image = null;

                btnSign.Enabled = false;
                validate = 0;

                MessageBox.Show("Form Cleared");
            }
        }

        private void pbEye_Click(object sender, EventArgs e)
        {
            if (txtPass.UseSystemPasswordChar == true)
            {
                txtPass.UseSystemPasswordChar = false;
                pbEye.Image = Image.FromFile("../Pics/Hide Eye 1.png");
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                pbEye.Image = Image.FromFile("../Pics/Show Eye 1.png");
            }
        }

        private void dtpBirthdate_Leave(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            var age = today.Year - dtpBirthdate.Value.Year;
            txtAge.Text = age.ToString();
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
                btnSign.Enabled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Login = new Form1();
            Login.ShowDialog();
        }
    }
}