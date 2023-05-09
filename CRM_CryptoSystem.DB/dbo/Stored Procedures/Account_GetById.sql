CREATE PROCEDURE [dbo].[Account_GetById]
	@Id int
AS
BEGIN

	SELECT Id, CryptoCurrency, [Status], LeadId
	FROM dbo.[Account]
	WHERE Id=@Id

END
