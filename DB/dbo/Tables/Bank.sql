﻿CREATE TABLE [dbo].[Bank]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [BankName] NVARCHAR(20) NOT NULL, 
    [BankAbbr] NVARCHAR(10) NOT NULL, 
	[EnBankName] VARCHAR(50) NOT NULL, 
    [EnBankAbbr] VARCHAR(10) NOT NULL,
    [Tel] VARCHAR(11) NOT NULL, 
    [Website] VARCHAR(100) NULL,
)
