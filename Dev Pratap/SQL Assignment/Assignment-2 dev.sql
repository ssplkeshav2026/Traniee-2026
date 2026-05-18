use northWind;

-- 1. Create a report that shows the CategoryName and Description from the categories table sorted by CategoryName.
select CategoryName, Description 
from Categories 
order by CategoryName asc;

-- 2. Create a report that shows the ContactName, CompanyName, ContactTitle and Phone number from the customers table sorted by Phone.
select ContactName, ContactTitle,Phone 
from Customers 
order by Phone asc;

-- 3. Create a report that shows the capitalized FirstName and capitalized LastName renamed as FirstName and Lastname respectively and HireDate from the employees table sorted from the newest to the oldest employee.
select UPPER(FirstName) as FirstName,UPPER(Lastname) as Lastname, HireDate  
from Employees
order by HireDate desc;


-- 4. Create a report that shows the top 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight from the orders table sorted by Freight in descending order.
select top 10 OrderID,OrderDate,ShippedDate, CustomerID, Freight  from Orders order by Freight desc;


-- 5. Create a report that shows all the CustomerID in lowercase letter and renamed as ID from the customers table.
select LOWER(CustomerID) as ID from Customers;

-- 6. Create a report that shows the CompanyName, Fax, Phone, Country, HomePage from the suppliers table sorted by the
-- Country in descending order then by CompanyName in ascending order.
select  CompanyName, Fax, Phone, Country, HomePage 
from Suppliers
order by Country desc , CompanyName asc;

-- 7. Create a report that shows CompanyName, ContactName of all customers from ‘Buenos Aires' only.
select CompanyName, ContactName from Customers where city='Buenos Aires';


-- 8. Create a report showing ProductName, UnitPrice, QuantityPerUnit of products that are out of stock.
select ProductName, UnitPrice, QuantityPerUnit 
from Products
where UnitsInStock=0;

-- 9. Create a report showing all the ContactName, Address, City of all customers not from Germany, Mexico, Spain.
select ContactName, Address, City
from Customers
where Country not in('Germany', 'Mexico', 'Spain')


-- 10. Create a report showing OrderDate, ShippedDate, CustomerID, Freight of all orders placed on 21 May 1996. 
select OrderDate, ShippedDate, CustomerID, Freight
from Orders
where OrderDate = '1996-05-21';

-- 11. Create a report showing FirstName, LastName, Country from the employees not from United States.
select FirstName, LastName, Country 
from Employees 
where Country != 'USA';



-- 12. Create a report that shows the EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate from all orders shipped later
-- than the required date.
select EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate
from Orders 
where ShippedDate>RequiredDate;


--13. Create a report that shows the City, CompanyName, ContactName of customers from cities starting with A or B.
select City, CompanyName, ContactName
from Customers 
where City like 'A%'or City like 'B%';


-- 14. Create a report showing all the even numbers of OrderID from the orders table.
select *
from Orders 
where OrderID %2 = 0;


-- 15. Create a report that shows all the orders where the freight cost more than $500.
select *
from Orders 
where freight > 500;

-- 16. Create a report that shows the ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel of all products that are up for
--reorder.
select ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel
from Products 
where ReorderLevel != 0;


-- 17. Create a report that shows the CompanyName, ContactName number of all customer that have no fax number.
select CompanyName, ContactName number
from Customers
where Fax is NULL;

-- 18. Create a report that shows the FirstName, LastName of all employees that do not report to anybody.
select FirstName, LastName
from Employees
where ReportsTo is NULL;


-- 19. Create a report showing all the odd numbers of OrderID from the orders table.
select *
from Orders
where OrderID%2=1;

-- 20. Create a report that shows the CompanyName, ContactName, Fax of all customers that do not have Fax number and sorted
-- by ContactName. 
select  CompanyName, ContactName, Fax
from Customers
where Fax is null 
order by ContactName;

-- 21. Create a report that shows the City, CompanyName, ContactName of customers from cities that has letter L in the name
-- sorted by ContactName.
select  City, CompanyName, ContactName
from Customers
where City like '%L%' 
order by ContactName;

