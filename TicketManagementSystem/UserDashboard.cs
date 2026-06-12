using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class UserDashboard : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True\r\n";
        private string userName;

        public UserDashboard(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome! {userName}";
            LoadLocations(); 
        }

        private void LoadLocations()
        {
            try
            {
                string transport = groupBoxTransport.Controls.OfType<RadioButton>()
                    .FirstOrDefault(r => r.Checked)?.Text;

                if (string.IsNullOrEmpty(transport)) return;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "";

                   
                    if (transport == "Bus")
                    {
                        query = "SELECT LocationName FROM BusLocation";
                    }
                    else if (transport == "Train")
                    {
                        query = "SELECT LocationName FROM TrainLocation";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    
                    comboBoxFrom.DataSource = dt.Copy();
                    comboBoxFrom.DisplayMember = "LocationName";
                    comboBoxFrom.ValueMember = "LocationName";

                   
                    comboBoxTo.DataSource = dt.Copy();
                    comboBoxTo.DisplayMember = "LocationName";
                    comboBoxTo.ValueMember = "LocationName";

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading locations: {ex.Message}");
            }
        }

        private void comboBoxFrom_DropDown(object sender, EventArgs e)
        {
           
            if (comboBoxFrom.Items.Count == 0)
                LoadLocations();
        }

        private void comboBoxTo_DropDown(object sender, EventArgs e)
        {
            
            if (comboBoxTo.Items.Count == 0)
                LoadLocations();
        }

        private void radioButtonBus_CheckedChanged(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void radioButtonTrain_CheckedChanged(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string from = comboBoxFrom.Text;
            string to = comboBoxTo.Text;
            string journeyDate = dateTimePicker.Value.ToString("yyyy-MM-dd");

            string transport = groupBoxTransport.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked)?.Text;

            try
            {
                if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || string.IsNullOrEmpty(transport) || string.IsNullOrEmpty(journeyDate))
                {
                    throw new ArgumentException("All fields must be filled in.");
                }

                if (from == to)
                {
                    MessageBox.Show("Invalid Location: 'From' and 'To' locations cannot be the same.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (transport == "Bus")
                {
                    if (!LoadBusDetails(from, to, journeyDate))
                    {
                        MessageBox.Show("No buses found for the selected route and date.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        BusForm busForm = new BusForm(from, to, journeyDate, userName);
                        busForm.Show();
                        this.Hide();
                    }
                }
                else if (transport == "Train")
                {
                    if (!LoadTrainDetails(from, to, journeyDate))
                    {
                        MessageBox.Show("No trains found for the selected route and date.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        TrainForm trainForm = new TrainForm(from, to, journeyDate, userName);
                        trainForm.Show();
                        this.Hide();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LoadBusDetails(string from, string to, string date)
        {
            bool busFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Bus WHERE Fromm = @From AND Too = @To AND Date = @Date";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@From", from);
                    command.Parameters.AddWithValue("@To", to);
                    command.Parameters.AddWithValue("@Date", date);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        busFound = true;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bus details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return busFound;
        }

        private bool LoadTrainDetails(string from, string to, string date)
        {
            bool trainFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Train WHERE Fromm = @From AND Too = @To AND Date = @Date";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@From", from);
                    command.Parameters.AddWithValue("@To", to);
                    command.Parameters.AddWithValue("@Date", date);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        trainFound = true;
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading train details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return trainFound;
        }

        private void profilebutton_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(userName);
            profileForm.Show();
            this.Hide();
        }
    }
}
