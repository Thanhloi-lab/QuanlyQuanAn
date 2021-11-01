using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DTO
{
    class Bill
    {
        int billStatus;
        DateTime? dateCheckIn;
        DateTime? dateCheckOut;
        int iD;
        int discount;
        public Bill(int ID, int billStatus, DateTime? dateCheckIn, DateTime? dateCheckOut, int discount)
        {
            this.ID = ID;
            this.BillStatus = billStatus;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Discount = discount;
        }

        public Bill(DataRow data)
        {
            this.ID = (int)data["ID"];
            if(data["BillStatus"].ToString()=="False")
                this.BillStatus = 0;
            else 
                this.BillStatus = 1;
            this.DateCheckIn = (DateTime?)data["DateCheckIn"];

            var dateCheckOutTemp = data["DateCheckOut"];
            if(dateCheckOutTemp.ToString() != "") 
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Discount = (int)data["discount"];
        }

        public int BillStatus { get => billStatus; set => billStatus = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int ID { get => iD; set => iD = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
