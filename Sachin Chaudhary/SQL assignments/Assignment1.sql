select* from categories
select* from CustomerCustomerDemo
select* from Customers
select* from Employees
select* from EmployeeTerritories
select* from [Order Details]
select* from Orders
select* from region
select* from Shippers
select* from suppliers
select* from Territories
select* from Products


--q1
SELECT CategoryName FROM categories
--q2
SELECT ContactName, CustomerID, CompanyName
FROM Customers
WHERE City = 'London';
--q3
SELECT Fax FROM suppliers WHERE Fax is not null
--q4
SELECT CustomerID FROM Orders WHERE RequiredDate BETWEEN '1997-01-01' AND '1998-01-01' AND Freight < 100;
--q5

SELECT CompanyName ,ContactName from customers WHERE Country IN('MAXICO', 'SWEDEN', 'GERMANY')

--q6
select count(*) from Products where Discontinued=1;
select count(*) from Products where Discontinued=0;

--q7
select CategoryName,Description from categories where categoryname  LIKE 'co%';

--q8
select  CompanyName,City,Country,PostalCode from Suppliers Where Address LIKE '%rue%' order by companyname asc;

--q9
select ProductID ,sum(Quantity) as TotalQuantity from [Order Details] group by ProductID;

--q10
select * FROM Customers;
SELECT * FROM Orders;
select * FROM Shippers;

SELECT  c.CompanyName, c.Address
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN Shippers s ON o.ShipVia = s.ShipperID
WHERE s.CompanyName = 'Speedy Express';

--q11
select * FROM Suppliers;
select companyname,ContactName,contacttitle,region from Suppliers;

--q12
select* from products
select* from Categories
SELECT p.ProductName
FROM Products p
INNER JOIN Categories c 
ON p.CategoryID = c.CategoryID
WHERE c.CategoryName = 'Condiments';

--q13
SELECT c.ContactName
FROM Customers c
LEFT JOIN Orders o 
ON c.CustomerID = o.CustomerID
WHERE o.CustomerID IS NULL;

--q14
select* from shippers
ALTER TABLE shippers
ADD ShipperName varchar(50);
INSERT INTO shippers (CompanyName)
VALUES ('Amazon');

--q15
UPDATE Shippers
SET CompanyName = 'Amazon Prime Shipping'
WHERE CompanyName = 'Amazon';

--q16
SELECT 
    S.CompanyName,
    ROUND(SUM(O.Freight), 0) AS TotalFreight
FROM Shippers S
JOIN Orders O 
    ON S.ShipperID = O.ShipVia
GROUP BY S.CompanyName;



--q17
SELECT LastName + ', ' + FirstName AS DisplayName
FROM Employees;


--q18
DECLARE @CustID VARCHAR(5) = 's1';
DECLARE @OrderID INT;


IF NOT EXISTS (SELECT 1 FROM Customers WHERE CustomerID = @CustID)
BEGIN
    INSERT INTO Customers (CustomerID, CompanyName, ContactName, Country)
    VALUES (@CustID, 'sachin Pvt Ltd', 'sachins', 'India');
END;

INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, ShipVia)
VALUES (@CustID, 1, GETDATE(), 1);


SET @OrderID = SCOPE_IDENTITY();

INSERT INTO OrderDetails (OrderID, ProductID, UnitPrice, Quantity)
SELECT 
    @OrderID,
    ProductID,
    UnitPrice,
    1
FROM Products
WHERE ProductName = 'Grandma''s Boysenberry Spread';

--q19
DELETE FROM OrderDetails
WHERE OrderID IN (
    SELECT OrderID 
    FROM Orders 
    WHERE CustomerID = 'S1'
);

DELETE FROM Orders
WHERE CustomerID = 'S1';
DELETE FROM Customers
WHERE CustomerID = 'S1';


--q20
SELECT ProductName,
UnitsInStock AS TotalUnits
FROM Products
WHERE UnitsInStock > 100;