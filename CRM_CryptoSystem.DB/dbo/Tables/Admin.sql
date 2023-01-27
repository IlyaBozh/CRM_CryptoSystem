CREATE TABLE [dbo].[Admin] (
    [Id]        BIGINT     NOT NULL,
    [Email]     NCHAR (50) NOT NULL,
    [Password]  NCHAR (25) NOT NULL,
    [IsDeleted] BIT        NOT NULL
);

