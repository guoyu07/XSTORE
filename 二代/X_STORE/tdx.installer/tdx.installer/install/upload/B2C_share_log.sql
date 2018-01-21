

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_share_log_s_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_share_log] DROP CONSTRAINT [DF_B2C_share_log_s_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_share_log_s_cent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_share_log] DROP CONSTRAINT [DF_B2C_share_log_s_cent]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_share_log_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_share_log] DROP CONSTRAINT [DF_B2C_share_log_regdate]
END

GO



/****** Object:  Table [dbo].[B2C_share_log]    Script Date: 11/17/2014 19:45:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_share_log]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_share_log]
GO



/****** Object:  Table [dbo].[B2C_share_log]    Script Date: 11/17/2014 19:45:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_share_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wwv] [varchar](255) NOT NULL,
	[ip] [varchar](255) NOT NULL,
	[s_id] [int] NOT NULL,
	[s_cent] [int] NOT NULL,
	[regdate] [datetime] NULL,
 CONSTRAINT [PK_B2C_SHARE_LOG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分享后获得积分的关联会员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share_log', @level2type=N'COLUMN',@level2name=N'wwv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share_log', @level2type=N'COLUMN',@level2name=N'ip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联b2c_share ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share_log', @level2type=N'COLUMN',@level2name=N's_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'赠送的积分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share_log', @level2type=N'COLUMN',@level2name=N's_cent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share_log', @level2type=N'COLUMN',@level2name=N'regdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分享记录日志表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share_log'
GO

ALTER TABLE [dbo].[B2C_share_log] ADD  CONSTRAINT [DF_B2C_share_log_s_id]  DEFAULT ((0)) FOR [s_id]
GO

ALTER TABLE [dbo].[B2C_share_log] ADD  CONSTRAINT [DF_B2C_share_log_s_cent]  DEFAULT ((0)) FOR [s_cent]
GO

ALTER TABLE [dbo].[B2C_share_log] ADD  CONSTRAINT [DF_B2C_share_log_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


