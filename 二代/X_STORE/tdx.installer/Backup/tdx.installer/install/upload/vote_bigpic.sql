

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_vote_bigpic_regTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[vote_bigpic] DROP CONSTRAINT [DF_vote_bigpic_regTime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_vote_bigpic_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[vote_bigpic] DROP CONSTRAINT [DF_vote_bigpic_isactive]
END

GO



/****** Object:  Table [dbo].[vote_bigpic]    Script Date: 11/17/2014 19:59:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vote_bigpic]') AND type in (N'U'))
DROP TABLE [dbo].[vote_bigpic]
GO


/****** Object:  Table [dbo].[vote_bigpic]    Script Date: 11/17/2014 19:59:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[vote_bigpic](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[picurl] [nvarchar](255) NOT NULL,
	[regTime] [datetime] NOT NULL,
	[isactive] [real] NOT NULL,
 CONSTRAINT [PK_vote_bigpic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认为0未启用，1为启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'vote_bigpic', @level2type=N'COLUMN',@level2name=N'isactive'
GO

ALTER TABLE [dbo].[vote_bigpic] ADD  CONSTRAINT [DF_vote_bigpic_regTime]  DEFAULT (getdate()) FOR [regTime]
GO

ALTER TABLE [dbo].[vote_bigpic] ADD  CONSTRAINT [DF_vote_bigpic_isactive]  DEFAULT ((0)) FOR [isactive]
GO


