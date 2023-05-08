CREATE PROCEDURE [dbo].[Lead_Add]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Patronymic nvarchar(50),
	@Birthday datetime,
	@Email nvarchar(50),
	@Phone nvarchar(15),
	@Login nvarchar(150),
	@Role tinyint,
	@Password nvarchar(255)
AS
BEGIN
INSERT INTO dbo.[Lead](
	FirstName,
	LastName,
	Patronymic,
	Birthday,
	Email,
	Phone,
	[Login],
	[Role],
	[Password],
	RegistrationDate)
VALUES(
	@FirstName,
	@LastName,
	@Patronymic,
	@Birthday,
	@Email,
	@Phone,
	@Login,
	@Role,
	@Password,
	GETDATE())

SELECT @@IDENTITY
END
