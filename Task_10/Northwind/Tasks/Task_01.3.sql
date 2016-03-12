select OrderID as 'Order Number', case when ShippedDate is null then 'Not Shipped' else convert(nchar, ShippedDate) end as 'Shipped Date'
	from Northwind.Orders
