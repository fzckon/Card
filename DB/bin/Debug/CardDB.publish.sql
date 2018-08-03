/*
Card 的部署脚本

此代码由工具生成。
如果重新生成此代码，则对此文件的更改可能导致
不正确的行为并将丢失。
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Card"
:setvar DefaultFilePrefix "Card"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
请检测 SQLCMD 模式，如果不支持 SQLCMD 模式，请禁用脚本执行。
要在启用 SQLCMD 模式后重新启用脚本，请执行:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'要成功执行此脚本，必须启用 SQLCMD 模式。';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
必须添加表 [dbo].[Card] 中的列 [dbo].[Card].[CardCvv2]，但该列无默认值，也不允许使用 NULL 值。如果表中包含数据，ALTER 脚本将不能工作。为避免此问题，必须: 向该列添加默认值，或者将其标记为允许使用 NULL 值，或者启用智能默认值生成功能作为部署选项。
*/

IF EXISTS (select top 1 1 from [dbo].[Card])
    RAISERROR (N'检测到行。由于可能丢失数据，正在终止架构更新。', 16, 127) WITH NOWAIT

GO
PRINT N'从重构日志文件 99d4b297-6b89-4340-9343-a9c32d3b414b 生成了以下操作';

PRINT N'将 [dbo].[Bill].[Status] 重命名为 BillStatus';


GO
EXECUTE sp_rename @objname = N'[dbo].[Bill].[Status]', @newname = N'BillStatus', @objtype = N'COLUMN';


GO
PRINT N'从重构日志文件 54d1d401-8f0b-43ec-a4d4-48bee890e528 生成了以下操作';

PRINT N'将 [dbo].[Bill].[Amount] 重命名为 BillAmount';


GO
EXECUTE sp_rename @objname = N'[dbo].[Bill].[Amount]', @newname = N'BillAmount', @objtype = N'COLUMN';


GO
PRINT N'从重构日志文件 a71c139f-b547-4409-8f0f-35193d1c3d14 生成了以下操作';

PRINT N'将 [dbo].[Card].[BillingDate] 重命名为 BillingDay';


GO
EXECUTE sp_rename @objname = N'[dbo].[Card].[BillingDate]', @newname = N'BillingDay', @objtype = N'COLUMN';


GO
PRINT N'从重构日志文件 20160cc4-6ba9-4124-9f38-b8b830ee5a11 生成了以下操作';

PRINT N'将 [dbo].[Card].[RepayDate] 重命名为 RepayDay';


GO
EXECUTE sp_rename @objname = N'[dbo].[Card].[RepayDate]', @newname = N'RepayDay', @objtype = N'COLUMN';


GO
PRINT N'从重构日志文件 c39f917f-f599-454d-8c56-5612a8a96ac6 生成了以下操作';

PRINT N'将 [dbo].[Card].[Amount] 重命名为 CardAmount';


GO
EXECUTE sp_rename @objname = N'[dbo].[Card].[Amount]', @newname = N'CardAmount', @objtype = N'COLUMN';


GO
PRINT N'从重构日志文件 50b68946-02e0-4609-b7e5-c6b67f12eb5c 生成了以下操作';

PRINT N'将 [dbo].[Friends].[Status] 重命名为 FriendStatus';


GO
EXECUTE sp_rename @objname = N'[dbo].[Friends].[Status]', @newname = N'FriendStatus', @objtype = N'COLUMN';


GO
PRINT N'从重构日志文件 d46bdc7a-7827-4b98-8c15-5b55c21b4d64 生成了以下操作';

PRINT N'将 [dbo].[UserPwd].[Status] 重命名为 PwdStatus';


GO
EXECUTE sp_rename @objname = N'[dbo].[UserPwd].[Status]', @newname = N'PwdStatus', @objtype = N'COLUMN';


GO
PRINT N'已跳过具有键 53fe9cc3-a1cd-4030-9d7d-d505897caf61 的重命名重构操作，不会将元素 [dbo].[CardShare].[Status] (SqlSimpleColumn) 重命名为 CardShareStatus';


GO
PRINT N'正在删除 [dbo].[Card] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Card] DROP CONSTRAINT [DF__Card__CardOrg__440B1D61];


GO
PRINT N'正在改变 [dbo].[Bill]...';


