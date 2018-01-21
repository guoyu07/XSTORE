

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Sub_To_Service_sub_from]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Sub_To_Service] DROP CONSTRAINT [DF_Sub_To_Service_sub_from]
END

GO



/****** Object:  Table [dbo].[Sub_To_Service]    Script Date: 11/17/2014 19:58:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sub_To_Service]') AND type in (N'U'))
DROP TABLE [dbo].[Sub_To_Service]
GO



/****** Object:  Table [dbo].[Sub_To_Service]    Script Date: 11/17/2014 19:58:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sub_To_Service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sub_company] [nvarchar](100) NULL,
	[sub_name] [nvarchar](50) NULL,
	[sub_mobile] [nvarchar](50) NULL,
	[sub_email] [nvarchar](50) NULL,
	[sub_zhiwu] [nvarchar](50) NULL,
	[sub_time] [datetime] NULL,
	[sub_ip] [nvarchar](50) NULL,
	[wid] [int] NOT NULL,
	[sub_type] [int] NOT NULL,
	[sub_from] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Sub_To_Service] ADD  CONSTRAINT [DF_Sub_To_Service_sub_from]  DEFAULT ((1)) FOR [sub_from]
GO


