select distinct [outer].LastName + ' ' + [outer].FirstName as 'Seller' 
	from Northwind.Employees [outer]
	where 150 < 
		(
			select COUNT([inner].EmployeeID)
			from Northwind.Orders [inner]
		)