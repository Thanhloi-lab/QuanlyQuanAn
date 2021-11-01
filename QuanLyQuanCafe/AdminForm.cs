using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class AdminForm : Form
    {
        BindingSource listFood = new BindingSource();
        BindingSource listCategory = new BindingSource();
        BindingSource listTable = new BindingSource();
        BindingSource listAccount = new BindingSource();
        AccountDTO loginAccount;

        public AccountDTO LoginAccount { get => loginAccount; set => loginAccount = value; }

        public AdminForm(AccountDTO account)
        {
            InitializeComponent();
            this.loginAccount = account;
            LoadForm();
        }

        #region Methods
        void LoadListBillByDate(DateTime dateIn, DateTime dateOut)
        {
            dgvRevenue.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dateIn, dateOut, int.Parse(tbPage.Text), 15);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpDateStart.Value = new DateTime(today.Year, today.Month, 1);
            dtpDateFinish.Value = dtpDateStart.Value.AddMonths(1).AddDays(-1);
        }
        void LoadForm()
        {
            dgvFood.DataSource = listFood;
            dgvCategory.DataSource = listCategory;
            dgvTable.DataSource = listTable;
            dgvAccount.DataSource = listAccount;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpDateStart.Value, dtpDateFinish.Value);
            LoadTabFood();
            BindingFood();
            LoadTabCategory();
            BindingCategory();
            LoadTabTable();
            BindingTable();
            LoadTabAccount();
            BindingAccount();
        }
        void LoadTabFood()
        {
            listFood.DataSource = FoodDAO.Instance.GetListFood();
            cbCategoryFood.DataSource = CategoryDAO.Instance.GetCategory();
            cbCategoryFood.DisplayMember = "FoodName";
        }
        void BindingFood()
        {
            tbFoodID.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nudFoodPrice.DataBindings.Add(new Binding("Value", dgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
            tbFoodName.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void LoadTabCategory()
        {
            listCategory.DataSource = CategoryDAO.Instance.GetCategory();
        }
        void BindingCategory()
        {
            tbCategoryID.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbCategoryName.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "FoodName", true, DataSourceUpdateMode.Never));
        }
        void LoadTabTable()
        {
            listTable.DataSource = TableDAO.Instance.LoadListTable();
        }
        void BindingTable()
        {
            tbTableID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbTableName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "TableName", true, DataSourceUpdateMode.Never));
        }
        void BindingAccount()
        {
            tbAccountID.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "ID", true, DataSourceUpdateMode.Never));
            tbUserName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            tbDislayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "DislayName", true, DataSourceUpdateMode.Never));
        }
        void LoadTabAccount()
        {
            listAccount.DataSource = Account.Instance.LoadListAccount();
        }
        void SearchFood(string name)
        {
            listFood.DataSource = FoodDAO.Instance.SearchFoodByName(name);
        }


        #endregion

        #region Events
        private void btStatistic_Click(object sender, EventArgs e)
        {
            tbPage.Text = "1";
            LoadListBillByDate(dtpDateStart.Value, dtpDateFinish.Value);
        }
        private void tbFoodID_TextChanged(object sender, EventArgs e)
        {
            if(dgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value != null)
            {
                int id = (int)dgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                CategoryDTO category = CategoryDAO.Instance.GetCategoryByID(id);
                int index = -1;
                int i = 0;
                foreach (CategoryDTO item in cbCategoryFood.Items)
                {
                    if (item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbCategoryFood.SelectedIndex = index;
            }
        }
        private void tbTableID_TextChanged(object sender, EventArgs e)
        {
            if (dgvTable.SelectedCells[0].OwningRow.Cells["ID"].Value != null)
            {
                int tableID = (int)dgvTable.SelectedCells[0].OwningRow.Cells["ID"].Value;
                Table table = TableDAO.Instance.LoadTableByID(tableID);
                if (table.TableStatus == "False")
                    tbTableStatus.Text = "Empty";
                else
                    tbTableStatus.Text = "Using";
            }
        }
        private void btViewFood_Click(object sender, EventArgs e)
        {
            LoadTabFood();
        }
        private void dgvRevenue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //    int accountID = (int)dgvRevenue.SelectedCells[0].OwningRow.Cells["AccountID"].Value;
            //    AccountDTO account = Account.Instance.GetAccountByID(accountID);
            //    //cbCategoryFood.SelectedItem = category;
            //    int index = -1;
            //    int i = 0;
            //    foreach (CategoryDTO item in cbCategoryFood.Items)
            //    {
            //        if (item.ID == account.ID)
            //        {
            //            index = i;
            //            break;
            //        }
            //        i++;
            //    }
            //    tbDislayNameCheckOutBill.Text = account.DisplayName;
            //    tbUserNameCheckOut.Text = account.UserName;
        }
        private void btAddFood_Click(object sender, EventArgs e)
        {
            string foodName = tbFoodName.Text;
            float price = (float)nudFoodPrice.Value;
            int categoryID = (cbCategoryFood.SelectedItem as CategoryDTO).ID;

            if (FoodDAO.Instance.InsertFood(foodName, price, categoryID))
            {
                MessageBox.Show("Completing add food");
                LoadTabFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
                MessageBox.Show("Failed to add food");
        }
        private void btDeleteFood_Click(object sender, EventArgs e)
        {
            int foodID = int.Parse(tbFoodID.Text);
            if(MessageBox.Show("Do you really want to delete current selected food?", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.No)
            {
                return;
            }

            if (FoodDAO.Instance.DeleteFood(foodID))
            {
                MessageBox.Show("Completing delete food");
                LoadTabFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
                MessageBox.Show("Failed to delete food");
        }
        private void btEditFood_Click(object sender, EventArgs e)
        {
            string foodName = tbFoodName.Text;
            float price = (float)nudFoodPrice.Value;
            int categoryID = (cbCategoryFood.SelectedItem as CategoryDTO).ID;
            int foodID = int.Parse(tbFoodID.Text);
            if (FoodDAO.Instance.EditFood(foodName, price, categoryID, foodID))
            {
                MessageBox.Show("Completing edit food");
                LoadTabFood();
                if (editFood != null)
                    editFood(this, new EventArgs());
            }
            else
                MessageBox.Show("Failed to edit food");
        }
        private void btAddCategory_Click(object sender, EventArgs e)
        {
            string foodName = tbCategoryName.Text;

            if (CategoryDAO.Instance.AddCategory(foodName))
            {
                MessageBox.Show("Completing add food category");
                LoadTabCategory();
                LoadTabFood();
                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
            }
            else
                MessageBox.Show("Failed to add food category");
        }
        private void btDeleteCatagory_Click(object sender, EventArgs e)
        {
            int categoryID = int.Parse(tbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(categoryID))
            {
                MessageBox.Show("Completing delete food category");
                LoadTabCategory();
                LoadTabFood();
                if (deleteCategory != null)
                    deleteCategory(this, new EventArgs());
            }
            else
                MessageBox.Show("Failed to edit food category");
            
        }
        private void btEditCategory_Click(object sender, EventArgs e)
        {
            string foodName = tbCategoryName.Text;
            int categoryID = int.Parse(tbCategoryID.Text);

            if (CategoryDAO.Instance.EditCategory(foodName, categoryID))
            {
                MessageBox.Show("Completing edit food category");
                LoadTabCategory();
                LoadTabFood();
                if (editCategory != null)
                    editCategory(this, new EventArgs());
            }
            else
                MessageBox.Show("Failed to edit food category");
        }
        private void btViewCategory_Click(object sender, EventArgs e)
        {
            LoadTabCategory();
        }
        private void btAddTable_Click(object sender, EventArgs e)
        {
            string tableName = tbTableName.Text;

            if (TableDAO.Instance.InsertTable(tableName))
            {
                MessageBox.Show("Completing add table");
                LoadTabTable();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else
                MessageBox.Show("Failed to add table");
        }
        private void btDeleteTable_Click(object sender, EventArgs e)
        {
            int tableID = int.Parse(tbTableID.Text);

            if (MessageBox.Show("Do you really want to delete current selected table?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            if (TableDAO.Instance.DeleteTable(tableID))
            {
                MessageBox.Show("Completing delete table");
                LoadTabTable();
                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
            }
            else
                MessageBox.Show("Can not delete table. Table is using or sth...");
        }
        private void btEditTable_Click(object sender, EventArgs e)
        {
            string tableName = tbTableName.Text;
            int tableID = int.Parse(tbTableID.Text);

            if (TableDAO.Instance.EditTable(tableName, tableID))
            {
                MessageBox.Show("Completing edit table");
                LoadTabTable();
                if (editTable != null)
                    editTable(this, new EventArgs());
            }
            else
                MessageBox.Show("Failed to edit table");
        }
        private void btViewTable_Click(object sender, EventArgs e)
        {
            LoadTabTable();
        }
        private void btAddAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string dislayName = tbDislayName.Text;
            string accountType = cbAccountType.SelectedItem.ToString();

            if (Account.Instance.InsertAccount(userName, dislayName, accountType))
            {
                MessageBox.Show("Complete");

                LoadTabAccount();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
        private void btDeleteAccount_Click(object sender, EventArgs e)
        {
            int accountID = (int)dgvAccount.SelectedCells[0].OwningRow.Cells["ID"].Value;
            int result = Account.Instance.DeleteAccount(accountID);
            string userName = tbUserName.Text;
            if (result == 3)
            {
                MessageBox.Show("Complete");
                LoadTabAccount();
            }
            else
                MessageBox.Show("Fail");
        }
        private void btEditAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string dislayName = tbDislayName.Text;
            string accountType = cbAccountType.SelectedItem.ToString();
            int accountID = (int)dgvAccount.SelectedCells[0].OwningRow.Cells["ID"].Value;

            if (Account.Instance.EditAccount(userName, dislayName, accountType, accountID))
            {
                MessageBox.Show("Complete");
                LoadTabAccount();
                accountType = cbAccountType.SelectedItem.ToString();
                if (updateAccount != null && loginAccount.ID == accountID)
                    updateAccount(this, new AccountEvent(Account.Instance.GetAccountByUserName(userName)));
                if (loginAccount.ID == accountID && accountType != loginAccount.AccountType)
                    this.Close();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
        private void btViewAccount_Click(object sender, EventArgs e)
        {
            LoadTabAccount();
        }
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedCells[0].OwningRow.Cells["ID"].Value != null)
            {
                int accountID = (int)dgvAccount.SelectedCells[0].OwningRow.Cells["ID"].Value;
                AccountDTO account = Account.Instance.GetAccountByID(accountID);
                if (account.AccountType == "False")
                    cbAccountType.SelectedItem = "False";
                else
                    cbAccountType.SelectedItem = "True";
            }
        }
        private void btResetPassword_Click(object sender, EventArgs e)
        {
            int accountID = int.Parse(tbAccountID.Text);
            string message = string.Format("Do you really want to reset password of {0}?", tbUserName.Text);
            if (MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Account.Instance.ResetPassword(accountID))
                    MessageBox.Show("Reset complete. New password is '1' ");
                else
                    MessageBox.Show("Reset false");
            }
        }
        private void btSearchFood_Click(object sender, EventArgs e)
        {
            SearchFood(tbSearchFood.Text);
        }
        private void btFirstPage_Click(object sender, EventArgs e)
        {
            tbPage.Text = "1";
        }
        private void btPreviousPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(tbPage.Text);
            if (page > 1)
                page--;
            tbPage.Text = page.ToString();
        }
        private void btNextPage_Click(object sender, EventArgs e)
        {
            int page = int.Parse(tbPage.Text);
            int sumRecord = BillDAO.Instance.GetCountBill(dtpDateStart.Value, dtpDateFinish.Value);
            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            if (page < lastPage)
                page++;
            tbPage.Text = page.ToString();
        }
        private void btBottomPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetCountBill(dtpDateStart.Value, dtpDateFinish.Value);
            int lastPage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastPage++;
            tbPage.Text = lastPage.ToString();
        }
        private void tbPage_TextChanged(object sender, EventArgs e)
        {
            int page = int.Parse(tbPage.Text);
            dgvRevenue.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpDateStart.Value, dtpDateFinish.Value, page, 15);
        }
        #endregion

        #region EventsMaking
        event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        event EventHandler editFood;
        public event EventHandler EditFood
        {
            add { editFood += value; }
            remove { editFood -= value; }
        }

        event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        event EventHandler editCategory;
        public event EventHandler EditCategory
        {
            add { editCategory += value; }
            remove { editCategory -= value; }
        }

        event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        event EventHandler editTable;
        public event EventHandler EditTable
        {
            add { editTable += value; }
            remove { editTable -= value; }
        }

        event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        #endregion
    }
}
