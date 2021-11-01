using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAO
{
    class TableDAO
    {
        private static TableDAO instance;
        public static int tableWidth = 85;
        public static int tableHeight = 85;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set => Instance = value;
        }
        private TableDAO() { }
        public List<Table> LoadListTable()
        {
            List<Table> listTable = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetListTable");

            foreach (DataRow item in data.Rows)
            {
                Table tb = new Table(item);
                listTable.Add(tb);
            }

            return listTable;
        }
        public Table LoadTableByID(int tableID)
        {
            Table table = null;
            DataTable data = DataProvider.Instance.ExecuteQuery("Select *from Tables WHERE Active = 1 AND ID = " + tableID);
            foreach (DataRow item in data.Rows)
            {
                table = new Table(item);
                return table;
            }
            return table;
        }
        public void SwitchTable(int TableID1, int TableID2)
        {
            string query = "EXEC USP_SwitchTable @id1 , @id2";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { TableID1, TableID2 });
        }
        public bool InsertTable(string tableName)
        {
            string query = string.Format("Insert Tables (TableName) VALUES (N'{0}')", tableName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditTable(string tableName, int tableID)
        {
            string query = string.Format("Update Tables SET TableName = N'{0}' WHERE ID = {1}", tableName, tableID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteTable(int ID)
        {
            string query = string.Format("Update Tables SET Active = 0 WHERE TableStatus = 0 AND ID = " + ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
