
--1. USER

IF NOT OBJECT_ID('AddEditUser') IS NULL	DROP PROC AddEditUser
GO
CREATE PROC AddEditUser
	@Id int
   ,@UserName nvarchar(256)
   ,@FirstName varchar(50)
   ,@MiddleName varchar(50)
   ,@Surname varchar(50)
   ,@PasswordHash nvarchar(256) 
AS
BEGIN
	IF ISNULL(@Id,0)>0
		UPDATE T1
		SET T1.FirstName=@FirstName
		   ,T1.MiddleName=@MiddleName
		   ,T1.Surname=@Surname
		   ,T1.PasswordHash=@PasswordHash
		FROM [User] T1
		WHERE T1.Id=@Id
	ELSE
		INSERT INTO [User](UserName,FirstName,MiddleName,Surname,PasswordHash)
		SELECT @UserName,@FirstName,@MiddleName,@Surname,@PasswordHash
END
GO

IF NOT OBJECT_ID('GetUsers') IS NULL	DROP PROC GetUsers
GO
CREATE PROC GetUsers
AS
BEGIN
	SELECT T1.Id,T1.UserName,T1.FirstName,T1.MiddleName,T1.Surname,T1.PasswordHash
	FROM [User] T1
END
GO

IF NOT OBJECT_ID('GetUser') IS NULL	DROP PROC GetUser
GO
CREATE PROC GetUser
	@Id int
AS
BEGIN
	SELECT T1.Id,T1.UserName,T1.FirstName,T1.MiddleName,T1.Surname,T1.PasswordHash
	FROM [User] T1
	WHERE T1.Id=@Id
END
GO




--2. PRODUCT CATEGORY

IF NOT OBJECT_ID('AddEditProductCategory') IS NULL	DROP PROC AddEditProductCategory
GO
CREATE PROC AddEditProductCategory
	@Id varchar(50)
   ,@Name varchar(50)
   ,@Description varchar(100)
   ,@UserId int
AS
BEGIN
	IF ISNULL(@Id,0)>0
		UPDATE T1
		SET T1.Name=@Name
		   ,T1.[Description]=@Description
		   ,T1.ModifiedBy=@UserId
		   ,T1.ModifiedOn=GETDATE()
		FROM ProductCategories T1
		WHERE T1.Id=@Id
	ELSE
		INSERT INTO ProductCategories(Name,[Description],CreatedBy,CreatedOn)
		SELECT @Name,@Description,@UserId,GETDATE()
END
GO

IF NOT OBJECT_ID('DeleteProductCategory') IS NULL	DROP PROC DeleteProductCategory
GO
CREATE PROC DeleteProductCategory
	@Id varchar(50)
   ,@UserId int
AS
BEGIN
	DELETE T1
	FROM ProductCategories T1
	WHERE T1.Id=@Id
END
GO

IF NOT OBJECT_ID('GetProductCategories') IS NULL	DROP PROC GetProductCategories
GO
CREATE PROC GetProductCategories
AS
BEGIN
	SELECT T1.Id,T1.Name,T1.[Description],T1.CreatedBy,T1.CreatedOn,T1.ModifiedBy,T1.ModifiedOn
	FROM ProductCategories T1
END
GO

IF NOT OBJECT_ID('GetProductCategory') IS NULL	DROP PROC GetProductCategory
GO
CREATE PROC GetProductCategory
	@Id int
AS
BEGIN
	SELECT T1.Id,T1.Name,T1.[Description],T1.CreatedBy,T1.CreatedOn,T1.ModifiedBy,T1.ModifiedOn
	FROM ProductCategories T1
	WHERE T1.Id=@Id
END
GO

--3. PRODUCT

IF NOT OBJECT_ID('AddEditProduct') IS NULL	DROP PROC AddEditProduct
GO
CREATE PROC AddEditProduct
	@Id varchar(50)
   ,@Name varchar(50)
   ,@Description varchar(100)
   ,@ProductCategoryId int
   ,@UserId int
AS
BEGIN
	IF ISNULL(@Id,0)>0
		UPDATE T1
		SET T1.Name=@Name
		   ,T1.[Description]=@Description
		   ,T1.ProductCategoryId=@ProductCategoryId
		   ,T1.ModifiedBy=@UserId
		   ,T1.ModifiedOn=GETDATE()
		FROM Products T1
		WHERE T1.Id=@Id
	ELSE
		INSERT INTO Products(Name,[Description],ProductCategoryId,CreatedBy,CreatedOn)
		SELECT @Name,@Description,@ProductCategoryId,@UserId,GETDATE()
END
GO

