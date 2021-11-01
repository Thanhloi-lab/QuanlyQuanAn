using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btSign_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            if (Login(username, password))
            {
                AccountDTO loginAccount = Account.Instance.GetAccountByUserName(username);
                ManageForm Form2 = new ManageForm(loginAccount);
                this.Hide();
                Form2.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect!");
            }
        }

        bool Login(string username, string password)
        {
            return Account.Instance.Login(username, password);
        }
        private void btExitLoginForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Do you want to quit the program", "Announce",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
