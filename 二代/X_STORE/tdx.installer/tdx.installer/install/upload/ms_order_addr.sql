

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_addr_a_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_addr] DROP CONSTRAINT [DF_ms_order_addr_a_isdel]
END

GO



/****** Object:  Table [dbo].[ms_order_addr]    Script Date: 11/17/2014 19:57:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ms_order_addr]') AND type in (N'U'))
DROP TABLE [dbo].[ms_order_addr]
GO



/****** Object:  Table [dbo].[ms_order_addr]    Script Date: 11/17/2014 19:57:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ms_order_addr](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ono] [nvarchar](50) NULL,
	[a_name] [nvarchar](50) NULL,
	[a_addr] [nvarchar](50) NULL,
	[a_addr2] [nvarchar](255) NULL,
	[a_zip] [nvarchar](50) NULL,
	[a_tel] [nvarchar](50) NULL,
	[a_mobile] [nvarchar](50) NULL,
	[a_senddate] [nvarchar](50) NULL,
	[a_des] [nvarchar](255) NULL,
	[a_isdel] [tinyint] NOT NULL,
 CONSTRAINT [PK_ms_order_addr] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ms_order_addr] ADD  CONSTRAINT [DF_ms_order_addr_a_isdel]  DEFAULT ((0)) FOR [a_isdel]
GO


