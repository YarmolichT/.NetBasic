USE SQL_Module8
 
DECLARE @EmployeeName NVARCHAR(50),
		@FirstName NVARCHAR(50),
		@LastName NVARCHAR(50),
		@CompanyName NVARCHAR(50),
		@Position NVARCHAR(30),
		@Street NVARCHAR(50),
		@City NVARCHAR(20),
		@State NVARCHAR(50),
		@ZipCode NVARCHAR(50)		

SET		@EmployeeName = 'YT'
SET		@FirstName ='Yarmolich'
SET     @LastName ='Tatsiana'
SET     @CompanyName ='ASD'
SET		@Position ='Dev'
SET		@Street ='BestStreet'
SET		@City ='Minak'
SET		@State ='MinskState'
SET		@ZipCode ='12389'
 
EXEC Insert_EmployeeInfo @FirstName , @LastName, @CompanyName, @Position, @Street,@City, @State,@ZipCode
 
SELECT * FROM Employee
				