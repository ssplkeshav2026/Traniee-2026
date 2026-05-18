USE Assignment1;

--1 Write a query to retrieve all columns from the Products table. --
SELECT * FROM Products;

--2 Write a query to display ProductName, UnitPrice, and UnitsInStock from the Products table for all products that are not discontinued (Discontinued = 0). --
SELECT ProductName, UnitPrice, UnitsInStock FROM Products WHERE Discontinued = 0;

--3 Retrieve all products where the UnitPrice is greater than 50. Display ProductName and UnitPrice, ordered by price from highest to lowest. --
SELECT ProductName, UnitPrice FROM Products WHERE UnitPrice > 50 
 ORDER BY UnitPrice DESC;

--4 Write a query to find all customers from Germany, USA, or France. Display CustomerID, CompanyName, and Country. --
SELECT CustomerID, CompanyName, Country FROM Customers WHERE Country IN('Germany', 'USA', 'France');

--5 Find all products where the ProductName starts with 'C'. Display ProductName and CategoryID. --
SELECT ProductName, CategoryID FROM Products WHERE ProductName LIKE 'C%';

--6 Retrieve all orders placed in the year 1997. Display OrderID, CustomerID, and OrderDate. --
SELECT OrderID, CustomerID, OrderDate FROM Orders WHERE YEAR(OrderDate) = '1997';

--7 Write a query to display products that are either out of stock (UnitsInStock = 0) OR have a price less than 10. Show ProductName, UnitPrice, and UnitsInStock. --
SELECT ProductName, UnitPrice, UnitsInStock FROM Products WHERE UnitsInStock = 0 OR UnitPrice < 10;

--8 Find all employees whose LastName is between 'D' and 'M' alphabetically. Display FirstName, LastName, and Title. --
SELECT FirstName, LastName, Title FROM Employees WHERE LastName BETWEEN 'D' AND 'M';

--9 Retrieve the top 10 most expensive products. Display ProductName and UnitPrice. --
SELECT TOP 10 ProductName, UnitPrice FROM Products ORDER BY UnitPrice DESC;

--10 Write a query to find all orders where the ShippedDate is NULL (not yet shipped). Display OrderID, CustomerID, and OrderDate. --
SELECT OrderID, CustomerID, OrderDate FROM Orders WHERE ShippedDate IS NULL;

--11 Write a query to display ProductName along with its CategoryName. Use INNER JOIN between Products and Categories tables. --
SELECT p.ProductName, c.CategoryName FROM Products p
 INNER JOIN Categories c ON c.CategoryID = p.CategoryID;

--12 Retrieve all orders with customer information. Display OrderID, OrderDate, CompanyName, and ContactName. Join Orders and Customers tables. --
SELECT o.OrderID, o.OrderDate, c.CompanyName, c.ContactName FROM Orders o
  INNER JOIN Customers c ON c.CustomerID = o.CustomerID;

--13 Display ProductName, Company Name (from Suppliers), and UnitPrice for all products. Use INNER JOIN between Products and Suppliers. --
SELECT p.ProductName, s.CompanyName, p.UnitPrice FROM Products p
  INNER JOIN Suppliers s ON s.SupplierID = p.SupplierID;

--14 Write a query to show all order details with product names. Display OrderID, ProductName, Quantity, and UnitPrice from the OrderDetails and Products tables. -- 
SELECT od.OrderID, p.ProductName, od.Quantity, od.UnitPrice FROM OrderDetails od
  INNER JOIN Products p ON p.ProductID = od.ProductID;

--15 List all employees with their managers' names. Display EmployeeID, Employee's FirstName and LastName, and Manager's FirstName and LastName. (Use self-join on Employees table). --
SELECT e.EmployeeID, e.FirstName, e.LastName, m.FirstName, m.LastName FROM Employees e
  JOIN Employees m ON e.ReportsTo = m.EmployeeID;

