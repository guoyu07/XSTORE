

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_obj_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_obj] DROP CONSTRAINT [DF_control_obj_wid]
END

GO



/****** Object:  Table [dbo].[control_obj]    Script Date: 11/17/2014 19:53:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[control_obj]') AND type in (N'U'))
DROP TABLE [dbo].[control_obj]
GO



/****** Object:  Table [dbo].[control_obj]    Script Date: 11/17/2014 19:53:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[control_obj](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[wid] [int] NOT NULL,
	[des] [varchar](255) NULL,
	[urls] [nvarchar](300) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[control_obj] ADD  CONSTRAINT [DF_control_obj_wid]  DEFAULT ((0)) FOR [wid]
GO


