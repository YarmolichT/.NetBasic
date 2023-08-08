CREATE PROCEDURE [dbo].[BulkDeleteByYear]
	@year INT
AS
	DELETE FROM [dbo].[Orders]
	WHERE Year(CreatedDate) = @year