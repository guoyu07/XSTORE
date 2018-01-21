

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_share_t_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_share] DROP CONSTRAINT [DF_B2C_share_t_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_share_t_wdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_share] DROP CONSTRAINT [DF_B2C_share_t_wdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_share_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_share] DROP CONSTRAINT [DF_B2C_share_regdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_share_t_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_share] DROP CONSTRAINT [DF_B2C_share_t_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_share_t_ischead]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_share] DROP CONSTRAINT [DF_B2C_share_t_ischead]
END

GO



/****** Object:  Table [dbo].[B2C_share]    Script Date: 11/17/2014 19:45:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_share]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_share]
GO



/****** Object:  Table [dbo].[B2C_share]    Script Date: 11/17/2014 19:45:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_share](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[t_title] [varchar](255) NULL,
	[t_msg] [ntext] NULL,
	[t_hits] [int] NOT NULL,
	[t_wdate] [datetime] NULL,
	[regdate] [datetime] NULL,
	[t_isactive] [int] NULL,
	[t_ischead] [int] NULL,
	[t_gif] [varchar](255) NULL,
 CONSTRAINT [PK_B2C_SHARE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share', @level2type=N'COLUMN',@level2name=N't_title'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share', @level2type=N'COLUMN',@level2name=N't_msg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���ʴ���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share', @level2type=N'COLUMN',@level2name=N't_hits'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���༭ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share', @level2type=N'COLUMN',@level2name=N't_wdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share', @level2type=N'COLUMN',@level2name=N'regdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�����Ƿ���� Ĭ��0Ϊ�򲻿��� ���������Ϊ1 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share', @level2type=N'COLUMN',@level2name=N't_isactive'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������Ļ�õĻ�����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share', @level2type=N'COLUMN',@level2name=N't_ischead'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ͼ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share', @level2type=N'COLUMN',@level2name=N't_gif'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������¹���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_share'
GO

ALTER TABLE [dbo].[B2C_share] ADD  CONSTRAINT [DF_B2C_share_t_hits]  DEFAULT ((0)) FOR [t_hits]
GO

ALTER TABLE [dbo].[B2C_share] ADD  CONSTRAINT [DF_B2C_share_t_wdate]  DEFAULT (getdate()) FOR [t_wdate]
GO

ALTER TABLE [dbo].[B2C_share] ADD  CONSTRAINT [DF_B2C_share_regdate]  DEFAULT (getdate()) FOR [regdate]
GO

ALTER TABLE [dbo].[B2C_share] ADD  CONSTRAINT [DF_B2C_share_t_isactive]  DEFAULT ((0)) FOR [t_isactive]
GO

ALTER TABLE [dbo].[B2C_share] ADD  CONSTRAINT [DF_B2C_share_t_ischead]  DEFAULT ((0)) FOR [t_ischead]
GO


