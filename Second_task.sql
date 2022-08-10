CREATE TABLE [Customers] (
	Id int PRIMARY KEY IDENTITY,
	Name varchar(255) NOT NULL
)
GO
CREATE TABLE [Orders] (
	Id int PRIMARY KEY IDENTITY,
	CustomerId int REFERENCES [Customers] (Id) ON DELETE CASCADE

)

GO
INSERT INTO [Customers] VALUES ('Max'), ('Pavel'), ('Ivan'), ('Leonid')
GO
INSERT INTO [Orders] VALUES (2),(4)
GO

SELECT Name FROM [Customers] LEFT JOIN [Orders] ON CustomerId = [Customers].Id WHERE CustomerId IS NULL
