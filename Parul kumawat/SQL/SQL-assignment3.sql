--1--
select * from Products;
--2--
select ProductName, UnitPrice, UnitsInStock 
from Products
where Discontinued = 0;
--3--
select * from Products 
where UnitPrice > 50 
order by ProductName , UnitPrice  desc
--4--
select * from Customers
select CustomerID,CompanyName,Country 
from Customers
where Country in('Germany','USA','France');
--5--
Select * from Products;
select ProductName, CategoryID 
from Products
where ProductName like 'C%';
--6--
Select * from Orders;
select OrderID,CustomerID,OrderDate from Orders
where year(OrderDate) = 1997

--7--
Select * from Products;
select ProductName,UnitPrice,UnitsInStock from Products
where UnitsInStock = 0 or UnitPrice < 10;
--8--
select * from Employees;
select FirstName,LastName,Title
from Employees
where LastName like 'D%' or LastName like 'M%';
--9--
Select * from Products;
select top 10 ProductName,UnitPrice from Products
order by UnitPrice desc;
--10--
select * from Orders;
select OrderID, CustomerID, OrderDate from Orders
where ShippedDate is null;
--11--
select * from Products;
select * from Categories;
select pro.ProductName, cat.CategoryName 
from Products pro
inner join Categories cat on pro.CategoryID = cat.CategoryID;
--12--
select * from Orders;
select * from Customers;
select ord.OrderId,ord.OrderDate,cust.CompanyName,cust.ContactName 
from Orders ord
join Customers cust on ord.CustomerID = cust.CustomerID;
--13--
select * from Products;
select * from Suppliers;
select pro.ProductName, supp.CompanyName, pro.UnitPrice 
from Products pro
inner join Suppliers supp on pro.SupplierID = supp.SupplierID;
--14--
select * from [Order Details];
select * from Products;
select od.OrderID, pro.ProductName, od.Quantity, od.UnitPrice
from [Order Details] od
join Products pro on od.ProductID = pro.ProductID;
--15--
select * from Employees;
select emp.EmployeeID, emp.FirstName as EmployeeFirstName,emp.LastName as EmployeeLastName,man.FirstName As ManagerFirstName, man.LastName as ManagerLastName
from Employees emp
left join Employees man on emp.EmployeeID = man.EmployeeID;
--16--
select * from Orders;
select * from Customers;
select ord.CustomerID,ord.OrderID,cust.CompanyName
from Orders ord
left join Customers cust on ord.CustomerID = cust.CustomerID
--17--
select * from Orders;
select * from Customers;
select * from Employees;
select ord.OrderID,cust.CompanyName, emp.FirstName + ' '+emp.LastName as EmployeeFullName 
from Orders ord
join Customers cust on ord.CustomerID = cust.CustomerID
join Employees emp on ord.EmployeeId = emp.EmployeeId;
--18--
select * from Products;
select * from Categories;
select pro.ProductName,cat.CategoryName
from Products pro
left join Categories cat on pro.CategoryID = cat.CategoryID
--19--
select * from Products;
select * from Categories;
select * from [Order Details];
select od.OrderId, pro.ProductName, od.Quantity, cat.CategoryName
from Products pro
inner join [Order Details] od on pro.ProductID = od.ProductID
inner join Categories cat on pro.CategoryID = cat.CategoryID;
--20--
select top 100 cust.CustomerID,ord.OrderID
from Customers cust
cross join Orders ord;
--21--
select * from Products;
select count(ProductID) as TotalProducts from Products;
--22--
select round(avg(UnitPrice),2) as AverageUnitPrice from Products;
--23--
select max(UnitPrice) as MaximumPrice,  min(UnitPrice) as MinimumPrice from Products;
--24--
select * from Products;
select * from Categories;
select CategoryID,count(ProductId) as TotalProductCount
from Products 
group by CategoryID;
--25--
select cat.CategoryName,count(pro.ProductId) as TotalProductCount
from Products pro
join Categories cat on pro.CategoryID = cat.CategoryID
group by CategoryName;
--26--
select * from Products;
select * from [Order Details];
select ProductId,sum(Quantity) as TotalQuantity from [Order Details]
group by ProductID;
--27--
select * from Categories;
select cat.CategoryName,count(pro.ProductId) as TotalProductCount
from Products pro
join Categories cat on pro.CategoryID = cat.CategoryID
group by cat.CategoryName
having count(pro.ProductId) > 10;
--28--
select * from Orders;
select * from [Order Details];
select OrderId, sum(UnitPrice * Quantity *(1-Discount)) as TotalAmount
from [Order Details]
group by OrderID
--29--
select * from Categories;
insert into Categories(CategoryName,Description)
values('Organic foods','Certified organic products');
--30--
select * from Products;
insert into Products(ProductName,SupplierID,CategoryID,UnitPrice,UnitsInStock,Discontinued)
values('Green Tea',1,1,15.00,50,0);
--31--
update Products set UnitPrice = UnitPrice * 1.10
where CategoryID = 1;
--32--
select * from Customers;
update Customers set Phone = '030-1234567' where CustomerID = 'ALFKI';
--33--
select * from Products;
update Products set Discontinued = 1 where UnitsInStock = 0;
--34--
delete from Products where Discontinued = 1 
and not exists( select 1 from [Order Details] where [Order Details].ProductID = Products.ProductID);
--35--
select * from Customers;
select * from Orders;

begin try
begin transaction;
declare @NewCustomerId NCHAR(5) = 'PARUL';
insert into Customers(CustomerID,CompanyName,ContactName)values(@NewCustomerId,'Parul Pvt. LTD.','Parul Kumawat');

