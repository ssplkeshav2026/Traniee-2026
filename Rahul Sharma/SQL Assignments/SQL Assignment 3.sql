use first_assignment

-- Q1 Write a query to retrieve all columns from the Products table.

select * from Products

--Q2 Write a query to display ProductName, UnitPrice, and UnitsInStock from the Products table for all products 
  -- are not discontinued (Discontinued = 0).

select productname,UnitPrice,UnitsInStock,Discontinued from products where discontinued=0

--Q3.Retrieve all products where the UnitPrice is greater than 50. Display ProductName and UnitPrice, ordered 
--by price from highest to lowest. Hint: Use WHERE for filtering and ORDER BY DESC for descending order

select ProductName,UnitPrice from Products where UnitPrice>50 order by UnitPrice desc

--Q4.Write a query to find all customers from Germany, USA, or France. Display CustomerID, Company Name, and Country.Hint: Use the IN operator for multiple values

select CustomerID,CompanyName,Country from Customers where Country in ('germany','usa','France')

--Q5 Find all products where the ProductName starts with 'C'. Display ProductName and CategoryID.

SELECT ProductName, CategoryID FROM Products WHERE ProductName LIKE 'C%';


--Q6.Retrieve all orders placed in the year 1997. Display OrderID, CustomerID, and OrderDate.
  -- Hint: Use YEAR() function or BETWEEN with dates

	select OrderID,CustomerID,OrderDate from orders where year(orderdate)=1997

	
--Q7.Write a query to display products that are either out of stock (UnitsInStock = 0) OR have a price less than 10.
--   Show ProductName, UnitPrice, and UnitsInStock.
--   Hint: Use OR operator to combine conditions


select ProductName,UnitPrice,UnitsInStock from products where UnitsInStock=0 or UnitPrice<10


--Q8.Find all employees whose LastName is between 'D' and 'M' alphabetically. Display FirstName, LastName, and Title.
--   Hint: Use BETWEEN for alphabetical ranges

select FirstName,LastName,Title from Employees where LastName between 'D' and 'M'


--Q9.Retrieve the top 10 most expensive products. Display ProductName and UnitPrice.
--Hint: Use TOP keyword with ORDER BY

select top(10) productname,unitprice from products order by unitprice desc

--Q10.Write a query to find all orders where the ShippedDate is NULL (not yet shipped). 
--    Display OrderID, CustomerID, and OrderDate.
--    Hint: Use IS NULL to check for NULL values


select  orderid,CustomerID,OrderDate from orders where ShippedDate is null


--Q11.Write a query to display ProductName along with its CategoryName.
--    Use INNER JOIN between Products and Categories tables.
 --   Hint: JOIN on CategoryID column present in both tables


 select p.ProductName,c.categoryname from products p inner join Categories c on p.CategoryID=c.CategoryID 


--Q12. Retrieve all orders with customer information. Display OrderID, OrderDate, CompanyName, and ContactName.
--Join Orders and Customers tables. Hint: JOIN on CustomerID

select o.orderid,o.orderdate,c.companyname,c.contactname from orders o join customers c on o.CustomerID=c.CustomerID   

--Q13.Display ProductName, CompanyName (from Suppliers), and UnitPrice for all products. 
--    Use INNER JOIN between Products and Suppliers.
-- Hint: JOIN on SupplierID

select p.ProductName,s.companyname,UnitPrice from products p join Suppliers s on p.SupplierID=s.SupplierID

--Q14.Write a query to show all order details with product names. Display OrderID, ProductName, Quantity, and UnitPrice from the [Order Details] and Products tables.
--Hint: JOIN [Order Details] with Products on ProductID

SELECT od.OrderID, p.ProductName, od.Quantity, od.UnitPrice FROM OrderDetails od INNER JOIN Products p ON od.ProductID = p.ProductID;

--Q15.List all employees with their managers' names. Display EmployeeID, Employee's FirstName and LastName, and Manager's FirstName and LastName. (Use self-join on Employees table)
--Hint: Self-join using Reports To column; use LEFT JOIN to include employees without managers


SELECT e.EmployeeID, e.FirstName AS EmployeeFirstName,e.LastName AS EmployeeLastName, m.FirstName AS ManagerFirstName, m.LastName AS ManagerLastName
FROM Employees e
LEFT JOIN Employees m ON e.ReportsTo = m.EmployeeID;


--Q16.Show all customers and their orders. Include customers even if they haven't placed any orders. Display CustomerID, CompanyName, and OrderID.
--Hint: Use LEFT JOIN to include all customers

