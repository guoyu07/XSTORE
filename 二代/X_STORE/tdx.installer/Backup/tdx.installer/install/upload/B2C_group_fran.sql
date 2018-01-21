

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_group_fran_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_group_fran] DROP CONSTRAINT [DF_B2C_group_fran_create_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_group_fran_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_group_fran] DROP CONSTRAINT [DF_B2C_group_fran_wid]
END

GO



/****** Object:  Table [dbo].[B2C_group_fran]    Script Date: 11/17/2014 19:35:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_group_fran]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_group_fran]
GO



/****** Object:  Table [dbo].[B2C_group_fran]    Script Date: 11/17/2014 19:35:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_group_fran](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[create_time] [datetime] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[wid] [int] NOT NULL,
 CONSTRAINT [PK_B2C_group_fran] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_group_fran] ADD  CONSTRAINT [DF_B2C_group_fran_create_time]  DEFAULT (getdate()) FOR [create_time]
GO

ALTER TABLE [dbo].[B2C_group_fran] ADD  CONSTRAINT [DF_B2C_group_fran_wid]  DEFAULT ((0)) FOR [wid]
GO


