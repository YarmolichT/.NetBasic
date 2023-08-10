CREATE PROCEDURE [dbo].[SelectByYear]
	@year int 
AS
	SELECT Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id
FROM dbo.Orders
WHERE Year(CreatedDate)=@year