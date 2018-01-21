
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_order_pay_pid]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_order_pay] DROP CONSTRAINT [DF_B2C_order_pay_pid]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_order_pay_p_amt]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_order_pay] DROP CONSTRAINT [DF_B2C_order_pay_p_amt]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_B2C_order_pay_regtime]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[B2C_order_pay] DROP CONSTRAINT [DF_B2C_order_pay_regtime]
END

GO



/****** Object:  Table [dbo].[B2C_order_pay]    Script Date: 11/17/2014 19:41:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[B2C_order_pay]') AND type in (N'U'))
DROP TABLE [dbo].[B2C_order_pay]
GO


/****** Object:  Table [dbo].[B2C_order_pay]    Script Date: 11/17/2014 19:41:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[B2C_order_pay](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ono] [nvarchar](50) NULL,
	[pid] [int] NOT NULL,
	[p_amt] [money] NOT NULL,
	[p_des] [nvarchar](255) NULL,
	[regtime] [datetime] NOT NULL,
 CONSTRAINT [PK_B2C_order_pay] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[B2C_order_pay] ADD  CONSTRAINT [DF_B2C_order_pay_pid]  DEFAULT ((0)) FOR [pid]
GO

ALTER TABLE [dbo].[B2C_order_pay] ADD  CONSTRAINT [DF_B2C_order_pay_p_amt]  DEFAULT ((0)) FOR [p_amt]
GO

ALTER TABLE [dbo].[B2C_order_pay] ADD  CONSTRAINT [DF_B2C_order_pay_regtime]  DEFAULT (getdate()) FOR [regtime]
GO


