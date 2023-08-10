CREATE TABLE [dbo].[Product]
(
    [Product_Id] INT  IDENTITY (1, 1) NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NULL, 
    [Description] NCHAR(100) NULL, 
    [Weight] INT NULL, 
    [Height] INT NULL, 
    [Width] INT NULL, 
    [Length] INT NULL
)