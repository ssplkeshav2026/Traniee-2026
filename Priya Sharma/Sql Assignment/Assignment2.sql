-- 1 --

Select CategoryName , Description
from Categories
ORDER BY CategoryName

-- 2 --

Select ContactName, CompanyName , ContactTitle , Phone
from Customers
ORDER BY Phone

-- 3 --

Select 
    UPPER(FirstName) AS FirstName,
    UPPER(LastName) AS LastName,
    HireDate
from employees
ORDER BY HireDate DESC;

-- 4 --

Select TOP 10
    OrderID, 
    OrderDate, 
    ShippedDate, 
    CustomerID, 
    Freight
from Orders
ORDER BY Freight;

-- 5 --

Select LOWER(CustomerID) AS ID
from Customers

-- 6 --

Select 
    CompanyName,
    Fax,
    Phone,
    Country, 
    HomePage
From Suppliers
ORDER BY
     Country DESC,
     CompanyName ASC;

-- 7 --

Select CompanyName , ContactName 
from Customers
Where City = 'Buenos Aires'

-- 8 --

Select ProductName, UnitPrice, QuantityPerUnit 
from Products
Where UnitsInStock = 0

-- 9 --

Select ContactName,Address,City
From Customers
WHERE Country NOT IN ('Germany','Mexico','Spain');

-- 10 --

Select OrderDate, ShippedDate, CustomerID, Freight
from Orders
WHERE OrderDate = '1996-05-21'

-- 11 --

Select FirstName , LastName , Country
from Employees
WHERE Country != 'USA';

-- 12 --

Select 
    EmployeeID, 
    OrderID, 
    CustomerID, 
    RequiredDate, 
    ShippedDate
From Orders
WHERE ShippedDate > RequiredDate

-- 13 --

Select  City, CompanyName, ContactName
From Customers
WHERE City Like '[A,B]%'

-- 14 -- 

Select OrderID from Orders
Where OrderID % 2 = 0;

-- 15 --

Select Freight from Orders 
Where Freight > $500

-- 16 --

Select 
     ProductName, 
     UnitsInStock, 
     UnitsOnOrder,
     ReorderLevel 
from Products
WHERE UnitsInStock + UnitsOnOrder <= ReorderLevel;


-- 17 -- 

Select CompanyName,ContactName 
from Customers
Where Fax IS NULL

-- 18 --

Select FirstName , LastName 
from Employees
Where ReportsTo IS NUll

-- 19 -- 
   
Select OrderID from Orders
Where OrderID % 2 != 0;

-- 20 --

Select CompanyName, ContactName, Fax 
from Customers
Where Fax IS NULL
ORDER BY ContactName

-- 21 --

Select City, CompanyName, ContactName 
from Customers
WHERE City LIKE '%L%'
ORDER BY ContactName

-- 22 --

Select  FirstName, LastName, BirthDate 
from Employees
WHERE BirthDate >= '1950-01-01' AND
      BirthDate < '1960-01-01';

-- 23 --

SELECT FirstName, LastName,YEAR(BirthDate) AS [Birth Year]
FROM Employees;

-- 24 --

Select OrderID, COUNT(OrderID) AS NumberofOrders
From [Order Details]
GROUP BY OrderID
ORDER BY NumberofOrders DESC;

-- 25 -- 

Select p.SupplierID, ProductName, CompanyName
From Products p
INNER JOIN Suppliers s
    ON p.SupplierID = s.SupplierID
WHERE CompanyName IN ('Exotic Liquids', 'Specialty Biscuits, Ltd.', 'Escargots Nouveaux')
ORDER BY SupplierID;

-- 26 --

Select ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress
from Orders
WHERE ShipPostalCode LIKE '98124%';

-- 27 --

Select ContactName, ContactTitle, CompanyName 
from Customers
WHERE ContactTitle NOT LIKE '%Sales%'

-- 28 --

Select LastName, FirstName, City 
from Employees
WHERE  City NOT LIKE 'Seattle'

-- 29 --

Select CompanyName, ContactTitle, City, Country
from Customers
WHERE Country = 'Mexico'
   OR (Country = 'Spain' AND City != 'Madrid');

-- 30 --

Select CONCAT(FirstName,' ',LastName, ' can be reached at x',Extension) AS Contactinfo 
from Employees

