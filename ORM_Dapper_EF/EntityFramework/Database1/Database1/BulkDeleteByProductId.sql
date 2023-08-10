CREATE PROCEDURE [dbo].[BulkDeleteByProductId]
	@product_id INT
AS
	DELETE FROM [dbo].[Orders]
	WHERE Product_Id = @product_id
