--1--
select * from Products;

--2--
select * from Products;
select ProductName,UnitPrice,UnitsInStock from Products where Discontinued=0;

--3--
select * from Products;   
select ProductName,UnitPrice from Products where UnitPrice>50 order by UnitPrice desc; 

--4--
select * from Customers;     
select CustomerID,CompanyName,Country from Customers where Country in('Germany','USA','France');

--5--
select * from Products;   
select ProductName,CategoryID from Products where ProductName like 'C%';   

--6--
select * from Orders;
select OrderID,CustomerID,OrderDate from Orders where Year(OrderDate)=1997;

--7--
select * from Products;
select ProductName,UnitPrice,UnitsInStock from Products where UnitsInStock=0 or UnitsInStock<10;

--8--
select * from Employees;
select FirstName,LastName,Title from Employees where LastName between 'D'and'M';

--9--
select * from Products;
select top 10 ProductName,UnitPrice from Products order by UnitPrice desc;

--10--
select * from Orders;
select OrderID,CustomerID,OrderDate from Orders where ShippedDate is null;

--11--
select * from Categories;    
select * from Products;

select p.ProductName,c.CategoryName 
from Categories as c
inner join Products as p
on c.CategoryID=p.CategoryID;

--12--
select * from Orders;       OrderID,OrderDate       
select * from Customers;    CompanyName,ContactName


select 0.OrderID,0.OrderDate,c.CompanyName,c.ContactName 
from Orders as o
join Customers as c
on o.CustomerID=c.CustomerID;

--13--
select * from Products;   ProductName,UnitPrice
select * from Suppliers;  CompanyName

select ProductName,UnitPrice,CompanyName
from Products as p
inner join Suppliers as s
on p.SupplierID=s.SupplierID;

--14--
select * from [Order Details];   OrderID,Quantity,UnitPrice
select * from Products;   ProductName

select o.OrderID,o.Quantity,o.UnitPrice, p.ProductName
from [Order Details] as o
join Products as p
on o.ProductID=p.ProductID;

--15--
select * from Employees;   
select * from Employees;

select e.EmployeeID ,
e.FirstName as Employee_FirstName,
e.LastName as Employee_LastName,
m.FirstName as Manager_FirstName,
m.LastName as Manager_LastName
from Employees e
left join Employees m
on e.ReportsTo=m.EmployeeID;

--16-- 
select * from Orders;      OrderID
select * from Customers;   CustomerID,CompanyName

select o.OrderID,c.CustomerID,c.CompanyName
from Orders as o
left join Customers as c
on   o.CustomerID=c.CustomerID;

--17--
select * from Orders;            OrderID
select *  from Customers;  CompanyName
select * from Employees;       Employee_fullName(FirstName+LastName)

select o.OrderID,c.CompanyName,concat(e.FirstName,'',e.LastName) as Employee_FullName
from Orders as o
join Customers as c  on o.CustomerID=c.CustomerID
join Employees as e on o.EmployeeID=e.EmployeeID;

--18--  
select * from Products;    ProductName
select * from Categories;  CategoryName

select p.ProductName,c.CategoryName 
from Products as p
left join Categories as c
on p.CategoryID=c.CategoryID;

--19--
select * from [Order Details];  OrderID,Quantity
select * from Products;         ProductName
select * from Categories;       CategoryName

select o.OrderID,o.Quantity,p.ProductName,c.CategoryName
from [Order Details] as o
inner join Products as p on o.ProductID=p.ProductID 
inner join Categories as c on  p.CategoryID=c.CategoryID;

--20--
select * from Orders;            OrderID                       CustomerID
select *  from Customers;        CustomerID                    CustomerID

select Top 100 o.OrderID,c.CustomerID
from Orders as o
cross join Customers as c
where o.CustomerID=c.CustomerID;

--21--
select * from Products;
select count(*) from Products;

--22--
select * from Products;
select  round(avg(UnitPrice), 2) from Products;

--23--
select * from Products;
select min(UnitPrice),max(UnitPrice) from Products;

--24--
select * from Products;
select CategoryID, COUNT(*) from Products group by CategoryID;

--25--
select * from Products;
select * from Categories;

select c.CategoryName, COUNT(p.ProductID) as TotalProduct
from Categories c
inner join Products p
on c.CategoryID = p.CategoryID
group by c.CategoryName;

--26--
select * from [Order Details];
select ProductID,sum(Quantity)
from [Order Details]
group by ProductID;


--27--
select * from Products;
select * from Categories;

select c.CategoryName, COUNT(p.ProductID) as ProductCount
from Categories c
join Products p
on c.CategoryID = p.CategoryID
group by c.CategoryName
having COUNT(p.ProductID) > 10;

--28--       Not Completed
select * from [Order Details];
select OrderID,sum(UnitPrice*Quantity*(1-Discount)) from [Order Details] group by OrderID;

--29--
select * from Categories;
insert into Categories (CategoryName, Description) values ('OrganicFoods', 'Certified organic products');

--30--
select * from Products;
insert into Products(ProductName,SupplierID,CategoryID,UnitPrice,UnitsInStock,Discontinued) values('Green Tea',1,1,15.00,50,0);

--31--
select * from Products;
update Products set UnitPrice = UnitPrice * 1.10 where CategoryID = 1;

--32--
select * from Customers;
update Customers set Phone = '030-1234567' where CustomerID='ALFKI';

