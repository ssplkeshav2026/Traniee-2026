use first_assignment
select name from sys.tables

--1 Create a report that shows the CategoryName and Description from the categories table sorted by CategoryName.

select categoryname,description from Categories order by categoryname

--2 Create a report that shows the ContactName, CompanyName, ContactTitle and Phone number 
--from the customers table sorted by Phone. 

select contactname,companyname,ContactTitle,phone as 'Phone number' from customers order by Phone

--3 Create a report that shows the capitalized FirstName and capitalized LastName renamed as FirstName and Lastname
--respectively and HireDate from the employees table sorted from the newest to the oldest employee. 


select UPPER(FirstName) as FirstName,upper(Lastname),hiredate from Employees order by HireDate desc

--4 Create a report that shows the top 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight 
--from the orders table sorted by Freight in descending order.


select top(10) orderid,OrderDate,ShippedDate,CustomerID,Freight from orders order by Freight desc

--5 Create a report that shows all the CustomerID in lowercase letter and renamed as ID from the customers table


select LOWER(CustomerID) as ID from Customers

--6 Create a report that shows the CompanyName, Fax, Phone, Country, HomePage 
--from the suppliers table sorted by the Country in descending order then by CompanyName in ascending order. 

select CompanyName,fax,phone,Country,HomePage from Suppliers order by Country desc,CompanyName asc

-- 7 Create a report that shows CompanyName, ContactName of all customers from ‘Buenos Aires' only. 

SELECT CustomerID,CompanyName, ContactName FROM Customers WHERE City = 'Buenos Aires';

--8 Create a report showing ProductName, UnitPrice, QuantityPerUnit of products that are out of stock

SELECT ProductName, UnitPrice, QuantityPerUnit FROM Products WHERE UnitsInStock = 0;

--9 Create a report showing all the ContactName, Address, City of all customers not from Germany, Mexico, Spain. 

select ContactName,Address,City from Customers where Country not in('germany','mexico','spain')

--10  Create a report showing OrderDate, ShippedDate, CustomerID, Freight of all orders placed on 21 May 1996. 

select OrderDate,ShippedDate,CustomerID,Freight from orders where OrderDate='1996-5-21';

-- 11 Create a report showing FirstName, LastName, Country from the employees not from United States

SELECT FirstName, LastName, Country FROM Employees WHERE Country NOT IN ('USA', 'United States');

-- 12 Create a report that shows the EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate 
--    from all orders shipped later than the required date
 
 select EmployeeID,OrderID,CustomerID,RequiredDate,ShippedDate from orders where ShippedDate>RequiredDate

-- 13 Create a report that shows the City, CompanyName, ContactName of customers from cities starting with A or B. 

    select city,CompanyName,contactname from Customers where city like 'A%' or city like 'B%'   
  
--14  Create a report showing all the even numbers of OrderID from the orders table.
    
    select * from orders where orderid%2=0

--15 Create a report that shows all the orders where the freight cost more than $500
    
    select * from Orders where Freight>500

--16  Create a report that shows the ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel of
--    all products that are up for reorder

SELECT ProductName,UnitsInStock,UnitsOnOrder,ReorderLevel FROM Products WHERE UnitsInStock + UnitsOnOrder <= ReorderLevel;
  
  
 --17 Create a report that shows the CompanyName, ContactName number of all customer that have no fax number. 

 SELECT CompanyName, ContactName FROM Customers WHERE Fax IS NULL or fax='';

 --18 Create a report that shows the FirstName, LastName of all employees that do not report to anybody. 

SELECT FirstName, LastName FROM Employees WHERE ReportsTo IS NULL;

--19  Create a report showing all the odd numbers of OrderID from the orders table.
    SELECT OrderID FROM Orders WHERE OrderID % 2 <> 0;


--20. Create a report that shows the CompanyName, ContactName, Fax of all customers 
--    that do not have Fax number and sorted by ContactName

SELECT CompanyName, ContactName, Fax FROM Customers WHERE Fax IS NULL OR Fax = '' ORDER BY CompanyName;

--21  Create a report that shows the City, CompanyName, ContactName of customers 
--    from cities that has letter L in the name sorted by ContactName. 
  
  SELECT City, CompanyName, ContactName FROM Customers WHERE City LIKE '%L%' ORDER BY ContactName; 


--22 Create a report that shows the FirstName, LastName, BirthDate of employees born in the 1950s

