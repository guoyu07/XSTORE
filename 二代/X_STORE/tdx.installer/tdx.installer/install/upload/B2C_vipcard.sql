

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_vipcard_is_open]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_vipcard] DROP CONSTRAINT [DF_B2C_vipcard_is_open]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_vipcard_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_vipcard] DROP CONSTRAINT [DF_B2C_vipcard_wid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_vipcard_card_start]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_vipcard] DROP CONSTRAINT [DF_B2C_vipcard_card_start]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_vipcard_acc_card]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_vipcard] DROP CONSTRAINT [DF_B2C_vipcard_acc_card]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_vipcard_get_card_condition]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_vipcard] DROP CONSTRAINT [DF_B2C_vipcard_get_card_condition]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_vipcard_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_vipcard] DROP CONSTRAINT [DF_B2C_vipcard_create_time]
END

GO



/****** Object:  Table [dbo].[B2C_vipcard]    Script Date: 11/17/2014 19:48:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_vipcard]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_vipcard]
GO



/****** Object:  Table [dbo].[B2C_vipcard]    Script Date: 11/17/2014 19:48:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_vipcard](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[is_open] [int] NOT NULL,
	[wid] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[title_image] [varchar](255) NOT NULL,
	[pre_name] [varchar](255) NOT NULL,
	[card_start] [int] NOT NULL,
	[acc_card] [int] NOT NULL,
	[get_card_condition] [int] NOT NULL,
	[no_getinfo] [varchar](255) NULL,
	[create_time] [datetime] NOT NULL,
	[card_info] [varchar](50) NULL,
 CONSTRAINT [PK_B2C_vipcard] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_vipcard] ADD  CONSTRAINT [DF_B2C_vipcard_is_open]  DEFAULT ((0)) FOR [is_open]
GO

ALTER TABLE [dbo].[B2C_vipcard] ADD  CONSTRAINT [DF_B2C_vipcard_wid]  DEFAULT ((0)) FOR [wid]
GO

ALTER TABLE [dbo].[B2C_vipcard] ADD  CONSTRAINT [DF_B2C_vipcard_card_start]  DEFAULT ((1)) FOR [card_start]
GO

ALTER TABLE [dbo].[B2C_vipcard] ADD  CONSTRAINT [DF_B2C_vipcard_acc_card]  DEFAULT ((1)) FOR [acc_card]
GO

ALTER TABLE [dbo].[B2C_vipcard] ADD  CONSTRAINT [DF_B2C_vipcard_get_card_condition]  DEFAULT ((0)) FOR [get_card_condition]
GO

ALTER TABLE [dbo].[B2C_vipcard] ADD  CONSTRAINT [DF_B2C_vipcard_create_time]  DEFAULT (getdate()) FOR [create_time]
GO


