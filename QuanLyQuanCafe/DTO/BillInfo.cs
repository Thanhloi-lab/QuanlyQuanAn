using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DTO
{
    class BillInfo
    {
        int iD;
        int billID;
        int foodID;
        float countBill;

        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public float CountBill { get => countBill; set => countBill = value; }

        public BillInfo(int id, int foodid, int billid, float countbill)
        {
            this.ID = id;
            this.BillID = billid;
            this.FoodID = foodid;
            this.CountBill = countbill;
        }
        public BillInfo(DataRow data)
        {
            this.ID = (int)data["id"];
            this.BillID = (int)data["billid"];
            this.FoodID = (int)data["foodid"];
            string str = data["countbill"].ToString();
            this.CountBill = float.Parse(str);
        }
    }
}
