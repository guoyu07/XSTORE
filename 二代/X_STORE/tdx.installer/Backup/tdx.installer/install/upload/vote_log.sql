

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_vote_log_vote_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[vote_log] DROP CONSTRAINT [DF_vote_log_vote_time]
END

GO



/****** Object:  Table [dbo].[vote_log]    Script Date: 11/17/2014 20:00:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vote_log]') AND type in (N'U'))
DROP TABLE [dbo].[vote_log]
GO



/****** Object:  Table [dbo].[vote_log]    Script Date: 11/17/2014 20:00:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[vote_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Album_id] [int] NOT NULL,
	[vote_time] [datetime] NOT NULL,
	[vote_wwv] [varchar](255) NOT NULL,
	[vote_ip] [varchar](255) NULL,
	[bigpic_id] [int] NOT NULL,
 CONSTRAINT [PK_vote_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相册id，关联vote_Album表id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'vote_log', @level2type=N'COLUMN',@level2name=N'Album_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联vote_bigpic表id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'vote_log', @level2type=N'COLUMN',@level2name=N'bigpic_id'
GO

ALTER TABLE [dbo].[vote_log] ADD  CONSTRAINT [DF_vote_log_vote_time]  DEFAULT (getdate()) FOR [vote_time]
GO


