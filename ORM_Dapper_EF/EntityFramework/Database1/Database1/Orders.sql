CREATE TABLE [dbo].[Orders]
(
    [Orderd_Id] INT NOT NULL IDENTITY (1, 1) PRIMARY KEY, 
    [Status] INT NULL, 
    [CreatedDate] DATETIME NULL, 
    [UpdatedDate] DATETIME NULL, 
    [Product_Id] INT NULL,
    CONSTRAINT [FK_order_product] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Product] ([Product_Id])
)