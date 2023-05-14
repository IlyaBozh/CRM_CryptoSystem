CREATE PROCEDURE [dbo].[Account_Add]
	@Currency tinyint,
	@Status tinyint,
	@LeadId int
AS
BEGIN
	INSERT INTO dbo.[Account](
			CryptoCurrency,
			[Status],
			LeadId)
	VALUES(
			@Currency,
			@Status,
			@LeadId)

	SELECT @@IDENTITY
END

