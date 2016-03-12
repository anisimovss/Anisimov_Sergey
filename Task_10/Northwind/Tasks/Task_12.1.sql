select  distinct SUBSTRING(LastName,1,1) as 'Fist symbol'
	from Northwind.Employees
	order by SUBSTRING(LastName,1,1) 