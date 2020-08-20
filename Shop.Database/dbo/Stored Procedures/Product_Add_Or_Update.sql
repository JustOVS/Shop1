

CREATE procedure [dbo].[Product_Add_Or_Update]
	@id bigint,
	@price money,
	@manufacturer nvarchar(30),
	@model nvarchar(30),
	@yearOfManufacture int,
	@length int,
	@width int,
	@height int,
	@airSpeed int,
	@dryingMode bit,
	@numberOfRecipes int,
	@numberOfNozzles int,
	@power int,
	@volume int,
	@descalingProtection bit,
	@noiseLevel int,
	@numberOfCompartments int,
	@numberOfModes int
as
begin
merge  dbo.[Product] p
using (values (@id)) n(Id) 
on p.id = n.Id 
when matched and p.IsDeleted=0
	then update 
		set p.Price = @price,
			p.Manufacturer = @manufacturer,
			p.Model = @model,
			p.YearOfManufacture = @yearOfManufacture,
			p.Length =@length,
			p.Width = @width,
			p.Height = @height,
			p.AirSpeed = @airSpeed,
			p.DryingMode = @dryingMode,
			p.NumberOfRecipes = @numberOfRecipes,
			p.NumberOfNozzles = @numberOfNozzles,
			p.Power = @power,
			p.Volume = @volume,
			p.DescalingProtection = @descalingProtection,
			p.NoiseLevel = @noiseLevel,
			p.NumberOfCompartments = @numberOfCompartments,
			p.NumberOfModes = @numberOfModes
when not matched 
	then insert (Price, 
				 Manufacturer, 
				 Model, 
				 YearOfManufacture,
				 Length, 
				 Width, 
				 Height,
				 AirSpeed,
				 DryingMode,
				 NumberOfRecipes,
				 NumberOfNozzles,
				 Power,
				 Volume,
				 DescalingProtection,
				 NoiseLevel,
				 NumberOfCompartments,
				 NumberOfModes,
				 IsDeleted) 
		values (@price,
				@manufacturer,
				@model,
				@yearOfManufacture,
				@length,
				@width,
				@height,
				@airSpeed,
				@dryingMode,
				@numberOfRecipes,
				@numberOfNozzles,
				@power,
				@volume,
				@descalingProtection,
				@noiseLevel,
				@numberOfCompartments,
				@numberOfModes, 
				default);
	declare @inserted bigint = CAST(SCOPE_IDENTITY() as [bigint])
	if @id !> 0  exec Product_GetById @inserted
end

