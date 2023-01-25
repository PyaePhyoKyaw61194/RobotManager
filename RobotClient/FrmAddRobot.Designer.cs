namespace RobotClient
{
    partial class FrmAddRobot
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
            LblOptional = new Label();
            LblNoti = new Label();
            BtnCreate = new Button();
            TxtDesc = new RichTextBox();
            LblDesc = new Label();
            TxtName = new TextBox();
            LblName = new Label();
            SuspendLayout();
            // 
            // LblOptional
            // 
            LblOptional.AutoSize = true;
            LblOptional.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblOptional.Location = new Point(22, 114);
            LblOptional.Name = "LblOptional";
            LblOptional.RightToLeft = RightToLeft.Yes;
            LblOptional.Size = new Size(80, 21);
            LblOptional.TabIndex = 13;
            LblOptional.Text = "(Optional)";
            // 
            // LblNoti
            // 
            LblNoti.AutoSize = true;
            LblNoti.BackColor = Color.Red;
            LblNoti.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblNoti.Location = new Point(150, 309);
            LblNoti.Name = "LblNoti";
            LblNoti.Size = new Size(52, 21);
            LblNoti.TabIndex = 12;
            LblNoti.Text = "label1";
            LblNoti.Visible = false;
            // 
            // BtnCreate
            // 
            BtnCreate.Location = new Point(150, 252);
            BtnCreate.Name = "BtnCreate";
            BtnCreate.Size = new Size(233, 43);
            BtnCreate.TabIndex = 11;
            BtnCreate.Text = "Create Robot";
            BtnCreate.UseVisualStyleBackColor = true;
            BtnCreate.Click += BtnCreate_Click;
            // 
            // TxtDesc
            // 
            TxtDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtDesc.Location = new Point(150, 93);
            TxtDesc.Name = "TxtDesc";
            TxtDesc.Size = new Size(233, 141);
            TxtDesc.TabIndex = 10;
            TxtDesc.Text = "";
            // 
            // LblDesc
            // 
            LblDesc.AutoSize = true;
            LblDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblDesc.Location = new Point(22, 93);
            LblDesc.Name = "LblDesc";
            LblDesc.Size = new Size(89, 21);
            LblDesc.TabIndex = 9;
            LblDesc.Text = "Description";
            // 
            // TxtName
            // 
            TxtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtName.Location = new Point(150, 20);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(233, 29);
            TxtName.TabIndex = 8;
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblName.Location = new Point(22, 23);
            LblName.Name = "LblName";
            LblName.Size = new Size(52, 21);
            LblName.TabIndex = 7;
            LblName.Text = "Name";
            // 
            // FrmAddRobot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 352);
            Controls.Add(LblOptional);
            Controls.Add(LblNoti);
            Controls.Add(BtnCreate);
            Controls.Add(TxtDesc);
            Controls.Add(LblDesc);
            Controls.Add(TxtName);
            Controls.Add(LblName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmAddRobot";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adding Robot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblOptional;
        private Label LblNoti;
        private Button BtnCreate;
        private RichTextBox TxtDesc;
        private Label LblDesc;
        private TextBox TxtName;
        private Label LblName;
    }
}