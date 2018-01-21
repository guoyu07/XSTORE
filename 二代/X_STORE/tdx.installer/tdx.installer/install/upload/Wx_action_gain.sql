

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Wx_action_gain_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Wx_action_gain] DROP CONSTRAINT [DF_Wx_action_gain_regdate]
END

GO



/****** Object:  Table [dbo].[Wx_action_gain]    Script Date: 11/17/2014 20:03:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wx_action_gain]') AND type in (N'U'))
DROP TABLE [dbo].[Wx_action_gain]
GO



/****** Object:  Table [dbo].[Wx_action_gain]    Script Date: 11/17/2014 20:03:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Wx_action_gain](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regdate] [datetime] NOT NULL,
	[acID] [int] NOT NULL,
	[ac_jpID] [int] NOT NULL,
	[froms] [nvarchar](255) NOT NULL,
	[from_tel] [nvarchar](255) NULL,
	[from_name] [nvarchar](255) NULL,
	[from_comp] [nvarchar](255) NULL,
	[from_addr] [nvarchar](255) NULL,
	[from_email] [nvarchar](255) NULL,
	[SN] [nvarchar](255) NULL,
 CONSTRAINT [PK_Wx_action_gain] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_gain', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_gain', @level2type=N'COLUMN',@level2name=N'regdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_gain', @level2type=N'COLUMN',@level2name=N'acID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'奖品ID 和1230一致' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_gain', @level2type=N'COLUMN',@level2name=N'ac_jpID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加活动微信' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_gain', @level2type=N'COLUMN',@level2name=N'froms'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_gain', @level2type=N'COLUMN',@level2name=N'from_tel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_gain', @level2type=N'COLUMN',@level2name=N'from_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SN码随机生成' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_gain', @level2type=N'COLUMN',@level2name=N'SN'
GO

ALTER TABLE [dbo].[Wx_action_gain] ADD  CONSTRAINT [DF_Wx_action_gain_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


