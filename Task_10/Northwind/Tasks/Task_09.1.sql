select CompanyName 
	from Northwind.Suppliers
	where SupplierID in 
		(
		select SupplierID 
			from Northwind.Products 
			where UnitsInStock = 0 
		)