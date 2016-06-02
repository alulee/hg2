/*****************************************************************
* ScriptName...: tbFamilyMember (家族成員基本資料)
* Purpose......: Create FamilyMember Table
* Programmer...: Randy
* Created On...: 2016/03/23
* ****************************************************************/
/* Modification History:
* 2016/04/01  Randy First Cut
* ****************************************************************/

/*****************************************************************/
/* Start Create Table Here                                       */
/*****************************************************************/

IF OBJECT_ID('FamilyMember') IS NOT NULL
BEGIN
	PRINT '<<<DROP TABLE FamilyMember>>>'
	DROP TABLE FamilyMember
END
GO

CREATE TABLE FamilyMember
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FamilyName] [nvarchar](30) NOT NULL --姓
		CONSTRAINT DF_FamilyMember_FamilyName DEFAULT '',
	[GivenName] [nvarchar](50) NOT NULL	--名
		CONSTRAINT DF_FamilyMember_GivenName DEFAULT '',
	[Description] [nvarchar](Max) NOT NULL
		CONSTRAINT DF_FamilyMember_Description DEFAULT '',	
	[FatherMemberId] [int] NOT NULL	--父
		CONSTRAINT DF_FamilyMember_FatherMemberId DEFAULT 0,
	[MotherMemberId] [int] NOT NULL	--母
		CONSTRAINT DF_FamilyMember_MotherMemberId DEFAULT 0,
	[BirthYear] [nvarchar](30) NOT NULL --出生年
		CONSTRAINT DF_FamilyMember_BirthYear DEFAULT '',
	[BirthMonth] [nvarchar](10) NOT NULL --出生月份
		CONSTRAINT DF_FamilyMember_BirthMonth DEFAULT '',
	[BirthDate] [nvarchar](10) NOT NULL --出生日期
		CONSTRAINT DF_FamilyMember_BirthDate DEFAULT '',
	[CurrentAddressId] [int] NOT NULL --目前居住地址編號
		CONSTRAINT DF_FamilyMember_CurrentAddressId DEFAULT 0,
	[Email] [nvarchar](500) NOT NULL --Email
		CONSTRAINT DF_FamilyMember_Email DEFAULT '',
	[Phone] [nvarchar](30) NOT NULL --電話號碼
		CONSTRAINT DF_FamilyMember_Phone DEFAULT '',		
	[MobilePhone] [nvarchar](30) NOT NULL --手機號碼
		CONSTRAINT DF_FamilyMember_MobilePhone DEFAULT '',
	[Gender] [nvarchar](1) NOT NULL --性別
		CONSTRAINT DF_FamilyMember_Gender DEFAULT '',
	[LungName] [nvarchar](30) NOT NULL --郎名
		CONSTRAINT DF_FamilyMember_LungName DEFAULT '',
	[HakkaName] [nvarchar](30) NOT NULL --客家名
		CONSTRAINT DF_FamilyMember_HakkaName DEFAULT '',		
	[JobDescription] [nvarchar](Max) NOT NULL --工作職業
		CONSTRAINT DF_FamilyMember_JobDescription DEFAULT '',
	[IsPublic] [bit] NOT NULL				--是否公開
		CONSTRAINT DF_FamilyMember_IsPublic DEFAULT 0,	
	[IsPublished] [bit] NOT NULL			--是否發佈
		CONSTRAINT DF_FamilyMember_IsPublished DEFAULT 0,
	[IsDeleted] [bit] NOT NULL				--是否刪除
		CONSTRAINT DF_FamilyMember_IsDeleted DEFAULT 0,
	[DisplayOrder] [int] NOT NULL
		CONSTRAINT DF_FamilyMember_DisplayOrder DEFAULT 0,
	[CreatedOnUtc] [datetime2](7) NOT NULL	
		CONSTRAINT DF_FamilyMember_CreatedOnUtc DEFAULT Getdate(),
	[UpdatedOnUtc] [datetime2](7) NOT NULL		
		CONSTRAINT DF_FamilyMember_UpdatedOnUtc DEFAULT Getdate(),
	[CreatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_FamilyMember_CreatedWho DEFAULT '',
	[UpdatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_FamilyMember_UpdatedWho DEFAULT '',
	[LastChanged] TimeStamp	--資料更新旗標
)
GO
/*****************************************************************/
/* End Create Table Here                                         */
/*****************************************************************/

/*****************************************************************/
/* Start Authirity Table Here                                    */
/*****************************************************************/
IF OBJECT_ID('FamilyMember') IS NULL
BEGIN
	PRINT '<<<CREATION OF TABLE FamilyMember FAILED>>>'
END
ELSE
BEGIN
	PRINT '<<<CREATED TABLE FamilyMember>>>'
	--/* Grant Permissions */
	--	PRINT '<<<CREATED TABLE FamilyMember Grant Authority to HG>>>'
	--GRANT INSERT ON FamilyMember TO HG
	--GRANT UPDATE ON FamilyMember TO HG
	--GRANT DELETE ON FamilyMember TO HG
	--GRANT SELECT ON FamilyMember TO HG
	--/* End Grant Permissions */
END
/*****************************************************************/
/* End Authirity Table Here                                      */
/*****************************************************************/

/*****************************************************************/
/* Primary Key --- Start                                         */
/*****************************************************************/
IF NOT OBJECT_ID('PKFamilyMemberKey') IS NULL
BEGIN
	PRINT '<<<Dropping Primary Key PKFamilyMemberKey(Id) From Table FamilyMember>>>'
	ALTER TABLE FamilyMember
	DROP
		CONSTRAINT PKFamilyMemberKey
END
GO

IF OBJECT_ID('PKFamilyMemberKey') IS NULL
BEGIN
	PRINT '<<<Adding Primary Key PKFamilyMemberKey(Id) To Table FamilyMember>>>'
	SET NOCOUNT ON
	ALTER TABLE FamilyMember
	ADD
		CONSTRAINT PKFamilyMemberKey PRIMARY KEY CLUSTERED (Id) WITH FILLFACTOR=75 ON [Primary]
END
GO
/*****************************************************************/
/* Primary Key --- End                                           */
/*****************************************************************/

/*****************************************************************/
/* Foreign Key --- Start                                         */
/*****************************************************************/

/*****************************************************************/
/* Foreign Key --- End                                           */
/*****************************************************************/

/*****************************************************************/
/* Index Key --- Start                                           */
/*****************************************************************/

/*****************************************************************/
/* Index Key --- End                                             */
/*****************************************************************/

