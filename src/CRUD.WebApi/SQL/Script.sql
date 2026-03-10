
CREATE DATABASE CRUD;

GO 

USE CRUD;

GO

CREATE TABLE [dbo].[Products]
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name NVARCHAR(100) NOT NULL,
Description NVARCHAR(500) NULL,
Price DECIMAL(18,2) NOT NULL
);

GO

INSERT INTO [dbo].[Products] (Name, Description, Price)
VALUES
('Laptop', 'Dell Inspiron', 2500.00),
('Mouse', 'Wireless Mouse', 50.00),
('Keyboard', 'Mechnical Keyboard', 150.00);

GO