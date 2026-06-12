using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class ManageTrain : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;";
        private AdminDashboard adminDashboard;

        public ManageTrain(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
        }

        private void ManageTrain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTrainData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TrainId AS Id, TrainName, Fromm, Too, Date, Class, Route, DepurtureTime, EstimatedTime, ReservedSeats, AvailableSeats, Price FROM Train";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewTrainList.DataSource = dataTable;
                    connection.Close();
                }

                dataGridViewTrainList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridViewTrainList.ScrollBars = ScrollBars.Both;
                dataGridViewTrainList.RowHeadersVisible = false;
                dataGridViewTrainList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewTrainList.ReadOnly = true;
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
                string trainName = txtTrainName.Text;
                string from = txtFrom.Text;
                string to = txtTo.Text;
                DateTime date = dtpDate.Value;
                string trainClass = txtClass.Text;
                string route = txtRoute.Text;
                string departureTime = dtpDepartureTime.Text;
                string estimatedTime = txtEstimatedTime.Text;
                string reservedSeats = string.IsNullOrEmpty(txtReservedSeats.Text) ? null : txtReservedSeats.Text;
                int availableSeats = Convert.ToInt32(txtAvailableSeats.Text);
                int price = Convert.ToInt32(txtPrice.Text);

                if (string.IsNullOrEmpty(trainName) || string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || string.IsNullOrEmpty(trainClass) || string.IsNullOrEmpty(route) || string.IsNullOrEmpty(estimatedTime) || availableSeats <= 0 || price <= 0)
                {
                    MessageBox.Show("Please fill in all the fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Train (TrainName, Fromm, Too, Date, Class, Route, DepurtureTime, EstimatedTime, ReservedSeats, AvailableSeats, Price) VALUES (@TrainName, @Fromm, @Too, @Date, @Class, @Route, @DepurtureTime, @EstimatedTime, @ReservedSeats, @AvailableSeats, @Price)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TrainName", trainName);
                    command.Parameters.AddWithValue("@Fromm", from);
                    command.Parameters.AddWithValue("@Too", to);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Class", trainClass);
                    command.Parameters.AddWithValue("@Route", route);
                    command.Parameters.AddWithValue("@DepurtureTime", departureTime);
                    command.Parameters.AddWithValue("@EstimatedTime", estimatedTime);
                    command.Parameters.AddWithValue("@ReservedSeats", (object)reservedSeats ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Train added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTrainData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error adding train", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding train: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTrainList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRowIndex = dataGridViewTrainList.SelectedRows[0].Index;
                int trainId = Convert.ToInt32(dataGridViewTrainList.Rows[selectedRowIndex].Cells["Id"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Train WHERE TrainId = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", trainId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Train deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTrainData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting train", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting train: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTrainList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRowIndex = dataGridViewTrainList.SelectedRows[0].Index;
                int trainId = Convert.ToInt32(dataGridViewTrainList.Rows[selectedRowIndex].Cells["Id"].Value);
                string trainName = txtTrainName.Text;
                string from = txtFrom.Text;
                string to = txtTo.Text;
                DateTime date = dtpDate.Value;
                string trainClass = txtClass.Text;
                string route = txtRoute.Text;
                string departureTime = dtpDepartureTime.Text;
                string estimatedTime = txtEstimatedTime.Text;
                string reservedSeats = string.IsNullOrEmpty(txtReservedSeats.Text) ? null : txtReservedSeats.Text;
                int availableSeats = Convert.ToInt32(txtAvailableSeats.Text);
                int price = Convert.ToInt32(txtPrice.Text);

                if (string.IsNullOrEmpty(trainName) || string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || string.IsNullOrEmpty(trainClass) || string.IsNullOrEmpty(route) || string.IsNullOrEmpty(estimatedTime) || availableSeats <= 0 || price <= 0)
                {
                    MessageBox.Show("Please fill in all the fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Train SET TrainName = @TrainName, Fromm = @Fromm, Too = @Too, Date = @Date, Class = @Class, Route = @Route, DepurtureTime = @DepurtureTime, EstimatedTime = @EstimatedTime, ReservedSeats = @ReservedSeats, AvailableSeats = @AvailableSeats, Price = @Price WHERE TrainId = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", trainId);
                    command.Parameters.AddWithValue("@TrainName", trainName);
                    command.Parameters.AddWithValue("@Fromm", from);
                    command.Parameters.AddWithValue("@Too", to);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Class", trainClass);
                    command.Parameters.AddWithValue("@Route", route);
                    command.Parameters.AddWithValue("@DepurtureTime", departureTime);
                    command.Parameters.AddWithValue("@EstimatedTime", estimatedTime);
                    command.Parameters.AddWithValue("@ReservedSeats", (object)reservedSeats ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Train updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTrainData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error updating train", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating train: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTrainData();
                ClearTextBoxes();
                dataGridViewTrainList.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTrainList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridViewTrainList.Rows[e.RowIndex];

                    txtTrainId.Text = selectedRow.Cells["Id"].Value.ToString();
                    txtTrainName.Text = selectedRow.Cells["TrainName"].Value.ToString();
                    txtFrom.Text = selectedRow.Cells["Fromm"].Value.ToString();
                    txtTo.Text = selectedRow.Cells["Too"].Value.ToString();
                    dtpDate.Value = Convert.ToDateTime(selectedRow.Cells["Date"].Value);
                    txtClass.Text = selectedRow.Cells["Class"].Value.ToString();
                    txtRoute.Text = selectedRow.Cells["Route"].Value.ToString();
                    dtpDepartureTime.Text = selectedRow.Cells["DepurtureTime"].Value.ToString();
                    txtEstimatedTime.Text = selectedRow.Cells["EstimatedTime"].Value.ToString();
                    txtReservedSeats.Text = selectedRow.Cells["ReservedSeats"].Value.ToString();
                    txtAvailableSeats.Text = selectedRow.Cells["AvailableSeats"].Value.ToString();
                    txtPrice.Text = selectedRow.Cells["Price"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting row: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            txtTrainName.Clear();
            txtFrom.Clear();
            txtTo.Clear();
            dtpDate.Value = DateTime.Now;
            txtClass.Clear();
            txtRoute.Clear();
            dtpDepartureTime.Clear();
            txtEstimatedTime.Clear();
            txtReservedSeats.Clear();
            txtAvailableSeats.Clear();
            txtPrice.Clear();
            txtTrainId.Text = "Auto-generated";
        }
    }
}
