

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BJ_obj_wid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[BJ_obj] DROP CONSTRAINT [DF_BJ_obj_wid]
END

GO



/****** Object:  Table [dbo].[BJ_obj]    Script Date: 11/17/2014 19:50:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BJ_obj]') AND type in (N'U'))
DROP TABLE [dbo].[BJ_obj]
GO


/****** Object:  Table [dbo].[BJ_obj]    Script Date: 11/17/2014 19:50:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BJ_obj](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wid] [int] NOT NULL,
	[name] [varchar](255) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BJ_obj] ADD  CONSTRAINT [DF_BJ_obj_wid]  DEFAULT ((0)) FOR [wid]
GO


