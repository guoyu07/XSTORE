

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_gains_acid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_gains] DROP CONSTRAINT [DF_wx_acm_action_gains_acid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_gains_lno]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_gains] DROP CONSTRAINT [DF_wx_acm_action_gains_lno]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_gains_g_num]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_gains] DROP CONSTRAINT [DF_wx_acm_action_gains_g_num]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_action_gains_g_per]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_action_gains] DROP CONSTRAINT [DF_wx_acm_action_gains_g_per]
END

GO



/****** Object:  Table [dbo].[wx_acm_action_gains]    Script Date: 11/17/2014 20:00:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_acm_action_gains]') AND type in (N'U'))
DROP TABLE [dbo].[wx_acm_action_gains]
GO



/****** Object:  Table [dbo].[wx_acm_action_gains]    Script Date: 11/17/2014 20:00:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[wx_acm_action_gains](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[acid] [int] NOT NULL,
	[lno] [varbinary](50) NOT NULL,
	[g_name] [nvarchar](50) NULL,
	[g_gif] [nvarchar](100) NULL,
	[g_cont] [nvarchar](max) NULL,
	[g_num] [int] NOT NULL,
	[g_per] [float] NOT NULL,
 CONSTRAINT [PK_wx_acm_action_gains] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[wx_acm_action_gains] ADD  CONSTRAINT [DF_wx_acm_action_gains_acid]  DEFAULT ((0)) FOR [acid]
GO

ALTER TABLE [dbo].[wx_acm_action_gains] ADD  CONSTRAINT [DF_wx_acm_action_gains_lno]  DEFAULT ((0)) FOR [lno]
GO

ALTER TABLE [dbo].[wx_acm_action_gains] ADD  CONSTRAINT [DF_wx_acm_action_gains_g_num]  DEFAULT ((0)) FOR [g_num]
GO

ALTER TABLE [dbo].[wx_acm_action_gains] ADD  CONSTRAINT [DF_wx_acm_action_gains_g_per]  DEFAULT ((0)) FOR [g_per]
GO


