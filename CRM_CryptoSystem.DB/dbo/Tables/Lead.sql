CREATE TABLE [dbo].[Lead] (
    [Id]               INT                   NOT NULL,
    [FirstName]        NCHAR (50)            NOT NULL,
    [LastName]         NCHAR (50)            NOT NULL,
    [Patronymic]       NCHAR (50)            NOT NULL,
    [Birthday]         DATETIME              NOT NULL,
    [Email]            NCHAR (50)            NOT NULL,
    [Phone]            NCHAR (15)            NOT NULL,
    [Login]            NCHAR (150)           NOT NULL,
    [Role]             TINYINT               NOT NULL,
    [Password]         NCHAR (255)           NOT NULL,
    [RegistrationDate] DATETIME              NOT NULL,
    [isDeleted]        BIT DEFAULT 0         NOT NULL
);

