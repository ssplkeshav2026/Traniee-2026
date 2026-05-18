--1--
select * from Categories
select CategoryName, Description from Categories;

--2--
select * from Customers
select ContactName, CustomerID, CompanyName from Customers where City='London';

--3-- 
select * from Suppliers
select * from Suppliers where Fax IS NOT NULL;

--4--
select * from Orders
select CustomerId from Orders where RequiredDate between 'Jan 1, 1997' and 'Jan 1, 1998' and Freight < 100;

--5--
select * from Customers
select CompanyName , ContactName from Customers where ContactTitle='Owner' and Country in('Mexico','Sweden',' Germany'); 

--6--
select * from Products
select count(*) as Discontinued from Products where Discontinued=0;
select count(*) as Discontinued from Products where Discontinued=1;

--7--
select * from Categories
select CategoryName , Description from Categories where CategoryName like'Co%';

--8--
select * from Suppliers
select CompanyName , City , Country, PostalCode from Suppliers where Address like '%rue%' order by CompanyName;

--9--
select * from [Order Details] 
select ProductID, sum(Quantity) as TotalQuantity from [Order Details] group by ProductID;

--10--
select * from Customers;
select * from Shippers;
select * from Orders
select c.CompanyName, c.Address from Customers c join Orders o on c.CustomerID = o.CustomerID join Shippers s on o.ShipVia = s.ShipperID where s.CompanyName = 'Speedy Express';

--11--
select s.CompanyName, s.ContactName, s.ContactTitle, s.Region from Suppliers s;

--12--
select * from Products
select p.ProductName from Products p join Categories c on p.CategoryID = c.CategoryID where c.CategoryName = 'Condiments';

--13-
select * from Orders
select c.CompanyName from Customers c left join Orders o ON c.CustomerID = o.CustomerID where o.OrderID is null;

--14--
select * from Shippers;
insert into Shippers (CompanyName) values ('Amazon');

--15--
select * from Shippers;
update Shippers set CompanyName = 'Amazon Prime Shipping' where CompanyName = 'Amazon';

--16--
select * from Shippers;
select * from Orders;
select s.CompanyName, round(sum(o.Freight), 0) as TotalFreight from Shippers s join Orders o ON s.ShipperID = o.ShipVia group by s.CompanyName;

--17--
select * from Employees
select LastName + ', ' + FirstName as DisplayName from Employees;

--18--
select * from Customers;
select * from Orders

declare @CustID varchar(10) = 'KAS02';
declare @OrderID int;

if not exists (select 1 from Customers where CustomerID = @CustID)
begin
insert into Customers (CustomerID, CompanyName, ContactName, Country)
    values (@CustID, 'Kashish Pvt Ltd', 'Kashish', 'India');
end

insert into Orders (CustomerID, EmployeeID, OrderDate, ShipVia)
values (@CustID, 1, GETDATE(), 1);

set @OrderID = SCOPE_IDENTITY();

insert into [Order Details] (OrderID, ProductID, UnitPrice, Quantity)
values (@OrderID, 1, 10, 2);

--19--
select * from Products
declare @CustID varchar(10) = 'KAS03';

delete from [Order Details]
where OrderID in (
    select OrderID from Orders where CustomerID = @CustID
);

delete from Orders where CustomerID = @CustID;
    
delete from Customers where CustomerID = @CustID;

--20--
select * from Products;
select ProductName, UnitsInStock as TotalUnits from Products where UnitsInStock > 100;
