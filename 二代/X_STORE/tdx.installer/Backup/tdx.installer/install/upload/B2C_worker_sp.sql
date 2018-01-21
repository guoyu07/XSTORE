

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_sp_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker_sp] DROP CONSTRAINT [DF_B2C_worker_sp_wid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_sp_gid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker_sp] DROP CONSTRAINT [DF_B2C_worker_sp_gid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_sp_uid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker_sp] DROP CONSTRAINT [DF_B2C_worker_sp_uid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_worker_sp_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_worker_sp] DROP CONSTRAINT [DF_B2C_worker_sp_regtime]
END

GO


/****** Object:  Table [dbo].[B2C_worker_sp]    Script Date: 11/17/2014 19:49:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_worker_sp]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_worker_sp]
GO



/****** Object:  Table [dbo].[B2C_worker_sp]    Script Date: 11/17/2014 19:49:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_worker_sp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wid] [int] NOT NULL,
	[cno] [nvarchar](50) NULL,
	[gids] [varchar](50) NULL,
	[gu_price] [nvarchar](50) NULL,
	[uid] [int] NOT NULL,
	[regtime] [datetime] NOT NULL,
 CONSTRAINT [PK_B2C_worker_sp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_worker_sp] ADD  CONSTRAINT [DF_B2C_worker_sp_wid]  DEFAULT ((0)) FOR [wid]
GO

ALTER TABLE [dbo].[B2C_worker_sp] ADD  CONSTRAINT [DF_B2C_worker_sp_gid]  DEFAULT ((0)) FOR [gids]
GO

ALTER TABLE [dbo].[B2C_worker_sp] ADD  CONSTRAINT [DF_B2C_worker_sp_uid]  DEFAULT ((0)) FOR [uid]
GO

ALTER TABLE [dbo].[B2C_worker_sp] ADD  CONSTRAINT [DF_B2C_worker_sp_regtime]  DEFAULT (getdate()) FOR [regtime]
GO


