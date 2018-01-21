

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_logs_regtime2]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_logs] DROP CONSTRAINT [DF_wx_logs_regtime2]
END

GO



/****** Object:  Table [dbo].[B2C_logs]    Script Date: 11/17/2014 19:37:18 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_logs]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_logs]
GO



/****** Object:  Table [dbo].[B2C_logs]    Script Date: 11/17/2014 19:37:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[B2C_logs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regtime] [datetime] NOT NULL,
	[Lmsg] [nvarchar](max) NULL,
	[Luname] [nvarchar](50) NULL,
	[Lip] [nvarchar](50) NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[B2C_logs] ADD  CONSTRAINT [DF_wx_logs_regtime2]  DEFAULT (getdate()) FOR [regtime]
GO


