using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class ProfileForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True\r\n";
        private string userName; 

        public ProfileForm(string userName)
        {
            InitializeComponent();
            this.userName = userName; 
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
           
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM UserInfo WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", userName);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        
                        lblID.Text = "ID: " + reader["ID"].ToString();
                        lblFirstName.Text = "First Name: " + reader["FirstName"].ToString();
                        lblSurname.Text = "Surname: " + reader["SurName"].ToString();

                       
                        DateTime dob = Convert.ToDateTime(reader["DOB"]);
                        lblDOB.Text = "Date of Birth: " + dob.ToString("yyyy-MM-dd");

                        lblGender.Text = "Gender: " + reader["Gender"].ToString();
                        lblEmail.Text = "Email: " + reader["Email"].ToString();
                        labelNum.Text = "Number: " + reader["Number"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("User details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            UserDashboard userDashboard = new UserDashboard(userName);
            userDashboard.Show();
        }

        
    }
}