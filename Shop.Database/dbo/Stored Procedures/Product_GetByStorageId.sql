CREATE procedure [dbo].[Product_GetByStorageId]
@storageId int
as
begin
	select	p.id,
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
			p.NumberOfModes,
			ps.Quantity
	
	from dbo.[Product] p
	Join [Product_Storage] ps on ps.id = p.id
	where ps.StorageId=@storageId and p.IsDeleted=0
end
