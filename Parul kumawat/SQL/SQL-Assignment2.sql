select * from Categories;
select * from CustomerDemographics;
select * from Customers;
select * from Employees;
select * from EmployeeTerritories;
select * from [Order Details];
select * from Orders;
select * from Products;
select * from Region;
select * from Shippers;
select * from Suppliers;
select * from Territories;

--1--
select CategoryName,Description from Categories order by CategoryName asc;
--2--
select ContactName, CompanyName, ContactTitle,Phone from Customers order by Phone asc;
--3--
select upper(FirstName) as FirstName,upper(LastName) as LastName,HireDate 
from Employees order by HireDate desc;
--4--
select top 10 OrderId,OrderDate,ShippedDate,CustomerID, Freight 
from Orders order by Freight desc;
--5--
select lower(CustomerID) as ID from Customers;
--6--
select  CompanyName, Fax, Phone, Country, HomePage
from Suppliers order by Country desc, CompanyName asc;
--7--
select CompanyName, ContactName from Customers where city = 'Buenos Aires';
--8--
select ProductName, UnitPrice, QuantityPerUnit from Products 
where UnitsInStock = 0;
--9--
select ContactName, Address, City from Customers
where Country not in('Germany','Mexico','Spain');
--10--
select OrderDate, ShippedDate, CustomerID, Freight 
from Orders where OrderDate = '1996-05-21';
--11--
select FirstName, LastName, Country from Employees
where Country not in('USA');
--12--
select EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate
from Orders
where ShippedDate > RequiredDate;
--13--
select City, CompanyName, ContactName from Customers
where City like 'A%' or City like 'B%'; 
--14--
select * from Orders where OrderID % 2 = 0;
--15--
select * from Orders where Freight > $500;
--16--
select * from Products;
select ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel 
from Products where UnitsInStock <= ReorderLevel and Discontinued = 0;
--17--
select * from Customers;
select  CompanyName, ContactName,Phone 
from Customers where Fax is null; 
--18--
select * from Employees;
select FirstName, LastName from Employees where ReportsTo is null;
--19--
select * from Orders where OrderID % 2 = 1;
--20--
select * from Customers;
select  CompanyName, ContactName, Fax
from Customers where Fax is null  order by ContactName asc;
--21--
select  City, CompanyName, ContactName from Customers
where City like '%l%' order by ContactName asc;
--22--
select * from Employees;
select FirstName, LastName, BirthDate from Employees
where BirthDate between '1950-01-01' and '1959-12-31';
--23--
select FirstName, LastName, Year(BirthDate) as 'birth year' 
from Employees;
--24--
select * from [Order Details];
select  OrderID, count(OrderID) as NumberofOrders from [Order Details]
group by OrderID order by NumberofOrders desc;
--25--
select * from Suppliers;
select supp.SupplierID, pro.ProductName, supp.CompanyName 
from Suppliers supp
join Products pro on supp.SupplierID = pro.SupplierID
where supp.CompanyName in('Exotic Liquids','Specialty Biscuits, Ltd.','Escargots Nouveaux')
order by supp.SupplierID;
--26--
select * from Orders;
select ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress
from Orders
where ShipPostalCode like '98124%';
--27--
select * from Customers;
select  ContactName, ContactTitle, CompanyName 
from  Customers
where ContactTitle not like '%Sales%';
--28--
select * from Employees;
select  LastName, FirstName, City from Employees
where City not in('Seattle');
--29--
select * from Customers;
select CompanyName, ContactTitle, City, Country 
from Customers
where Country in('Mexico','Spain') and City <>'Madrid';
--30--
select * from Employees;
select concat(FirstName,' ',LastName,' can be reached at x',Extension) as ContactInfo from Employees

--31--
select ContactName from Customers
where ContactName not like '_A%';
--32--
select * from Products;
select round(avg(UnitPrice),2) as AveragePrice,sum(UnitsInStock) as TotalStock,max(UnitsOnOrder) as MaxOrder
from Products;

--33--
select * from Products;
select * from Categories;
select * from Suppliers;

select  supp.SupplierID, supp.CompanyName, cat.CategoryName, pro.ProductName, pro.UnitPrice
from Products as pro
join Suppliers as supp on  supp.SupplierID = pro.SupplierID
join Categories as cat on cat.CategoryID = pro.CategoryID;

--34--
select * from Orders;
select CustomerID, sum(Freight) as TotalFreight from Orders
group by CustomerID
having sum(Freight) > 200;

--35--
select * from Orders;
select * from [Order Details];
select * from Customers;
select  ord.OrderID, cust.ContactName, od.UnitPrice, od.Quantity, od.Discount
from [Order Details] as od 
join Orders as ord on od.OrderID = ord.OrderID
join Customers as cust on ord.CustomerID = cust.CustomerID

--36--
select * from Employees;
select emp.EmployeeId,emp.FirstName+' '+emp.LastName as Employee,
m.EmployeeId,m.FirstName+' '+m.LastName as Manager
from Employees emp
left join Employees m on emp.ReportsTo = m.EmployeeID
order by emp.EmployeeID;

--37--
select * from Products;
select avg(UnitPrice) as AveragePrice,min(UnitPrice) as  MinimumPrice ,max(UnitPrice) as MinimumPrice
from Products;

--38--
select * from Customers;
Select * from Orders;
create view CustomerInfo as 
select cust.CustomerID,cust.CompanyName, cust.ContactName, cust.ContactTitle,cust.Address,cust.City,cust.Country,cust.Phone,ord.OrderDate,ord.RequiredDate,ord.ShippedDate
from Customers cust
inner join Orders ord on cust.CustomerID = ord.CustomerID

--39--
exec sp_rename 'CustomerInfo','Customer Details';

--40--
select * from Suppliers;
Select * from Products;
Select * from Categories;
create view ProductDetails as
select pro.ProductID,supp.CompanyName,pro.ProductName,cat.CategoryName,cat.Description,pro.QuantityPerUnit,pro.UnitPrice,pro.UnitsInStock,pro.UnitsOnOrder,pro.ReorderLevel,pro.Discontinued
from Products pro
inner join Suppliers supp on pro.SupplierID = supp.SupplierID
inner join Categories cat on pro.CategoryID = cat.CategoryID

--41--
drop view [Customer Details];

--42--
select * from Categories;
select left(CategoryName,5) as [short info] from Categories;

--43--

select * into shippers_duplicate from Shippers;
select * from shippers_duplicate;

--44--
alter table shippers_duplicate 
add Email varchar(100)
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
Select * from Products;
Select * from Suppliers;

select supp.CompanyName, pro.ProductName
from Products pro 
join Categories cat on pro.CategoryID = cat.CategoryID
join Suppliers supp on pro.SupplierID = supp.SupplierID
where cat.CategoryName = 'Seafood';

--46--
select pro.CategoryID, supp.CompanyName, pro.ProductName 
from Products pro
join Suppliers supp on pro.SupplierID = supp.SupplierID
where pro.CategoryID = 5;

--47--
drop table shippers_duplicate;

--48--
select * from Employees;
select LastName, FirstName, Title,  year(getDate()) - year(BirthDate)  as Age
from Employees;

--49--
select * from Orders;
select * from Customers;

select cust.CompanyName, count(ord.OrderId) as [Number of Orders]
from Customers cust
join Orders ord on cust.CustomerID = ord.CustomerID
where ord.OrderDate > '1994-12-31'
group by cust.CompanyName
having count(ord.OrderId) > 10;

--50--
select * from Products;
select concat(ProductName,' weighs/is ',QuantityPerUnit,' and cost $',cast(UnitPrice as int)) as ProductInfo from Products