-- 22. Create a report that shows the FirstName, LastName, BirthDate of employees born in the 1950s.
select  FirstName, LastName, BirthDate
from Employees
where BirthDate between '1950-01-01' and '1959-12-31' ;


-- 23. Create a report that shows the FirstName, LastName, the year of Birthdate as birth year from the employees table.
select  FirstName, LastName, YEAR(BirthDate) as 'birth year'
from Employees ;

-- 24. Create a report showing OrderID, total number of Order ID as NumberofOrders from the orderdetails table grouped by
-- OrderID and sorted by NumberofOrders in descending order. HINT: you will need to use a Groupby statement.

select  OrderID, count(OrderID) as 'NumberofOrders'
from [Order Details]
group by OrderID
order by NumberofOrders desc;


-- 25. Create a report that shows the SupplierID, ProductName, CompanyName from all product Supplied by Exotic Liquids,
-- Specialty Biscuits, Ltd., Escargots Nouveaux sorted by the supplier ID *************
select  s.SupplierID, p.ProductName, s.CompanyName
from Suppliers as s
join  Products as p on s.SupplierID = p.SupplierID
where s.CompanyName in('Exotic Liquids','Specialty Biscuits Ltd.', 'Escargots Nouveaux')
order by s.SupplierID
;


-- 26. Create a report that shows the ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress of all orders
-- with ShipPostalCode beginning with "98124".
select  ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress
from Orders 
where ShipPostalCode like '98124%' ;


-- 27. Create a report that shows the ContactName, ContactTitle, CompanyName of customers that the has no "Sales" in their
-- ContactTitle.
select  ContactName, ContactTitle, CompanyName
from  Customers
where ContactTitle not like '%Sales%' ;


-- 28. Create a report that shows the LastName, FirstName, City of employees in cities other than "Seattle";
select   LastName, FirstName,City
from  Employees
where City != 'Seattle' ;

-- 29. Create a report that shows the CompanyName, ContactTitle, City, Country of all customers in any city in Mexico or other
-- cities in Spain other than Madrid.
select   CompanyName, ContactTitle, City, Country
from  Customers
where Country in ('mexico','Spain' )  And 
City not in('Madrid') ;

--30
select * from Employees;
select concat(FirstName,' ',LastName,' can be reached at x',Extension)as Contactinfo from Employees;

--31. Create a report that shows the ContactName of all customers that do not have letter A as the second alphabet in their
--Contactname.
select   ContactName
from  Customers
where Contactname not like '_A%' ;

-- 32. Create a report that shows the average UnitPrice rounded to the next whole number, total price of UnitsInStock and
-- maximum number of orders from the products table. All saved as UnitPrice, TotalStock and MaxOrder respectively.

select   ROUND(AVG(UnitPrice),2) as UnitPrice , sum(UnitsInStock) as TotalStock ,max(UnitsOnOrder) as MaxOrder
from  Products ;


-- 33. Create a report that shows the SupplierID, CompanyName, CategoryName, ProductName and UnitPrice from the products,
--suppliers and categories table.
select * from Products;
select   p.SupplierID, CompanyName, CategoryName, ProductName , UnitPrice
from  Products  p

INNER JOIN suppliers s ON p.SupplierID = s.SupplierID
INNER JOIN categories c ON p.CategoryID = c.CategoryID
;


-- 34. Create a report that shows the CustomerID, sum of Freight, from the orders table with sum of freight greater $200, grouped
-- by CustomerID. HINT: you will need to use a Groupby and a Having statement.
select * from Products;
select   CustomerID,sum(Freight) as 'sum of Freight' 
from  orders 
group by CustomerID
having sum(Freight) >200;

-- 35. Create a report that shows the OrderID ContactName, UnitPrice, Quantity, Discount from the order details, orders and
-- customers table with discount given on every purchase.

select   o.OrderID ,ContactName, UnitPrice, Quantity,Discount
from  [Order Details]  od

INNER JOIN orders o ON od.OrderID = o.OrderID
INNER JOIN customers c ON o.CustomerID = c.CustomerID
;

