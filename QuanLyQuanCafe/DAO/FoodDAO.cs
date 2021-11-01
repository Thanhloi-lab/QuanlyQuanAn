using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            set => instance = value;
        }
        private FoodDAO() { }
        public List<FoodDTO> GetListFoodByCategoryID(int iD)
        {
            List<FoodDTO> listfood = new List<FoodDTO>();
            string query = "SELECT *FROM Food WHERE Active = 1 AND CategoryID = " + iD;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO foodRow = new FoodDTO(item);
                listfood.Add(foodRow);
            }
            return listfood;
        }
        public List<FoodDTO> GetListFood()
        {
            List<FoodDTO> listfood = new List<FoodDTO>();
            string query = "SELECT *FROM Food where active = 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                FoodDTO foodRow = new FoodDTO(item);
                listfood.Add(foodRow);
            }
            return listfood;
        }
        public bool InsertFood(string foodName, float price, int categoryID)
        {
            string query = string.Format("INSERT Food(FoodName, Price, CategoryID) VALUES (N'{0}',{1},{2})", foodName, price, categoryID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditFood(string foodName, float price, int categoryID, int foodID)
        {
            string query = string.Format("UPDATE Food SET FoodName = N'{0}', Price = {1}, CategoryID = {2} WHERE ID = {3}", foodName, price, categoryID, foodID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFood(int foodID)
        {
            string query = string.Format("Update Food SET Active = 0 WHERE ID = {0}", foodID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteFoodByCategoryID(int categoryID)
        {
            string query = string.Format("Update Food SET Active = 0 WHERE CategoryID = {0}", categoryID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<FoodDTO> SearchFoodByName(string foodName)
        {
            string query = string.Format("select *from food where Active = 1 AND dbo.fuconverttounsign(FoodName) like N'%'+ dbo.fuconverttounsign(N'{0}') + '%'", foodName);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            List<FoodDTO> listFood = new List<FoodDTO>();
            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                listFood.Add(food);
            }
            return listFood;
        }
    }
}
