/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
CREATE PROCEDURE [dbo].[SelectByStatus]
	@status int 
AS
	SELECT Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id
FROM dbo.Orders
WHERE status=@status

GO
CREATE PROCEDURE [dbo].[SelectByProductId]
	@product_id int 
AS
	SELECT Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id
FROM dbo.Orders
WHERE Product_Id=@product_id

GO
CREATE PROCEDURE [dbo].[SelectByYear]
	@year int 
AS
	SELECT Orderd_Id, Status, CreatedDate, UpdatedDate, Product_Id
FROM dbo.Orders
WHERE Year(CreatedDate)=@year
GO
