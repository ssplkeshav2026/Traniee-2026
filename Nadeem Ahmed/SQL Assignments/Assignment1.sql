USE Assignment1;

--1 Select all category names with their descriptions from the Categories table. --
SELECT CategoryName, description FROM Categories;

--2 Select the contact name, customer id, and company name of all Customers in London --
SELECT ContactName, CustomerID, CompanyName FROM Customers WHERE City = 'London';

--3 Marketing managers and sales representatives have asked you to select all available columns in the Suppliers tables that have a FAX number. --
SELECT * FROM Suppliers WHERE Fax IS NOT NULL;

--4 Select a list of customers id’s from the Orders table with required dates between Jan 1, 1997 and Jan 1, 1998 and with freight under 100 units. --
SELECT DISTINCT CustomerID FROM Orders WHERE RequiredDate BETWEEN '01-01-1997' AND '01-01-1998' AND Freight <100;

--5 Select a list of company names and contact names of all the Owners from the Customer table from Mexico, Sweden and Germany. --
SELECT CompanyName, ContactName FROM Customers WHERE Country IN ('Mexico', 'Sweden', 'Germany') AND ContactTitle = 'Owner';

--6 Count the number of discontinued products in the Products table. --
SELECT COUNT(Discontinued) FROM Products;

--7 Select a list of category names and descriptions of all categories beginning with 'Co' from the Categories table. --
SELECT CategoryName, Description FROM Categories WHERE CategoryName LIKE 'Co%';

--8 Select all the company names, city, country and postal code from the Suppliers table with the word 'rue' in their address. The list should be ordered alphabetically by company name. --
SELECT CompanyName, City, Country, PostalCode FROM Suppliers WHERE Address LIKE '%rue%' ORDER BY CompanyName ASC;

--9 Select the product id and the total quantities ordered for each product id in the Order Details table. --
SELECT ProductID,sum(quantity) AS TotalQuantity FROM OrderDetails GROUP BY ProductID;

--10 Select the customer name and customer address of all customers with orders that shipped using Speedy Express --
SELECT DISTINCT c.ContactName, c.Address, s.CompanyName FROM Customers c
 INNER JOIN Orders o ON c.CustomerID = o.CustomerID
 INNER JOIN Shippers s ON o.ShipVia = s.ShipperID
 WHERE s.CompanyName = 'Speedy Express';

--11 Select a list of Suppliers containing company name, contact name, contact title and region description. --
SELECT CompanyName, ContactName, ContactTitle, region FROM Suppliers;

--12 Select all product names from the Products table that are condiments. --

SELECT P.ProductName FROM Products p
 INNER JOIN Categories c ON p.CategoryID = c.CategoryID
 WHERE c.CategoryID = 2;

 --13 Select a list of customer names who have no orders in the Orders table. --
SELECT ContactName FROM Customers 
	WHERE CustomerID NOT IN (SELECT CustomerID FROM Orders);

--14 Add a shipper named 'Amazon' to the Shippers table using SQL. --
INSERT INTO Shippers(CompanyName) VALUES ('Amazon');

--15 Change the company name from 'Amazon' to 'Amazon Prime Shipping' in the Shippers table using SQL. --
UPDATE Shippers SET CompanyName = 'Amazon Prime Shipping' WHERE ShipperID = 4;

--16 Select a complete list of company names from the Shippers table. Include freight totals rounded to the nearest whole number for each shipper from the Orders table for those shippers with orders. --
SELECT s.CompanyName, ROUND(SUM(o.freight), 0) FROM Shippers s
 INNER JOIN Orders o ON s.ShipperID = o.ShipVia  GROUP BY s.CompanyName;

--17 Select all employee first and last names from the Employees table by combining the 2 columns aliased as 'DisplayName'. The combined format should be 'LastName, FirstName'. --
SELECT LastName + ' ' + FirstName AS DisplayName FROM Employees;
		 
--18 Add yourself to the Customers table with an order for 'Grandma's Boysenberry Spread'. --
INSERT INTO Customers(CustomerID, CompanyName, ContactName, City) VALUES 
('NADAH', 'Nadeem Pvt Ltd','Nadeem Ahmed', 'Jaipur');



INSERT INTO Orders(CustomerID) VALUES ('NADAH');
	SELECT * FROM Customers WHERE CustomerID = 'NADAH';
	SELECT * FROM Orders WHERE CustomerID = 'NADAH';
	SELECT * FROM OrderDetails;
	SELECT OrderID FROM Orders;
	SELECT MAX(OrderID) AS LastOrderID FROM Orders;

	INSERT INTO OrderDetails (OrderID, ProductID)
VALUES (
    (SELECT MAX(OrderID) FROM Orders),
    (SELECT ProductID 
     FROM Products 
     WHERE ProductName = 'Grandma''s Boysenberry Spread')
);



--19 Remove yourself and your order from the database. --
-- Step 1
DELETE FROM OrderDetails
WHERE OrderID IN (
    SELECT OrderID FROM Orders WHERE CustomerID = 'NADAH'
);

-- Step 2
DELETE FROM Orders
WHERE CustomerID = 'NADAH';

-- Step 3
DELETE FROM Customers
WHERE CustomerID = 'NADAH';

SELECT * FROM Customers;
SELECT * FROM Products;
SELECT * FROM OrderDetails;
SELECT * FROM Orders;


--20 Select a list of products from the Products table along with the total units in stock for each product. Give the computed column a name using the alias, 'TotalUnits'. Include only products with TotalUnits greater than 100. --
SELECT ProductName,(UnitsInStock + UnitsOnOrder) AS TotalUnits FROM Products WHERE (UnitsInStock + UnitsOnOrder) > 100;