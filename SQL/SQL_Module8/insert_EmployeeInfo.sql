CREATE PROCEDURE [dbo].[Insert_EmployeeInfo]
					(@EmployeeName NVARCHAR(50) = '',
					@FirstName NVARCHAR(50) = '',
					@LastName NVARCHAR(50) = '',
					@CompanyName NVARCHAR(50),
					@Position NVARCHAR(30) = '',
					@Street NVARCHAR(50),
					@City NVARCHAR(20) = '',
					@State NVARCHAR(50) = '',
					@ZipCode NVARCHAR(50)= '')
AS
	BEGIN
		DECLARE @letter_expression NVARCHAR(10) SET @letter_expression = '[A-Za-z]%'

		SET @EmployeeName = (CASE WHEN (@EmployeeName IS NULL OR TRIM(@EmployeeName) LIKE '') THEN ' ' 
								ELSE @EmployeeName END)
		
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
						@EmployeeName)				
		END
END