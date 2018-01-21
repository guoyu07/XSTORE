

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_control_dict_is_txt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[control_dict] DROP CONSTRAINT [DF_control_dict_is_txt]
END

GO



/****** Object:  Table [dbo].[control_dict]    Script Date: 11/17/2014 19:53:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[control_dict]') AND type in (N'U'))
DROP TABLE [dbo].[control_dict]
GO



/****** Object:  Table [dbo].[control_dict]    Script Date: 11/17/2014 19:53:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[control_dict](
	[id] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[is_txt] [int] NOT NULL,
	[des] [varchar](255) NULL,
 CONSTRAINT [PK_control_dict] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[control_dict] ADD  CONSTRAINT [DF_control_dict_is_txt]  DEFAULT ((1)) FOR [is_txt]
GO


