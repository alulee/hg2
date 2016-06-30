/*****************************************************************
* ScriptName...: tbFamilyMemberRelation (家族成員關聯資料表)
* Purpose......: Create FamilyMemberRelation Table
* Programmer...: Randy
* Created On...: 2016/04/06
* ****************************************************************/
/* Modification History:
* 2016/04/24 Randy First Cut
* ****************************************************************/

/*****************************************************************/
/* Start Create Table Here                                       */
/*****************************************************************/

IF OBJECT_ID('FamilyMemberRelation') IS NOT NULL
BEGIN
	PRINT '<<<DROP TABLE FamilyMemberRelation>>>'
	DROP TABLE FamilyMemberRelation
END
GO

CREATE TABLE FamilyMemberRelation
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FamilyMemberId] [int] NOT NULL 
		CONSTRAINT DF_FamilyMemberRelation_FamilyMemberId DEFAULT 0,
	[RelatedFamilyMemberId] [int] NOT NULL 
		CONSTRAINT DF_FamilyMemberRelation_RelatedFamilyMemberId DEFAULT 0,
	[RelationType] [varchar](10) NOT NULL
		CONSTRAINT DF_FamilyMemberRelation_Relation DEFAULT '',
	[CreatedOnUtc] [datetime2](7) NOT NULL	
		CONSTRAINT DF_FamilyMemberRelation_CreatedOnUtc DEFAULT Getdate(),
	[UpdatedOnUtc] [datetime2](7) NOT NULL		
		CONSTRAINT DF_FamilyMemberRelation_UpdatedOnUtc DEFAULT Getdate(),
	[CreatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_FamilyMemberRelation_CreatedWho DEFAULT '',
	[UpdatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_FamilyMemberRelation_UpdatedWho DEFAULT '',
	[LastChanged] TimeStamp	--資料更新旗標
)
GO
/*****************************************************************/
/* End Create Table Here                                         */
/*****************************************************************/

/*****************************************************************/
/* Start Authirity Table Here                                    */
/*****************************************************************/
IF OBJECT_ID('FamilyMemberRelation') IS NULL
BEGIN
	PRINT '<<<CREATION OF TABLE FamilyMemberRelation FAILED>>>'
END
ELSE
BEGIN
	PRINT '<<<CREATED TABLE FamilyMemberRelation>>>'
	--/* Grant Permissions */
	--	PRINT '<<<CREATED TABLE FamilyMemberRelation Grant Authority to HG>>>'
	--GRANT INSERT ON FamilyMemberRelation TO HG
	--GRANT UPDATE ON FamilyMemberRelation TO HG
	--GRANT DELETE ON FamilyMemberRelation TO HG
	--GRANT SELECT ON FamilyMemberRelation TO HG
	--/* End Grant Permissions */
END
/*****************************************************************/
/* End Authirity Table Here                                      */
/*****************************************************************/

/*****************************************************************/
/* Primary Key --- Start                                         */
/*****************************************************************/
IF NOT OBJECT_ID('PKFamilyMemberRelationKey') IS NULL
BEGIN
	PRINT '<<<Dropping Primary Key PKFamilyMemberRelationKey(Id) From Table FamilyMemberRelation>>>'
	ALTER TABLE FamilyMemberRelation
	DROP
		CONSTRAINT PKFamilyMemberRelationKey
END
GO

IF OBJECT_ID('PKFamilyMemberRelationKey') IS NULL
BEGIN
	PRINT '<<<Adding Primary Key PKFamilyMemberRelationKey(Id) To Table FamilyMemberRelation>>>'
	SET NOCOUNT ON
	ALTER TABLE FamilyMemberRelation
	ADD
		CONSTRAINT PKFamilyMemberRelationKey PRIMARY KEY CLUSTERED (Id) WITH FILLFACTOR=75 ON [Primary]
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

