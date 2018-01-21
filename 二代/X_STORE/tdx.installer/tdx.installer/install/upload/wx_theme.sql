

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_theme_tvip]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_theme] DROP CONSTRAINT [DF_wx_theme_tvip]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_theme_theme_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_theme] DROP CONSTRAINT [DF_wx_theme_theme_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_theme_isActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_theme] DROP CONSTRAINT [DF_wx_theme_isActive]
END

GO



/****** Object:  Table [dbo].[wx_theme]    Script Date: 11/21/2014 17:55:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_theme]') AND type in (N'U'))
DROP TABLE [dbo].[wx_theme]
GO


/****** Object:  Table [dbo].[wx_theme]    Script Date: 11/21/2014 17:55:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_theme](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[t_name] [nvarchar](50) NULL,
	[t_theme] [nvarchar](50) NULL,
	[tvip] [tinyint] NOT NULL,
	[cid] [int] NOT NULL,
	[isActive] [int] NULL,
 CONSTRAINT [PK_wx_theme] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_theme] ADD  CONSTRAINT [DF_wx_theme_tvip]  DEFAULT ((1)) FOR [tvip]
GO

ALTER TABLE [dbo].[wx_theme] ADD  CONSTRAINT [DF_wx_theme_theme_id]  DEFAULT ((0)) FOR [cid]
GO

ALTER TABLE [dbo].[wx_theme] ADD  CONSTRAINT [DF_wx_theme_isActive]  DEFAULT ((0)) FOR [isActive]
GO


