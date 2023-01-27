CREATE TABLE [dbo].[Account] (
    [Id]             BIGINT  NOT NULL,
    [CryptoCurrency] TINYINT NOT NULL,
    [Status]         TINYINT NOT NULL,
    [LeadId]         INT     NOT NULL,
    [isDeleted]      BIT     NOT NULL
);

