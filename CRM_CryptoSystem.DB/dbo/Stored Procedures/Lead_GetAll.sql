CREATE PROCEDURE [dbo].[Lead_GetAll]

AS
BEGIN
	SELECT 
		Id, 
		FirstName, 
		LastName, 
		Patronymic, 
		Birthday, 
		Email, 
		Phone,
		[Login], 
		[Role], 
		RegistrationDate
	FROM dbo.[Lead]
	WHERE (IsDeleted = 0)

END
