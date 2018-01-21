

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_b2c_inq_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[b2c_inq] DROP CONSTRAINT [DF_b2c_inq_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_b2c_inq_i_isV]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[b2c_inq] DROP CONSTRAINT [DF_b2c_inq_i_isV]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_b2c_inq_i_Vtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[b2c_inq] DROP CONSTRAINT [DF_b2c_inq_i_Vtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_b2c_inq_i_isR]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[b2c_inq] DROP CONSTRAINT [DF_b2c_inq_i_isR]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_b2c_inq_i_Rtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[b2c_inq] DROP CONSTRAINT [DF_b2c_inq_i_Rtime]
END

GO


/****** Object:  Table [dbo].[b2c_inq]    Script Date: 11/19/2014 16:18:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[b2c_inq]') AND type in (N'U'))
DROP TABLE [dbo].[b2c_inq]
GO


/****** Object:  Table [dbo].[b2c_inq]    Script Date: 11/19/2014 16:18:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[b2c_inq](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regtime] [datetime] NULL,
	[Ips] [nvarchar](50) NULL,
	[i_url] [nvarchar](255) NULL,
	[i_system] [nvarchar](50) NULL,
	[i_ie] [nvarchar](50) NULL,
	[i_lang] [nvarchar](50) NULL,
	[cname] [nvarchar](50) NULL,
	[i_title] [nvarchar](255) NULL,
	[i_content] [nvarchar](max) NULL,
	[i_email] [nvarchar](255) NULL,
	[i_name] [nvarchar](50) NULL,
	[i_tel] [nvarchar](50) NULL,
	[i_isV] [int] NULL,
	[i_Vtime] [datetime] NULL,
	[i_isR] [int] NULL,
	[i_Rtime] [datetime] NULL,
 CONSTRAINT [PK_b2c_inq] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[b2c_inq] ADD  CONSTRAINT [DF_b2c_inq_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[b2c_inq] ADD  CONSTRAINT [DF_b2c_inq_i_isV]  DEFAULT ((0)) FOR [i_isV]
GO

ALTER TABLE [dbo].[b2c_inq] ADD  CONSTRAINT [DF_b2c_inq_i_Vtime]  DEFAULT (getdate()) FOR [i_Vtime]
GO

ALTER TABLE [dbo].[b2c_inq] ADD  CONSTRAINT [DF_b2c_inq_i_isR]  DEFAULT ((0)) FOR [i_isR]
GO

ALTER TABLE [dbo].[b2c_inq] ADD  CONSTRAINT [DF_b2c_inq_i_Rtime]  DEFAULT (getdate()) FOR [i_Rtime]
GO


