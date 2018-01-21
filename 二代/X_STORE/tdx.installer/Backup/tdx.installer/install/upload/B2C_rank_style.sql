
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_rank_style_is_def]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_rank_style] DROP CONSTRAINT [DF_B2C_rank_style_is_def]
END

GO



/****** Object:  Table [dbo].[B2C_rank_style]    Script Date: 11/17/2014 19:43:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_rank_style]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_rank_style]
GO



/****** Object:  Table [dbo].[B2C_rank_style]    Script Date: 11/17/2014 19:43:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_rank_style](
	[id] [int] NOT NULL,
	[rankid] [int] NOT NULL,
	[logo_url] [varchar](255) NULL,
	[name_color] [varchar](255) NOT NULL,
	[rank_color] [varchar](255) NOT NULL,
	[number_color] [varchar](255) NOT NULL,
	[card_bak] [varchar](255) NOT NULL,
	[is_def] [int] NOT NULL,
 CONSTRAINT [PK_B2C_rank_style] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_rank_style] ADD  CONSTRAINT [DF_B2C_rank_style_is_def]  DEFAULT ((0)) FOR [is_def]
GO


