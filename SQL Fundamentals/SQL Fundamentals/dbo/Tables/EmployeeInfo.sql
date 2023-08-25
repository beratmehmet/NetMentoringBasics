CREATE VIEW [dbo].[EmployeeInfo]
	AS SELECT Employee.Id,
	CASE
		WHEN EmployeeName IS NULL THEN Person.FirstName +' '+ Person.LastName 
		ELSE EmployeeName
	END as EmployeeFullName,
	Address.Zipcode+'_'+Address.State+'-'+Address.Street as EmployeeFullAddress,
	Employee.CompanyName+'('+Employee.Position+')' as EmployeeCompanyInfo
	FROM [Employee] 
	INNER JOIN Person 
	ON Employee.PersonID = Person.Id
	INNER JOIN Address 
	ON Employee.AddressId = Address.Id