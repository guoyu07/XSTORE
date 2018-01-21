

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_action_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_action] DROP CONSTRAINT [DF_wx_action_regdate]
END

GO



/****** Object:  Table [dbo].[wx_action]    Script Date: 11/22/2014 09:54:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_action]') AND type in (N'U'))
DROP TABLE [dbo].[wx_action]
GO



/****** Object:  Table [dbo].[wx_action]    Script Date: 11/22/2014 09:54:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_action](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[typeid] [int] NULL,
	[ac_title] [nvarchar](255) NULL,
	[ac_des] [nvarchar](255) NULL,
	[ac_bdate] [datetime] NULL,
	[ac_edate] [datetime] NULL,
	[ac_dj_info] [nvarchar](255) NULL,
	[ac_end_title] [nvarchar](255) NULL,
	[ac_jp_one] [nvarchar](255) NULL,
	[ac_jp_two] [nvarchar](255) NULL,
	[ac_jp_three] [nvarchar](255) NULL,
	[ac_b_gif] [nvarchar](255) NULL,
	[ac_zj_info] [nvarchar](255) NULL,
	[ac_end_des] [nvarchar](255) NULL,
	[ac_jp_one_num] [int] NULL,
	[ac_jp_two_num] [int] NULL,
	[ac_jp_three_num] [int] NULL,
	[ac_e_gif] [nvarchar](255) NULL,
	[ac_cf_info] [nvarchar](255) NULL,
	[regdate] [datetime] NOT NULL,
	[hits] [int] NULL,
	[views] [int] NULL,
	[ac_totlenum] [int] NULL,
	[ac_men_num] [int] NULL,
 CONSTRAINT [PK_wx_action] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'typeid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_des'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_bdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_edate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'兑奖显示信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_dj_info'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束显示标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_end_title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'一等奖' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_one'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'二等奖' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_two'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'三等奖' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_three'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开始图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_b_gif'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'中奖显示信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_zj_info'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束显示简介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_end_des'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'一等奖数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_one_num'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'二等奖数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_two_num'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'三等奖数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_three_num'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结束图片地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_e_gif'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重复信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_cf_info'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'regdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转发次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'views'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预计参加人数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_totlenum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'每人最大次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_men_num'
GO

ALTER TABLE [dbo].[wx_action] ADD  CONSTRAINT [DF_wx_action_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