--36. Create a report that shows the EmployeeID, the LastName and FirstName as employee, and the LastName and FirstName of
--who they report to as manager from the employees table sorted by Employee ID. HINT: This is a SelfJoin.
select e1.EmployeeID ,CONCAT(e1.LastName, ' ', e1.FirstName) as  employee, e2.FirstName+' '+e2.LastName as manager
from  Employees e1 
left JOIN Employees e2 ON e1.ReportsTo = e2.EmployeeID;

select * from Employees;



-- 37. Create a report that shows the average, minimum and maximum UnitPrice of all products as AveragePrice, MinimumPrice
-- and MaximumPrice respectively.
select avg(UnitPrice) as AveragePrice ,min(UnitPrice) as  MinimumPrice,max(UnitPrice) as MaximumPrice
from  Products;

-- 38. Create a view named CustomerInfo that shows the CustomerID, CompanyName, ContactName, ContactTitle, Address, City,
-- Country, Phone, OrderDate, RequiredDate, ShippedDate from the customers and orders table. HINT: Create a View.
CREATE VIEW CustomerInfo as 
SELECT c.CustomerID, CompanyName, ContactName, ContactTitle, Address, City,Country, Phone, OrderDate, RequiredDate, ShippedDate
FROM Customers c
inner join Orders o on c.CustomerID = o.CustomerID;


-- 39. Change the name of the view you created from customerinfo to customer details.

EXEC sp_rename 'CustomerInfo', 'customer details';


-- 40. Create a view named ProductDetails that shows the ProductID, CompanyName, ProductName, CategoryName, Description,
-- QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued from the supplier, products and
-- categories tables. HINT: Create a View
CREATE VIEW ProductDetails as 
SELECT ProductID, CompanyName, ProductName, CategoryName, Description, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued
FROM Suppliers s
inner join products p on s.SupplierID  = p.SupplierID
inner join Categories c on c.CategoryID = p.CategoryID;

 -- 41. Drop the customer details view.
 DROP VIEW [customer details];

-- 42. Create a report that fetch the first 5 character of categoryName from the category tables and renamed as ShortInfo
select left(categoryName,5) as ShortInfo from Categories;


-- 43. Create a copy of the shipper table as shippers_duplicate. Then insert a copy of shippers data into the new table HINT: Create
-- a Table, use the LIKE Statement and INSERT INTO statement. 
select * into shippers_duplicate from Shippers;

select * from shippers_duplicate;

-- 44. 
alter table shippers_duplicate add Email varchar(50);
update shippers_duplicate set Email ='speedyexpress.gmail.com' where ShipperID = 1;
update shippers_duplicate set Email ='unitedpackage.gmail.com' where ShipperID = 2;
update shippers_duplicate set Email ='federalshipping.gmail.com' where ShipperID = 3;
select * from shippers_duplicate;

-- 45. Create a report that shows the CompanyName and ProductName from all product in the Seafood category.

select CompanyName, ProductName
from Products p
JOIN Suppliers s on s.SupplierID = p.SupplierID 
JOIN Categories c on c.CategoryID = p.CategoryID 
where c.CategoryName = 'Seafood'
;



-- 46. Create a report that shows the CategoryID, CompanyName and ProductName from all product in the categoryID 5.
select ca.CategoryID, CompanyName , ProductName 
from Products p
left JOIN Categories ca on ca.CategoryID = p.CategoryID 
left JOIN Suppliers  s on s.SupplierID = p.SupplierID 
where ca.CategoryID = 5;

-- 47. Delete the shippers_duplicate table.
drop table shippers_duplicate;

-- 48.
select FirstName,LastName,Title,CONCAT( year(CURRENT_TIMESTAMP)-year( BirthDate),' Years' )as Age from Employees;

-- 49. Create a report that the CompanyName and total number of orders by customer renamed as number of orders since
-- December 31, 1994. Show number of Orders greater than 10. 

select CompanyName ,count(o.CustomerID) as'number of orders'
from Customers c
left JOIN Orders o on c.CustomerID = o.CustomerID 
where o.OrderDate >'1994-12-31'
group by CompanyName 
having count(o.OrderID)>10;

-- 50
select concat(ProductName,' weighs/is ',QuantityPerUnit,'and cost $', cast(UnitPrice as int ) ) as ProductInfo from Products;

