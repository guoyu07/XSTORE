

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tpage_shopID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tpage] DROP CONSTRAINT [DF_B2C_tpage_shopID]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tpage_g_isurl]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tpage] DROP CONSTRAINT [DF_B2C_tpage_g_isurl]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tpage_g_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tpage] DROP CONSTRAINT [DF_B2C_tpage_g_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tpage_g_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tpage] DROP CONSTRAINT [DF_B2C_tpage_g_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tpage_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tpage] DROP CONSTRAINT [DF_B2C_tpage_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tpage_g_isSys]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tpage] DROP CONSTRAINT [DF_B2C_tpage_g_isSys]
END

GO


/****** Object:  Table [dbo].[B2C_tpage]    Script Date: 11/17/2014 19:47:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_tpage]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_tpage]
GO



/****** Object:  Table [dbo].[B2C_tpage]    Script Date: 11/17/2014 19:47:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_tpage](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cno] [varchar](200) NULL,
	[shopID] [int] NOT NULL,
	[gtitle] [varchar](255) NULL,
	[gcontent] [ntext] NULL,
	[gfile] [varchar](255) NULL,
	[ggif] [varchar](255) NULL,
	[g_isurl] [int] NOT NULL,
	[g_url] [varchar](2000) NULL,
	[g_title] [varchar](255) NULL,
	[g_key] [varchar](255) NULL,
	[g_des] [varchar](255) NULL,
	[g_sort] [int] NOT NULL,
	[g_hits] [int] NOT NULL,
	[regtime] [datetime] NOT NULL,
	[g_r1] [varchar](2000) NULL,
	[g_r2] [varchar](2000) NULL,
	[g_isSys] [tinyint] NOT NULL,
 CONSTRAINT [PK_B2C_tpage] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_tpage] ADD  CONSTRAINT [DF_B2C_tpage_shopID]  DEFAULT ((0)) FOR [shopID]
GO

ALTER TABLE [dbo].[B2C_tpage] ADD  CONSTRAINT [DF_B2C_tpage_g_isurl]  DEFAULT ((0)) FOR [g_isurl]
GO

ALTER TABLE [dbo].[B2C_tpage] ADD  CONSTRAINT [DF_B2C_tpage_g_sort]  DEFAULT ((99)) FOR [g_sort]
GO

ALTER TABLE [dbo].[B2C_tpage] ADD  CONSTRAINT [DF_B2C_tpage_g_hits]  DEFAULT ((0)) FOR [g_hits]
GO

ALTER TABLE [dbo].[B2C_tpage] ADD  CONSTRAINT [DF_B2C_tpage_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[B2C_tpage] ADD  CONSTRAINT [DF_B2C_tpage_g_isSys]  DEFAULT ((0)) FOR [g_isSys]
GO


