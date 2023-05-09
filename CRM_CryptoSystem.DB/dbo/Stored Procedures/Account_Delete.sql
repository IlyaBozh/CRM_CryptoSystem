CREATE PROCEDURE [dbo].[Account_Delete]
	@Id int,
	@IsDeleted bit
AS
BEGIN
	UPDATE dbo.[Account]
	SET isDeleted = @IsDeleted
	WHERE Id = @Id
END
