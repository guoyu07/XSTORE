
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AccountConfig_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AccountConfig] DROP CONSTRAINT [DF_B2C_AccountConfig_wid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AccountConfig_category]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AccountConfig] DROP CONSTRAINT [DF_B2C_AccountConfig_category]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AccountConfig_opened]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AccountConfig] DROP CONSTRAINT [DF_B2C_AccountConfig_opened]
END

GO



/****** Object:  Table [dbo].[B2C_AccountConfig]    Script Date: 11/17/2014 19:30:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_AccountConfig]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_AccountConfig]
GO



/****** Object:  Table [dbo].[B2C_AccountConfig]    Script Date: 11/17/2014 19:30:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[B2C_AccountConfig](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wid] [int] NOT NULL,
	[category] [int] NULL,
	[opened] [int] NULL,
 CONSTRAINT [PK_B2C_AccountConfig] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公众号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_AccountConfig', @level2type=N'COLUMN',@level2name=N'wid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应类型1代表积分2代表钱包' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_AccountConfig', @level2type=N'COLUMN',@level2name=N'category'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认0不开启' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_AccountConfig', @level2type=N'COLUMN',@level2name=N'opened'
GO

ALTER TABLE [dbo].[B2C_AccountConfig] ADD  CONSTRAINT [DF_B2C_AccountConfig_wid]  DEFAULT ((0)) FOR [wid]
GO

ALTER TABLE [dbo].[B2C_AccountConfig] ADD  CONSTRAINT [DF_B2C_AccountConfig_category]  DEFAULT ((1)) FOR [category]
GO

ALTER TABLE [dbo].[B2C_AccountConfig] ADD  CONSTRAINT [DF_B2C_AccountConfig_opened]  DEFAULT ((0)) FOR [opened]
GO


