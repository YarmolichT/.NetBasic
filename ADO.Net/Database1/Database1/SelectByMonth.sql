CREATE PROCEDURE [dbo].[SelectByMonth]
	@month int 
AS
	SELECT Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id
FROM dbo.Orders
WHERE MONTH(CreatedDate)=@month
