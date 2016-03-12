select CustomerID, Country
	from Northwind.Customers
	where Country >= 'B' and Country <= 'H'
	order by Country