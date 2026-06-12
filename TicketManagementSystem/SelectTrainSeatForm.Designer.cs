namespace TicketManagementSystem
{
    partial class SelectTrainSeatForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSeats;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnConfirmTicket;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTrainSeatForm));
            this.flowLayoutPanelSeats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnConfirmTicket = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelSeats
            // 
            this.flowLayoutPanelSeats.BackColor = System.Drawing.Color.PowderBlue;
            this.flowLayoutPanelSeats.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelSeats.Location = new System.Drawing.Point(250, 98);
            this.flowLayoutPanelSeats.Name = "flowLayoutPanelSeats";
            this.flowLayoutPanelSeats.Size = new System.Drawing.Size(327, 462);
            this.flowLayoutPanelSeats.TabIndex = 0;
            this.flowLayoutPanelSeats.WrapContents = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.SystemColors.Info;
            this.lblUserName.Font = new System.Drawing.Font("Rockwell Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUserName.Location = new System.Drawing.Point(252, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(285, 47);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Select Seat, User";
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.LightCoral;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(1164, 12);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(75, 30);
            this.btnSignOut.TabIndex = 3;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnConfirmTicket
            // 
            this.btnConfirmTicket.AutoSize = true;
            this.btnConfirmTicket.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnConfirmTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmTicket.Location = new System.Drawing.Point(713, 255);
            this.btnConfirmTicket.Name = "btnConfirmTicket";
            this.btnConfirmTicket.Size = new System.Drawing.Size(220, 42);
            this.btnConfirmTicket.TabIndex = 4;
            this.btnConfirmTicket.Text = "Confirm Seat";
            this.btnConfirmTicket.UseVisualStyleBackColor = false;
            this.btnConfirmTicket.Click += new System.EventHandler(this.btnConfirmTicket_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(666, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "**User Can Select Upto 4 Tickets**";
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::TicketManagementSystem.Properties.Resources.png_transparent_arrow_computer_icons_encapsulated_postscript_button_back_icon_angle_logo_left_arrow;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Location = new System.Drawing.Point(28, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(63, 30);
            this.btnBack.TabIndex = 2;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::TicketManagementSystem.Properties.Resources.traininside;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1238, 647);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // SelectTrainSeatForm
            // 
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1262, 653);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmTicket);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.flowLayoutPanelSeats);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectTrainSeatForm";
            this.Text = "Select Train Seats";
            this.Load += new System.EventHandler(this.SelectSeatForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
