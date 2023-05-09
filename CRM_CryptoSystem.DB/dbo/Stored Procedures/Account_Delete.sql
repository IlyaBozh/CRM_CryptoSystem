CREATE PROCEDURE [dbo].[Account_Delete]
	@Id int
AS
BEGIN
	UPDATE dbo.[Account]
	SET isDeleted = 1
	WHERE Id = @Id
END
