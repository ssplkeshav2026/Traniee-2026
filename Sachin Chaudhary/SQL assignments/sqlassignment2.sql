--assignment2
--q1
select* from  categories
select CategoryName , Description from Categories order by categoryname asc;

--q2
select* from  Customers
 select ContactName, CompanyName, ContactTitle ,Phone number from Customers order by phone asc;

 --q3
 select* from  Employees
 select upper(FirstName) as FirstName,LOWER(LastName) as LastName from Employees order by HireDate desc;


 --q4
 select * from orders ;
 select top 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight from Orders order by Freight desc;


 --q5
 
 select lower(CustomerID) as ID from Customers;

--q6
select* from Suppliers
select CompanyName,Fax,Phone,Country,HomePage from Suppliers order by Country desc , CompanyName asc

--q7
 
 select * from Customers
 select CompanyName,ContactName from Customers where City ='Buenos Aires';
 --q8
 
  select * from Products
 select ProductName,UnitPrice,QuantityPerUnit from Products where UnitsInStock=0

 --q9
 --Create a report showing all the ContactName, Address, City of all customers not from Germany, Mexico, Spain. 
 select * from Customers
 select ContactName,Address,City from Customers where Country Not in ('Germany','Mexico','Spain')

--q10
--Create a report showing OrderDate, ShippedDate, CustomerID, Freight of all orders placed on 21 May 1996.
select * from Orders
select OrderDate,ShippedDate,CustomerID,Freight from Orders where OrderDate='1996-05-21'

--q11
 --Create a report showing FirstName, LastName, Country from the employees not from United States. 
  select* from Employees
 select FirstName,LastName,Country from Employees where Country Not In ('USA')

 --q12
 -- Create a report that shows the EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate from all orders shipped later 
--than the required date. 
select * from orders
select  EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate from  Orders where ShippedDate>RequiredDate

--q13
select* from customers
--Create a report that shows the City, CompanyName, ContactName of customers from cities starting with A or B. 
select City,CompanyName,ContactName from Customers where city like 'a%' or city like 'b%'

--q14
--Create a report showing all the even numbers of OrderID from the orders table. 
select * from Orders
select OrderID from orders where (OrderID)%2=0 
--q15
--Create a report that shows all the orders where the freight cost more than $500.
select* from orders where Freight>$500;


--q16
 --Create a report that shows the ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel of all products that are up for 
--reorder.
select* from products
select ProductName, UnitsInStock, UnitsOnOrder from Products where  (UnitsInStock + UnitsOnOrder) <= ReorderLevel;

--q17
--Create a report that shows the CompanyName, ContactName number of all customer that have no fax number
select* from Customers
select CompanyName,ContactName from Customers where fax is null

--q18
 --Create a report that shows the FirstName, LastName of all employees that do not report to anybody. 
 select* from Employees
 select FirstName, LastName FROM Employees WHERE ReportsTo is null;

 --q19
 --Create a report showing all the odd numbers of OrderID from the orders table. 
 select * from Orders
 select OrderID from orders where (OrderID)%2!=0

 --q20
 --Create a report that shows the CompanyName, ContactName, Fax of all customers that do not have Fax number and sorted 
--by ContactName. 
select CompanyName,ContactName,Fax from Customers where fax is null  order by ContactName asc

--q21
--Create a report that shows the City, CompanyName, ContactName of customers from cities that has letter L in the name 
--sorted by ContactName.
select City,CompanyName,ContactName from Customers where City like '%l%' order by ContactName asc

--q22
--Create a report that shows the FirstName, LastName, BirthDate of employees born in the 1950s.
select * from Employees
select Firstname,lastname BirthDate from Employees where BirthDate like '1950%'

--q23
--Create a report that shows the FirstName, LastName, the year of Birthdate as birth year from the employees table. 
select FirstName,LastName, birthdate as [Birth year ] from employees

