CREATE DATABASE TestData
GO

USE TestData
GO

CREATE TABLE dbo.Products  (
	ProductID int PRIMARY KEY NOT NULL,  
	ProductName varchar(25) NOT NULL,  
	Price money NULL,  
	ProductDescription text NULL
)  
GO

INSERT dbo.Products (ProductID, ProductName, Price, ProductDescription)  
    VALUES (1, 'Clamp', 12.48, 'Workbench clamp')  
GO

INSERT dbo.Products (ProductName, ProductID, Price, ProductDescription)  
    VALUES ('Screwdriver', 50, 3.17, 'Flat head')  
GO

INSERT dbo.Products  
    VALUES (75, 'Tire Bar', NULL, 'Tool for changing tires.')  
GO

INSERT Products (ProductID, ProductName, Price)  
    VALUES (3000, '3mm Bracket', .52)  
GO

UPDATE dbo.Products  
    SET ProductName = 'Flat Head Screwdriver'  
    WHERE ProductID = 50  
GO


CREATE VIEW vw_Names  
   AS  
   SELECT ProductName, Price FROM Products;  
GO

CREATE PROCEDURE pr_Names @VarPrice money  
   AS  
   BEGIN  
      -- The print statement returns text to the user  
      PRINT 'Products less than ' + CAST(@VarPrice AS varchar(10));  
      -- A second statement starts here  
      SELECT ProductName, Price FROM vw_Names  
            WHERE Price < @varPrice;  
   END  
GO