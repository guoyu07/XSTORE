

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_d_gid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_d] DROP CONSTRAINT [DF_ms_order_d_gid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_d_od_price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_d] DROP CONSTRAINT [DF_ms_order_d_od_price]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_d_od_cent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_d] DROP CONSTRAINT [DF_ms_order_d_od_cent]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_d_od_num]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_d] DROP CONSTRAINT [DF_ms_order_d_od_num]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_d_od_amt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_d] DROP CONSTRAINT [DF_ms_order_d_od_amt]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_d_od_allcent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_d] DROP CONSTRAINT [DF_ms_order_d_od_allcent]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_d_od_isD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_d] DROP CONSTRAINT [DF_ms_order_d_od_isD]
END

GO


/****** Object:  Table [dbo].[ms_order_d]    Script Date: 11/17/2014 19:57:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ms_order_d]') AND type in (N'U'))
DROP TABLE [dbo].[ms_order_d]
GO



/****** Object:  Table [dbo].[ms_order_d]    Script Date: 11/17/2014 19:57:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ms_order_d](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ono] [varchar](255) NULL,
	[gid] [int] NOT NULL,
	[od_price] [money] NOT NULL,
	[od_cent] [money] NOT NULL,
	[od_num] [money] NOT NULL,
	[od_amt] [money] NOT NULL,
	[od_allcent] [money] NOT NULL,
	[od_des] [varchar](255) NULL,
	[od_isD] [tinyint] NOT NULL,
 CONSTRAINT [PK_ms_order_d] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ms_order_d] ADD  CONSTRAINT [DF_ms_order_d_gid]  DEFAULT ((0)) FOR [gid]
GO

ALTER TABLE [dbo].[ms_order_d] ADD  CONSTRAINT [DF_ms_order_d_od_price]  DEFAULT ((0)) FOR [od_price]
GO

ALTER TABLE [dbo].[ms_order_d] ADD  CONSTRAINT [DF_ms_order_d_od_cent]  DEFAULT ((0)) FOR [od_cent]
GO

ALTER TABLE [dbo].[ms_order_d] ADD  CONSTRAINT [DF_ms_order_d_od_num]  DEFAULT ((0)) FOR [od_num]
GO

ALTER TABLE [dbo].[ms_order_d] ADD  CONSTRAINT [DF_ms_order_d_od_amt]  DEFAULT ((0)) FOR [od_amt]
GO

ALTER TABLE [dbo].[ms_order_d] ADD  CONSTRAINT [DF_ms_order_d_od_allcent]  DEFAULT ((0)) FOR [od_allcent]
GO

ALTER TABLE [dbo].[ms_order_d] ADD  CONSTRAINT [DF_ms_order_d_od_isD]  DEFAULT ((0)) FOR [od_isD]
GO


