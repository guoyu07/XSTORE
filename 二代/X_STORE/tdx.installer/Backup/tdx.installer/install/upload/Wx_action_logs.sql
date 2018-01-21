

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Wx_action_logs_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Wx_action_logs] DROP CONSTRAINT [DF_Wx_action_logs_regdate]
END

GO



/****** Object:  Table [dbo].[Wx_action_logs]    Script Date: 11/17/2014 20:03:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Wx_action_logs]') AND type in (N'U'))
DROP TABLE [dbo].[Wx_action_logs]
GO



/****** Object:  Table [dbo].[Wx_action_logs]    Script Date: 11/17/2014 20:03:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Wx_action_logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regdate] [datetime] NOT NULL,
	[acID] [int] NOT NULL,
	[froms] [nvarchar](255) NOT NULL,
	[from_Res] [int] NOT NULL,
 CONSTRAINT [PK_Wx_action_logs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_logs', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_logs', @level2type=N'COLUMN',@level2name=N'regdate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'活动ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_logs', @level2type=N'COLUMN',@level2name=N'acID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加活动微信' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_logs', @level2type=N'COLUMN',@level2name=N'froms'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'参加活动结果123代表几等奖0代表没有' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Wx_action_logs', @level2type=N'COLUMN',@level2name=N'from_Res'
GO

ALTER TABLE [dbo].[Wx_action_logs] ADD  CONSTRAINT [DF_Wx_action_logs_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


