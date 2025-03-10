CREATE DATABASE Stationery;
GO

USE Stationery;
GO

CREATE TABLE product_types (
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(255) NOT NULL
);

CREATE TABLE products (
    id INT IDENTITY PRIMARY KEY,       
    name NVARCHAR(255) NOT NULL, 
	product_type_id INT  NOT NULL,
	quantity INT NOT NULL CHECK (quantity >= 0),
	cost DECIMAL(10,2) NOT NULL CHECK (cost >= 0), 
	FOREIGN KEY (product_type_id) REFERENCES product_types(id) ON DELETE CASCADE
);

CREATE TABLE managers (
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(255) NOT NULL
);

CREATE TABLE customers (
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(255) NOT NULL
);



CREATE TABLE sales (
    id INT IDENTITY PRIMARY KEY,
    product_id INT NOT NULL,
    manager_id INT NOT NULL,
    customer_id INT NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    unit_price DECIMAL(10,2) NOT NULL CHECK (unit_price >= 0),
    date_sale DATE NOT NULL,
    FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE,
    FOREIGN KEY (manager_id) REFERENCES managers(id),
    FOREIGN KEY (customer_id) REFERENCES customers(id)
);

	INSERT INTO product_types (name) 
VALUES
('�����'),
('���������'),
('�������'),
('�������'),
('�������'),
('������'),
('�������'),
('��������'),
('������'),
('�������'),
('������'),
('��������'),
('�������'),
('����������');



	INSERT INTO products (name, product_type_id, quantity, cost)
VALUES
('����� �������', 1, 500, 29.99),
('����� �����', 1, 500, 29.99),
('�������� ������� � ����������', 2, 500, 29.99),
('������� � ������ ��� �������', 3, 200, 39.99),
('������ "���������" (��������)', 4, 50, 49.99),
('������� ��������� �� ����������', 5, 100, 24.99),
('����� ��������', 6, 100, 19.99),
('������� ��������� �� �������', 7, 1000, 1.99),
('������� ��������� ����������', 8, 50, 35.99),
('������ A1', 9, 700, 49.99),
('������ ��� ��������� "����� ������" (�������, ��������)', 10, 5000, 199.99),
('������ ����������� ��� ���������������� (���������)', 11, 1000, 99.99),
('�������� ��� ���������', 12, 100, 34.99),
('������� ����������� � �������� ���������', 13, 3000, 20.99),
('���������� (����� ��� ���������� ���������)', 14, 200, 89.99);



	INSERT INTO managers (name)
VALUES
('��������� �����'),
('��������� ������'),
('������� �����'),
('���� ����'),
('������� ����');


	INSERT INTO customers (name)
VALUES
('������ ����'),
('����� ����'),
('�������� ����������');


	INSERT INTO sales (product_id, manager_id, customer_id, quantity, unit_price, date_sale)
