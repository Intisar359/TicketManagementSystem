namespace TicketManagementSystem
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.lblAdminDashboard = new System.Windows.Forms.Label();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnManageAdmin = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnShowBusList = new System.Windows.Forms.Button();
            this.btnShowBusRoute = new System.Windows.Forms.Button();
            this.btnManageBus = new System.Windows.Forms.Button();
            this.btnShowTrainList = new System.Windows.Forms.Button();
            this.btnShowTrainRoute = new System.Windows.Forms.Button();
            this.btnManageTrain = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAdminDashboard
            // 
            this.lblAdminDashboard.BackColor = System.Drawing.Color.AliceBlue;
            this.lblAdminDashboard.Font = new System.Drawing.Font("Rockwell Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminDashboard.ForeColor = System.Drawing.Color.Red;
            this.lblAdminDashboard.Location = new System.Drawing.Point(451, 43);
            this.lblAdminDashboard.Name = "lblAdminDashboard";
            this.lblAdminDashboard.Size = new System.Drawing.Size(388, 40);
            this.lblAdminDashboard.TabIndex = 11;
            this.lblAdminDashboard.Text = "ADMIN DASHBOARD";
            this.lblAdminDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.LightCoral;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(1136, 12);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(100, 40);
            this.btnSignOut.TabIndex = 10;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnManageAdmin
            // 
            this.btnManageAdmin.AutoSize = true;
            this.btnManageAdmin.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnManageAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageAdmin.Location = new System.Drawing.Point(25, 79);
            this.btnManageAdmin.Name = "btnManageAdmin";
            this.btnManageAdmin.Size = new System.Drawing.Size(128, 40);
            this.btnManageAdmin.TabIndex = 9;
            this.btnManageAdmin.Text = "Manage Admin";
            this.btnManageAdmin.UseVisualStyleBackColor = false;
            this.btnManageAdmin.Click += new System.EventHandler(this.btnManageAdmin_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.MediumTurquoise;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.Location = new System.Drawing.Point(498, 126);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(286, 30);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "Welcome, Admin";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowBusList
            // 
            this.btnShowBusList.AutoSize = true;
            this.btnShowBusList.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnShowBusList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowBusList.Location = new System.Drawing.Point(441, 310);
            this.btnShowBusList.Name = "btnShowBusList";
            this.btnShowBusList.Size = new System.Drawing.Size(190, 40);
            this.btnShowBusList.TabIndex = 7;
            this.btnShowBusList.Text = "SHOW BUS LIST";
            this.btnShowBusList.UseVisualStyleBackColor = false;
            this.btnShowBusList.Click += new System.EventHandler(this.btnShowBusList_Click);
            // 
            // btnShowBusRoute
            // 
            this.btnShowBusRoute.AutoSize = true;
            this.btnShowBusRoute.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnShowBusRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowBusRoute.Location = new System.Drawing.Point(441, 370);
            this.btnShowBusRoute.Name = "btnShowBusRoute";
            this.btnShowBusRoute.Size = new System.Drawing.Size(190, 40);
            this.btnShowBusRoute.TabIndex = 6;
            this.btnShowBusRoute.Text = "MANAGE BUS ROUTE";
            this.btnShowBusRoute.UseVisualStyleBackColor = false;
            this.btnShowBusRoute.Click += new System.EventHandler(this.btnShowBusRoute_Click);
            // 
            // btnManageBus
            // 
            this.btnManageBus.AutoSize = true;
            this.btnManageBus.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnManageBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageBus.Location = new System.Drawing.Point(441, 430);
            this.btnManageBus.Name = "btnManageBus";
            this.btnManageBus.Size = new System.Drawing.Size(190, 40);
            this.btnManageBus.TabIndex = 5;
            this.btnManageBus.Text = "MANANGE BUS";
            this.btnManageBus.UseVisualStyleBackColor = false;
            this.btnManageBus.Click += new System.EventHandler(this.btnManageBus_Click);
            // 
            // btnShowTrainList
            // 
            this.btnShowTrainList.AutoSize = true;
            this.btnShowTrainList.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnShowTrainList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowTrainList.Location = new System.Drawing.Point(662, 310);
            this.btnShowTrainList.Name = "btnShowTrainList";
            this.btnShowTrainList.Size = new System.Drawing.Size(204, 40);
            this.btnShowTrainList.TabIndex = 3;
            this.btnShowTrainList.Text = "SHOW TRAIN LIST";
            this.btnShowTrainList.UseVisualStyleBackColor = false;
            this.btnShowTrainList.Click += new System.EventHandler(this.btnShowTrainList_Click);
            // 
            // btnShowTrainRoute
            // 
            this.btnShowTrainRoute.AutoSize = true;
            this.btnShowTrainRoute.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnShowTrainRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowTrainRoute.Location = new System.Drawing.Point(662, 370);
            this.btnShowTrainRoute.Name = "btnShowTrainRoute";
            this.btnShowTrainRoute.Size = new System.Drawing.Size(204, 40);
            this.btnShowTrainRoute.TabIndex = 2;
            this.btnShowTrainRoute.Text = "MANAGE TRAIN ROUTE";
            this.btnShowTrainRoute.UseVisualStyleBackColor = false;
            this.btnShowTrainRoute.Click += new System.EventHandler(this.btnShowTrainRoute_Click);
            // 
            // btnManageTrain
            // 
            this.btnManageTrain.AutoSize = true;
            this.btnManageTrain.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnManageTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageTrain.Location = new System.Drawing.Point(662, 430);
            this.btnManageTrain.Name = "btnManageTrain";
            this.btnManageTrain.Size = new System.Drawing.Size(204, 40);
            this.btnManageTrain.TabIndex = 1;
            this.btnManageTrain.Text = "MANAGE TRAIN";
            this.btnManageTrain.UseVisualStyleBackColor = false;
            this.btnManageTrain.Click += new System.EventHandler(this.btnManageTrain_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(25, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "Manage User";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::TicketManagementSystem.Properties.Resources.setting2;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(130, 384);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(154, 137);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TicketManagementSystem.Properties.Resources.settings;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(917, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 206);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // AdminDashboard
            // 
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1262, 653);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnManageTrain);
            this.Controls.Add(this.btnShowTrainRoute);
            this.Controls.Add(this.btnShowTrainList);
            this.Controls.Add(this.btnManageBus);
            this.Controls.Add(this.btnShowBusRoute);
            this.Controls.Add(this.btnShowBusList);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnManageAdmin);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.lblAdminDashboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblAdminDashboard;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnManageAdmin;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnShowBusList;
        private System.Windows.Forms.Button btnShowBusRoute;
        private System.Windows.Forms.Button btnManageBus;
        private System.Windows.Forms.Button btnShowTrainList;
        private System.Windows.Forms.Button btnShowTrainRoute;
        private System.Windows.Forms.Button btnManageTrain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}