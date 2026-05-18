use northWind;
select * from Customers;
select * from Categories;
select * from Shippers;
select * from "Suppliers";
select * from "Orders";
select * from Products;

--1
select CategoryName ,Description from  Categories;

--2
select ContactName, CustomerID, CompanyName
from Customers
where City = 'London';

--3

select * from Suppliers 
where ContactTitle in ('Marketing Manager','Sales Representative')
And Fax IS NOT NULL;

--4

select CustomerID 
from Orders 
where RequiredDate BETWEEN '1997-01-01' AND '1998-01-01' 
AND Freight > 100;

--5
select companyName,ContactName 
from Customers 
where Country in ('Mexico','Sweden','Germany');

--6
select count(*) from Products where Discontinued=1;

--7
select CategoryName, Description 
from Categories 
where CategoryName LIKE 'co%';

--8
select CompanyName,City,Country,PostalCode 
from "Suppliers"
where Address LIKE '%rue%' 
order by CompanyName;

--9
select ProductID,Quantity from [Order Details]

--10
SELECT Customers.ContactName , Customers.Address
FROM Orders
INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID 
where Orders.ShipVia=1
;

--11 pending 

SELECT s.CompanyName , s.ContactName, s.ContactTitle
FROM Suppliers s 
where s.Region is not null;

--12


SELECT ProductName
FROM Products
where CategoryID=2

--13

SELECT c.ContactName
FROM Customers c
left JOIN Orders o ON o.CustomerID = c.CustomerID 
where o.CustomerID is null; 

--14
insert into Shippers(CompanyName) 
values ('Amazon');
select * from Shippers;

--15
update Shippers set CompanyName = 'Amazon Prime Shipping' where CompanyName ='Amazon'
select * from Shippers;

--16
select * from Shippers;
select * from Orders;

SELECT S.CompanyName, ROUND(SUM(O.Freight), 0) AS 'Total Freight'
FROM Shippers S
LEFT JOIN Orders O ON S.ShipperID = O.ShipVia
GROUP BY S.CompanyName;


--17--
select LastName+FirstName as DisplayName from Employees

--18--
DECLARE @User NVARCHAR(20)= 'dev';

insert into Customers(CustomerID,CompanyName) 
values(@User,'devCmpany'); 

select * from Customers;

DECLARE @productId NVARCHAR(20);
set @productId  = (select ProductId from Products where ProductName = 'Grandma''s Boysenberry Spread');


INSERT INTO "Orders"("CustomerID")
VALUES (@User)

DECLARE @OrderId NVARCHAR(20);
set @OrderId  = (select OrderId from Orders where CustomerID = @User);



insert into [Order Details] (OrderID,Quantity,ProductID)
Values (@OrderId,1,@productId);




--19--
DECLARE @User2 NVARCHAR(20)= 'dev';

DECLARE @OrderId2 NVARCHAR(20);
set @OrderId2  = (select OrderId from Orders where CustomerID = @User2);

DECLARE @OrderIdDetail NVARCHAR(20);
set @OrderIdDetail  = (select OrderId from [Order Details] where OrderId = @OrderId2);




delete from [Order Details] where OrderID = @OrderIdDetail;
delete from Orders where OrderID = @OrderId2;
delete from Customers where CustomerID = @User2;



--20--
select ProductName,UnitsInStock as TotalUnits
from Products
where UnitsInStock>100;




