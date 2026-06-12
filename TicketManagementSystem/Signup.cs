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
    public partial class SignupForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True\r\n"; // Replace with actual server and database details

        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            string number = textNumber.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string dob = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string gender = radioButton1.Checked ? "Male" : "Female"; 

            
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(number) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Fields cannot be empty. Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            
            if (firstName[0] != Char.ToUpper(firstName[0]))
            {
                MessageBox.Show("First name must start with an uppercase letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (surname[0] != Char.ToUpper(surname[0]))
            {
                MessageBox.Show("Surname must start with an uppercase letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!ValidationHelper.IsValidUsername(username))
            {
                MessageBox.Show("Username must be exactly 8 characters long, contain at least one special character and number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!ValidationHelper.IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain a mix of uppercase, lowercase, and numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (string.IsNullOrEmpty(number) || number.Length != 11 || !number.All(char.IsDigit))
            {
                textNumber.ForeColor = System.Drawing.Color.Green;
                MessageBox.Show("Please enter a valid 11-digit mobile number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            else
            {
                
                textNumber.ForeColor = System.Drawing.Color.Red;
            }

           
            int age = DateTime.Now.Year - dateTimePicker1.Value.Year;
            if (dateTimePicker1.Value.Date > DateTime.Now.AddYears(-age)) age--; 

            if (age < 18)
            {
                MessageBox.Show("User must be 18 years old.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkEmailQuery = "SELECT COUNT(*) FROM UserInfo WHERE Email = @Email";
                    using (SqlCommand checkEmailCommand = new SqlCommand(checkEmailQuery, connection))
                    {
                        checkEmailCommand.Parameters.AddWithValue("@Email", email);
                        int emailExists = (int)checkEmailCommand.ExecuteScalar();
                        if (emailExists > 0)
                        {
                            MessageBox.Show("A user already exists with this email. Please choose a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    
                    string checkNumberQuery = "SELECT COUNT(*) FROM UserInfo WHERE Number = @Number";
                    using (SqlCommand checkNumberCommand = new SqlCommand(checkNumberQuery, connection))
                    {
                        checkNumberCommand.Parameters.AddWithValue("@Number", number);
                        int numberExists = (int)checkNumberCommand.ExecuteScalar();
                        if (numberExists > 0)
                        {
                            MessageBox.Show("A user already exists with this mobile number. Please choose a different number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    
                    string checkUsernameQuery = "SELECT COUNT(*) FROM UserInfo WHERE UserName = @UserName";
                    using (SqlCommand checkUsernameCommand = new SqlCommand(checkUsernameQuery, connection))
                    {
                        checkUsernameCommand.Parameters.AddWithValue("@UserName", username);
                        int usernameExists = (int)checkUsernameCommand.ExecuteScalar();
                        if (usernameExists > 0)
                        {
                            MessageBox.Show("This username is already taken. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "INSERT INTO UserInfo (FirstName, SurName, DOB, Gender, Email, Number, UserName, Password) VALUES (@FirstName, @SurName, @DOB, @Gender, @Email, @Number, @UserName, @Password)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@SurName", surname);
                        command.Parameters.AddWithValue("@DOB", dob);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Number", number);
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@Password", password); 

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                
                MessageBox.Show("Account Created Successfully! Please log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide(); 
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"An error occurred while connecting to the database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
        
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            
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

        private void btnShowConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.UseSystemPasswordChar)
            {
                txtConfirmPassword.UseSystemPasswordChar = false;
                btnShowConfirmPassword.Text = "";
            }
            else
            {
                txtConfirmPassword.UseSystemPasswordChar = true;
                btnShowConfirmPassword.Text = "";
            }
        }

        private void textBoxNumber_TextChanged(object sender, EventArgs e)
        {
        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}