namespace RobotClient
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            robotGridView = new DataGridView();
            No = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            btnCreate = new Button();
            lblAlert = new Label();
            btnUrl = new Button();
            ((System.ComponentModel.ISupportInitialize)robotGridView).BeginInit();
            SuspendLayout();
            // 
            // robotGridView
            // 
            robotGridView.AllowUserToAddRows = false;
            robotGridView.AllowUserToDeleteRows = false;
            robotGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            robotGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            robotGridView.Columns.AddRange(new DataGridViewColumn[] { No, name, Description, Id });
            robotGridView.Location = new Point(12, 82);
            robotGridView.Name = "robotGridView";
            robotGridView.ReadOnly = true;
            robotGridView.RowTemplate.Height = 25;
            robotGridView.Size = new Size(758, 356);
            robotGridView.TabIndex = 5;
            // 
            // No
            // 
            No.HeaderText = "No";
            No.Name = "No";
            No.ReadOnly = true;
            No.SortMode = DataGridViewColumnSortMode.NotSortable;
            No.Width = 50;
            // 
            // name
            // 
            name.HeaderText = "Name";
            name.Name = "name";
            name.ReadOnly = true;
            name.SortMode = DataGridViewColumnSortMode.NotSortable;
            name.Width = 200;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.SortMode = DataGridViewColumnSortMode.NotSortable;
            Description.Width = 250;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.SortMode = DataGridViewColumnSortMode.NotSortable;
            Id.Visible = false;
            Id.Width = 50;
            // 
            // btnCreate
            // 
            btnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCreate.Location = new Point(638, 12);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(132, 46);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "Add Robot";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // lblAlert
            // 
            lblAlert.AutoSize = true;
            lblAlert.BackColor = Color.Red;
            lblAlert.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAlert.Location = new Point(15, 447);
            lblAlert.Name = "lblAlert";
            lblAlert.Size = new Size(52, 21);
            lblAlert.TabIndex = 7;
            lblAlert.Text = "label1";
            lblAlert.Visible = false;
            // 
            // btnUrl
            // 
            btnUrl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUrl.Location = new Point(12, 12);
            btnUrl.Name = "btnUrl";
            btnUrl.Size = new Size(132, 46);
            btnUrl.TabIndex = 6;
            btnUrl.Text = "Connection";
            btnUrl.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 475);
            Controls.Add(robotGridView);
            Controls.Add(btnCreate);
            Controls.Add(lblAlert);
            Controls.Add(btnUrl);
            Name = "FrmMain";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)robotGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView robotGridView;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Id;
        private Button btnCreate;
        private Label lblAlert;
        private Button btnUrl;
    }
}