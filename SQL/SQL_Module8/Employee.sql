CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CompanyName] nvarchar(20) NOT NULL,
    [Position] nvarchar(30) NULL,
    [EmployeeName] nvarchar(100) NULL,
	[PersonId] INT NOT NULL,
	CONSTRAINT [FK_Employee_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id_Person]),
	[AddressId] INT NOT NULL,
	CONSTRAINT [FK_Employee_Address] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address]([Id_Address])	
)
