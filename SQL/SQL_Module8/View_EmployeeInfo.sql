CREATE VIEW [dbo].[View_EmployeeInfo]
    AS SELECT Employee.Id ,
    (CASE WHEN EmployeeName = NULL THEN CONCAT(PersonJoined.FirstName, ' ', PersonJoined.LastName)
                        ELSE EmployeeName
                        END) AS EmployeeFullName,

     CONCAT(AddressJoined.ZipCode, '_', AddressJoined.State, '_', AddressJoined.City, '_',AddressJoined.Street) as EmployeeFullAddress,
     CONCAT( CompanyName,'-',Position) as EmployeeCompanyInfo

     FROM Employee
     JOIN Person as PersonJoined ON Employee.PersonId = PersonJoined.Id_Person 
     JOIN Address as AddressJoined ON Employee.AddressId = AddressJoined.Id_Address
     ORDER BY CompanyName ASC, AddressJoined.City ASC offset 0 ROWS;