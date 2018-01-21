

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__B2C_Hclas__c_sor__51EF2864]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Hclass] DROP CONSTRAINT [DF__B2C_Hclas__c_sor__51EF2864]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__B2C_Hclas__c_isa__52E34C9D]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Hclass] DROP CONSTRAINT [DF__B2C_Hclas__c_isa__52E34C9D]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__B2C_Hclas__c_isd__53D770D6]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Hclass] DROP CONSTRAINT [DF__B2C_Hclas__c_isd__53D770D6]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__B2C_Hclas__regti__54CB950F]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Hclass] DROP CONSTRAINT [DF__B2C_Hclas__regti__54CB950F]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__B2C_Hclas__c_par__55BFB948]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Hclass] DROP CONSTRAINT [DF__B2C_Hclas__c_par__55BFB948]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__B2C_Hclas__c_lev__56B3DD81]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Hclass] DROP CONSTRAINT [DF__B2C_Hclas__c_lev__56B3DD81]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__B2C_Hclas__c_chi__57A801BA]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_Hclass] DROP CONSTRAINT [DF__B2C_Hclas__c_chi__57A801BA]
END

GO



/****** Object:  Table [dbo].[B2C_Hclass]    Script Date: 11/17/2014 19:35:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_Hclass]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_Hclass]
GO



/****** Object:  Table [dbo].[B2C_Hclass]    Script Date: 11/17/2014 19:35:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_Hclass](
	[c_id] [int] IDENTITY(1,1) NOT NULL,
	[c_no] [varchar](100) NOT NULL,
	[c_name] [nvarchar](200) NOT NULL,
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
 CONSTRAINT [PK__B2C_Hclass__50FB042B] PRIMARY KEY CLUSTERED 
(
	[c_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_Hclass] ADD  CONSTRAINT [DF__B2C_Hclas__c_sor__51EF2864]  DEFAULT ((99)) FOR [c_sort]
GO

ALTER TABLE [dbo].[B2C_Hclass] ADD  CONSTRAINT [DF__B2C_Hclas__c_isa__52E34C9D]  DEFAULT ((1)) FOR [c_isactive]
GO

ALTER TABLE [dbo].[B2C_Hclass] ADD  CONSTRAINT [DF__B2C_Hclas__c_isd__53D770D6]  DEFAULT ((0)) FOR [c_isdel]
GO

ALTER TABLE [dbo].[B2C_Hclass] ADD  CONSTRAINT [DF__B2C_Hclas__regti__54CB950F]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[B2C_Hclass] ADD  CONSTRAINT [DF__B2C_Hclas__c_par__55BFB948]  DEFAULT ((0)) FOR [c_parent]
GO

ALTER TABLE [dbo].[B2C_Hclass] ADD  CONSTRAINT [DF__B2C_Hclas__c_lev__56B3DD81]  DEFAULT ((1)) FOR [c_level]
GO

ALTER TABLE [dbo].[B2C_Hclass] ADD  CONSTRAINT [DF__B2C_Hclas__c_chi__57A801BA]  DEFAULT ((0)) FOR [c_child]
GO


