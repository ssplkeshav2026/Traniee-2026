---1---Select all category names with their descriptions from the Categories table.
SELECT CategoryName, Description
FROM Categories;
---2---Select the contact name, customer id, and company name of all Customers in London
Select contactName, customerID,companyName 
FROM Customers

WHERE City = 'London';

---3---Marketing managers and sales representatives have asked you to select all available columns in the Suppliers tables that have a FAX number.

SELECT *
FROM suppliers

where Fax is not null;

--4--Select a list of customers id’s from the Orders table with required dates between Jan 1, 1997 and Jan 1, 1998 and with freight under 100 units.

SELECT CustomerID
FROM Orders
WHERE RequiredDate >= '1997-01-01'
  AND RequiredDate < '1998-01-01'
  AND Freight < 100;

---5---Select a list of company names and contact names of all the Owners from the Customer table from Mexico, Sweden and Germany

  SELECT CompanyName, contactName
  FROM Customers
  WHERE contactTitle = 'owner'
  AND country IN('mexico','sweden','germany');

  --6--Count the number of discontinued products in the Products table

    SELECT COUNT('DISCONTINUED' ) FROM PRODUCTS;
---7--Select a list of category names and descriptions of all categories beginning with 'Co' from the Categories table.

  select categoryname , description from categories
  where categoryname like 'co%';

  ---8---Select all the company names, city, country and postal code from the Suppliers table with the word 'rue' in their address. The list should be ordered alphabetically by company name
    select companyname, city, country, postalcode from suppliers
  where address like '%rue%' 
  order by companyname;

  --9--Select the product id and the total quantities ordered for each product id in the Order Details table.
  select productid , sum(quantity) as totalquantityordered
from[order details] group by productid;

--10--Select the customer name and customer address of all customers with orders that shipped using Speedy Expres
SELECT c.CustomerName, c.Address
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN Shippers s ON o.ShipVia = s.ShipperID
WHERE s.CompanyName = 'Speedy Express';

---11--Select all product names from the Products table that are condiments.
SELECT ProductName
FROM Products
WHERE CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName = 'Condiments');   

--12--Select a list of Suppliers containing company name, contact name, contact title and region description.
SELECT ProductName
FROM Products
WHERE CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName = 'Condiments');  
--13--Select a list of customer names who have no orders in the Orders table

SELECT c.companyname AS Customers
FROM Customers c
LEFT JOIN Orders o ON c.customerid = o.customerId
WHERE o.customerId IS NULL;   

--14--Add a shipper named 'Amazon' to the Shippers table using SQL
insert into shippers (companyname) values ('amazon');

--15--Change the company name from 'Amazon' to 'Amazon Prime Shipping' in the Shippers table using SQL

update shippers
set companyname = 'Amazon Prime Shipping' 
where companyname = 'Amazon';

--16--Select a complete list of company names from the Shippers table. Include freight totals rounded to the nearest whole number for each shipper from the Orders table for those shippers with orders.

SELECT s.CompanyName, SUM(o.Freight)
FROM Shippers s
INNER JOIN Orders o
ON s.ShipperID = o.ShipVia
GROUP BY s.CompanyName;

--17--Select all employee first and last names from the Employees table by combining the 2 columns aliased as 'DisplayName'. The combined format should be 'LastName, FirstName


SELECT 
    LastName + ', ' + FirstName AS DisplayName
FROM Employees;


--18--
INSERT INTO Customers(CustomerID, CompanyName, ContactName, City) VALUES('SETIA', 'AAYUSH Pvt Ltd','AAYUSHSETIA', 'Jaipur');
INSERT INTO Orders(CustomerID) VALUES ('setia');
SELECT * FROM Customers WHERE CustomerID = 'setia';SELECT * FROM Orders WHERE CustomerID = 'setia';
SELECT * FROM OrderDetails;SELECT OrderID FROM Orders;
SELECT MAX(OrderID) AS LastOrderID FROM Orders;INSERT INTO OrderDetails (OrderID, ProductID)VALUES (    (SELECT MAX(OrderID) FROM Orders),    (SELECT ProductID 
     FROM Products 
     WHERE ProductName = 'Grandma''s Boysenberry Spread'));


--20--
SELECT ProductName,(UnitsInStock + UnitsOnOrder) AS TotalUnits FROM Products WHERE (UnitsInStock + UnitsOnOrder) > 100;