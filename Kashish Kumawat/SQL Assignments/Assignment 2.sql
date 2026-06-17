--1--
select * from Categories;
select CategoryName, Description from Categories order by CategoryName;

--2--
select * from Customers;
select ContactName, CompanyName, ContactTitle, Phone from Customers order by Phone;

--3--
select * from Employees;
select upper(FirstName) as FirstName, upper(LastName) as LastName, HireDate from Employees order by HireDate desc;

--4--
select * from Orders;
select top 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight from Orders order by Freight desc;

--5--
select * from Customers;
select lower(CustomerID) as ID from Customers;

--6--
select * from Suppliers;
select CompanyName, Fax, Phone, Country, HomePage from Suppliers order by Country desc, CompanyName asc;

--7--
select * from Customers;
select CompanyName, ContactName from Customers where City = 'Buenos Aires';

--8--
select * from Products;
select ProductName, UnitPrice, QuantityPerUnit from Products where UnitsInStock = 0;

--9--
select * from Customers;
select ContactName, Address, City from Customers where Country not in('Germany', 'Mexico', 'Spain');

--10--
select * from Orders;
select OrderDate, ShippedDate, CustomerID, Freight from Orders where OrderDate = '1996-05-21';

--11--
select * from Employees;
select FirstName, LastName, Country from Employees where Country <> 'USA';

--12--
select * from Orders;
select EmployeeID, OrderID, CustomerID, RequiredDate, ShippedDate from Orders where ShippedDate > RequiredDate;

--13--
select * from Customers;
select City, CompanyName, ContactName from Customers where City like 'A%' or City like 'B%';

--14--
select * from Orders;
select OrderID from Orders where OrderID % 2 = 0;

--15--
select * from Orders;
select * from Orders where Freight > 500;

--16--
select * from Products;
select ProductName, UnitsInStock, UnitsOnOrder, ReorderLevel from Products where ReorderLevel = 0;

--17--
select * from Customers;
select CompanyName, ContactName from Customers where Fax is null;

--18--
select * from Employees;
select FirstName, LastName from Employees where ReportsTo is null;

--19--
select * from Orders;
select OrderID from Orders where OrderID % 2 <> 0;

--20--
select * from Customers;
select CompanyName, ContactName, Fax from Customers where Fax is null order by ContactName;

--21--
select * from Customers;
select City, CompanyName, ContactName from Customers where City like '%L%' order by ContactName;

--22--
select * from Employees;
select FirstName, LastName, BirthDate from Employees where BirthDate between '1950-01-01' and '1959-12-31';

--23--
select * from Employees;
select FirstName, LastName, year(BirthDate) as BirthYear from Employees;

--24--
select * from [Order Details];
select OrderID, count(OrderID) as NumberOfOrders from [Order Details] group by OrderID order by NumberOfOrders desc;

--25--
select * from Suppliers;
select * from Products;
select p.SupplierID, p.ProductName, s.CompanyName from Products p join Suppliers s on p.SupplierID = s.SupplierID where s.CompanyName IN ('Exotic Liquids', 'Specialty Biscuits, Ltd.', 'Escargots Nouveaux') order by p.SupplierID;

--26--
select * from Orders;
select ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress from Orders where ShipPostalCode LIKE '98124%';

--27--
select * from Customers;
select ContactName, ContactTitle, CompanyName from Customers where ContactTitle not like ('%Sales%');

--28--
select * from Employees;
select LastName, FirstName, City from Employees where City <> 'Seattle';

--29--
select * from Customers;
select CompanyName, ContactTitle, City, Country
from Customers
where Country = 'Mexico'or (Country = 'Spain' and City <> 'Madrid');

--30--
select * from Employees;
select FirstName + ' ' + LastName + 'can be reached at x' + Extension as ContactInfo from Employees;

--31--
select * from Customers;
select ContactName from Customers where ContactName not like '_A%';

--32--
select * from Products;
select round(avg(UnitPrice),0) as AveragePrice, sum(UnitsInStock) as TotalStock, max(UnitsOnOrder) as MaxOrder from Products;

