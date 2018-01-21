

/****** Object:  Table [dbo].[wx_acm_level]    Script Date: 11/17/2014 20:02:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_acm_level]') AND type in (N'U'))
DROP TABLE [dbo].[wx_acm_level]
GO



/****** Object:  Table [dbo].[wx_acm_level]    Script Date: 11/17/2014 20:02:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_acm_level](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[c_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_wx_acm_level] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


