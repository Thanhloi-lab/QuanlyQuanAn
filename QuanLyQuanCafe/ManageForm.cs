using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class ManageForm : Form
    {
        AccountDTO loginAccount;
        float totalPrice = 0;

        public AccountDTO LoginAccount
        {
            get => loginAccount;
            set { loginAccount = value; AdminRight(loginAccount.AccountType); }
        }

        public ManageForm(AccountDTO loginAccount)
        {
            InitializeComponent();
            this.LoginAccount = loginAccount;
        }

        #region Method
        private void ManageForm_Load(object sender, EventArgs e)
        {
            LoadListTable();
            LoadListCategory();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        void LoadListTable()
        {
            flpTable.Controls.Clear();
            List<Table> listTable = TableDAO.Instance.LoadListTable();

            foreach (Table item in listTable)
            {
                Button bt = new Button() { Width = TableDAO.tableWidth, Height = TableDAO.tableHeight };
                bt.Click += Bt_Click;
                bt.Tag = item;
                if (item.TableStatus == "False")
                {
                    bt.Text = item.TableName + Environment.NewLine + "Empty";
                    bt.BackColor = Color.Empty;
                }
                else
                {
                    List<MenuDTO> menu = MenuDAO.Instance.GetListMenuByTable(item.ID);
                    if (item.TableStatus == "True" && menu.Count==0)
                    {
                        bt.Text = item.TableName + Environment.NewLine + "Waiting";
                        bt.BackColor = Color.Orange;
                    }
                    bt.Text = item.TableName + Environment.NewLine + "Using";
                    bt.BackColor = Color.LightGreen;
                }
                flpTable.Controls.Add(bt);
            }
        }

        void LoadListCategory()
        {
            List<CategoryDTO> listFoodCategory = (List<CategoryDTO>)CategoryDAO.Instance.GetCategory();
            cbCategory.DataSource = listFoodCategory;
            cbCategory.DisplayMember = "FoodName";
        }

        void ShowBill(int ID)
        {
            lvBill.Items.Clear();

            if (tbCurrentTableName.Text == "Non")
                return;
            List<MenuDTO> menu = MenuDAO.Instance.GetListMenuByTable(ID);
            float totalPrice = 0;
            foreach (MenuDTO item in menu)
            {
                ListViewItem lvitemp = new ListViewItem(item.FoodName.ToString());
                lvitemp.SubItems.Add(item.FoodCount.ToString());
                lvitemp.SubItems.Add(item.Price.ToString());
                lvitemp.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lvBill.Items.Add(lvitemp);
            }
            this.totalPrice = totalPrice;
            CultureInfo culture = new CultureInfo("vi-VN");
            tbTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        void AdminRight(string accountType)
        {
            if (accountType == "True")
                adminToolStripMenuItem.Enabled = true;
            else
                adminToolStripMenuItem.Enabled = false;

            accountInfoToolStripMenuItem.Text += " (" + loginAccount.DislayName + ")";
        }

        void LoadComboBoxSwitchTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadListTable();
            cb.DisplayMember = "TableName";
        }


        #endregion

        #region Events
        private void accountProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfileForm f = new AccountProfileForm(loginAccount);
            f.UpdateAccount += F_UpdateAccount;
            
            f.ShowDialog();
        }

        private void F_UpdateAccount(object sender, AccountEvent e)
        {
            accountInfoToolStripMenuItem.Text = "Account info (" + e.Account.DislayName + ")";

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            CategoryDTO selected = cb.SelectedItem as CategoryDTO;
            id = selected.ID;
            List<FoodDTO> listfood = FoodDAO.Instance.GetListFoodByCategoryID(id);
            if (listfood.Count == 0)
            {
                cbFood.Text = "";
                cbFood.DataSource = null;
                return;
            }
            cbFood.DataSource = listfood;
            cbFood.DisplayMember = "Name";
        }

        private void btAddFoods_Click(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text == "Non")
            {
                MessageBox.Show("Choose a table to add food");
                return;
            }

            if(cbFood.DataSource == null)
            {
                return;
            }
            Table table = lvBill.Tag as Table;
            int iDBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as FoodDTO).ID;
            int count = (int)nudCountFood.Value;

            if(iDBill == -1 && count >0)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxBillID(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(iDBill, foodID, count);
            }
            ShowBill(table.ID);
            LoadListTable();
        }

        private void btPay_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;
            int iDBill = BillDAO.Instance.GetUnCheckBillIDByTableID(table.ID);
            if(iDBill != -1)
            {
                int discount = (int)nudDiscount.Value;
                double finalTotalPrice = totalPrice - (totalPrice * discount / 100);
                if (MessageBox.Show(string.Format("Do you really want to pay for {0} \nTotal price = {1} * {2}% = {3}", table.TableName, totalPrice, discount, finalTotalPrice),
                    "Announce", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BillDAO.Instance.CheckOut(iDBill, discount, (float)finalTotalPrice, loginAccount.ID);
                    ShowBill(table.ID);
                }
            }
            LoadListTable();
        }

        private void btSwitchTable_Click(object sender, EventArgs e)
        {
            int currentTableID = (lvBill.Tag as Table).ID;
            int newTableID = (cbSwitchTable.SelectedItem as Table).ID;
            TableDAO.Instance.SwitchTable(currentTableID, newTableID);
            LoadListTable();
            ShowBill(currentTableID);
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm f = new AdminForm(loginAccount);
            f.InsertFood += F_InsertFood;
            f.DeleteFood += F_DeleteFood;
            f.EditFood += F_EditFood;
            f.EditCategory += F_EditCategory;
            f.InsertCategory += F_InsertCategory;
            f.DeleteCategory += F_DeleteCategory;
            f.InsertTable += F_InsertTable;
            f.EditTable += F_EditTable;
            f.DeleteTable += F_DeleteTable;
            f.UpdateAccount += F_UpdateAccount1;
            f.ShowDialog();
            if (loginAccount == null)
            {
                MessageBox.Show("aaaa");
                this.Close();
            }
                
        }

        private void F_UpdateAccount1(object sender, AccountEvent e)
        {
            AdminRight(e.Account.AccountType);
            loginAccount = e.Account;
            accountInfoToolStripMenuItem.Text = "Account info (" + e.Account.DislayName + ")";
        }

        private void F_DeleteTable(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
                ShowBill((lvBill.Tag as Table).ID);
            LoadListTable();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void F_EditTable(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
                ShowBill((lvBill.Tag as Table).ID);
            LoadListTable();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void F_InsertTable(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
                ShowBill((lvBill.Tag as Table).ID);
            LoadListTable();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void F_DeleteCategory(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
                ShowBill((lvBill.Tag as Table).ID);
            LoadListCategory();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void F_InsertCategory(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
                ShowBill((lvBill.Tag as Table).ID);

            LoadListCategory();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void F_EditCategory(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
                ShowBill((lvBill.Tag as Table).ID);
            LoadListCategory();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void F_EditFood(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
            LoadListCategory();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void F_DeleteFood(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
            LoadListTable();
            LoadListCategory();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void F_InsertFood(object sender, EventArgs e)
        {
            if (tbCurrentTableName.Text != "Non")
            {
                ShowBill((lvBill.Tag as Table).ID);
            }
            LoadListCategory();
            LoadComboBoxSwitchTable(cbSwitchTable);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            nudCountFood.Value = 1;
            nudDiscount.Value = 0;
            int tableID = ((sender as Button).Tag as Table).ID;
            lvBill.Tag = (sender as Button).Tag;
            tbCurrentTableName.Text = (lvBill.Tag as Table).TableName;
            ShowBill(tableID);
        }
        #endregion

        private void flpTable_ControlAdded(object sender, ControlEventArgs e)
        {

        }
    }
}
