SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('Country') IS NOT NULL
BEGIN
	PRINT '<<<DROP TABLE Country>>>'
	DROP TABLE Country
END
GO
CREATE TABLE [dbo].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LanguageID] Int Not Null Default 0,
	[TwoLetterIsoCode] [nvarchar](2) NULL,
	[ThreeLetterIsoCode] [nvarchar](3) NULL,	
	[NumericIsoCode] [int] NOT NULL,
	[Published] [bit] NOT NULL,
	[DisplayOrder] [int] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