-- 31 -- 

Select ContactName from Customers 
WHERE ContactName NOT LIKE '_A%'

-- 32 --

Select
    CEILING(AVG(UnitPrice)) AS AveragePrice,
    SUM(UnitsInStock * UnitPrice) AS TotalStock,
    MAX(UnitsOnOrder) AS MaxOrder
from Products;

-- 33 -- 

Select
    p.SupplierID, CompanyName, CategoryName, ProductName, UnitPrice
From Products p
INNER JOIN Suppliers s
    ON p.SupplierID = s.SupplierID
INNER JOIN Categories c
    ON p.CategoryID = c.CategoryID;

-- 34 --

Select CustomerID, SUM(Freight) AS TotalFreight
from Orders
GROUP BY CustomerID
HAVING SUM(Freight) > 200;

-- 35 --

Select od.OrderID, ContactName, UnitPrice, Quantity, Discount
from [Order Details] od
INNER JOIN Orders o
  ON od.OrderID = o.OrderID
INNER JOIN Customers c
  ON o.CustomerID = c.CustomerID
WHERE Discount > 0;

-- 36 --

Select e.EmployeeID, 
    e.LastName + ' ' + e.FirstName AS Employee,
    m.LastName + ' ' + m.FirstName AS Manager
from Employees e
LEFT JOIN Employees m ON e.ReportsTo = m.EmployeeID
ORDER BY EmployeeID;

-- 37 --

Select 
    AVG(UnitPrice) AS AveragePrice,
    MIN(UnitPrice) AS MinimumPrice,
    MAX(UnitPrice) AS MaximumPrice
from Products

-- 38 --
GO
CREATE VIEW Customerinfo AS
Select
    c.CustomerID,
    c.CompanyName,
    c.ContactName,
    c.ContactTitle,
    c.Address,
    c.City,
    c.Country,
    c.Phone,
    o.OrderDate,
    o.RequiredDate,
    o.ShippedDate
From Customers c
INNER JOIN Orders o
    ON c.CustomerID = o.CustomerID;

-- 39 --

EXEC sp_rename 'Customerinfo' , 'CustomerDetails';

-- 40 --

GO
CREATE VIEW ProductDetails AS
Select
    p.ProductID,
    s.CompanyName,
    p.ProductName,
    c.CategoryName,
    c.Description,
    p.QuantityPerUnit,
    p.UnitPrice,
    p.UnitsInStock,
    p.UnitsOnOrder,
    p.ReorderLevel,
    p.Discontinued
from Products p
INNER JOIN Suppliers s  ON p.SupplierID = s.SupplierID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID;

-- 41 --

DROP VIEW CustomerDetails;

-- 42 --

Select LEFT(CategoryName, 5) AS ShortInfo
from Categories;

-- 43 --

Select * into ShippersDuplicate from Shippers;

-- 44 --

ALTER TABLE ShippersDuplicate 
add Email nvarchar(80);


Select * from ShippersDuplicate
UPDATE ShippersDuplicate
SET Email = 'speedyexpress@gmail.com'
WHERE ShipperID = 1;

UPDATE ShippersDuplicate
SET Email = 'unitedpackage@gmail.com'
WHERE ShipperID = 2;

UPDATE ShippersDuplicate
SET Email = 'federalshipping@gmail.com'
WHERE ShipperID = 3;

-- 45 --

Select CompanyName, ProductName
FROM Products p
INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE CategoryName = 'Seafood';

-- 46 --

Select CategoryID, CompanyName,ProductName
FROM Products p
LEFT JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE CategoryID = 5;

-- 47 --

DROP table ShippersDuplicate

-- 48 --

SELECT LastName, FirstName, Title,
    CAST(DATEDIFF(YEAR, BirthDate, GETDATE()) AS nvarchar) + ' Years' AS Age
FROM Employees;

-- 49 --

Select CompanyName, COUNT(o.OrderID) AS [Number of Orders]
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE OrderDate > '1994-12-31'
GROUP BY CompanyName
HAVING COUNT(OrderID) > 10;

-- 50 --

Select CONCAT(ProductName, ' weighs/is ' , QuantityPerUnit, ' and cost $' + CAST(UnitPrice AS VARCHAR)) AS ProductInfo
from Products;

