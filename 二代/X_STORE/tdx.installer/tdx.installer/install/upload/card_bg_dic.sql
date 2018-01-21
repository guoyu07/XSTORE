

/****** Object:  Table [dbo].[card_bg_dic]    Script Date: 11/17/2014 19:52:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[card_bg_dic]') AND type in (N'U'))
DROP TABLE [dbo].[card_bg_dic]
GO



/****** Object:  Table [dbo].[card_bg_dic]    Script Date: 11/17/2014 19:52:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[card_bg_dic](
	[id] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[color_url] [varchar](255) NOT NULL,
 CONSTRAINT [PK_card_bg_dic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


