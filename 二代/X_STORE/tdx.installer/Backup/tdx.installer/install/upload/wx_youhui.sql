

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_youhui_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_youhui] DROP CONSTRAINT [DF_wx_youhui_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_youhui_isA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_youhui] DROP CONSTRAINT [DF_wx_youhui_isA]
END

GO


/****** Object:  Table [dbo].[wx_youhui]    Script Date: 11/17/2014 20:06:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_youhui]') AND type in (N'U'))
DROP TABLE [dbo].[wx_youhui]
GO


/****** Object:  Table [dbo].[wx_youhui]    Script Date: 11/17/2014 20:06:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_youhui](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regtime] [datetime] NOT NULL,
	[yh_no] [nvarchar](50) NULL,
	[FromUser] [nvarchar](50) NULL,
	[isA] [tinyint] NOT NULL,
	[cityID] [int] NULL,
 CONSTRAINT [PK_wx_youhui] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_youhui] ADD  CONSTRAINT [DF_wx_youhui_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[wx_youhui] ADD  CONSTRAINT [DF_wx_youhui_isA]  DEFAULT ((1)) FOR [isA]
GO