--33--
select * from Products;
update Products set Discontinued = 1 where UnitsInStock = 0;

--34--
select * from [Order Details];
delete from Products where Discontinued = 1
AND NOT EXISTS (
 select 1 
 from [Order Details] as o
 where o.ProductID = Products.ProductID);

--35--
select * from Customers;
select * from Orders;

begin try
    begin transaction;

    -- Insert into Customers
    insert into Customers (CustomerID, CompanyName, ContactName) values ('Kk001', 'Keshav pvt ltd', 'Keshav Kumar kumawat');

    -- Insert into Orders for that customer
    insert into Orders (CustomerID, OrderDate) values ('kK001', GETDATE());

    commit transaction;
end try

begin catch
    rollback transaction;

    print ERROR_MESSAGE();
end catch;

--36--
select * from Products;
select ProductName, UnitPrice from Products where UnitPrice > (select avg(UnitPrice) from Products);

--37--
select * from Customers;
select * from Orders;

select c.CustomerID,c.CompanyName from Customers c
where exists (
    select 1 
    from Orders o 
    where o.CustomerID = c.CustomerID );

--38--
select * from Products;
select * from Products
where SupplierID in (
    select SupplierID 
    from Suppliers 
    where Country = 'Germany'
);

--39--
select * from [Order Details];

with AverageValue as (
    select avg(UnitPrice) as avg_val from [Order Details]
)
select * from [Order Details], AverageValue
where [Order Details].UnitPrice > AverageValue.avg_val;

--40--
select * from Customers;
select * from Orders;

with CustomerOrders AS (
    select CustomerID, COUNT(OrderID) AS total_orders from Orders
    group by CustomerID
)
select CustomerID, total_orders from CustomerOrders where total_orders > 10;

--41--
select * from Products;
select CategoryID, ProductName, UnitPrice
from Products as outer_p
where UnitPrice = (
    select max(UnitPrice)
    from Products as inner_p
    where inner_p.CategoryID = outer_p.CategoryID
);

--42--
select * from Customers;
select * from Orders;

select * from Customers as c
where not exists (
    select 1 
    from Orders o 
    where o.CustomerID = c.CustomerID
);

--43--
select * from Products;
select * from Categories;

create view vw_ProductList as
select p.ProductID, p.ProductName, c.CategoryName, p.UnitPrice
from Products p
join Categories c on p.CategoryID = c.CategoryID
where p.Discontinued = 0;

--44--
select * from Orders;
select * from Customers;
select * from [Order Details];

create view vw_OrderSummary as
select O.OrderID, C.CompanyName AS CustomerName, O.OrderDate, count(OD.OrderID) as NumberOfItems
from Orders as O
join Customers as C on O.CustomerID = C.CustomerID
join [Order Details] as OD on O.OrderID = OD.OrderID
group by O.OrderID, C.CompanyName, O.OrderDate;

--45--
select * from Products;
select * from Orders;
select * from [Order Details];

create procedure usp_GetProductsByCategory
    @CategoryID int
as
begin
    select * from Products where CategoryID = @CategoryID;
end;

--46--
select * from Orders;
select * from [Order Details];

create procedure usp_GetCustomerOrders
    @CustomerID int  
as
begin
    set NOCOUNT on;

    select o.OrderID,o.OrderDate,od.ProductID,od.Quantity,od.UnitPrice
    from Orders o
    join [Order Details] od on o.OrderID = od.OrderID
    where o.CustomerID = @CustomerID;
end;
go

--47--
create procedure usp_AddCategory
    @CategoryName nvarchar(100),
    @Description nvarchar(max),
    @CategoryID int output
as
begin
    set NOCOUNT on;

    insert into Categories (CategoryName, Description) values (@CategoryName, @Description);

    set @CategoryID = SCOPE_IDENTITY();
end;
go

--48--
create procedure usp_UpdateProductPrice
    @ProductID int,
    @NewPrice decimal(10, 2)
as
begin
  
    if @NewPrice <= 0
    begin
        RAISERROR('The new price must be greater than 0.', 16, 1);
        RETURN; 
    end

    update Products
    set Price = @NewPrice
    where ProductID = @ProductID;

    if @@ROWCOUNT = 0
    begin
        print 'No product found with the provided ID.';
    end
    else
    begin
        print 'Product price updated successfully.';
    end
end;


--49--
select * from Employees;
select * from [Order Details];
select * from Orders;

create procedure usp_GetEmployeeSales
as
begin
    select 
        e.EmployeeID,
        (e.FirstName + ' ' + e.LastName) as FullName,
        sum(od.UnitPrice * od.Quantity) as TotalSales
    from Employees e
    join Orders o on e.EmployeeID = o.EmployeeID
    join [Order Details] od on o.OrderID = od.OrderID
    group by 
        e.EmployeeID, 
        e.FirstName, 
        e.LastName;
end;
go

--50--
select * from Orders;

create procedure usp_GetMonthlyOrderStats
    @Year int,
    @Month int
as
begin
    select count(ord.OrderId) as TotalOrders,sum(od.unitPrice*od.Quantity*(1-od.Discount)) as TotalRevenue
    from Orders ord
    inner join [Order Details] od on ord.OrderID=od.OrderId
    where year(ord.OrderDate)=@Year and month(ord.OrderDate)=@Month;
end;
exec usp_GetMonthlyOrderStats @Year=1997,@Month=5;








