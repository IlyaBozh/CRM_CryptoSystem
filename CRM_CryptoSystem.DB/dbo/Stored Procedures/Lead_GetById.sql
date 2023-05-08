CREATE PROCEDURE [dbo].[Lead_GetById]
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
		L.IsDeleted,
		A.Id,
		A.CryptoCurrency,
		A.[Status],
		A.IsDeleted
	FROM dbo.[Lead] AS L
	
	LEFT JOIN dbo.Account AS A ON (A.LeadId = L.Id)

	WHERE L.Id = @Id
END