--16 Show all customers and their orders. Include customers even if they haven't placed any orders. Display CustomerID, CompanyName, and OrderID. --
SELECT c.CustomerID, c.CompanyName, o.OrderID FROM Customers c
  LEFT JOIN Orders o ON c.CustomerID = o.CustomerID;

--17 Write a query using three tables: Orders, Customers, and Employees. Display OrderID, CompanyName (customer), and the employee's full name (FirstName + LastName) who handled the order. --
SELECT o.OrderID, c.CompanyName, e.FirstName + ' ' + e.LastName AS EmployeeFullName FROM Orders o
 INNER JOIN Customers c ON o.CustomerID = c.CustomerID
 INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID;

--18 Find all products and their categories. Include products that don't have a category assigned (CategoryID is NULL). Display ProductName and CategoryName. --
SELECT p.ProductName, c.CategoryName FROM Products p
 LEFT JOIN Categories c ON c.CategoryID = p.CategoryID;

--19 Display OrderID, ProductName, Quantity, CategoryName by joining three tables: OrderDetails, Products, and Categories. --
SELECT o.OrderID, p.ProductName, o.Quantity, c.CategoryName FROM OrderDetails o
 INNER JOIN Products p ON p.ProductID = o.ProductID
 INNER JOIN Categories c ON c.CategoryID = p.CategoryID;

--20 Write a query to show all combinations of Customers and Orders (CROSS JOIN). Limit the result to 100 rows. Display CustomerID and OrderID. --
SELECT TOP 100 c.CustomerID, o.OrderID FROM Customers c 
 CROSS JOIN Orders o 

--21 Find the total number of products in the Products table. --
 SELECT COUNT(*) AS TotalProducts FROM Products;

--22 Calculate the average unit price of all products. Round to 2 decimal places. --
 SELECT ROUND(AVG(UnitPrice),2) AS AveragePrice FROM Products;

--23 Find the minimum and maximum UnitPrice from the Products table. Display both in one query. --
 SELECT MIN(UnitPrice) AS MinPrice, MAX(UnitPrice) AS MaxPrice FROM Products;

--24 Count how many products exist in each category. Display CategoryID and the count of products. --
 SELECT CategoryID, COUNT(*) AS TotalProducts FROM Products GROUP BY CategoryID;

--25 Show CategoryName and the number of products in each category. Join Products and Categories tables and use GROUP BY. --
 SELECT c.CategoryName, COUNT(p.ProductID) AS NumberOfProducts FROM Categories c
  INNER JOIN Products p ON p.CategoryID = c.CategoryID
  GROUP BY c.CategoryName;

--26 Find the total quantity ordered for each product. Display ProductID and total quantity from OrderDetails. --
 SELECT ProductID, SUM(Quantity) AS TotalQuantity FROM OrderDetails GROUP BY ProductID;

--27 Find categories that have more than 10 products. Display CategoryName and product count. --
 SELECT c.CategoryName, COUNT(p.ProductID) AS NumberOfProducts FROM Categories c
  INNER JOIN Products p ON p.CategoryID = c.CategoryID
  GROUP BY CategoryName HAVING COUNT(p.ProductID) >10;

--28 Calculate the total sales amount for each order. Display OrderID and total amount (UnitPrice Quantity* (1 - Discount)) from OrderDetails. --
 SELECT OrderID, SUM(UnitPrice * Quantity * (1 - Discount)) AS TotalAmount FROM 
    OrderDetails GROUP BY OrderID;

--29 Write an INSERT statement to add a new category to the Categories table. CategoryName = 'Organic Foods', Description = 'Certified organic products'. --
 INSERT INTO Categories(CategoryName, Description) 
 VALUES ('Organic Foods','Certified organic products');

--30 Insert a new product into the Products table. ProductName = 'Green Tea', SupplierID = 1, CategoryID = 1, UnitPrice = 15.00, UnitsInStock = 50, Discontinued = 0. --
 INSERT INTO Products(ProductName, SupplierID, CategoryID, UnitPrice, UnitsInStock, Discontinued) 
 VALUES('Green Tea', 1, 1, 15.00, 50, 0);

