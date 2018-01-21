
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Downs_w_sort]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Downs] DROP CONSTRAINT [DF_B2C_Downs_w_sort]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Downs_w_wdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Downs] DROP CONSTRAINT [DF_B2C_Downs_w_wdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Downs_w_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Downs] DROP CONSTRAINT [DF_B2C_Downs_w_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Downs_w_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Downs] DROP CONSTRAINT [DF_B2C_Downs_w_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Downs_w_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Downs] DROP CONSTRAINT [DF_B2C_Downs_w_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Downs_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Downs] DROP CONSTRAINT [DF_B2C_Downs_regdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_Downs_cityID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Downs] DROP CONSTRAINT [DF_B2C_Downs_cityID]
END

GO


/****** Object:  Table [dbo].[B2C_Downs]    Script Date: 11/19/2014 12:01:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_Downs]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_Downs]
GO


/****** Object:  Table [dbo].[B2C_Downs]    Script Date: 11/19/2014 12:01:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_Downs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[P_tab] [varchar](50) NOT NULL,
	[P_row] [varchar](50) NOT NULL,
	[P_no] [varchar](50) NOT NULL,
	[cno] [varchar](50) NULL,
	[P_name] [varchar](255) NOT NULL,
	[P_gif] [varchar](255) NULL,
	[P_url] [varchar](255) NULL,
	[P_des] [varchar](255) NULL,
	[P_ftype] [varchar](50) NULL,
	[P_fweight] [varchar](50) NULL,
	[P_sort] [int] NOT NULL,
	[P_wdate] [datetime] NOT NULL,
	[P_hits] [int] NOT NULL,
	[P_isactive] [int] NOT NULL,
	[P_isdel] [int] NOT NULL,
	[regdate] [datetime] NOT NULL,
	[cityID] [int] NOT NULL,
 CONSTRAINT [PK_B2C_Downs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_Downs] ADD  CONSTRAINT [DF_B2C_Downs_w_sort]  DEFAULT ((99)) FOR [P_sort]
GO

ALTER TABLE [dbo].[B2C_Downs] ADD  CONSTRAINT [DF_B2C_Downs_w_wdate]  DEFAULT (getdate()) FOR [P_wdate]
GO

ALTER TABLE [dbo].[B2C_Downs] ADD  CONSTRAINT [DF_B2C_Downs_w_hits]  DEFAULT ((0)) FOR [P_hits]
GO

ALTER TABLE [dbo].[B2C_Downs] ADD  CONSTRAINT [DF_B2C_Downs_w_isactive]  DEFAULT ((1)) FOR [P_isactive]
GO

ALTER TABLE [dbo].[B2C_Downs] ADD  CONSTRAINT [DF_B2C_Downs_w_isdel]  DEFAULT ((0)) FOR [P_isdel]
GO

ALTER TABLE [dbo].[B2C_Downs] ADD  CONSTRAINT [DF_B2C_Downs_regdate]  DEFAULT (getdate()) FOR [regdate]
GO

ALTER TABLE [dbo].[B2C_Downs] ADD  CONSTRAINT [DF_B2C_Downs_cityID]  DEFAULT ((1)) FOR [cityID]
GO


