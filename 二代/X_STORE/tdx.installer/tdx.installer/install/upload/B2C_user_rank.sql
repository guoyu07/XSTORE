

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_user_rank_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_user_rank] DROP CONSTRAINT [DF_B2C_user_rank_create_time]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_user_rank_last_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_user_rank] DROP CONSTRAINT [DF_B2C_user_rank_last_time]
END

GO



/****** Object:  Table [dbo].[B2C_user_rank]    Script Date: 11/17/2014 19:48:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_user_rank]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_user_rank]
GO



/****** Object:  Table [dbo].[B2C_user_rank]    Script Date: 11/17/2014 19:48:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_user_rank](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NOT NULL,
	[rankid] [int] NOT NULL,
	[create_time] [datetime] NOT NULL,
	[last_time] [datetime] NOT NULL,
	[card_number] [varchar](255) NOT NULL,
 CONSTRAINT [PK_B2C_user_rank] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_user_rank] ADD  CONSTRAINT [DF_B2C_user_rank_create_time]  DEFAULT (getdate()) FOR [create_time]
GO

ALTER TABLE [dbo].[B2C_user_rank] ADD  CONSTRAINT [DF_B2C_user_rank_last_time]  DEFAULT (getdate()) FOR [last_time]
GO


