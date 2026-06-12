using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class BusForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";
        private string selectedFrom;
        private string selectedTo;
        private string selectedDate;
        private string userName;

        public BusForm(string from, string to, string date, string user)
        {
            InitializeComponent();
            this.selectedFrom = from;
            this.selectedTo = to;
            this.selectedDate = date;
            this.userName = user;
        }

        private void BusForm_Load(object sender, EventArgs e)
        {
            lblFrom.Text = $"From: {selectedFrom}";
            lblTo.Text = $"To: {selectedTo}";
            lblDate.Text = $"Date: {selectedDate}";
            lblUserName.Text = $"Book Ticket, {userName}";
            LoadBusDetails(selectedFrom, selectedTo, selectedDate);
        }

        private void LoadBusDetails(string from, string to, string date)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT BusId, BusName, Class, Route, Date, DepurtureTime, EstimatedTime, AvailableSeats, Price " +
                                   "FROM Bus WHERE Fromm = @From AND Too = @To AND Date = @Date";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@From", from);
                    command.Parameters.AddWithValue("@To", to);
                    command.Parameters.AddWithValue("@Date", date);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int availableSeats = Convert.ToInt32(reader["AvailableSeats"]);

                        RadioButton busRadioButton = new RadioButton();
                        busRadioButton.Text = $"Bus: {reader["BusName"]}  -  Class: ({reader["Class"]})  - Route: ({reader["Route"]})  - Departure Time: ({reader["DepurtureTime"]})  - Journey Time: ({reader["EstimatedTime"]})  - Available Seats: ({availableSeats})  - Price: {reader["Price"]} Taka";
                        busRadioButton.Tag = reader["BusId"].ToString();
                        busRadioButton.AutoSize = true;

                        if (availableSeats == 0)
                        {
                            busRadioButton.Enabled = false;
                            busRadioButton.ForeColor = System.Drawing.Color.Gray;
                        }

                        flowLayoutPanel1.Controls.Add(busRadioButton);
                    }

                    if (flowLayoutPanel1.Controls.Count == 0)
                    {
                        MessageBox.Show("No buses found for the selected route and date.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bus details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            try
            {
                RadioButton selectedBus = flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                if (selectedBus == null)
                {
                    MessageBox.Show("You must select a bus.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedBusId = selectedBus.Tag.ToString();

                // Pass selectedFrom, selectedTo, selectedDate along with userName and selectedBusId
                SelectSeatForm selectSeatForm = new SelectSeatForm(userName, selectedBusId, selectedFrom, selectedTo, selectedDate);
                selectSeatForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            try
            {
                RadioButton selectedBus = flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                if (selectedBus != null)
                {
                    selectedBus.Checked = false;
                }
                else
                {
                    MessageBox.Show("No bus is currently selected.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred while deselecting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserDashboard userDashboard = new UserDashboard(userName);
            userDashboard.Show();
            this.Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
