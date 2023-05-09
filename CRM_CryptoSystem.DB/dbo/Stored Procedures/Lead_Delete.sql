CREATE PROCEDURE [dbo].[Lead_Delete]
		@Id int,
		@IsDeleted bit

AS
BEGIN

	UPDATE dbo.[Lead]
	SET isDeleted = @IsDeleted
	WHERE Id = @Id

END