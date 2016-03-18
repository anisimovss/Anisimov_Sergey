alter procedure Northwind.GreatestOrders
	@year datetime
as 
begin
	select emp.LastName + ' ' + emp.FirstName as 'Seller',
		ROUND(SUM(od.Quantity*(od.UnitPrice - (od.UnitPrice * od.Discount)))*100,0,0)/100 as Price 
		from Northwind.Employees as emp 
		join Northwind.Orders as o on emp.EmployeeID = o.EmployeeID 
		join Northwind.[Order Details] as od on o.OrderID = od.OrderID
		where convert(varchar(4), YEAR(o.OrderDate)) = @year
		group by emp.LastName + ' ' + emp.FirstName
end