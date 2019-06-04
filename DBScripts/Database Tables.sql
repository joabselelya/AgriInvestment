
IF NOT OBJECT_ID('InvestmentCycles') IS NULL	DROP TABLE InvestmentCycles
GO
IF NOT OBJECT_ID('Products') IS NULL	DROP TABLE Products
GO
IF NOT OBJECT_ID('ProductCategories') IS NULL	DROP TABLE ProductCategories
GO
IF NOT OBJECT_ID('User') IS NULL	DROP TABLE [User]
GO

--1. USER

IF NOT OBJECT_ID('User') IS NULL	DROP TABLE [User]
GO
CREATE TABLE [User](
	Id int NOT NULL IDENTITY(1,1)
   ,UserName nvarchar(256) NOT NULL
   ,FirstName varchar(50) NOT NULL
   ,MiddleName varchar(50) NULL
   ,Surname varchar(50) NOT NULL
   ,PasswordHash nvarchar(256) NULL
   --,SecurityStamp nvarchar(256) NULL
   --,EmailConfirmed bit NOT NULL DEFAULT(0)
   --,PasswordChangeDate datetime NULL
   --,Avatar nvarchar(70) NULL
   --,MobileNoConfirmed bit NOT NULL DEFAULT(0)
   --,IsActive bit NOT NULL DEFAULT(0)
   --,DeactivateDate datetime NULL
   --,LoginDate datetime NULL
   --,ActivityDate datetime NULL
   --,AccessFailedCount int NOT NULL DEFAULT(0)
   --,IsLocked bit NOT NULL DEFAULT(0)
   --,LockoutEndDateUTC datetime NULL
   --,CreatedBy int NOT NULL
   --,CreatedOn datetime NOT NULL
   --,ModifiedBy int NULL
   --,ModifiedOn datetime NULL
   --,CONSTRAINT PK_User PRIMARY KEY (Id)
   --,CONSTRAINT FK_User_UserGroup_UserGroupId FOREIGN KEY (UserGroupId) REFERENCES UserGroup(Id) ON UPDATE NO ACTION ON DELETE NO ACTION
   --,CONSTRAINT IX_User_UserName UNIQUE NONCLUSTERED (UserName)
)
GO


--2. PRODUCT CATEGORY

IF NOT OBJECT_ID('ProductCategories') IS NULL	DROP TABLE ProductCategories
GO
CREATE TABLE ProductCategories(
	Id int NOT NULL IDENTITY(1,1)
   ,Name varchar(50) NOT NULL
   ,[Description] varchar(100) NULL
   ,CreatedOn datetime NOT NULL
   ,CreatedBy int NOT NULL
   ,ModifiedBy int NULL
   ,ModifiedOn datetime NULL
   ,CONSTRAINT PK_ProductCategory_Id PRIMARY KEY(Id)
)
GO


--3. PRODUCT

IF NOT OBJECT_ID('Products') IS NULL	DROP TABLE Products
GO
CREATE TABLE Products(
	Id int NOT NULL IDENTITY(1,1)
   ,Name varchar(50) NOT NULL
   ,[Description] varchar(100) NULL
   ,ProductCategoryId int NOT NULL
   ,CreatedOn datetime NOT NULL
   ,CreatedBy int NOT NULL
   ,ModifiedBy int NULL
   ,ModifiedOn datetime NULL
   ,CONSTRAINT PK_Product_Id PRIMARY KEY(Id)
   ,CONSTRAINT FK_Product_ProductCategory_ProductCategoryId FOREIGN KEY(ProductCategoryId) REFERENCES ProductCategories(Id)
)
GO


--4. INVESTMENT CYCLE

IF NOT OBJECT_ID('InvestmentCycles') IS NULL	DROP TABLE InvestmentCycles
GO
CREATE TABLE InvestmentCycles(
	Id int NOT NULL IDENTITY(1,1)
   ,FromDate datetime NOT NULL
   ,ProductId int NOT NULL
   ,TargetAmount money NOT NULL
   ,MinimumAmount money NOT NULL
   ,MaximumAmount money NOT NULL
   ,CreatedOn datetime NOT NULL
   ,CreatedBy int NOT NULL
   ,ModifiedBy int NULL
   ,ModifiedOn datetime NULL
   ,CONSTRAINT PK_InvestmentCycle_Id PRIMARY KEY(Id)
   ,CONSTRAINT FK_InvestmentCycle_Product_ProductId FOREIGN KEY(ProductId) REFERENCES Products(Id)
)
GO