

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Goods_M_gid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Goods_M] DROP CONSTRAINT [DF_B2C_Goods_M_gid]
END

GO



/****** Object:  Table [dbo].[B2C_Goods_M]    Script Date: 11/17/2014 19:34:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_Goods_M]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_Goods_M]
GO



/****** Object:  Table [dbo].[B2C_Goods_M]    Script Date: 11/17/2014 19:34:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[B2C_Goods_M](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[gid] [int] NOT NULL,
	[g_msg] [ntext] NULL,
 CONSTRAINT [PK_B2C_Goods_M] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[B2C_Goods_M] ADD  CONSTRAINT [DF_B2C_Goods_M_gid]  DEFAULT ((0)) FOR [gid]
GO


