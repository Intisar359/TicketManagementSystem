using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class ManageBus : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;";
        private AdminDashboard adminDashboard;

        public ManageBus(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
        }

        private void ManageBus_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBusData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBusData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Bus";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewBusList.DataSource = dataTable;
                    connection.Close();
                }

                dataGridViewBusList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dataGridViewBusList.ScrollBars = ScrollBars.Both;
                dataGridViewBusList.RowHeadersVisible = false;
                dataGridViewBusList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewBusList.ReadOnly = true;
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
                string busName = txtBusName.Text;
                string from = txtFrom.Text;
                string to = txtTo.Text;
                DateTime date = dtpDate.Value;
                string busClass = txtClass.Text;
                string route = txtRoute.Text;
                string departureTime = dtpDepartureTime.Text;
                string estimatedTime = txtEstimatedTime.Text;
                string reservedSeats = string.IsNullOrEmpty(txtReservedSeats.Text) ? null : txtReservedSeats.Text;
                int availableSeats = Convert.ToInt32(txtAvailableSeats.Text);
                int price = Convert.ToInt32(txtPrice.Text);

                if (string.IsNullOrEmpty(busName) || string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || string.IsNullOrEmpty(busClass) || string.IsNullOrEmpty(route) || string.IsNullOrEmpty(estimatedTime) || availableSeats <= 0 || price <= 0)
                {
                    MessageBox.Show("Please fill in all the fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Bus (BusName, Fromm, Too, Date, Class, Route, DepurtureTime, EstimatedTime, ReservedSeats, AvailableSeats, Price) VALUES (@BusName, @Fromm, @Too, @Date, @Class, @Route, @DepurtureTime, @EstimatedTime, @ReservedSeats, @AvailableSeats, @Price)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BusName", busName);
                    command.Parameters.AddWithValue("@Fromm", from);
                    command.Parameters.AddWithValue("@Too", to);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Class", busClass);
                    command.Parameters.AddWithValue("@Route", route);
                    command.Parameters.AddWithValue("@DepurtureTime", departureTime);
                    command.Parameters.AddWithValue("@EstimatedTime", estimatedTime);
                    command.Parameters.AddWithValue("@ReservedSeats", (object)reservedSeats ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Bus added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBusData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error adding bus", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding bus: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBusList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRowIndex = dataGridViewBusList.SelectedRows[0].Index;
                int busId = Convert.ToInt32(dataGridViewBusList.Rows[selectedRowIndex].Cells["BusId"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Bus WHERE BusId = @BusId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BusId", busId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Bus deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBusData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting bus", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting bus: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewBusList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int selectedRowIndex = dataGridViewBusList.SelectedRows[0].Index;
                int busId = Convert.ToInt32(dataGridViewBusList.Rows[selectedRowIndex].Cells["BusId"].Value);
                string busName = txtBusName.Text;
                string from = txtFrom.Text;
                string to = txtTo.Text;
                DateTime date = dtpDate.Value;
                string busClass = txtClass.Text;
                string route = txtRoute.Text;
                string departureTime = dtpDepartureTime.Text;
                string estimatedTime = txtEstimatedTime.Text;
                string reservedSeats = string.IsNullOrEmpty(txtReservedSeats.Text) ? null : txtReservedSeats.Text;
                int availableSeats = Convert.ToInt32(txtAvailableSeats.Text);
                int price = Convert.ToInt32(txtPrice.Text);

                if (string.IsNullOrEmpty(busName) || string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || string.IsNullOrEmpty(busClass) || string.IsNullOrEmpty(route) || string.IsNullOrEmpty(estimatedTime) || availableSeats <= 0 || price <= 0)
                {
                    MessageBox.Show("Please fill in all the fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Bus SET BusName = @BusName, Fromm = @Fromm, Too = @Too, Date = @Date, Class = @Class, Route = @Route, DepurtureTime = @DepurtureTime, EstimatedTime = @EstimatedTime, ReservedSeats = @ReservedSeats, AvailableSeats = @AvailableSeats, Price = @Price WHERE BusId = @BusId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BusId", busId);
                    command.Parameters.AddWithValue("@BusName", busName);
                    command.Parameters.AddWithValue("@Fromm", from);
                    command.Parameters.AddWithValue("@Too", to);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Class", busClass);
                    command.Parameters.AddWithValue("@Route", route);
                    command.Parameters.AddWithValue("@DepurtureTime", departureTime);
                    command.Parameters.AddWithValue("@EstimatedTime", estimatedTime);
                    command.Parameters.AddWithValue("@ReservedSeats", (object)reservedSeats ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Bus updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBusData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Error updating bus", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating bus: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBusData();
                ClearTextBoxes();
                dataGridViewBusList.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewBusList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridViewBusList.Rows[e.RowIndex];

                    txtBusId.Text = selectedRow.Cells["BusId"].Value.ToString();
                    txtBusName.Text = selectedRow.Cells["BusName"].Value.ToString();
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
            txtBusName.Clear();
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
            txtBusId.Text = "Auto-generated";
        }
    }
}
