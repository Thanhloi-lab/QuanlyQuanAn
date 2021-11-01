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
    class BillInfoDAO
    {
        static BillInfoDAO instance;

        public static BillInfoDAO Instance {
            get { if (instance == null) instance = new BillInfoDAO(); return instance; }
            private set => instance = value; }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int billID)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT *FROM BillInfo WHERE BillID = " + billID);
            
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        public void InsertBillInfo(int billID, int foodID, float countBill)
        {
            string query = "exec USP_InserBillInfo @BillID , @FoodID , @CountBill";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { billID, foodID, countBill });
        }
        public void DeleteBillInfoByFoodID(int foodID)
        {
            DataProvider.Instance.ExecuteNonQuery("update BillInfo set active = 0 WHERE FoodID = " + foodID);
        }
    }
}
