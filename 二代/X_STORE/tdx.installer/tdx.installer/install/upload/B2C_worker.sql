

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_vip]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_vip]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_logontime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_logontime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_wx_theme]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_wx_theme]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_wx_theme2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_wx_theme2]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_wx_theme3]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_wx_theme3]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_wx_theme4]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_wx_theme4]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_wx_FirstIsGif]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_wx_FirstIsGif]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_lx]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_lx]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_limit]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_limit]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_bdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_bdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_edate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_edate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_M_udate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker] DROP CONSTRAINT [DF_B2C_worker_M_udate]
END

GO



/****** Object:  Table [dbo].[B2C_worker]    Script Date: 11/17/2014 19:49:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_worker]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_worker]
GO



/****** Object:  Table [dbo].[B2C_worker]    Script Date: 11/17/2014 19:49:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_worker](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[M_vip] [int] NOT NULL,
	[M_name] [nvarchar](50) NULL,
	[M_psw] [nvarchar](50) NULL,
	[M_question] [nvarchar](200) NULL,
	[M_answer] [nvarchar](200) NULL,
	[M_logontime] [datetime] NOT NULL,
	[regtime] [datetime] NOT NULL,
	[M_hits] [int] NOT NULL,
	[M_company] [nvarchar](50) NULL,
	[M_tel] [varchar](50) NULL,
	[M_mobile] [varchar](50) NULL,
	[M_email] [varchar](255) NULL,
	[M_url] [varchar](255) NULL,
	[M_QQ] [varchar](255) NULL,
	[M_map] [nvarchar](1000) NULL,
	[wx_name] [nvarchar](50) NULL,
	[wx_nichen] [nvarchar](50) NULL,
	[wx_2wm] [nvarchar](50) NULL,
	[wx_ID] [nvarchar](50) NULL,
	[wx_theme] [tinyint] NOT NULL,
	[wx_theme2] [tinyint] NOT NULL,
	[wx_theme3] [tinyint] NOT NULL,
	[wx_theme4] [tinyint] NOT NULL,
	[wx_GNTheme] [nvarchar](50) NULL,
	[wx_DID] [nvarchar](50) NULL,
	[wx_Dpsw] [nvarchar](50) NULL,
	[wx_FirstIsGif] [tinyint] NOT NULL,
	[M_lx] [tinyint] NOT NULL,
	[M_isactive] [int] NOT NULL,
	[M_isdel] [int] NOT NULL,
	[M_limit] [tinyint] NOT NULL,
	[M_bdate] [datetime] NOT NULL,
	[M_edate] [datetime] NOT NULL,
	[M_udate] [datetime] NOT NULL,
	[area_no] [nvarchar](50) NULL,
	[hy_no] [nvarchar](50) NULL,
 CONSTRAINT [PK_B2C_worker] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型默认2为商城1为其它' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_worker', @level2type=N'COLUMN',@level2name=N'M_lx'
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_vip]  DEFAULT ((0)) FOR [M_vip]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_logontime]  DEFAULT (getdate()) FOR [M_logontime]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_hits]  DEFAULT ((0)) FOR [M_hits]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_wx_theme]  DEFAULT ((1)) FOR [wx_theme]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_wx_theme2]  DEFAULT ((1)) FOR [wx_theme2]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_wx_theme3]  DEFAULT ((1)) FOR [wx_theme3]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_wx_theme4]  DEFAULT ((0)) FOR [wx_theme4]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_wx_FirstIsGif]  DEFAULT ((1)) FOR [wx_FirstIsGif]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_lx]  DEFAULT ((2)) FOR [M_lx]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_isactive]  DEFAULT ((1)) FOR [M_isactive]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_isdel]  DEFAULT ((0)) FOR [M_isdel]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_limit]  DEFAULT ((3)) FOR [M_limit]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_bdate]  DEFAULT (getdate()) FOR [M_bdate]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_edate]  DEFAULT (getdate()) FOR [M_edate]
GO

ALTER TABLE [dbo].[B2C_worker] ADD  CONSTRAINT [DF_B2C_worker_M_udate]  DEFAULT (getdate()) FOR [M_udate]
GO


