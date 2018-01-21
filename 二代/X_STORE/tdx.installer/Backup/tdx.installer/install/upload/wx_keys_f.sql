

/****** Object:  Table [dbo].[wx_keys_f]    Script Date: 11/17/2014 20:04:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_keys_f]') AND type in (N'U'))
DROP TABLE [dbo].[wx_keys_f]
GO



/****** Object:  Table [dbo].[wx_keys_f]    Script Date: 11/17/2014 20:04:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_keys_f](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[f_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_wx_keys_f] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


