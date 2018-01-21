

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_C2C_TranslateZh_create_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[C2C_TranslateZh] DROP CONSTRAINT [DF_C2C_TranslateZh_create_date]
END

GO


/****** Object:  Table [dbo].[C2C_TranslateZh]    Script Date: 11/17/2014 19:51:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[C2C_TranslateZh]') AND type in (N'U'))
DROP TABLE [dbo].[C2C_TranslateZh]
GO



/****** Object:  Table [dbo].[C2C_TranslateZh]    Script Date: 11/17/2014 19:51:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[C2C_TranslateZh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kw] [varchar](255) NULL,
	[app_user] [varchar](255) NULL,
	[app_father] [varchar](255) NULL,
	[create_date] [datetime] NOT NULL,
 CONSTRAINT [PK_C2C_TranslateZh] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_TranslateZh', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关键字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_TranslateZh', @level2type=N'COLUMN',@level2name=N'kw'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_TranslateZh', @level2type=N'COLUMN',@level2name=N'app_user'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属商家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_TranslateZh', @level2type=N'COLUMN',@level2name=N'app_father'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'C2C_TranslateZh', @level2type=N'COLUMN',@level2name=N'create_date'
GO

ALTER TABLE [dbo].[C2C_TranslateZh] ADD  CONSTRAINT [DF_C2C_TranslateZh_create_date]  DEFAULT (getdate()) FOR [create_date]
GO


