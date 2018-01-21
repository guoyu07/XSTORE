

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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'typeid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_des'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʼʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_bdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_edate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ҽ���ʾ��Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_dj_info'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ʾ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_end_title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'һ�Ƚ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_one'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ƚ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_two'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ƚ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_three'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ʼͼƬ��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_b_gif'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�н���ʾ��Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_zj_info'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ʾ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_end_des'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'һ�Ƚ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_one_num'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ƚ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_two_num'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���Ƚ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_jp_three_num'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ͼƬ��ַ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_e_gif'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ظ���Ϣ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_cf_info'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'regdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ת������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'views'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ԥ�Ʋμ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_totlenum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ÿ��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'wx_action', @level2type=N'COLUMN',@level2name=N'ac_men_num'
GO

ALTER TABLE [dbo].[wx_action] ADD  CONSTRAINT [DF_wx_action_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


