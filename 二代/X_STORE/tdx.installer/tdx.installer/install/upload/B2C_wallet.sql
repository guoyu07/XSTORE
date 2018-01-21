

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_payorcost]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_payorcost]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_wid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_is_add]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_is_add]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_create_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_category]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_category]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_rankid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_rankid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_star_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_star_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_end_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_end_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_wallet_is_fandian]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_wallet] DROP CONSTRAINT [DF_B2C_wallet_is_fandian]
END

GO


/****** Object:  Table [dbo].[B2C_wallet]    Script Date: 11/17/2014 19:49:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_wallet]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_wallet]
GO



/****** Object:  Table [dbo].[B2C_wallet]    Script Date: 11/17/2014 19:49:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_wallet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payorcost] [int] NOT NULL,
	[wid] [int] NOT NULL,
	[amount] [money] NOT NULL,
	[give_amount] [money] NOT NULL,
	[is_add] [int] NOT NULL,
	[create_time] [datetime] NOT NULL,
	[isdel] [int] NOT NULL,
	[des] [varchar](255) NULL,
	[category] [int] NOT NULL,
	[rankid] [int] NOT NULL,
	[star_time] [datetime] NOT NULL,
	[end_time] [datetime] NOT NULL,
	[is_fandian] [int] NULL,
 CONSTRAINT [PK_B2C_wallet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'此字段只对钱包生效默认0不返点则赠送的费用就是钱，如果为1返点就为百分比' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_wallet', @level2type=N'COLUMN',@level2name=N'is_fandian'
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_payorcost]  DEFAULT ((1)) FOR [payorcost]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_wid]  DEFAULT ((0)) FOR [wid]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_is_add]  DEFAULT ((0)) FOR [is_add]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_create_time]  DEFAULT (getdate()) FOR [create_time]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_isdel]  DEFAULT ((0)) FOR [isdel]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_category]  DEFAULT ((1)) FOR [category]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_rankid]  DEFAULT ((1)) FOR [rankid]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_star_time]  DEFAULT (getdate()) FOR [star_time]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_end_time]  DEFAULT (getdate()) FOR [end_time]
GO

ALTER TABLE [dbo].[B2C_wallet] ADD  CONSTRAINT [DF_B2C_wallet_is_fandian]  DEFAULT ((0)) FOR [is_fandian]
GO


