select 
	distinct emp.LastName + ' ' + emp.FirstName as 'Seller',
	COUNT(ord.EmployeeID) as 'Amount'
	from Northwind.Orders as ord 
	join Northwind.Employees as emp on ord.EmployeeID = emp.EmployeeID
	group by emp.LastName + ' ' + emp.FirstName
	order by COUNT(ord.EmployeeID) desc 