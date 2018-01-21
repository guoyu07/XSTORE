

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Franchises_is_long]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Franchises] DROP CONSTRAINT [DF_B2C_Franchises_is_long]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Franchises_group_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Franchises] DROP CONSTRAINT [DF_B2C_Franchises_group_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Franchises_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Franchises] DROP CONSTRAINT [DF_B2C_Franchises_create_time]
END

GO


/****** Object:  Table [dbo].[B2C_Franchises]    Script Date: 11/17/2014 19:34:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_Franchises]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_Franchises]
GO



/****** Object:  Table [dbo].[B2C_Franchises]    Script Date: 11/17/2014 19:34:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_Franchises](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[is_long] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[des] [varchar](255) NULL,
	[create_time] [datetime] NOT NULL,
	[name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_B2C_Franchises] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_Franchises] ADD  CONSTRAINT [DF_B2C_Franchises_is_long]  DEFAULT ((1)) FOR [is_long]
GO

ALTER TABLE [dbo].[B2C_Franchises] ADD  CONSTRAINT [DF_B2C_Franchises_group_id]  DEFAULT ((1)) FOR [group_id]
GO

ALTER TABLE [dbo].[B2C_Franchises] ADD  CONSTRAINT [DF_B2C_Franchises_create_time]  DEFAULT (getdate()) FOR [create_time]
GO


