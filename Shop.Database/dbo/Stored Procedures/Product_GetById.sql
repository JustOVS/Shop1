CREATE procedure [dbo].[Product_GetById]
@id bigint
as
begin
	select  p.Price,
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
	
	from dbo.[Product] p
	where p.id=@id and p.IsDeleted=0
end