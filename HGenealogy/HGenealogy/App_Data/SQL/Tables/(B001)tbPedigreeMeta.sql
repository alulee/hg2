/*****************************************************************
* ScriptName...: tbPedigreeMeta (族譜基本資料)
* Purpose......: Create PedigreeMeta Table
* Programmer...: Randy
* Created On...: 2016/03/23
* ****************************************************************/
/* Modification History:
* 2016/03/23  Randy First Cut
* ****************************************************************/

/*****************************************************************/
/* Start Create Table Here                                       */
/*****************************************************************/

IF OBJECT_ID('PedigreeMeta') IS NOT NULL
BEGIN
	PRINT '<<<DROP TABLE PedigreeMeta>>>'
	DROP TABLE PedigreeMeta
END
GO

CREATE TABLE PedigreeMeta
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL
		CONSTRAINT DF_PedigreeMeta_Title DEFAULT '',
	[Editor] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NOT NULL
		CONSTRAINT DF_PedigreeMeta_Description DEFAULT '',
	[Image] [nvarchar](255) NULL,
	[PublishDate] [datetime2](7) NULL,
	[Volumes] [int] NOT NULL
		CONSTRAINT DF_PedigreeMeta_Volumes DEFAULT 0,
	[Pages] [int] NOT NULL
		CONSTRAINT DF_PedigreeMeta_Pages DEFAULT 0,
	[FamilyName] [nvarchar](30) NOT NULL
		CONSTRAINT DF_PedigreeMeta_FamilyName DEFAULT '',
	[OriginalAncestor] [nvarchar](30) NULL,
	[DateMoveToTaiwan] [nvarchar](10) NULL,
	[AncestorToTaiwan] [nvarchar](30) NULL,
	[OriginalAddress] [nvarchar](30) NULL,
	[TotalGenerations] [int] NOT NULL
		CONSTRAINT DF_PedigreeMeta_TotalGenerations DEFAULT 0,
	[GenerationToTaiwan] [int] NOT NULL
		CONSTRAINT DF_PedigreeMeta_GenerationToTaiwan DEFAULT 0,
	[LivingAreaInTaiwan] [nvarchar](255) NULL,
	[OriginalCollector] [nvarchar](50) NULL,
	[ContentNotes] [nvarchar](max) NULL,
	[TangName] [nvarchar](50) NULL,
	[IsPublic] [bit] NOT NULL
		CONSTRAINT DF_PedigreeMeta_IsPublic DEFAULT 0,
	[IsPublished] [bit] NOT NULL
		CONSTRAINT DF_PedigreeMeta_IsPublished DEFAULT 0,
	[IsDeleted] [bit] NOT NULL				--是否刪除
		CONSTRAINT DF_PedigreeMeta_IsDeleted DEFAULT 0,
	[CreatedOnUtc] [datetime2](7) NOT NULL	
		CONSTRAINT DF_PedigreeMeta_CreatedOnUtc DEFAULT Getdate(),
	[UpdatedOnUtc] [datetime2](7) NOT NULL		
		CONSTRAINT DF_PedigreeMeta_UpdatedOnUtc DEFAULT Getdate(),
	[CreatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_PedigreeMeta_CreatedWho DEFAULT '',
	[UpdatedWho] [nvarchar](20) NOT NULL
		CONSTRAINT DF_PedigreeMeta_UpdatedWho DEFAULT '',
	[LastChanged] TimeStamp	--資料更新旗標
)
GO
/*****************************************************************/
/* End Create Table Here                                         */
/*****************************************************************/

/*****************************************************************/
/* Start Authirity Table Here                                    */
/*****************************************************************/
IF OBJECT_ID('PedigreeMeta') IS NULL
BEGIN
	PRINT '<<<CREATION OF TABLE PedigreeMeta FAILED>>>'
END
ELSE
BEGIN
	PRINT '<<<CREATED TABLE PedigreeMeta>>>'
	--/* Grant Permissions */
	--	PRINT '<<<CREATED TABLE PedigreeMeta Grant Authority to HG>>>'
	--GRANT INSERT ON PedigreeMeta TO HG
	--GRANT UPDATE ON PedigreeMeta TO HG
	--GRANT DELETE ON PedigreeMeta TO HG
	--GRANT SELECT ON PedigreeMeta TO HG
	--/* End Grant Permissions */
END
/*****************************************************************/
/* End Authirity Table Here                                      */
/*****************************************************************/

/*****************************************************************/
/* Primary Key --- Start                                         */
/*****************************************************************/
IF NOT OBJECT_ID('PKPedigreeMetaKey') IS NULL
BEGIN
	PRINT '<<<Dropping Primary Key PKPedigreeMetaKey(Id) From Table PedigreeMeta>>>'
	ALTER TABLE PedigreeMeta
	DROP
		CONSTRAINT PKPedigreeMetaKey
END
GO

IF OBJECT_ID('PKPedigreeMetaKey') IS NULL
BEGIN
	PRINT '<<<Adding Primary Key PKPedigreeMetaKey(Id) To Table PedigreeMeta>>>'
	SET NOCOUNT ON
	ALTER TABLE PedigreeMeta
	ADD
		CONSTRAINT PKPedigreeMetaKey PRIMARY KEY CLUSTERED (Id) WITH FILLFACTOR=75 ON [Primary]
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