VALUES
(1, 1, 1, 10, 39.99, '2025-02-23'),
(2, 2, 2, 5, 39.99, '2025-02-24'),
(3, 3, 3, 20, 49.99, '2025-02-25'),
(4, 4, 1, 15, 59.99, '2025-02-26'),
(5, 5, 2, 8, 34.99, '2025-02-27'),
(6, 1, 3, 25, 29.99, '2025-02-28'),
(7, 2, 1, 100, 10.99, '2025-03-01'),
(8, 3, 2, 7, 45.99, '2025-03-02'),
(9, 4, 3, 50, 59.99, '2025-03-03'),
(10, 5, 1, 30, 219.99, '2025-03-04'),
(11, 1, 2, 50, 110.99, '2025-03-05'),
(12, 2, 3, 12, 44.99, '2025-03-06'),
(13, 3, 1, 60, 30.99, '2025-03-07'),
(14, 4, 2, 25, 99.99, '2025-03-08');

            Create function ProductsList(
                @Product_Type nvarchar(255)
            )
              returns @returntable table
              (
                id int,
                name nvarchar(100),
	            product_type_id int ,
                quantity int,
	            cost decimal
            )
              as
              BEGIN
                INSERT  @returntable
                SELECT id, name, product_type_id, quantity, cost
	            FROM products 
				WHERE product_type_id = (SELECT id FROM product_types WHERE name = @Product_Type)
                RETURN
              END
              go

              select * from ProductsList(N'�����')  
			  


			 
			  
           
		   

		  


		    create procedure ShowProductsByType
            @type nvarchar (255) as
            select * from products
            where product_type_id = (SELECT id FROM product_types WHERE name like @type) 
            order by Name desc
            go

            execute ShowProductsByType '�����' 




			
            create procedure Add_Product 
			             @name nvarchar(255), 
			             @product_type_name nvarchar(255),
						 @quantity int,
						 @cost decimal(10, 2)
            as
            INSERT INTO products  (name, product_type_id, quantity, cost)
            VALUES  (@name, (SELECT id FROM product_types WHERE name = @product_type_name), @quantity, @cost)
        

			
            create procedure Add_Type
			             @name nvarchar(255)
            as
            INSERT INTO product_types  (name)
            VALUES  (@name)
        
		   create procedure Add_Manager
			             @name nvarchar(255)
            as
            INSERT INTO managers(name)
            VALUES  (@name)


	
	 
           create procedure Delete_Product 
           @name nvarchar (255) as
           delete from products where name like @name 
		   go

		     create procedure Delete_Type 
           @name nvarchar (255) as
           delete from product_types where name like @name 
		   go

		    create procedure Delete_Manager 
           @name nvarchar (255) as
           delete from managers where name like @name 
		   go
		   
            declare @name nvarchar(255)
            set @name = '%Visual%Basic%'
            execute Delete_Product @name 
            go
        



		 create procedure Update_Product 
		   @oldname nvarchar(255),
           @name nvarchar(255), 
		   @product_type_name nvarchar(255),
		   @quantity int,
		   @cost decimal(10, 2)
		   as
            update products 
			set 
			name = @name,
			product_type_id = (SELECT id FROM product_types WHERE name = @product_type_name),
            quantity = @quantity,
            cost = @cost
			where name = @oldname
		   go




		   
		 create procedure Update_Type 
		   @oldname nvarchar(255),
           @name nvarchar(255)
		   as
            update product_types 
			set 
			name = @name
			where name = @oldname
		   go



		    create procedure Update_Manager
		   @oldname nvarchar(255),
           @name nvarchar(255)
		   as
            update managers 
			set 
			name = @name
			where name = @oldname
		   go
		   

           
             create view sum_of_quantity as
             SELECT SUM(quantity) as TotalQuantity, 
            (SELECT name FROM product_types WHERE id = product_type_id) as ProductType
            FROM products
            GROUP BY product_type_id;
            go


			create view cost_cost_per_type as
            SELECT product_type_id,
           (SELECT name FROM product_types WHERE id = product_type_id) as ProductType,
		    min(cost) AS MinCost,
            max(cost) AS MaxCost
            FROM products
            GROUP BY product_type_id;
            GO


			create procedure MaxCostProduct
            @productType  nvarchar(255) output, 
            @maxCost decimal(10, 2) output
              as
              select @maxCost = max(MaxCost)
              from cost_cost_per_type;
              select @productType = ProductType
				from cost_cost_per_type
				where MaxCost = @maxCost;
				go

				create procedure MinCostProduct
            @productType  nvarchar(255) output, 
            @minCost decimal(10, 2) output
              as
              select @minCost = min(MinCost)
              from cost_cost_per_type;
              select @productType = ProductType
				from cost_cost_per_type
				where MinCost = @minCost;
				go



				  declare @productType nvarchar(255), @maxCost int;
            execute MaxCostProduct @productType output, @maxCost output;
            select '��� ���������:', @productType, '������������ �������������:', @maxCost;
            go

				  declare @productType nvarchar(255), @minCost int;
            execute MinCostProduct @productType output, @minCost output;
            select '��� ���������:', @productType, '����������� �������������:', @minCost;
            go


              create procedure MaxQuantity
			  @productType nvarchar(255) output, 
			  @totalQuantity int output
              as
              select @totalQuantity = max(TotalQuantity) 
			  from sum_of_quantity;
             
			  select @productType = ProductType
              from sum_of_quantity
              where TotalQuantity = @totalQuantity;
			  go

             declare @productType nvarchar(255), @totalQuantity int;
            execute MaxQuantity @productType output, @totalQuantity output;
            select '��� ���������:', @productType, '������������ ����������:', @totalQuantity;
            go

            
			  create procedure MinQuantity
			  @productType nvarchar(255) output, 
			  @totalQuantity int output
              as
              select @totalQuantity = min(TotalQuantity) 
			  from sum_of_quantity;
             
			  select @productType = ProductType
              from sum_of_quantity
              where TotalQuantity = @totalQuantity;
			  go

			     declare @productType nvarchar(255), @totalQuantity int;
            execute MinQuantity @productType output, @totalQuantity output;
            select '��� ���������:', @productType, '����������� ����������:', @totalQuantity;
            go

        




			  
	