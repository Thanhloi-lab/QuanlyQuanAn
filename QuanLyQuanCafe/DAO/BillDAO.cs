using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAO
{
    class BillDAO
    {
        static BillDAO instance;

        public static BillDAO Instance {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value; }

        private BillDAO() { }
        public int GetUnCheckBillIDByTableID(int tableID)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT *FROM Bill WHERE TableID =" + tableID + " AND BillStatus = 0");
            if(data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }
        public void InsertBill(int TableID)
        {
            string query = "exec USP_InserBill @TableID";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { TableID });
        }
        public int GetMaxBillID()
        {
            return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(ID) FROM Bill");
        }
        public void CheckOut(int BillID, int discount, float totalPrice, int accountID)
        {
            string query = "UPDATE dbo.Bill SET BillStatus = 1, discount = " + discount + ", DateCheckOut = GETDATE(), CheckOutByAccountID = " + accountID + ", TotalPrice = " + totalPrice + " WHERE ID = " + BillID;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable GetBillListByDateAndPage(DateTime dateIn, DateTime dateOut, int page, int step)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDateAndPage @CheckIn , @CheckOut , @page , @pageRows", new object[] { dateIn, dateOut, page, step});
        }
        public int GetCountBill(DateTime dateIn, DateTime dateOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("EXEC USP_GetCountBillByDate @CheckIn , @CheckOut", new object[] { dateIn, dateOut});
        }
    }
}
