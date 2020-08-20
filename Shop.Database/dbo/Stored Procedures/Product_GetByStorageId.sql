

CREATE procedure [dbo].[Product_GetByStorageId]
@storageId int
as
begin
	select	p.id,
			p.Price,
			p.Manufacturer,
			p.Model,
			p.YearOfManufacture

	from dbo.[Product] p
	Join [Product_Storage] ps on ps.id = p.id
	where ps.StorageId=@storageId and p.IsDeleted=0
end
