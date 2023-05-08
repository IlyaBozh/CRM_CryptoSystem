CREATE PROCEDURE [dbo].[Lead_GetAll]

AS
	SELECT 
			Id, 
			FirstName, 
			LastName, 
			Patronymic, 
			Birthday, 
			Email, 
			Phone,
			Passport, 
			City, 
			[Address], 
			[Role], 
			RegistrationDate
	FROM dbo.[Lead]
	WHERE (IsDeleted = 0)

END
