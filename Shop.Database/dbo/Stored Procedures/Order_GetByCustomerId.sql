


create procedure [dbo].[Order_GetByCustomerId]
@customerId int
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
			p.YearOfManufacture,
			p.Length,
			p.Width,
			p.Height,
			p.AirSpeed,
			p.DryingMode,
			p.NumberOfRecipes,
			p.NumberOfNozzles,
			p.Power,
			p.Volume,
			p.DescalingProtection,
			p.NoiseLevel,
			p.NumberOfCompartments,
			p.NumberOfModes

	
	from [dbo].[Order] o
	join [dbo].[Product_Order] po on o.id = po.OrderId
	join [dbo].[Product] p on p.id = po.ProductId
	where o.CustomerId=@customerId and o.IsDeleted=0 and p.IsDeleted=0
end
