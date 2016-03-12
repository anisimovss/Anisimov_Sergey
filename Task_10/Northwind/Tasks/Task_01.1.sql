select OrderID, ShippedDate, ShipVia
	from Northwind.Orders 
	where ShippedDate >= 1998-05-06 and ShipVia >= 2