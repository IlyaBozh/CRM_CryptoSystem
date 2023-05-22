CREATE PROCEDURE [dbo].[Account_Add]
	@CryptoCurrency tinyint,
	@Status tinyint,
	@LeadId int
AS
BEGIN
	INSERT INTO dbo.[Account](
			CryptoCurrency,
			[Status],
			LeadId)
	VALUES(
			@CryptoCurrency,
			@Status,
			@LeadId)

	SELECT @@IDENTITY
END

