

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_mp_wx_FirstIsGif]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_mp] DROP CONSTRAINT [DF_wx_mp_wx_FirstIsGif]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_mp_wx_cid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_mp] DROP CONSTRAINT [DF_wx_mp_wx_cid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_mp_wx_isActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_mp] DROP CONSTRAINT [DF_wx_mp_wx_isActive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_mp_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_mp] DROP CONSTRAINT [DF_wx_mp_regtime]
END

GO



/****** Object:  Table [dbo].[wx_mp]    Script Date: 11/22/2014 09:53:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_mp]') AND type in (N'U'))
DROP TABLE [dbo].[wx_mp]
GO



/****** Object:  Table [dbo].[wx_mp]    Script Date: 11/22/2014 09:53:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_mp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wx_name] [nvarchar](50) NULL,
	[wx_nichen] [nvarchar](50) NULL,
	[wx_2wm] [nvarchar](50) NULL,
	[wx_ID] [nvarchar](50) NULL,
	[wx_DID] [nvarchar](50) NULL,
	[wx_Dpsw] [nvarchar](50) NULL,
	[wx_FirstIsGif] [tinyint] NOT NULL,
	[wx_des] [nvarchar](500) NULL,
	[wx_cid] [tinyint] NOT NULL,
	[wx_isActive] [tinyint] NOT NULL,
	[regtime] [datetime] NOT NULL,
 CONSTRAINT [PK_wx_mp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_mp] ADD  CONSTRAINT [DF_wx_mp_wx_FirstIsGif]  DEFAULT ((1)) FOR [wx_FirstIsGif]
GO

ALTER TABLE [dbo].[wx_mp] ADD  CONSTRAINT [DF_wx_mp_wx_cid]  DEFAULT ((1)) FOR [wx_cid]
GO

ALTER TABLE [dbo].[wx_mp] ADD  CONSTRAINT [DF_wx_mp_wx_isActive]  DEFAULT ((0)) FOR [wx_isActive]
GO

ALTER TABLE [dbo].[wx_mp] ADD  CONSTRAINT [DF_wx_mp_regtime]  DEFAULT (getdate()) FOR [regtime]
GO


