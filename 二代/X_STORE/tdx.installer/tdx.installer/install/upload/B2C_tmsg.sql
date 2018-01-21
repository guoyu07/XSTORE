

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_shopID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_shopID]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_isurl]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_isurl]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_iflag]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_iflag]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_cflag]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_cflag]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_wdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_wdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_regdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_isHead]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_isHead]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_ischead]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_ischead]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_tmsg_t_isF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_tmsg] DROP CONSTRAINT [DF_B2C_tmsg_t_isF]
END

GO



/****** Object:  Table [dbo].[B2C_tmsg]    Script Date: 11/17/2014 19:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_tmsg]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_tmsg]
GO



/****** Object:  Table [dbo].[B2C_tmsg]    Script Date: 11/17/2014 19:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_tmsg](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cno] [varchar](200) NULL,
	[shopID] [int] NOT NULL,
	[t_title] [varchar](255) NULL,
	[t_author] [varchar](50) NULL,
	[t_source] [varchar](255) NULL,
	[t_gif] [varchar](255) NULL,
	[t_msg] [ntext] NULL,
	[t_isurl] [int] NOT NULL,
	[t_url] [varchar](255) NULL,
	[t_filename] [varchar](255) NULL,
	[t_sort] [int] NOT NULL,
	[t_iflag] [int] NOT NULL,
	[t_cflag] [int] NOT NULL,
	[t_hits] [int] NOT NULL,
	[t_wdate] [datetime] NOT NULL,
	[regdate] [datetime] NOT NULL,
	[t_isactive] [int] NOT NULL,
	[t_isdel] [int] NOT NULL,
	[t_isHead] [int] NOT NULL,
	[t_ischead] [int] NOT NULL,
	[t_key] [varchar](255) NULL,
	[t_des] [varchar](255) NULL,
	[t_isF] [tinyint] NOT NULL,
	[app_id] [varchar](255) NULL,
	[file_id] [varchar](255) NULL,
 CONSTRAINT [PK_B2C_tmsg] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_shopID]  DEFAULT ((0)) FOR [shopID]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_isurl]  DEFAULT ((0)) FOR [t_isurl]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_sort]  DEFAULT ((99)) FOR [t_sort]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_iflag]  DEFAULT ((0)) FOR [t_iflag]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_cflag]  DEFAULT ((0)) FOR [t_cflag]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_hits]  DEFAULT ((0)) FOR [t_hits]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_wdate]  DEFAULT (getdate()) FOR [t_wdate]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_regdate]  DEFAULT (getdate()) FOR [regdate]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_isactive]  DEFAULT ((1)) FOR [t_isactive]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_isdel]  DEFAULT ((0)) FOR [t_isdel]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_isHead]  DEFAULT ((0)) FOR [t_isHead]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_ischead]  DEFAULT ((0)) FOR [t_ischead]
GO

ALTER TABLE [dbo].[B2C_tmsg] ADD  CONSTRAINT [DF_B2C_tmsg_t_isF]  DEFAULT ((0)) FOR [t_isF]
GO


