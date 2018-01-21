

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_tmsg_pid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_tmsg] DROP CONSTRAINT [DF_wx_tmsg_pid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_tmsg_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_tmsg] DROP CONSTRAINT [DF_wx_tmsg_regtime]
END

GO



/****** Object:  Table [dbo].[wx_tmsg]    Script Date: 11/17/2014 20:05:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_tmsg]') AND type in (N'U'))
DROP TABLE [dbo].[wx_tmsg]
GO



/****** Object:  Table [dbo].[wx_tmsg]    Script Date: 11/17/2014 20:05:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_tmsg](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ToUserName] [nvarchar](50) NULL,
	[FromUserName] [nvarchar](50) NULL,
	[MsgType] [nvarchar](50) NULL,
	[Msg] [nvarchar](max) NULL,
	[MsgId] [nvarchar](50) NULL,
	[Creatime] [nvarchar](50) NULL,
	[Location_X] [nvarchar](50) NULL,
	[Location_Y] [nvarchar](50) NULL,
	[Scale] [nvarchar](50) NULL,
	[Label] [nvarchar](50) NULL,
	[PicUrl] [nvarchar](500) NULL,
	[reply] [nvarchar](max) NULL,
	[pid] [int] NOT NULL,
	[regtime] [datetime] NOT NULL,
	[cityID] [int] NULL,
 CONSTRAINT [PK_wx_tmsg] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_tmsg] ADD  CONSTRAINT [DF_wx_tmsg_pid]  DEFAULT ((0)) FOR [pid]
GO

ALTER TABLE [dbo].[wx_tmsg] ADD  CONSTRAINT [DF_wx_tmsg_regtime]  DEFAULT (getdate()) FOR [regtime]
GO