--31 Write an UPDATE statement to increase the UnitPrice of all products in CategoryID 1 by 10%. --
 SELECT * FROM Products;
 UPDATE Products SET UnitPrice = UnitPrice * 1.10 WHERE CategoryID = 1;

--32 Update the phone number of the customer with CustomerID = 'ALFKI' to '030-1234567'.
 UPDATE Customers SET Phone = '030-1234567' WHERE CustomerID = 'ALFKI';  

--33 Mark all products as discontinued (set Discontinued = 1) where UnitsInStock = 0. --
 UPDATE Products SET Discontinued = 1 WHERE UnitsInStock = 0;

--34 Delete all products that are discontinued AND have never been ordered (don't exist in OrderDetails). --
 DELETE p FROM Products AS p
    WHERE Discontinued = 1
    AND NOT EXISTS (
    SELECT * 
    FROM OrderDetails AS od
    WHERE od.ProductID = p.ProductID
 );

--35 Write a transaction that inserts a new customer and then inserts an order for that customer. Use BEGIN TRANSACTION, COMMIT, and include error handling with TRY/CATCH. --
 BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO Customers (CustomerID, CompanyName, ContactName, Phone) 
    VALUES ('JCKWI', 'JackWilliamstech', 'Jack Williams', '0141-4012365');

    INSERT INTO Orders (CustomerID, OrderDate) 
    VALUES ('JCKWI', GETDATE());

    COMMIT TRANSACTION;
 END TRY
 BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT ERROR_MESSAGE();
 END CATCH;
 
 
 --36 Find all products that have a UnitPrice greater than the average price of all products. Display ProductName and UnitPrice. --
 SELECT ProductName, UnitPrice FROM Products WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);

 --37 Find customers who have placed at least one order. Display CustomerID and CompanyName. Use a subquery with EXISTS. --
 SELECT c.CustomerID, c.CompanyName FROM Customers c WHERE EXISTS(
    SELECT 1 FROM Orders o WHERE o.CustomerID = c.CustomerID
 );

 --38 Find all products supplied by suppliers from 'Germany'. Use a subquery to get SupplierIDs first. --
 SELECT  * FROM Products WHERE SupplierID IN (SELECT SupplierID FROM Suppliers WHERE Country = 'Germany');

 --39 Write a query using a Common Table Expression (CTE) to find the average order value, then display all orders that are above this average. --
 WITH total_order AS(
    SELECT OrderID, SUM(UnitPrice * Quantity * (1-Discount)) AS total_amt FROM OrderDetails
    GROUP BY OrderID
 ) 
 SELECT * FROM total_order WHERE total_amt > (SELECT AVG(total_amt) FROM total_order);


 --40 Use a CTE to calculate the number of orders per customer, then select customers who have placed more than 10 orders. --
 WITH NumberofOrders AS(
    SELECT CustomerID,
    COUNT(OrderID) AS total_orders
    FROM Orders GROUP BY CustomerID
 )

 SELECT CustomerID, total_orders FROM NumberOfOrders WHERE total_orders > 10;

 --41 Find the most expensive product in each category using a correlated subquery. Display CategoryID, ProductName, and UnitPrice. --
 SELECT CategoryID, ProductName, UnitPrice FROM Products AS p WHERE UnitPrice = (
    SELECT MAX(UnitPrice) FROM Products WHERE CategoryID = p.CategoryID
 );

 --42 Write a query to find customers who have never placed and order. --
 SELECT * FROM Customers c WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
);

