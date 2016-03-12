select CONVERT(money, ROUND(SUM(Quantity*(UnitPrice - (UnitPrice * Discount)))*100,0,0)/100) as 'Total' 
	from Northwind.[Order Details]