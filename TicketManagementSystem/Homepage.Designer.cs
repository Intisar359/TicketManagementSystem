using System.Windows.Forms;
using System;

namespace TicketManagementSystem
{
    partial class HomePageForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnLetsStart;
        private Button btnContribution;
        private PictureBox pictureBoxContribution;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePageForm));
            this.btnLetsStart = new System.Windows.Forms.Button();
            this.btnContribution = new System.Windows.Forms.Button();
            this.pictureBoxContribution = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLetsStart
            // 
            this.btnLetsStart.BackColor = System.Drawing.Color.Salmon;
            this.btnLetsStart.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLetsStart.Location = new System.Drawing.Point(499, 187);
            this.btnLetsStart.Name = "btnLetsStart";
            this.btnLetsStart.Size = new System.Drawing.Size(250, 40);
            this.btnLetsStart.TabIndex = 0;
            this.btnLetsStart.Text = "Let\'s Start";
            this.btnLetsStart.UseVisualStyleBackColor = false;
            this.btnLetsStart.Click += new System.EventHandler(this.btnLetsStart_Click);
            // 
            // btnContribution
            // 
            this.btnContribution.BackColor = System.Drawing.Color.Salmon;
            this.btnContribution.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContribution.Location = new System.Drawing.Point(499, 233);
            this.btnContribution.Name = "btnContribution";
            this.btnContribution.Size = new System.Drawing.Size(250, 40);
            this.btnContribution.TabIndex = 1;
            this.btnContribution.Text = "Contribution";
            this.btnContribution.UseVisualStyleBackColor = false;
            this.btnContribution.Click += new System.EventHandler(this.btnContribution_Click);
            // 
            // pictureBoxContribution
            // 
            this.pictureBoxContribution.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxContribution.BackgroundImage")));
            this.pictureBoxContribution.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxContribution.ErrorImage = null;
            this.pictureBoxContribution.Image = global::TicketManagementSystem.Properties.Resources.contribution;
            this.pictureBoxContribution.InitialImage = null;
            this.pictureBoxContribution.Location = new System.Drawing.Point(271, 277);
            this.pictureBoxContribution.Name = "pictureBoxContribution";
            this.pictureBoxContribution.Size = new System.Drawing.Size(754, 360);
            this.pictureBoxContribution.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxContribution.TabIndex = 2;
            this.pictureBoxContribution.TabStop = false;
            this.pictureBoxContribution.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Ivory;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(448, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 56);
            this.label1.TabIndex = 3;
            this.label1.Text = "KOTHIN TICKET";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::TicketManagementSystem.Properties.Resources.bus4;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(203, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 112);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::TicketManagementSystem.Properties.Resources.rail;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(974, 187);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(108, 112);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // HomePageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackgroundImage = global::TicketManagementSystem.Properties.Resources.home;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1258, 649);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLetsStart);
            this.Controls.Add(this.btnContribution);
            this.Controls.Add(this.pictureBoxContribution);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Algerian", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HomePageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.HomePageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContribution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}