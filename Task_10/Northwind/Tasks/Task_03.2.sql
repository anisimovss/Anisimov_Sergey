select CustomerID, Country
	from Northwind.Customers
	where Country between 'B' and 'H'
	order by Country