--33--
select * from Products;
select * from Suppliers;
select * from Categories;
select p.SupplierID, s.CompanyName, c.CategoryName, p.ProductName, p.UnitPrice from Products p join  Suppliers s on p.SupplierID = s.SupplierID join Categories c on p.CategoryID = c.CategoryID;

--34--
select * from Orders;
select CustomerID, sum(Freight) as TotalFreight from Orders group by CustomerID having sum(Freight) > 200;

--35--
select * from [Order Details];
select o.OrderID, c.ContactName, od.UnitPrice, od.Quantity, od.Discount from [Order Details] od join Orders o on od.OrderID = o.OrderID join Customers c on o.CustomerID = c.CustomerID where od.Discount > 0;

--36--
select * from Employees;
select e.EmployeeID, e.FirstName + ' ' + e.LastName AS Employee, m.FirstName + ' ' + m.LastName AS Manager
from Employees e left join Employees m on e.ReportsTo = m.EmployeeID order by e.EmployeeID;

--37--
select * from Products;
select avg(UnitPrice) as AveragePrice, min(UnitPrice) as MinimumPrice, max(UnitPrice) as MaximumPrice from Products;

--38--
drop view CustomerInfo;
create view CustomerInfo as
select c.CustomerID, c.CompanyName, c.ContactName, c.ContactTitle, c.Address, c.City, c.Country, c.Phone, o.OrderDate, o.RequiredDate, o.ShippedDate from Customers c join Orders o on c.CustomerID = o.CustomerID;

--39--
select * from sys.views where name = 'CustomerInfo';
select * from sys.views where name = 'CustomerDetails';
drop view CustomerDetails;
exec sp_rename 'dbo.CustomerInfo', 'CustomerDetails';

--40--
select * from sys.views where name = 'ProductDetails';
drop view ProductDetails;
create view ProductDetails as
select p.ProductID, s.CompanyName, p.ProductName, c.CategoryName, c.Description, p.QuantityPerUnit, p.UnitPrice, p.UnitsInStock, p.UnitsOnOrder, p.ReorderLevel, p.Discontinued
from Products p join Suppliers s on p.SupplierID = s.SupplierID join Categories c on p.CategoryID = c.CategoryID;

--41--
drop view CustomerDetails;

--42--
select * from Categories;
select left(CategoryName, 5) as ShortInfo from Categories;

--43--
select * from sys.tables where name = 'Shippers_Duplicate';
drop table Shippers_Duplicate;
select * into Shippers_Duplicate from Shippers where 1 = 0;

insert into Shippers_Duplicate (CompanyName, Phone)
select CompanyName, Phone from Shippers;

--44--
select ShipperID, CompanyName, Phone, CompanyName + '@gmail.com' as Email from Shippers_Duplicate;

--45--
select * from Products;
select * from Suppliers;
select * from Categories;
select s.CompanyName, p.ProductName from Products p
join Suppliers s on p.SupplierID = s.SupplierID
join Categories c on  p.CategoryID = c.CategoryID where c.CategoryName = 'Seafood';

--46--
select * from Customers;
select p.CategoryID, s.CompanyName, p.ProductName from Products p
join Suppliers s on p.SupplierID = s.SupplierID where p.CategoryID = 5;

--47--
drop table Shippers_Duplicate;

--48--
select * from Employees;
select LastName, FirstName, Title, cast(datediff(year, BirthDate, getdate()) as varchar) + ' Years' as Age from Employees;

--49--
select * from Customers;
select * from Orders;
select c.CompanyName, count(o.OrderID) as NumberOfOrders from Customers c
join Orders o on c.CustomerID = o.CustomerID
where o.OrderDate > '1994-12-31' group by c.CompanyName having count(o.OrderID) > 10;

--50--
select * from Products;


select ProductName + 'weighs/is '+ QuantityPerUnit + ' and cost $' + cast(UnitPrice as varchar) as ProductInfo from Products;