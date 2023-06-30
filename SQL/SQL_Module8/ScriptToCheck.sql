USE SQL_Module8
 
DECLARE @FirstName NVARCHAR(50),
		@LastName NVARCHAR(50),
		@CompanyName NVARCHAR(50),
		@Position NVARCHAR(30),
		@Street NVARCHAR(50),
		@City NVARCHAR(20),
		@State NVARCHAR(50),
		@ZipCode NVARCHAR(50)		

SET		@FirstName ='YArm'
SET     @LastName ='TAts'
SET     @CompanyName ='ASD'
SET		@Position ='Dev'
SET		@Street ='qwer'
SET		@City ='Minak'
SET		@State ='Pinsk'
SET		@ZipCode ='123'
 
EXEC Insert_EmployeeInfo @FirstName , @LastName, @CompanyName, @Position, @Street,@City, @State,@ZipCode
 
SELECT * FROM Employee
				