SELECT FirstName, LastName, BirthDate FROM Employees WHERE YEAR(BirthDate) BETWEEN 1950 AND 1959;

-- 23  Create a report that shows the FirstName, LastName, the year of Birthdate as birth year 
--     from the employees table

SELECT FirstName, LastName, YEAR(BirthDate) AS 'Birth Year' FROM Employees
 
--24 Create a report showing OrderID, total number of Order ID as NumberofOrders 
--   from the orderdetails table grouped by OrderID and sorted by NumberofOrders in descending order.

SELECT OrderID,COUNT(OrderID) AS NumberOfOrders FROM OrderDetails GROUP BY OrderID ORDER BY NumberOfOrders DESC;


--25  Create a report that shows the SupplierID, ProductName, CompanyName 
--    from all product Supplied by Exotic Liquids, Specialty Biscuits, Ltd., Escargots Nouveaux 
--    sorted by the supplier ID

SELECT p.SupplierID, p.ProductName, s.CompanyName FROM Products p JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE s.CompanyName IN ('Exotic Liquids','Specialty Biscuits, Ltd.','Escargots Nouveaux') ORDER BY p.SupplierID;



--26. Create a report that shows the ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress of all orders
--    with ShipPostalCode beginning with "98124".


SELECT ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress
FROM Orders
WHERE ShipPostalCode LIKE '98124%';

--27  . Create a report that shows the ContactName, ContactTitle, CompanyName of customers that the has no "Sales" in their
--      ContactTitle.

SELECT ContactName, ContactTitle, CompanyName FROM Customers WHERE ContactTitle NOT LIKE '%Sales%';


--28. Create a report that shows the LastName, FirstName, City of employees in cities other than "Seattle";


SELECT LastName, FirstName, City FROM Employees WHERE City <> 'Seattle';


--29. Create a report that shows the CompanyName, ContactTitle, City, Country of all customers in any city in Mexico or other
--    cities in Spain other than Madrid. 

SELECT CompanyName, ContactTitle, City, Country FROM Customers WHERE Country = 'Mexico' OR (Country = 'Spain' AND City <> 'Madrid');


--30 Create a select statement that outputs the following


SELECT FirstName + ' ' + LastName + ' can be reached at x' + Extension AS Contactinfo FROM Employees;

--31. Create a report that shows the ContactName of all customers 
--    that do not have letter A as the second alphabet in their Contactname.


SELECT ContactName FROM Customers WHERE ContactName NOT LIKE '_A%';


--32. Create a report that shows the average UnitPrice rounded to the next whole number,
--    total price of UnitsInStock and maximum number of orders from the products table.
--    All saved as AveragePrice, TotalStock and MaxOrder respectively.

SELECT CEILING(AVG(UnitPrice)) AS AveragePrice,SUM(UnitsInStock) AS TotalStock,MAX(UnitsOnOrder) AS MaxOrder FROM Products;

--33 Create a report that shows the SupplierID, CompanyName, CategoryName, ProductName and 
--   UnitPrice from the products, suppliers and categories table.

SELECT s.SupplierID,s.CompanyName,c.CategoryName,p.ProductName,p.UnitPrice FROM Products p
JOIN Suppliers s ON p.SupplierID = s.SupplierID
JOIN Categories c ON p.CategoryID = c.CategoryID;


--34. Create a report that shows the CustomerID, sum of Freight,
--    from the orders table with sum of freight greater $200, grouped by CustomerID. 

SELECT CustomerID,SUM(Freight) AS TotalFreight FROM Orders
GROUP BY CustomerID
HAVING SUM(Freight) > 200;


-- 35. Create a report that shows the OrderID ContactName, UnitPrice, Quantity, Discount 
--     from the order details, orders and customers table with discount given on every purchase. 


SELECT o.OrderID,c.ContactName,od.UnitPrice,od.Quantity,od.Discount
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID;

--36 Create a report that shows the EmployeeID, the LastName and FirstName as employee, and
--   the LastName and FirstName of who they report to as manager from the employees table sorted by Employee ID.


SELECT e.EmployeeID,e.LastName + ' ' + e.FirstName AS Employee,m.LastName + ' ' + m.FirstName AS Manager
FROM Employees e
LEFT JOIN Employees m ON e.ReportsTo = m.EmployeeID
ORDER BY e.EmployeeID;


--37. Create a report that shows the average, minimum and maximum UnitPrice of all products as AveragePrice, MinimumPrice
--    and MaximumPrice respectively


