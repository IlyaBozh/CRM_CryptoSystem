﻿CREATE PROCEDURE [dbo].[Account_Update]
	@Id bigint,
	@Status tinyint
AS
BEGIN

	UPDATE dbo.[Account]
	SET [Status] = @Status
	WHERE Id = @Id

END
