


CREATE procedure [dbo].[Product_Order_Add_Or_Update]
	@id bigint = null,
	@ProductId bigint,
	@OrderId bigint,
	@Quantity int
as
begin
merge  dbo.[Product_Order] p
using (values (@id)) n(Id) 
on p.Id = n.Id 
when matched
	then update 
		set p.ProductId = @ProductId,
			p.OrderId = @OrderId,
			p.Quantity = @Quantity
			
when not matched 
	then insert (ProductId,
				 OrderId,
				 Quantity) 
		values (@ProductId,
				@OrderId,
				@Quantity);
	declare @inserted bigint = CAST(SCOPE_IDENTITY() as [bigint])
	if @id > 0 exec Product_Order_GetById @id
	else exec Product_Order_GetById @inserted
end

