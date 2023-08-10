CREATE PROCEDURE [dbo].[BulkDeleteByMonth]
	@month INT
AS
	DELETE FROM [dbo].[Orders]
	WHERE MONTH(CreatedDate) = @month
