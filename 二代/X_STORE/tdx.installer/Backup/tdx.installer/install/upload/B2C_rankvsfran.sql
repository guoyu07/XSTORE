

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_rankvsfran_create_time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_rankvsfran] DROP CONSTRAINT [DF_B2C_rankvsfran_create_time]
END

GO



/****** Object:  Table [dbo].[B2C_rankvsfran]    Script Date: 11/17/2014 19:44:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_rankvsfran]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_rankvsfran]
GO



/****** Object:  Table [dbo].[B2C_rankvsfran]    Script Date: 11/17/2014 19:44:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[B2C_rankvsfran](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[create_time] [datetime] NOT NULL,
	[franid] [int] NOT NULL,
	[rankid] [int] NOT NULL,
 CONSTRAINT [PK_B2C_rankvsfran] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[B2C_rankvsfran] ADD  CONSTRAINT [DF_B2C_rankvsfran_create_time]  DEFAULT (getdate()) FOR [create_time]
GO


