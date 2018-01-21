

/****** Object:  Table [dbo].[wx_actions2]    Script Date: 11/17/2014 20:03:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_actions2]') AND type in (N'U'))
DROP TABLE [dbo].[wx_actions2]
GO



/****** Object:  Table [dbo].[wx_actions2]    Script Date: 11/17/2014 20:03:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_actions2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ac_name] [nvarchar](50) NULL,
	[ac_url] [nvarchar](500) NULL,
 CONSTRAINT [PK_wx_actions2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


