use northWind;

-- 1 
select * from products;

--2
select ProductName,UnitPrice,UnitPrice,UnitsInStock 
from Products where Discontinued=0;

--3
select * 
from Products where UnitPrice>50
order by UnitPrice desc;

--4
select * from Customers;
select CustomerID,CompanyName,Country 
from Customers 
where Country in('Germany','USA','France');

--5
select ProductName,CategoryID
from Products 
where ProductName like 'C%';

--6
select OrderID,CustomerID,OrderDate
from Orders 
where year(OrderDate)='1997' ;

--7
select ProductName,UnitPrice,UnitsInStock
from Products 
where UnitsInStock=0 or UnitPrice<10 ;

--8
select FirstName,LastName,Title
from Employees 
where LastName LIKE '[D-M]%'
order by LastName;

--9
select ProductName, UnitPrice
from Products 
order by UnitPrice desc;

--10
select OrderID,CustomerID,OrderDate
from Orders 
where ShippedDate is null;

-- section Join 

--11
select p.ProductName , c.CategoryName
from Products p 
inner join Categories c on c.CategoryID = p.CategoryID ;

--12
select o.OrderID , o.OrderDate, c.CompanyName, c.ContactName
from Orders o 
join Customers c on c.CustomerID = o.CustomerID;

--13
select p.ProductName,s.CompanyName,p.UnitPrice
from Products p 
inner join Suppliers s on p.SupplierID = s.SupplierID;

--14
select od.OrderID, p.ProductName, od.Quantity, od.UnitPrice
from [Order Details] as od
inner join Products p on p.ProductID = od.ProductID;

--15 *********************************************
select e1.EmployeeID,e1.FirstName,e1.LastName, e2.FirstName,e2.LastName 
from Employees as e1
left join Employees e2 on e1.ReportsTo = e2.EmployeeID;

--16
select c.CustomerID,c.CompanyName,o.OrderID 
from Customers as c
left join Orders o on c.CustomerID = o.CustomerID;

--17
select o.OrderID,c.CompanyName,e.FirstName+e.LastName as 'Employee'
from Orders o
join Customers c on c.CustomerID = o.CustomerID
join Employees e on e.EmployeeID = o.EmployeeID;

--18
select p.ProductName, c.CategoryName
from Products p
join Categories c on c.CategoryID = p.CategoryID;

--19
select od.OrderID, p.ProductName,od.Quantity, c.CategoryName
from [Order Details] od
inner join Products p on p.ProductID = od.ProductID
inner join Categories c on c.CategoryID = p.CategoryID;

--20
select top 100 c.CustomerID,o.OrderID
from Customers c 
cross join Orders o;


-- 
-- 21
select count(ProductID) as 'Total Products' 
from Products;

-- 22
select round(avg(UnitPrice),2) as 'Average' 
from Products;



-- 23
select min(UnitPrice) as 'Minimum' , max(UnitPrice) as 'Maximum' 
from Products;

-- 24
select CategoryID, count(CategoryID) as 'Count' 
from Products 
group by CategoryID

-- 25
select c.CategoryName, count(p.CategoryID) as 'Count' 
from Products p
join Categories c on c.CategoryID = p.CategoryID
group by CategoryName;

-- 26
select ProductID, sum(Quantity) as 'Count' 
from [Order Details]
group by ProductID;

-- 27
select c.CategoryName , count(p.ProductID)
from Categories c
right join Products p on c.CategoryID = p.CategoryID
group by CategoryName
having count(p.ProductID)>10
;

-- 28
select od.OrderID , sum(UnitPrice*Quantity*(1-Discount)) as totalSales
from [Order Details] od
group by OrderID
;


--29
insert into Categories (CategoryName,Description) 
values('Organic Foods','Certified organic products');

select * from Categories;

--30
insert into 
Products(ProductName,SupplierID,CategoryID,UnitPrice,UnitsInStock,Discontinued) 
values ('Green Tea',1,1,15.00,50,0);

select * from Products;

-- 31. 
UPDATE Products
SET  UnitPrice = UnitPrice*1.10
WHERE CategoryID = 1;

select * from Products;



-- 32.
UPDATE Customers
SET  Phone = '030-1234567'
WHERE CustomerID = 'ALFKI';

select * from Customers;

--33.
UPDATE Products
SET  Discontinued = 1
WHERE UnitsInStock = 0;

select * from Products;

--34.
DELETE FROM Products
where Discontinued = 0
AND ProductID NOT IN (
    SELECT ProductID FROM [Order Details]
);

--35.

BEGIN TRY
    BEGIN TRANSACTION;

    INSERT INTO Customers (CustomerID,CompanyName,ContactName )
    VALUES ('jd','Jane Doe', 'jane.doe@example.com');

    DECLARE @NewCustomerID INT = SCOPE_IDENTITY();


    INSERT INTO Orders (CustomerID, OrderDate )
    VALUES (@NewCustomerID, GETDATE());


    COMMIT TRANSACTION;
    PRINT 'Order processed successfully.';

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION;
    END

    PRINT 'Error: ' + ERROR_MESSAGE();
