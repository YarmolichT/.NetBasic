/*
Скрипт развертывания для SQL_Module8

Этот код был создан программным средством.
Изменения, внесенные в этот файл, могут привести к неверному выполнению кода и будут потеряны
в случае его повторного формирования.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SQL_Module8"
:setvar DefaultFilePrefix "SQL_Module8"
:setvar DefaultDataPath "C:\Users\Tatsiana_Yarmolich\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Tatsiana_Yarmolich\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Проверьте режим SQLCMD и отключите выполнение скрипта, если режим SQLCMD не поддерживается.
Чтобы повторно включить скрипт после включения режима SQLCMD выполните следующую инструкцию:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Для успешного выполнения этого скрипта должен быть включен режим SQLCMD.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
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
CREATE PROCEDURE [dbo].[insert_EmployeeInfo]
					(@FirstName NVARCHAR(50),
					@LastName NVARCHAR(50),
					@CompanyName NVARCHAR(50),
					@Position NVARCHAR(30),
					@Street NVARCHAR(50),
					@City NVARCHAR(20),
					@State NVARCHAR(50),
					@ZipCode NVARCHAR(50))
AS
	BEGIN

		DECLARE @letter_expression NVARCHAR(10) SET @letter_expression = '[A-Za-z]%'

		SET @FirstName = (CASE WHEN (@FirstName IS NULL OR TRIM(@FirstName) LIKE '') THEN ' ' 
								ELSE @FirstName END)

		SET @LastName = (CASE WHEN (@LastName IS NULL OR TRIM(@LastName) LIKE '') THEN ' '
								ELSE @LastName END)

		SET @CompanyName = (CASE WHEN LEN(@CompanyName)>20 THEN SUBSTRING(@CompanyName,0,20) 
								ELSE @CompanyName END)

IF(CONCAT(@FirstName, ' ', @LastName) LIKE @letter_expression OR 
				@FirstName LIKE @letter_expression OR 
				@LastName LIKE @letter_expression)
		BEGIN
			INSERT INTO dbo.[Person] ([FirstName], [LastName])
			VALUES(@FirstName, @LastName)

		DECLARE @person_identity INT = (SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY])

		INSERT INTO dbo.[Address]
						([Street], 
						[City], 
						[State], 
						[ZipCode])
				VALUES (@Street, 
					@City, 
					@State, 
					@ZipCode)

DECLARE @address_identity INT = (SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY])

			INSERT INTO dbo.[Employee]
						([AddressId], 
						[PersonId], 
						[CompanyName], 
						[Position], 
						[EmployeeName])
			VALUES (@address_identity,
					@person_identity, 
					@CompanyName, 
					@Position, 
					CONCAT(@FirstName, ' ', @LastName))
		END
END
GO

GO
PRINT N'Обновление завершено.';


GO
