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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'正在创建 $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'无法修改数据库设置。您必须是 SysAdmin 才能应用这些设置。';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'无法修改数据库设置。您必须是 SysAdmin 才能应用这些设置。';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'正在创建 [dbo].[Bank]...';


GO
CREATE TABLE [dbo].[Bank] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [BankName]   NVARCHAR (20)    NOT NULL,
    [BankAbbr]   NVARCHAR (10)    NOT NULL,
    [EnBankName] VARCHAR (50)     NOT NULL,
    [EnBankAbbr] VARCHAR (10)     NOT NULL,
    [Tel]        VARCHAR (11)     NOT NULL,
    [Website]    VARCHAR (100)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Bill]...';


GO
CREATE TABLE [dbo].[Bill] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [CardId]      UNIQUEIDENTIFIER NOT NULL,
    [BillingDate] DATE             NOT NULL,
    [RepayDate]   DATE             NOT NULL,
    [Amount]      DECIMAL (18, 2)  NOT NULL,
    [RepayAmount] DECIMAL (18, 2)  NULL,
    [Status]      INT              NOT NULL,
    [CreateTime]  DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Card]...';


GO
CREATE TABLE [dbo].[Card] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [CardType]     INT              NOT NULL,
    [CardOrg]      INT              NOT NULL,
    [CardStatus]   INT              NOT NULL,
    [CardLevel]    INT              NULL,
    [CardNo]       CHAR (16)        NOT NULL,
    [CardCvv]      CHAR (7)         NOT NULL,
    [CardName]     NVARCHAR (50)    NULL,
    [BankId]       UNIQUEIDENTIFIER NOT NULL,
    [OpenBankName] NVARCHAR (100)   NULL,
    [ValidThru]    CHAR (4)         NULL,
    [ValidDate]    DATE             NULL,
    [ReservedTel]  CHAR (11)        NOT NULL,
    [QPassword]    CHAR (6)         NULL,
    [Password]     CHAR (6)         NULL,
    [BillingDate]  INT              NULL,
    [RepayDate]    INT              NULL,
    [Amount]       DECIMAL (18, 2)  NULL,
    [TempAmount]   DECIMAL (18, 2)  NULL,
    [HandleDate]   DATE             NULL,
    [CreateTime]   DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Friends]...';


GO
CREATE TABLE [dbo].[Friends] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [FriendId]   UNIQUEIDENTIFIER NOT NULL,
    [Status]     INT              NOT NULL,
    [CreateTime] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [UserName]   NVARCHAR (100)   NOT NULL,
    [NickName]   NVARCHAR (100)   NULL,
    [FullName]   NVARCHAR (100)   NOT NULL,
    [Birthday]   DATE             NULL,
    [Sex]        INT              NULL,
    [Tel]        NCHAR (10)       NULL,
    [Email]      NVARCHAR (200)   NULL,
    [CreateTime] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[UserPwd]...';


GO
CREATE TABLE [dbo].[UserPwd] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [Password]   VARCHAR (128)    NULL,
    [Status]     INT              NOT NULL,
    [CreateTime] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[UserShare]...';


GO
CREATE TABLE [dbo].[UserShare] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [CardId]     UNIQUEIDENTIFIER NOT NULL,
    [UserId]     UNIQUEIDENTIFIER NOT NULL,
    [Status]     INT              NOT NULL,
    [CreateTime] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'正在创建 [dbo].[Bill] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Bill]
    ADD DEFAULT 1 FOR [Status];


GO
PRINT N'正在创建 [dbo].[Card] 上未命名的约束...';


GO
ALTER TABLE [dbo].[Card]
    ADD DEFAULT 1 FOR [CardOrg];


GO
-- 正在重构步骤以使用已部署的事务日志更新目标服务器

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c205e304-bb9f-4124-b624-551025afdf32')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c205e304-bb9f-4124-b624-551025afdf32')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4aa13a23-e688-4817-a3b0-2f5e31f62d61')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4aa13a23-e688-4817-a3b0-2f5e31f62d61')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '72e52614-1c27-4c6e-bcc7-d9e61e4a6fe7')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('72e52614-1c27-4c6e-bcc7-d9e61e4a6fe7')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b6fcabd5-57e8-49cd-9654-2d6a9fb16e71')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b6fcabd5-57e8-49cd-9654-2d6a9fb16e71')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '30a3d71b-1bdf-4f53-add4-3436b3fd137d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('30a3d71b-1bdf-4f53-add4-3436b3fd137d')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'更新完成。';


GO
