

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_config_wx_theme]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_config] DROP CONSTRAINT [DF_wx_config_wx_theme]
END

GO


/****** Object:  Table [dbo].[wx_config]    Script Date: 11/22/2014 13:29:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_config]') AND type in (N'U'))
DROP TABLE [dbo].[wx_config]
GO



/****** Object:  Table [dbo].[wx_config]    Script Date: 11/22/2014 13:29:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[wx_config](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[M_company] [nvarchar](50) NULL,
	[M_tel] [varchar](50) NULL,
	[M_mobile] [varchar](50) NULL,
	[M_email] [varchar](255) NULL,
	[M_QQ] [varchar](255) NULL,
	[M_map] [nvarchar](1000) NULL,
	[wx_name] [nvarchar](50) NULL,
	[wx_nichen] [nvarchar](50) NULL,
	[wx_theme] [tinyint] NOT NULL,
	[wx_GNTheme] [nvarchar](50) NULL,
 CONSTRAINT [PK_wx_config] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[wx_config] ADD  CONSTRAINT [DF_wx_config_wx_theme]  DEFAULT ((1)) FOR [wx_theme]
GO


