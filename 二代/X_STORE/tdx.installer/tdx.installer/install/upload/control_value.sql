

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_value_key_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_value] DROP CONSTRAINT [DF_control_value_key_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_value_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_value] DROP CONSTRAINT [DF_control_value_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_value_is_select]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_value] DROP CONSTRAINT [DF_control_value_is_select]
END

GO



/****** Object:  Table [dbo].[control_value]    Script Date: 11/17/2014 19:54:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[control_value]') AND type in (N'U'))
DROP TABLE [dbo].[control_value]
GO



/****** Object:  Table [dbo].[control_value]    Script Date: 11/17/2014 19:54:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[control_value](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[key_id] [int] NOT NULL,
	[value] [varchar](255) NOT NULL,
	[sort] [int] NOT NULL,
	[is_select] [int] NOT NULL,
 CONSTRAINT [PK_control_value] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'控件关联KEYid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_value', @level2type=N'COLUMN',@level2name=N'key_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应的值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_value', @level2type=N'COLUMN',@level2name=N'value'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_value', @level2type=N'COLUMN',@level2name=N'sort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否选中' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'control_value', @level2type=N'COLUMN',@level2name=N'is_select'
GO

ALTER TABLE [dbo].[control_value] ADD  CONSTRAINT [DF_control_value_key_id]  DEFAULT ((0)) FOR [key_id]
GO

ALTER TABLE [dbo].[control_value] ADD  CONSTRAINT [DF_control_value_sort]  DEFAULT ((99)) FOR [sort]
GO

ALTER TABLE [dbo].[control_value] ADD  CONSTRAINT [DF_control_value_is_select]  DEFAULT ((0)) FOR [is_select]
GO


