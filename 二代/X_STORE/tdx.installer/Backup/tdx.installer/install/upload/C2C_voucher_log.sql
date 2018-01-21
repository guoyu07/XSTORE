

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_log_v_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher_log] DROP CONSTRAINT [DF_C2C_voucher_log_v_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_log_mid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher_log] DROP CONSTRAINT [DF_C2C_voucher_log_mid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_log_isuse]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher_log] DROP CONSTRAINT [DF_C2C_voucher_log_isuse]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_log_vl_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher_log] DROP CONSTRAINT [DF_C2C_voucher_log_vl_date]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_log_vl_update]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher_log] DROP CONSTRAINT [DF_C2C_voucher_log_vl_update]
END

GO



/****** Object:  Table [dbo].[C2C_voucher_log]    Script Date: 11/17/2014 19:51:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[C2C_voucher_log]') AND type in (N'U'))
DROP TABLE [dbo].[C2C_voucher_log]
GO


/****** Object:  Table [dbo].[C2C_voucher_log]    Script Date: 11/17/2014 19:51:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[C2C_voucher_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[v_id] [int] NULL,
	[mid] [int] NULL,
	[isuse] [int] NULL,
	[vl_date] [datetime] NULL,
	[vl_update] [datetime] NULL,
 CONSTRAINT [PK_C2C_VOUCHER_LOG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联代金卷ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher_log', @level2type=N'COLUMN',@level2name=N'v_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联会员ID B2C_MEM' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher_log', @level2type=N'COLUMN',@level2name=N'mid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否使用 默认0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher_log', @level2type=N'COLUMN',@level2name=N'isuse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'领用时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher_log', @level2type=N'COLUMN',@level2name=N'vl_date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用时间 使用时更新时间 此时isuse=1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher_log', @level2type=N'COLUMN',@level2name=N'vl_update'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代金卷日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher_log'
GO

ALTER TABLE [dbo].[C2C_voucher_log] ADD  CONSTRAINT [DF_C2C_voucher_log_v_id]  DEFAULT ((0)) FOR [v_id]
GO

ALTER TABLE [dbo].[C2C_voucher_log] ADD  CONSTRAINT [DF_C2C_voucher_log_mid]  DEFAULT ((0)) FOR [mid]
GO

ALTER TABLE [dbo].[C2C_voucher_log] ADD  CONSTRAINT [DF_C2C_voucher_log_isuse]  DEFAULT ((0)) FOR [isuse]
GO

ALTER TABLE [dbo].[C2C_voucher_log] ADD  CONSTRAINT [DF_C2C_voucher_log_vl_date]  DEFAULT (getdate()) FOR [vl_date]
GO

ALTER TABLE [dbo].[C2C_voucher_log] ADD  CONSTRAINT [DF_C2C_voucher_log_vl_update]  DEFAULT (getdate()) FOR [vl_update]
GO


