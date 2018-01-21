

/****** Object:  Table [dbo].[B2C_HY]    Script Date: 11/17/2014 19:35:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_HY]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_HY]
GO


/****** Object:  Table [dbo].[B2C_HY]    Script Date: 11/17/2014 19:35:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[B2C_HY](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hy_no] [nvarchar](50) NULL,
	[hy_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_B2C_HY] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


