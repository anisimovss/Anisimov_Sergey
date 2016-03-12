select ContactName, Country 
	from Northwind.Customers
	where Country in ('USA', 'Canada')
	order by ContactName, Country