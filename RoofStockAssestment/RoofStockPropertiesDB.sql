USE [Properties]
GO
/****** Object:  Table [dbo].[Properties]    Script Date: 2/24/2021 12:15:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Properties](
	[Id] [int] NOT NULL,
	[YearBuilt] [nvarchar](4) NOT NULL,
	[ListPrice] [decimal](10, 2) NOT NULL,
	[MonthlyRent] [decimal](10, 2) NOT NULL,
	[GrossYield] [decimal](10, 2) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
