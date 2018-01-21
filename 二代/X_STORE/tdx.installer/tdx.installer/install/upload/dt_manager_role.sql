

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_manage__is_sy__41F8B7BD]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_manager_role] DROP CONSTRAINT [DF__dt_manage__is_sy__41F8B7BD]
END

GO


/****** Object:  Table [dbo].[dt_manager_role]    Script Date: 11/17/2014 19:55:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dt_manager_role]') AND type in (N'U'))
DROP TABLE [dbo].[dt_manager_role]
GO


/****** Object:  Table [dbo].[dt_manager_role]    Script Date: 11/17/2014 19:55:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dt_manager_role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](100) NULL,
	[role_type] [tinyint] NULL,
	[is_sys] [tinyint] NULL,
 CONSTRAINT [PK_DT_MANAGER_ROLE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager_role', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager_role', @level2type=N'COLUMN',@level2name=N'role_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager_role', @level2type=N'COLUMN',@level2name=N'role_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否系统默认0否1是' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager_role', @level2type=N'COLUMN',@level2name=N'is_sys'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager_role'
GO

ALTER TABLE [dbo].[dt_manager_role] ADD  DEFAULT ((0)) FOR [is_sys]
GO


