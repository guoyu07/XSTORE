

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Table_1_wID
wID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_Table_1_wID
wID]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_tiaojian]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_tiaojian]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_tiaojian2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_tiaojian2]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_price_m]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_price_m]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_price_t]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_price_t]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_AMT_xn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_AMT_xn]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_AMT_min]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_AMT_min]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_AMT_max]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_AMT_max]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_AMT_per]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_AMT_per]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_AMT_have]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_AMT_have]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_Bdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_Bdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_Edate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_Edate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_Qdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_Qdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_isHead]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_isHead]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_isCHead]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_isCHead]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_tm_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_tm_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Team_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Team] DROP CONSTRAINT [DF_B2C_Team_regdate]
END

GO



/****** Object:  Table [dbo].[B2C_Team]    Script Date: 11/17/2014 19:46:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_Team]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_Team]
GO



/****** Object:  Table [dbo].[B2C_Team]    Script Date: 11/17/2014 19:46:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_Team](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wID] [int] NOT NULL,
	[tm_title] [varchar](255) NULL,
	[tm_tiaojian] [int] NOT NULL,
	[tm_tiaojian2] [int] NOT NULL,
	[tm_price_m] [money] NOT NULL,
	[tm_price_t] [money] NOT NULL,
	[tm_AMT_xn] [int] NOT NULL,
	[tm_AMT_min] [int] NOT NULL,
	[tm_AMT_max] [int] NOT NULL,
	[tm_AMT_per] [money] NOT NULL,
	[tm_AMT_have] [money] NOT NULL,
	[tm_Bdate] [datetime] NOT NULL,
	[tm_Edate] [datetime] NOT NULL,
	[tm_Qdate] [datetime] NOT NULL,
	[tm_des] [varchar](255) NULL,
	[tm_tip] [varchar](255) NULL,
	[tm_Gname] [varchar](255) NULL,
	[tm_gif] [varchar](255) NULL,
	[tm_gif2] [varchar](255) NULL,
	[tm_gif3] [varchar](255) NULL,
	[tm_flv] [varchar](255) NULL,
	[tm_msg] [ntext] NULL,
	[tm_dp] [ntext] NULL,
	[tm_tg] [ntext] NULL,
	[tm_isactive] [int] NOT NULL,
	[tm_isdel] [int] NOT NULL,
	[tm_isHead] [int] NOT NULL,
	[tm_isCHead] [int] NOT NULL,
	[tm_sort] [int] NOT NULL,
	[tm_hits] [int] NOT NULL,
	[regdate] [datetime] NOT NULL,
 CONSTRAINT [PK_B2C_Team] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属商户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'wID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'团购项目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成团条件限制1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_tiaojian'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成团条件限制2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_tiaojian2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'市场价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_price_m'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'团购价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_price_t'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'虚拟购买人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_AMT_xn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最少成团人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_AMT_min'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最多可购买数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_AMT_max'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每人限购数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_AMT_per'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已经购买数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_AMT_have'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_Bdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_Edate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'券有效期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_Qdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_des'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'提示' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_tip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_Gname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片1地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_gif'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片2地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_gif2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片3地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_gif3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'视频地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_flv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'本单详情' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_msg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'网友点评' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_dp'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'推广辞' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_tg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'启动/停止' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_isactive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_isdel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否首页推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_isHead'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否类别推荐' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_isCHead'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'同类排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_sort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'点击次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'tm_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'录入时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_Team', @level2type=N'COLUMN',@level2name=N'regdate'
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_Table_1_wID
wID]  DEFAULT ((0)) FOR [wID]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_tiaojian]  DEFAULT ((0)) FOR [tm_tiaojian]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_tiaojian2]  DEFAULT ((0)) FOR [tm_tiaojian2]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_price_m]  DEFAULT ((0)) FOR [tm_price_m]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_price_t]  DEFAULT ((0)) FOR [tm_price_t]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_AMT_xn]  DEFAULT ((0)) FOR [tm_AMT_xn]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_AMT_min]  DEFAULT ((0)) FOR [tm_AMT_min]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_AMT_max]  DEFAULT ((0)) FOR [tm_AMT_max]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_AMT_per]  DEFAULT ((0)) FOR [tm_AMT_per]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_AMT_have]  DEFAULT ((0)) FOR [tm_AMT_have]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_Bdate]  DEFAULT (getdate()) FOR [tm_Bdate]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_Edate]  DEFAULT (getdate()) FOR [tm_Edate]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_Qdate]  DEFAULT (getdate()) FOR [tm_Qdate]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_isactive]  DEFAULT ((1)) FOR [tm_isactive]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_isdel]  DEFAULT ((0)) FOR [tm_isdel]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_isHead]  DEFAULT ((0)) FOR [tm_isHead]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_isCHead]  DEFAULT ((0)) FOR [tm_isCHead]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_sort]  DEFAULT ((99)) FOR [tm_sort]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_tm_hits]  DEFAULT ((0)) FOR [tm_hits]
GO

ALTER TABLE [dbo].[B2C_Team] ADD  CONSTRAINT [DF_B2C_Team_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


