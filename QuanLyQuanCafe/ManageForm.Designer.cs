namespace QuanLyQuanCafe
{
    partial class ManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAddFoods = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.nudCountFood = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbCurrentTableName = new System.Windows.Forms.TextBox();
            this.tbTotalPrice = new System.Windows.Forms.TextBox();
            this.cbSwitchTable = new System.Windows.Forms.ComboBox();
            this.btSwitchTable = new System.Windows.Forms.Button();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.btDiscount = new System.Windows.Forms.Button();
            this.btPay = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCountFood)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.accountInfoToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            resources.ApplyResources(this.adminToolStripMenuItem, "adminToolStripMenuItem");
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // accountInfoToolStripMenuItem
            // 
            this.accountInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountProfileToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.accountInfoToolStripMenuItem.Name = "accountInfoToolStripMenuItem";
            resources.ApplyResources(this.accountInfoToolStripMenuItem, "accountInfoToolStripMenuItem");
            // 
            // accountProfileToolStripMenuItem
            // 
            this.accountProfileToolStripMenuItem.Name = "accountProfileToolStripMenuItem";
            resources.ApplyResources(this.accountProfileToolStripMenuItem, "accountProfileToolStripMenuItem");
            this.accountProfileToolStripMenuItem.Click += new System.EventHandler(this.accountProfileToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            resources.ApplyResources(this.quitToolStripMenuItem, "quitToolStripMenuItem");
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // flpTable
            // 
            resources.ApplyResources(this.flpTable, "flpTable");
            this.flpTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpTable.Name = "flpTable";
            this.flpTable.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flpTable_ControlAdded);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btAddFoods);
            this.panel1.Controls.Add(this.cbFood);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.nudCountFood);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btAddFoods
            // 
            resources.ApplyResources(this.btAddFoods, "btAddFoods");
            this.btAddFoods.Name = "btAddFoods";
            this.btAddFoods.UseVisualStyleBackColor = true;
            this.btAddFoods.Click += new System.EventHandler(this.btAddFoods_Click);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            resources.ApplyResources(this.cbFood, "cbFood");
            this.cbFood.Name = "cbFood";
            // 
            // cbCategory
            // 
            resources.ApplyResources(this.cbCategory, "cbCategory");
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // nudCountFood
            // 
            resources.ApplyResources(this.nudCountFood, "nudCountFood");
            this.nudCountFood.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudCountFood.Name = "nudCountFood";
            this.nudCountFood.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lvBill);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvBill.HideSelection = false;
            resources.ApplyResources(this.lvBill, "lvBill");
            this.lvBill.Name = "lvBill";
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tbCurrentTableName);
            this.panel3.Controls.Add(this.tbTotalPrice);
            this.panel3.Controls.Add(this.cbSwitchTable);
            this.panel3.Controls.Add(this.btSwitchTable);
            this.panel3.Controls.Add(this.nudDiscount);
            this.panel3.Controls.Add(this.btDiscount);
            this.panel3.Controls.Add(this.btPay);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // tbCurrentTableName
            // 
            this.tbCurrentTableName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.tbCurrentTableName, "tbCurrentTableName");
            this.tbCurrentTableName.ForeColor = System.Drawing.Color.Red;
            this.tbCurrentTableName.Name = "tbCurrentTableName";
            this.tbCurrentTableName.ReadOnly = true;
            // 
            // tbTotalPrice
            // 
            this.tbTotalPrice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.tbTotalPrice, "tbTotalPrice");
            this.tbTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.tbTotalPrice.Name = "tbTotalPrice";
            this.tbTotalPrice.ReadOnly = true;
            // 
            // cbSwitchTable
            // 
            this.cbSwitchTable.FormattingEnabled = true;
            resources.ApplyResources(this.cbSwitchTable, "cbSwitchTable");
            this.cbSwitchTable.Name = "cbSwitchTable";
            // 
            // btSwitchTable
            // 
            resources.ApplyResources(this.btSwitchTable, "btSwitchTable");
            this.btSwitchTable.Name = "btSwitchTable";
            this.btSwitchTable.UseVisualStyleBackColor = true;
            this.btSwitchTable.Click += new System.EventHandler(this.btSwitchTable_Click);
            // 
            // nudDiscount
            // 
            resources.ApplyResources(this.nudDiscount, "nudDiscount");
            this.nudDiscount.Name = "nudDiscount";
            // 
            // btDiscount
            // 
            resources.ApplyResources(this.btDiscount, "btDiscount");
            this.btDiscount.Name = "btDiscount";
            this.btDiscount.UseVisualStyleBackColor = true;
            // 
            // btPay
            // 
            this.btPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btPay.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btPay, "btPay");
            this.btPay.ForeColor = System.Drawing.Color.Red;
            this.btPay.Name = "btPay";
            this.btPay.UseVisualStyleBackColor = false;
            this.btPay.Click += new System.EventHandler(this.btPay_Click);
            // 
            // ManageForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManageForm";
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCountFood)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountInfoToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btAddFoods;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.NumericUpDown nudCountFood;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbSwitchTable;
        private System.Windows.Forms.Button btSwitchTable;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Button btDiscount;
        private System.Windows.Forms.Button btPay;
        private System.Windows.Forms.ToolStripMenuItem accountProfileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox tbTotalPrice;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.TextBox tbCurrentTableName;
    }
}