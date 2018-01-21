

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_v_num]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher] DROP CONSTRAINT [DF_C2C_voucher_v_num]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_v_amount]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher] DROP CONSTRAINT [DF_C2C_voucher_v_amount]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_v_deduction]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher] DROP CONSTRAINT [DF_C2C_voucher_v_deduction]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher] DROP CONSTRAINT [DF_C2C_voucher_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_v_start_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher] DROP CONSTRAINT [DF_C2C_voucher_v_start_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_v_end_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher] DROP CONSTRAINT [DF_C2C_voucher_v_end_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_v_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher] DROP CONSTRAINT [DF_C2C_voucher_v_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_voucher_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_voucher] DROP CONSTRAINT [DF_C2C_voucher_wid]
END

GO



/****** Object:  Table [dbo].[C2C_voucher]    Script Date: 11/17/2014 19:51:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[C2C_voucher]') AND type in (N'U'))
DROP TABLE [dbo].[C2C_voucher]
GO



/****** Object:  Table [dbo].[C2C_voucher]    Script Date: 11/17/2014 19:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[C2C_voucher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[v_num] [int] NULL,
	[v_amount] [numeric](18, 0) NULL,
	[v_deduction] [numeric](18, 0) NULL,
	[regtime] [datetime] NULL,
	[v_start_time] [datetime] NULL,
	[v_end_time] [datetime] NULL,
	[v_isactive] [int] NULL,
	[wid] [int] NULL,
 CONSTRAINT [PK_C2C_VOUCHER] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发行数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher', @level2type=N'COLUMN',@level2name=N'v_num'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用金额条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher', @level2type=N'COLUMN',@level2name=N'v_amount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抵扣金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher', @level2type=N'COLUMN',@level2name=N'v_deduction'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher', @level2type=N'COLUMN',@level2name=N'regtime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效期开始' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher', @level2type=N'COLUMN',@level2name=N'v_start_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效期结束' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher', @level2type=N'COLUMN',@level2name=N'v_end_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher', @level2type=N'COLUMN',@level2name=N'v_isactive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属商家 worker ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher', @level2type=N'COLUMN',@level2name=N'wid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代金卷' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_voucher'
GO

ALTER TABLE [dbo].[C2C_voucher] ADD  CONSTRAINT [DF_C2C_voucher_v_num]  DEFAULT ((0)) FOR [v_num]
GO

ALTER TABLE [dbo].[C2C_voucher] ADD  CONSTRAINT [DF_C2C_voucher_v_amount]  DEFAULT ((0)) FOR [v_amount]
GO

ALTER TABLE [dbo].[C2C_voucher] ADD  CONSTRAINT [DF_C2C_voucher_v_deduction]  DEFAULT ((0)) FOR [v_deduction]
GO

ALTER TABLE [dbo].[C2C_voucher] ADD  CONSTRAINT [DF_C2C_voucher_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[C2C_voucher] ADD  CONSTRAINT [DF_C2C_voucher_v_start_time]  DEFAULT (getdate()) FOR [v_start_time]
GO

ALTER TABLE [dbo].[C2C_voucher] ADD  CONSTRAINT [DF_C2C_voucher_v_end_time]  DEFAULT (getdate()) FOR [v_end_time]
GO

ALTER TABLE [dbo].[C2C_voucher] ADD  CONSTRAINT [DF_C2C_voucher_v_isactive]  DEFAULT ((0)) FOR [v_isactive]
GO

ALTER TABLE [dbo].[C2C_voucher] ADD  CONSTRAINT [DF_C2C_voucher_wid]  DEFAULT ((0)) FOR [wid]
GO