--q24
-- Create a report showing OrderID, total number of Order ID as NumberofOrders from the orderdetails table grouped by 
--OrderID and sorted by NumberofOrders in descending order. HINT: you will need to use a Groupby statement.
select * from Orders
select * from OrderDetails
select OrderID ,count(OrderID) as NumberofOrders from OrderDetails group by OrderID order by NumberofOrders desc

--q25
 --Create a report that shows the SupplierID, ProductName, CompanyName from all product Supplied by Exotic Liquids, 
--Specialty Biscuits, Ltd., Escargots Nouveaux sorted by the supplier ID
select* from Products
select* from Suppliers
SELECT products.SupplierID, Products.ProductName,Suppliers.CompanyName
FROM Products
INNER JOIN Suppliers ON Products.SupplierID=Suppliers.SupplierID where CompanyName  in ('Exotic Liquids','Specialty Biscuits, Ltd.','Escargots Nouveaux') order by SupplierID asc

--q26
--Create a report that shows the ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress of all orders 
--with ShipPostalCode beginning with "98124". 
select ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress from Orders where ShipPostalCode like '98124%'

--q27
--Create a report that shows the ContactName, ContactTitle, CompanyName of customers that the has no "Sales" in their 
--ContactTitle.
select* from Customers
select ContactName, ContactTitle, CompanyName from Customers  where  ContactTitle  not like '%sales%';

--q28
--Create a report that shows the LastName, FirstName, City of employees in cities other than "Seattle"; 
select* from Employees
select LastName, FirstName, City from Employees where City!='seattle'


--q29
--Create a report that shows the CompanyName, ContactTitle, City, Country of all customers in any city in Mexico or other 
--cities in Spain other than Madrid.
select CompanyName, ContactTitle, City, Country from Customers WHERE (Country = 'Mexico')
   OR (Country = 'Spain' AND City not in ('Madrid'));

--q30
select* from Employees
select (Lastname+firstname) +'can be reached at x'+extension as contectinfo from Employees

--q31
--Create a report that shows the ContactName of all customers that do not have letter A as the second alphabet in their 
--Contactname. 
select ContactName from Customers where ContactName not like '_a%'

--q32
--Create a report that shows the average UnitPrice rounded to the next whole number, total price of UnitsInStock and 
--maximum number of orders from the products table. All saved as AveragePrice, TotalStock and MaxOrder respectively. 
select CEILING(AVG(UnitPrice)) as AveragePrice,sum(unitsOnOrder) as Totalstock,max(UnitsOnOrder) as maxOrder from Products
select* from Products

--q33
--Create a report that shows the SupplierID, CompanyName, CategoryName, ProductName and UnitPrice from the products, 
--suppliers and categories table. 
select* from products
select* from Suppliers
select* from Categories
select products.SupplierID, Suppliers.CompanyName, Categories.CategoryName, products.ProductName from Products 
inner JOIN Suppliers  ON products.SupplierID = suppliers.SupplierID
inner join Categories on Products.CategoryID=Categories.CategoryID

--q34
--. Create a report that shows the CustomerID, sum of Freight, from the orders table with sum of freight greater $200, grouped 
--by CustomerID. HINT: you will need to use a Groupby and a Having statement. 
select* from Orders
select CustomerID, sum(Freight) from  orders  group by CustomerID having sum(Freight)>200

--q35
--Create a report that shows the OrderID ContactName, UnitPrice, Quantity, Discount from the order details, orders and 
--customers table with discount given on every purchase. 
select* from orderdetails
select* from orders
select* from Customers
select orders.OrderID, customers.ContactName, orderdetails.UnitPrice, orderdetails.Quantity, orderdetails.Discount from OrderDetails
inner join Orders on orders.OrderID = orderdetails.OrderID
inner join Customers on Orders.customerID=Customers.customerID

--q36
--Create a report that shows the EmployeeID, the LastName and FirstName as employee, and the LastName and FirstName of 
--who they report to as manager from the employees table sorted by Employee ID. HINT: This is a SelfJoin.
select* from Employees
select 
    e.EmployeeID, 
    e.FirstName + ' ' + e.LastName AS employee, 
    m.FirstName + ' ' + m.LastName AS manager
