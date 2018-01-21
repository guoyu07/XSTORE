

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_Account_mid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_Account] DROP CONSTRAINT [DF_C2C_Account_mid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_Account_ptid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_Account] DROP CONSTRAINT [DF_C2C_Account_ptid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_Account_ac_money]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_Account] DROP CONSTRAINT [DF_C2C_Account_ac_money]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_Account_ac_Amt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_Account] DROP CONSTRAINT [DF_C2C_Account_ac_Amt]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_Account_ac_update]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_Account] DROP CONSTRAINT [DF_C2C_Account_ac_update]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_Account_ac_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_Account] DROP CONSTRAINT [DF_C2C_Account_ac_regdate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_Account_cityID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_Account] DROP CONSTRAINT [DF_C2C_Account_cityID]
END

GO



/****** Object:  Table [dbo].[C2C_Account]    Script Date: 11/17/2014 19:50:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[C2C_Account]') AND type in (N'U'))
DROP TABLE [dbo].[C2C_Account]
GO



/****** Object:  Table [dbo].[C2C_Account]    Script Date: 11/17/2014 19:50:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[C2C_Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wid] [int] NOT NULL,
	[ptid] [int] NOT NULL,
	[cno] [varchar](50) NULL,
	[orderNo] [varchar](50) NULL,
	[ac_money] [money] NOT NULL,
	[ac_Amt] [money] NOT NULL,
	[ac_update] [datetime] NOT NULL,
	[ac_regdate] [datetime] NOT NULL,
	[ac_des] [varchar](255) NULL,
	[uid] [int] NOT NULL,
 CONSTRAINT [PK_C2C_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[C2C_Account] ADD  CONSTRAINT [DF_C2C_Account_mid]  DEFAULT ((0)) FOR [wid]
GO

ALTER TABLE [dbo].[C2C_Account] ADD  CONSTRAINT [DF_C2C_Account_ptid]  DEFAULT ((0)) FOR [ptid]
GO

ALTER TABLE [dbo].[C2C_Account] ADD  CONSTRAINT [DF_C2C_Account_ac_money]  DEFAULT ((0)) FOR [ac_money]
GO

ALTER TABLE [dbo].[C2C_Account] ADD  CONSTRAINT [DF_C2C_Account_ac_Amt]  DEFAULT ((0)) FOR [ac_Amt]
GO

ALTER TABLE [dbo].[C2C_Account] ADD  CONSTRAINT [DF_C2C_Account_ac_update]  DEFAULT (getdate()) FOR [ac_update]
GO

ALTER TABLE [dbo].[C2C_Account] ADD  CONSTRAINT [DF_C2C_Account_ac_regdate]  DEFAULT (getdate()) FOR [ac_regdate]
GO

ALTER TABLE [dbo].[C2C_Account] ADD  CONSTRAINT [DF_C2C_Account_cityID]  DEFAULT ((0)) FOR [uid]
GO


