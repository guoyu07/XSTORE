

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_mid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_mid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_date]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_gid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_gid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_aid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_aid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_lastDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_lastDate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_amt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_amt]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_cent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_cent]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_stid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_stid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_st_amt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_st_amt]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_allamt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_allamt]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_orders_o_way]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_orders] DROP CONSTRAINT [DF_ms_orders_o_way]
END

GO



/****** Object:  Table [dbo].[ms_orders]    Script Date: 11/17/2014 19:58:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ms_orders]') AND type in (N'U'))
DROP TABLE [dbo].[ms_orders]
GO



/****** Object:  Table [dbo].[ms_orders]    Script Date: 11/17/2014 19:58:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ms_orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[mid] [int] NOT NULL,
	[o_date] [datetime] NOT NULL,
	[o_no] [varchar](50) NULL,
	[gid] [nvarchar](255) NOT NULL,
	[o_Des] [nvarchar](255) NULL,
	[o_isdel] [int] NOT NULL,
	[aid] [int] NOT NULL,
	[o_lastDate] [datetime] NOT NULL,
	[o_amt] [money] NOT NULL,
	[o_cent] [money] NOT NULL,
	[o_stid] [tinyint] NOT NULL,
	[o_st_amt] [money] NOT NULL,
	[o_allamt] [money] NOT NULL,
	[o_user] [nvarchar](50) NULL,
	[o_way] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ms_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_mid]  DEFAULT ((0)) FOR [mid]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_date]  DEFAULT (getdate()) FOR [o_date]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_gid]  DEFAULT ((0)) FOR [gid]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_isdel]  DEFAULT ((0)) FOR [o_isdel]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_aid]  DEFAULT ((0)) FOR [aid]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_lastDate]  DEFAULT (getdate()) FOR [o_lastDate]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_amt]  DEFAULT ((0)) FOR [o_amt]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_cent]  DEFAULT ((0)) FOR [o_cent]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_stid]  DEFAULT ((0)) FOR [o_stid]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_st_amt]  DEFAULT ((0)) FOR [o_st_amt]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_allamt]  DEFAULT ((0)) FOR [o_allamt]
GO

ALTER TABLE [dbo].[ms_orders] ADD  CONSTRAINT [DF_ms_orders_o_way]  DEFAULT (N'web') FOR [o_way]
GO


