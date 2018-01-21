

/****** Object:  Table [dbo].[wx_userInfo]    Script Date: 11/17/2014 20:06:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_userInfo]') AND type in (N'U'))
DROP TABLE [dbo].[wx_userInfo]
GO



/****** Object:  Table [dbo].[wx_userInfo]    Script Date: 11/17/2014 20:06:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[wx_userInfo](
	[fake_id] [varchar](255) NULL,
	[nick_name] [varchar](255) NULL,
	[remark_name] [varchar](255) NULL,
	[group_name] [varchar](255) NULL,
	[image_url] [varchar](255) NULL,
	[weixinID] [varchar](255) NULL,
	[cityID] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


