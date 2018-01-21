

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_paytype_pt_isActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_paytype] DROP CONSTRAINT [DF_B2C_paytype_pt_isActive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_paytype_pt_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_paytype] DROP CONSTRAINT [DF_B2C_paytype_pt_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_paytype_pt_isYN]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_paytype] DROP CONSTRAINT [DF_B2C_paytype_pt_isYN]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_paytype_pt_isWEB]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_paytype] DROP CONSTRAINT [DF_B2C_paytype_pt_isWEB]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_paytype_pt_isBank]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_paytype] DROP CONSTRAINT [DF_B2C_paytype_pt_isBank]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_paytype_pt_AMT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_paytype] DROP CONSTRAINT [DF_B2C_paytype_pt_AMT]
END

GO



/****** Object:  Table [dbo].[B2C_paytype]    Script Date: 11/17/2014 19:42:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_paytype]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_paytype]
GO



/****** Object:  Table [dbo].[B2C_paytype]    Script Date: 11/17/2014 19:42:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_paytype](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pt_name] [varchar](50) NOT NULL,
	[pt_isActive] [int] NOT NULL,
	[pt_isdel] [int] NOT NULL,
	[pt_isYN] [int] NOT NULL,
	[pt_isWEB] [int] NOT NULL,
	[pt_isBank] [int] NOT NULL,
	[pt_AMT] [money] NOT NULL,
 CONSTRAINT [PK_B2C_paytype] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_paytype] ADD  CONSTRAINT [DF_B2C_paytype_pt_isActive]  DEFAULT ((1)) FOR [pt_isActive]
GO

ALTER TABLE [dbo].[B2C_paytype] ADD  CONSTRAINT [DF_B2C_paytype_pt_isdel]  DEFAULT ((0)) FOR [pt_isdel]
GO

ALTER TABLE [dbo].[B2C_paytype] ADD  CONSTRAINT [DF_B2C_paytype_pt_isYN]  DEFAULT ((0)) FOR [pt_isYN]
GO

ALTER TABLE [dbo].[B2C_paytype] ADD  CONSTRAINT [DF_B2C_paytype_pt_isWEB]  DEFAULT ((0)) FOR [pt_isWEB]
GO

ALTER TABLE [dbo].[B2C_paytype] ADD  CONSTRAINT [DF_B2C_paytype_pt_isBank]  DEFAULT ((0)) FOR [pt_isBank]
GO

ALTER TABLE [dbo].[B2C_paytype] ADD  CONSTRAINT [DF_B2C_paytype_pt_AMT]  DEFAULT ((0)) FOR [pt_AMT]
GO


