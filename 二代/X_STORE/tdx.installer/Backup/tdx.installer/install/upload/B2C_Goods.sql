

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_isURL]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_isURL]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_price_B]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_price_B]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_price_S]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_price_S]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_price_M]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_price_M]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_cent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_cent]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_lowN]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_lowN]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_flag]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_flag]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_parent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_parent]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_wdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_wdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_buytype]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_buytype]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_xuni]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_xuni]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_g_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_g_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods] DROP CONSTRAINT [DF_B2C_Goods_regtime]
END

GO



/****** Object:  Table [dbo].[B2C_Goods]    Script Date: 11/17/2014 19:34:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_Goods]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_Goods]
GO



/****** Object:  Table [dbo].[B2C_Goods]    Script Date: 11/17/2014 19:34:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_Goods](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cno] [varchar](50) NULL,
	[bno] [varchar](50) NULL,
	[g_no] [varchar](50) NULL,
	[g_txm] [varchar](50) NULL,
	[g_name] [varchar](300) NULL,
	[g_unit] [varchar](10) NULL,
	[g_gif] [varchar](300) NULL,
	[g_gif2] [varchar](300) NULL,
	[g_isURL] [tinyint] NOT NULL,
	[g_url] [varchar](1000) NULL,
	[g_sort] [int] NOT NULL,
	[g_des] [varchar](2000) NULL,
	[g_price_B] [money] NOT NULL,
	[g_price_S] [money] NOT NULL,
	[g_price_M] [money] NOT NULL,
	[g_cent] [money] NOT NULL,
	[g_lowN] [money] NOT NULL,
	[g_flag] [int] NOT NULL,
	[g_filename] [varchar](200) NULL,
	[g_parent] [int] NOT NULL,
	[g_childs] [nvarchar](100) NULL,
	[g_title] [varchar](300) NULL,
	[g_key] [varchar](max) NULL,
	[g_description] [nvarchar](max) NULL,
	[g_isactive] [int] NOT NULL,
	[g_isdel] [int] NOT NULL,
	[g_sym] [varchar](200) NULL,
	[g_wdate] [datetime] NOT NULL,
	[g_buytype] [tinyint] NOT NULL,
	[g_xuni] [tinyint] NOT NULL,
	[g_hits] [int] NOT NULL,
	[regtime] [datetime] NOT NULL,
 CONSTRAINT [PK_B2C_Goods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_isURL]  DEFAULT ((0)) FOR [g_isURL]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_sort]  DEFAULT ((99)) FOR [g_sort]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_price_B]  DEFAULT ((0)) FOR [g_price_B]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_price_S]  DEFAULT ((0)) FOR [g_price_S]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_price_M]  DEFAULT ((0)) FOR [g_price_M]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_cent]  DEFAULT ((0)) FOR [g_cent]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_lowN]  DEFAULT ((0)) FOR [g_lowN]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_flag]  DEFAULT ((0)) FOR [g_flag]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_parent]  DEFAULT ((0)) FOR [g_parent]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_isactive]  DEFAULT ((1)) FOR [g_isactive]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_isdel]  DEFAULT ((0)) FOR [g_isdel]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_wdate]  DEFAULT (getdate()) FOR [g_wdate]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_buytype]  DEFAULT ((0)) FOR [g_buytype]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_xuni]  DEFAULT ((0)) FOR [g_xuni]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_g_hits]  DEFAULT ((0)) FOR [g_hits]
GO

ALTER TABLE [dbo].[B2C_Goods] ADD  CONSTRAINT [DF_B2C_Goods_regtime]  DEFAULT (getdate()) FOR [regtime]
GO


