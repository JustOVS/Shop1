



CREATE procedure [dbo].[Product_Order_GetById]
@id bigint
as
begin
	select  po.ProductId,
			po.OrderId,
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
	
	from dbo.[Product_Order] po
	join dbo.[Product] p on p.id = po.ProductId
	where po.Id=@id
end
