CREATE PROCEDURE [dbo].[Account_GetAll]

AS
BEGIN
	SELECT Id, CryptoCurrency, [Status], LeadId
	FROM dbo.[Account]
	WHERE IsDeleted = 0
END
