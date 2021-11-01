using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class FoodDTO
    {
        int iD;
        string name;
        float price;
        int categoryID;
        public FoodDTO(int iD, string name, float price, int categoryID)
        {
            this.ID = iD;
            this.Name = name;
            this.Price = price;
            this.CategoryID = categoryID;
        }

        public FoodDTO(DataRow data)
        {
            this.ID = (int)data["iD"];
            this.Name = data["foodname"].ToString();
            string str = data["price"].ToString();
            this.Price = float.Parse(str);
            this.CategoryID = (int)data["categoryID"];
        }
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public int ID { get => iD; set => iD = value; }
    }
}
