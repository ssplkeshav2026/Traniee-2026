--1--
select * from Categories;
select CategoryName,Description  from Categories order by CategoryName asc;

--2--
select * from Customers;
select ContactName, CompanyName, ContactTitle,Phone from customers order by Phone asc ;

--3--
select * from Employees;
select upper(FirstName) as FirstName,upper(LastName) as LastName,HireDate from Employees order by HireDate desc;

--4--
select * from Orders;
select top 10 OrderID,OrderDate,ShippedDate,CustomerID,Freight from Orders order by Freight desc;

--5--
select * from Customers;
select lower(CustomerID) as ID from Customers;

--6--
select * from Suppliers;
select  CompanyName, Fax, Phone, Country, HomePage from Suppliers order by Country desc,CompanyName asc;

--7--
select * from Customers;
select CompanyName, ContactName from Customers where City='Buenos Aires';

--8--
select * from Products;
select ProductName, UnitPrice, QuantityPerUnit from Products where UnitsInStock=0;

--9--
select * from Customers;
select ContactName, Address, City from Customers where city not in ('Germany', 'Mexico', 'Spain');

--10--
select * from Orders;
select  OrderDate, ShippedDate, CustomerID, Freight from Orders where OrderDate='1996-05-21' ;

--11--
select * from Employees;
select FirstName, LastName, Country from Employees where Country not in ('USA');

--12--
select * from Orders;
select EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate from Orders where ShippedDate>RequiredDate;

--13--
select * from Customers;
select City, CompanyName, ContactName from Customers where city like 'A%' or city like 'B%';

--14--
select * from Orders;
select OrderID from Orders where OrderID %2 =0;

--15--
select * from Orders;
select freight from Orders where freight>500;

--16--
select * from Products;
select ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel from Products where UnitsInStock <= ReorderLevel and Discontinued=0; 

--17--
select * from Customers;
select CompanyName, ContactName from Customers where Fax is null;

--18--
select * from Employees;
select FirstName, LastName from Employees where ReportsTo is null;

--19--
select * from orders;
select OrderID from orders where OrderID %2 = 1 ;

--20--
select * from Customers;
select CompanyName, ContactName, Fax from Customers where Fax not in ('NULL') order by ContactName asc;

--21--
select * from customers;
select City, CompanyName, ContactName from customers WHERE City like '%L%' order by ContactName asc;	

--22--
select * from Employees;
select FirstName, LastName, BirthDate from Employees where BirthDate BETWEEN '1950-01-01' AND '1959-12-31';

--23--
select *  from Employees;
select FirstName, LastName,Year(BirthDate) as birthyear  from Employees;

--24--
select * from [Order Details];
select OrderID,count(OrderID) as NumberofOrders from [Order Details] 
group by OrderID  order by NumberofOrders desc;

--25--
select * from Products;
select * from Suppliers;

select s.SupplierID, p.ProductName,s.CompanyName
from Suppliers as s
join Products as p
on s.SupplierID=p.SupplierID
where s.CompanyName in('Exotic Liquids', 'Specialty Biscuits, Ltd.', 'Escargots Nouveaux')
order by s.SupplierID;

--26--
select * from Orders;
select ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress from Orders where ShipPostalCode like '98124%';

--27--
select * from Customers;
select ContactName, ContactTitle, CompanyName from Customers where  ContactTitle not like '%Sales%';

--28--
select * from Employees;
select LastName, FirstName, City from Employees where city not in ('Seattle');

--29--
select * from Customers;
select CompanyName, ContactTitle, City, Country from Customers where Country = 'Mexico' or (Country = 'Spain' AND City <> 'Madrid');

--30--
select * from Employees;
select CONCAT(FirstName,' ',LastName,' ', 'can be reached at x',Extension) as Contactinfo from Employees;

--31--
select * from Customers;
select ContactName from Customers where ContactName not like '_a%';

--32--
 select * from Products;
select 
    ceiling(avg(UnitPrice)) as AveragePrice,
    sum(UnitsInStock) as TotalStock,
    max(UnitsOnOrder) as MaxOrder
from Products;

--33--
select * from Products;
select * from Categories;
select * from Suppliers;

