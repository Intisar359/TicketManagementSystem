using System.Windows.Forms;

namespace TicketManagementSystem
{
    partial class ManageTrain
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridViewTrainList;
        private Button btnBack;
        private Button btnSignOut;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnRefresh;
        private TextBox txtTrainId;
        private TextBox txtTrainName;
        private TextBox txtFrom;
        private TextBox txtTo;
        private DateTimePicker dtpDate;
        private TextBox txtClass;
        private TextBox txtRoute;
        private TextBox txtEstimatedTime;
        private TextBox txtReservedSeats;
        private TextBox txtAvailableSeats;
        private TextBox txtPrice;
        private Label lblTrainId;
        private Label lblTrainName;
        private Label lblFrom;
        private Label lblTo;
        private Label lblDate;
        private Label lblClass;
        private Label lblRoute;
        private Label lblDepartureTime;
        private Label lblEstimatedTime;
        private Label lblReservedSeats;
        private Label lblAvailableSeats;
        private Label lblPrice;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageTrain));
            this.dataGridViewTrainList = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtTrainId = new System.Windows.Forms.TextBox();
            this.txtTrainName = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.txtEstimatedTime = new System.Windows.Forms.TextBox();
            this.txtReservedSeats = new System.Windows.Forms.TextBox();
            this.txtAvailableSeats = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblTrainId = new System.Windows.Forms.Label();
            this.lblTrainName = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblRoute = new System.Windows.Forms.Label();
            this.lblDepartureTime = new System.Windows.Forms.Label();
            this.lblEstimatedTime = new System.Windows.Forms.Label();
            this.lblReservedSeats = new System.Windows.Forms.Label();
            this.lblAvailableSeats = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.dtpDepartureTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrainList)).BeginInit();
            this.SuspendLayout();
            // 
            // 
            // 
            this.dataGridViewTrainList.AllowDrop = true;
            this.dataGridViewTrainList.AllowUserToAddRows = false;
            this.dataGridViewTrainList.AllowUserToDeleteRows = false;
            this.dataGridViewTrainList.AllowUserToResizeColumns = false;
            this.dataGridViewTrainList.AllowUserToResizeRows = false;
            this.dataGridViewTrainList.BackgroundColor = System.Drawing.Color.LightSeaGreen;
            this.dataGridViewTrainList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrainList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewTrainList.Location = new System.Drawing.Point(30, 58);
            this.dataGridViewTrainList.Name = "dataGridViewTrainList";
            this.dataGridViewTrainList.ReadOnly = true;
            this.dataGridViewTrainList.RowHeadersWidth = 51;
            this.dataGridViewTrainList.Size = new System.Drawing.Size(1201, 268);
            this.dataGridViewTrainList.TabIndex = 0;
            this.dataGridViewTrainList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTrainList_CellClick);
            // 
            // 
            // 
            this.btnBack.BackgroundImage = global::TicketManagementSystem.Properties.Resources.png_transparent_arrow_computer_icons_encapsulated_postscript_button_back_icon_angle_logo_left_arrow;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(69, 40);
            this.btnBack.TabIndex = 1;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // 
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.LightCoral;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(1150, 12);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(100, 40);
            this.btnSignOut.TabIndex = 2;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // 
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.Chartreuse;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(440, 523);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // 
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(737, 523);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            //
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.BackColor = System.Drawing.Color.Coral;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(588, 523);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            //
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(575, 599);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(127, 40);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // 
            // 
            this.txtTrainId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrainId.Location = new System.Drawing.Point(216, 350);
            this.txtTrainId.Name = "txtTrainId";
            this.txtTrainId.ReadOnly = true;
            this.txtTrainId.Size = new System.Drawing.Size(146, 24);
            this.txtTrainId.TabIndex = 7;
            this.txtTrainId.Text = "Auto-generated";
            // 
            // 
            // 
            this.txtTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrainName.Location = new System.Drawing.Point(216, 383);
            this.txtTrainName.Name = "txtTrainName";
            this.txtTrainName.Size = new System.Drawing.Size(146, 24);
            this.txtTrainName.TabIndex = 8;
            // 
            // 
            // 
            this.txtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(216, 413);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(146, 24);
            this.txtFrom.TabIndex = 9;
            // 
            // 
            // 
            this.txtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(216, 443);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(146, 24);
            this.txtTo.TabIndex = 10;
            // 
            // 
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(527, 354);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(299, 24);
            this.dtpDate.TabIndex = 11;
            // 
            // 
            // 
            this.txtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.Location = new System.Drawing.Point(527, 384);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(299, 24);
            this.txtClass.TabIndex = 12;
            // 
            // 
            // 
            this.txtRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoute.Location = new System.Drawing.Point(527, 414);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(299, 24);
            this.txtRoute.TabIndex = 13;
            // 
            // 
            // 
            this.txtEstimatedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimatedTime.Location = new System.Drawing.Point(1003, 350);
            this.txtEstimatedTime.Name = "txtEstimatedTime";
            this.txtEstimatedTime.Size = new System.Drawing.Size(166, 24);
            this.txtEstimatedTime.TabIndex = 15;
            // 
            // 
            // 
            this.txtReservedSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReservedSeats.Location = new System.Drawing.Point(1003, 380);
            this.txtReservedSeats.Name = "txtReservedSeats";
            this.txtReservedSeats.Size = new System.Drawing.Size(166, 24);
            this.txtReservedSeats.TabIndex = 16;
            // 
            // 
            // 
            this.txtAvailableSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvailableSeats.Location = new System.Drawing.Point(1003, 410);
            this.txtAvailableSeats.Name = "txtAvailableSeats";
            this.txtAvailableSeats.Size = new System.Drawing.Size(166, 24);
            this.txtAvailableSeats.TabIndex = 17;
            // 
            // 
            // 
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(1003, 440);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(166, 24);
            this.txtPrice.TabIndex = 18;
            // 
            // 
            // 
            this.lblTrainId.BackColor = System.Drawing.Color.Cyan;
            this.lblTrainId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainId.Location = new System.Drawing.Point(99, 350);
            this.lblTrainId.Name = "lblTrainId";
            this.lblTrainId.Size = new System.Drawing.Size(100, 23);
            this.lblTrainId.TabIndex = 19;
            this.lblTrainId.Text = "TrainId";
            // 
            // 
            // 
            this.lblTrainName.BackColor = System.Drawing.Color.Cyan;
            this.lblTrainName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainName.Location = new System.Drawing.Point(99, 380);
            this.lblTrainName.Name = "lblTrainName";
            this.lblTrainName.Size = new System.Drawing.Size(100, 23);
            this.lblTrainName.TabIndex = 20;
            this.lblTrainName.Text = "Train Name";
            // 
            //
            // 
            this.lblFrom.BackColor = System.Drawing.Color.Cyan;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(99, 410);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(100, 23);
            this.lblFrom.TabIndex = 21;
            this.lblFrom.Text = "From";
            // 
            // 
            // 
            this.lblTo.BackColor = System.Drawing.Color.Cyan;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(99, 440);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(100, 23);
            this.lblTo.TabIndex = 22;
            this.lblTo.Text = "To";
            // 
            // 
            // 
            this.lblDate.BackColor = System.Drawing.Color.Cyan;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(380, 354);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(132, 23);
            this.lblDate.TabIndex = 23;
            this.lblDate.Text = "Date";
            // 
            // 
            // 
            this.lblClass.BackColor = System.Drawing.Color.Cyan;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(380, 384);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(132, 23);
            this.lblClass.TabIndex = 24;
            this.lblClass.Text = "Class";
            // 
            // 
            // 
            this.lblRoute.BackColor = System.Drawing.Color.Cyan;
            this.lblRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoute.Location = new System.Drawing.Point(380, 414);
            this.lblRoute.Name = "lblRoute";
            this.lblRoute.Size = new System.Drawing.Size(132, 23);
            this.lblRoute.TabIndex = 25;
            this.lblRoute.Text = "Route";
            // 
            // 
            // 
            this.lblDepartureTime.BackColor = System.Drawing.Color.Cyan;
            this.lblDepartureTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartureTime.Location = new System.Drawing.Point(380, 444);
            this.lblDepartureTime.Name = "lblDepartureTime";
            this.lblDepartureTime.Size = new System.Drawing.Size(132, 23);
            this.lblDepartureTime.TabIndex = 26;
            this.lblDepartureTime.Text = "Departure Time";
            // 
            // 
            // 
            this.lblEstimatedTime.BackColor = System.Drawing.Color.Cyan;
            this.lblEstimatedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedTime.Location = new System.Drawing.Point(848, 351);
            this.lblEstimatedTime.Name = "lblEstimatedTime";
            this.lblEstimatedTime.Size = new System.Drawing.Size(136, 23);
            this.lblEstimatedTime.TabIndex = 27;
            this.lblEstimatedTime.Text = "Estimated Time";
            // 
            // 
            // 
            this.lblReservedSeats.BackColor = System.Drawing.Color.Cyan;
            this.lblReservedSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservedSeats.Location = new System.Drawing.Point(848, 381);
            this.lblReservedSeats.Name = "lblReservedSeats";
            this.lblReservedSeats.Size = new System.Drawing.Size(136, 23);
            this.lblReservedSeats.TabIndex = 28;
            this.lblReservedSeats.Text = "Reserved Seats";
            // 
            // 
            this.lblAvailableSeats.BackColor = System.Drawing.Color.Cyan;
            this.lblAvailableSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableSeats.Location = new System.Drawing.Point(848, 411);
            this.lblAvailableSeats.Name = "lblAvailableSeats";
            this.lblAvailableSeats.Size = new System.Drawing.Size(136, 23);
            this.lblAvailableSeats.TabIndex = 29;
            this.lblAvailableSeats.Text = "Available Seats";
            // 
            // 
            // 
            this.lblPrice.BackColor = System.Drawing.Color.Cyan;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(848, 441);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(136, 23);
            this.lblPrice.TabIndex = 30;
            this.lblPrice.Text = "Price";
            // 
            // 
            // 
            this.dtpDepartureTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDepartureTime.Location = new System.Drawing.Point(527, 442);
            this.dtpDepartureTime.Name = "dtpDepartureTime";
            this.dtpDepartureTime.Size = new System.Drawing.Size(299, 24);
            this.dtpDepartureTime.TabIndex = 31;
            // 
            //
            // 
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1262, 753);
            this.Controls.Add(this.dtpDepartureTime);
            this.Controls.Add(this.dataGridViewTrainList);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtTrainId);
            this.Controls.Add(this.txtTrainName);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtRoute);
            this.Controls.Add(this.txtEstimatedTime);
            this.Controls.Add(this.txtReservedSeats);
            this.Controls.Add(this.txtAvailableSeats);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblTrainId);
            this.Controls.Add(this.lblTrainName);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblRoute);
            this.Controls.Add(this.lblDepartureTime);
            this.Controls.Add(this.lblEstimatedTime);
            this.Controls.Add(this.lblReservedSeats);
            this.Controls.Add(this.lblAvailableSeats);
            this.Controls.Add(this.lblPrice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Train";
            this.Load += new System.EventHandler(this.ManageTrain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrainList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox dtpDepartureTime;
    }
}
