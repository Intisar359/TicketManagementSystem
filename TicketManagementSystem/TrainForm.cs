using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace TicketManagementSystem
{
    public partial class TrainForm : Form
    {
        private string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";
        private string selectedFrom;
        private string selectedTo;
        private string selectedDate;
        private string userName;

        public TrainForm(string from, string to, string date, string user)
        {
            InitializeComponent();
            this.selectedFrom = from;
            this.selectedTo = to;
            this.selectedDate = date;
            this.userName = user;
        }

        private void TrainForm_Load(object sender, EventArgs e)
        {
            lblFrom.Text = $"From: {selectedFrom}";
            lblTo.Text = $"To: {selectedTo}";
            lblDate.Text = $"Date: {selectedDate}";
            lblUserName.Text = $"Book Ticket, {userName}";
            LoadTrainDetails(selectedFrom, selectedTo, selectedDate);
        }

        private void LoadTrainDetails(string from, string to, string date)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TrainId, TrainName, Class, Route, Date, DepurtureTime, EstimatedTime, AvailableSeats, Price " +
                                   "FROM Train WHERE Fromm = @From AND Too = @To AND Date = @Date";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@From", from);
                    command.Parameters.AddWithValue("@To", to);
                    command.Parameters.AddWithValue("@Date", date);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int availableSeats = Convert.ToInt32(reader["AvailableSeats"]);

                        RadioButton trainRadioButton = new RadioButton();
                        trainRadioButton.Text = $"Train: {reader["TrainName"]}  -  Class: ({reader["Class"]})  - Route: ({reader["Route"]})  - Departure Time: ({reader["DepurtureTime"]})  - Journey Time: ({reader["EstimatedTime"]})  - Available Seats: ({availableSeats})  - Price: {reader["Price"]} Taka";
                        trainRadioButton.Tag = reader["TrainId"].ToString();
                        trainRadioButton.AutoSize = true;

                        if (availableSeats == 0)
                        {
                            trainRadioButton.Enabled = false;
                            trainRadioButton.ForeColor = System.Drawing.Color.Gray;
                        }

                        flowLayoutPanel1.Controls.Add(trainRadioButton);
                    }

                    if (flowLayoutPanel1.Controls.Count == 0)
                    {
                        MessageBox.Show("No trains found for the selected route and date.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserDashboard userDashboard = new UserDashboard(userName);
                        userDashboard.Show();
                        this.Hide();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading train details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            try
            {
                RadioButton selectedTrain = flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                if (selectedTrain == null)
                {
                    MessageBox.Show("You must select a train.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedTrainId = selectedTrain.Tag.ToString();
                SelectTrainSeatForm selectTrainSeatForm = new SelectTrainSeatForm(userName, selectedTrainId, selectedFrom, selectedTo, selectedDate);
                selectTrainSeatForm.Show();
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
                RadioButton selectedTrain = flowLayoutPanel1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                if (selectedTrain != null)
                {
                    selectedTrain.Checked = false;
                }
                else
                {
                    MessageBox.Show("No train is currently selected.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
