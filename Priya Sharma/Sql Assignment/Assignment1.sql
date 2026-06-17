-- 1 --
Select CategoryName , Description 
from Categories

-- 2 --
Select ContactName , CustomerID , CompanyName ,City
from Customers
Where City = 'London'

-- 3 --
Select * from Suppliers
Where Fax IS NOT NULL

-- 4 --
Select CustomerID 
from Orders

-- 5 --
Select CompanyName , ContactName
from Customers
Where  ContactTitle = 'Owner'
AND Country IN ('Mexico', 'Sweden', 'Germany')

-- 6 --

Select COUNT(*) AS DiscontinuedProducts
from Products
Where Discontinued = 1

-- 7 --
Select CategoryName , description 
from Categories 
where CategoryName like 'CO%'

-- 8 --

Select CompanyName , City,Country , PostalCode
from Suppliers
Where Address like 'rue%'

-- 9 --

Select ProductID, SUM(Quantity) AS TotalQuantityOrdered
From [Order Details]
GROUP BY ProductID

-- 10 --

Select DISTINCT c.CustomerID,Address
From Customers c
INNER JOIN Orders o 
ON c.CustomerID = o.CustomerID
INNER JOIN Shippers s 
ON ShipVia = ShipperID
Where s.CompanyName = 'Speedy Express';

-- 11 --

Select CompanyName , ContactName , ContactTitle , Region
from Suppliers
Where Region IS NOT NULL

-- 12 --

Select ProductName
from Products p
INNER JOIN Categories c
on p.CategoryID = c.CategoryID
where c.CategoryName = 'Condiments';

-- 13 --
-- CustomerID because there is no CustomerName

Select CustomerID From Customers
Where CustomerID NOT IN (
    Select CustomerID From Orders
);

-- 14 --

INSERT INTO Shippers (CompanyName)
VALUES ('Amazon');

-- 15 --

UPDATE Shippers
SET CompanyName = 'Amazon Prime Shipping'
WHERE CompanyName = 'Amazon';

-- 16 --

SELECT CompanyName,
ROUND(SUM(Freight), 0) AS TotalFreight
FROM Shippers 
INNER JOIN Orders 
ON ShipperID = ShipVia
GROUP BY CompanyName;

-- 17 --

Select LastName +','+ FirstName AS DisplayName
from Employees

-- 18 --

DECLARE @CustomerID nvarchar(10) = 'PRIYA';
DECLARE @OrderID INT;
DECLARE @ProductID INT;

INSERT INTO Customers (CustomerID, CompanyName)
VALUES (@CustomerID, 'Priya');

Select @ProductID = ProductID
From Products
Where ProductName = 'Grandma''s Boysenberry Spread';

INSERT INTO Orders (CustomerID)
VALUES (@CustomerID);

SET @OrderID = SCOPE_IDENTITY();

INSERT INTO [Order Details] (OrderID, ProductID)
VALUES (@OrderID, @ProductID);

-- 19 --

DELETE From [Order Details]
Where OrderID IN (
    Select OrderID
    From Orders
    Where CustomerID = 'Priya'
);

DELETE From Orders
Where CustomerID = 'Priya';

DELETE From Customers
Where CustomerID = 'Priya';

-- 20 --

Select ProductName,UnitsInStock AS TotalUnits
From Products
Where UnitsInStock > 100;




 

