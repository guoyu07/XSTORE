

/****** Object:  Table [dbo].[weixin_class]    Script Date: 11/17/2014 20:00:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[weixin_class]') AND type in (N'U'))
DROP TABLE [dbo].[weixin_class]
GO



/****** Object:  Table [dbo].[weixin_class]    Script Date: 11/17/2014 20:00:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[weixin_class](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[number] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[image] [varchar](255) NULL,
	[url] [varchar](255) NULL,
	[sort] [int] NULL,
	[describe] [varchar](5000) NULL,
	[is_active] [int] NULL,
	[is_delete] [int] NULL,
	[reg_time] [datetime] NULL,
	[fat_Id] [int] NULL,
	[class_level] [int] NULL,
	[child_number] [int] NULL,
	[count_child] [int] NULL,
	[city_ID] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


