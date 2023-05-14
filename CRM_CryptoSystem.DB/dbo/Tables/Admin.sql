CREATE TABLE [dbo].[Admin] (
    [Id]        BIGINT IDENTITY     NOT NULL PRIMARY KEY,
    [Email]     NCHAR (50)          NOT NULL,
    [Password]  NCHAR (255)         NOT NULL,
    [IsDeleted] BIT DEFAULT 0       NOT NULL
);