select s.SupplierID, s.CompanyName, c.CategoryName, p.ProductName, p.UnitPrice
from Products p
join  Suppliers s on p.SupplierID = s.SupplierID
join Categories c on p.CategoryID = c.CategoryID;

--34-- 
select * from Orders;

select CustomerID, sum(Freight) as TotalFreight
from Orders
group by CustomerID
having sum(Freight) > 200;

--35--
select od.OrderID, c.ContactName, od.UnitPrice, od.Quantity, od.Discount
from [Order Details] od
join Orders o on od.OrderID = o.OrderID
join Customers c on c.CustomerID = o.CustomerID
where od.Discount <> 0;

--36--
select * from Employees;
select 
    e.EmployeeID, 
    e.LastName + ', ' + e.FirstName AS employee, 
    m.LastName + ', ' + m.FirstName AS manager
from employees e
left join employees m 
on e.ReportsTo = m.EmployeeID
order by e.EmployeeID asc;

--37--
select * from Products;
select avg(UnitPrice) as AveragePrice,min(UnitPrice) as MinimumPrice,max(UnitPrice) as MaximumPrice
from Products;

--38--
select * from Customers;
select * from Orders;

create view CustomerInfo as
select C.CustomerID, C.CompanyName, C.ContactName, C.ContactTitle, C.Address, C.City, C.Country, C.Phone, 
    O.OrderDate, O.RequiredDate, O.ShippedDate
from Customers C
join Orders O on C.CustomerID = O.CustomerID;


--39--
exec sp_rename 'CustomerInfo','customer details';

--40--
Create a view named ProductDetails that shows the ProductID, CompanyName, ProductName, CategoryName, Description, 
QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued from the supplier, products and 
categories tables. HINT: Create a View 

select * from Products;
select * from Suppliers;
select * from Categories;

create view ProductDetails as
select p.ProductID,p.ProductName,p.QuantityPerUnit,p.UnitPrice,p.UnitsInStock,p.UnitsOnOrder,p.ReorderLevel,p.Discontinued ,s.CompanyName, c.CategoryName,c.Description
from Products p
join Suppliers s on p.SupplierID = s.SupplierID
join Categories c on p.CategoryID = c.CategoryID;

--41--
Drop the customer details view. 
drop view [customer details];

--42-- 
select * from Categories;
select SUBSTRING(categoryName, 1,5) as ShortInf from Categories;

--43--
select * from Shippers;
select * into shippers_duplicate from Shippers;
select * from shippers_duplicate;

--44--
alter table. shippers_duplicate
add Email VARCHAR(100);

update shippers_duplicate
set Email = 'speedyexpress@gmail.com'
where ShipperID = 1;

update shippers_duplicate
set Email = 'unitedpackage@gmail.com'
where ShipperID = 2;

update shippers_duplicate
set Email = 'federalshipping@gmail.com'
where ShipperID = 3;

--45--
select * from Categories;
select * from Products;
select * from Suppliers;
select s.CompanyName, p.ProductName
from Products p
join Categories c on p.CategoryID = c.CategoryID
join Suppliers s on p.SupplierID = s.SupplierID
where c.CategoryName = 'Seafood';

--46--
select * from Products;      ProductName,CategoryID
select * from Suppliers;     CompanyName


select p.CategoryID, s.CompanyName, p.ProductName
from Products as p
join Suppliers as s on p.SupplierID = s.SupplierID
where p.CategoryID = 5;

--47--
select * from shippers_duplicate;

drop table shippers_duplicate;

--48--
select * from Employees;
select LastName,FirstName,Title,year(getDate())-year(BirthDate) as Age from Employees;

--49--
select * from Orders;
select * from Customers;

select c.CompanyName,count(o.OrderId) as[Number of Orders]
from Customers as c
join Orders as o on c.CustomerID=o.CustomerID
where o.OrderDate>'1994-12-31'
group by c.CompanyName
having count(o.OrderId)>10;

--50--
select * from Products;
select CONCAT(ProductName,' ','weighs/is',' ',QuantityPerUnit,' ','and cost $',cast(UnitPrice as int)) as ProductInfo from Products;