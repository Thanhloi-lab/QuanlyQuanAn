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
    public partial class AccountProfileForm : Form
    {
        AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get => loginAccount;
            set { loginAccount = value; LoadTextBoxChangeAccount(); }
        }

        public AccountProfileForm(AccountDTO loginAccount)
        {
            InitializeComponent();
            this.LoginAccount = loginAccount;
        }
        void LoadTextBoxChangeAccount()
        {
            tbUserName.Text = loginAccount.UserName;
            tbDisplayName.Text = loginAccount.DislayName;
        }
        void UpdateAccountInfo()
        {
            string dislayName = tbDisplayName.Text;
            string userName = tbUserName.Text;
            string passWord = tbPassWord.Text;
            string newPassWord = tbNewPassWord.Text;
            string reEnterNewPassWord = tbReEnerNewPassWord.Text;

            if (!newPassWord.Equals(reEnterNewPassWord))
                MessageBox.Show("ReEnter Password is incorrect!");
            else
            {
                if (Account.Instance.UpdateAccount(userName, dislayName, passWord, newPassWord))
                {
                    MessageBox.Show("Update complete!");
                    if(updateAccount != null)
                        updateAccount(this, new AccountEvent(Account.Instance.GetAccountByUserName(userName)));
                }
                else
                    MessageBox.Show("Password is incorrect!");
            }
        }
        private void btUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
        private void btQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
    }
    public class AccountEvent:EventArgs
    {
        AccountDTO account;
        public AccountEvent(AccountDTO account)
        {
            this.Account = account;
        }

        public AccountDTO Account { get => account; set => account = value; }
    }
}
