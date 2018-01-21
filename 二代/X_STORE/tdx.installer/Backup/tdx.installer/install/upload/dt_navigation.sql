

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__nav_t__4999D985]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__nav_t__4999D985]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_navigat__name__4A8DFDBE]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_navigat__name__4A8DFDBE]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__title__4B8221F7]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__title__4B8221F7]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__sub_t__4C764630]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__sub_t__4C764630]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__link___4D6A6A69]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__link___4D6A6A69]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__sort___4E5E8EA2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__sort___4E5E8EA2]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__is_lo__4F52B2DB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__is_lo__4F52B2DB]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__remar__5046D714]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__remar__5046D714]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__paren__513AFB4D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__paren__513AFB4D]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__class__522F1F86]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__class__522F1F86]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__class__532343BF]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__class__532343BF]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__chann__541767F8]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__chann__541767F8]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__actio__550B8C31]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__actio__550B8C31]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_naviga__is_sy__55FFB06A]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_navigation] DROP CONSTRAINT [DF__dt_naviga__is_sy__55FFB06A]
END

GO



/****** Object:  Table [dbo].[dt_navigation]    Script Date: 11/17/2014 19:56:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dt_navigation]') AND type in (N'U'))
DROP TABLE [dbo].[dt_navigation]
GO


/****** Object:  Table [dbo].[dt_navigation]    Script Date: 11/17/2014 19:56:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dt_navigation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nav_type] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[title] [nvarchar](100) NULL,
	[sub_title] [nvarchar](100) NULL,
	[link_url] [nvarchar](255) NULL,
	[sort_id] [int] NULL,
	[is_lock] [tinyint] NULL,
	[remark] [nvarchar](500) NULL,
	[parent_id] [int] NULL,
	[class_list] [nvarchar](500) NULL,
	[class_layer] [int] NULL,
	[channel_id] [int] NULL,
	[action_type] [nvarchar](500) NULL,
	[is_sys] [tinyint] NULL,
 CONSTRAINT [PK_DT_NAVIGATION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导航类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'nav_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导航ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'副标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'sub_title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'link_url'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序数字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'sort_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否隐藏0显示1隐藏' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'is_lock'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'remark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属父导航ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'parent_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单ID列表(逗号分隔开)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'class_list'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导航深度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'class_layer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属频道ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'channel_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限资源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'action_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统默认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation', @level2type=N'COLUMN',@level2name=N'is_sys'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统导航菜单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_navigation'
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ('') FOR [nav_type]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ('') FOR [name]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ('') FOR [title]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ('') FOR [sub_title]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ('') FOR [link_url]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ((99)) FOR [sort_id]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ((0)) FOR [is_lock]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ('') FOR [remark]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ((0)) FOR [parent_id]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ('') FOR [class_list]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ((1)) FOR [class_layer]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ((0)) FOR [channel_id]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ('') FOR [action_type]
GO

ALTER TABLE [dbo].[dt_navigation] ADD  DEFAULT ((0)) FOR [is_sys]
GO


