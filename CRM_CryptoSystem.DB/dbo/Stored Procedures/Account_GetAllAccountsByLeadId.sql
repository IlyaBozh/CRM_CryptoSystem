CREATE PROCEDURE [dbo].[Account_GetAllAccountsByLeadId]
	@leadId int
AS
BEGIN

	SELECT Id, CryptoCurrency, [Status], LeadId
	FROM dbo.[Account]
	WHERE IsDeleted = 0 AND LeadId = @leadId

END
