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
            DgvRobot = new DataGridView();
            No = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            BtnCreate = new Button();
            LblAlert = new Label();
            BtnUrl = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvRobot).BeginInit();
            SuspendLayout();
            // 
            // DgvRobot
            // 
            DgvRobot.AllowUserToAddRows = false;
            DgvRobot.AllowUserToDeleteRows = false;
            DgvRobot.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DgvRobot.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvRobot.Columns.AddRange(new DataGridViewColumn[] { No, name, Description, Id });
            DgvRobot.Location = new Point(12, 82);
            DgvRobot.Name = "DgvRobot";
            DgvRobot.ReadOnly = true;
            DgvRobot.RowTemplate.Height = 25;
            DgvRobot.Size = new Size(758, 356);
            DgvRobot.TabIndex = 5;
            DgvRobot.CellClick += DgvRobot_CellClick;
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
            // BtnCreate
            // 
            BtnCreate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnCreate.Location = new Point(638, 12);
            BtnCreate.Name = "BtnCreate";
            BtnCreate.Size = new Size(132, 46);
            BtnCreate.TabIndex = 4;
            BtnCreate.Text = "Add Robot";
            BtnCreate.UseVisualStyleBackColor = true;
            BtnCreate.Click += BtnCreate_Click;
            // 
            // LblAlert
            // 
            LblAlert.AutoSize = true;
            LblAlert.BackColor = Color.Red;
            LblAlert.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblAlert.Location = new Point(15, 447);
            LblAlert.Name = "LblAlert";
            LblAlert.Size = new Size(52, 21);
            LblAlert.TabIndex = 7;
            LblAlert.Text = "label1";
            LblAlert.Visible = false;
            // 
            // BtnUrl
            // 
            BtnUrl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnUrl.Location = new Point(12, 12);
            BtnUrl.Name = "BtnUrl";
            BtnUrl.Size = new Size(132, 46);
            BtnUrl.TabIndex = 6;
            BtnUrl.Text = "Connection";
            BtnUrl.UseVisualStyleBackColor = true;
            BtnUrl.Click += BtnUrl_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 475);
            Controls.Add(DgvRobot);
            Controls.Add(BtnCreate);
            Controls.Add(LblAlert);
            Controls.Add(BtnUrl);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Robot Manager";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)DgvRobot).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvRobot;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Id;
        private Button BtnCreate;
        private Label LblAlert;
        private Button BtnUrl;
    }
}