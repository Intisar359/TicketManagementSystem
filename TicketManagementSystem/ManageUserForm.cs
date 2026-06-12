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
    public partial class ManageUserForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;";
        private AdminDashboard adminDashboard;

        public ManageUserForm(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
        }

        private void ManageUserForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM UserInfo";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewUserInfo.DataSource = dataTable;
                    connection.Close();
                }

                dataGridViewUserInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridViewUserInfo.ScrollBars = ScrollBars.Both;
                dataGridViewUserInfo.RowHeadersVisible = false;
                dataGridViewUserInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewUserInfo.ReadOnly = true;

                dataGridViewUserInfo.AllowUserToAddRows = false;
                dataGridViewUserInfo.AllowUserToDeleteRows = false;
                dataGridViewUserInfo.AllowUserToOrderColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminDashboard.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFirstName.Text;
                string surName = txtSurName.Text;
                DateTime dob = dtpDOB.Value;
                string gender = txtGender.Text;
                string number = txtNumber.Text;
                string email = txtEmail.Text;
                string userName = txtUserName.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surName) || string.IsNullOrEmpty(gender) ||
                    string.IsNullOrEmpty(number) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please fill in all the fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO UserInfo (FirstName, SurName, DOB, Gender, Number, Email, UserName, Password) " +
                                   "VALUES (@FirstName, @SurName, @DOB, @Gender, @Number, @Email, @UserName, @Password)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@SurName", surName);
                    command.Parameters.AddWithValue("@DOB", dob);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Number", number);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error adding user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUserInfo.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRowIndex = dataGridViewUserInfo.SelectedRows[0].Index;
                int userId = Convert.ToInt32(dataGridViewUserInfo.Rows[selectedRowIndex].Cells["ID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM UserInfo WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", userId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUserInfo.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRowIndex = dataGridViewUserInfo.SelectedRows[0].Index;
                int userId = Convert.ToInt32(dataGridViewUserInfo.Rows[selectedRowIndex].Cells["ID"].Value);
                string firstName = txtFirstName.Text;
                string surName = txtSurName.Text;
                DateTime dob = dtpDOB.Value;
                string gender = txtGender.Text;
                string number = txtNumber.Text;
                string email = txtEmail.Text;
                string userName = txtUserName.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(surName) || string.IsNullOrEmpty(gender) ||
                    string.IsNullOrEmpty(number) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please fill in all the fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE UserInfo SET FirstName = @FirstName, SurName = @SurName, DOB = @DOB, Gender = @Gender, " +
                                   "Number = @Number, Email = @Email, UserName = @UserName, Password = @Password WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@SurName", surName);
                    command.Parameters.AddWithValue("@DOB", dob);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Number", number);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@ID", userId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error updating user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadUserData();
                ClearTextBoxes();
                dataGridViewUserInfo.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridViewUserInfo.Rows[e.RowIndex];

                    txtFirstName.Text = selectedRow.Cells["FirstName"].Value.ToString();
                    txtSurName.Text = selectedRow.Cells["SurName"].Value.ToString();
                    dtpDOB.Value = Convert.ToDateTime(selectedRow.Cells["DOB"].Value);
                    txtGender.Text = selectedRow.Cells["Gender"].Value.ToString();
                    txtNumber.Text = selectedRow.Cells["Number"].Value.ToString();
                    txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                    txtUserName.Text = selectedRow.Cells["UserName"].Value.ToString();
                    txtPassword.Text = selectedRow.Cells["Password"].Value.ToString();

                    selectedRow.Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            txtFirstName.Clear();
            txtSurName.Clear();
            dtpDOB.Value = DateTime.Now;
            txtGender.Clear();
            txtNumber.Clear();
            txtEmail.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtId.Text = "Auto-generated";
        }
    }
}
