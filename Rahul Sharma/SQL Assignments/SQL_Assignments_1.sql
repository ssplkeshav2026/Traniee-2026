
select name from sys.tables
select * from CustomerCustomerDemo;
select * from CustomerDemographics;
select * from Region;
select * from Territories;
select * from EmployeeTerritories;
select * from Employees;
select * from Customers
select * from Categories;
select * from Shippers;
select * from Suppliers; 
select * from Orders;
select * from Products;
select * from OrderDetails


--1  Select all category names with their descriptions from the Categories table.

select categoryName,Description from categories;


--2 Select the contact name, customer id, and company name of all Customers in London

select ContactName,CustomerId,CompanyName from Customers where city='london';


--3 Marketing managers and sales representatives have asked you to select all available columns in the Suppliers tables that have a FAX number

select * from Suppliers where fax is not null;


--4  Select a list of customers id’s from the Orders table with required dates between Jan 1, 1997 and Jan 1, 1998 and with freight under 100 units.


select distinct customerid from orders where RequiredDate between '01-1-1997' and '01-1-1998' and freight<100;

--5 Select a list of company names and contact names of all the Owners from the Customer table from Mexico, Sweden and Germany.

select  companyname,contactname from customers where country in('Mexico','Sweden','Germany') and ContactTitle='owner'

--6 Count the number of discontinued products in the Products table.
select count(discontinued) from products  

--7 Select a list of category names and descriptions of all categories beginning with 'Co' from the Categories table

select categoryname,description from categories where categoryname like 'co%';


--8 Select all the company names, city, country and postal code from the Suppliers table with the word 'rue' in their address. The list should be ordered alphabetically by company name

select  companyname, city,country,postalcode from suppliers where address like '%rue%' order by companyname

--9 Select the product id and the total quantities ordered for each product id in the Order Details table

select productid,sum(quantity) as Quantity from orderdetails group by productid

--10 Select the customer name and customer address of all customers with orders that shipped using Speedy Express.

select c.contactname,c.address, s.CompanyName from customers c
 INNER JOIN orders o ON c.CustomerID =  o.CustomerID
 INNER JOIN Shippers s ON o.ShipVia = s.ShipperID
  WHERE s.ShipperID = 1;

-- 11 Select a list of Suppliers containing company name, contact name, contact title and region description.

   select companyname,contactname,contacttitle,region from suppliers where CompanyName is not null and contactname is not null and contacttitle is not null and region is not null

--12 Select all product names from the Products table that are condiments

select p.productname, c.categoryname from products p 
inner join categories c on p.categoryId=c.categoryid
where p.categoryid=2

--13 Select a list of customer names who have no orders in the Orders table.

SELECT ContactName FROM Customers WHERE CustomerID NOT IN (SELECT CustomerID  FROM Orders);

--14 Add a shipper named 'Amazon' to the Shippers table using SQL

insert into shippers (companyname) values('Amazon');

--15 Change the company name from 'Amazon' to 'Amazon Prime Shipping' in the Shippers table using SQL.

update shippers set companyname='Amazon Prime Shipping ' where companyname='Amazon'

--16  Select a complete list of company names from the Shippers table. Include freight totals rounded to the nearest whole number for each shipper from the Orders table for those shippers with orders.

SELECT s.CompanyName,ROUND(SUM(o.Freight), 0) AS TotalFreight FROM Shippers s JOIN Orders o ON s.ShipperID = o.ShipVia GROUP BY s.CompanyName;

--17 Select all employee first and last names from the Employees table by combining the 2 columns aliased as 'DisplayName'. The combined format should be 'LastName, FirstName'.

select lastname+', '+firstname as Displayname from employees;

--18 Add yourself to the Customers table with an order for 'Grandma's Boysenberry Spread'

    INSERT INTO Customers 
    (CustomerID, CompanyName, ContactName, City, Country)
    VALUES 
    ('RAHUL', 'Rahul Pvt Ltd', 'Rahul Sharma', 'Jaipur', 'India');


INSERT INTO Orders 
(CustomerID, EmployeeID, OrderDate, RequiredDate, ShipVia, Freight, ShipName)
VALUES 
('RAHUL', 1, GETDATE(), DATEADD(DAY, 7, GETDATE()), 1, 100, 'Rahul Order');

DECLARE @OrderID INT;
SET @OrderID = SCOPE_IDENTITY();

INSERT INTO orderdetails
(OrderID, ProductID, UnitPrice, Quantity, Discount)
SELECT 
    @OrderID,
    ProductID,
    UnitPrice,
    1,
    0
FROM Products
WHERE ProductName = 'Grandma''s Boysenberry Spread';

--19 Remove yourself and your order from the database

DELETE FROM OrderDetails
WHERE OrderID IN (
    SELECT OrderID 
    FROM Orders 
    WHERE CustomerID = 'RAHUL'
);


DELETE FROM Orders
WHERE CustomerID = 'RAHUL';


DELETE FROM Customers
WHERE CustomerID = 'RAHUL';

--20 Select a list of products from the Products table along with the total units in 
--    stock for each product. Give the computed column a name using the alias, 
--    'TotalUnits'. Include only products with TotalUnits greater than 100

SELECT ProductName,UnitsInStock AS TotalUnit FROM Products WHERE UnitsInStock > 100;