END CATCH;


-- 36.
select ProductName,UnitPrice 
from Products
where (select avg(UnitPrice) from Products) < UnitPrice
;

--37.
select CustomerID,CompanyName 
from Customers
where exists (select CustomerID from Orders);

--38.
select * from Products
where SupplierID in(select SupplierID from Suppliers where Country='Germany' );

--39.
WITH aboveAvgOrder AS (
    SELECT *
    FROM [Order Details]
    WHERE UnitPrice > (
        SELECT AVG(UnitPrice)
        FROM [Order Details]
    )
)
SELECT *
FROM aboveAvgOrder;

--40.


WITH AvgOrderBycust AS (
    SELECT CustomerID, COUNT(*) AS totalOrder
    FROM Orders
    GROUP BY CustomerID
)
SELECT *
FROM AvgOrderBycust
WHERE totalOrder > 10;

-- 41.

select CategoryID ProductName,UnitPrice 
from Products p
where UnitPrice = (select max(UnitPrice) from Products where CategoryID = p.CategoryID)
;

-- 42.

SELECT *
FROM Customers c
WHERE NOT EXISTS (
    SELECT 1 
    FROM Orders o 
    WHERE o.CustomerID = c.CustomerID
);

--43
CREATE VIEW [vw_ProductList] AS
SELECT p.ProductID, p.ProductName ,CategoryName,p.UnitPrice
FROM Products p
join Categories c on c.CategoryID= p.CategoryID
where Discontinued = 0;

select * from vw_ProductList;

--44
CREATE VIEW vw_OrderSummary AS
SELECT o.OrderID, c.CompanyName,o.OrderDate,SUM(od.Quantity) AS TotalQuantity
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY 
    o.OrderID,
    c.CompanyName,
    o.OrderDate;




SELECT * FROM vw_OrderSummary;

--45
CREATE PROCEDURE usp_GetProductsByCategory
  @CategoryId int
AS
BEGIN
  SELECT * FROM Products
  WHERE CategoryID = @CategoryId;
END;


EXEC usp_GetProductsByCategory @categoryId=2;

--46 
CREATE PROCEDURE usp_GetCustomerOrders
  @CustomerID nvarchar(20)
AS
BEGIN
  SELECT * FROM Orders
  WHERE CustomerID = @CustomerID;
END;


EXEC usp_GetCustomerOrders @CustomerID='ANTON';

--47
CREATE PROCEDURE usp_AddCategory
  @CategoryName NVARCHAR(20),
  @Description NVARCHAR(200),
  @CategoryId INT OUTPUT
AS
BEGIN
  INSERT INTO Categories (CategoryName, Description) 
  VALUES (@CategoryName, @Description);

  SET @CategoryId = SCOPE_IDENTITY();
END;

DECLARE @NewCategoryId INT;

EXEC usp_AddCategory 
  @CategoryName = 'new category',
  @Description = 'description',
  @CategoryId = @NewCategoryId OUTPUT;

SELECT @NewCategoryId;

--48
CREATE PROCEDURE usp_UpdateProductPrice
    @ProductID INT,
    @NewPrice DECIMAL(10,2)
AS
BEGIN
    IF @NewPrice = 0
    BEGIN
        RAISERROR('Price cannot be 0.', 17, 1);
        RETURN;
    END

    UPDATE Products
    SET UnitPrice = @NewPrice
    WHERE ProductID = @ProductID;
END;

EXEC usp_UpdateProductPrice 
  @ProductID = 3,
  @NewPrice = 10;


--49
CREATE PROCEDURE useGetEmployeeSales
AS
BEGIN
    select e.EmployeeID,e.FirstName+e.LastName as FullName,sum(UnitPrice*Quantity) 'TotalSales' 
    from Employees e
    join Orders o on e.EmployeeID = o.EmployeeID
    join [Order Details] od on o.OrderID = od.OrderID
    group by e.EmployeeID,e.FirstName,e.LastName
END;

EXEC useGetEmployeeSales;

--50
CREATE PROCEDURE usp_GetMonthlyOrderStats
    @year INT,
    @month int
AS
BEGIN
    select sum(od.Quantity*od.UnitPrice) as 'Total Revenue',count(*) as 'Total orders'
    from Orders o
    join [Order Details] as od on od.OrderID = o.OrderID
    WHERE o.OrderDate >= DATEFROMPARTS(@year, @month, 1)
    AND o.OrderDate < DATEADD(MONTH, 1, DATEFROMPARTS(@year, @month, 1))
END;


EXEC usp_GetMonthlyOrderStats
    @year = 1996,
    @month = 7;


SELECT * FROM Orders;