GO
ALTER TABLE [dbo].[Bill]
    ADD [Remark] NVARCHAR (500) NULL;


GO
PRINT N'正在开始重新生成表 [dbo].[Card]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Card] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [CardType]     INT              DEFAULT 1 NOT NULL,
    [CardOrg]      INT              DEFAULT 1 NOT NULL,
    [CardStatus]   INT              DEFAULT 1 NOT NULL,
    [CardLevel]    INT              DEFAULT 1 NULL,
    [CardCurrency] INT              DEFAULT 1 NULL,
    [CardNo]       VARCHAR (32)     NOT NULL,
    [CardCvv]      CHAR (7)         NOT NULL,
    [CardCvv2]     CHAR (3)         NOT NULL,
    [CardName]     NVARCHAR (50)    NULL,
    [BankId]       UNIQUEIDENTIFIER NOT NULL,
    [OpenBankName] NVARCHAR (100)   NULL,
    [ValidThru]    CHAR (4)         NULL,
    [ValidDate]    DATE             NULL,
    [ReservedTel]  CHAR (11)        NOT NULL,
    [QPassword]    CHAR (6)         NULL,
    [Password]     CHAR (6)         NULL,
    [BillingDay]   INT              NULL,
    [RepayDay]     INT              NULL,
    [CardAmount]   DECIMAL (18, 2)  NULL,
    [TempAmount]   DECIMAL (18, 2)  NULL,
    [HandleDate]   DATE             NULL,
    [CreateTime]   DATETIME         NOT NULL,
    [Remark]       NVARCHAR (500)   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Card])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Card] ([Id], [CardType], [CardOrg], [CardStatus], [CardLevel], [CardNo], [CardCvv], [CardName], [BankId], [OpenBankName], [ValidThru], [ValidDate], [ReservedTel], [QPassword], [Password], [BillingDay], [RepayDay], [CardAmount], [TempAmount], [HandleDate], [CreateTime])
        SELECT   [Id],
                 [CardType],
                 [CardOrg],
                 [CardStatus],
                 [CardLevel],
                 [CardNo],
                 [CardCvv],
                 [CardName],
                 [BankId],
                 [OpenBankName],
                 [ValidThru],
                 [ValidDate],
                 [ReservedTel],
                 [QPassword],
                 [Password],
                 [BillingDay],
                 [RepayDay],
                 [CardAmount],
                 [TempAmount],
                 [HandleDate],
                 [CreateTime]
        FROM     [dbo].[Card]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[Card];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Card]', N'Card';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'正在改变 [dbo].[User]...';


GO
ALTER TABLE [dbo].[User]
    ADD [Status] INT DEFAULT 1 NOT NULL;


GO
PRINT N'正在创建 [dbo].[CardShare]...';


GO
CREATE TABLE [dbo].[CardShare] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [CardId]          UNIQUEIDENTIFIER NOT NULL,
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [CardShareStatus] INT              NOT NULL,
    [CreateTime]      DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
-- 正在重构步骤以使用已部署的事务日志更新目标服务器
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '99d4b297-6b89-4340-9343-a9c32d3b414b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('99d4b297-6b89-4340-9343-a9c32d3b414b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '54d1d401-8f0b-43ec-a4d4-48bee890e528')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('54d1d401-8f0b-43ec-a4d4-48bee890e528')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a71c139f-b547-4409-8f0f-35193d1c3d14')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a71c139f-b547-4409-8f0f-35193d1c3d14')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '20160cc4-6ba9-4124-9f38-b8b830ee5a11')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('20160cc4-6ba9-4124-9f38-b8b830ee5a11')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c39f917f-f599-454d-8c56-5612a8a96ac6')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c39f917f-f599-454d-8c56-5612a8a96ac6')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '50b68946-02e0-4609-b7e5-c6b67f12eb5c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('50b68946-02e0-4609-b7e5-c6b67f12eb5c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd46bdc7a-7827-4b98-8c15-5b55c21b4d64')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d46bdc7a-7827-4b98-8c15-5b55c21b4d64')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '53fe9cc3-a1cd-4030-9d7d-d505897caf61')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('53fe9cc3-a1cd-4030-9d7d-d505897caf61')

GO

GO
PRINT N'更新完成。';


GO