from
    employees e
JOIN 
    employees m ON e.ReportsTo = m.EmployeeID
order by
    e.EmployeeID;

 --q37
    --Create a report that shows the average, minimum and maximum UnitPrice of all products as AveragePrice, MinimumPrice 
--and MaximumPrice respectively.
select AVG(UnitPrice) as AveragePrice,MAX(UnitPrice) as MaximumPrice, min(UnitPrice) as MinimumPrice from OrderDetails

--q38
-- Create a view named CustomerInfo that shows the CustomerID, CompanyName, ContactName, ContactTitle, Address, City, 
--Country, Phone, OrderDate, RequiredDate, ShippedDate from the customers and orders table. HINT: Create a View.
select* from Orders
select* from Customers
go
create view CustomerInfo as
select Customers.CustomerID, Customers.CompanyName, Customers.ContactName, Customers.ContactTitle, Customers.Address, Customers.City, 
Customers.Country, Customers.Phone, Orders.OrderDate, Orders.RequiredDate, Orders.ShippedDate from Customers
join Orders on Customers.CustomerID=Orders.CustomerID;
select* from customer deta

--q39
-- Change the name of the view you created from customerinfo to customer details. 
EXEC sp_rename 'CustomerINnfo', ' customerdetails';

--q40
CREATE VIEW ProductDetails AS
SELECT 
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
FROM Products p
JOIN Suppliers s ON p.SupplierID = s.SupplierID
JOIN Categories c ON p.CategoryID = c.CategoryID;

--q41

DROP VIEW IF EXISTS CustomerInfo;

--q42
--Create a report that fetch the first 5 character of categoryName from the category tables and renamed as ShortInfo 
select* from Categories
select LEFT(CategoryName, 5) AS ShortInfo
from Categories;


--q43
select * into shippers_duplicate 
FROM Shippers;
select * from shippers_duplicate

--q44

ALTER TABLE Shippers_Duplicate 
add Email varchar(80);



Select * from shippers_duplicate
UPDATE shippers_duplicate SET Email = 'speedyexpress@gmail.com' WHERE ShipperID = 1;
UPDATE shippers_duplicate SET Email = 'UnitedPackage@gmail.com' WHERE ShipperID = 2;
UPDATE shippers_duplicate SET Email = 'fedreleshipping@gmail.com' WHERE ShipperID = 3;

delete shippers_duplicate where ShipperID=10;
--q45
--Create a report that shows the CompanyName and ProductName from all product in the Seafood category
select* from Suppliers
select* from Categories
select
    s.CompanyName, 
    p.ProductName
from 
    Products p
JOIN 
    Suppliers s ON p.SupplierID = s.SupplierID
JOIN 
    Categories c ON p.CategoryID = c.CategoryID
where 
    c.CategoryName = 'Seafood';

--q46
select
    p.CategoryID, 
    s.CompanyName, 
    p.ProductName
from Products AS p
INNER JOIN Suppliers AS s ON p.SupplierID = s.SupplierID
where p.CategoryID = 5;

--q47
DROP TABLE shippers_duplicate;

--q48
select* from Employees

select
    LastName,
    FirstName,
    Title,
    CAST(DATEDIFF(YEAR, BirthDate, GETDATE()) AS VARCHAR) + ' Years' AS Age
FROM Employees;

--q49
select 
    c.CompanyName,
    COUNT(o.OrderID) AS [number of orders since December 31, 1994]
from Customers c
JOIN Orders o 
    ON c.CustomerID = o.CustomerID
where o.OrderDate > '1994-12-31'
group by c.CompanyName
having COUNT(o.OrderID) > 10;
--q50
select* from Products
select (ProductName)+'weighs/is'+(QuantityPerUnit)+'and Cost $'+CAST(CAST(UnitPrice AS INT) AS VARCHAR) from Products
