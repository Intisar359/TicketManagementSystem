using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class ShowTrainRouteForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;";
        private AdminDashboard adminDashboard;

        public ShowTrainRouteForm(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
        }

        private void ShowTrainRouteForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLocationData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLocationData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM TrainLocation";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewLocation.DataSource = dataTable;
                    connection.Close();
                }

                dataGridViewLocation.ReadOnly = true;
                dataGridViewLocation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewLocation.ScrollBars = ScrollBars.Both;
                dataGridViewLocation.RowHeadersVisible = false;
                dataGridViewLocation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                string locationName = txtLocationName.Text;

                if (string.IsNullOrEmpty(locationName))
                {
                    MessageBox.Show("Location Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO TrainLocation (LocationName) VALUES (@LocationName)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LocationName", locationName);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Location added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLocationData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error adding location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding location: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLocation.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRowIndex = dataGridViewLocation.SelectedRows[0].Index;
                int locationId = Convert.ToInt32(dataGridViewLocation.Rows[selectedRowIndex].Cells["ID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM TrainLocation WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", locationId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Route deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLocationData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting location: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLocation.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRowIndex = dataGridViewLocation.SelectedRows[0].Index;
                int locationId = Convert.ToInt32(dataGridViewLocation.Rows[selectedRowIndex].Cells["ID"].Value);
                string locationName = txtLocationName.Text;

                if (string.IsNullOrEmpty(locationName))
                {
                    MessageBox.Show("Route Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE TrainLocation SET LocationName = @LocationName WHERE ID = @ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LocationName", locationName);
                    command.Parameters.AddWithValue("@ID", locationId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Route updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLocationData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error updating Route", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating location: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadLocationData();
                ClearTextBoxes();
                dataGridViewLocation.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridViewLocation.Rows[e.RowIndex];

                    txtLocationName.Text = selectedRow.Cells["LocationName"].Value.ToString();
                    txtLocationId.Text = selectedRow.Cells["ID"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            txtLocationName.Clear();
            txtLocationId.Text = "Auto-generated";
        }
    }
}
