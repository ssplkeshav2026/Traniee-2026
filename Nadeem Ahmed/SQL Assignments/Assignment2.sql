USE Assignment1;

--1 Create a report that shows the CategoryName and Description from the categories table sorted by CategoryName. --
SELECT CategoryName, Description FROM Categories ORDER BY CategoryName ASC;

--2  Create a report that shows the ContactName, CompanyName, ContactTitle and Phone number from the customers table sorted by Phone. --
SELECT ContactName, CompanyName, ContactTitle, Phone FROM Customers ORDER BY Phone ASC;

--3 Create a report that shows the capitalized FirstName and capitalized LastName renamed as FirstName and Lastname respectively and HireDate from the employees table sorted from the newest to the oldest employee. --
SELECT UPPER(FirstName) AS FirstName, UPPER(LastName) AS LastName , HireDate FROM Employees ORDER BY HireDate DESC;

--4  Create a report that shows the top 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight from the orders table sorted by Freight in descending order. --
SELECT TOP 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight FROM Orders ORDER BY Freight DESC;

--5 reate a report that shows all the CustomerID in lowercase letter and renamed as ID from the customers table. --
SELECT LOWER(CustomerID) AS ID FROM Customers; 

--6 Create a report that shows the CompanyName, Fax, Phone, Country, HomePage from the suppliers table sorted by the Country in descending order then by CompanyName in ascending order. --
SELECT CompanyName, Fax, Phone, Country, HomePage FROM Suppliers ORDER BY Country DESC, CompanyName ASC;

--7 Create a report that shows CompanyName, ContactName of all customers from ‘Buenos Aires' only. --
SELECT CompanyName, ContactName FROM Customers WHERE City='Buenos Aires';

--8  Create a report showing ProductName, UnitPrice, QuantityPerUnit of products that are out of stock. --
SELECT ProductName, UnitPrice, QuantityPerUnit FROM Products WHERE UnitsInStock=0;

--9 Create a report showing all the ContactName, Address, City of all customers not from Germany, Mexico, Spain. --
SELECT ContactName, Address, City FROM Customers WHERE City NOT IN ('Germany', 'Mexico', 'Spain');

--10 Create a report showing OrderDate, ShippedDate, CustomerID, Freight of all orders placed on 21 May 1996. --
SELECT OrderDate, ShippedDate, CustomerID, Freight FROM Orders WHERE OrderDate = '1996-05-21' ;

--11 Create a report showing FirstName, LastName, Country from the employees not from United States. --
SELECT FirstName, LastName, Country FROM Employees WHERE Country NOT IN ('USA');

--12 Create a report that shows the EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate from all orders shipped later than the required date. --
SELECT EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate FROM Orders WHERE ShippedDate > RequiredDate;

--13 Create a report that shows the City, CompanyName, ContactName of customers from cities starting with A or B. --
SELECT City, CompanyName, ContactName FROM Customers WHERE CITY LIKE 'A%' OR City LIKE 'B%' ORDER BY City ASC;

--14 Create a report showing all the even numbers of OrderID from the orders table. --
SELECT OrderID FROM Orders WHERE (OrderID % 2) = 0 ORDER BY OrderID ASC;

--15 Create a report that shows all the orders where the freight cost more than $500. --
SELECT * FROM Orders WHERE Freight > 500;

--16 Create a report that shows the ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel of all products that are up for reorder. --
SELECT ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel FROM Products WHERE (UnitsInStock + UnitsOnOrder) < ReorderLevel;

--17 Create a report that shows the CompanyName, ContactName number of all customer that have no fax number. --
SELECT CompanyName, ContactName, Phone FROM Customers WHERE Fax IS NOT NULL;

--18 Create a report that shows the FirstName, LastName of all employees that do not report to anybody. --
SELECT FirstName, LastName FROM Employees WHERE ReportsTo IS NULL;

--19 Create a report showing all the odd numbers of OrderID from the orders table. --
SELECT OrderID FROM Orders WHERE (OrderID % 2) = 1 ORDER BY OrderID ASC;

--20 Create a report that shows the CompanyName, ContactName, Fax of all customers that do not have Fax number and sorted by ContactName. --
SELECT CompanyName, ContactName, Fax FROM Customers WHERE Fax IS NULL ORDER BY ContactName ASC;

--21 Create a report that shows the City, CompanyName, ContactName of customers from cities that has letter L in the name sorted by ContactName. --
SELECT City, CompanyName, ContactName FROM Customers WHERE City LIKE '%l%' ORDER BY ContactName ASC;

