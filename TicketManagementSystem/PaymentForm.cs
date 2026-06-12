using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace TicketManagementSystem
{
    public partial class PaymentForm : Form
    {
        private string userName;
        private List<int> selectedSeats;
        private string busId;
        private string storedPhoneNumber;
        private string selectedFrom;
        private string selectedTo;
        private string selectedDate;
        private bool isPaymentConfirmed = false; 

        public PaymentForm(List<int> seats, string user, string bus, string from, string to, string date)
        {
            InitializeComponent();
            this.selectedSeats = seats;
            this.userName = user;
            this.busId = bus;
            this.selectedFrom = from;
            this.selectedTo = to;
            this.selectedDate = date;
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Please Confirm Payment, {userName}";
            LoadTicketDetails();
        }

        private void LoadTicketDetails()
        {
            try
            {
                string busName = "", from = "", to = "", route = "", depTime = "", estimatedTime = "";
                decimal pricePerTicket = 0;

                string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";
                string query = "SELECT BusName, Fromm, Too, Route, DepurtureTime, EstimatedTime, Price FROM Bus WHERE BusId = @BusId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BusId", busId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        busName = reader["BusName"].ToString();
                        from = reader["Fromm"].ToString();
                        to = reader["Too"].ToString();
                        route = reader["Route"].ToString();
                        depTime = reader["DepurtureTime"].ToString();
                        estimatedTime = reader["EstimatedTime"].ToString();
                        pricePerTicket = Convert.ToDecimal(reader["Price"]);
                    }
                    else
                    {
                        MessageBox.Show("No bus details found for the selected BusId.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                lblTicketDetails.Text = $"Bus Name: {busName}\n" +
                                        $"From: {from}\n" +
                                        $"To: {to}\n" +
                                        $"Route: {route}\n" +
                                        $"Departure Time: {depTime}\n" +
                                        $"Estimated Time: {estimatedTime}\n" +
                                        $"Selected Seats No.: {string.Join(", ", selectedSeats)}";

                decimal totalPrice = selectedSeats.Count * pricePerTicket;
                lblTotalPrice.Text = $"Total Price: {totalPrice} Taka";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ticket details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (isPaymentConfirmed)
            {
                MessageBox.Show("Payment already confirmed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }

            if (string.IsNullOrEmpty(txtPhoneNumber.Text) || string.IsNullOrEmpty(txtCustomInput.Text))
            {
                MessageBox.Show("Please fill in both fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";
                string query = "SELECT Number FROM UserInfo WHERE UserName = @UserName";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", userName);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        storedPhoneNumber = reader["Number"].ToString();

                        if (txtPhoneNumber.Text != storedPhoneNumber)
                        {
                            MessageBox.Show("Phone number does not match with the registered user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phone number not found for the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    connection.Close();
                }

                ReserveSeats();

                isPaymentConfirmed = true; 

                MessageBox.Show("Congratulations! Ticket purchase completed.", "Payment Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnPrintTicket.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReserveSeats()
        {
            try
            {
                string currentReservedSeats = "";

                string query = "SELECT ReservedSeats FROM Bus WHERE BusId = @BusId";

                using (SqlConnection connection = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BusId", busId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        currentReservedSeats = reader["ReservedSeats"].ToString();
                    }
                    connection.Close();
                }

                if (string.IsNullOrEmpty(currentReservedSeats))
                {
                    currentReservedSeats = string.Join(",", selectedSeats);
                }
                else
                {
                    currentReservedSeats += "," + string.Join(",", selectedSeats);
                }

                string updateQuery = "UPDATE Bus SET ReservedSeats = @ReservedSeats, AvailableSeats = AvailableSeats - @SeatsSelected WHERE BusId = @BusId";

                using (SqlConnection connection = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@ReservedSeats", currentReservedSeats);
                    command.Parameters.AddWithValue("@SeatsSelected", selectedSeats.Count);
                    command.Parameters.AddWithValue("@BusId", busId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Seats have been successfully reserved!");
                    }
                    else
                    {
                        MessageBox.Show("Error reserving seats.");
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reserving seats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during sign out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (isPaymentConfirmed)
            {
                UserDashboard userDashboard = new UserDashboard(userName);
                userDashboard.Show();
            }
            else
            {
                SelectSeatForm selectSeatForm = new SelectSeatForm(userName, busId, selectedFrom, selectedTo, selectedDate);
                selectSeatForm.Show();
            }

            this.Hide();
        }

        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            try
            {
                string ticketDetails = $"Ticket Details:\n\n" +
                                       $"Bus Name: {lblTicketDetails.Text}\n" +
                                       $"Total Price: {lblTotalPrice.Text}";

                MessageBox.Show(ticketDetails, "Ticket Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
