

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_test_lid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_test] DROP CONSTRAINT [DF_wx_acm_test_lid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_test_hid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_test] DROP CONSTRAINT [DF_wx_acm_test_hid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_test_whid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_test] DROP CONSTRAINT [DF_wx_acm_test_whid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_wx_acm_test_regdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[wx_acm_test] DROP CONSTRAINT [DF_wx_acm_test_regdate]
END

GO



/****** Object:  Table [dbo].[wx_acm_test]    Script Date: 11/17/2014 20:02:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[wx_acm_test]') AND type in (N'U'))
DROP TABLE [dbo].[wx_acm_test]
GO



/****** Object:  Table [dbo].[wx_acm_test]    Script Date: 11/17/2014 20:02:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[wx_acm_test](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lid] [tinyint] NOT NULL,
	[hid] [nvarchar](50) NOT NULL,
	[whid] [nvarchar](50) NOT NULL,
	[t_title] [nvarchar](500) NULL,
	[t_answer] [nvarchar](50) NULL,
	[t_cont] [nvarchar](200) NULL,
	[regdate] [datetime] NOT NULL,
 CONSTRAINT [PK_wx_acm_test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[wx_acm_test] ADD  CONSTRAINT [DF_wx_acm_test_lid]  DEFAULT ((0)) FOR [lid]
GO

ALTER TABLE [dbo].[wx_acm_test] ADD  CONSTRAINT [DF_wx_acm_test_hid]  DEFAULT ((0)) FOR [hid]
GO

ALTER TABLE [dbo].[wx_acm_test] ADD  CONSTRAINT [DF_wx_acm_test_whid]  DEFAULT ((0)) FOR [whid]
GO

ALTER TABLE [dbo].[wx_acm_test] ADD  CONSTRAINT [DF_wx_acm_test_regdate]  DEFAULT (getdate()) FOR [regdate]
GO


