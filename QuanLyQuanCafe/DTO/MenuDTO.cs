using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class MenuDTO
    {
        string foodName;
        float foodCount;
        float price;
        float totalPrice;
        
        public MenuDTO(string foodname, float foodcount, float price, float totalprice = 0)
        {
            this.FoodName = foodname;
            this.FoodCount = foodcount;
            this.Price = price;
            this.TotalPrice = totalprice;
        }

        public MenuDTO(DataRow data)
        {
            this.FoodName = data["foodname"].ToString();

            string str = data["countbill"].ToString();

            this.FoodCount = float.Parse(str);
            str = data["price"].ToString();
            this.Price = float.Parse(str);
            str = data["totalprice"].ToString();
            this.TotalPrice = float.Parse(str);
        }

        public string FoodName { get => foodName; set => foodName = value; }
        public float FoodCount { get => foodCount; set => foodCount = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
