

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_keys_fid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_keys] DROP CONSTRAINT [DF_wx_keys_fid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_keys_k_level]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_keys] DROP CONSTRAINT [DF_wx_keys_k_level]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_keys_k_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_keys] DROP CONSTRAINT [DF_wx_keys_k_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_keys_k_isSys]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_keys] DROP CONSTRAINT [DF_wx_keys_k_isSys]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_keys_cityID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_keys] DROP CONSTRAINT [DF_wx_keys_cityID]
END

GO



/****** Object:  Table [dbo].[wx_keys]    Script Date: 11/17/2014 20:04:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_keys]') AND type in (N'U'))
DROP TABLE [dbo].[wx_keys]
GO


/****** Object:  Table [dbo].[wx_keys]    Script Date: 11/17/2014 20:04:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[wx_keys](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[k_words] [nvarchar](500) NULL,
	[k_answer] [ntext] NULL,
	[fid] [tinyint] NOT NULL,
	[k_url] [nvarchar](500) NULL,
	[k_level] [tinyint] NOT NULL,
	[k_isdel] [tinyint] NOT NULL,
	[k_isSys] [tinyint] NOT NULL,
	[k_image] [varchar](500) NULL,
	[k_content] [ntext] NULL,
	[k_sort] [int] NULL,
	[k_url2] [nvarchar](500) NULL,
	[k_des] [ntext] NULL,
	[guid] [varchar](255) NULL,
	[cityID] [int] NULL,
 CONSTRAINT [PK_wx_keys] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[wx_keys] ADD  CONSTRAINT [DF_wx_keys_fid]  DEFAULT ((0)) FOR [fid]
GO

ALTER TABLE [dbo].[wx_keys] ADD  CONSTRAINT [DF_wx_keys_k_level]  DEFAULT ((0)) FOR [k_level]
GO

ALTER TABLE [dbo].[wx_keys] ADD  CONSTRAINT [DF_wx_keys_k_isdel]  DEFAULT ((0)) FOR [k_isdel]
GO

ALTER TABLE [dbo].[wx_keys] ADD  CONSTRAINT [DF_wx_keys_k_isSys]  DEFAULT ((0)) FOR [k_isSys]
GO

ALTER TABLE [dbo].[wx_keys] ADD  CONSTRAINT [DF_wx_keys_cityID]  DEFAULT ((0)) FOR [cityID]
GO


