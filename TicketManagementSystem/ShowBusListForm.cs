using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class ShowBusListForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;";
        private AdminDashboard adminDashboard;

        public ShowBusListForm(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
        }

        private void ShowBusListForm_Load(object sender, EventArgs e)
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

                dataGridViewBusList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewBusList.ScrollBars = ScrollBars.Both;
                dataGridViewBusList.RowHeadersVisible = false;
                dataGridViewBusList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            this.Close();
            adminDashboard.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBusData();
                dataGridViewBusList.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
