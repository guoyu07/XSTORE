

/****** Object:  Table [dbo].[B2C_PeopleInfo]    Script Date: 11/17/2014 19:43:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_PeopleInfo]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_PeopleInfo]
GO


/****** Object:  Table [dbo].[B2C_PeopleInfo]    Script Date: 11/17/2014 19:43:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_PeopleInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wwv] [varchar](255) NULL,
	[nicheng] [varchar](255) NULL,
	[fakeID] [varchar](255) NULL,
	[weiName] [varchar](255) NULL,
	[xingbie] [varchar](255) NULL,
	[shengfen] [varchar](255) NULL,
	[chengshi] [varchar](255) NULL,
	[touxiang] [varchar](255) NULL,
	[guanzhutime] [varchar](255) NULL,
	[yuyan] [varchar](255) NULL,
	[memb_id] [int] NOT NULL,
 CONSTRAINT [PK_B2C_PeopleInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'wwv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'nicheng'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'fake' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'fakeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'weiName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'xingbie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'shengfen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'chengshi'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'touxiang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关注时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'guanzhutime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'语言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'B2C_PeopleInfo', @level2type=N'COLUMN',@level2name=N'yuyan'
GO


