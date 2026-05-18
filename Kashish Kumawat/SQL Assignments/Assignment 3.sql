--1--
select * from Customers;

--2--
select * from Products;
select ProductName, UnitPrice, UnitsInStock from Products where Discontinued=0;

--3--
select * from Products;
select ProductName, UnitPrice from Products where UnitPrice > 50 order by UnitPrice desc;

--4--
select * from Customers;
select CustomerID, CompanyName, Country from Customers where Country in('Germany','USA','France');

--5---
select * from Products;
select ProductName, CategoryID from Products where ProductName like 'C%';

--6--
select * from Orders;
select OrderId, CustomerID, OrderDate from Orders where year(OrderDate) = 1997;

--7--
select * from Products;
select ProductName, UnitPrice, UnitsInStock from Products where UnitsInStock =0 or UnitPrice < 10;

--8--
select * from Employees;
select FirstName, LastName, Title from Employees where LastName between 'D' and 'M';

--9--
select * from Products;
select top 10 ProductName, UnitPrice from Products order by UnitPrice desc;

--10--
select * from Orders;
select OrderID, CustomerID, OrderDate from Orders where ShippedDate is null;

--11--
select * from Products;
select * from Categories;
select p.ProductName, c.CategoryName from Products p inner join Categories c on p.CategoryID = c.CategoryID;

--12--
select * from Orders;
select * from Customers;
select o.OrderID, o.OrderDate, c.CompanyName, c.ContactName from Orders o inner join Customers c on o.CustomerID = c.CustomerID;

--13--
select * from Products;
select * from Suppliers;
select p.ProductName, s.CompanyName, p.UnitPrice from Products p inner join Suppliers s on p.SupplierID = s.SupplierID;

--14--
select * from [Order Details];
select * from Products;
select od.OrderID, p.ProductName, od.Quantity, od.UnitPrice from [Order Details] od inner join Products p on od.ProductID = p.ProductID;

--15--
select * from Employees;
select e.EmployeeID, e.FirstName, e.LastName, m.FirstName as ManagerFirstName, m.LastName as ManagerLastName from Employees e left join Employees m on e.ReportsTo = m.EmployeeID;

--16--
select * from Customers;
select * from Orders;
select c.CustomerID, c.CompanyName, o.OrderID from Customers c left join Orders o on c.CustomerID = o.CustomerID;

--17--
select * from Orders;
select * from Customers;
select o.OrderID, c.CompanyName, e.FirstName + ' ' + e.LastName as EmployeeName from Orders o inner join Customers c
on o.CustomerID = c.CustomerID inner join Employees e on o.EmployeeID = e.EmployeeID;

--18--
select * from Products;
select * from Categories;
select p.ProductName, c.CategoryName from Products p left join Categories c on p.CategoryID = c.CategoryID;

--19--
select * from Products;
select * from Categories;
select * from [Order Details];
select od.OrderID, p.ProductName, od.Quantity, c.CategoryName from [Order Details] od inner join Products p on od.ProductID = p.ProductID inner join Categories c on p.CategoryID = c.CategoryID;

--20--
select * from Customers;
select * from Orders;
select top 100 c.CustomerID, o.OrderID from Customers c cross join Orders o;

--21--
select * from Products;
select count(*) as TotalProducts from Products;

--22--
select * from Products;
select round(avg(UnitPrice),2) as Average from Products;

--23--
select * from Products;
select min(UnitPrice) as MinPrice , max(UnitPrice) as MaxPrice from Products;

--24--
select * from Products;
select CategoryID, count(*) as ProductCount from Products group by CategoryID;

--25-- 
select * from   Categories;
select * from Products;
select c.CategoryName,count(p.ProductID)  as ProductCount from Categories c inner join Products p on c.CategoryID=p.CategoryID group by c.CategoryName;
 
--26--
select * from [Order Details];
select ProductID , sum(Quantity) as TotalQuantity  from [Order Details] group by ProductID;

--27--
select * from Categories ;
select * from Products;
select c.CategoryName, count(p.ProductID) as ProductCount from Categories c inner join Products p on c.CategoryID = p.ProductID group by c.CategoryName having count(p.ProductID) > 10;

--28--
select * from [Order Details];
select OrderID, sum(UnitPrice * Quantity * (1 - Discount)) as TotalAmount from [Order Details] group by OrderID;

--29--
insert into Categories (CategoryName, Description) values('Organic Foods', 'Certified organic products');