insert into Orders(CustomerID,OrderDate,ShipCity)values(@NewCustomerId,GETDATE(),'Lyon');
commit transaction;
print 'your transaction committed successfully';
end try

begin catch
if @@trancount > 0
begin
rollback transaction;
print 'your transaction failed';
end
print 'error message' + error_message();
end catch;

--36--
select ProductName,UnitPrice
from Products
where  UnitPrice > (select avg(UnitPrice) from Products)
--37--
select CustomerID,CompanyName
from Customers
where exists(select CustomerID from Orders);
--38--
select * from Suppliers;
select * from Products where SupplierID in(select SupplierID from Suppliers where Country = 'Germany');
--39--
select * from Orders;
select * from [Order Details];
with OrderValues as(
select OrderId, sum(UnitPrice * Quantity *(1-Discount)) as TotalAmount
from [Order Details]
group by OrderID
),
AvgOrderValue as(
select avg(TotalAmount) as AvgValue from OrderValues
)
select ov.OrderID,ov.TotalAmount
from OrderValues ov
cross join AvgOrderValue aov
where ov.TotalAmount > aov.AvgValue 

--40--
select * from Orders;
select * from Customers;
with NoOfOrdersPerCustomer as(
select CustomerId,count(OrderID) as TotalOrders from Orders group by CustomerID
)
select CustomerID,TotalOrders from NoOfOrdersPerCustomer where TotalOrders > 10;

--41--
select * from Products;
select * from Categories;
select pro.CategoryID,pro.ProductName,pro.UnitPrice 
from Products pro
where pro.UnitPrice = (
select max(pro2.UnitPrice) from Products pro2
where pro2.CategoryID = pro.CategoryID);

--42--
select * from Customers;
select cust.CustomerID,cust.ContactName from Customers cust
where not exists(select 1 from Orders ord where ord.CustomerID = cust.CustomerID);

--43--
create view vw_ProductList as 
select pro.ProductID,pro.ProductName,pro.UnitPrice,cat.CategoryName
from Products pro
join Categories cat on pro.CategoryID = cat.CategoryID
where pro.Discontinued = 0;
select * from vw_ProductList;

--44--
select * from Orders;
select * from Customers;
select * from [Order Details];
create view vw_OrderSummary as
select ord.OrderID,cust.CompanyName,ord.OrderDate,count(od.ProductID) as ToatlNumberOfItems
from Orders ord
join Customers cust on ord.CustomerID = cust.CustomerID
join [Order Details] od on ord.OrderID = od.OrderID
group by ord.OrderID,cust.CompanyName,ord.OrderDate;
select * from vw_OrderSummary;

--45--
select * from Categories;
select * from Products;
create procedure usp_GetProductsByCategory
@CategoryID int
as
begin 
select ProductID,ProductName,UnitPrice,UnitsInStock,UnitsOnOrder,Discontinued from Products
where CategoryID = @CategoryID
end;

exec usp_GetProductsByCategory  @CategoryID = 1;

--46--
select * from Products;
select * from Customers;
select * from [Order Details];

create procedure usp_GetCustomerOrders 
@CustomerID nvarchar(30)
as
begin 
select ord.OrderID,ord.OrderDate,cust.CompanyName,cust.ContactName,pro.ProductName,od.Quantity,od.UnitPrice
from Orders ord
join Customers cust on ord.CustomerID = cust.CustomerID
join [Order Details] od on ord.OrderID = od.OrderID
join Products pro on od.ProductID = pro.ProductID
where ord.CustomerID = @CustomerID
end;

exec usp_GetCustomerOrders @CustomerID = 'ALFKI';

--47--
create procedure usp_AddCategory
@CategoryName nvarchar(20),
@Description nvarchar(200),
@NewCategoryID int output
as
begin
insert into Categories(CategoryName,Description)values(@CategoryName,@Description);
set @NewCategoryID = scope_identity();
end;

declare @NewId int;
exec usp_AddCategory @CategoryName = 'new category',@Description = 'description',@NewCategoryID = @NewId output;
select @NewId as NewCategoryID;
select * from Categories;

--48--
select * from Products;
create procedure usp_UpdateProductPrice
@ProductID int,
@NewPrice decimal(10,2)
as 
begin 
if @NewPrice <= 0 
begin 
raiserror('price must be greater than 0',16,1);
return;
end
update Products 
set UnitPrice = @NewPrice
where ProductID = @ProductID;
end;

exec usp_UpdateProductPrice @ProductID = 1, @NewPrice = 50.00;

--49--
create procedure usp_GetEmployeeSales
as 
begin
select emp.EmployeeID,emp.FirstName+' '+emp.LastName as FullName,sum(od.UnitPrice * od.Quantity *(1-od.Discount)) as TotalAmount 
from Employees emp
inner join Orders ord on emp.EmployeeID = ord.EmployeeID
inner join [Order Details] od on ord.OrderID = od.OrderID
group by emp.EmployeeID,emp.FirstName,emp.LastName;
end;

exec usp_GetEmployeeSales;

--50--
create procedure usp_GetMonthlyOrderStats
@Year int,
@Month int
as
begin
select count(ord.OrderId) as TotalOrders, sum(od.UnitPrice * od.Quantity *(1-od.Discount)) as TotalRevenue
from Orders ord
inner join [Order Details] od on ord.OrderID = od.OrderID
where year(ord.OrderDate) = @Year and month(ord.OrderDate) = @Month;
end;

exec usp_GetMonthlyOrderStats @Year = 1997, @Month = 5;




