

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_gain_acid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_gain] DROP CONSTRAINT [DF_wx_acm_gain_acid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_gain_gid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_gain] DROP CONSTRAINT [DF_wx_acm_gain_gid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_gain_ga_wdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_gain] DROP CONSTRAINT [DF_wx_acm_gain_ga_wdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_gain_ga_gdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_gain] DROP CONSTRAINT [DF_wx_acm_gain_ga_gdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_gain_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_gain] DROP CONSTRAINT [DF_wx_acm_gain_regdate]
END

GO



/****** Object:  Table [dbo].[wx_acm_gain]    Script Date: 11/17/2014 20:01:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_acm_gain]') AND type in (N'U'))
DROP TABLE [dbo].[wx_acm_gain]
GO



/****** Object:  Table [dbo].[wx_acm_gain]    Script Date: 11/17/2014 20:01:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_acm_gain](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[acid] [int] NOT NULL,
	[gid] [int] NOT NULL,
	[wwv] [nvarchar](50) NOT NULL,
	[ga_wdate] [datetime] NOT NULL,
	[ga_idc] [nvarchar](50) NULL,
	[ga_tel] [nvarchar](50) NULL,
	[ga_uname] [nvarchar](50) NULL,
	[ga_addr] [nvarchar](100) NULL,
	[ga_zip] [nvarchar](10) NULL,
	[ga_email] [nvarchar](200) NULL,
	[ga_wwv] [nvarchar](50) NULL,
	[ga_gdate] [datetime] NOT NULL,
	[wuser] [nvarchar](50) NULL,
	[SN] [nvarchar](50) NULL,
	[regdate] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_acm_gain] ADD  CONSTRAINT [DF_wx_acm_gain_acid]  DEFAULT ((0)) FOR [acid]
GO

ALTER TABLE [dbo].[wx_acm_gain] ADD  CONSTRAINT [DF_wx_acm_gain_gid]  DEFAULT ((0)) FOR [gid]
GO

ALTER TABLE [dbo].[wx_acm_gain] ADD  CONSTRAINT [DF_wx_acm_gain_ga_wdate]  DEFAULT (getdate()) FOR [ga_wdate]
GO

ALTER TABLE [dbo].[wx_acm_gain] ADD  CONSTRAINT [DF_wx_acm_gain_ga_gdate]  DEFAULT (getdate()) FOR [ga_gdate]
GO

ALTER TABLE [dbo].[wx_acm_gain] ADD  CONSTRAINT [DF_wx_acm_gain_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


