using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace TicketManagementSystem
{
    public partial class SelectSeatForm : Form
    {
        private string userName;
        private List<int> selectedSeats = new List<int>();
        private string busId;
        private List<int> bookedSeats = new List<int>();

        private string selectedFrom;
        private string selectedTo;
        private string selectedDate;


        public SelectSeatForm(string user, string busId, string from, string to, string date)
        {
            InitializeComponent();
            this.userName = user;
            this.busId = busId;
            this.selectedFrom = from;
            this.selectedTo = to;
            this.selectedDate = date;
        }

        private void SelectSeatForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblUserName.Text = $"Please Select Seat, {userName}";
                CreateSeatButtons();
                LoadBookedSeats();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateSeatButtons()
        {
            try
            {
                int seatCount = 40;
                int seatWidth = 35, seatHeight = 35;
                int seatsPerColumn = 10;
                int paddingBetweenColumns = 20;

                flowLayoutPanelSeats.WrapContents = true;
                flowLayoutPanelSeats.FlowDirection = FlowDirection.TopDown;
                flowLayoutPanelSeats.AutoScroll = true;

                for (int i = 1; i <= seatCount; i++)
                {
                    Button seatButton = new Button();
                    seatButton.Name = "btnSeat" + i;
                    seatButton.Size = new System.Drawing.Size(seatWidth, seatHeight);
                    seatButton.Text = i.ToString();
                    seatButton.Click += new EventHandler(SeatButton_Click);
                    seatButton.Tag = i;

                    if (i % seatsPerColumn == 0)
                    {
                        seatButton.Margin = new Padding(0, 0, paddingBetweenColumns, 8);
                    }
                    else
                    {
                        seatButton.Margin = new Padding(5);
                    }

                    if (bookedSeats.Contains(i))
                    {
                        seatButton.BackColor = System.Drawing.Color.Gray;
                        seatButton.Enabled = false;
                    }

                    flowLayoutPanelSeats.Controls.Add(seatButton);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating seat buttons: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookedSeats()
        {
            try
            {
                string query = "SELECT ReservedSeats FROM Bus WHERE BusId = @BusId";

                using (SqlConnection connection = new SqlConnection("Data Source=MSI\\SQLEXPRESS;Initial Catalog=TicketManagement;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BusId", busId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string reservedSeats = reader["ReservedSeats"].ToString();
                        if (!string.IsNullOrEmpty(reservedSeats))
                        {
                            bookedSeats = reservedSeats.Split(',').Select(int.Parse).ToList();
                        }
                    }
                    connection.Close();
                }

                foreach (var seatNumber in bookedSeats)
                {
                    Button seatButton = flowLayoutPanelSeats.Controls
                        .OfType<Button>()
                        .FirstOrDefault(btn => (int)btn.Tag == seatNumber);

                    if (seatButton != null)
                    {
                        seatButton.BackColor = System.Drawing.Color.Gray;
                        seatButton.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booked seats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button clickedButton = (Button)sender;
                int seatNumber = (int)clickedButton.Tag;

                if (bookedSeats.Contains(seatNumber) || clickedButton.Enabled == false)
                {
                    MessageBox.Show("This seat is already booked or unavailable.");
                    return;
                }

                if (selectedSeats.Contains(seatNumber))
                {
                    selectedSeats.Remove(seatNumber);
                    clickedButton.BackColor = System.Drawing.Color.DarkSeaGreen;
                }
                else
                {
                    if (selectedSeats.Count < 4)
                    {
                        selectedSeats.Add(seatNumber);
                        clickedButton.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        MessageBox.Show("You can only select up to 4 seats.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting seat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                BusForm busForm = new BusForm(selectedFrom, selectedTo, selectedDate, userName);
                busForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating back to BusForm: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            try
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error signing out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSeats.Count > 0)
                {
                    MessageBox.Show("Ticket Booked! Proceed to payment to confirm.", "Ticket Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PaymentForm paymentForm = new PaymentForm(selectedSeats, userName, busId, selectedFrom, selectedTo, selectedDate);
                    paymentForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please select at least one seat.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
