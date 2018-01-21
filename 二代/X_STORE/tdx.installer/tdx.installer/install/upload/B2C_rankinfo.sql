

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_rankinfo_score]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_rankinfo] DROP CONSTRAINT [DF_B2C_rankinfo_score]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_rankinfo_overdays]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_rankinfo] DROP CONSTRAINT [DF_B2C_rankinfo_overdays]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_rankinfo_cardid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_rankinfo] DROP CONSTRAINT [DF_B2C_rankinfo_cardid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_rankinfo_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_rankinfo] DROP CONSTRAINT [DF_B2C_rankinfo_create_time]
END

GO



/****** Object:  Table [dbo].[B2C_rankinfo]    Script Date: 11/17/2014 19:44:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_rankinfo]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_rankinfo]
GO



/****** Object:  Table [dbo].[B2C_rankinfo]    Script Date: 11/17/2014 19:44:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_rankinfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[score] [int] NOT NULL,
	[overdays] [int] NOT NULL,
	[des] [varchar](255) NULL,
	[cardid] [int] NOT NULL,
	[create_time] [datetime] NULL,
 CONSTRAINT [PK_B2C_rankinfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_rankinfo] ADD  CONSTRAINT [DF_B2C_rankinfo_score]  DEFAULT ((0)) FOR [score]
GO

ALTER TABLE [dbo].[B2C_rankinfo] ADD  CONSTRAINT [DF_B2C_rankinfo_overdays]  DEFAULT ((0)) FOR [overdays]
GO

ALTER TABLE [dbo].[B2C_rankinfo] ADD  CONSTRAINT [DF_B2C_rankinfo_cardid]  DEFAULT ((0)) FOR [cardid]
GO

ALTER TABLE [dbo].[B2C_rankinfo] ADD  CONSTRAINT [DF_B2C_rankinfo_create_time]  DEFAULT (getdate()) FOR [create_time]
GO


