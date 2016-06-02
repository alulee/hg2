
/* DataSource :

select 'INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) ' + CHAR(13) + 
		'VALUES (1, ''' + Descr +  ''', 1, 100)'  + CHAR(13)  
from CodeLkup
where ListID = 'City'

*/

-- Truncate Table [StateProvince]
 
-- 新增 省/州 : TW
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'基隆市', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'台北市', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'新北市', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'桃園縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'新竹市', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'新竹縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'苗栗縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'台中市', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'彰化縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'南投縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'雲林縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'嘉義市', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'嘉義縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'台南市', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'高雄市', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'屏東縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'台東縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'花蓮縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'宜蘭縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'澎湖縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'金門縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'連江縣', 1, 1, 100)
INSERT INTO [dbo].[StateProvince] ([CountryId],[Name],[LanguageId],[Published],[DisplayOrder]) VALUES (1, N'南海', 1, 1, 100)