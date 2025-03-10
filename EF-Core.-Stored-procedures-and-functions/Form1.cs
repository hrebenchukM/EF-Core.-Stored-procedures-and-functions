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

            }
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


        private void buttonAVQF_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    using (StationeryContext db = new StationeryContext())
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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

        private void buttonshowbymanager_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string selectedManager = comboBoxManager.SelectedItem.ToString();

            //    using (StationeryContext db = new StationeryContext())
            //    {
            //        SqlParameter param = new SqlParameter("@Product_Manager", selectedManager);
            //        var products = db.Products.FromSqlRaw("SELECT * FROM ProductsListManager (@Product_Manager)", param).ToList();

            //        LoadProducts(db, products);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