SELECT c.CustomerID, c.CompanyName, o.OrderID FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID;

--Q17.Write a query using three tables: Orders, Customers, and Employees. Display OrderID, CompanyName (customer), and the employee's full name (FirstName + LastName) who handled the order.
--Hint: Join Orders with Customers and Employees; use + or CONCAT for full name

SELECT o.OrderID,c.CompanyName,e.FirstName + ' ' + e.LastName AS EmployeeName FROM Orders o 
INNER JOIN Customers c
ON o.CustomerID = c.CustomerID
INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID;


--Q18.Find all products and their categories. Include products that don't have a category assigned (CategoryID is NULL). Display ProductName and CategoryName.
--Hint: Use LEFT JOIN to include all products

SELECT p.ProductName, c.CategoryName FROM Products p LEFT JOIN Categories c ON p.CategoryID = c.CategoryID;


--Q19.Display OrderID, ProductName, Quantity, CategoryName by joining three tables: [Order Details], Products, and Categories.
--Hint: Chain two INNER JOINS

SELECT od.OrderID,p.ProductName,od.Quantity,c.CategoryName FROM OrderDetails od
INNER JOIN Products p ON od.ProductID = p.ProductID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID;


--Q20.Write a query to show all combinations of Customers and Orders (CROSS JOIN). Limit the result to 100 rows. Display CustomerID and OrderID.
--Hint: Use CROSS JOIN and TOP to limit results


SELECT TOP 100 c.CustomerID,o.OrderID FROM Customers c CROSS JOIN Orders o;


--Q21.Find the total number of products in the Products table.
--Hint: Use COUNT(*) aggregate function

select count(*) as 'Total Number Products' from Products


--Q22.Calculate the average unit price of all products. Round to 2 decimal places.
--Hint: Use AVG() function with CAST or ROUND

select Round(AVG(unitprice),2) from Products


--Q23.Find the minimum and maximum UnitPrice from the Products table. Display both in one query.
--Hint: Use MIN() and MAX() functions

select MIN(unitprice) as minimum_Unitprice,max(unitprice) as Maximum_unitPrice from Products



--Q24.Count how many products exist in each category. Display CategoryID and the count of products.
--    Hint: Use COUNT with GROUP BY CategoryID

		SELECT CategoryID, COUNT(*) AS ProductCount FROM Products GROUP BY CategoryID;

--Q25.Show CategoryName and the number of products in each category. Join Products and Categories tables and use GROUP BY.
--    Hint: JOIN then GROUP BY CategoryName

select c.CategoryName,count(p.ProductID)  AS ProductCount from Categories c inner join Products p on c.CategoryID=p.CategoryID group by c.CategoryName

--Q26.Find the total quantity ordered for each product. Display ProductID and total quantity from [Order Details].
--    Hint: Use SUM(Quantity) with GROUP BY ProductID

SELECT ProductID, SUM(Quantity) AS TotalQuantity FROM OrderDetails GROUP BY ProductID;


--Q27.Find categories that have more than 10 products. Display CategoryName and product count.
--    Hint: Use HAVING clause after GROUP BY to filter aggregated results

SELECT c.CategoryName, COUNT(p.ProductID) AS ProductCount FROM Categories c 
INNER JOIN Products p ON c.CategoryID = p.CategoryID GROUP BY c.CategoryName HAVING COUNT(p.ProductID) > 10;


--Q28.Calculate the total sales amount for each order. Display OrderID and total amount (UnitPrice Quantity (1- Discount)) from [Order Details]. * *
--Hint: Use SUM with calculation in GROUP BY

SELECT OrderID,SUM(UnitPrice * Quantity * (1 - Discount)) AS TotalAmount FROM OrderDetails GROUP BY OrderID;


--Q29.Write an INSERT statement to add a new category to the Categories table, CategoryName = 'Organic Foods", Description = 'Certified organic products".
--    Hint: Use INSERT INTO with column names and VALUES

INSERT INTO Categories (CategoryName, Description)VALUES ('Organic Foods', 'Certified organic products');

--Q30. Insert a new product into the Products table, ProductName = 'Green Tea', SupplierID = 1, CategoryID = 1, UnitPrice = 15.00, UnitsInStock 50, Discontinued = 0.
--     Hint: Specify all required columns in INSERT

INSERT INTO Products (ProductName, SupplierID, CategoryID, UnitPrice, UnitsInStock, Discontinued)VALUES ('Green Tea', 1, 1, 15.00, 50, 0);


--Q31.Write an UPDATE statement to increase the UnitPrice of all products in CategoryID 1 by 10%.
--    Hint: Use UPDATE with SET and WHERE clause

