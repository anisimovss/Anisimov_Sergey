select OrderID, case when ShippedDate is null then 'Not Shipped' end as 'Shipped Date'
	from Northwind.Orders
	where ShippedDate is null 