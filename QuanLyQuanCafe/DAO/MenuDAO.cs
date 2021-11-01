using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class MenuDAO
    {
        static MenuDAO instance;

        public static MenuDAO Instance {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            set => instance = value; }

        private MenuDAO() { }

        public List<MenuDTO> GetListMenuByTable(int TableID)
        {
            List<MenuDTO> listmenu = new List<MenuDTO>();
            string query = "SELECT f.FoodName, bi.CountBill, f.Price, (bi.CountBill*f.Price) AS TotalPrice FROM Food as f, BillInfo as bi, Bill as b WHERE bi.BillID = b.ID AND f.ID = bi.FoodID AND b.BillStatus = 0 AND b.TableID = " + TableID;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                MenuDTO menu = new MenuDTO(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
            

    }
}
