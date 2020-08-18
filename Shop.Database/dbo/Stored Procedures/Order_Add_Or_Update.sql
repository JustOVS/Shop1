


CREATE procedure [dbo].[Order_Add_Or_Update]
	@id bigint,
	@address nvarchar(50),
	@customerId int

as
begin
declare @time datetime2(7) = SYSDATETIME()
merge  dbo.[Order] o
using (values (@id)) n(Id) 
on o.Id = n.Id 
when matched and o.IsDeleted=0
	then update 
		set o.Address = @address,
			o.CustomerId = @customerId,
			o.Time = @time
when not matched 
	then insert (Address,
				 Time,
				 CustomerId,
				 IsDeleted) 
		values (@address,
				@time,
				@CustomerId,
				default);
	declare @inserted bigint = CAST(SCOPE_IDENTITY() as [bigint])
	if @id > 0 exec Order_GetById @id
	else exec Order_GetById @inserted
end

