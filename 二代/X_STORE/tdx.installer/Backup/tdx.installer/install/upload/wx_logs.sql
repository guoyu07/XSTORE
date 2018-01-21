

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_logs_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_logs] DROP CONSTRAINT [DF_wx_logs_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_logs_isReplay]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_logs] DROP CONSTRAINT [DF_wx_logs_isReplay]
END

GO



/****** Object:  Table [dbo].[wx_logs]    Script Date: 11/17/2014 20:05:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_logs]') AND type in (N'U'))
DROP TABLE [dbo].[wx_logs]
GO


/****** Object:  Table [dbo].[wx_logs]    Script Date: 11/17/2014 20:05:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regtime] [datetime] NOT NULL,
	[Lmsg] [nvarchar](max) NULL,
	[FromUser] [nvarchar](50) NULL,
	[toUser] [nvarchar](50) NULL,
	[Ltype] [nvarchar](50) NULL,
	[isReply] [tinyint] NOT NULL,
	[LRe] [nvarchar](max) NULL,
	[cityID] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_logs] ADD  CONSTRAINT [DF_wx_logs_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[wx_logs] ADD  CONSTRAINT [DF_wx_logs_isReplay]  DEFAULT ((0)) FOR [isReply]
GO


