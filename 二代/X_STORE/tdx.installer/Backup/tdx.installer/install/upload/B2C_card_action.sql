

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_card_action_is_long]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_card_action] DROP CONSTRAINT [DF_B2C_card_action_is_long]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_card_action_star_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_card_action] DROP CONSTRAINT [DF_B2C_card_action_star_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_card_action_end_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_card_action] DROP CONSTRAINT [DF_B2C_card_action_end_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_card_action_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_card_action] DROP CONSTRAINT [DF_B2C_card_action_create_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_card_action_cardid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_card_action] DROP CONSTRAINT [DF_B2C_card_action_cardid]
END

GO



/****** Object:  Table [dbo].[B2C_card_action]    Script Date: 11/17/2014 19:33:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_card_action]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_card_action]
GO


/****** Object:  Table [dbo].[B2C_card_action]    Script Date: 11/17/2014 19:33:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_card_action](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[is_long] [int] NOT NULL,
	[star_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
	[des] [varchar](255) NOT NULL,
	[create_time] [datetime] NOT NULL,
	[cardid] [int] NOT NULL,
 CONSTRAINT [PK_B2C_card_action] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_card_action] ADD  CONSTRAINT [DF_B2C_card_action_is_long]  DEFAULT ((1)) FOR [is_long]
GO

ALTER TABLE [dbo].[B2C_card_action] ADD  CONSTRAINT [DF_B2C_card_action_star_time]  DEFAULT (getdate()) FOR [star_time]
GO

ALTER TABLE [dbo].[B2C_card_action] ADD  CONSTRAINT [DF_B2C_card_action_end_time]  DEFAULT (getdate()) FOR [end_time]
GO

ALTER TABLE [dbo].[B2C_card_action] ADD  CONSTRAINT [DF_B2C_card_action_create_time]  DEFAULT (getdate()) FOR [create_time]
GO

ALTER TABLE [dbo].[B2C_card_action] ADD  CONSTRAINT [DF_B2C_card_action_cardid]  DEFAULT ((1)) FOR [cardid]
GO


