USE [MusiquePT2_F]
GO

/****** Object:  Table [dbo].[ABONNÉS]    Script Date: 11/06/2021 16:53:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ABONNÉS](
	[CODE_ABONNÉ] [int] IDENTITY(1,1) NOT NULL,
	[CODE_PAYS] [int] NULL,
	[NOM_ABONNÉ] [char](32) NOT NULL,
	[PRÉNOM_ABONNÉ] [char](32) NOT NULL,
	[LOGIN_ABONNÉ] [char](32) NOT NULL,
	[PASSWORD_ABONNÉ] [char](256) NOT NULL,
	[isAdmin] [bit] NOT NULL,
	[creationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ABONNÉS] PRIMARY KEY CLUSTERED 
(
	[CODE_ABONNÉ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Login] UNIQUE NONCLUSTERED 
(
	[LOGIN_ABONNÉ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ABONNÉS]  WITH CHECK ADD  CONSTRAINT [FK_ABONNÉS_PAYS] FOREIGN KEY([CODE_PAYS])
REFERENCES [dbo].[PAYS] ([CODE_PAYS])
GO

ALTER TABLE [dbo].[ABONNÉS] CHECK CONSTRAINT [FK_ABONNÉS_PAYS]
GO
