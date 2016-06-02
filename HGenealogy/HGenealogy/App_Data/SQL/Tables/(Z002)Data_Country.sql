
-- 新增國家清單
Truncate Table Country
GO
Insert Into Country (Name, LanguageId, TwoLetterIsoCode, ThreeLetterIsoCode, NumericIsoCode, Published, DisplayOrder)
VALUES( N'台灣', 1, 'TW', 'TWN', 158, 1, 1)

Insert Into Country (Name, LanguageId, TwoLetterIsoCode, ThreeLetterIsoCode, NumericIsoCode, Published, DisplayOrder)
VALUES( N'中國', 2, 'CN', 'CHN', 156, 1, 2)
	