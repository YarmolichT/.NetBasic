CREATE PROCEDURE [dbo].[BulkDeleteByStatus]
	@status INT
AS
	DELETE FROM [dbo].[Orders]
	WHERE Status = @status
