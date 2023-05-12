CREATE PROCEDURE [dbo].[Admin_GetAdminByEmail]
	@Email nvarchar(50)
AS
BEGIN
	SELECT Id, Email, [Password] FROM dbo.[Admin]
	WHERE Email = @Email AND IsDeleted = 0
END
