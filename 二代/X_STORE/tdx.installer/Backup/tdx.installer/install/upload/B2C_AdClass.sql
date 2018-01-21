

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AdClass_BigID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AdClass] DROP CONSTRAINT [DF_B2C_AdClass_BigID]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AdClass_c_Amt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AdClass] DROP CONSTRAINT [DF_B2C_AdClass_c_Amt]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AdClass_c_width]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AdClass] DROP CONSTRAINT [DF_B2C_AdClass_c_width]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AdClass_c_height]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AdClass] DROP CONSTRAINT [DF_B2C_AdClass_c_height]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AdClass_c_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AdClass] DROP CONSTRAINT [DF_B2C_AdClass_c_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_AdClass_c_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_AdClass] DROP CONSTRAINT [DF_B2C_AdClass_c_isactive]
END

GO



/****** Object:  Table [dbo].[B2C_AdClass]    Script Date: 11/17/2014 19:30:51 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_AdClass]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_AdClass]
GO



/****** Object:  Table [dbo].[B2C_AdClass]    Script Date: 11/17/2014 19:30:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_AdClass](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BigID] [int] NOT NULL,
	[c_no] [varchar](100) NULL,
	[c_name] [varchar](100) NULL,
	[c_des] [varchar](255) NULL,
	[c_Amt] [int] NOT NULL,
	[c_width] [int] NOT NULL,
	[c_height] [int] NOT NULL,
	[c_sort] [int] NOT NULL,
	[c_isactive] [int] NOT NULL,
 CONSTRAINT [PK_B2C_AdClass] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_AdClass] ADD  CONSTRAINT [DF_B2C_AdClass_BigID]  DEFAULT ((0)) FOR [BigID]
GO

ALTER TABLE [dbo].[B2C_AdClass] ADD  CONSTRAINT [DF_B2C_AdClass_c_Amt]  DEFAULT ((0)) FOR [c_Amt]
GO

ALTER TABLE [dbo].[B2C_AdClass] ADD  CONSTRAINT [DF_B2C_AdClass_c_width]  DEFAULT ((0)) FOR [c_width]
GO

ALTER TABLE [dbo].[B2C_AdClass] ADD  CONSTRAINT [DF_B2C_AdClass_c_height]  DEFAULT ((0)) FOR [c_height]
GO

ALTER TABLE [dbo].[B2C_AdClass] ADD  CONSTRAINT [DF_B2C_AdClass_c_sort]  DEFAULT ((99)) FOR [c_sort]
GO

ALTER TABLE [dbo].[B2C_AdClass] ADD  CONSTRAINT [DF_B2C_AdClass_c_isactive]  DEFAULT ((1)) FOR [c_isactive]
GO


