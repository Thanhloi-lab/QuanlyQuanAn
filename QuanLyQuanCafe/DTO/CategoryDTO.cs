using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class CategoryDTO
    {
        int iD;
        string foodName;
        public CategoryDTO(int iD, string categoryName)
        {
            this.ID = iD;
            this.FoodName = categoryName;
        }
        public CategoryDTO(DataRow data)
        {
            this.ID = (int)data["ID"];
            this.FoodName = data["FoodName"].ToString();
        }
        public int ID { get => iD; set => iD = value; }
        public string FoodName { get => foodName; set => foodName = value; }
    }
}
