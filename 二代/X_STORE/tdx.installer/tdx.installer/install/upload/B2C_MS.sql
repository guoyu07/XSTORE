

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_wID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_wID]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_tiaojian]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_tiaojian]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_price_m]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_price_m]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_price_t]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_price_t]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_AMT_xn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_AMT_xn]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_AMT_max]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_AMT_max]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_AMT_per]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_AMT_per]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_AMT_have]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_AMT_have]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_Bdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_Bdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_Edate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_Edate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_Qdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_Qdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_isHead]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_isHead]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_isCHead]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_isCHead]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_ms_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_ms_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_MS_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_MS] DROP CONSTRAINT [DF_B2C_MS_regdate]
END

GO



/****** Object:  Table [dbo].[B2C_MS]    Script Date: 11/17/2014 19:39:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_MS]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_MS]
GO



/****** Object:  Table [dbo].[B2C_MS]    Script Date: 11/17/2014 19:39:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_MS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wID] [int] NOT NULL,
	[ms_title] [varchar](255) NULL,
	[ms_tiaojian] [int] NOT NULL,
	[ms_price_m] [money] NOT NULL,
	[ms_price_t] [money] NOT NULL,
	[ms_AMT_xn] [int] NOT NULL,
	[ms_AMT_max] [int] NOT NULL,
	[ms_AMT_per] [money] NOT NULL,
	[ms_AMT_have] [money] NOT NULL,
	[ms_Bdate] [datetime] NOT NULL,
	[ms_Edate] [datetime] NOT NULL,
	[ms_Qdate] [datetime] NOT NULL,
	[ms_des] [varchar](255) NULL,
	[ms_tip] [varchar](255) NULL,
	[ms_Gname] [varchar](255) NULL,
	[ms_gif] [varchar](255) NULL,
	[ms_gif2] [varchar](255) NULL,
	[ms_gif3] [varchar](255) NULL,
	[ms_flv] [varchar](255) NULL,
	[ms_msg] [ntext] NULL,
	[ms_dp] [ntext] NULL,
	[ms_tg] [ntext] NULL,
	[ms_isactive] [int] NOT NULL,
	[ms_isdel] [int] NOT NULL,
	[ms_isHead] [int] NOT NULL,
	[ms_isCHead] [int] NOT NULL,
	[ms_sort] [int] NOT NULL,
	[ms_hits] [int] NOT NULL,
	[regdate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����̻�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'wID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɱ��Ŀ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������������1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_tiaojian'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�г���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_price_m'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_price_t'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���⹺������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_AMT_xn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ɹ�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_AMT_max'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ÿ���޹�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_AMT_per'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ѿ���������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_AMT_have'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʼʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_Bdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_Edate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ȯ��Ч��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_Qdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_des'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʾ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_tip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ʒ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_Gname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͼƬ1��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_gif'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͼƬ2��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_gif2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͼƬ3��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_gif3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ƶ��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_flv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_msg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ѵ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_dp'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ƹ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_tg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����/ֹͣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_isactive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�ɾ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_isdel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ���ҳ�Ƽ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_isHead'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����Ƽ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_isCHead'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ͬ������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_sort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'ms_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'¼��ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_MS', @level2type=N'COLUMN',@level2name=N'regdate'
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_wID]  DEFAULT ((0)) FOR [wID]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_tiaojian]  DEFAULT ((0)) FOR [ms_tiaojian]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_price_m]  DEFAULT ((0)) FOR [ms_price_m]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_price_t]  DEFAULT ((0)) FOR [ms_price_t]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_AMT_xn]  DEFAULT ((0)) FOR [ms_AMT_xn]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_AMT_max]  DEFAULT ((0)) FOR [ms_AMT_max]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_AMT_per]  DEFAULT ((0)) FOR [ms_AMT_per]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_AMT_have]  DEFAULT ((0)) FOR [ms_AMT_have]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_Bdate]  DEFAULT (getdate()) FOR [ms_Bdate]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_Edate]  DEFAULT (getdate()) FOR [ms_Edate]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_Qdate]  DEFAULT (getdate()) FOR [ms_Qdate]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_isactive]  DEFAULT ((1)) FOR [ms_isactive]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_isdel]  DEFAULT ((0)) FOR [ms_isdel]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_isHead]  DEFAULT ((0)) FOR [ms_isHead]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_isCHead]  DEFAULT ((0)) FOR [ms_isCHead]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_sort]  DEFAULT ((99)) FOR [ms_sort]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_ms_hits]  DEFAULT ((0)) FOR [ms_hits]
GO

ALTER TABLE [dbo].[B2C_MS] ADD  CONSTRAINT [DF_B2C_MS_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


