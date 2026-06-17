--Assignment 3----
--q1
select* from Products;
--q2
select ProductName,UnitPrice,UnitsInStock from Products where Discontinued=0;

--q3
select* from Products
select productName,Unitprice from Products where UnitPrice>50 order by UnitPrice desc

--q4
select* from Customers
select customerID,companyname,country from Customers where Country in ('germany','USA','france')

--q5
select ProductName,categoryid from Products where ProductName like 'c%'

--q6
select* from orders
select orderid,customerid,orderdate from orders where OrderDate between '1996-01-01' and '1996-12-31';

--q7
select productname,unitprice,UnitsInStock from Products where (UnitsInStock=0 or UnitPrice<10);

--q8
select firstname,lastname,title from Employees where lastname between 'D' and 'm';

--q9
select TOP 10 ProductName, UnitPrice 
from Products 
order by UnitPrice DESC;

--q10
select orderid, Customerid,orderdate from Orders where ShippedDate is null;


--q11
select productname,Categoryname from Products
 inner join Categories on .Categories.CategoryID=Products.CategoryID
 
 --q12
 select Orders.orderid,Orders.orderdate,companyname,contactname from Orders
 join Customers on Orders.CustomerID=Customers.CustomerID

 --q13
 select* from Suppliers
 select* from Products
 select Products.ProductName,Suppliers.companyname,Products.unitprice from Products
 inner join Suppliers   on Suppliers.SupplierID=Products.SupplierID 

 --q14
 select* from Products
 select OrderDetails.orderid,Products.productname,OrderDetails.quantity,Products.UnitPrice from OrderDetails
 inner join Products on OrderDetails.ProductID=Products.ProductID

 --q15
 select
    e.EmployeeID,
    e.FirstName AS EmployeeFirstName,
    e.LastName AS EmployeeLastName,
    m.FirstName AS ManagerFirstName,
    m.LastName AS ManagerLastName
FROM Employees e
LEFT JOIN Employees m
ON e.ReportsTo = m.EmployeeID;

--q16
select* from Orders
select* from Customers
select Orders.customerid,.customers.Companyname,Orders.orderid from Orders
left join Customers on Orders.CustomerID=Customers.CustomerID

--q17
select* from Customers
select* from Orders
select* from Employees
select orderid,companyname,(firstname+lastname) as [employees full name] from Orders
inner join Customers on Customers.CustomerID=Orders.CustomerID
inner join Employees on Orders.EmployeeID=Employees.EmployeeID

--q18
select* from Products
select* from Categories
select products.ProductName,categories.CategoryName from Products
left join Categories on Categories.CategoryID=Products.CategoryID

--q19
select* from Orders
select* from Categories
select
    od.OrderID,
    p.ProductName,
    od.Quantity,
    c.CategoryName
from OrderDetails od
INNER JOIN Products p 
    on od.ProductID = p.ProductID
INNER JOIN Categories c 
    on p.CategoryID = c.CategoryID;


    --20
    select TOP 100 
    c.CustomerID,
    o.OrderID
from Customers c
CROSS JOIN Orders o;

--21
SELECT COUNT(*) AS TotalProducts
FROM Products;

--22
SELECT AVG(CAST(UnitPrice AS DECIMAL(10,2))) as average FROM Products;

--23
select min(unitprice) as maximumvalue,max(unitprice) as minimumvalue from Products
--24
select* from Products
select COUNT(ProductName) as totalproducts,CategoryID from Products group by CategoryID

--25
select* from Products
select* from Categories
select categoryname, COUNT(ProductName)as totalproducts from Products
inner join Categories on Products.CategoryID=Categories.CategoryID
group by CategoryName

--26
select productid,sum(quantity) as [total quantites] from OrderDetails group by ProductID

--27
select* from Products
SELECT 
    c.CategoryName, 
    COUNT(p.ProductID) AS ProductCount
FROM 
    Categories c
JOIN 
    Products p ON c.CategoryID = p.CategoryID
GROUP BY 
    c.CategoryName
HAVING 
    COUNT(p.ProductID) > 10;

--q28
select* from OrderDetails
select orderID,sum(unitprice*quantity*(1-Discount))as [total amount] from OrderDetails group by  OrderID

--q29
select* from Categories
insert into Categories(CategoryName,Description) values ('organic foods','certified organic products');\
--30
insert into Products(ProductName,SupplierID,CategoryID,UnitPrice,UnitsInStock,Discontinued) values ('green tea',1,1,15.00,50,0)]

--31
update Products
set UnitPrice =UnitPrice*1.10
where CategoryID=1;

--32
update Customers
set phone='031-1234567'
where CustomerID='ALFKI'

--33
update Products
set Discontinued=1
where UnitsInStock=0


--34
delete from Products
where Discontinued = 1
AND ProductID NOT IN (select ProductID FROM OrderDetails);

