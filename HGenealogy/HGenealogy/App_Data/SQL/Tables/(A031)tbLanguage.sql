GO

/****** Object:  Table [dbo].[Language]    Script Date: 2016/06/01 09:40:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('Language') IS NOT NULL
BEGIN
	PRINT '<<<DROP TABLE Language>>>'
	DROP TABLE Country
END
GO
CREATE TABLE [dbo].[Language](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LanguageCulture] [nvarchar](20) NOT NULL,
	[UniqueSeoCode] [nvarchar](2) NULL,
	[FlagImageFileName] [nvarchar](50) NULL,
	[Rtl] [bit] NOT NULL,
	[LimitedToStores] [bit] NOT NULL,
	[DefaultCurrencyId] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


