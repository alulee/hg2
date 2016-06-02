/*****************************************************************
* ScriptName...: tbAddress (地址)
* Purpose......: Create Address Table
* Programmer...: Randy
* Created On...: 2016/04/13
* ****************************************************************/
/* Modification History:
* 2016/04/13  Randy First Cut
* ****************************************************************/

/*****************************************************************/
/* Start Create Table Here                                       */
/*****************************************************************/

IF OBJECT_ID('Address') IS NOT NULL
BEGIN
	PRINT '<<<DROP TABLE Address>>>'
	DROP TABLE Address
END
GO

CREATE TABLE Address
(
	[Id] int IDENTITY(1,1) NOT NULL,
	[Country] nvarchar(Max) NOT NULL
		CONSTRAINT DF_Address_Country DEFAULT '',	
	[StateProvince] nvarchar(Max) NOT NULL
		CONSTRAINT DF_Address_StateProvince DEFAULT '',	
	[City] nvarchar(Max) NOT NULL
		CONSTRAINT DF_Address_City DEFAULT '',	
	[Address1] nvarchar(Max) NOT NULL
		CONSTRAINT DF_Address_Address1 DEFAULT '',
	[Address2] nvarchar(Max) NOT NULL
		CONSTRAINT DF_Address_Address2 DEFAULT '',
	[ZipPostalCode] nvarchar(100) NOT NULL
		CONSTRAINT DF_Address_ZipPostalCode DEFAULT '',
	[ContactName] nvarchar(100) NOT NULL --地址聯絡人
		CONSTRAINT DF_Address_ContactName DEFAULT '',
	[ContactEmail] nvarchar(100) NOT NULL --地址聯絡人Email
		CONSTRAINT DF_Address_ContactEmail DEFAULT '',
	[ContactPhone] nvarchar(100) NOT NULL --地址聯絡人電話
		CONSTRAINT DF_Address_ContactPhone DEFAULT '',
	[ContactFax] nvarchar(100) NOT NULL --地址聯絡人電話
		CONSTRAINT DF_Address_ContactFax DEFAULT '',
	[Longitude] decimal(28,6) NULL, --地址經度 
	[Latitude] decimal(28,6) NULL, --地址緯度  
	[CustomAttributes] nvarchar(max) NULL
		CONSTRAINT DF_Address_CustomAttributes DEFAULT '',
	[IsDeleted] bit NOT NULL				--是否刪除
		CONSTRAINT DF_Address_IsDeleted DEFAULT 0,
	[DisplayOrder] int NOT NULL
		CONSTRAINT DF_Address_DisplayOrder DEFAULT 0,
	[CreatedOnUtc] datetime2(7) NOT NULL	
		CONSTRAINT DF_Address_CreatedOnUtc DEFAULT Getdate(),
	[UpdatedOnUtc] datetime2(7) NOT NULL		
		CONSTRAINT DF_Address_UpdatedOnUtc DEFAULT Getdate(),
	[CreatedWho] nvarchar(20) NOT NULL
		CONSTRAINT DF_Address_CreatedWho DEFAULT '',
	[UpdatedWho] nvarchar(20) NOT NULL
		CONSTRAINT DF_Address_UpdatedWho DEFAULT '',
	[LastChanged] TimeStamp	--資料更新旗標
)
GO
/*****************************************************************/
/* End Create Table Here                                         */
/*****************************************************************/

/*****************************************************************/
/* Start Authirity Table Here                                    */
/*****************************************************************/
IF OBJECT_ID('Address') IS NULL
BEGIN
	PRINT '<<<CREATION OF TABLE Address FAILED>>>'
END
ELSE
BEGIN
	PRINT '<<<CREATED TABLE Address>>>'
	--/* Grant Permissions */
	--	PRINT '<<<CREATED TABLE Address Grant Authority to HG>>>'
	--GRANT INSERT ON Address TO HG
	--GRANT UPDATE ON Address TO HG
	--GRANT DELETE ON Address TO HG
	--GRANT SELECT ON Address TO HG
	--/* End Grant Permissions */
END
/*****************************************************************/
/* End Authirity Table Here                                      */
/*****************************************************************/

/*****************************************************************/
/* Primary Key --- Start                                         */
/*****************************************************************/
IF NOT OBJECT_ID('PKAddressKey') IS NULL
BEGIN
	PRINT '<<<Dropping Primary Key PKAddressKey(Id) From Table Address>>>'
	ALTER TABLE Address
	DROP
		CONSTRAINT PKAddressKey
END
GO

IF OBJECT_ID('PKAddressKey') IS NULL
BEGIN
	PRINT '<<<Adding Primary Key PKAddressKey(Id) To Table Address>>>'
	SET NOCOUNT ON
	ALTER TABLE Address
	ADD
		CONSTRAINT PKAddressKey PRIMARY KEY CLUSTERED (Id) WITH FILLFACTOR=75 ON [Primary]
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

