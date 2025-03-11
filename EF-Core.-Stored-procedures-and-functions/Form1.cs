using Microsoft.Data.SqlClient;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EF_Core._Stored_procedures_and_functions
{
    // Для работы с существующей БД MS SQL Server необходимо добавить два пакета:
    // Microsoft.EntityFrameworkCore.SqlServer(представляет функциональность Entity Framework для работы с MS SQL Server)
    // Microsoft.EntityFrameworkCore.Tools(пакет для создания классов по базе существующей базе данных, т.е. reverse engineering)

    // Scaffold-DbContext "Server=DESKTOP-G30VB0K\MSSQLSERVER01;Database=AcademyGroup;Integrated Security=SSPI;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer
    // Scaffold-DbContext "Data Source=D:\\AcademyGroup.db" Microsoft.EntityFrameworkCore.Sqlite
    public partial class Form1 : Form
    {
        private void LoadData()
        {
            using (StationeryContext db = new StationeryContext())
            {
                var productTypes = db.ProductTypes.Select(p => p.Name).ToList();
                comboBoxproductstypes.DataSource = productTypes;

                var products = db.Products.FromSqlRaw("SELECT * FROM products").ToList();
                LoadProducts(db, products);


                var types = db.ProductTypes.FromSqlRaw("SELECT * FROM product_types").ToList();
                LoadTypes(db, types);


                var managers = db.Managers.FromSqlRaw("SELECT * FROM managers").ToList();
                LoadManagers(db, managers);


                var customers = db.Customers.FromSqlRaw("SELECT * FROM customers").ToList();
                LoadCustomers(db, customers);




                var managerNames = db.Managers.Select(m => m.Name).ToList();
                comboBoxManagers.DataSource = managerNames;

                var customerNames = db.Customers.Select(c => c.Name).ToList();
                comboBoxCustomers.DataSource = customerNames;

                var sales = db.Sales.FromSqlRaw("SELECT * FROM sales").ToList();
                LoadSales(db, sales);

            }
        }


        private void LoadSales(StationeryContext db, List<Sale> sales)
        {

            foreach (var sale in sales)
            {
                db.Entry(sale).Reference(p => p.Product).Load();
                db.Entry(sale).Reference(p => p.Manager).Load();
                db.Entry(sale).Reference(p => p.Customer).Load();
            }
            var saleGrid = sales
                .Select(p => new
                {
                    Product = p.Product.Name,
                    Manager = p.Manager.Name,
                    Customer = p.Customer.Name,
                    p.Quantity,
                    p.UnitPrice,
                    p.DateSale
                })
                .ToList();

            dataGridView5.DataSource = saleGrid;
        }

        private void LoadCustomers(StationeryContext db, List<Customer> customers)
        {
            foreach (var c in customers)
            {
                db.Entry(c).Collection(c => c.Sales).Load();
            }

            var customerGrid = customers
                .Select(m => new
                {
                    m.Name,
                    SalesQuantity = m.Sales.Sum(s => s.Quantity),
                    TotalSalesAmount = m.Sales.Sum(s => s.Quantity * s.UnitPrice)
                })
                .ToList();

            dataGridView4.DataSource = customerGrid;
        }


        private void LoadManagers(StationeryContext db, List<Manager> managers)
        {
            foreach (var m in managers)
            {
                db.Entry(m).Collection(m => m.Sales).Load();
            }

            var managerGrid = managers
                .Select(m => new
                {
                    m.Name,
                    SalesQuantity = m.Sales.Sum(s => s.Quantity),
                    TotalSalesAmount = m.Sales.Sum(s => s.Quantity * s.UnitPrice)
                })
                .ToList();

            dataGridView3.DataSource = managerGrid;
        }


        private void LoadTypes(StationeryContext db, List<ProductType> types)
        {
            foreach (var type in types)
            {
                db.Entry(type).Collection(p => p.Products).Load();
            }

            var typeGrid = types
                .Select(t => new
                {
                    t.Name,
                    Products = t.Products.Sum(s => s.Quantity)
                })
                .ToList();

            dataGridView2.DataSource = typeGrid;
        }

        private void LoadProducts(StationeryContext db, List<Product> products)
        {
            // Загружаем связанные данные вручную так как в FromSqlRaw нет Include
            foreach (var product in products)
            {
                db.Entry(product).Reference(p => p.ProductType).Load();
                db.Entry(product).Collection(p => p.Sales).Load();
            }

            // Преобразуем в удобный формат для DataGridView
            var productGrid = products
                .Select(p => new
                {
                    p.Name,
                    ProductType = p.ProductType.Name,
                    p.Quantity,
                    p.Cost,
                    SalesQuantity = p.Sales.Sum(s => s.Quantity),
                    TotalSalesAmount = p.Sales.Sum(s => s.Quantity * s.UnitPrice)
               })
                .ToList();

            dataGridView1.DataSource = productGrid;
        }

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        ///////////////////////////////////////////////////////////////PROCEDURES\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedType = comboBoxproductstypes.SelectedItem.ToString();


                if (string.IsNullOrEmpty(textBoxproductname.Text) || string.IsNullOrEmpty(textBoxquantity.Text) ||
                    string.IsNullOrEmpty(textBoxcost.Text) || comboBoxproductstypes.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }


                string productName = textBoxproductname.Text;
                int quantity = int.Parse(textBoxquantity.Text);
                decimal cost = decimal.Parse(textBoxcost.Text);



                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("name", productName),
                        new SqlParameter("product_type_name", selectedType),
                        new SqlParameter("quantity", quantity),
                        new SqlParameter("cost", cost)

                    };
                    var numberOfRowInserted = db.Database.ExecuteSqlRaw("Add_Product @name, @product_type_name, @quantity, @cost", sqlParameters);
                    if (numberOfRowInserted == 1)
                        MessageBox.Show("Запись успешно добавлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void buttonAddType_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textBoxTypeName.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните поле.");
                    return;
                }


                string typeName = textBoxTypeName.Text;



                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("name", typeName)

                    };
                    var numberOfRowInserted = db.Database.ExecuteSqlRaw("Add_Type @name", sqlParameters);
                    if (numberOfRowInserted == 1)
                        MessageBox.Show("Запись успешно добавлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddManger_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textBoxManagers.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните поле.");
                    return;
                }


                string managerName = textBoxManagers.Text;



                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("name", managerName)

                    };
                    var numberOfRowInserted = db.Database.ExecuteSqlRaw("Add_Manager @name", sqlParameters);
                    if (numberOfRowInserted == 1)
                        MessageBox.Show("Запись успешно добавлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textBoxCustomer.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните поле.");
                    return;
                }


                string customerName = textBoxCustomer.Text;



                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("name", customerName)
                    };
                    var numberOfRowInserted = db.Database.ExecuteSqlRaw("Add_Customer @name", sqlParameters);
                    if (numberOfRowInserted == 1)
                        MessageBox.Show("Запись успешно добавлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddSale_Click(object sender, EventArgs e)
        {
            try
            {


                string productName = "";
                if (dataGridView5.SelectedRows.Count > 0)
                {

                    productName = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
                }
                else
                {

                    MessageBox.Show("Пожалуйста, выберете в списке кантовар для добавления его продажи.");
                    return;
                }


                if (string.IsNullOrEmpty(textBoxManager.Text) ||
                    string.IsNullOrEmpty(textBoxCustomerName.Text) || string.IsNullOrEmpty(textBoxCount.Text) ||
                    string.IsNullOrEmpty(textBoxPrice.Text) || dateTimePicker1.Value.Date == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }


                string managerName = textBoxManager.Text;
                string customerName = textBoxCustomerName.Text;
                int quantity = int.Parse(textBoxCount.Text);
                decimal unit_price = decimal.Parse(textBoxPrice.Text);
                DateTime selectedDate = dateTimePicker1.Value.Date;



                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                       new SqlParameter("@product_name", productName),
                       new SqlParameter("@manager_name", managerName),
                       new SqlParameter("@customer_name", customerName),
                       new SqlParameter("@quantity", quantity),
                       new SqlParameter("@unit_price", unit_price),
                       new SqlParameter("@date_sale", selectedDate)
                    };
                    var numberOfRowInserted = db.Database.ExecuteSqlRaw("Add_Sale @product_name, @manager_name, @customer_name, @quantity, @unit_price, @date_sale", sqlParameters);
                    if (numberOfRowInserted == 1)
                        MessageBox.Show("Запись успешно добавлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            try
            {

                string productName = "";
                int quantity = 0;
                decimal cost = 0;
                string productType = "";


                if (dataGridView1.SelectedRows.Count > 0)
                {

                    productName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    productType = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    quantity = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                    cost = decimal.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());


                }
                else
                {

                    MessageBox.Show("Пожалуйста, выберете в списке кантовар для изменения.");
                    return;
                }

                string newproductName = textBoxproductname.Text;
                int newquantity = int.Parse(textBoxquantity.Text);
                decimal newcost = decimal.Parse(textBoxcost.Text);
                string newType = comboBoxproductstypes.SelectedItem.ToString();


                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("oldname", productName),
                        new SqlParameter("name", newproductName),
                        new SqlParameter("product_type_name", newType),
                        new SqlParameter("quantity", newquantity),
                        new SqlParameter("cost", newcost)

                    };
                    var numberOfRowUpdated = db.Database.ExecuteSqlRaw("Update_Product @oldname, @name, @product_type_name, @quantity, @cost", sqlParameters);
                    if (numberOfRowUpdated == 1)
                        MessageBox.Show("Запись успешно обновлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonUpdateType_Click(object sender, EventArgs e)
        {
            try
            {
                string typeName = "";
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    typeName = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                }
                else
                {

                    MessageBox.Show("Пожалуйста, выберете в списке тип для изменения.");
                    return;
                }
                string newtypeName = textBoxTypeName.Text;

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("oldname", typeName),
                        new SqlParameter("name", newtypeName)

                    };
                    var numberOfRowUpdated = db.Database.ExecuteSqlRaw("Update_Type @oldname, @name", sqlParameters);
                    if (numberOfRowUpdated == 1)
                        MessageBox.Show("Запись успешно обновлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonUpdateManager_Click(object sender, EventArgs e)
        {
            try
            {
                string managerName = "";
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    managerName = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                }
                else
                {

                    MessageBox.Show("Пожалуйста, выберете в списке тип для изменения.");
                    return;
                }
                string newmanagerName = textBoxManagers.Text;

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("oldname", managerName),
                        new SqlParameter("name", newmanagerName)

                    };
                    var numberOfRowUpdated = db.Database.ExecuteSqlRaw("Update_Manager @oldname, @name", sqlParameters);
                    if (numberOfRowUpdated == 1)
                        MessageBox.Show("Запись успешно обновлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = "";
                if (dataGridView4.SelectedRows.Count > 0)
                {
                    customerName = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
                }
                else
                {

                    MessageBox.Show("Пожалуйста, выберете в списке тип для изменения.");
                    return;
                }
                string newcustomerName = textBoxCustomer.Text;

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("oldname", customerName),
                        new SqlParameter("name", newcustomerName)

                    };
                    var numberOfRowUpdated = db.Database.ExecuteSqlRaw("Update_Customer @oldname, @name", sqlParameters);
                    if (numberOfRowUpdated == 1)
                        MessageBox.Show("Запись успешно обновлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUpdateSale_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = "";
                string managerName = "";
                string customerName = "";
                int quantity = 0;
                decimal unit_price = 0;
                DateTime olddate;

                if (dataGridView5.SelectedRows.Count > 0)
                {

                    productName = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
                    managerName = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();
                    customerName = dataGridView5.SelectedRows[0].Cells[2].Value.ToString();
                    quantity = int.Parse(dataGridView5.SelectedRows[0].Cells[3].Value.ToString());
                    unit_price = decimal.Parse(dataGridView5.SelectedRows[0].Cells[4].Value.ToString());
                    olddate = DateTime.Parse(dataGridView5.SelectedRows[0].Cells[5].Value.ToString());

                }
                else
                {

                    MessageBox.Show("Пожалуйста, выберете в списке кантовар для изменения.");
                    return;
                }


                if (string.IsNullOrEmpty(textBoxManager.Text) ||
                  string.IsNullOrEmpty(textBoxCustomerName.Text) || string.IsNullOrEmpty(textBoxCount.Text) ||
                  string.IsNullOrEmpty(textBoxPrice.Text) || dateTimePicker1.Value.Date == null)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return;
                }


                string newmanagerName = textBoxManager.Text;
                string newcustomerName = textBoxCustomerName.Text;
                int newquantity = int.Parse(textBoxCount.Text);
                decimal newunit_price = decimal.Parse(textBoxPrice.Text);
                DateTime newselectedDate = dateTimePicker1.Value.Date;



                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter[] sqlParameters = {
                        new SqlParameter("oldname", productName),
                        new SqlParameter("product", productName),
                        new SqlParameter("oldmanager", managerName),
                        new SqlParameter("manager", newmanagerName),
                        new SqlParameter("oldcustomer", customerName),
                        new SqlParameter("customer", newcustomerName),
                        new SqlParameter("quantity", newquantity),
                        new SqlParameter("unit_price", newunit_price),
                        new SqlParameter("selectedDate", newselectedDate),

                    };
                    var numberOfRowUpdated = db.Database.ExecuteSqlRaw("Update_Sale @oldname, @product, @oldmanager, @manager,@oldcustomer, @customer, @quantity,@unit_price,@selectedDate", sqlParameters);
                    if (numberOfRowUpdated == 1)
                        MessageBox.Show("Запись успешно обновлена в таблицу!");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = "";
                if (!string.IsNullOrEmpty(textBoxproductname.Text))
                {
                    productName = textBoxproductname.Text;
                }
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    productName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                }


                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Пожалуйста, выберите товар для удаления.");
                    return;
                }
                productName = "%" + productName + "%";

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = productName
                    };
                    var numberOfRowDeleted = db.Database.ExecuteSqlRaw("Delete_Product @name", param);
                    MessageBox.Show("Количество удаленных записей: " + numberOfRowDeleted.ToString());
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }








        private void buttonDeleteType_Click(object sender, EventArgs e)
        {
            try
            {
                string typeName = "";
                if (!string.IsNullOrEmpty(textBoxTypeName.Text))
                {
                    typeName = textBoxTypeName.Text;
                }
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    typeName = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                }


                if (string.IsNullOrEmpty(typeName))
                {
                    MessageBox.Show("Пожалуйста, выберите товар для удаления.");
                    return;
                }
                typeName = "%" + typeName + "%";

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = typeName
                    };
                    var numberOfRowDeleted = db.Database.ExecuteSqlRaw("Delete_Type @name", param);
                    MessageBox.Show("Количество удаленных записей: " + numberOfRowDeleted.ToString());
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void buttonDeleteManager_Click(object sender, EventArgs e)
        {
            try
            {
                string managerName = "";
                if (!string.IsNullOrEmpty(textBoxManagers.Text))
                {
                    managerName = textBoxManagers.Text;
                }
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    managerName = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                }


                if (string.IsNullOrEmpty(managerName))
                {
                    MessageBox.Show("Пожалуйста, выберите товар для удаления.");
                    return;
                }
                managerName = "%" + managerName + "%";

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = managerName
                    };
                    var numberOfRowDeleted = db.Database.ExecuteSqlRaw("Delete_Manager @name", param);
                    MessageBox.Show("Количество удаленных записей: " + numberOfRowDeleted.ToString());
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void buttonDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = "";
                if (!string.IsNullOrEmpty(textBoxCustomer.Text))
                {
                    customerName = textBoxCustomer.Text;
                }
                if (dataGridView4.SelectedRows.Count > 0)
                {
                    customerName = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
                }


                if (string.IsNullOrEmpty(customerName))
                {
                    MessageBox.Show("Пожалуйста, выберите товар для удаления.");
                    return;
                }
                customerName = "%" + customerName + "%";

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = customerName
                    };
                    var numberOfRowDeleted = db.Database.ExecuteSqlRaw("Delete_Customer @name", param);
                    MessageBox.Show("Количество удаленных записей: " + numberOfRowDeleted.ToString());
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void buttonDeleteSale_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = "";
                string managerName = "";
                string customerName = "";
                int quantity = 0;
                decimal unit_price = 0;
                DateTime date;

                if (dataGridView5.SelectedRows.Count > 0)
                {

                    productName = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
                    managerName = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();
                    customerName = dataGridView5.SelectedRows[0].Cells[2].Value.ToString();
                    quantity = int.Parse(dataGridView5.SelectedRows[0].Cells[3].Value.ToString());
                    unit_price = decimal.Parse(dataGridView5.SelectedRows[0].Cells[4].Value.ToString());
                    date = DateTime.Parse(dataGridView5.SelectedRows[0].Cells[5].Value.ToString());

                }
                else
                {

                    MessageBox.Show("Пожалуйста, выберете в списке кантовар для изменения.");
                    return;
                }



                if (string.IsNullOrEmpty(productName))
                {
                    MessageBox.Show("Пожалуйста, выберите товар для удаления.");
                    return;
                }
                productName = "%" + productName + "%";

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = productName
                    };
                    SqlParameter param2 = new()
                    {
                        ParameterName = "@manager_name",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = managerName
                    };
                    SqlParameter param3 = new()
                    {
                        ParameterName = "@customer_name",
                        SqlDbType = SqlDbType.NVarChar,
                        Value = customerName
                    };
                    var numberOfRowDeleted = db.Database.ExecuteSqlRaw("Delete_Sale @name, @manager_name, @customer_name", param, param2, param3);
                    MessageBox.Show("Количество удаленных записей: " + numberOfRowDeleted.ToString());
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }












        private void buttonshowbytype_ClickP(object sender, EventArgs e)
        {
            try
            {
                string selectedType = comboBoxproductstypes.SelectedItem.ToString();

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new("@type", selectedType);
                    var products = db.Products.FromSqlRaw("ShowProductsByType @type", param).ToList();

                    LoadProducts(db, products);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }







        private void buttonMaxQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@productType",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Output,
                        Size = 255
                    };
                    SqlParameter param2 = new()
                    {
                        ParameterName = "@totalQuantity",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    db.Database.ExecuteSqlRaw("MaxQuantity @productType  out, @totalQuantity  out", param, param2);
                    MessageBox.Show("Тип продукции: " + param.Value.ToString() + "  Максимальное количество: " + param2.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMinQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@productType",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Output,
                        Size = 255
                    };
                    SqlParameter param2 = new()
                    {
                        ParameterName = "@totalQuantity",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    db.Database.ExecuteSqlRaw("MinQuantity @productType  out, @totalQuantity  out", param, param2);
                    MessageBox.Show("Тип продукции: " + param.Value.ToString() + "  Минимальное количество: " + param2.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMaxCost_Click(object sender, EventArgs e)
        {
            try
            {
                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@productType",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Output,
                        Size = 255
                    };
                    SqlParameter param2 = new()
                    {
                        ParameterName = "@maxCost",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    db.Database.ExecuteSqlRaw("MaxCostProduct @productType  out, @maxCost  out", param, param2);
                    MessageBox.Show("Тип продукции: " + param.Value.ToString() + "  Максимальная себестоимость: " + param2.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonMinCost_Click(object sender, EventArgs e)
        {
            try
            {
                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new()
                    {
                        ParameterName = "@productType",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Output,
                        Size = 255
                    };
                    SqlParameter param2 = new()
                    {
                        ParameterName = "@minCost",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    db.Database.ExecuteSqlRaw("MinCostProduct @productType  out, @minCost  out", param, param2);
                    MessageBox.Show("Тип продукции: " + param.Value.ToString() + "  Минимальная себестоимость: " + param2.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
















        ///////////////////////////////////////////////////////////////Functions\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        private void buttonshowbytype_ClickF(object sender, EventArgs e)
        {
            try
            {
                string selectedType = comboBoxproductstypes.SelectedItem.ToString();

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new SqlParameter("@Product_Type", selectedType);
                    var products = db.Products.FromSqlRaw("SELECT * FROM ProductsList (@Product_Type)", param).ToList();

                    LoadProducts(db, products);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


       



        private void buttonshowbymanagers_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedManager = comboBoxManagers.SelectedItem.ToString();

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new SqlParameter("@Product_Manager", selectedManager);
                    var manager = db.Sales.FromSqlRaw("SELECT * FROM SalesByManager (@Product_Manager)", param).ToList();

                    LoadSales(db, manager);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonshowbycustomers_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedCustomer = comboBoxCustomers.SelectedItem.ToString();

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new SqlParameter("@Product_Customer", selectedCustomer);
                    var customer = db.Sales.FromSqlRaw("SELECT * FROM SalesByCustomer (@Product_Customer)", param).ToList();

                    LoadSales(db, customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLatestSale_Click(object sender, EventArgs e)
        {
            try
            {
                using (StationeryContext db = new StationeryContext())
                {
                    var customer = db.Sales.FromSqlRaw("SELECT * FROM LatestSale ()").ToList();

                    LoadSales(db, customer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void buttonAVQF_Click(object sender, EventArgs e)
        {
            try
            {

                string selectedType = comboBoxproductstypes.SelectedItem.ToString();

                using (StationeryContext db = new StationeryContext())
                {
                    SqlParameter param = new SqlParameter("@Product_Type", selectedType);
                    var avg = db.Products.FromSqlRaw("SELECT * FROM AVGQuantityByType (@Product_Type)", param).ToList();

                    LoadProducts(db, avg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
