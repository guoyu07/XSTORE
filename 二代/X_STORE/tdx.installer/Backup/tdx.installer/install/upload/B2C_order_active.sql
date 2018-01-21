

/****** Object:  Table [dbo].[B2C_order_active]    Script Date: 11/17/2014 19:40:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_order_active]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_order_active]
GO



/****** Object:  Table [dbo].[B2C_order_active]    Script Date: 11/17/2014 19:40:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[B2C_order_active](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[a_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_B2C_order_active] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


