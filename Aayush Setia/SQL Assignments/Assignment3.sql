--1--
SELECT * FROM Products;
--2--
SELECT ProductName,UnitPrice,UnitsInStock
FROM Products
WHERE Discontinued = 0;
--3--
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice > 50
ORDER BY UnitPrice DESC;
--4--
SELECT CustomerID, CompanyName, Country
FROM Customers
WHERE Country IN ('Germany', 'USA', 'France');
--5--
SELECT ProductName, CategoryID
FROM Products
WHERE ProductName LIKE 'C%';

--6--
SELECT OrderID, CustomerID, OrderDate
FROM Orders
WHERE YEAR(OrderDate) = 1997;
--7--
SELECT ProductName, UnitPrice, UnitsInStock
FROM Products
WHERE UnitsInStock = 0 OR UnitPrice < 10;
--8--
SELECT FirstName, LastName, Title
FROM Employees
WHERE LastName BETWEEN 'D' AND 'M'
ORDER BY LastName;
--9--
SELECT TOP 10 ProductName, UnitPrice
FROM Products
ORDER BY UnitPrice DESC;
--10--
SELECT OrderID, CustomerID, OrderDate
FROM Orders
WHERE ShippedDate IS NULL;
--11--
SELECT ProductName, CategoryName
FROM Products
INNER JOIN Categories
ON Products.CategoryID = Categories.CategoryID;
--12--
SELECT Orders.OrderID, Orders.OrderDate, Customers.CompanyName, Customers.ContactName
FROM Orders
INNER JOIN Customers
ON Orders.CustomerID = Customers.CustomerID;
--13--
SELECT Products.ProductName, Suppliers.CompanyName, Products.UnitPrice
FROM Products
INNER JOIN Suppliers
ON Products.SupplierID = Suppliers.SupplierID;
--14--
SELECT od.OrderID, Products.ProductName, od.Quantity, od.UnitPrice
FROM [Order Details] as od
INNER JOIN Products
ON od.ProductID = Products.ProductID;
--15--
SELECT E.EmployeeID, E.FirstName, E.LastName,M.FirstName AS ManagerFirstName,M.LastName AS ManagerLastName
FROM Employees E
LEFT JOIN Employees M ON E.ReportsTo = M.EmployeeID;
--16--
SELECT C.CustomerID, C.CompanyName, Orders.OrderID
FROM Customers as  c
LEFT JOIN Orders ON C.CustomerID = Orders.CustomerID;
--17--
SELECT c.CustomerID, C.CompanyName, O.OrderID
from Customers as c
LEFT JOIN Orders as o on c.CustomerID = o.CustomerID;
--18--
SELECT p.ProductName,  c.Categoryname
FROM Products as p
LEFT JOIN Categories as c
on p.CategoryID = c.CategoryID;
--19--
Select od.OrderID, od.Quantity, p.ProductName, c.categoryName
from [Order Details] as od
INNER JOIN Products as p 
on od.ProductID = p.ProductID
INNER JOIN Categories as c
on c.CategoryID = p.CategoryID;
--20--
SELECT top 100 c.CustomerID,o.OrderID
FROM Customers as c
cross join orders as o;
--21--
SELECT count(*) FROM Products;
--22--
SELECT ROUND(avg(unitprice),2)
from products;
--23--
SELECT CategoryID, COUNT(*) FROM Products
GROUP BY CategoryID;
--24--
SELECT MIN(UnitPrice) as MinPrice,
MAX( UnitPrice ) as MaxPrice
from products;
--25--
SELECT c.categoryName, count(p.productID) as ProductCount
FROM Categories as c
JOIN products as p ON
c.CategoryID=p.CategoryID
GROUP BY CategoryName; 
--26--
SELECT ProductID , sum(quantity)as totalquantity
from [Order Details]
GROUP BY ProductID
--27--
select c.categoryname,count(p.productID) as productcount
from Categories as c
JOIN products as p ON p.categoryID= c.CategoryID
group by c.CategoryName having count(p.productID) >10;
--28--
SELECT OrderID,sum(UnitPrice*Quantity*(1-Discount)) as DiscountPrice
from[Order Details]
GROUP BY OrderID;
--29--
INSERT INTO Categories(CategoryName,Description) Values ('organic foods','certified organic products');
--30--
INSERT INTO Products(ProductName,SupplierID,CategoryID,UnitPrice,UnitsInStock,Discontinued) Values('Green Tea','1','1','15.00','50','0');
--31--
UPDATE Products set Unitprice = unitprice*1.10
Where CategoryID=1;
--32--
UPDATE Customers set Phone = '030-1234567'
where CustomerID = 'ALFKI';
--33-- 
update products set Discontinued=1
where UnitsInStock=0;
--34--
DELETE FROM Products
WHERE Discontinued = 1
AND ProductID NOT IN (SELECT distinct ProductID  FROM [Order Details]);
--35---
BEGIN TRY
BEGIN TRANSACTION;
INSERT INTO Customers (CustomerID, CompanyName, ContactName, Phone)VALUES ('AYUSE', 'AayushSetia Pvt ltd', 'Aayush Setia', '0879-02314');
INSERT INTO Orders (CustomerID, OrderDate)VALUES ('AHJTY', GETDATE());
COMMIT TRANSACTION;
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION;
PRINT ERROR_MESSAGE();
END CATCH;
--36--
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);
--37--
SELECT CustomerID, CompanyName
FROM Customers c
WHERE EXISTS ( SELECT 1  FROM Orders o 
    WHERE o.CustomerID = c.CustomerID);
