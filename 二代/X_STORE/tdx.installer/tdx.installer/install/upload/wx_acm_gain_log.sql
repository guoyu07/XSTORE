

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_gain_log_acID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_gain_log] DROP CONSTRAINT [DF_wx_acm_gain_log_acID]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_gain_log_result]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_gain_log] DROP CONSTRAINT [DF_wx_acm_gain_log_result]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_gain_log_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_gain_log] DROP CONSTRAINT [DF_wx_acm_gain_log_regdate]
END

GO



/****** Object:  Table [dbo].[wx_acm_gain_log]    Script Date: 11/17/2014 20:01:42 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_acm_gain_log]') AND type in (N'U'))
DROP TABLE [dbo].[wx_acm_gain_log]
GO



/****** Object:  Table [dbo].[wx_acm_gain_log]    Script Date: 11/17/2014 20:01:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_acm_gain_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[acID] [int] NOT NULL,
	[wwv] [nvarchar](50) NULL,
	[guidno] [nvarchar](50) NULL,
	[result] [tinyint] NOT NULL,
	[regdate] [datetime] NOT NULL,
 CONSTRAINT [PK_wx_acm_gain_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_acm_gain_log] ADD  CONSTRAINT [DF_wx_acm_gain_log_acID]  DEFAULT ((0)) FOR [acID]
GO

ALTER TABLE [dbo].[wx_acm_gain_log] ADD  CONSTRAINT [DF_wx_acm_gain_log_result]  DEFAULT ((0)) FOR [result]
GO

ALTER TABLE [dbo].[wx_acm_gain_log] ADD  CONSTRAINT [DF_wx_acm_gain_log_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


