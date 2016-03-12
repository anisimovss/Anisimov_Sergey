select distinct convert(varchar(4), YEAR(ShippedDate)) as 'Year', COUNT(convert(varchar(4), YEAR(ShippedDate))) as 'Total'
	from Northwind.Orders
	where ShippedDate is not null
	group by convert(varchar(4), YEAR(ShippedDate))