--1--
SELECT CategoryName, Description
FROM Categories
ORDER BY CategoryName ASC;
---2--
select ContactName,CompanyName,ContactTitle,Phone number
from customers
order by phone ASC;
---3---
SELECT 
    UPPER(FirstName) AS FirstName,
    UPPER(LastName) AS LastName,
    HireDate
FROM Employees
ORDER BY HireDate DESC;
--4--
select top 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight
from orders 
order by freight desc
--5--
select  lower(CustomerID) as id 
from  customers
--6--
select CompanyName, Fax, Phone, Country, HomePage
from  suppliers 
order by Country desc , CompanyName asc;
--7--
select companyname, contactname 
from customers
where city='Buenos Aires';

--8--
select ProductName, UnitPrice, QuantityPerUnit
from products 
where UnitsInStock = 0;
--9--

select  ContactName, Address, City 
from customers 
where country not in(' Germany', 'Mexico' , 'Spain');
--10--
select  OrderDate, ShippedDate, CustomerID, Freight 
from orders
where orderdate =  '1996-5-21';
--11--
select  FirstName, LastName, Country
from employees		
where COUNTRY not in ('USA');
--12--
SELECT  EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate
FROM orders 
WHERE Shippeddate > requireddate;
--13---
select  City, CompanyName, ContactName
from  customers 
where city like 'A%' or city like 'b%' ;       
--14--
select  OrderID 
from orders
where orderid %2=0;
--15--
select *
from orders
where  freight > $500;
--16--
select  ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel
from products
where UnitsInStock + UnitsOnOrder <= ReorderLevel
--17--
select CompanyName, ContactName number
from customers 
where fax is null;
--18--
select  FirstName, LastName
from employees
where reportsto is null;
--19--
select  OrderID 
from orders
where orderid %2=1;
--20--
select CompanyName, ContactName, Fax 
from customers 
where fax is null
order by ContactName asc;
--21--
select City, CompanyName, ContactName
from  customers
where city like 'l%'  
order by contactName asc;
--22--.
select FirstName, LastName, BirthDate
from employees
where birthdate between '1950-1-1' and '1959-12-31';
--23--
select  FirstName, LastName,  year(Birthdate) birthyear 
from employees
--24--
SELECT OrderID, COUNT(OrderID) AS NumberofOrders
FROM orderdetails
GROUP BY OrderID
ORDER BY NumberofOrders DESC;
--25--
SELECT p.SupplierID, p.ProductName, s.CompanyName
FROM Products p
JOIN Suppliers s  ON p.SupplierID = s.SupplierID
WHERE s.CompanyName IN (
    'Exotic Liquids', 
    'Specialty Biscuits, Ltd.', 
    'Escargots Nouveaux'
)
ORDER BY p.SupplierID;
--26--
select ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress
from orders
where ShipPostalCode like '98124%';
--27--
select  ContactName, ContactTitle, CompanyName
from customers
where ContactTitle not like 'Sales%';
--28--
select LastName, FirstName, City
from employees 
where city not in ('Seattle')
--29--
select  CompanyName, ContactTitle, City, Country
from customers
where country = 'Mexico' or (country = 'Spain'and city <> 'Madrid');
--30 --
SELECT * FROM Employees;
SELECT FirstName + ' ' + LastName + ' can be reached at x ' + Extension AS ContactInfo FROM Employees;


--31--
select ContactName
from customers
where ContactName not like '_a%';
--33--
SELECT  p.SupplierID,s.CompanyName,c.CategoryName,p.ProductName,p.UnitPrice
FROM Products p
JOIN Suppliers s ON p.SupplierID = s.SupplierID
JOIN Categories c ON p.CategoryID = c.CategoryID;
--32--
SELECT CEILING(AVG(UnitPrice)) AS AveragePrice,SUM(UnitPrice * UnitsInStock) AS TotalStock,MAX(UnitsOnOrder) AS MaxOrder
FROM Products
--34--
SELECT CustomerID, SUM(Freight) AS TotalFreight
FROM Orders
GROUP BY CustomerID
HAVING SUM(Freight) > 200;
--35--
SELECT o.OrderID, c.ContactName, od.UnitPrice,od.Quantity, od.Discount
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID;
--36--
SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS Employee,M.LastName + ' ' + M.FirstName AS Manager
FROM Employees E
LEFT JOIN Employees M
ON E.ReportsTo = M.EmployeeID
ORDER BY E.EmployeeID;
--37--
SELECT AVG(UnitPrice) AS AveragePrice,MIN(UnitPrice) AS MinimumPrice,MAX(UnitPrice) AS MaximumPrice
FROM Products;

--38--
CREATE VIEW CustomerInfo AS
SELECT C.CustomerID, C.CompanyName, C.ContactName, C.ContactTitle,C.Address, C.City, C.Country,C.Phone,O.OrderDate,
    O.RequiredDate,O.ShippedDate
FROM Customers C
JOIN Orders O
ON C.CustomerID = O.CustomerID

SELECT * FROM CustomerInfo;
--39--
exec sp_rename 'customerinfo', 'customer_details';
--41--
drop view  customer_details;
--42--
select left(categoryName , 5)  as ShortInfo 
from  categories;
--43--
select * into shippers_duplicate
from  shippers
where 1 = 0
insert shippers_duplicate select * from shippers;
--44--
select shipperID , companyname , phone , Email
from shippers_duplicate
--45--
SELECT s.CompanyName,p.ProductName
FROM  Products p
JOIN Categories c ON p.CategoryID = c.CategoryID
JOIN Suppliers s ON p.SupplierID = s.SupplierID
WHERE c.CategoryName = 'Seafood';   
--47--
drop table shippers_duplicate ;
--48--
SELECT LastName, FirstName, Title,
DATEDIFF(YEAR, BirthDate, GETDATE()) AS Age
FROM Employees
--50--
SELECT (ProductName, + ' weighs/is ' +, QuantityPerUnit, + ' and cost $',+ CAST(ROUND(UnitPrice,0) AS INT)) AS ProductInfo FROM Products
 