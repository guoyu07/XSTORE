
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_rights_r_parent]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_rights] DROP CONSTRAINT [DF_B2C_rights_r_parent]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_rights_r_level]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_rights] DROP CONSTRAINT [DF_B2C_rights_r_level]
END

GO



/****** Object:  Table [dbo].[B2C_rights]    Script Date: 11/17/2014 19:44:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_rights]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_rights]
GO



/****** Object:  Table [dbo].[B2C_rights]    Script Date: 11/17/2014 19:44:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_rights](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[r_name] [varchar](50) NOT NULL,
	[r_parent] [int] NOT NULL,
	[r_level] [int] NOT NULL,
 CONSTRAINT [PK_B2C_rights] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_rights] ADD  CONSTRAINT [DF_B2C_rights_r_parent]  DEFAULT ((0)) FOR [r_parent]
GO

ALTER TABLE [dbo].[B2C_rights] ADD  CONSTRAINT [DF_B2C_rights_r_level]  DEFAULT ((0)) FOR [r_level]
GO


