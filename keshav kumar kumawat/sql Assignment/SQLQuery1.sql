--1--
select CategoryName from Categories;

--2--
select CustomerID,CompanyName,ContactName from Customers  where city='London';

--3--
SELECT * FROM Suppliers WHERE Fax IS NOT NULL;

--4--
select CustomerID from Orders where RequiredDate between 1997-01-01 and 1998-01-01 and Freight<100;

--5--
SELECT CompanyName, ContactName FROM Customers WHERE Country IN ('Mexico', 'Sweden', 'Germany');

--6--
select Discontinued from Products where Discontinued=1;

--7--
SELECT CategoryName, Description FROM Categories WHERE CategoryName LIKE 'Co%';

--8--
select CompanyName,city,country,PostalCode from Suppliers  where Address Like '%Rue%' order by CompanyName asc;
select ProductID,Quantity from [Order Details];


--10--
SELECT c.CompanyName, c.Address
FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
INNER JOIN Shippers s ON o.ShipVia = s.ShipperID
WHERE s.CompanyName = 'Speedy Express';


--11--
select CompanyName,ContactName,ContactTitle
from Suppliers as s
where s.Region is not null;


--12--
select ProductName from Products as p
left join categories as  c
on p.CategoryID=c.CategoryID 
WHERE c.CategoryID = 2;0


--13--
SELECT ContactName from Customers as c
left join Orders as o 
on o.CustomerID=c.CustomerID
WHERE o.CustomerID IS NULL;



--14--
insert into Shippers(CompanyName) values('Amazon');
select * from Shippers;

--15--
update Shippers 
set CompanyName='Amazon Prime Shipping'
where ShipperID=4;

select * from Shippers;

--16--
select * from Shippers;
Select s.CompanyName,
    ROUND(SUM(O.Freight), 0) AS TotalFreight
from Shippers s
inner join Orders O ON S.ShipperID = O.ShipVia
group by S.CompanyName;

--17--
select LastName + ', ' + FirstName AS DisplayName 
from Employees;

select * from Employees

--18--
declare @user varchar(50)='keshav'
insert into Customers (ContactName,CompanyName)
values (@user,'keshav pvt.Ltd');

declare @orderId int=scope_identity();
insert into orders(CustomerID) values(@orderId );

declare @productId int= scope_identity();
insert into Products(ProductID) values(@productId);

insert into [Order Details] (OrderID, ProductID)
values(@orderId,@productId);
select * from [Order Details];

--19--
delete from [Order Details]
where OrderID = @orderId;

delete from Orders
where OrderID = @orderId;

delete from Products
where ProductID = @productId;

delete from Customers
where ContactName = @user;

--20--                  
select ProductName,UnitsInStock as TotalUnits from Products 
where UnitsInStock>100;
