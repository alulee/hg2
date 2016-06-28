/*****************************************************************
* ScriptName...: tbFamilyMember_Picture_Mapping (家族成員圖片基本資料)
* Purpose......: Create FamilyMember_Picture_Mapping Table
* Programmer...: Randy
* Created On...: 2016/04/06
* ****************************************************************/
/* Modification History:
* 2016/04/01  Randy First Cut
* ****************************************************************/

/*****************************************************************/
/* Start Create Table Here                                       */
/*****************************************************************/

IF OBJECT_ID('FamilyMember_Picture_Mapping') IS NOT NULL
BEGIN
	PRINT '<<<DROP TABLE FamilyMember_Picture_Mapping>>>'
	DROP TABLE FamilyMember_Picture_Mapping
END
GO

CREATE TABLE FamilyMember_Picture_Mapping
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FamilyMemberId] [int] NOT NULL 
		CONSTRAINT DF_FamilyMember_Picture_Mapping_FamilyMemberId DEFAULT 0,
	[PictureId] [int] NOT NULL 
		CONSTRAINT DF_FamilyMember_Picture_Mapping_PictureId DEFAULT 0,
	[DisplayOrder] [int] NOT NULL
		CONSTRAINT DF_FamilyMember_Picture_Mapping_DisplayOrder DEFAULT 0,
	[CreatedOnUtc] [datetime2](7) NOT NULL	
		CONSTRAINT DF_FamilyMember_Picture_Mapping_CreatedOnUtc DEFAULT Getdate(),
	[UpdatedOnUtc] [datetime2](7) NOT NULL		
		CONSTRAINT DF_FamilyMember_Picture_Mapping_UpdatedOnUtc DEFAULT Getdate(),
	[CreatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_FamilyMember_Picture_Mapping_CreatedWho DEFAULT '',
	[UpdatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_FamilyMember_Picture_Mapping_UpdatedWho DEFAULT '',
	[LastChanged] TimeStamp	--資料更新旗標
)
GO
/*****************************************************************/
/* End Create Table Here                                         */
/*****************************************************************/

/*****************************************************************/
/* Start Authirity Table Here                                    */
/*****************************************************************/
IF OBJECT_ID('FamilyMember_Picture_Mapping') IS NULL
BEGIN
	PRINT '<<<CREATION OF TABLE FamilyMember_Picture_Mapping FAILED>>>'
END
ELSE
BEGIN
	PRINT '<<<CREATED TABLE FamilyMember_Picture_Mapping>>>'
	--/* Grant Permissions */
	--	PRINT '<<<CREATED TABLE FamilyMember_Picture_Mapping Grant Authority to HG>>>'
	--GRANT INSERT ON FamilyMember_Picture_Mapping TO HG
	--GRANT UPDATE ON FamilyMember_Picture_Mapping TO HG
	--GRANT DELETE ON FamilyMember_Picture_Mapping TO HG
	--GRANT SELECT ON FamilyMember_Picture_Mapping TO HG
	--/* End Grant Permissions */
END
/*****************************************************************/
/* End Authirity Table Here                                      */
/*****************************************************************/

/*****************************************************************/
/* Primary Key --- Start                                         */
/*****************************************************************/
IF NOT OBJECT_ID('PKFamilyMember_Picture_MappingKey') IS NULL
BEGIN
	PRINT '<<<Dropping Primary Key PKFamilyMember_Picture_MappingKey(Id) From Table FamilyMember_Picture_Mapping>>>'
	ALTER TABLE FamilyMember_Picture_Mapping
	DROP
		CONSTRAINT PKFamilyMember_Picture_MappingKey
END
GO

IF OBJECT_ID('PKFamilyMember_Picture_MappingKey') IS NULL
BEGIN
	PRINT '<<<Adding Primary Key PKFamilyMember_Picture_MappingKey(Id) To Table FamilyMember_Picture_Mapping>>>'
	SET NOCOUNT ON
	ALTER TABLE FamilyMember_Picture_Mapping
	ADD
		CONSTRAINT PKFamilyMember_Picture_MappingKey PRIMARY KEY CLUSTERED (Id) WITH FILLFACTOR=75 ON [Primary]
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

