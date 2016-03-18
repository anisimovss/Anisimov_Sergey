--select * from Northwind.Orders

alter procedure Northwind.ShippedOrdersDiff
	@SpecifiedDelay int
as 
begin
	select OrderID,
		OrderDate,
		ShippedDate,
		DATEDIFF(dd, OrderDate, ShippedDate) as 'ShippedDelay',
		@SpecifiedDelay as 'SpecifiedDelay'
		from Northwind.Orders
		where (DATEDIFF(dd, OrderDate, ShippedDate) > @SpecifiedDelay) or (ShippedDate is null)
end