
CREATE procedure [dbo].[Order_Delete]
	@id bigint
as
begin
	update dbo.[Order]
	set IsDeleted = 1
	where Id = @id;
end;
