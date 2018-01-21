

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_brand_c_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_brand] DROP CONSTRAINT [DF_B2C_brand_c_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_brand_c_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_brand] DROP CONSTRAINT [DF_B2C_brand_c_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_brand_c_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_brand] DROP CONSTRAINT [DF_B2C_brand_c_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_brand_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_brand] DROP CONSTRAINT [DF_B2C_brand_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_brand_c_parent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_brand] DROP CONSTRAINT [DF_B2C_brand_c_parent]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_brand_c_level]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_brand] DROP CONSTRAINT [DF_B2C_brand_c_level]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_brand_c_child]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_brand] DROP CONSTRAINT [DF_B2C_brand_c_child]
END

GO



/****** Object:  Table [dbo].[B2C_brand]    Script Date: 11/17/2014 19:32:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_brand]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_brand]
GO



/****** Object:  Table [dbo].[B2C_brand]    Script Date: 11/17/2014 19:32:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_brand](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_no] [varchar](50) NULL,
	[c_name] [nvarchar](200) NULL,
	[c_gif] [varchar](300) NULL,
	[c_url] [varchar](2000) NULL,
	[c_sort] [int] NOT NULL,
	[c_des] [varchar](300) NULL,
	[c_isactive] [int] NOT NULL,
	[c_isdel] [int] NOT NULL,
	[regtime] [datetime] NOT NULL,
	[c_parent] [int] NOT NULL,
	[c_level] [int] NOT NULL,
	[c_child] [int] NOT NULL,
 CONSTRAINT [PK_B2C_brand] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_brand] ADD  CONSTRAINT [DF_B2C_brand_c_sort]  DEFAULT ((99)) FOR [c_sort]
GO

ALTER TABLE [dbo].[B2C_brand] ADD  CONSTRAINT [DF_B2C_brand_c_isactive]  DEFAULT ((1)) FOR [c_isactive]
GO

ALTER TABLE [dbo].[B2C_brand] ADD  CONSTRAINT [DF_B2C_brand_c_isdel]  DEFAULT ((0)) FOR [c_isdel]
GO

ALTER TABLE [dbo].[B2C_brand] ADD  CONSTRAINT [DF_B2C_brand_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[B2C_brand] ADD  CONSTRAINT [DF_B2C_brand_c_parent]  DEFAULT ((0)) FOR [c_parent]
GO

ALTER TABLE [dbo].[B2C_brand] ADD  CONSTRAINT [DF_B2C_brand_c_level]  DEFAULT ((1)) FOR [c_level]
GO

ALTER TABLE [dbo].[B2C_brand] ADD  CONSTRAINT [DF_B2C_brand_c_child]  DEFAULT ((0)) FOR [c_child]
GO


