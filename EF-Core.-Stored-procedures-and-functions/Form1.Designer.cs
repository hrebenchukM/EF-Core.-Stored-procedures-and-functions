namespace EF_Core._Stored_procedures_and_functions
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            buttonAVQF = new Button();
            buttonMinCost = new Button();
            buttonMaxCost = new Button();
            buttonMinQuantity = new Button();
            buttonMaxQuantity = new Button();
            button1 = new Button();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonAdd = new Button();
            textBoxcost = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBoxquantity = new TextBox();
            label1 = new Label();
            textBoxproductname = new TextBox();
            buttonshowbytype = new Button();
            comboBoxproductstypes = new ComboBox();
            tabPage2 = new TabPage();
            label4 = new Label();
            textBoxTypeName = new TextBox();
            buttonDeleteType = new Button();
            buttonUpdateType = new Button();
            buttonAddType = new Button();
            dataGridView2 = new DataGridView();
            tabPage3 = new TabPage();
            label5 = new Label();
            textBoxManagers = new TextBox();
            buttonDeleteManager = new Button();
            buttonUpdateManager = new Button();
            buttonAddManger = new Button();
            dataGridView3 = new DataGridView();
            tabPage4 = new TabPage();
            label6 = new Label();
            textBoxCustomer = new TextBox();
            buttonDeleteCustomer = new Button();
            buttonUpdateCustomer = new Button();
            buttonAddCustomer = new Button();
            dataGridView4 = new DataGridView();
            tabPage5 = new TabPage();
            buttonLatestSale = new Button();
            buttonshowbycustomers = new Button();
            comboBoxCustomers = new ComboBox();
            comboBoxManagers = new ComboBox();
            buttonshowbymanagers = new Button();
            label12 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBoxPrice = new TextBox();
            textBoxCount = new TextBox();
            label11 = new Label();
            label10 = new Label();
            textBoxCustomerName = new TextBox();
            label7 = new Label();
            textBoxManager = new TextBox();
            label9 = new Label();
            buttonDeleteSale = new Button();
            buttonUpdateSale = new Button();
            buttonAddSale = new Button();
            dataGridView5 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(8, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1040, 191);
            dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1059, 457);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(buttonAVQF);
            tabPage1.Controls.Add(buttonMinCost);
            tabPage1.Controls.Add(buttonMaxCost);
            tabPage1.Controls.Add(buttonMinQuantity);
            tabPage1.Controls.Add(buttonMaxQuantity);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(buttonDelete);
            tabPage1.Controls.Add(buttonUpdate);
            tabPage1.Controls.Add(buttonAdd);
            tabPage1.Controls.Add(textBoxcost);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBoxquantity);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(textBoxproductname);
            tabPage1.Controls.Add(buttonshowbytype);
            tabPage1.Controls.Add(comboBoxproductstypes);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1051, 424);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Канцтовары";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonAVQF
            // 
            buttonAVQF.Location = new Point(813, 362);
            buttonAVQF.Name = "buttonAVQF";
            buttonAVQF.Size = new Size(143, 29);
            buttonAVQF.TabIndex = 21;
            buttonAVQF.Text = "Сред. количество (F)";
            buttonAVQF.UseVisualStyleBackColor = true;
            buttonAVQF.Click += buttonAVQF_Click;
            // 
            // buttonMinCost
            // 
            buttonMinCost.Location = new Point(876, 327);
            buttonMinCost.Name = "buttonMinCost";
            buttonMinCost.Size = new Size(167, 29);
            buttonMinCost.TabIndex = 20;
            buttonMinCost.Text = "Мин.собестоимость";
            buttonMinCost.UseVisualStyleBackColor = true;
            buttonMinCost.Click += buttonMinCost_Click;
            // 
            // buttonMaxCost
            // 
            buttonMaxCost.Location = new Point(876, 292);
            buttonMaxCost.Name = "buttonMaxCost";
            buttonMaxCost.Size = new Size(167, 29);
            buttonMaxCost.TabIndex = 19;
            buttonMaxCost.Text = "Макс.собестоимость";
            buttonMaxCost.UseVisualStyleBackColor = true;
            buttonMaxCost.Click += buttonMaxCost_Click;
            // 
            // buttonMinQuantity
            // 
            buttonMinQuantity.Location = new Point(727, 327);
            buttonMinQuantity.Name = "buttonMinQuantity";
            buttonMinQuantity.Size = new Size(143, 29);
            buttonMinQuantity.TabIndex = 18;
            buttonMinQuantity.Text = "Мин.количество";
            buttonMinQuantity.UseVisualStyleBackColor = true;
            buttonMinQuantity.Click += buttonMinQuantity_Click;
            // 
            // buttonMaxQuantity
            // 
            buttonMaxQuantity.Location = new Point(727, 292);
            buttonMaxQuantity.Name = "buttonMaxQuantity";
            buttonMaxQuantity.Size = new Size(143, 29);
            buttonMaxQuantity.TabIndex = 17;
            buttonMaxQuantity.Text = "Макс.количество";
            buttonMaxQuantity.UseVisualStyleBackColor = true;
            buttonMaxQuantity.Click += buttonMaxQuantity_Click;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(20, 254);
            button1.Name = "button1";
            button1.Size = new Size(234, 57);
            button1.TabIndex = 16;
            button1.Text = "фильтрации товаров по типу(P)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonshowbytype_ClickP;
            // 
            // buttonDelete
            // 
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.Location = new Point(927, 214);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 67);
            buttonDelete.TabIndex = 15;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Cursor = Cursors.Hand;
            buttonUpdate.Location = new Point(827, 214);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(94, 67);
            buttonUpdate.TabIndex = 14;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Cursor = Cursors.Hand;
            buttonAdd.Location = new Point(727, 214);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 67);
            buttonAdd.TabIndex = 13;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // textBoxcost
            // 
            textBoxcost.Location = new Point(486, 298);
            textBoxcost.Name = "textBoxcost";
            textBoxcost.Size = new Size(189, 27);
            textBoxcost.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(351, 301);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 9;
            label3.Text = "Себестоимость";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(351, 261);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 8;
            label2.Text = "Количество";
            // 
            // textBoxquantity
            // 
            textBoxquantity.Location = new Point(486, 254);
            textBoxquantity.Name = "textBoxquantity";
            textBoxquantity.Size = new Size(189, 27);
            textBoxquantity.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(351, 222);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 6;
            label1.Text = "Название";
            // 
            // textBoxproductname
            // 
            textBoxproductname.Location = new Point(486, 214);
            textBoxproductname.Name = "textBoxproductname";
            textBoxproductname.Size = new Size(189, 27);
            textBoxproductname.TabIndex = 5;
            // 
            // buttonshowbytype
            // 
            buttonshowbytype.Cursor = Cursors.Hand;
            buttonshowbytype.Location = new Point(20, 327);
            buttonshowbytype.Name = "buttonshowbytype";
            buttonshowbytype.Size = new Size(234, 52);
            buttonshowbytype.TabIndex = 4;
            buttonshowbytype.Text = "фильтрации товаров по типу(F)";
            buttonshowbytype.UseVisualStyleBackColor = true;
            buttonshowbytype.Click += buttonshowbytype_ClickF;
            // 
            // comboBoxproductstypes
            // 
            comboBoxproductstypes.FormattingEnabled = true;
            comboBoxproductstypes.Location = new Point(8, 214);
            comboBoxproductstypes.Name = "comboBoxproductstypes";
            comboBoxproductstypes.Size = new Size(304, 28);
            comboBoxproductstypes.TabIndex = 3;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(textBoxTypeName);
            tabPage2.Controls.Add(buttonDeleteType);
            tabPage2.Controls.Add(buttonUpdateType);
            tabPage2.Controls.Add(buttonAddType);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1051, 424);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Типы канцтоваров";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(351, 221);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 18;
            label4.Text = "Название";
            // 
            // textBoxTypeName
            // 
            textBoxTypeName.Location = new Point(486, 214);
            textBoxTypeName.Name = "textBoxTypeName";
            textBoxTypeName.Size = new Size(189, 27);
            textBoxTypeName.TabIndex = 17;
            // 
            // buttonDeleteType
            // 
            buttonDeleteType.Cursor = Cursors.Hand;
            buttonDeleteType.Location = new Point(927, 214);
            buttonDeleteType.Name = "buttonDeleteType";
            buttonDeleteType.Size = new Size(94, 67);
            buttonDeleteType.TabIndex = 16;
            buttonDeleteType.Text = "Удалить";
            buttonDeleteType.UseVisualStyleBackColor = true;
            buttonDeleteType.Click += buttonDeleteType_Click;
            // 
            // buttonUpdateType
            // 
            buttonUpdateType.Cursor = Cursors.Hand;
            buttonUpdateType.Location = new Point(827, 214);
            buttonUpdateType.Name = "buttonUpdateType";
            buttonUpdateType.Size = new Size(94, 67);
            buttonUpdateType.TabIndex = 15;
            buttonUpdateType.Text = "Обновить";
            buttonUpdateType.UseVisualStyleBackColor = true;
            buttonUpdateType.Click += buttonUpdateType_Click;
            // 
            // buttonAddType
            // 
            buttonAddType.Cursor = Cursors.Hand;
            buttonAddType.Location = new Point(727, 214);
            buttonAddType.Name = "buttonAddType";
            buttonAddType.Size = new Size(94, 67);
            buttonAddType.TabIndex = 14;
            buttonAddType.Text = "Добавить";
            buttonAddType.UseVisualStyleBackColor = true;
            buttonAddType.Click += buttonAddType_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(8, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(1040, 191);
            dataGridView2.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(textBoxManagers);
            tabPage3.Controls.Add(buttonDeleteManager);
            tabPage3.Controls.Add(buttonUpdateManager);
            tabPage3.Controls.Add(buttonAddManger);
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1051, 424);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Менеджеры по продажам";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(351, 221);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 21;
            label5.Text = "Название";
            // 
            // textBoxManagers
            // 
            textBoxManagers.Location = new Point(486, 214);
            textBoxManagers.Name = "textBoxManagers";
            textBoxManagers.Size = new Size(189, 27);
            textBoxManagers.TabIndex = 20;
            // 
            // buttonDeleteManager
            // 
            buttonDeleteManager.Cursor = Cursors.Hand;
            buttonDeleteManager.Location = new Point(927, 214);
            buttonDeleteManager.Name = "buttonDeleteManager";
            buttonDeleteManager.Size = new Size(94, 67);
            buttonDeleteManager.TabIndex = 19;
            buttonDeleteManager.Text = "Удалить";
            buttonDeleteManager.UseVisualStyleBackColor = true;
            buttonDeleteManager.Click += buttonDeleteManager_Click;
            // 
            // buttonUpdateManager
            // 
            buttonUpdateManager.Cursor = Cursors.Hand;
            buttonUpdateManager.Location = new Point(827, 214);
            buttonUpdateManager.Name = "buttonUpdateManager";
            buttonUpdateManager.Size = new Size(94, 67);
            buttonUpdateManager.TabIndex = 18;
            buttonUpdateManager.Text = "Обновить";
            buttonUpdateManager.UseVisualStyleBackColor = true;
            buttonUpdateManager.Click += buttonUpdateManager_Click;
            // 
            // buttonAddManger
            // 
            buttonAddManger.Cursor = Cursors.Hand;
            buttonAddManger.Location = new Point(727, 214);
            buttonAddManger.Name = "buttonAddManger";
            buttonAddManger.Size = new Size(94, 67);
            buttonAddManger.TabIndex = 17;
            buttonAddManger.Text = "Добавить";
            buttonAddManger.UseVisualStyleBackColor = true;
            buttonAddManger.Click += buttonAddManger_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(8, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.Size = new Size(1040, 191);
            dataGridView3.TabIndex = 1;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(textBoxCustomer);
            tabPage4.Controls.Add(buttonDeleteCustomer);
            tabPage4.Controls.Add(buttonUpdateCustomer);
            tabPage4.Controls.Add(buttonAddCustomer);
            tabPage4.Controls.Add(dataGridView4);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(1051, 424);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Фирмы покупатели";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(351, 221);
            label6.Name = "label6";
            label6.Size = new Size(77, 20);
            label6.TabIndex = 24;
            label6.Text = "Название";
            // 
            // textBoxCustomer
            // 
            textBoxCustomer.Location = new Point(486, 214);
            textBoxCustomer.Name = "textBoxCustomer";
            textBoxCustomer.Size = new Size(189, 27);
            textBoxCustomer.TabIndex = 23;
            // 
            // buttonDeleteCustomer
            // 
            buttonDeleteCustomer.Cursor = Cursors.Hand;
            buttonDeleteCustomer.Location = new Point(927, 214);
            buttonDeleteCustomer.Name = "buttonDeleteCustomer";
            buttonDeleteCustomer.Size = new Size(94, 67);
            buttonDeleteCustomer.TabIndex = 22;
            buttonDeleteCustomer.Text = "Удалить";
            buttonDeleteCustomer.UseVisualStyleBackColor = true;
            buttonDeleteCustomer.Click += buttonDeleteCustomer_Click;
            // 
            // buttonUpdateCustomer
            // 
            buttonUpdateCustomer.Cursor = Cursors.Hand;
            buttonUpdateCustomer.Location = new Point(827, 214);
            buttonUpdateCustomer.Name = "buttonUpdateCustomer";
            buttonUpdateCustomer.Size = new Size(94, 67);
            buttonUpdateCustomer.TabIndex = 21;
            buttonUpdateCustomer.Text = "Обновить";
            buttonUpdateCustomer.UseVisualStyleBackColor = true;
            buttonUpdateCustomer.Click += buttonUpdateCustomer_Click;
            // 
            // buttonAddCustomer
            // 
            buttonAddCustomer.Cursor = Cursors.Hand;
            buttonAddCustomer.Location = new Point(727, 214);
            buttonAddCustomer.Name = "buttonAddCustomer";
            buttonAddCustomer.Size = new Size(94, 67);
            buttonAddCustomer.TabIndex = 20;
            buttonAddCustomer.Text = "Добавить";
            buttonAddCustomer.UseVisualStyleBackColor = true;
            buttonAddCustomer.Click += buttonAddCustomer_Click;
            // 
            // dataGridView4
            // 
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(8, 3);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.RowHeadersWidth = 51;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.Size = new Size(1040, 191);
            dataGridView4.TabIndex = 1;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(buttonLatestSale);
            tabPage5.Controls.Add(buttonshowbycustomers);
            tabPage5.Controls.Add(comboBoxCustomers);
            tabPage5.Controls.Add(comboBoxManagers);
            tabPage5.Controls.Add(buttonshowbymanagers);
            tabPage5.Controls.Add(label12);
            tabPage5.Controls.Add(dateTimePicker1);
            tabPage5.Controls.Add(textBoxPrice);
            tabPage5.Controls.Add(textBoxCount);
            tabPage5.Controls.Add(label11);
            tabPage5.Controls.Add(label10);
            tabPage5.Controls.Add(textBoxCustomerName);
            tabPage5.Controls.Add(label7);
            tabPage5.Controls.Add(textBoxManager);
            tabPage5.Controls.Add(label9);
            tabPage5.Controls.Add(buttonDeleteSale);
            tabPage5.Controls.Add(buttonUpdateSale);
            tabPage5.Controls.Add(buttonAddSale);
            tabPage5.Controls.Add(dataGridView5);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Size = new Size(1051, 424);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Продажи";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // buttonLatestSale
            // 
            buttonLatestSale.Location = new Point(727, 381);
            buttonLatestSale.Name = "buttonLatestSale";
            buttonLatestSale.Size = new Size(250, 29);
            buttonLatestSale.TabIndex = 43;
            buttonLatestSale.Text = "Последняя продажа";
            buttonLatestSale.UseVisualStyleBackColor = true;
            buttonLatestSale.Click += buttonLatestSale_Click;
            // 
            // buttonshowbycustomers
            // 
            buttonshowbycustomers.Cursor = Cursors.Hand;
            buttonshowbycustomers.Location = new Point(20, 259);
            buttonshowbycustomers.Name = "buttonshowbycustomers";
            buttonshowbycustomers.Size = new Size(234, 52);
            buttonshowbycustomers.TabIndex = 42;
            buttonshowbycustomers.Text = "фильтрации товаров по покупателю(F)";
            buttonshowbycustomers.UseVisualStyleBackColor = true;
            buttonshowbycustomers.Click += buttonshowbycustomers_Click;
            // 
            // comboBoxCustomers
            // 
            comboBoxCustomers.FormattingEnabled = true;
            comboBoxCustomers.Location = new Point(20, 213);
            comboBoxCustomers.Name = "comboBoxCustomers";
            comboBoxCustomers.Size = new Size(304, 28);
            comboBoxCustomers.TabIndex = 41;
            // 
            // comboBoxManagers
            // 
            comboBoxManagers.FormattingEnabled = true;
            comboBoxManagers.Location = new Point(20, 327);
            comboBoxManagers.Name = "comboBoxManagers";
            comboBoxManagers.Size = new Size(304, 28);
            comboBoxManagers.TabIndex = 40;
            // 
            // buttonshowbymanagers
            // 
            buttonshowbymanagers.Cursor = Cursors.Hand;
            buttonshowbymanagers.Location = new Point(20, 369);
            buttonshowbymanagers.Name = "buttonshowbymanagers";
            buttonshowbymanagers.Size = new Size(234, 52);
            buttonshowbymanagers.TabIndex = 39;
            buttonshowbymanagers.Text = "фильтрации товаров по менеджеру(F)";
            buttonshowbymanagers.UseVisualStyleBackColor = true;
            buttonshowbymanagers.Click += buttonshowbymanagers_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(727, 305);
            label12.Name = "label12";
            label12.Size = new Size(108, 20);
            label12.TabIndex = 37;
            label12.Text = "Дата продажи";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(727, 328);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 36;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(486, 345);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(189, 27);
            textBoxPrice.TabIndex = 35;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(486, 305);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(189, 27);
            textBoxCount.TabIndex = 34;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(351, 345);
            label11.Name = "label11";
            label11.Size = new Size(126, 20);
            label11.TabIndex = 33;
            label11.Text = "Цена за еденицу";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(351, 305);
            label10.Name = "label10";
            label10.Size = new Size(90, 20);
            label10.TabIndex = 32;
            label10.Text = "Количество";
            // 
            // textBoxCustomerName
            // 
            textBoxCustomerName.Location = new Point(486, 261);
            textBoxCustomerName.Name = "textBoxCustomerName";
            textBoxCustomerName.Size = new Size(189, 27);
            textBoxCustomerName.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(351, 261);
            label7.Name = "label7";
            label7.Size = new Size(90, 20);
            label7.TabIndex = 30;
            label7.Text = "Покупатель";
            // 
            // textBoxManager
            // 
            textBoxManager.Location = new Point(486, 218);
            textBoxManager.Name = "textBoxManager";
            textBoxManager.Size = new Size(189, 27);
            textBoxManager.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(351, 221);
            label9.Name = "label9";
            label9.Size = new Size(83, 20);
            label9.TabIndex = 27;
            label9.Text = "Менеджер";
            // 
            // buttonDeleteSale
            // 
            buttonDeleteSale.Cursor = Cursors.Hand;
            buttonDeleteSale.Location = new Point(927, 214);
            buttonDeleteSale.Name = "buttonDeleteSale";
            buttonDeleteSale.Size = new Size(94, 67);
            buttonDeleteSale.TabIndex = 25;
            buttonDeleteSale.Text = "Удалить";
            buttonDeleteSale.UseVisualStyleBackColor = true;
            buttonDeleteSale.Click += buttonDeleteSale_Click;
            // 
            // buttonUpdateSale
            // 
            buttonUpdateSale.Cursor = Cursors.Hand;
            buttonUpdateSale.Location = new Point(827, 214);
            buttonUpdateSale.Name = "buttonUpdateSale";
            buttonUpdateSale.Size = new Size(94, 67);
            buttonUpdateSale.TabIndex = 24;
            buttonUpdateSale.Text = "Обновить";
            buttonUpdateSale.UseVisualStyleBackColor = true;
            buttonUpdateSale.Click += buttonUpdateSale_Click;
            // 
            // buttonAddSale
            // 
            buttonAddSale.Cursor = Cursors.Hand;
            buttonAddSale.Location = new Point(727, 214);
            buttonAddSale.Name = "buttonAddSale";
            buttonAddSale.Size = new Size(94, 67);
            buttonAddSale.TabIndex = 23;
            buttonAddSale.Text = "Добавить";
            buttonAddSale.UseVisualStyleBackColor = true;
            buttonAddSale.Click += buttonAddSale_Click;
            // 
            // dataGridView5
            // 
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView5.Location = new Point(8, 3);
            dataGridView5.Name = "dataGridView5";
            dataGridView5.RowHeadersWidth = 51;
            dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView5.Size = new Size(1040, 191);
            dataGridView5.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 457);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "База данных Канцтовары";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private ComboBox comboBoxproductstypes;
        private Button buttonshowbytype;
        private TextBox textBoxproductname;
        private TextBox textBoxcost;
        private Label label3;
        private Label label2;
        private TextBox textBoxquantity;
        private Label label1;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonAdd;
        private Button button1;
        private Button buttonMaxQuantity;
        private Button buttonMinQuantity;
        private Button buttonMaxCost;
        private Button buttonMinCost;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private Button buttonAddType;
        private DataGridView dataGridView4;
        private Button buttonUpdateType;
        private TextBox textBoxTypeName;
        private Button buttonDeleteType;
        private Label label4;
        private Button buttonAVQF;
        private Button buttonDeleteManager;
        private Button buttonUpdateManager;
        private Button buttonAddManger;
        private Button buttonDeleteCustomer;
        private Button buttonUpdateCustomer;
        private Button buttonAddCustomer;
        private Label label5;
        private TextBox textBoxManagers;
        private ComboBox comboBoxManager;
        private ComboBox comboBoxManagers;
        private Button buttonshowbymanager;
        private TabPage tabPage5;
        private Button buttonDeleteSale;
        private Button buttonUpdateSale;
        private Button buttonAddSale;
        private DataGridView dataGridView5;
        private Label label6;
        private TextBox textBoxCustomer;
        private Label label11;
        private Label label10;
        private TextBox textBoxCustomerName;
        private Label label7;
        private TextBox textBoxManager;
        private Label label9;
        private TextBox textBoxPrice;
        private TextBox textBoxCount;
        private Label label12;
        private DateTimePicker dateTimePicker1;
        private Button buttonshowbymanagers;
        private Button buttonshowbycustomers;
        private ComboBox comboBoxCustomers;
        private Button buttonLatestSale;
    }
}
