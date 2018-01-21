

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_user_key_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_user] DROP CONSTRAINT [DF_control_user_key_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_user_value_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_user] DROP CONSTRAINT [DF_control_user_value_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_user_mid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_user] DROP CONSTRAINT [DF_control_user_mid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_user_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_user] DROP CONSTRAINT [DF_control_user_regtime]
END

GO



/****** Object:  Table [dbo].[control_user]    Script Date: 11/17/2014 19:53:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[control_user]') AND type in (N'U'))
DROP TABLE [dbo].[control_user]
GO



/****** Object:  Table [dbo].[control_user]    Script Date: 11/17/2014 19:53:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[control_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key_id] [int] NOT NULL,
	[value_id] [int] NOT NULL,
	[value_txt] [varchar](255) NULL,
	[mid] [int] NOT NULL,
	[ip] [varchar](255) NULL,
	[regtime] [datetime] NOT NULL,
	[ono] [varchar](225) NULL,
	[wwv] [varchar](50) NULL,
 CONSTRAINT [PK_control_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_user', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_user', @level2type=N'COLUMN',@level2name=N'key_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_user', @level2type=N'COLUMN',@level2name=N'mid'
GO

ALTER TABLE [dbo].[control_user] ADD  CONSTRAINT [DF_control_user_key_id]  DEFAULT ((0)) FOR [key_id]
GO

ALTER TABLE [dbo].[control_user] ADD  CONSTRAINT [DF_control_user_value_id]  DEFAULT ((0)) FOR [value_id]
GO

ALTER TABLE [dbo].[control_user] ADD  CONSTRAINT [DF_control_user_mid]  DEFAULT ((0)) FOR [mid]
GO

ALTER TABLE [dbo].[control_user] ADD  CONSTRAINT [DF_control_user_regtime]  DEFAULT (getdate()) FOR [regtime]
GO


