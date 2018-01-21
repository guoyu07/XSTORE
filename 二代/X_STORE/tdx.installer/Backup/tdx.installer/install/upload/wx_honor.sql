

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_honor_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_honor] DROP CONSTRAINT [DF_wx_honor_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_honor_isHonor]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_honor] DROP CONSTRAINT [DF_wx_honor_isHonor]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_honor_cityID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_honor] DROP CONSTRAINT [DF_wx_honor_cityID]
END

GO


/****** Object:  Table [dbo].[wx_honor]    Script Date: 11/17/2014 20:04:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_honor]') AND type in (N'U'))
DROP TABLE [dbo].[wx_honor]
GO



/****** Object:  Table [dbo].[wx_honor]    Script Date: 11/17/2014 20:04:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_honor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regtime] [datetime] NOT NULL,
	[FromUser] [nvarchar](50) NULL,
	[resultNum] [nvarchar](50) NULL,
	[isHonor] [tinyint] NOT NULL,
	[cityID] [int] NOT NULL,
 CONSTRAINT [PK_wx_honor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_honor] ADD  CONSTRAINT [DF_wx_honor_regtime]  DEFAULT (getdate()) FOR [regtime]
GO

ALTER TABLE [dbo].[wx_honor] ADD  CONSTRAINT [DF_wx_honor_isHonor]  DEFAULT ((0)) FOR [isHonor]
GO

ALTER TABLE [dbo].[wx_honor] ADD  CONSTRAINT [DF_wx_honor_cityID]  DEFAULT ((0)) FOR [cityID]
GO


