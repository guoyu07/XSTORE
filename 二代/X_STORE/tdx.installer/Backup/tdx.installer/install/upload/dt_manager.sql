

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_manage__role___3A5795F5]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_manager] DROP CONSTRAINT [DF__dt_manage__role___3A5795F5]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_manage__real___3B4BBA2E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_manager] DROP CONSTRAINT [DF__dt_manage__real___3B4BBA2E]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_manage__telep__3C3FDE67]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_manager] DROP CONSTRAINT [DF__dt_manage__telep__3C3FDE67]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_manage__email__3D3402A0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_manager] DROP CONSTRAINT [DF__dt_manage__email__3D3402A0]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_manage__is_lo__3E2826D9]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_manager] DROP CONSTRAINT [DF__dt_manage__is_lo__3E2826D9]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__dt_manage__add_t__3F1C4B12]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[dt_manager] DROP CONSTRAINT [DF__dt_manage__add_t__3F1C4B12]
END

GO


/****** Object:  Table [dbo].[dt_manager]    Script Date: 11/17/2014 19:55:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[dt_manager]') AND type in (N'U'))
DROP TABLE [dbo].[dt_manager]
GO



/****** Object:  Table [dbo].[dt_manager]    Script Date: 11/17/2014 19:55:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[dt_manager](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[role_type] [int] NULL,
	[user_name] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[salt] [nvarchar](20) NULL,
	[real_name] [nvarchar](50) NULL,
	[telephone] [nvarchar](30) NULL,
	[email] [nvarchar](30) NULL,
	[is_lock] [int] NULL,
	[add_time] [datetime] NULL,
 CONSTRAINT [PK_DT_MANAGER] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ɫID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'role_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ա����1����2ϵ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'role_type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'user_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'password'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'6λ����ַ���,�����õ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'salt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û��ǳ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'real_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ϵ�绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'telephone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'is_lock'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager', @level2type=N'COLUMN',@level2name=N'add_time'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����Ա��Ϣ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'dt_manager'
GO

ALTER TABLE [dbo].[dt_manager] ADD  DEFAULT ((2)) FOR [role_type]
GO

ALTER TABLE [dbo].[dt_manager] ADD  DEFAULT ('') FOR [real_name]
GO

ALTER TABLE [dbo].[dt_manager] ADD  DEFAULT ('') FOR [telephone]
GO

ALTER TABLE [dbo].[dt_manager] ADD  DEFAULT ('') FOR [email]
GO

ALTER TABLE [dbo].[dt_manager] ADD  DEFAULT ((0)) FOR [is_lock]
GO

ALTER TABLE [dbo].[dt_manager] ADD  DEFAULT (getdate()) FOR [add_time]
GO


