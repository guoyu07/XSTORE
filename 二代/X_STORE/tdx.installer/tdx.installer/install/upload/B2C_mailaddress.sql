

/****** Object:  Table [dbo].[B2C_mailaddress]    Script Date: 11/17/2014 19:37:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_mailaddress]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_mailaddress]
GO



/****** Object:  Table [dbo].[B2C_mailaddress]    Script Date: 11/17/2014 19:37:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_mailaddress](
	[id] [int] NOT NULL,
	[mailaddress] [varchar](255) NULL,
 CONSTRAINT [PK_B2C_mailaddress] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


