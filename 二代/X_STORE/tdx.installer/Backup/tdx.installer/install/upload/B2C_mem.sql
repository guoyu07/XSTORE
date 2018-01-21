

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_vip]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_vip]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_logontime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_logontime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_busi]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_busi]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_BirthDay]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_BirthDay]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_email_true]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_email_true]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_mem_M_mobile_true]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_mem] DROP CONSTRAINT [DF_B2C_mem_M_mobile_true]
END

GO


/****** Object:  Table [dbo].[B2C_mem]    Script Date: 11/17/2014 19:38:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_mem]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_mem]
GO



/****** Object:  Table [dbo].[B2C_mem]    Script Date: 11/17/2014 19:38:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_mem](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[M_vip] [int] NOT NULL,
	[M_card] [nvarchar](50) NULL,
	[M_name] [nvarchar](50) NULL,
	[M_psw] [nvarchar](50) NULL,
	[M_question] [nvarchar](200) NULL,
	[M_answer] [nvarchar](200) NULL,
	[M_logontime] [datetime] NOT NULL,
	[M_regtime] [datetime] NOT NULL,
	[M_hits] [int] NOT NULL,
	[M_truename] [nvarchar](50) NULL,
	[M_sex] [nvarchar](50) NULL,
	[M_isactive] [int] NOT NULL,
	[M_isdel] [int] NOT NULL,
	[M_busi] [int] NOT NULL,
	[surl] [varchar](255) NULL,
	[M_photo] [varchar](255) NULL,
	[M_tags] [varchar](255) NULL,
	[M_xueli] [varchar](50) NULL,
	[M_addr] [varchar](255) NULL,
	[M_tel] [varchar](50) NULL,
	[M_fax] [varchar](50) NULL,
	[M_zip] [varchar](50) NULL,
	[M_mobile] [varchar](50) NULL,
	[M_BirthDay] [datetime] NOT NULL,
	[M_email] [varchar](255) NULL,
	[M_url] [varchar](255) NULL,
	[M_QQ] [varchar](255) NULL,
	[M_email_true] [tinyint] NOT NULL,
	[M_mobile_true] [tinyint] NOT NULL,
	[M_Guider] [varchar](50) NULL,
	[M_IDCard] [nvarchar](50) NULL,
	[M_jobs] [nvarchar](50) NULL,
	[ip] [varchar](50) NULL,
	[M_DPID] [nvarchar](50) NULL,
	[M_CarNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_B2C_mem] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_vip]  DEFAULT ((0)) FOR [M_vip]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_logontime]  DEFAULT (getdate()) FOR [M_logontime]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_regtime]  DEFAULT (getdate()) FOR [M_regtime]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_hits]  DEFAULT ((0)) FOR [M_hits]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_isactive]  DEFAULT ((1)) FOR [M_isactive]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_isdel]  DEFAULT ((0)) FOR [M_isdel]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_busi]  DEFAULT ((0)) FOR [M_busi]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_BirthDay]  DEFAULT (getdate()) FOR [M_BirthDay]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_email_true]  DEFAULT ((0)) FOR [M_email_true]
GO

ALTER TABLE [dbo].[B2C_mem] ADD  CONSTRAINT [DF_B2C_mem_M_mobile_true]  DEFAULT ((0)) FOR [M_mobile_true]
GO


