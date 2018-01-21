

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_note_mid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_note] DROP CONSTRAINT [DF_B2C_note_mid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_note_n_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_note] DROP CONSTRAINT [DF_B2C_note_n_isactive]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_note_n_isdel]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_note] DROP CONSTRAINT [DF_B2C_note_n_isdel]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_note_n_isR]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_note] DROP CONSTRAINT [DF_B2C_note_n_isR]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_note_n_rDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_note] DROP CONSTRAINT [DF_B2C_note_n_rDate]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_note_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_note] DROP CONSTRAINT [DF_B2C_note_regdate]
END

GO



/****** Object:  Table [dbo].[B2C_note]    Script Date: 11/17/2014 19:40:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_note]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_note]
GO



/****** Object:  Table [dbo].[B2C_note]    Script Date: 11/17/2014 19:40:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_note](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[n_tab] [varchar](50) NOT NULL,
	[n_row] [varchar](50) NOT NULL,
	[mid] [int] NOT NULL,
	[n_title] [varchar](255) NULL,
	[n_msg] [varchar](255) NULL,
	[n_link] [varchar](255) NULL,
	[n_ip] [varchar](50) NULL,
	[n_isactive] [int] NOT NULL,
	[n_isdel] [int] NOT NULL,
	[n_isR] [int] NOT NULL,
	[n_reply] [varchar](255) NULL,
	[n_rDate] [datetime] NOT NULL,
	[regdate] [datetime] NOT NULL,
 CONSTRAINT [PK_B2C_note] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_note] ADD  CONSTRAINT [DF_B2C_note_mid]  DEFAULT ((0)) FOR [mid]
GO

ALTER TABLE [dbo].[B2C_note] ADD  CONSTRAINT [DF_B2C_note_n_isactive]  DEFAULT ((1)) FOR [n_isactive]
GO

ALTER TABLE [dbo].[B2C_note] ADD  CONSTRAINT [DF_B2C_note_n_isdel]  DEFAULT ((0)) FOR [n_isdel]
GO

ALTER TABLE [dbo].[B2C_note] ADD  CONSTRAINT [DF_B2C_note_n_isR]  DEFAULT ((0)) FOR [n_isR]
GO

ALTER TABLE [dbo].[B2C_note] ADD  CONSTRAINT [DF_B2C_note_n_rDate]  DEFAULT (getdate()) FOR [n_rDate]
GO

ALTER TABLE [dbo].[B2C_note] ADD  CONSTRAINT [DF_B2C_note_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


