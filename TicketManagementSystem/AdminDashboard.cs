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
    public partial class AdminDashboard : Form
    {
        private string adminName;
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;";

        public AdminDashboard(string adminName)
        {
            InitializeComponent();
            this.adminName = adminName;
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                //lblAdminDashboard.Text = "ADMIN DASHBOARD";
                FetchAdminNameFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Admin Dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchAdminNameFromDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Name FROM AdminPass WHERE Name = @Name";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", adminName);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        lblWelcome.Text = $"Welcome, {reader["Name"].ToString()}";
                    }
                    else
                    {
                        MessageBox.Show("Admin not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching admin name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnManageAdmin_Click(object sender, EventArgs e)
        {
            ManageAdminForm manageAdminForm = new ManageAdminForm(this);
            manageAdminForm.Show();
            this.Hide();
        }

        private void btnShowBusList_Click(object sender, EventArgs e)
        {
            ShowBusListForm showBusListForm = new ShowBusListForm(this);
            showBusListForm.Show();
            this.Hide();
        }

        private void btnShowBusRoute_Click(object sender, EventArgs e)
        {
            ShowBusRouteForm showBusRouteForm = new ShowBusRouteForm(this);
            showBusRouteForm.Show();
            this.Hide();
        }

        private void btnManageBus_Click(object sender, EventArgs e)
        {
            ManageBus manageBusForm = new ManageBus(this);
            manageBusForm.Show();
            this.Hide();
        }

        private void btnShowTrainList_Click(object sender, EventArgs e)
        {
            ShowTrainListForm showTrainListForm = new ShowTrainListForm(this);
            showTrainListForm.Show();
            this.Hide();
        }

        private void btnShowTrainRoute_Click(object sender, EventArgs e)
        {
            ShowTrainRouteForm showTrainRouteForm = new ShowTrainRouteForm(this);
            showTrainRouteForm.Show();
            this.Hide();
        }

        private void btnManageTrain_Click(object sender, EventArgs e)
        {
            ManageTrain manageTrain = new ManageTrain(this);
            manageTrain.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageUserForm manageUserForm = new ManageUserForm(this);
            manageUserForm.Show();
            this.Hide();
        }
    }
}
