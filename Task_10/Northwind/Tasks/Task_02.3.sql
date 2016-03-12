select distinct Country 
	from Northwind.Customers
	where ContactName is not null
	order by Country desc