select c.ContactName,
	COUNT(o.CustomerID) as 'Count'
	from Northwind.Customers as c
	left join Northwind.Orders as o on c.CustomerID = o.CustomerID
	group by c.ContactName
	order by COUNT(o.CustomerID)