--43 Create a simple VIEW named vw_ProductList that displays ProductID, ProductName, CategoryName, and UnitPrice for all active products (not discontinued). --
 CREATE VIEW vw_ProductList AS
    SELECT p.ProductID, p.ProductName, c.CategoryName, p.UnitPrice FROM Products p
    INNER JOIN Categories c ON p.CategoryID = c.CategoryID
    WHERE p.Discontinued = 0;

 --44 Create a VIEW named vw_OrderSummary that shows OrderID, CustomerName (CompanyName), OrderDate, and the number of items in each order. --
  CREATE VIEW vw_OrderSummary AS 
    SELECT o.OrderID, c.CompanyName, o.OrderDate, COUNT(o.OrderID) AS NumberOfItems FROM Orders o
     INNER JOIN Customers c ON c.CustomerID = o.CustomerID
     INNER JOIN OrderDetails od ON od.OrderID = o.OrderID
     GROUP BY o.OrderID, c.CompanyName, o.OrderDate;
    
   --45 Write a stored procedure named usp_GetProductsByCategory that accepts a @CategoryID parameter and returns all products in that category. --
   CREATE PROCEDURE usp_GetProductsByCategory
        @CategoryID INT
    AS
    BEGIN
        SELECT * FROM Products WHERE CategoryID = @CategoryID;
    END;

   --46 Create a stored procedure named usp_GetCustomerOrders that accepts @CustomerID as a parameter and returns all orders for that customer with order details. --
   CREATE PROCEDURE usp_GetCustomerOrders
        @CustomerID VARCHAR(40)
    AS 
    BEGIN
        SELECT o.OrderID, o.OrderDate, od.ProductID, od.Quantity, od.UnitPrice FROM Orders o
         INNER JOIN OrderDetails od ON od.OrderID = o.OrderID
         WHERE o.CustomerID = @CustomerID;
    END

    --47 Write a stored procedure usp_AddCategory that accepts @CategoryName and @Description as parameters, inserts a new category, and returns the newly created CategoryID using an OUTPUT parameter. --
    CREATE PROCEDURE usp_AddCategory
    @CategoryName VARCHAR(100),
    @Description VARCHAR(MAX),
    @CategoryID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Categories (CategoryName, Description)
    VALUES (@CategoryName, @Description);
    SET @CategoryID = SCOPE_IDENTITY();
END;

--48 Create a stored procedure usp_UpdateProductPrice that accepts @ProductID and @NewPrice, validates that @NewPrice is greater than 0, and updates the product's price. Use RAISERROR for validation. --
CREATE PROCEDURE usp_UpdateProductPrice
    @ProductID INT,
    @NewPrice DECIMAL(10, 2)
AS
BEGIN
    
    IF @NewPrice <= 0
    BEGIN
        RAISERROR('The new price must be greater than 0.', 16, 1);
        RETURN;
    END

    UPDATE Products
    SET UnitPrice = @NewPrice
    WHERE ProductID = @ProductID;

END;

--49 Write a stored procedure usp_GetEmployeeSales that shows total sales handled by each employee. Return EmployeeID, FullName (FirstName + LastName), and TotalSales amount. --
CREATE PROCEDURE usp_GetEmployeeSales
AS
BEGIN
    SELECT 
        e.EmployeeID,
        e.FirstName + ' ' + e.LastName AS FullName,
        SUM(od.Quantity * od.UnitPrice) AS TotalSales
    FROM Employees e
    INNER JOIN Orders o ON e.EmployeeID = o.EmployeeID
    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
    GROUP BY e.EmployeeID, e.FirstName, e.LastName;
END;
GO

--50 Create a stored procedure usp_GetMonthly OrderStats that accepts @Year and @Month as parameters and returns the total number of orders and total revenue for that month. --
CREATE PROCEDURE usp_GetMonthlyOrderStats
    @Year INT,
    @Month INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        COUNT(DISTINCT o.OrderID) AS TotalOrders, 
        SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalRevenue
    FROM 
        Orders o
    INNER JOIN 
        OrderDetails od ON o.OrderID = od.OrderID
    WHERE 
        YEAR(o.OrderDate) = @Year AND 
        MONTH(o.OrderDate) = @Month;
END;
GO
usp_GetMonthlyOrderStats 1996, 07;

