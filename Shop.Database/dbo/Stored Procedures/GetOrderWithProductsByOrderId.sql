




CREATE procedure [dbo].[GetOrderWithProductsByOrderId]
@id bigint
as
begin
	select  o.id,
			o.Time,
			o.Address,
			o.CustomerId,
			po.id,
			po.Quantity,
			p.id,
			p.Price,
			p.Manufacturer,
			p.Model,
			p.YearOfManufacture

	from [dbo].[Order] o
	join [dbo].[Product_Order] po on o.id = po.OrderId
	join [dbo].[Product] p on p.id = po.ProductId
	where o.Id=@id and o.IsDeleted=0 and p.IsDeleted=0
end
