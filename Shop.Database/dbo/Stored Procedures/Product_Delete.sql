CREATE procedure [dbo].[Product_Delete]
	@id bigint
as
begin
	update dbo.[Product]
	set IsDeleted = 1
	where Id = @id;
end;