--22 Create a report that shows the FirstName, LastName, BirthDate of employees born in the 1950s. --
SELECT FirstName, LastName, BirthDate FROM Employees WHERE Year(BirthDate) BETWEEN 1950 AND 1959;

--23 Create a report that shows the FirstName, LastName, the year of Birthdate as birth year from the employees table. --
SELECT FirstName, LastName, YEAR(BirthDate) AS BirthYear FROM Employees;

--24  Create a report showing OrderID, total number of Order ID as NumberofOrders from the orderdetails table grouped by OrderID and sorted by NumberofOrders in descending order. HINT: you will need to use a Groupby statement. --
SELECT OrderID, COUNT(OrderID) AS NumberOfOrders FROM OrderDetails GROUP BY OrderID ORDER BY NumberOfOrders DESC;

--25 Create a report that shows the SupplierID, ProductName, CompanyName from all product Supplied by Exotic Liquids, Specialty Biscuits, Ltd., Escargots Nouveaux sorted by the supplier ID. --
SELECT s.SupplierID, p.ProductName, s.CompanyName FROM Suppliers s
 INNER JOIN Products p ON p.SupplierID = s.SupplierID
 WHERE s.SupplierID IN (1,8, 27) ORDER BY s.SupplierID ASC;


--26 Create a report that shows the ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress of all orders with ShipPostalCode beginning with "98124". --
SELECT ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress FROM Orders WHERE ShipPostalCode LIKE '98124%';

--27 Create a report that shows the ContactName, ContactTitle, CompanyName of customers that the has no "Sales" in their ContactTitle. --
SELECT ContactName, ContactTitle, CompanyName FROM Customers WHERE ContactTitle NOT LIKE '%Sales%';

--28  Create a report that shows the LastName, FirstName, City of employees in cities other than "Seattle". --
SELECT LastName, FirstName, City FROM Employees WHERE City NOT IN ('Seattle');

--29 Create a report that shows the CompanyName, ContactTitle, City, Country of all customers in any city in Mexico or other cities in Spain other than Madrid. 
SELECT CompanyName, ContactTitle, City, Country FROM Customers WHERE Country = 'Mexico' OR (Country = 'Spain' AND City <> 'Madrid');

--30 
SELECT FirstName + ' ' + LastName + ' can be reached at ' + Extension AS ContactInfo FROM Employees;

--31 Create a report that shows the ContactName of all customers that do not have letter A as the second alphabet in their Contactname. --
SELECT ContactName FROM Customers WHERE ContactName NOT LIKE '_A%'

--32 Create a report that shows the average UnitPrice rounded to the next whole number, total price of UnitsInStock and maximum number of orders from the products table. All saved as AveragePrice, TotalStock and MaxOrder respectively. --
SELECT ROUND(AVG(UnitPrice),0) AS AveragePrice, SUM(UnitsInStock) AS TotalStock, MAX(UnitsOnOrder) AS MaxOrder FROM Products;

--33 Create a report that shows the SupplierID, CompanyName, CategoryName, ProductName and UnitPrice from the products, suppliers and categories table. --
SELECT s.SupplierID, s.CompanyName, c.CategoryName, p.ProductName, p.UnitPrice FROM Products p
 INNER JOIN Suppliers s ON s.SupplierID = p.SupplierID
 INNER JOIN Categories c ON c.CategoryID = p.CategoryID;

--34  Create a report that shows the CustomerID, sum of Freight, from the orders table with sum of freight greater $200, grouped by CustomerID. HINT: you will need to use a Groupby and a Having statement. --
SELECT CustomerID, SUM(Freight) AS Freight FROM ORDERS GROUP BY CustomerID HAVING SUM(Freight) > 200;

--35  Create a report that shows the OrderID, ContactName, UnitPrice, Quantity, Discount from the order details, orders and customers table with discount given on every purchase. --
SELECT od.OrderID, c.ContactName, od.UnitPrice, od.Quantity, od.Discount FROM OrderDetails od
 INNER JOIN Orders o ON o.OrderID = od.OrderID
 INNER JOIN Customers c ON c.CustomerID = o.CustomerID
 WHERE Discount > 0;

 --36 Create a report that shows the EmployeeID, the LastName and FirstName as employee, and the LastName and FirstName of who they report to as manager from the employees table sorted by Employee ID. HINT: This is a SelfJoin. --4
 SELECT 
    e.EmployeeID,
    e.LastName + ' ' + e.FirstName AS Employee,
    m.LastName + ' ' + m.FirstName AS Manager
FROM Employees e
LEFT JOIN Employees m 
    ON e.ReportsTo = m.EmployeeID
ORDER BY e.EmployeeID;

