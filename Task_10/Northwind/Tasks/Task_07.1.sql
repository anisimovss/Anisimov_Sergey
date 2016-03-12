select emp.LastName,
	ter.TerritoryDescription
	from Northwind.Employees as emp
	join Northwind.EmployeeTerritories as empt on emp.EmployeeID = empt.EmployeeID
	join Northwind.Territories as ter on empt.TerritoryID = ter.TerritoryID
	join Northwind.Region as reg on ter.RegionID = reg.RegionID