using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class AccountDTO
    {
        int iD;
        string dislayName;
        string userName;
        string passWord;
        string accountType;
        public AccountDTO() { }
        public AccountDTO(int iD, string dislayName, string userName, string passWord, string accountType)
        {
            this.ID = iD;
            this.DislayName = dislayName;
            this.UserName = userName;
            this.PassWord = passWord;
            this.AccountType = accountType;
        }
        public AccountDTO(DataRow data)
        {
            this.ID = (int)data["iD"];
            this.DislayName = data["DislayName"].ToString();
            this.UserName = data["userName"].ToString();
            this.PassWord = data["passWord"].ToString();
            this.AccountType = data["accountType"].ToString();
        }

        public int ID { get => iD; set => iD = value; }
        public string DislayName { get => dislayName; set => dislayName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string AccountType { get => accountType; set => accountType = value; }
    }
}
