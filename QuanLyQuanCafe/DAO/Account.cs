using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAO
{
    public class Account
    {
        static Account instance;

        public static Account Instance 
            { get { if (instance == null) instance = new Account(); return instance; }  
            private set => instance = value; }

        private Account() { }

        public bool Login(string username, string password)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            string query = "SelectAccount @username , @password";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {username, hasPass});
            
            return data.Rows.Count>0;
        }
        public AccountDTO GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account where Active = 1 AND UserName = '" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }

            return null;
        }
        public AccountDTO GetAccountByID(int accountID)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account where Active = 1 AND ID =" + accountID);
            foreach (DataRow item in data.Rows)
            {
                return new AccountDTO(item);
            }
            return null;
        }
        public bool UpdateAccount(string userName, string dislayName, string passWord, string newPassWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] temp1 = ASCIIEncoding.ASCII.GetBytes(newPassWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            byte[] hasData1 = new MD5CryptoServiceProvider().ComputeHash(temp1);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            string hasPass1 = "";
            foreach (byte item in hasData1)
            {
                hasPass1 += item;
            }
            int isComplete = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccount @DislayName , @UserName , @PassWord , @NewPassWord", new object[] {dislayName, userName, hasPass, hasPass1 });
            return isComplete > 0;
        }
        public DataTable LoadListAccount()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT ID, UserName, DislayName, AccountType FROM Account WHERE Active = 1");
            return data;
        }
        public bool ResetPassword(int accountID)
        {
            string query = string.Format("Update Account SET password = '1962026656160185351301320480154111117132155' WHERE ID = {0}", accountID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool InsertAccount(string userName, string dislayName, string accountType)
        {
            string query = string.Format("Select COUNT(*) from Account WHERE UserName = N'{0}' AND Active = 1", userName);
            if ((int)DataProvider.Instance.ExecuteScalar(query) > 0)
            {
                MessageBox.Show("Username was exist !");
                return false;
            }
            string query1 = "EXEC USP_InsertAccount @UserName , @DislayName , @AccountType";
            int result = DataProvider.Instance.ExecuteNonQuery(query1, new object[] { userName, dislayName, accountType });
            return result > 0;
        }
        public bool EditAccount(string userName, string dislayName, string accountType, int accountID)
        {
            int result = 0;

            try 
            {
                string query1 = string.Format("Update account set UserName = '{0}', DislayName = '{1}' , AccountType = '{2}' WHERE ID = {3}", userName, dislayName, accountType, accountID);
                result = DataProvider.Instance.ExecuteNonQuery(query1);
            }
            catch 
            {
                MessageBox.Show("Username was exist!");
                result = 0;
            }
            return result > 0;
        }
        public int DeleteAccount(int accountID)
        {
            int isLastAdmin = (int)DataProvider.Instance.ExecuteScalar("Select Count(*) from account WHERE AccountType = 1 AND Active = 1 AND ID = 1");
            int isAdmin = (int)DataProvider.Instance.ExecuteScalar("Select Count(*) from account WHERE AccountType = 1 AND Active = 1 AND ID = " + accountID);
            string query1 = string.Format("Update Account Set Active = 0 WHERE ID = " + accountID);
            if (isLastAdmin == 1 && isAdmin == 1)
            {
                MessageBox.Show("Can't delete the last admin");
                return 1;
            }
            if(isAdmin == 1)
            {
                MessageBox.Show("Can't delete the current login account As Administrator");
                return 2;
            }
            
            int result = DataProvider.Instance.ExecuteNonQuery(query1);
            if (result > 0)
                return 3;
            return 4;
        }
    }
}
