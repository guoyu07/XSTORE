

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_vote_Album_Album_regTime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[vote_Album] DROP CONSTRAINT [DF_vote_Album_Album_regTime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_vote_Album_c_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[vote_Album] DROP CONSTRAINT [DF_vote_Album_c_id]
END

GO



/****** Object:  Table [dbo].[vote_Album]    Script Date: 11/17/2014 19:59:40 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vote_Album]') AND type in (N'U'))
DROP TABLE [dbo].[vote_Album]
GO



/****** Object:  Table [dbo].[vote_Album]    Script Date: 11/17/2014 19:59:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[vote_Album](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Album_name] [nvarchar](255) NOT NULL,
	[Album_pic] [nvarchar](255) NULL,
	[Album_desc] [nvarchar](max) NULL,
	[Album_regTime] [datetime] NOT NULL,
	[c_id] [int] NOT NULL,
	[bigpic_id] [int] NOT NULL,
 CONSTRAINT [PK_vote_Album] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相册名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'vote_Album', @level2type=N'COLUMN',@level2name=N'Album_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片类别id，关联B2C_Hclass表c_id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'vote_Album', @level2type=N'COLUMN',@level2name=N'c_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联表vote_bigpic表id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'vote_Album', @level2type=N'COLUMN',@level2name=N'bigpic_id'
GO

ALTER TABLE [dbo].[vote_Album] ADD  CONSTRAINT [DF_vote_Album_Album_regTime]  DEFAULT (getdate()) FOR [Album_regTime]
GO

ALTER TABLE [dbo].[vote_Album] ADD  CONSTRAINT [DF_vote_Album_c_id]  DEFAULT ((0)) FOR [c_id]
GO


