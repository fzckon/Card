CREATE TABLE [dbo].[Bill]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [CardId] UNIQUEIDENTIFIER NOT NULL, 
    [BillingDate] DATE NOT NULL, 
    [RepayDate] DATE NOT NULL, 
    [BillAmount] DECIMAL(18, 2) NOT NULL, 
    [RepayAmount] DECIMAL(18, 2) NULL, 
    [BillStatus] INT NOT NULL DEFAULT 1, 
    [CreateTime] DATETIME NOT NULL, 
    [Remark] NVARCHAR(500) NULL, 
)