--38--
SELECT *FROM Products
WHERE SupplierID IN ( SELECT SupplierID 
    FROM Suppliers WHERE Country = 'Germany');
--39--
 WITH AvgValueCTE AS (
 SELECT AVG(OrderValue) AS OverallAverage
 FROM Orders)SELECT *FROM Orders, AvgValueCTE
WHERE Orders.OrderValue > AvgValueCTE.OverallAverage;
--40--
WITH CustomerOrderCounts AS (
    SELECT CustomerID, COUNT(OrderID) AS TotalOrders
    FROM Orders
    GROUP BY CustomerID)
SELECT CustomerID, TotalOrders
FROM CustomerOrderCounts
WHERE TotalOrders > 10;
--41--
SELECT CategoryID, ProductName, UnitPrice
FROM Products AS OuterTable
WHERE UnitPrice = (
    SELECT MAX(UnitPrice)
    FROM Products AS InnerTable
    WHERE InnerTable.CategoryID = OuterTable.CategoryID);
--42--
SELECT c.customerid,c.CompanyName
FROM Customers c
WHERE NOT EXISTS (
    SELECT 1 
    FROM Orders o 
    WHERE o.customerid = c.customerid);
--43--
CREATE VIEW vw_ProductList AS
SELECT 
    p.ProductID, 
    p.ProductName, 
    c.CategoryName, 
    p.UnitPrice
FROM Products p
JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE p.Discontinued = 0;
--44--
CREATE VIEW vw_OrderSummary AS
SELECT  o.OrderID,c.CompanyName AS CustomerName, o.OrderDate, 
    COUNT(od.OrderID) AS NumberOfItems
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY o.OrderID, c.CompanyName, o.OrderDate;
--45--
CREATE PROCEDURE usp_GetProductsByCategory
    @CategoryID INT
AS
BEGIN
    SELECT * 
    FROM Products 
    WHERE CategoryID = @CategoryID;
END;
--46--
CREATE PROCEDURE usp_GetCustomerOrders
    @CustomerID NCHAR(5)
AS
BEGIN
    SELECT   o.OrderID, o.OrderDate, od.ProductID, od.UnitPrice, od.Quantity, od.Discount
    FROM Orders o
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    WHERE o.CustomerID = @CustomerID;
END;
--47--
CREATE PROCEDURE usp_AddCategory
    @CategoryName NVARCHAR(50),
    @Description NVARCHAR(MAX),
    @CategoryID INT OUTPUT 
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Categories (CategoryName, Description)VALUES (@CategoryName, @Description);

  
    SET @CategoryID = SCOPE_IDENTITY();
END;
---48---

CREATE PROCEDURE usp_UpdateProductPrice
    @ProductID INT,
    @NewPrice DECIMAL(10, 2)
AS
BEGIN
    
    IF @NewPrice <= 0
    BEGIN
        RAISERROR('The new price must be greater than 0.', 16, 1);
    END
    ELSE
    BEGIN
     
        UPDATE Products SET Price = @NewPrice WHERE ProductID = @ProductID;
        
        PRINT 'Product price updated successfully.';
    END
END;
--49--

CREATE PROCEDURE usp_GetEmployeeSales
AS
BEGIN
    SELECT 
        E.EmployeeID,E.FirstName + ' ' + E.LastName AS FullName,
        SUM(OD.Quantity * OD.UnitPrice) AS TotalSales
    FROM Employees AS E
    INNER JOIN Orders AS O ON E.EmployeeID = O.EmployeeID
    INNER JOIN [Order Details] AS OD ON O.OrderID = OD.OrderID
    GROUP BY E.EmployeeID,   E.FirstName, E.LastName;
END;

