alter function Northwind.IsBoss(@id int)
	returns bit
as
begin
	declare @result bit;
	set @result = 
		(
			select distinct convert(bit,Count(ReportsTo))
				from Northwind.Employees 
				where @id = ReportsTo
		);
	return(@result);
end

--Пример
--select distinct Northwind.IsBoss(2) as 'Result' from Northwind.Employees  
