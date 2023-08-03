CREATE PROCEDURE [dbo].[SelectByStatus]
	@status int 
AS
	SELECT Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id
FROM dbo.Orders
WHERE status=@status