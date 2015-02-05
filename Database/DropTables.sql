USE [Waffle]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Message_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Message]'))
ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_Message_User]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Message_User1]') AND parent_object_id = OBJECT_ID(N'[dbo].[Message]'))
ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_Message_User1]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Message_Id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Message] DROP CONSTRAINT [DF_Message_Id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Message_CreateDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Message] DROP CONSTRAINT [DF_Message_CreateDate]
END

GO

USE [Waffle]
GO

/****** Object:  Table [dbo].[Message]    Script Date: 02/05/2015 21:04:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Message]') AND type in (N'U'))
DROP TABLE [dbo].[Message]
GO


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_User_Id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_Id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_User_IsOnline]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[User] DROP CONSTRAINT [DF_User_IsOnline]
END

GO

USE [Waffle]
GO

/****** Object:  Table [dbo].[User]    Script Date: 02/05/2015 21:04:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO


