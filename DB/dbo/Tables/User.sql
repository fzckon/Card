CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(100) NOT NULL, 
    [NickName] NVARCHAR(100) NULL, 
    [FullName] NVARCHAR(100) NOT NULL, 
    [Birthday] DATE NULL, 
    [Sex] INT NULL, 
    [Tel] NCHAR(10) NULL, 
    [Email] NVARCHAR(200) NULL, 
    [CreateTime] DATETIME NOT NULL, 
    [Status] INT NOT NULL DEFAULT 1, 
)
