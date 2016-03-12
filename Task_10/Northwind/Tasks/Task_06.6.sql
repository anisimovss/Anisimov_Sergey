select emp2.LastName as 'User Name',
	emp1.LastName as 'Boss'
	from Northwind.Employees as emp1
	right join Northwind.Employees as emp2 on emp1.EmployeeID = emp2.ReportsTo
