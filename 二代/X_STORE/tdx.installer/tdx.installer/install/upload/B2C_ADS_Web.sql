

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_ADS_Web_a_btime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_ADS_Web] DROP CONSTRAINT [DF_B2C_ADS_Web_a_btime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_ADS_Web_a_etime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_ADS_Web] DROP CONSTRAINT [DF_B2C_ADS_Web_a_etime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_ADS_Web_a_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_ADS_Web] DROP CONSTRAINT [DF_B2C_ADS_Web_a_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_ADS_Web_a_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_ADS_Web] DROP CONSTRAINT [DF_B2C_ADS_Web_a_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_ADS_Web_a_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_ADS_Web] DROP CONSTRAINT [DF_B2C_ADS_Web_a_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_ADS_Web_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_ADS_Web] DROP CONSTRAINT [DF_B2C_ADS_Web_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_ADS_Web_a_isSys]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_ADS_Web] DROP CONSTRAINT [DF_B2C_ADS_Web_a_isSys]
END

GO


/****** Object:  Table [dbo].[B2C_ADS_Web]    Script Date: 11/19/2014 14:57:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_ADS_Web]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_ADS_Web]
GO



/****** Object:  Table [dbo].[B2C_ADS_Web]    Script Date: 11/19/2014 14:57:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_ADS_Web](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cno] [varchar](50) NULL,
	[a_name] [varchar](200) NULL,
	[a_gif] [varchar](300) NULL,
	[a_adGif] [varchar](300) NULL,
	[a_url] [varchar](2000) NOT NULL,
	[a_btime] [datetime] NOT NULL,
	[a_etime] [datetime] NOT NULL,
	[a_sort] [int] NOT NULL,
	[a_des] [varchar](300) NULL,
	[a_isactive] [int] NOT NULL,
	[a_isdel] [int] NOT NULL,
	[regtime] [datetime] NOT NULL,
	[a_isSys] [tinyint] NOT NULL,
 CONSTRAINT [PK_B2C_ADS_Web] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_ADS_Web] ADD  CONSTRAINT [DF_B2C_ADS_Web_a_btime]  DEFAULT (getdate()) FOR [a_btime]
GO

ALTER TABLE [dbo].[B2C_ADS_Web] ADD  CONSTRAINT [DF_B2C_ADS_Web_a_etime]  DEFAULT (getdate()) FOR [a_etime]
GO

ALTER TABLE [dbo].[B2C_ADS_Web] ADD  CONSTRAINT [DF_B2C_ADS_Web_a_sort]  DEFAULT ((99)) FOR [a_sort]
GO

ALTER TABLE [dbo].[B2C_ADS_Web] ADD  CONSTRAINT [DF_B2C_ADS_Web_a_isactive]  DEFAULT ((1)) FOR [a_isactive]
GO

ALTER TABLE [dbo].[B2C_ADS_Web] ADD  CONSTRAINT [DF_B2C_ADS_Web_a_isdel]  DEFAULT ((0)) FOR [a_isdel]
GO

ALTER TABLE [dbo].[B2C_ADS_Web] ADD  CONSTRAINT [DF_B2C_ADS_Web_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[B2C_ADS_Web] ADD  CONSTRAINT [DF_B2C_ADS_Web_a_isSys]  DEFAULT ((0)) FOR [a_isSys]
GO


