-- Basic Select & Filtering
-- 1 --

Select * from Products

-- 2 --

Select ProductName, UnitPrice, UnitsInStock
from Products
WHERE Discontinued = 0

-- 3 --

Select ProductName , UnitPrice
from Products
WHERE UnitPrice > 50
ORDER BY UnitPrice DESC

-- 4 --

Select CustomerID, CompanyName, Country
from Customers
WHERE Country IN ('Germany', 'USA', 'France')


-- 5 --

Select ProductName , CategoryID
from Products 
WHERE ProductName LIKE 'C%' 

-- 6 --

--Using BETWEEN
Select OrderID, CustomerID, OrderDate
from Orders
WHERE OrderDate BETWEEN ('1997-01-01')AND('1997-12-31')

--Using YEAR()
Select OrderID, CustomerID, OrderDate
from Orders
WHERE  YEAR(OrderDate) = 1997

-- 7 --

Select PRoductName, UnitPrice, UnitsInStock
from Products
WHERE UnitsInStock = 0 OR UnitPrice < 10

-- 8 --

Select FirstName, LastName, Title
from Employees
WHERE LastName  BETWEEN 'D' AND 'M'

-- 9 --

Select TOP 10 ProductName, UnitPrice
from Products
ORDER BY UnitPrice DESC

-- 10 --

Select OrderID, CustomerID, OrderDate
from Orders
WHERE ShippedDate IS NULL


-- Joins & Relationship
-- 11 --

Select ProductName, CategoryName
from Products p
INNER JOIN Categories c 
ON p.CategoryID = c.CategoryID 

-- 12 -- 

Select OrderID, OrderDate, CompanyName, ContactName
FROM Orders O
JOIN Customers C
ON O.CustomerID = C.CustomerID;

-- 13 --

Select ProductName, s.CompanyName, p.UnitPrice
from Suppliers s
INNER JOIN Products p
ON s.SupplierID = p.SupplierID

-- 14 --

Select OrderID, ProductName, Quantity, p.UnitPrice
from [Order Details] od
JOIN Products p
ON p.ProductID = od.ProductID


-- 15 --

Select e.EmployeeID AS Emp_ID,
e.FirstName AS Emp_FirstName,
e.LastName AS Emp_LastName,
m.FirstName AS ManagerFirstName,
m.LastName AS ManagerLastName
from Employees e
LEFT JOIN Employees m
ON e.ReportsTo = m.EmployeeID;

-- 16 --

Select c.CustomerID,CompanyName,OrderID
from Customers c
LEFT JOIN Orders o
ON c.CustomerID = o.CustomerID

-- 17 --

Select OrderID, c.CompanyName,CONCAT(FirstName,' ',LastName) AS Emp_FullName
from Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Employees e ON o.EmployeeID = e.EmployeeID

-- 18 --

Select ProductName, CategoryName
from Categories c
LEFT JOIN Products p ON  c.CategoryID = p.CategoryID
WHERE p.CategoryID IS NULL

-- 19 --

Select od.OrderID, p.ProductName, od.Quantity, c.CategoryName
from [Order Details] od
INNER JOIN Products p ON od.ProductID = p.ProductID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID

-- 20 --

SELECT TOP 100 c.CustomerID, o.OrderID
FROM Customers c
CROSS JOIN Orders o;

-- Aggregate functions & GROUP BY
-- 21 --

Select COUNT(*) As TotalNumberOfProducts
from Products

-- 22 --

Select ROUND(AVG(UnitPrice),2) AS AVERAGE
from Products

-- 23 --

Select 
     MIN(UnitPrice) AS MinimumPrice,
     MAX(UnitPrice) AS MaximunPrice
from Products

-- 24 -- 

Select CategoryID,COUNT(ProductName) AS TotalProducts
from Products
GROUP BY CategoryID

-- 25 --

Select CategoryName, COUNT(ProductName) AS Total
from Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY CategoryName

-- 26 --

Select ProductID, SUM(Quantity) AS Total_Quantity
from [Order Details]
GROUP BY ProductID

-- 27 --

Select CategoryName, COUNT(ProductID) AS ProductCount
from Categories c
JOIN Products p ON c.CategoryID = p.CategoryID
GROUP BY CategoryName
HAVING COUNT(ProductID) > 10;

-- 28 --

Select OrderID , SUM(UnitPrice * Quantity * (1-Discount)) AS TotalSales
from [Order Details]
GROUP BY OrderID


-- Data Manipulation
-- 29 --

INSERT INTO Categories (CategoryName, Description)
VALUES ('Organic Foods', 'Certified organic products');

-- 30 --

INSERT INTO Products(ProductName,SupplierID,CategoryID,UnitPrice,UnitsINStock,Discontinued)
VALUES('Green Tea',1,1,'15.00',50,0)

-- 31 --

UPDATE Products
SET UnitPrice = UnitPrice * 1.10
WHERE CategoryID = 1;

-- 32 --

UPDATE Customers 
SET Phone = '030-1234567'
WHERE CustomerID = 'ALFKI';

