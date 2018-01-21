

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_sendtype_st_price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_sendtype] DROP CONSTRAINT [DF_B2C_sendtype_st_price]
END

GO


/****** Object:  Table [dbo].[B2C_sendtype]    Script Date: 11/17/2014 19:45:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_sendtype]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_sendtype]
GO



/****** Object:  Table [dbo].[B2C_sendtype]    Script Date: 11/17/2014 19:45:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[B2C_sendtype](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[st_name] [nvarchar](50) NULL,
	[st_price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_B2C_sendtype] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[B2C_sendtype] ADD  CONSTRAINT [DF_B2C_sendtype_st_price]  DEFAULT ((0)) FOR [st_price]
GO


