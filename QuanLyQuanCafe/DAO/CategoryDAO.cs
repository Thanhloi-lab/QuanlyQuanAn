using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        static CategoryDAO instance;

        public static CategoryDAO Instance 
        {   
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            set => instance = value; 
        }

        private CategoryDAO() { }

        public List<CategoryDTO> GetCategory()
        {
            List<CategoryDTO> listCategory = new List<CategoryDTO>();
            string query = "SELECT *FROM FoodCategory WHERE Active = 1";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CategoryDTO categoryRow = new CategoryDTO(item);
                listCategory.Add(categoryRow);
            }
            return listCategory;
        }
        public CategoryDTO GetCategoryByID(int categoryID)
        {
            CategoryDTO category = null;
            string query = "SELECT *FROM FoodCategory WHERE ID = " + categoryID;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new CategoryDTO(item);
                return category;
            }
            return category;
        }
        public bool AddCategory(string foodName)
        {
            string query = string.Format("Insert FoodCategory(FoodName) VALUES (N'{0}')", foodName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditCategory(string foodName, int categoryID)
        {
            string query = string.Format("Update FoodCategory SET FoodName = N'{0}' WHERE ID = {1}", foodName, categoryID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteCategory(int categoryID)
        {
            FoodDAO.Instance.DeleteFoodByCategoryID(categoryID);
            string query = string.Format("Update FoodCategory SET Active = 0 WHERE ID = {0}", categoryID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
