

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_log_acid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_log] DROP CONSTRAINT [DF_wx_acm_action_log_acid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_log_tid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_log] DROP CONSTRAINT [DF_wx_acm_action_log_tid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_log_YorN]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_log] DROP CONSTRAINT [DF_wx_acm_action_log_YorN]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_log_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_log] DROP CONSTRAINT [DF_wx_acm_action_log_regdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_log_acl_no]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_log] DROP CONSTRAINT [DF_wx_acm_action_log_acl_no]
END

GO



/****** Object:  Table [dbo].[wx_acm_action_log]    Script Date: 11/17/2014 20:01:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_acm_action_log]') AND type in (N'U'))
DROP TABLE [dbo].[wx_acm_action_log]
GO


/****** Object:  Table [dbo].[wx_acm_action_log]    Script Date: 11/17/2014 20:01:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_acm_action_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[acid] [int] NOT NULL,
	[tid] [int] NOT NULL,
	[wwv] [nvarchar](50) NULL,
	[answer] [nvarchar](50) NULL,
	[YorN] [tinyint] NOT NULL,
	[regdate] [datetime] NOT NULL,
	[acl_no] [tinyint] NOT NULL,
	[guid_no] [nvarchar](50) NULL,
	[ips] [nvarchar](50) NULL,
 CONSTRAINT [PK_wx_acm_action_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_acm_action_log] ADD  CONSTRAINT [DF_wx_acm_action_log_acid]  DEFAULT ((0)) FOR [acid]
GO

ALTER TABLE [dbo].[wx_acm_action_log] ADD  CONSTRAINT [DF_wx_acm_action_log_tid]  DEFAULT ((0)) FOR [tid]
GO

ALTER TABLE [dbo].[wx_acm_action_log] ADD  CONSTRAINT [DF_wx_acm_action_log_YorN]  DEFAULT ((0)) FOR [YorN]
GO

ALTER TABLE [dbo].[wx_acm_action_log] ADD  CONSTRAINT [DF_wx_acm_action_log_regdate]  DEFAULT (getdate()) FOR [regdate]
GO

ALTER TABLE [dbo].[wx_acm_action_log] ADD  CONSTRAINT [DF_wx_acm_action_log_acl_no]  DEFAULT ((0)) FOR [acl_no]
GO


