using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Cafe_Uni_Project
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource = localhost; username = root; password =; database = dbcafeuniproject");
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader;
        
        public Form1()
        {
            InitializeComponent();
        }

        public class globalvariable
        {
            public static string globalusername;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            globalvariable.globalusername = username;

            try
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();
                }
                conn.Open();
                string query = "SELECT * FROM tblPersonalRecords WHERE Username = '" + username + "' AND Password = '" + password + "'";
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    if (txtUsername.Text == "Admin")
                    {
                        MessageBox.Show("Login Successful for Admin", "Welcome to Cafe Uni");
                        this.Hide();
                        globalvariable.globalusername = username;
                        Form4 Dashboard = new Form4();
                        Dashboard.ShowDialog();
                    }
                    else 
                    {
                        MessageBox.Show("Login Successful for Employee", "Welcome to Cafe Uni");
                        this.Hide();
                        Form4 Dashboard = new Form4();
                        Dashboard.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Login, Username or Password is incorrect!"); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loging the account: " + ex.Message); 
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Signup = new Form3();
            Signup.ShowDialog();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void pbEyelog_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                pbEyelog.Image = Image.FromFile("../Pics/Hide Eye 1.png");
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                pbEyelog.Image = Image.FromFile("../Pics/Show Eye 1.png");
            }
        }
    }
}
