

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_config_shop_Auth]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_config] DROP CONSTRAINT [DF_B2C_config_shop_Auth]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_config_shop_uptime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_config] DROP CONSTRAINT [DF_B2C_config_shop_uptime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_config_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_config] DROP CONSTRAINT [DF_B2C_config_regtime]
END

GO



/****** Object:  Table [dbo].[B2C_config]    Script Date: 11/17/2014 19:33:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_config]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_config]
GO



/****** Object:  Table [dbo].[B2C_config]    Script Date: 11/17/2014 19:33:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_config](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[shop_name] [nvarchar](255) NULL,
	[shop_lang] [nvarchar](255) NULL,
	[shop_addr] [nvarchar](255) NULL,
	[shop_zip] [varchar](10) NULL,
	[shop_tel] [varchar](255) NULL,
	[shop_fax] [varchar](255) NULL,
	[shop_mobile] [varchar](50) NULL,
	[shop_email] [varchar](255) NULL,
	[shop_url] [varchar](255) NULL,
	[shop_QQ] [varchar](255) NULL,
	[shop_ww] [varchar](255) NULL,
	[shop_msn] [varchar](255) NULL,
	[shop_WB] [varchar](255) NULL,
	[shop_IM] [varchar](255) NULL,
	[shop_beian] [varchar](50) NULL,
	[shop_title] [varchar](255) NULL,
	[shop_key] [nvarchar](300) NULL,
	[shop_des] [nvarchar](300) NULL,
	[shop_tj] [varchar](max) NULL,
	[shop_path] [varchar](255) NULL,
	[shop_gif] [varchar](255) NULL,
	[shop_msg] [nvarchar](max) NULL,
	[shop_ver] [varchar](50) NULL,
	[shop_Auth] [datetime] NOT NULL,
	[shop_uptime] [datetime] NOT NULL,
	[regtime] [datetime] NOT NULL,
 CONSTRAINT [PK_B2C_config] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_config] ADD  CONSTRAINT [DF_B2C_config_shop_Auth]  DEFAULT (getdate()) FOR [shop_Auth]
GO

ALTER TABLE [dbo].[B2C_config] ADD  CONSTRAINT [DF_B2C_config_shop_uptime]  DEFAULT (getdate()) FOR [shop_uptime]
GO

ALTER TABLE [dbo].[B2C_config] ADD  CONSTRAINT [DF_B2C_config_regtime]  DEFAULT (getdate()) FOR [regtime]
GO