--37 Create a report that shows the average, minimum and maximum UnitPrice of all products as AveragePrice, MinimumPrice and MaximumPrice respectively. --
SELECT AVG(UnitPrice) AS AveragePrice, MIN(UnitPrice) AS MinimumPrice, MAX(UnitPrice) AS MaximumPrice FROM Products;

--38  Create a view named CustomerInfo that shows the CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Country, Phone, OrderDate, RequiredDate, ShippedDate from the customers and orders table. HINT: Create a View. --
CREATE VIEW CustomerInfo AS 
 SELECT c.CustomerID, c.CompanyName, c.ContactName, c.ContactTitle, c.Address, c.City, c.Country, c.Phone, o.OrderDate, o.RequiredDate, o.ShippedDate FROM Customers c
  INNER JOIN Orders o ON o.CustomerID = c.CustomerID;

--39 Change the name of the view you created from customerinfo to customer details. --
EXEC sp_rename 'CustomerInfo' , 'CustomerDetails';

--40 Create a view named ProductDetails that shows the ProductID, CompanyName, ProductName, CategoryName, Description, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued from the supplier, products and categories tables. HINT: Create a View. --
CREATE VIEW ProductDetails AS 
 SELECT p.ProductID, s.CompanyName, p.ProductName, c.CategoryName, c.Description, p.QuantityPerUnit, p.UnitPrice, p.UnitsInStock, p.UnitsOnOrder, p.ReorderLevel, p.Discontinued FROM Products p
  INNER JOIN Categories c ON p.CategoryID = c.CategoryID 
  INNER JOIN Suppliers s ON s.SupplierID = p.SupplierID;

--41 --
DROP VIEW CustomerDetails;

--42 Create a report that fetch the first 5 character of categoryName from the category tables and renamed as ShortInfo. --
SELECT LEFT(CategoryName, 5) AS ShortInfo FROM Categories;

--43 Create a copy of the shipper table as shippers_duplicate. Then insert a copy of shippers data into the new table HINT: Createa Table, use the LIKE Statement and INSERT INTO statement. --
-- Step 1: Create copy (no PK, no IDENTITY copied)
SELECT * 
INTO shippers_duplicate
FROM Shippers;



--44 --
ALTER TABLE shippers_duplicate 
ADD Email VARCHAR(100) NULL;

UPDATE shippers_duplicate 
SET Email = 'speedyexpress@gmail.com' WHERE ShipperId = 1;

UPDATE shippers_duplicate 
SET Email = 'unitedpackage@gmail.com' WHERE ShipperId = 2;

UPDATE shippers_duplicate 
SET Email = 'federalshipping@gmail.com' WHERE ShipperId = 3;


--45 Create a report that shows the CompanyName and ProductName from all product in the Seafood category. --
SELECT s.CompanyName, p.ProductName FROM Suppliers s 
 INNER JOIN Products p ON p.SupplierID = s.SupplierID
 INNER JOIN Categories c ON c.CategoryID = p.CategoryID
 WHERE c.CategoryID = 8;

 --46 Create a report that shows the CategoryID, CompanyName and ProductName from all product in the categoryID 5. --
SELECT c.CategoryID, s.CompanyName, p.ProductName FROM Categories c
  INNER JOIN Products p ON p.CategoryID = c.CategoryID
  INNER JOIN Suppliers s ON s.SupplierID = p.SupplierID
  WHERE c.CategoryID = 5;

 --47 Delete the shippers_duplicate table. --
  DROP TABLE shippers_duplicate;

 --48 Create a select statement that ouputs the following from the employees table. --
 SELECT * INTO employees_duplicate FROM Employees;

    UPDATE employees_duplicate 
    SET Age = DATEDIFF(YEAR, BirthDate, GETDATE());

    SELECT LastName, FirstName, Title, Age FROM employees_duplicate;

 --49 Create a report that the CompanyName and total number of orders by customer renamed as number of orders since December 31, 1994. Show number of Orders greater than 10. --
  SELECT * FROM Customers;
  SELECT * FROM Orders;

  SELECT c.CompanyName, COUNT(o.OrderID) AS NumberOfOrders FROM Customers c
   INNER JOIN Orders o ON o.CustomerID = c.CustomerID
   WHERE o.OrderDate > '1994-12-31'
   GROUP BY c.CompanyName 
   HAVING COUNT(o.OrderID) > 10
   ORDER BY NumberOfOrders DESC;

   --50 -- 
  SELECT CONCAT(ProductName, ' weighs/is ', QuantityPerUnit, ' and cost $', CAST(ROUND(UnitPrice,0) AS INT)) AS ProductInfo FROM Products;
