namespace LibraryGames
{
    partial class frmLogin
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            btnClose = new Button();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(93, 9);
            label1.Name = "label1";
            label1.Size = new Size(386, 46);
            label1.TabIndex = 0;
            label1.Text = "Welcome! Please Login";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(33, 113);
            label2.Name = "label2";
            label2.Size = new Size(96, 23);
            label2.TabIndex = 1;
            label2.Text = "Username :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(33, 195);
            label3.Name = "label3";
            label3.Size = new Size(89, 23);
            label3.TabIndex = 2;
            label3.Text = "Password :";
            // 
            // txtUserName
            // 
            txtUserName.BorderStyle = BorderStyle.FixedSingle;
            txtUserName.Location = new Point(170, 113);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(290, 27);
            txtUserName.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(170, 191);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(290, 27);
            txtPassword.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(531, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(31, 29);
            btnClose.TabIndex = 5;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(234, 251);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(101, 45);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 308);
            Controls.Add(btnLogin);
            Controls.Add(btnClose);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Button btnClose;
        private Button btnLogin;
    }
}
