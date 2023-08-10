CREATE PROCEDURE [dbo].[SelectByProductId]
	@product_id int 
AS
	SELECT Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id
FROM dbo.Orders
WHERE Product_Id=@product_id