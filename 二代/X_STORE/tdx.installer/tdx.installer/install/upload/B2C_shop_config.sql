

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_shop_config_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_shop_config] DROP CONSTRAINT [DF_B2C_shop_config_wid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_shop_config_sc_isCategory]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_shop_config] DROP CONSTRAINT [DF_B2C_shop_config_sc_isCategory]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_shop_config_Sc_isBrand]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_shop_config] DROP CONSTRAINT [DF_B2C_shop_config_Sc_isBrand]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_shop_config_Sc_isHot]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_shop_config] DROP CONSTRAINT [DF_B2C_shop_config_Sc_isHot]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_shop_config_Sc_isNew]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_shop_config] DROP CONSTRAINT [DF_B2C_shop_config_Sc_isNew]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_shop_config_Sc_isSpecial]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_shop_config] DROP CONSTRAINT [DF_B2C_shop_config_Sc_isSpecial]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_shop_config_Sc_isMsg]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_shop_config] DROP CONSTRAINT [DF_B2C_shop_config_Sc_isMsg]
END

GO



/****** Object:  Table [dbo].[B2C_shop_config]    Script Date: 11/17/2014 19:46:11 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_shop_config]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_shop_config]
GO


/****** Object:  Table [dbo].[B2C_shop_config]    Script Date: 11/17/2014 19:46:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_shop_config](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wid] [int] NOT NULL,
	[sc_isCategory] [tinyint] NOT NULL,
	[Sc_isBrand] [tinyint] NOT NULL,
	[Sc_isHot] [tinyint] NOT NULL,
	[Sc_isNew] [tinyint] NOT NULL,
	[Sc_isSpecial] [tinyint] NOT NULL,
	[Sc_isMsg] [tinyint] NOT NULL,
	[Sc_wx_appId] [varchar](50) NULL,
	[Sc_wx_appSecret] [varchar](50) NULL,
	[Sc_wx_appSignKey] [varchar](50) NULL,
	[Sc_wx_partnerId] [varchar](50) NULL,
	[Sc_wx_partnerKey] [varchar](50) NULL,
	[Sc_yl_securityKey] [varchar](50) NULL,
	[Sc_yl_merId] [varchar](50) NULL,
	[Sc_yl_merAbbr] [varchar](50) NULL,
	[Sc_yl_acqCode] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'wid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'sc_isCategory'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示品牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_isBrand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示热卖商品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_isHot'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示新品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_isNew'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示推荐商品' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_isSpecial'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示新闻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_isMsg'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_wx_appId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_wx_appSecret'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_wx_appSignKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_wx_partnerId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_wx_partnerKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银联支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_yl_securityKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银联支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_yl_merId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银联支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_yl_merAbbr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银联支付字符串' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_shop_config', @level2type=N'COLUMN',@level2name=N'Sc_yl_acqCode'
GO

ALTER TABLE [dbo].[B2C_shop_config] ADD  CONSTRAINT [DF_B2C_shop_config_wid]  DEFAULT ((0)) FOR [wid]
GO

ALTER TABLE [dbo].[B2C_shop_config] ADD  CONSTRAINT [DF_B2C_shop_config_sc_isCategory]  DEFAULT ((0)) FOR [sc_isCategory]
GO

ALTER TABLE [dbo].[B2C_shop_config] ADD  CONSTRAINT [DF_B2C_shop_config_Sc_isBrand]  DEFAULT ((0)) FOR [Sc_isBrand]
GO

ALTER TABLE [dbo].[B2C_shop_config] ADD  CONSTRAINT [DF_B2C_shop_config_Sc_isHot]  DEFAULT ((0)) FOR [Sc_isHot]
GO

ALTER TABLE [dbo].[B2C_shop_config] ADD  CONSTRAINT [DF_B2C_shop_config_Sc_isNew]  DEFAULT ((1)) FOR [Sc_isNew]
GO

ALTER TABLE [dbo].[B2C_shop_config] ADD  CONSTRAINT [DF_B2C_shop_config_Sc_isSpecial]  DEFAULT ((1)) FOR [Sc_isSpecial]
GO

ALTER TABLE [dbo].[B2C_shop_config] ADD  CONSTRAINT [DF_B2C_shop_config_Sc_isMsg]  DEFAULT ((1)) FOR [Sc_isMsg]
GO


