namespace RobotClient
{
    partial class FrmUrl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblAlert = new Label();
            BtnUpdate = new Button();
            TxtUrl = new TextBox();
            LblUrl = new Label();
            SuspendLayout();
            // 
            // lblAlert
            // 
            lblAlert.AutoSize = true;
            lblAlert.BackColor = Color.Red;
            lblAlert.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAlert.Location = new Point(105, 23);
            lblAlert.Name = "lblAlert";
            lblAlert.Size = new Size(152, 21);
            lblAlert.TabIndex = 7;
            lblAlert.Text = "Connection Problem";
            lblAlert.Visible = false;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnUpdate.Location = new Point(389, 97);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(104, 36);
            BtnUpdate.TabIndex = 6;
            BtnUpdate.Text = "Update";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_ClickAsync;
            // 
            // TxtUrl
            // 
            TxtUrl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtUrl.Location = new Point(105, 62);
            TxtUrl.Name = "TxtUrl";
            TxtUrl.Size = new Size(388, 29);
            TxtUrl.TabIndex = 5;
            // 
            // LblUrl
            // 
            LblUrl.AutoSize = true;
            LblUrl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblUrl.Location = new Point(17, 65);
            LblUrl.Name = "LblUrl";
            LblUrl.Size = new Size(86, 21);
            LblUrl.TabIndex = 4;
            LblUrl.Text = "Base URL : ";
            // 
            // FrmUrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 147);
            Controls.Add(lblAlert);
            Controls.Add(BtnUpdate);
            Controls.Add(TxtUrl);
            Controls.Add(LblUrl);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmUrl";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Connection Url";
            Load += FrmUrl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAlert;
        private Button BtnUpdate;
        private TextBox TxtUrl;
        private Label LblUrl;
    }
}