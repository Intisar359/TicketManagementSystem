using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class ForgotPass : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";

        public ForgotPass()
        {
            InitializeComponent();
        }

        private void ForgotPass_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           
            string email = txtEmail.Text;
            string number = txtNumber.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(number))
            {
                MessageBox.Show("Please fill in both email and phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM UserInfo WHERE Email = @Email AND Number = @Number";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Number", number);

                        int userExists = (int)command.ExecuteScalar();

                        if (userExists > 0)
                        {
                           
                            EditPass editPassForm = new EditPass(email);
                            editPassForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            
                            MessageBox.Show("Wrong email or phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while validating: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ForgotPass_Load_1(object sender, EventArgs e)
        {

        }

        private void lblNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