-- 33 --

UPDATE Products
SET Discontinued = 1
WHERE UnitsInStock = 0

-- 34 --

Delete from Products
WHERE Discontinued = 1
AND NOT EXISTS (
    Select 1 
    from [Order Details] 
    WHERE [Order Details].ProductID = Products.ProductID);

-- 35 --

BEGIN TRY
    BEGIN TRANSACTION;  
    INSERT INTO Customers (CustomerID, CompanyName, ContactName)
    VALUES ('P1001', 'Priya Sharma', 'Priya');

    INSERT INTO Orders (CustomerID, OrderDate)
    VALUES ('P1001', GETDATE());

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
    PRINT 'Error occurred: ' + ERROR_MESSAGE();
END CATCH;

-- Subqueries & CTEs
-- 36 --

Select ProductName, UnitPrice
from Products
WHERE UnitPrice > 
(Select AVG(UnitPrice) from Products);

-- 37 --

Select CustomerID, CompanyName
from Customers c
WHERE EXISTS (
Select 1 
from Orders o 
WHERE o.CustomerID = c.CustomerID);

-- 38 --

Select * from Products
WHERE SupplierID IN (
Select SupplierID 
from Suppliers 
WHERE Country = 'Germany');

-- 39 --

WITH OrderTotals AS (
    Select o.OrderID,
    SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS OrderValue
    from Orders o
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY o.OrderID
),
AvgValue AS (
    Select AVG(OrderValue) AS AvgOrderValue
    from OrderTotals
)
Select ot.OrderID, ot.OrderValue
from OrderTotals ot
CROSS JOIN AvgValue av
WHERE ot.OrderValue > av.AvgOrderValue
ORDER BY ot.OrderValue DESC;

-- 40 --

WITH OrderPerCustomer AS (
    Select CustomerID, COUNT(OrderID) as OrderCount
    from Orders
    GROUP BY CustomerID
)
Select CustomerID, OrderCount
from OrderPerCustomer
WHERE OrderCount > 10;

-- 41 --

Select CategoryID, ProductName, UnitPrice
from Products p
WHERE UnitPrice= (
Select MAX(UnitPrice)
from Products p1
WHERE p1.CategoryID = p.CategoryID);

-- 42 --

Select * from Customers c
WHERE NOT EXISTS (
Select 1 
from Orders o 
WHERE o.CustomerID = c.CustomerID);


-- Views & Stored Procedures
-- 43 --

CREATE VIEW vw_ProductList AS
Select ProductID, ProductName, CategoryName, UnitPrice
from Products p
JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE Discontinued = 0;

-- 44 --

CREATE VIEW vw_OrderSummary AS 
Select o.OrderID, CompanyName, o.OrderDate, COUNT(od.ProductID) AS NumberOfItem
from Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.OrderID, c.CompanyName, o.OrderDate

-- 45 --

CREATE PROCEDURE usp_GetProductsByCategory
    @CategoryID INT
AS
BEGIN
    Select * from Products
    WHERE CategoryID = @CategoryID;
END;

EXEC usp_GetProductsByCategory @CategoryID = 1;

-- 46 --

CREATE PROCEDURE usp_GetCustomerOrders
    @CustomerID NCHAR(5)
AS
BEGIN
    Select o.OrderID, OrderDate, ProductID, UnitPrice, Quantity
    from Orders o
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE o.CustomerID = @CustomerID;
END;

-- 47 --

CREATE PROCEDURE usp_AddCategory
    @CategoryName nvarchar(15),
    @Description ntext,
    @CategoryID INT OUTPUT
AS
BEGIN
    INSERT INTO Categories (CategoryName, Description)
    VALUES (@CategoryName, @Description);
    
    SET @CategoryID = SCOPE_IDENTITY();
END;

-- 48 --

CREATE PROCEDURE usp_UpdateProductPrice
    @ProductID INT,
    @NewPrice MONEY
AS
BEGIN
    IF @NewPrice <= 0
    BEGIN
        RAISERROR('The new price must be greater than zero.', 16, 1);
        RETURN;
    END

    UPDATE Products
    SET UnitPrice = @NewPrice
    WHERE ProductID = @ProductID;
END;

-- 49 --

CREATE PROCEDURE usp_GetEmployeeSales
AS
BEGIN
    Select e.EmployeeID, (e.FirstName + ' ' + e.LastName) AS FullName,
        SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalSales
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY e.EmployeeID, e.FirstName,e.LastName
    ORDER BY TotalSales DESC;
END;

-- 50 --

CREATE PROCEDURE usp_GetMonthlyOrderStats
    @Year INT,
    @Month INT
AS
BEGIN
    Select COUNT(DISTINCT o.OrderID) AS TotalOrders,
        SUM(od.UnitPrice * od.Quantity * (1 - od.Discount)) AS TotalRevenue
    from Orders o
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE YEAR(o.OrderDate) = @Year AND MONTH(o.OrderDate) = @Month;
END;

--- Completed ---