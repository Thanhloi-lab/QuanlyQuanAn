namespace QuanLyQuanCafe
{
    partial class LoginForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btExitLoginForm = new System.Windows.Forms.Button();
            this.btSign = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btExitLoginForm);
            this.panel1.Controls.Add(this.btSign);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.tbUsername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 109);
            this.panel1.TabIndex = 0;
            // 
            // btExitLoginForm
            // 
            this.btExitLoginForm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExitLoginForm.Location = new System.Drawing.Point(237, 83);
            this.btExitLoginForm.Name = "btExitLoginForm";
            this.btExitLoginForm.Size = new System.Drawing.Size(75, 23);
            this.btExitLoginForm.TabIndex = 5;
            this.btExitLoginForm.Text = "Exit";
            this.btExitLoginForm.UseVisualStyleBackColor = true;
            this.btExitLoginForm.Click += new System.EventHandler(this.btExitLoginForm_Click);
            // 
            // btSign
            // 
            this.btSign.Location = new System.Drawing.Point(156, 83);
            this.btSign.Name = "btSign";
            this.btSign.Size = new System.Drawing.Size(75, 23);
            this.btSign.TabIndex = 4;
            this.btSign.Text = "Sign in";
            this.btSign.UseVisualStyleBackColor = true;
            this.btSign.Click += new System.EventHandler(this.btSign_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(89, 47);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(217, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(89, 9);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(217, 20);
            this.tbUsername.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName :";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btSign;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btExitLoginForm;
            this.ClientSize = new System.Drawing.Size(341, 127);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Button btExitLoginForm;
        private System.Windows.Forms.Button btSign;
    }
}

