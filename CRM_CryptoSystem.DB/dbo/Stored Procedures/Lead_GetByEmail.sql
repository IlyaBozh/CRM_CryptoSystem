CREATE PROCEDURE [dbo].[Lead_GetByEmail]
		@Email nvarchar(50)

AS
BEGIN

	SELECT 
		Id, 
		FirstName, 
		LastName, 
		Email,
		[Password]
	FROM dbo.[Lead]
	WHERE Email = @Email AND IsDeleted = 0

END