IF NOT OBJECT_ID('DeleteProduct') IS NULL	DROP PROC DeleteProduct
GO
CREATE PROC DeleteProduct
	@Id varchar(50)
   ,@UserId int
AS
BEGIN
	DELETE T1
	FROM Products T1
	WHERE T1.Id=@Id
END
GO

IF NOT OBJECT_ID('GetProducts') IS NULL	DROP PROC GetProducts
GO
CREATE PROC GetProducts
AS
BEGIN
	SELECT T1.Id,T1.Name,T1.[Description],T1.ProductCategoryId,T2.Name AS ProductCategoryName,T1.CreatedBy,T1.CreatedOn,T1.ModifiedBy,T1.ModifiedOn
	FROM Products T1 INNER JOIN ProductCategories T2 ON T1.ProductCategoryId=T2.Id
END
GO

IF NOT OBJECT_ID('GetProduct') IS NULL	DROP PROC GetProduct
GO
CREATE PROC GetProduct
	@Id int
AS
BEGIN
	DECLARE @ProductCategoryId int

	SELECT @ProductCategoryId=T1.ProductCategoryId FROM Products T1 WHERE T1.Id=@Id

	SELECT T1.Id,T1.Name,T1.[Description],T1.ProductCategoryId,T2.Name AS ProductCategoryName,T1.CreatedBy,T1.CreatedOn,T1.ModifiedBy,T1.ModifiedOn
	FROM Products T1 INNER JOIN ProductCategories T2 ON T1.ProductCategoryId=T2.Id
	WHERE T1.Id=@Id

	EXEC GetProducts @Id=@ProductCategoryId
END
GO


--4. INVESTMENT CYCLE

IF NOT OBJECT_ID('AddEditInvestmentCycle') IS NULL	DROP PROC AddEditInvestmentCycle
GO
CREATE PROC AddEditInvestmentCycle
	@Id varchar(50)
   ,@FromDate datetime
   ,@ProductId int
   ,@TargetAmount money
   ,@MinimumAmount money
   ,@MaximumAmount money
   ,@UserId int
AS
BEGIN
	IF ISNULL(@Id,0)>0
		UPDATE T1
		SET T1.FromDate=@FromDate
		   ,T1.ProductId=@ProductId
		   ,T1.TargetAmount=@TargetAmount
		   ,T1.MinimumAmount=@MinimumAmount
		   ,T1.MaximumAmount=@MaximumAmount
		   ,T1.ModifiedBy=@UserId
		   ,T1.ModifiedOn=GETDATE()
		FROM InvestmentCycles T1
		WHERE T1.Id=@Id
	ELSE
		INSERT INTO InvestmentCycles(FromDate,ProductId,TargetAmount,MinimumAmount,MaximumAmount,CreatedBy,CreatedOn)
		SELECT @FromDate,@ProductId,@TargetAmount,@MinimumAmount,@MaximumAmount,@UserId,GETDATE()
END
GO

IF NOT OBJECT_ID('DeleteInvestmentCycle') IS NULL	DROP PROC DeleteInvestmentCycle
GO
CREATE PROC DeleteInvestmentCycle
	@Id varchar(50)
   ,@UserId int
AS
BEGIN
	DELETE T1
	FROM InvestmentCycles T1
	WHERE T1.Id=@Id
END
GO

IF NOT OBJECT_ID('GetInvestmentCycles') IS NULL	DROP PROC GetInvestmentCycles
GO
CREATE PROC GetInvestmentCycles
AS
BEGIN
	SELECT T1.Id,T1.FromDate,T1.ProductId,T2.Name AS ProductName,T1.TargetAmount,T1.MinimumAmount,T1.MinimumAmount,T1.CreatedBy,T1.CreatedOn,T1.ModifiedBy,T1.ModifiedOn
	FROM InvestmentCycles T1 INNER JOIN Products T2 ON T1.ProductId=T2.Id
END
GO

IF NOT OBJECT_ID('GetInvestmentCycle') IS NULL	DROP PROC GetInvestmentCycle
GO
CREATE PROC GetInvestmentCycle
	@Id int
AS
BEGIN
	DECLARE @ProductId int

	SELECT @ProductId=T1.ProductId FROM InvestmentCycles T1 WHERE T1.Id=@Id

	SELECT T1.Id,T1.FromDate,T1.ProductId,T2.Name AS ProductName,T1.TargetAmount,T1.MinimumAmount,T1.MinimumAmount,T1.CreatedBy,T1.CreatedOn,T1.ModifiedBy,T1.ModifiedOn
	FROM InvestmentCycles T1 INNER JOIN Products T2 ON T1.ProductId=T2.Id
	WHERE T1.Id=@Id

	EXEC GetProduct @Id=@ProductId
END
GO