SELECT AVG(UnitPrice) AS AveragePrice,MIN(UnitPrice) AS MinimumPrice,MAX(UnitPrice) AS MaximumPrice FROM Products;


--38. Create a view named CustomerInfo that shows the CustomerID, CompanyName, ContactName, ContactTitle, Address, City,
--    Country, Phone, OrderDate, RequiredDate, ShippedDate from the customers and orders table.

CREATE VIEW CustomerInfo AS
SELECT c.CustomerID,c.CompanyName,c.ContactName,c.ContactTitle,c.Address,c.City,c.Country,c.Phone,o.OrderDate,o.RequiredDate,o.ShippedDate
FROM Customers c
INNER JOIN Orders o
ON c.CustomerID = o.CustomerID;


--39. Change the name of the view you created from customerinfo to customer details.

EXEC sp_rename 'customerinfo', 'customerDetails';



--40. Create a view named ProductDetails that shows the ProductID, CompanyName, ProductName, CategoryName, Description,
--    QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued from the supplier, products and
--    categories tables. 


CREATE VIEW ProductDetails AS
SELECT p.ProductID,s.CompanyName,p.ProductName,c.CategoryName,c.Description,p.QuantityPerUnit,p.UnitPrice,
    p.UnitsInStock,p.UnitsOnOrder,
    p.ReorderLevel,
    p.Discontinued
FROM Products p
INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID;


-- 41. Drop the customer details view.
      
        drop view CustomerDetails

-- 42. Create a report that fetch the first 5 character of categoryName from the category tables and renamed as ShortInfo

    select SUBSTRING(categoryname,1,5) as ShortInfo  from Categories

-- 43. Create a copy of the shipper table as shippers_duplicate. 
--     Then insert a copy of shippers data into the new table HINT: Create a Table, use the LIKE Statement and INSERT INTO statement. 

   SELECT *
   INTO Shippers_Duplicate
   FROM Shippers
   WHERE 1 = 0;


   INSERT INTO Shippers_Duplicate (CompanyName, Phone)SELECT CompanyName, Phone FROM Shippers;


    select * from Shippers_Duplicate

-- 44. Create a select statement that outputs the following from the shippers_duplicate Table: 

   select *from Shippers_Duplicate
   alter table shippers_duplicate add Email varchar(50)
    update Shippers_Duplicate set email='speedyexpress@gmail.com' where ShipperID=1
    update Shippers_Duplicate set email='unitedpackage@gmail.com' where ShipperID=2
    update Shippers_Duplicate set email='federshipping@gmail.com' where ShipperID=3

-- 45. Create a report that shows the CompanyName and ProductName from all product in the Seafood category.

SELECT s.CompanyName,p.ProductName FROM Products p
INNER JOIN Suppliers s ON p.SupplierID = s.SupplierID
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE c.CategoryName = 'Seafood';


-- 46. Create a report that shows the CategoryID, CompanyName and ProductName from all product in the categoryID 5.

 select c.CategoryID,s.companyname,pn.productname from Categories c
 inner join products pn on c.CategoryID=pn.CategoryID
 inner join Suppliers s on pn.SupplierID=s.SupplierID
 where c.CategoryID=5

-- 47. Delete the shippers_duplicate table 
   
   
  drop table shippers_duplicate 

--48 Create a select statement that ouputs the following from the employees table.
--   NB: The age might differ depending on the year you are attempting this query. 


SELECT LastName,FirstName,Title,CAST(DATEDIFF(YEAR, BirthDate, GETDATE()) 
         - CASE 
             WHEN DATEADD(YEAR, DATEDIFF(YEAR, BirthDate, GETDATE()), BirthDate) > GETDATE() 
             THEN 1 
             ELSE 0 
           END AS VARCHAR) + ' Years' AS Age
FROM Employees;


--49 Create a report that the CompanyName and total number of orders by customer renamed as number of orders 
--   since December 31, 1994. Show number of Orders greater than 10


SELECT c.CompanyName,COUNT(o.OrderID) AS 'Number of Orders'
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1994-12-31'
GROUP BY c.CompanyName
HAVING COUNT(o.OrderID) > 10;


--50 Create a select statement that ouputs the following from the product table
--   NB: It should return 77rows

SELECT ProductName + ' weighs/is ' + QuantityPerUnit + ' and cost $' + CAST(CAST(UnitPrice AS INT) AS VARCHAR) AS ProductInfo
FROM Products;