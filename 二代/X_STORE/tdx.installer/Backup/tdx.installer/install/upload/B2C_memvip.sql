

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_memvip_Mvip_price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_memvip] DROP CONSTRAINT [DF_B2C_memvip_Mvip_price]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_memvip_Mvip_total]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_memvip] DROP CONSTRAINT [DF_B2C_memvip_Mvip_total]
END

GO



/****** Object:  Table [dbo].[B2C_memvip]    Script Date: 11/17/2014 19:38:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_memvip]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_memvip]
GO



/****** Object:  Table [dbo].[B2C_memvip]    Script Date: 11/17/2014 19:38:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_memvip](
	[Mvip_id] [int] IDENTITY(1,1) NOT NULL,
	[Mvip_name] [varchar](50) NULL,
	[Mvip_price] [decimal](18, 2) NOT NULL,
	[Mvip_total] [decimal](18, 2) NOT NULL,
	[Mvip_des] [varchar](255) NULL,
 CONSTRAINT [PK_B2C_memvip] PRIMARY KEY CLUSTERED 
(
	[Mvip_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_memvip] ADD  CONSTRAINT [DF_B2C_memvip_Mvip_price]  DEFAULT ((0)) FOR [Mvip_price]
GO

ALTER TABLE [dbo].[B2C_memvip] ADD  CONSTRAINT [DF_B2C_memvip_Mvip_total]  DEFAULT ((0)) FOR [Mvip_total]
GO


