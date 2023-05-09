CREATE PROCEDURE [dbo].[Lead_GetAllInfoById]
	@Id int
AS
BEGIN

	SELECT
	
		L.Id, 
		L.FirstName, 
		L.LastName, 
		L.Patronymic, 
		L.Birthday, 
		L.Email, 
		L.Phone,
		L.[Login], 
		L.[Role], 
		L.RegistrationDate, 
		A.Id, 
		A.CryptoCurrency, 
		A.[Status] 
	FROM [dbo].[Lead] AS L
	LEFT JOIN [dbo].[Account] AS A ON L.Id = A.LeadId

	WHERE L.Id = @Id AND L.IsDeleted = 0 
END
