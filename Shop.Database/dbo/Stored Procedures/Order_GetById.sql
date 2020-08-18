



create procedure [dbo].[Order_GetById]
@id bigint
as
begin
	select  o.id,
			o.Time,
			o.Address,
			o.CustomerId
	from [dbo].[Order] o
	where o.Id=@id and o.IsDeleted=0
end
