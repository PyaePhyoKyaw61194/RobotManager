namespace RobotClient
{
    partial class FrmUpdateRobot
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
            LblNoti = new Label();
            BtnUpdate = new Button();
            TxtDesc = new RichTextBox();
            LblDesc = new Label();
            TxtName = new TextBox();
            LblName = new Label();
            label2 = new Label();
            label1 = new Label();
            LblOptional = new Label();
            SuspendLayout();
            // 
            // LblNoti
            // 
            LblNoti.AutoSize = true;
            LblNoti.BackColor = Color.Red;
            LblNoti.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblNoti.Location = new Point(155, 323);
            LblNoti.Name = "LblNoti";
            LblNoti.Size = new Size(52, 21);
            LblNoti.TabIndex = 18;
            LblNoti.Text = "label3";
            LblNoti.Visible = false;
            // 
            // BtnUpdate
            // 
            BtnUpdate.Location = new Point(155, 266);
            BtnUpdate.Name = "BtnUpdate";
            BtnUpdate.Size = new Size(245, 43);
            BtnUpdate.TabIndex = 17;
            BtnUpdate.Text = "Update Robot";
            BtnUpdate.UseVisualStyleBackColor = true;
            BtnUpdate.Click += BtnUpdate_Click;
            // 
            // TxtDesc
            // 
            TxtDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtDesc.Location = new Point(155, 96);
            TxtDesc.Name = "TxtDesc";
            TxtDesc.Size = new Size(245, 141);
            TxtDesc.TabIndex = 16;
            TxtDesc.Text = "";
            // 
            // LblDesc
            // 
            LblDesc.AutoSize = true;
            LblDesc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblDesc.Location = new Point(27, 96);
            LblDesc.Name = "LblDesc";
            LblDesc.Size = new Size(89, 21);
            LblDesc.TabIndex = 15;
            LblDesc.Text = "Description";
            // 
            // TxtName
            // 
            TxtName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtName.Location = new Point(155, 23);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(245, 29);
            TxtName.TabIndex = 14;
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblName.Location = new Point(27, 26);
            LblName.Name = "LblName";
            LblName.Size = new Size(52, 21);
            LblName.TabIndex = 13;
            LblName.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(293, 93);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(54, 47);
            label1.Name = "label1";
            label1.Size = new Size(0, 21);
            label1.TabIndex = 11;
            // 
            // LblOptional
            // 
            LblOptional.AutoSize = true;
            LblOptional.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblOptional.Location = new Point(27, 117);
            LblOptional.Name = "LblOptional";
            LblOptional.RightToLeft = RightToLeft.Yes;
            LblOptional.Size = new Size(80, 21);
            LblOptional.TabIndex = 19;
            LblOptional.Text = "(Optional)";
            // 
            // FrmUpdateRobot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 393);
            Controls.Add(LblOptional);
            Controls.Add(LblNoti);
            Controls.Add(BtnUpdate);
            Controls.Add(TxtDesc);
            Controls.Add(LblDesc);
            Controls.Add(TxtName);
            Controls.Add(LblName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmUpdateRobot";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Updating Robot";
            Shown += FrmUpdateRobot_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblNoti;
        private Button BtnUpdate;
        private RichTextBox TxtDesc;
        private Label LblDesc;
        private TextBox TxtName;
        private Label LblName;
        private Label label2;
        private Label label1;
        private Label LblOptional;
    }
}