

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_user_u_vip]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_user] DROP CONSTRAINT [DF_B2C_user_u_vip]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_user_u_logontime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_user] DROP CONSTRAINT [DF_B2C_user_u_logontime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_user_u_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_user] DROP CONSTRAINT [DF_B2C_user_u_regtime]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_user_u_hits]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_user] DROP CONSTRAINT [DF_B2C_user_u_hits]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_user_u_isactive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_user] DROP CONSTRAINT [DF_B2C_user_u_isactive]
END

GO



/****** Object:  Table [dbo].[B2C_user]    Script Date: 11/17/2014 19:48:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_user]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_user]
GO



/****** Object:  Table [dbo].[B2C_user]    Script Date: 11/17/2014 19:48:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[B2C_user](
	[u_id] [int] IDENTITY(1,1) NOT NULL,
	[u_vip] [int] NOT NULL,
	[u_name] [varchar](50) NOT NULL,
	[u_psw] [varchar](50) NOT NULL,
	[u_mail] [varchar](255) NULL,
	[u_question] [varchar](255) NULL,
	[u_answer] [varchar](255) NULL,
	[u_rights] [varchar](100) NULL,
	[u_area_rights] [varchar](100) NULL,
	[u_logontime] [datetime] NOT NULL,
	[u_regtime] [datetime] NOT NULL,
	[u_hits] [int] NOT NULL,
	[u_isactive] [int] NOT NULL,
	[u_remarks] [varchar](255) NULL,
 CONSTRAINT [PK_B2C_user] PRIMARY KEY CLUSTERED 
(
	[u_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[B2C_user] ADD  CONSTRAINT [DF_B2C_user_u_vip]  DEFAULT ((0)) FOR [u_vip]
GO

ALTER TABLE [dbo].[B2C_user] ADD  CONSTRAINT [DF_B2C_user_u_logontime]  DEFAULT (getdate()) FOR [u_logontime]
GO

ALTER TABLE [dbo].[B2C_user] ADD  CONSTRAINT [DF_B2C_user_u_regtime]  DEFAULT (getdate()) FOR [u_regtime]
GO

ALTER TABLE [dbo].[B2C_user] ADD  CONSTRAINT [DF_B2C_user_u_hits]  DEFAULT ((0)) FOR [u_hits]
GO

ALTER TABLE [dbo].[B2C_user] ADD  CONSTRAINT [DF_B2C_user_u_isactive]  DEFAULT ((1)) FOR [u_isactive]
GO


