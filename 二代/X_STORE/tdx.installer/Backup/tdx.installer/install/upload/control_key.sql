

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_key_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_key] DROP CONSTRAINT [DF_control_key_wid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_key_type_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_key] DROP CONSTRAINT [DF_control_key_type_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_key_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_key] DROP CONSTRAINT [DF_control_key_sort]
END

GO



/****** Object:  Table [dbo].[control_key]    Script Date: 11/17/2014 19:53:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[control_key]') AND type in (N'U'))
DROP TABLE [dbo].[control_key]
GO



/****** Object:  Table [dbo].[control_key]    Script Date: 11/17/2014 19:53:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[control_key](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wid] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[type_id] [int] NOT NULL,
	[sort] [int] NOT NULL,
 CONSTRAINT [PK_control_key] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_key', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公众号ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_key', @level2type=N'COLUMN',@level2name=N'wid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控件名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_key', @level2type=N'COLUMN',@level2name=N'name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控件类型ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_key', @level2type=N'COLUMN',@level2name=N'type_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_key', @level2type=N'COLUMN',@level2name=N'sort'
GO

ALTER TABLE [dbo].[control_key] ADD  CONSTRAINT [DF_control_key_wid]  DEFAULT ((0)) FOR [wid]
GO

ALTER TABLE [dbo].[control_key] ADD  CONSTRAINT [DF_control_key_type_id]  DEFAULT ((1)) FOR [type_id]
GO

ALTER TABLE [dbo].[control_key] ADD  CONSTRAINT [DF_control_key_sort]  DEFAULT ((99)) FOR [sort]
GO