UPDATE Products SET UnitPrice = UnitPrice * 1.10 WHERE CategoryID = 1;

--Q32.Update the phone number of the customer with CustomerID = 'ALFKI' to '030-1234567'.
--    Hint: UPDATE single row with WHERE on primary key

UPDATE Customers SET Phone = '030-1234567' WHERE CustomerID = 'ALFKI';


--Q33 Mark all products as discontinued (set Discontinued = 1) where UnitsInStock = 0.
--    Hint: UPDATE multiple rows based on a condition


UPDATE Products SET Discontinued = 1 WHERE UnitsInStock = 0;

--Q34. Delete all products that are discontinued AND have never been ordered (don't exist in [Order Details]).
--     Hint: Use DELETE with WHERE and NOT EXISTS subquery


DELETE FROM Products WHERE Discontinued = 1 AND NOT EXISTS 
(SELECT 1 FROM OrderDetails od WHERE od.ProductID = Products.ProductID);


--Q35.Write a transaction that inserts a new customer and then inserts an order for that customer. Use BEGIN TRANSACTION, COMMIT, and include error handling with TRY/CATCH.
--    Hint: Wrap INSERT statements in BEGIN TRAN COMMIT with TRY/CATCH

BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO Customers (CustomerID, CompanyName, ContactName, Phone)
    VALUES ('NEWC2', 'New Company Ltd', 'John Doe', '123-4567890');

    INSERT INTO Orders (CustomerID, OrderDate)
    VALUES ('NEWC2', GETDATE());

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT 'Error occurred: Transaction rolled back';
END CATCH;


--Q36 Find all products that have a UnitPrice greater than the average price of all products. Display ProductName and UnitPrice.
--    Hint: Use subquery with AVG() in WHERE clause
    select productname,unitprice from Products where UnitPrice>(select avg(UnitPrice) from Products)
     

--Q37.Find customers who have placed at least one order. Display CustomerID and CompanyName. Use a subquery with EXISTS.
--    Hint: Use WHERE EXISTS with correlated subquery

    SELECT CustomerID, CompanyName FROM Customers c WHERE EXISTS ( SELECT 1 FROM Orders o WHERE o.CustomerID = c.CustomerID);

--Q38. Find all products supplied by suppliers from 'Germany'. Use a subquery to get SupplierIDs first.
--     Hint Use IN with subquery

        SELECT ProductName FROM Products WHERE SupplierID IN (SELECT SupplierID FROM Suppliers WHERE Country = 'Germany');

--Q39.Write a query using a Common Table Expression (CTE) to find the average order value, then display all orders that are above this average.
--    Hint: Use WITH clause to define CTE

    WITH OrderTotals AS (
    SELECT OrderID,SUM(UnitPrice * Quantity * (1 - Discount)) AS TotalAmount
    FROM OrderDetails
    GROUP BY OrderID
    )
    SELECT *
    FROM OrderTotals
    WHERE TotalAmount > (SELECT AVG(TotalAmount) FROM OrderTotals);

--Q40.Use a CTE to calculate the number of orders per customer, then select customers who have placed more than 10 orders.
--     Hint: CTE with COUNT and GROUP BY, then filter in outer query
select * from orders


    with cal_no_orders as
    select count(orders) as NumberOfOrders,customerid from orders group by customreid) having NumberOfOrders>(select   

    WITH CustomerOrders AS 
    (SELECT CustomerID, COUNT(OrderID) AS OrderCount FROM Orders GROUP BY CustomerID )

    SELECT CustomerID, OrderCount FROM CustomerOrders WHERE OrderCount > 10;

--Q41.Find the most expensive product in each category using a correlated subquery. Display CategoryID, ProductName, and UnitPrice.
--Hint: WHERE UnitPrice = (SELECT MAX. WHERE CategoryID= outer. CategoryID)

SELECT CategoryID, ProductName, UnitPrice FROM Products p WHERE UnitPrice = ( SELECT MAX(UnitPrice) 
FROM Products WHERE CategoryID = p.CategoryID);


--Q42. Write a query to find customers who have never placed an order. Use NOT EXISTS.
--     Hint: WHERE NOT EXISTS (subquery checking Orders)

SELECT CustomerID, CompanyName FROM Customers c WHERE NOT EXISTS (SELECT 1 FROM Orders o WHERE o.CustomerID = c.CustomerID);



--Q43.Create a simple VIEW named vw_ProductList that displays ProductID, ProductName, CategoryName, 
--    and UnitPrice for all active products (not discontinued).
--    Hint: CREATE VIEW with SELECT and JOIN

create view vww_ProductList as  select p.ProductID,p.productname,c.categoryname,p.UnitPrice from products p inner join Categories c on p.CategoryID=c.CategoryID
where p.Discontinued=0


--Q44.Create a VIEW named vw_OrderSummary that shows OrderID, CustomerName (CompanyName), OrderDate, and the number of items in each order.
--    Hint: JOIN Orders, Customers, and aggregate [Order Details]


CREATE VIEW vw_OrderSummary AS
SELECT o.OrderID,c.CompanyName AS CustomerName,o.OrderDate, COUNT(od.ProductID) AS NumberOfItems FROM Orders o
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
GROUP BY o.OrderID,c.CompanyName,o.OrderDate;


--Q45.Write a stored procedure named usp_GetProductsByCategory that accepts a @CategoryID parameter and returns all products in that category.
--    Hint: CREATE PROCEDURE with parameter and SELECT

create procedure usp_GetProductsByCategory
@CategoryId int
as
BEGIN
select ProductID,ProductName,UnitPrice,CategoryID from products where CategoryID=@CategoryId 
end


--Q46.Create a stored procedure named usp_GetCustomerOrders that accepts @CustomerID as a parameter 
--    and returns all orders for that customer with order details.
--    Hint: Procedure with parameter and JOIN query

create procedure usp_GetCustomerOrders
@CustomerId int
as
BEGIN
  SELECT o.OrderID,o.OrderDate,o.RequiredDate,o.ShippedDate,od.ProductID,od.UnitPrice,od.Quantity,od.Discount
    FROM Orders o
    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
    WHERE o.CustomerID = @CustomerID
    ORDER BY o.OrderID;
end


--Q47.Write a stored procedure usp_AddCategory that accepts @CategoryName and @Description as parameters, inserts a new category, and returns the newly created CategoryID using an OUTPUT parameter.

CREATE PROCEDURE usp_AddCategory
    @CategoryName NVARCHAR(100),
    @Description NVARCHAR(255),
    @CategoryID INT OUTPUT
AS
BEGIN
    INSERT INTO Categories (CategoryName, Description)
    VALUES (@CategoryName, @Description);  
    SET @CategoryID = SCOPE_IDENTITY();
END;

DECLARE @NewCategoryID INT;

EXEC usp_AddCategory
    @CategoryName = 'Snacks',
    @Description = 'Chips and snacks items',
    @CategoryID = @NewCategoryID OUTPUT;

SELECT @NewCategoryID AS NewCategoryID;


--Q48.Create a stored procedure usp_UpdateProductPrice that accepts @ProductID 
--    and @NewPrice, validates that @NewPrice is greater than 0, and updates the product's price. Use RAISERROR for validation.
 --   Hint: Add IF condition to check price, use RAISERROR for errors
    
    CREATE PROCEDURE usp_UpdateProductPrice
    @ProductID INT,
    @NewPrice DECIMAL(10,2)
AS
BEGIN

    IF @NewPrice <= 0
    BEGIN
        RAISERROR ('Price must be greater than 0.', 16, 1);
        RETURN;
    END;


    UPDATE Products
    SET UnitPrice = @NewPrice
    WHERE ProductID = @ProductID;

END;


--Q49.Write a stored procedure usp_GetEmployeeSales that shows total sales handled by each employee. Return EmployeeID, FullName (FirstName + LastName), and TotalSales amount.
--    Hint: JOIN Orders with Employees and aggregate [Order Details]
CREATE PROCEDURE usp_GetEmployeeSales
AS
BEGIN
    SELECT e.EmployeeID,e.FirstName + ' ' + e.LastName AS FullName,SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalSales
    FROM Employees e
    INNER JOIN Orders o ON e.EmployeeID = o.EmployeeID
    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
    GROUP BY e.EmployeeID,e.FirstName,e.LastName
    ORDER BY TotalSales DESC;
END;

exec usp_GetEmployeeSales



--Q50,Create a stored procedure usp_GetMonthlyOrderStats that accepts @Year and @Month as parameters and returns the total number of orders and total revenue for that month.
--    Hint: Filter by YEAR() and MONTH() functions, use COUNT and SUM

CREATE PROCEDURE usp_GetMonthlyOrderStats
    @Year INT,
    @Month INT
AS
BEGIN
    SELECT COUNT(DISTINCT o.OrderID) AS TotalOrders,SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalRevenue
    FROM Orders o
    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
    WHERE YEAR(o.OrderDate) = @Year AND MONTH(o.OrderDate) = @Month;
END;