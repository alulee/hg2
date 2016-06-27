
/* DataSource :


select 'INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) ' + CHAR(13) + 
		'VALUES (1,1, N''' + CodelkupCity.Descr +  ''', N''' +  CodelkupState.Descr + ''', ''' + CodelkupState.Susr3 + ''', 1, ' +  CodelkupState.Susr3 + ')'  + CHAR(13)  
from CodeLkup CodelkupCity join Codelkup CodelkupState ON   CodelkupCity.Code = CodelkupState.Susr2
where CodelkupCity.listid = 'City' AND CodelkupState.listid = 'State'

 
*/

-- Truncate Table [City]
 
-- 新增 城市 清單
INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市中正區', '100', 1, 100)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市大同區', '103', 1, 103)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市中山區', '104', 1, 104)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市松山區', '105', 1, 105)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市大安區', '106', 1, 106)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市萬華區', '108', 1, 108)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市信義區', '110', 1, 110)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市士林區', '111', 1, 111)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市北投區', '112', 1, 112)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市內湖區', '114', 1, 114)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市南港區', '115', 1, 115)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市汐止區', '221', 1, 221)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣礁溪鄉', '262', 1, 262)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣造橋鄉', '361', 1, 361)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣頭屋鄉', '362', 1, 362)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣公館鄉', '363', 1, 363)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣大湖鄉', '364', 1, 364)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣泰安鄉', '365', 1, 365)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣銅鑼鄉', '366', 1, 366)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣三義鄉', '367', 1, 367)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣西湖鄉', '368', 1, 368)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣卓蘭鎮', '369', 1, 369)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市中區', '400', 1, 400)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市東區', '401', 1, 401)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市南區', '402', 1, 402)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市西區', '403', 1, 403)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市北區', '404', 1, 404)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市北屯區', '406', 1, 406)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市西屯區', '407', 1, 407)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市南屯區', '408', 1, 408)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市太平區', '411', 1, 411)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市大里區', '412', 1, 412)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市霧峰區', '413', 1, 413)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市烏日區', '414', 1, 414)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市豐原區', '420', 1, 420)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市后里區', '421', 1, 421)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台北市', N'台北市文山區', '116', 1, 116)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'基隆市', N'基隆市仁愛區', '200', 1, 200)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'基隆市', N'基隆市信義區', '201', 1, 201)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'基隆市', N'基隆市中正區', '202', 1, 202)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'基隆市', N'基隆市中山區', '203', 1, 203)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'基隆市', N'基隆市安樂區', '204', 1, 204)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'基隆市', N'基隆市暖暖區', '205', 1, 205)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'基隆市', N'基隆市七堵區', '206', 1, 206)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市萬里區', '207', 1, 207)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市金山區', '208', 1, 208)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'連江縣', N'連江縣南竿鄉', '209', 1, 209)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'連江縣', N'連江縣北竿鄉', '210', 1, 210)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'連江縣', N'連江縣莒光鄉', '211', 1, 211)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市石岡區', '422', 1, 422)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣溪州鄉', '524', 1, 524)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣水上鄉', '608', 1, 608)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣鹿草鄉', '611', 1, 611)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣太保市', '612', 1, 612)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣朴子市', '613', 1, 613)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣東石鄉', '614', 1, 614)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣六腳鄉', '615', 1, 615)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣新港鄉', '616', 1, 616)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣民雄鄉', '621', 1, 621)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣大林鎮', '622', 1, 622)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣溪口鄉', '623', 1, 623)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣義竹鄉', '624', 1, 624)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣布袋鎮', '625', 1, 625)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣斗南鎮', '630', 1, 630)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣大埤鄉', '631', 1, 631)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣虎尾鎮', '632', 1, 632)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣土庫鎮', '633', 1, 633)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣褒忠鄉', '634', 1, 634)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣東勢鄉', '635', 1, 635)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣台西鄉', '636', 1, 636)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣崙背鄉', '637', 1, 637)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣麥寮鄉', '638', 1, 638)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣斗六市', '640', 1, 640)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣林內鄉', '643', 1, 643)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣古坑鄉', '646', 1, 646)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣莿桐鄉', '647', 1, 647)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣西螺鎮', '648', 1, 648)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市東勢區', '423', 1, 423)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市和平區', '424', 1, 424)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市新社區', '426', 1, 426)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市潭子區', '427', 1, 427)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市大雅區', '428', 1, 428)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市神岡區', '429', 1, 429)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市大肚區', '432', 1, 432)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市沙鹿區', '433', 1, 433)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市龍井區', '434', 1, 434)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市梧棲區', '435', 1, 435)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市清水區', '436', 1, 436)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市大甲區', '437', 1, 437)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市外埔區', '438', 1, 438)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台中市', N'台中市大安區', '439', 1, 439)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣彰化市', '500', 1, 500)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣芬園鄉', '502', 1, 502)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣花壇鄉', '503', 1, 503)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣秀水鄉', '504', 1, 504)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣鹿港鎮', '505', 1, 505)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣福興鄉', '506', 1, 506)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣線西鄉', '507', 1, 507)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣和美鎮', '508', 1, 508)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣伸港鄉', '509', 1, 509)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣員林鎮', '510', 1, 510)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣社頭鄉', '511', 1, 511)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市七股區', '724', 1, 724)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市將軍區', '725', 1, 725)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市學甲區', '726', 1, 726)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市北門區', '727', 1, 727)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市新營區', '730', 1, 730)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市後壁區', '731', 1, 731)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市白河區', '732', 1, 732)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市東山區', '733', 1, 733)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市六甲區', '734', 1, 734)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市下營區', '735', 1, 735)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市柳營區', '736', 1, 736)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市鹽水區', '737', 1, 737)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市善化區', '741', 1, 741)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市大內區', '742', 1, 742)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市山上區', '743', 1, 743)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市新市區', '744', 1, 744)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市安定區', '745', 1, 745)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市新興區', '800', 1, 800)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市前金區', '801', 1, 801)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市苓雅區', '802', 1, 802)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市鹽埕區', '803', 1, 803)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市鼓山區', '804', 1, 804)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣埔里鎮', '545', 1, 545)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市旗津區', '805', 1, 805)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市前鎮區', '806', 1, 806)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市三民區', '807', 1, 807)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市楠梓區', '811', 1, 811)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市小港區', '812', 1, 812)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市左營區', '813', 1, 813)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市仁武區', '814', 1, 814)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市大社區', '815', 1, 815)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南海', N'南海島東沙群島', '817', 1, 817)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南海', N'南海島南沙群島', '819', 1, 819)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市岡山區', '820', 1, 820)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市路竹區', '821', 1, 821)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市阿蓮區', '822', 1, 822)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市田寮區', '823', 1, 823)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市燕巢區', '824', 1, 824)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市橋頭區', '825', 1, 825)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市梓官區', '826', 1, 826)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市彌陀區', '827', 1, 827)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市永安區', '828', 1, 828)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市湖內區', '829', 1, 829)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市鳳山區', '830', 1, 830)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市大寮區', '831', 1, 831)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市林園區', '832', 1, 832)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市鳥松區', '833', 1, 833)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市大樹區', '840', 1, 840)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市旗山區', '842', 1, 842)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市美濃區', '843', 1, 843)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市六龜區', '844', 1, 844)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市內門區', '845', 1, 845)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市杉林區', '846', 1, 846)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市甲仙區', '847', 1, 847)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市桃源區', '848', 1, 848)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市那瑪夏區', '849', 1, 849)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市茂林區', '851', 1, 851)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'高雄市', N'高雄市茄萣區', '852', 1, 852)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'澎湖縣', N'澎湖縣馬公市', '880', 1, 880)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'澎湖縣', N'澎湖縣西嶼鄉', '881', 1, 881)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'澎湖縣', N'澎湖縣望安鄉', '882', 1, 882)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'澎湖縣', N'澎湖縣七美鄉', '883', 1, 883)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'澎湖縣', N'澎湖縣白沙鄉', '884', 1, 884)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'澎湖縣', N'澎湖縣湖西鄉', '885', 1, 885)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'金門縣', N'金門縣金沙鎮', '890', 1, 890)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'金門縣', N'金門縣金湖鎮', '891', 1, 891)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'金門縣', N'金門縣金寧鄉', '892', 1, 892)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'金門縣', N'金門縣金城鎮', '893', 1, 893)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'金門縣', N'金門縣烈嶼鄉', '894', 1, 894)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'金門縣', N'金門縣烏坵鄉', '896', 1, 896)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣屏東市', '900', 1, 900)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣三地門鄉', '901', 1, 901)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣霧台鄉', '902', 1, 902)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣瑪家鄉', '903', 1, 903)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣九如鄉', '904', 1, 904)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣里港鄉', '905', 1, 905)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣高樹鄉', '906', 1, 906)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣鹽埔鄉', '907', 1, 907)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣長治鄉', '908', 1, 908)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣麟洛鄉', '909', 1, 909)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣竹田鄉', '911', 1, 911)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣內埔鄉', '912', 1, 912)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣萬丹鄉', '913', 1, 913)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣潮州鎮', '920', 1, 920)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣泰武鄉', '921', 1, 921)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣來義鄉', '922', 1, 922)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣萬巒鄉', '923', 1, 923)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣崁頂鄉', '924', 1, 924)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣新埤鄉', '925', 1, 925)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣南州鄉', '926', 1, 926)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣林邊鄉', '927', 1, 927)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣東港鎮', '928', 1, 928)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣琉球鄉', '929', 1, 929)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣佳冬鄉', '931', 1, 931)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣新園鄉', '932', 1, 932)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣枋寮鄉', '940', 1, 940)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣枋山鄉', '941', 1, 941)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣春日鄉', '942', 1, 942)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣獅子鄉', '943', 1, 943)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣車城鄉', '944', 1, 944)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣牡丹鄉', '945', 1, 945)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣恆春鎮', '946', 1, 946)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'屏東縣', N'屏東縣滿州鄉', '947', 1, 947)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣台東市', '950', 1, 950)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣綠島鄉', '951', 1, 951)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'連江縣', N'連江縣東引鄉', '212', 1, 212)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市板橋區', '220', 1, 220)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣蘭嶼鄉', '952', 1, 952)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣延平鄉', '953', 1, 953)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣卑南鄉', '954', 1, 954)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣鹿野鄉', '955', 1, 955)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣關山鎮', '956', 1, 956)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣海端鄉', '957', 1, 957)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣池上鄉', '958', 1, 958)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣東河鄉', '959', 1, 959)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣成功鎮', '961', 1, 961)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣長濱鄉', '962', 1, 962)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣太麻里鄉', '963', 1, 963)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣金峰鄉', '964', 1, 964)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣大武鄉', '965', 1, 965)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台東縣', N'台東縣達仁鄉', '966', 1, 966)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣花蓮市', '970', 1, 970)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣新城鄉', '971', 1, 971)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣秀林鄉', '972', 1, 972)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣吉安鄉', '973', 1, 973)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣壽豐鄉', '974', 1, 974)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣鳳林鎮', '975', 1, 975)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣光復鄉', '976', 1, 976)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣豐濱鄉', '977', 1, 977)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣瑞穗鄉', '978', 1, 978)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣萬榮鄉', '979', 1, 979)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣玉里鎮', '981', 1, 981)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣卓溪鄉', '982', 1, 982)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'花蓮縣', N'花蓮縣富里鄉', '983', 1, 983)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市深坑區', '222', 1, 222)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市石碇區', '223', 1, 223)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市瑞芳區', '224', 1, 224)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市平溪區', '226', 1, 226)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市雙溪區', '227', 1, 227)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市貢寮區', '228', 1, 228)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市新店區', '231', 1, 231)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市坪林區', '232', 1, 232)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市烏來區', '233', 1, 233)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市永和區', '234', 1, 234)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市中和區', '235', 1, 235)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市土城區', '236', 1, 236)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市三峽區', '237', 1, 237)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市樹林區', '238', 1, 238)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市鶯歌區', '239', 1, 239)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市三重區', '241', 1, 241)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市新莊區', '242', 1, 242)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市泰山區', '243', 1, 243)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市林口區', '244', 1, 244)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市蘆洲區', '247', 1, 247)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市五股區', '248', 1, 248)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市八里區', '249', 1, 249)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市淡水區', '251', 1, 251)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市三芝區', '252', 1, 252)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新北市', N'新北市石門區', '253', 1, 253)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣宜蘭市', '260', 1, 260)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣頭城鎮', '261', 1, 261)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣壯圍鄉', '263', 1, 263)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣員山鄉', '264', 1, 264)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣羅東鎮', '265', 1, 265)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣埔鹽鄉', '516', 1, 516)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣二水鄉', '530', 1, 530)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣三星鄉', '265', 1, 265)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣大同鄉', '267', 1, 267)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣五結鄉', '268', 1, 268)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣冬山鄉', '269', 1, 269)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣蘇澳鎮', '270', 1, 270)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'宜蘭縣', N'宜蘭縣南澳鄉', '272', 1, 272)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹市', N'新竹市東區', '300', 1, 300)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹市', N'新竹市北區', '300', 1, 300)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹市', N'新竹市香山區', '300', 1, 300)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣竹北市', '302', 1, 302)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣湖口鄉', '303', 1, 303)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣新豐鄉', '304', 1, 304)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣新埔鎮', '305', 1, 305)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣關西鎮', '306', 1, 306)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣芎林鄉', '307', 1, 307)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣田中鎮', '520', 1, 520)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣南投市', '540', 1, 540)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣信義鄉', '556', 1, 556)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣苗栗市', '360', 1, 360)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣永靖鄉', '512', 1, 512)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣埔心鄉', '513', 1, 513)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣溪湖鎮', '514', 1, 514)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣大村鄉', '515', 1, 515)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣田尾鄉', '522', 1, 522)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣埤頭鄉', '523', 1, 523)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣竹塘鄉', '525', 1, 525)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣二林鎮', '526', 1, 526)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣大城鄉', '527', 1, 527)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣芳苑鄉', '528', 1, 528)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣草屯鎮', '542', 1, 542)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣國姓鄉', '544', 1, 544)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣仁愛鄉', '546', 1, 546)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣名間鄉', '551', 1, 551)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣集集鎮', '552', 1, 552)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣水里鄉', '553', 1, 553)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣魚池鄉', '555', 1, 555)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣竹山鎮', '557', 1, 557)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣鹿谷鄉', '558', 1, 558)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義市', N'嘉義市東區', '600', 1, 600)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義市', N'嘉義市西區', '600', 1, 600)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣番路鄉', '602', 1, 602)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣梅山鄉', '603', 1, 603)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣竹崎鄉', '604', 1, 604)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣阿里山鄉', '605', 1, 605)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣中埔鄉', '606', 1, 606)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'嘉義縣', N'嘉義縣大埔鄉', '607', 1, 607)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣寶山鄉', '308', 1, 308)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣竹東鎮', '310', 1, 310)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣五峰鄉', '311', 1, 311)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣橫山鄉', '312', 1, 312)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣尖石鄉', '313', 1, 313)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣北埔鄉', '314', 1, 314)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'新竹縣', N'新竹縣峨眉鄉', '315', 1, 315)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣中壢市', '320', 1, 320)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣平鎮市', '324', 1, 324)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣龍潭鄉', '325', 1, 325)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣楊梅鎮', '326', 1, 326)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣新屋鄉', '327', 1, 327)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣觀音鄉', '328', 1, 328)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣桃園市', '330', 1, 330)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣龜山鄉', '333', 1, 333)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣八德市', '334', 1, 334)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣大溪鎮', '335', 1, 335)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣復興鄉', '336', 1, 336)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣大園鄉', '337', 1, 337)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'桃園縣', N'桃園縣蘆竹鄉', '338', 1, 338)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣竹南鎮', '350', 1, 350)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣頭份鎮', '351', 1, 351)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣三灣鄉', '352', 1, 352)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣南庄鄉', '353', 1, 353)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣獅潭鄉', '354', 1, 354)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣後龍鎮', '356', 1, 356)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣通霄鎮', '357', 1, 357)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'苗栗縣', N'苗栗縣苑裡鎮', '358', 1, 358)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'彰化縣', N'彰化縣北斗鎮', '521', 1, 521)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'南投縣', N'南投縣中寮鄉', '541', 1, 541)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣二崙鄉', '649', 1, 649)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣北港鎮', '651', 1, 651)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣水林鄉', '652', 1, 652)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣口湖鄉', '653', 1, 653)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣四湖鄉', '654', 1, 654)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'雲林縣', N'雲林縣元長鄉', '655', 1, 655)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市中西區', '700', 1, 700)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市東區', '701', 1, 701)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市南區', '702', 1, 702)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市北區', '704', 1, 704)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市安平區', '708', 1, 708)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市安南區', '709', 1, 709)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市永康區', '710', 1, 710)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市歸仁區', '711', 1, 711)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市新化區', '712', 1, 712)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市左鎮區', '713', 1, 713)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市玉井區', '714', 1, 714)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市楠西區', '715', 1, 715)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市南化區', '716', 1, 716)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市仁德區', '717', 1, 717)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市關廟區', '718', 1, 718)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市龍崎區', '719', 1, 719)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市官田區', '720', 1, 720)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市麻豆區', '721', 1, 721)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市佳里區', '722', 1, 722)

INSERT INTO [dbo].[City] ([LanguageID], [CountryId], [StateProviceName], [CityName], [ZipCode], [Published],[DisplayOrder]) 
VALUES (1,1, N'台南市', N'台南市西港區', '723', 1, 723)