--35
BEGIN TRY
    BEGIN TRANSACTION;

  
    INSERT INTO Customers (CustomerName, Email)
    VALUES ('sachin chaudhary', 'sachin@example.com');

  
    DECLARE @NewCustomerID INT = SCOPE_IDENTITY();

   
    INSERT INTO Orders (CustomerID, OrderDate, TotalAmount)
    VALUES (@NewCustomerID, GETDATE(), 150.00);

    
    COMMIT TRANSACTION;
    PRINT 'Transaction committed successfully.';
END TRY
BEGIN CATCH
  
    IF @@TRANSTRANCOUNT > 0
        ROLLBACK TRANSACTION;
    PRINT 'Transaction failed and rolled back.';
    PRINT 'Error Message: ' + ERROR_MESSAGE();
END CATCH;


--q36
select ProductName, UnitPrice
from Products
where UnitPrice > (select AVG(UnitPrice) from Products);

--q37
select customerid,companyname from Customers c where Exists (
SELECT 1 
    FROM Orders o 
    WHERE o.CustomerID = c.CustomerID
);
--q38
select *
FROM Products
WHERE SupplierID IN (
    SELECT SupplierID
    FROM Suppliers
    WHERE Country = 'Germany'
);

--q39
WITH OrderAverage AS (
    SELECT * 
    FROM OrderDetails
    WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM OrderDetails)
)
SELECT * FROM OrderAverage;
--40

   WITH CustomerOrderCounts AS (
    SELECT customerid, COUNT(orderid) AS total_orders 
    FROM orders 
    GROUP BY customerid
) 
SELECT customerid, total_orders 
FROM CustomerOrderCounts 
WHERE total_orders > 10;

--41
SELECT 
    CategoryID, 
    ProductName, 
    UnitPrice
FROM 
    Products 
WHERE 
    UnitPrice = (
        SELECT MAX(UnitPrice)
        FROM Products
    
    );
 --42
 SELECT *
FROM Customers c
WHERE NOT EXISTS (
    SELECT 1
    FROM Orders o
    WHERE o.CustomerID = c.CustomerID
);

--43
select* from products
select* from Categories
CREATE VIEW vw_ProductList AS
SELECT products.productid,products.productname,Categories.Categoryname,products.unitprice
FROM products
inner join Categories on Categories.CategoryID=products.CategoryID
where Discontinued=1
select* from vw_ProductList

--44
CREATE VIEW vw_OrderSummary AS
SELECT 
    O.OrderID, 
    C.CompanyName AS CustomerName, 
    O.OrderDate, 
    COUNT(OD.OrderID) AS NumberOfItems
FROM Orders O
JOIN Customers C ON O.CustomerID = C.CustomerID
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
GROUP BY O.OrderID, C.CompanyName, O.OrderDate;
--45
CREATE PROCEDURE usp_GetProductsByCategory
    @CategoryID INT
AS
BEGIN
    SELECT *
    FROM Products
    WHERE CategoryID = @CategoryID;
END;
--46
CREATE PROCEDURE usp_GetCustomerOrders
    @CustomerID INT 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        o.OrderID,
        o.OrderDate,
        od.ProductID,
        od.Quantity,
        od.UnitPrice
    FROM Orders o
    INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
    WHERE o.CustomerID = @CustomerID;
END;
GO
--47
CREATE PROCEDURE usp_AddCategory
    @CategoryName VARCHAR(50),
    @Description VARCHAR(MAX),
    @CategoryID INT OUTPUT
AS
BEGIN
      INSERT INTO Categories (CategoryName, Description)
    VALUES (@CategoryName, @Description);
    SET @CategoryID = SCOPE_IDENTITY();
END;

--48
CREATE PROCEDURE usp_UpdateProductPrice
    @ProductID INT,
    @NewPrice DECIMAL(18, 2)
AS
BEGIN
   
    IF @NewPrice <= 0
    BEGIN
        RAISERROR('The price must be greater than 0.', 16, 1);
        RETURN;
    END

    
    UPDATE Products
    SET UnitPrice = @NewPrice
    WHERE ProductID = @ProductID;
END;

--49
CREATE PROCEDURE usp_GetEmployeeSales
AS
BEGIN
    SELECT 
        Employees.EmployeeID, 
        Employees.FirstName + ' ' + Employees.LastName AS FullName, 
        SUM(OrderDetails.UnitPrice * OrderDetails.Quantity * (1 - OrderDetails.Discount)) AS TotalSales
    FROM Employees
    INNER JOIN Orders 
        ON Employees.EmployeeID = Orders.EmployeeID
    INNER JOIN OrderDetails
        ON Orders.OrderID = OrdeRDetails.OrderID
    GROUP BY 
        Employees.EmployeeID, 
        Employees.FirstName, 
        Employees.LastName;
END;

--40
CREATE PROCEDURE usp_GetMonthlyOrderStats
    @Year INT,
    @Month INT
AS
BEGIN
   
    SELECT 
        COUNT(OrderID) AS TotalOrders, 
        SUM(OrderID) AS TotalRevenue
    FROM Orders
    WHERE YEAR(OrderDate) = @Year 
      AND MONTH(OrderDate) = @Month;
END;





