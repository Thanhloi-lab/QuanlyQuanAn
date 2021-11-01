using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {
        int iD;
        string tableName;
        string tableStatus;

        public int ID { get => iD; set => iD = value; }
        public string TableName { get => tableName; set => tableName = value; }
        public string TableStatus { get => tableStatus; set => tableStatus = value; }

        public Table(int id, string tablename, string tablestatus)
        {
            this.ID = id;
            this.TableName = tablename;
            this.TableStatus = tablestatus;
        }
        
        public Table(DataRow data)
        {
            this.ID = (int)data["id"];
            this.TableName = data["TableName"].ToString();
            this.TableStatus = data["TableStatus"].ToString();
        }
    }
}
