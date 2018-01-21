

/****** Object:  Table [dbo].[wx_actions]    Script Date: 11/17/2014 20:03:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_actions]') AND type in (N'U'))
DROP TABLE [dbo].[wx_actions]
GO



/****** Object:  Table [dbo].[wx_actions]    Script Date: 11/17/2014 20:03:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_actions](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[ac_name] [nvarchar](50) NULL,
	[ac_url] [nvarchar](300) NULL,
 CONSTRAINT [PK_wx_actions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


