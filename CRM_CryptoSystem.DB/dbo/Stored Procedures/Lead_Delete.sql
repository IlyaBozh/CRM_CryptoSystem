CREATE PROCEDURE [dbo].[Lead_Delete]
		@id int,
		@isDeleted bit

AS
BEGIN

	UPDATE dbo.[Lead]
	SET isDeleted = @isDeleted
	WHERE Id = @Id

END