--30--
insert into Products (ProductName, SupplierID, CategoryID, UnitPrice, UnitsInStock, Discontinued)
values ('Green Tea', 1, 1, 15.00, 50, 0);

--31--
select * from Products;
update Products set UnitPrice = UnitPrice * 1.10 where CategoryID = 1;

--32--
select * from Customers;
update Customers set phone='030-12345678' where CustomerID='ALFKI';

--33--
select * from Products;
update Products set Discontinued = 1 where UnitsInStock = 0;

--34--
delete from Products where Discontinued = 1 and ProductID not in (
    select ProductID from [Order Details]
);

--35--
begin try
    begin transaction;
    insert into Customers (CustomerID, CompanyName)
    values('01', 'Kashish');

    insert into Orders (CustomerID, OrderDate)
    values('NEW01', GETDATE());

    commit transaction;
end try
begin catch
    print 'Error occurred';
end catch;

--36--
select * from Products;
select ProductName, UnitPrice from Products where UnitPrice > (
        select avg(UnitPrice) from Products
);

--37--
select * from Customers;
select CustomerID, CompanyName from Customers c where exists (
    select 1 from Orders o where o.CustomerID = c.CustomerID
);

--38--
select ProductName from Products where SupplierID in (
    select SupplierID from Suppliers where Country = 'Germany'
);

--39--
with AvgOrderValue as (
    select avg(UnitPrice * Quantity) as AvgValue from [Order Details]
)
select od.OrderID from [Order Details] od, AvgOrderValue group by od.OrderID, AvgValue having sum(od.UnitPrice * od.Quantity) > AvgValue;

--40--
with CustomerOrders as (
    select CustomerID, count(*) as TotalOrders from Orders group by CustomerID
)
select CustomerID, TotalOrders from CustomerOrders where TotalOrders > 10;

--41--
select p.CategoryID, p.ProductName, p.UnitPrice from Products p where p.UnitPrice = (
   select max(UnitPrice) from Products where CategoryID = p.CategoryID
);

--42--
select CustomerID, CompanyName from Customers c where not exists (
           select 1 from Orders o where o.CustomerID = c.CustomerID
);

--43--
create view vw_ProductList as select p.ProductID, p.ProductName, c.CategoryName, p.UnitPrice from Products p inner join Categories c 
on p.CategoryID = c.CategoryID where p.Discontinued = 0;

--44--
create view vw_OrderSummary as select o.OrderID, c.CompanyName as CustomerName, o.OrderDate, count(od.ProductID) as TotalItems from Orders o
inner join [Order Details] od on o.OrderID = od.OrderID group by o.OrderID, c.CompanyName, o.OrderDate;

--45--
create procedure usp_GetProductsByCategory @CategoryID int as 
begin
    select * from Products where CategoryID = @CategoryID;
end;

--46--
create procedure usp_GetCustomerOrders
    @CustomerID char(5) as
begin
    select o.OrderID, o.OrderDate,od.ProductID, od.Quantity,od.UnitPrice from Orders o
    inner join [Order Details] od on o.OrderID = od.OrderID where o.CustomerID = @CustomerID;
end;

--47--
create procedure usp_AddCategory
    @CategoryName varchar(50), @Description varchar(255), @NewCategoryID int output as
begin
    insert into Categories (CategoryName, Description)
    values (@CategoryName, @Description);
    set @NewCategoryID = scope_Identity();
end;

--48--
create procedure usp_Upd    ateProductPrice @ProductID int, @NewPrice money as
begin
    if @NewPrice <= 0
   begin
        raiserror ('Price must be greater than 0', 16, 1);
        return;
   end
update Products set UnitPrice = @NewPrice where ProductID = @ProductID; 
end;

-- Q49
create procedure usp_GetEmployeeSales as
begin
    select e.EmployeeID, e.FirstName + ' ' + e.LastName AS FullName,
    sum(od.UnitPrice * od.Quantity * (1 - od.Discount)) as TotalSales from Employees e
    inner join Orders o on e.EmployeeID = o.EmployeeID
    inner join [Order Details] od on o.OrderID = od.OrderID
    group by e.EmployeeID, e.FirstName, e.LastName;
end;

-- Q50
create procedure usp_GetMonthlyOrderStats
    @Year int,
    @Month int as
begin
    select count(distinct o.OrderID) as TotalOrders, sum(od.UnitPrice * od.Quantity * (1 - od.Discount)) as TotalRevenue from Orders o
    inner join [Order Details] od on o.OrderID = od.OrderID
    where year(o.OrderDate) = @Year and month(o.OrderDate) = @Month;
end;