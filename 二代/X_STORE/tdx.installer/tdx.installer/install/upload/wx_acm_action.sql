

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_lid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action] DROP CONSTRAINT [DF_wx_acm_action_lid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_hid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action] DROP CONSTRAINT [DF_wx_acm_action_hid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_whid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action] DROP CONSTRAINT [DF_wx_acm_action_whid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_bdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action] DROP CONSTRAINT [DF_wx_acm_action_bdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_edate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action] DROP CONSTRAINT [DF_wx_acm_action_edate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_freq]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action] DROP CONSTRAINT [DF_wx_acm_action_freq]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action] DROP CONSTRAINT [DF_wx_acm_action_regtime]
END

GO



/****** Object:  Table [dbo].[wx_acm_action]    Script Date: 11/22/2014 09:55:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_acm_action]') AND type in (N'U'))
DROP TABLE [dbo].[wx_acm_action]
GO



/****** Object:  Table [dbo].[wx_acm_action]    Script Date: 11/22/2014 09:55:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_acm_action](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ac_name] [nvarchar](200) NULL,
	[lid] [nvarchar](50) NOT NULL,
	[hid] [int] NOT NULL,
	[whid] [int] NOT NULL,
	[bdate] [datetime] NOT NULL,
	[edate] [datetime] NOT NULL,
	[freq] [int] NOT NULL,
	[regtime] [datetime] NOT NULL,
 CONSTRAINT [PK_wx_acm_action] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_acm_action] ADD  CONSTRAINT [DF_wx_acm_action_lid]  DEFAULT ((0)) FOR [lid]
GO

ALTER TABLE [dbo].[wx_acm_action] ADD  CONSTRAINT [DF_wx_acm_action_hid]  DEFAULT ((0)) FOR [hid]
GO

ALTER TABLE [dbo].[wx_acm_action] ADD  CONSTRAINT [DF_wx_acm_action_whid]  DEFAULT ((0)) FOR [whid]
GO

ALTER TABLE [dbo].[wx_acm_action] ADD  CONSTRAINT [DF_wx_acm_action_bdate]  DEFAULT (getdate()) FOR [bdate]
GO

ALTER TABLE [dbo].[wx_acm_action] ADD  CONSTRAINT [DF_wx_acm_action_edate]  DEFAULT (getdate()) FOR [edate]
GO

ALTER TABLE [dbo].[wx_acm_action] ADD  CONSTRAINT [DF_wx_acm_action_freq]  DEFAULT ((1)) FOR [freq]
GO

ALTER TABLE [dbo].[wx_acm_action] ADD  CONSTRAINT [DF_wx_acm_action_regtime]  DEFAULT (getdate()) FOR [regtime]
GO


