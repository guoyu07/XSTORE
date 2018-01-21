

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BJ_value_obj_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[BJ_value] DROP CONSTRAINT [DF_BJ_value_obj_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BJ_value_pro_id]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[BJ_value] DROP CONSTRAINT [DF_BJ_value_pro_id]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BJ_value_price]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[BJ_value] DROP CONSTRAINT [DF_BJ_value_price]
END

GO


/****** Object:  Table [dbo].[BJ_value]    Script Date: 11/17/2014 19:50:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BJ_value]') AND type in (N'U'))
DROP TABLE [dbo].[BJ_value]
GO



/****** Object:  Table [dbo].[BJ_value]    Script Date: 11/17/2014 19:50:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BJ_value](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[obj_id] [int] NOT NULL,
	[pro_id] [int] NOT NULL,
	[price] [money] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BJ_value] ADD  CONSTRAINT [DF_BJ_value_obj_id]  DEFAULT ((0)) FOR [obj_id]
GO

ALTER TABLE [dbo].[BJ_value] ADD  CONSTRAINT [DF_BJ_value_pro_id]  DEFAULT ((0)) FOR [pro_id]
GO

ALTER TABLE [dbo].[BJ_value] ADD  CONSTRAINT [DF_BJ_value_price]  DEFAULT ((0)) FOR [price]
GO


