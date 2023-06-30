CREATE TABLE [dbo].[Address]
(
	[Id_Address] INT NOT NULL PRIMARY KEY IDENTITY,
	[Street] nvarchar(50) not NULL,
    [City] nvarchar(20) NULL,
    [State] nvarchar(50) NULL,
    [ZipCode] nvarchar(50) NULL
)
