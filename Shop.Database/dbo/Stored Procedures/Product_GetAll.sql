CREATE procedure [dbo].[Product_GetAll]

as
begin
	select  p.id,
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
	
	from dbo.[Product] p
	where p.IsDeleted=0
end