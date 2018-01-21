

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ex_message_datetime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ex_message] DROP CONSTRAINT [DF_ex_message_datetime]
END

GO



/****** Object:  Table [dbo].[ex_message]    Script Date: 11/17/2014 19:56:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ex_message]') AND type in (N'U'))
DROP TABLE [dbo].[ex_message]
GO



/****** Object:  Table [dbo].[ex_message]    Script Date: 11/17/2014 19:56:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ex_message](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[message] [ntext] NULL,
	[track] [ntext] NULL,
	[wid] [varchar](255) NULL,
	[className] [varchar](255) NULL,
	[currentdate] [datetime] NULL,
 CONSTRAINT [PK_ex_message] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ex_message] ADD  CONSTRAINT [DF_ex_message_datetime]  DEFAULT (getdate()) FOR [currentdate]
GO


