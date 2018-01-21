

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_log_ol_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_log] DROP CONSTRAINT [DF_ms_order_log_ol_date]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ms_order_log_aid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ms_order_log] DROP CONSTRAINT [DF_ms_order_log_aid]
END

GO



/****** Object:  Table [dbo].[ms_order_log]    Script Date: 11/17/2014 19:57:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ms_order_log]') AND type in (N'U'))
DROP TABLE [dbo].[ms_order_log]
GO



/****** Object:  Table [dbo].[ms_order_log]    Script Date: 11/17/2014 19:57:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ms_order_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ono] [varchar](255) NULL,
	[ol_name] [varchar](50) NULL,
	[ol_date] [datetime] NOT NULL,
	[ol_des] [varchar](255) NULL,
	[aid] [int] NOT NULL,
 CONSTRAINT [PK_ms_order_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ms_order_log] ADD  CONSTRAINT [DF_ms_order_log_ol_date]  DEFAULT (getdate()) FOR [ol_date]
GO

ALTER TABLE [dbo].[ms_order_log] ADD  CONSTRAINT [DF_ms_order_log_aid]  DEFAULT ((0)) FOR [aid]
GO


