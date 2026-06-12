using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True\r\n";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please select ADMIN or USER.", "Role Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = radioButton2.Checked ? "User" : "Admin";

            if (!ValidationHelper.IsValidUsername(username))

            {
                MessageBox.Show("Username must contain 8 Characters with number and special character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidationHelper.IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain a mix of uppercase, lowercase, and numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = string.Empty;
                    SqlCommand command = null;

                    if (role == "User")
                    {
                        query = "SELECT COUNT(*) FROM UserInfo WHERE UserName = @UserName AND Password = @Password";
                    }
                    else if (role == "Admin")
                    {
                        query = "SELECT COUNT(*) FROM AdminPass WHERE Name = @Name AND AdminPassword = @AdminPassword";
                    }

                    try
                    {
                        command = new SqlCommand(query, connection);

                        if (role == "User")
                        {
                            command.Parameters.AddWithValue("@UserName", username);
                            command.Parameters.AddWithValue("@Password", password);
                        }
                        else if (role == "Admin")
                        {
                            command.Parameters.AddWithValue("@Name", username);
                            command.Parameters.AddWithValue("@AdminPassword", password);
                        }

                        int userCount = (int)command.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (role == "User")
                            {
                                this.Hide();
                                UserDashboard userDashboard = new UserDashboard(username);
                                userDashboard.Show();
                            }
                            else
                            {
                                this.Hide();
                                AdminDashboard adminDashboard = new AdminDashboard(username);
                                adminDashboard.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException sqlEx)
                    {
                        MessageBox.Show($"SQL Error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Unexpected Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPassword.Text = "";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPassword.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePageForm homePage = new HomePageForm();
            homePage.Show();
        }

        private void lblSignup_Click(object sender, EventArgs e)
        {
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButtonAdmin_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void lblSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignupForm().Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ForgotPass().Show();
            this.Hide();
        }
    }
}
