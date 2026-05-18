--Exercise #1--
select * from Categories;
select CategoryName, Description from Categories;

--Exercise #2--
select * from Customers;
select ContactName, CustomerId, CompanyName from Customers where City = 'London'; 

--Exercise #3--
select * from Suppliers;
select SupplierId, CompanyName, ContactName, ContactTitle, Address,City,Region,PostalCode,Country,Phone,HomePage from Suppliers where Fax is not null;


--Exercise #4--
select * from Orders;
select CustomerId,RequiredDate,Freight from Orders
where RequiredDate between '1997-01-01' and '1998-01-01' and Freight < 100;


--Exercise #5--
select CompanyName, ContactName, ContactTitle, Country  from Customers 
where ContactTitle = 'Owner' and Country in ('Mexico','Sweden','Germany');


--Exercise #6--
select * from Products;
select count(*) as discontinued from Products where Discontinued = 1; 



--Exercise #7--
select CategoryName,Description from Categories 
where CategoryName like 'Co%' or Description like 'Co%';


--Exercise #8--
select CompanyName,City,Country,PostalCode from Suppliers 
where Address like '%rue%';


--Exercise #9--
select * from [Order Details];
select ProductId, sum(Quantity) as total from [Order Details] group by ProductId;


--Exercise #10--
SELECT ContactName, Address
FROM Customers  as cust
INNER JOIN Orders as ord
on cust.CustomerID = ord.CustomerID where ShipVia = 1;


--Exercise #11--
select CompanyName,ContactName,ContactTitle 
from Suppliers as supp
where supp.Region is not null;


--Exercise #12--
select ProductName from Products where CategoryID = 2;

--Exercise #13--
select ContactName from Customers as cus
left join Orders as ord
on ord.CustomerID =   cus.CustomerID
where ord.CustomerID is null;


--Exercise #14--
select * from Shippers;
insert into Shippers(CompanyName)
values('Amazon');


--Exercise #15--
update Shippers set CompanyName = 'Amazon Prime Shopping' where ShipperID = 4;


--Exercise #16--
SELECT S.CompanyName, ROUND(SUM(Ord.Freight), 0) AS TotalFreight
FROM Shippers S
JOIN Orders Ord ON S.ShipperID = Ord.ShipVia
GROUP BY S.CompanyName;


--Exercise #17--
select * from Employees;
select concat(Lastname,',',FirstName) as DisplayName from Employees;


--Exercise #18--
select * from Customers;
select * from Orders;
select * from Products;
select * from [Order Details];
delete from Customers where CustomerID = 'PARUL';
delete from Orders where OrderID = 11078;
delete from [Order Details] where OrderID = 11078;


declare @Customer_id nvarchar(5) = 'Parul'
insert into Customers(CustomerID,ContactName,CompanyName)
values(@Customer_id,'Parul','Parul Pvt. Ltd.');

insert into Orders(CustomerID)values(@Customer_id);
declare @Order_id int = scope_identity();

DECLARE @ProductID INT = (SELECT ProductID FROM Products WHERE ProductName = 'Grandma''s Boysenberry Spread');
insert into [Order Details] (OrderID,ProductID,UnitPrice,Quantity,Discount)
values(@Order_id,@ProductID,25.00,7,0);


--Exercise #19--

declare @Cust_id nvarchar(5) = 'Parul'
DECLARE @Ord_id INT;

select @Ord_id = OrderID from Orders
where CustomerID = @Cust_id;

delete from [Order Details]
where OrderID = @Ord_id;

delete from Orders
where OrderID = @Ord_id;

delete from Customers
where CustomerID = @Cust_id;



--Exercise #20--
select ProductName, UnitsInStock as TotalUnits from Products
where UnitsInStock > 100;	


select * from CustomerCustomerDemo;

select * from EmployeeTerritories;


select * from Region;
















select * from Territories;



