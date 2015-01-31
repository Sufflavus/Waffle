USE [Waffle]
GO

/****** Object:  Table [dbo].[User]    Script Date: 01/31/2015 21:46:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsOnline] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_IsOnline]  DEFAULT ((0)) FOR [IsOnline]
GO

GO

/****** Object:  Table [dbo].[Message]    Script Date: 01/31/2015 21:48:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Message](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO

ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [DF_Message_CreateTime]  DEFAULT (getdate()) FOR [CreateDate]
GO