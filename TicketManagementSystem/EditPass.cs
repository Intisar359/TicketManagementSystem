using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class EditPass : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";
        private string userEmail;

        public EditPass(string email)
        {
            InitializeComponent();
            this.userEmail = email;
        }

        private void EditPass_Load(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ForgotPass forgotPassForm = new ForgotPass();
            forgotPassForm.Show();
            this.Hide();
        }

        private bool ValidatePassword(string password)
        {
            return ValidationHelper.IsValidPassword(password);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string retypePassword = txtRetypePassword.Text;

            if (password != retypePassword)
            {
                MessageBox.Show("Passwords do not match. Please make sure both passwords are the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidatePassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long, contain uppercase, lowercase, and a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE UserInfo SET Password = @Password WHERE Email = @Email";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Email", userEmail);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while updating the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnShowRetypePassword_Click(object sender, EventArgs e)
        {
            if (txtRetypePassword.UseSystemPasswordChar)
            {
                txtRetypePassword.UseSystemPasswordChar = false;
                btnShowRetypePassword.Text = "";
            }
            else
            {
                txtRetypePassword.UseSystemPasswordChar = true;
                btnShowRetypePassword.Text = "";
            }
        }

        private void EditPass_Load_1(object sender, EventArgs e)
        {
        }
    }
}
