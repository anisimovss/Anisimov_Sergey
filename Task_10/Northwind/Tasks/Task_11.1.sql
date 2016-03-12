select distinct [outer].CompanyName
	from Northwind.Customers [outer]
	where not exists 
		(
			select [inner].CustomerID
			from Northwind.Orders [inner]
			where [inner].CustomerID = [outer].CustomerID
		)