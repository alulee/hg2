/*****************************************************************
* ScriptName...: tbFamilyMemberInfo (家族成員延申資料)
* Purpose......: Create FamilyMemberInfo Table
* Programmer...: Randy
* Created On...: 2016/04/13
* ****************************************************************/
/* Modification History:
* 2016/04/13  Randy First Cut
* ****************************************************************/

/*****************************************************************/
/* Start Create Table Here                                       */
/*****************************************************************/

IF OBJECT_ID('FamilyMemberInfo') IS NOT NULL
BEGIN
	PRINT '<<<DROP TABLE FamilyMemberInfo>>>'
	DROP TABLE FamilyMemberInfo
END
GO

CREATE TABLE FamilyMemberInfo
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FamilyMemberId] [int] NOT NULL	--家族成員編號
		CONSTRAINT DF_FamilyMemberInfo_FamilyMemberId DEFAULT 0,
	[InfoType] [nvarchar](10) NOT NULL	--延伸資料類別
		CONSTRAINT DF_FamilyMemberInfo_InfoType DEFAULT '',
	[InfoTitle] [nvarchar](30) NOT NULL --延伸資料抬頭
		CONSTRAINT DF_FamilyMemberInfo_InfoTitle DEFAULT '',
	[InfoContent] [nvarchar](max) NOT NULL --延伸資料內容
		CONSTRAINT DF_FamilyMemberInfo_InfoContent DEFAULT '',	
	[Address] nvarchar(Max) NOT NULL --延伸資料相關地址
		CONSTRAINT DF_FamilyMemberInfo_Address DEFAULT '',
	[Longitude] decimal(28,6) NULL, --延伸資料地址經度 
	[Latitude] decimal(28,6) NULL, --延伸資料地址緯度 	
	[DisplayOrder] [int] NOT NULL
		CONSTRAINT DF_FamilyMemberInfo_DisplayOrder DEFAULT 0,
	[CreatedOnUtc] [datetime2](7) NOT NULL	
		CONSTRAINT DF_FamilyMemberInfo_CreatedOnUtc DEFAULT Getdate(),
	[UpdatedOnUtc] [datetime2](7) NOT NULL		
		CONSTRAINT DF_FamilyMemberInfo_UpdatedOnUtc DEFAULT Getdate(),
	[CreatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_FamilyMemberInfo_CreatedWho DEFAULT '',
	[UpdatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_FamilyMemberInfo_UpdatedWho DEFAULT '',
	[LastChanged] TimeStamp	--資料更新旗標
)
GO
/*****************************************************************/
/* End Create Table Here                                         */
/*****************************************************************/

/*****************************************************************/
/* Start Authirity Table Here                                    */
/*****************************************************************/
IF OBJECT_ID('FamilyMemberInfo') IS NULL
BEGIN
	PRINT '<<<CREATION OF TABLE FamilyMemberInfo FAILED>>>'
END
ELSE
BEGIN
	PRINT '<<<CREATED TABLE FamilyMemberInfo>>>'
	--/* Grant Permissions */
	--	PRINT '<<<CREATED TABLE FamilyMemberInfo Grant Authority to HG>>>'
	--GRANT INSERT ON FamilyMemberInfo TO HG
	--GRANT UPDATE ON FamilyMemberInfo TO HG
	--GRANT DELETE ON FamilyMemberInfo TO HG
	--GRANT SELECT ON FamilyMemberInfo TO HG
	--/* End Grant Permissions */
END
/*****************************************************************/
/* End Authirity Table Here                                      */
/*****************************************************************/

/*****************************************************************/
/* Primary Key --- Start                                         */
/*****************************************************************/
IF NOT OBJECT_ID('PKFamilyMemberInfoKey') IS NULL
BEGIN
	PRINT '<<<Dropping Primary Key PKFamilyMemberInfoKey(Id) From Table FamilyMemberInfo>>>'
	ALTER TABLE FamilyMemberInfo
	DROP
		CONSTRAINT PKFamilyMemberInfoKey
END
GO

IF OBJECT_ID('PKFamilyMemberInfoKey') IS NULL
BEGIN
	PRINT '<<<Adding Primary Key PKFamilyMemberInfoKey(Id) To Table FamilyMemberInfo>>>'
	SET NOCOUNT ON
	ALTER TABLE FamilyMemberInfo
	ADD
		CONSTRAINT PKFamilyMemberInfoKey PRIMARY KEY CLUSTERED (Id) WITH FILLFACTOR=75 ON [Primary]
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

