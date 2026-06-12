using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class ShowTrainListForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;";
        private AdminDashboard adminDashboard;

        public ShowTrainListForm(AdminDashboard adminDashboard)
        {
            InitializeComponent();
            this.adminDashboard = adminDashboard;
        }

        private void ShowTrainListForm_Load(object sender, EventArgs e)
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

                dataGridViewTrainList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewTrainList.ScrollBars = ScrollBars.Both;
                dataGridViewTrainList.RowHeadersVisible = false;
                dataGridViewTrainList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                LoadTrainData();
                dataGridViewTrainList.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
