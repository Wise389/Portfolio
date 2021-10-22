USE [GuildCars]
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'RemoveOldUserRoles')
		DROP PROCEDURE RemoveOldUserRoles
GO

CREATE PROCEDURE [dbo].[RemoveOldUserRoles]
	@UserId nvarchar(128),
	@RoleId nvarchar(128)
AS
DELETE FROM AspNetUserRoles 
WHERE UserID = @UserId AND RoleId = @RoleId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateContact')
		DROP PROCEDURE CreateContact
GO

CREATE PROCEDURE [dbo].[CreateContact]
	@Name nvarchar(max),
	@Email nvarchar(50),
	@Phone nvarchar(50),
	@Message nvarchar(max)

AS
INSERT INTO Contact ([Name], Email, Phone, [Message])
VALUES (@Name, @Email, @Phone, @Message)
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateCustomer')
		DROP PROCEDURE CreateCustomer
GO

CREATE PROCEDURE [dbo].[CreateCustomer]
	@Name nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(50),
	@Street1 nvarchar(50),
	@Street2 nvarchar(50),
	@City nvarchar(50),
	@StateId int,
	@Zipcode int

AS
INSERT INTO Customer([Name], Email, Phone, Street1, Street2, City, StateId, Zipcode)
VALUES (@Name, @Email, @Phone, @Street1, @Street2, @City, @StateId, @Zipcode)
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateMake')
		DROP PROCEDURE CreateMake
GO

CREATE PROCEDURE [dbo].[CreateMake]
	@MakeName nvarchar(50),
	@DateAdded datetime,
	@UserId nvarchar(256)

AS
INSERT INTO Make (MakeName, DateAdded, UserId)
VALUES (@MakeName, @DateAdded, @UserId)
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateModel')
		DROP PROCEDURE CreateModel
GO

CREATE PROCEDURE [dbo].[CreateModel]
	@ModelName nvarchar(50),
	@MakeId int,
	@DateAdded datetime,
	@UserId nvarchar(50)

AS
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES (@ModelName, @MakeId, @DateAdded, @UserId)
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateSale')
		DROP PROCEDURE CreateSale
GO

CREATE PROCEDURE [dbo].[CreateSale]
	@PurchasePrice decimal,
	@SalesType int,
	@SalesDate datetime,
	@VehicleId int,
	@UserName nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(50),
	@Street1 nvarchar(50),
	@Street2 nvarchar(50) null,
	@City nvarchar(50),
	@StateId int,
	@Zipcode int,
	@Name nvarchar(50)
AS
DECLARE @CUSTOMERID INT
INSERT INTO Customer ([Name], Phone, Email, Street1, Street2, City, StateId, Zipcode)
VALUES (@Name, @Phone, @Email, @Street1, @Street2, @City, @StateId, @Zipcode)
SET @CUSTOMERID = SCOPE_IDENTITY()
INSERT INTO Sale (SalesType, SaleDate, PurchasePrice, CustomerId, UserId, VehicleId)
VALUES (@SalesType, @SalesDate, @PurchasePrice, @CUSTOMERID, (SELECT Id FROM AspNetUsers WHERE UserName = @UserName), @VehicleId)
UPDATE Vehicles
SET Sold = 1
WHERE VehicleId = @VehicleId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateSpecial')
		DROP PROCEDURE CreateSpecial
GO

CREATE PROCEDURE [dbo].[CreateSpecial]
	@SpecialId int,
	@SpecialTitle nvarchar(10),
	@SpecialMessage nvarchar(50),
	@ImageFilePath nvarchar([max])
AS
INSERT INTO Special (SpecialId , SpecialTitle, SpecialMessage, ImageFilePath)
VALUES (@SpecialId, @SpecialTitle, @SpecialMessage, @ImageFilePath)
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateVehicle')
		DROP PROCEDURE CreateVehicle
GO

CREATE PROCEDURE [dbo].[CreateVehicle]
	@SalesPrice decimal,
	@MakeId int,
	@ModelId int,
	@ConditionId int,
	@BodyStyleId int,
	@Year int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage int,
	@VIN nvarchar(17),
	@MSRP decimal,
	@Description nvarchar(max),
	@ImageFilePath nvarchar(max),
	@Featured bit,
	@Sold bit

AS
DECLARE @ID INT
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, SalesPrice, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, [Description], ImageFilePath, Featured, Sold)
VALUES (@MakeId, @ModelId, @ConditionId, @BodyStyleId, @SalesPrice, @Year, @TransmissionId, @ColorId, @InteriorId, @Mileage, @VIN, @MSRP, @Description, @ImageFilePath, @Featured, @Sold)
SET @ID = SCOPE_IDENTITY()
RETURN @ID
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteCustomer')
		DROP PROCEDURE DeleteCustomer
GO

CREATE PROCEDURE [dbo].[DeleteCustomer]
	@CustomerId int
AS
DELETE FROM Customer 
WHERE CustomerId = @CustomerId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteSale')
		DROP PROCEDURE DeleteSale
GO

CREATE PROCEDURE [dbo].[DeleteSale]
	@SalesId int
AS
DELETE FROM Sale 
WHERE SalesId = @SalesId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteSpecial')
		DROP PROCEDURE DeleteSpecial
GO


CREATE PROCEDURE [dbo].[DeleteSpecial]
	@SpecialId int
AS
DELETE FROM Special 
WHERE SpecialId = @SpecialId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteVehicle')
		DROP PROCEDURE DeleteVehicle
GO

CREATE PROCEDURE [dbo].[DeleteVehicle]
	@VehicleId int
AS
DELETE FROM Vehicles 
WHERE VehicleId = @VehicleId
GO
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllMakes')
		DROP PROCEDURE GetAllMakes
GO

CREATE PROCEDURE [dbo].[GetAllMakes]	
AS

SELECT 
m.MakeId,
m.MakeName,
m.DateAdded,
m.UserId,
u.Email
FROM Make m
JOIN AspNetUsers u ON u.Id = m.UserId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllModels')
		DROP PROCEDURE GetAllModels
GO

CREATE PROCEDURE [dbo].[GetAllModels]	
AS

SELECT 
m.ModelId,
m.ModelName,
m.MakeId,
ma.MakeName,
m.DateAdded,
m.UserId,
asp.Email
FROM Model m
JOIN Make ma ON m.MakeId = ma.MakeId
JOIN AspNetUsers asp ON asp.Id = m.UserId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllSales')
		DROP PROCEDURE GetAllSales
GO

CREATE PROCEDURE [dbo].[GetAllSales]

AS

SELECT
s.SalesId,
s.PurchasePrice,
s.SaleDate,
s.CustomerId,
s.VehicleId,
s.UserId,
c.[Name],
c.Phone,
c.Email,
c.Street1,
c.Street2,
c.City,
c.StateId,
c.Zipcode,
v.MakeId,
v.SalesPrice,
ma.MakeName,
v.ModelId,
mo.ModelName,
v.ConditionId,
v.BodyStyleId,
v.[Year],
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold
FROM Vehicles v
JOIN Sale s ON v.VehicleId = s.VehicleId
LEFT JOIN Customer c ON c.CustomerId = s.CustomerId
JOIN Make ma ON ma.MakeId = v.MakeId
JOIN Model mo ON mo.ModelId = v.ModelId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllUsers')
		DROP PROCEDURE GetAllUsers
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS

SELECT u.Id AS UserId, u.Email, u.UserName, r.[Name] AS [Role]
    FROM AspNetUsers u
    INNER JOIN AspNetUserRoles a ON a.UserId = u.Id
    INNER JOIN AspNetRoles r ON r.Id = a.RoleId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetAllVehicles')
		DROP PROCEDURE GetAllVehicles
GO

CREATE PROCEDURE [dbo].[GetAllVehicles]
AS

SELECT 
v.VehicleId,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold,
v.SalesPrice
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetFeaturedVehicle')
		DROP PROCEDURE GetFeaturedVehicle
GO

CREATE PROCEDURE [dbo].[GetFeaturedVehicle]
AS

SELECT 
v.VehicleId,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold,
v.SalesPrice
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
WHERE v.Featured = 1 AND v.Sold = 0

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetInventoryReport')
		DROP PROCEDURE GetInventoryReport
GO

CREATE PROCEDURE [dbo].[GetInventoryReport]
    @ConditionID int 
AS
	SELECT v.[Year], ma.MakeName, mo.ModelName, COUNT(*) AS [Count], SUM(v.MSRP) AS 'Stock Value'
	FROM Vehicles AS v
	JOIN Make AS ma ON ma.MakeId = v.MakeId
	JOIN Model AS mo ON mo.ModelId = v.ModelId
	WHERE v.ConditionId = @ConditionID
	GROUP BY v.[Year], ma.MakeName, mo.ModelName

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetNewVehicle')
		DROP PROCEDURE GetNewVehicle
GO

CREATE PROCEDURE [dbo].[GetNewVehicle]
	@ConditionId int 
AS

SELECT 
v.VehicleId,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold,
v.SalesPrice
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
WHERE ConditionId = 1

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetSaleById')
		DROP PROCEDURE GetSaleById
GO

CREATE PROCEDURE [dbo].[GetSaleById]
	@VehicleId int
	AS

SELECT
s.SalesId,
s.PurchasePrice,
s.SaleDate,
s.CustomerId,
s.VehicleId,
s.UserId,
v.VehicleId,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.SalesPrice,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold
FROM Vehicles v
JOIN Sale s ON v.VehicleId = s.VehicleId
LEFT JOIN Customer c ON c.CustomerId = s.CustomerId
JOIN Make ma ON ma.MakeId = v.MakeId
JOIN Model mo ON mo.ModelId = v.ModelId
WHERE v.VehicleId = @VehicleId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetSalesReport')
		DROP PROCEDURE GetSalesReport
GO

CREATE PROCEDURE [dbo].[GetSalesReport]
	@UserId nvarchar(128) null,
	@StartDate datetime null, 
	@EndDate datetime null
AS

SELECT
u.UserName,
SUM(s.PurchasePrice) AS TotalSales,
COUNT(s.SalesId) AS TotalVehicles

FROM Sale s
JOIN AspNetUsers u ON s.UserId = u.Id
WHERE 
(@UserId is null or s.UserId = @UserId)
AND (@StartDate is null or s.SaleDate >= @StartDate)
AND (@EndDate is null or s.SaleDate <= @EndDate)
GROUP BY u.UserName
ORDER BY TotalSales DESC
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetSpecialById')
		DROP PROCEDURE GetSpecialById
GO

CREATE PROCEDURE [dbo].[GetSpecialById]
	@SpecialId int
AS

SELECT
s.ImageFilePath,
s.SpecialId,
s.SpecialTitle,
s.SpecialMessage
FROM Special s
WHERE s.SpecialId = @SpecialId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetSpecials')
		DROP PROCEDURE GetSpecials
GO

CREATE PROCEDURE [dbo].[GetSpecials]
AS

SELECT
s.ImageFilePath,
s.SpecialId,
s.SpecialTitle,
s.SpecialMessage
FROM Special s

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetUsedVehicles')
		DROP PROCEDURE GetUsedVehicles
GO

CREATE PROCEDURE [dbo].[GetUsedVehicles]
	@ConditionId int 
AS

SELECT 
v.VehicleId,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold,
v.SalesPrice
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
WHERE ConditionId = 2

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetUserById')
		DROP PROCEDURE GetUserById
GO

CREATE PROCEDURE [dbo].[GetUserById]
	@UserId nvarchar(128)
AS

SELECT u.Id AS UserId, u.Email, u.UserName, r.[Name] AS [Role]
    FROM AspNetUsers u
    INNER JOIN AspNetUserRoles a ON a.UserId = u.Id
    INNER JOIN AspNetRoles r ON r.Id = a.RoleId
	WHERE u.Id = @UserId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetVehiclesById')
		DROP PROCEDURE GetVehiclesById
GO

CREATE PROCEDURE [dbo].[GetVehiclesById]
	@VehicleId int

AS

SELECT 
v.SalesPrice,
v.VehicleId,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
WHERE v.VehicleId = @VehicleId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'NewVehicleSearch')
		DROP PROCEDURE NewVehicleSearch
GO

CREATE PROCEDURE [dbo].[NewVehicleSearch]
	@minPrice int null,
	@maxPrice int null, 
	@minYear int null, 
	@maxYear int null,
	@searchString nvarchar(50) null
AS

SELECT TOP 20
v.VehicleId,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold,
v.SalesPrice
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
WHERE 
(@minPrice is null or v.MSRP >= @minPrice) 
AND (@maxPrice is null or v.MSRP <= @maxPrice)
AND (@minYear is null or v.[Year] >= @minYear)
AND (@maxYear is null or v.[Year] <= @maxPrice)
AND (@searchString is null or v.[Year] like '%' + @searchString + '%'  or ma.MakeName like '%' + @searchString + '%' or mo.ModelName like '%' + @searchString + '%')
AND ConditionId = 1
ORDER BY v.MSRP DESC

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'SalesSearch')
		DROP PROCEDURE SalesSearch
GO

CREATE PROCEDURE [dbo].[SalesSearch]
	@minPrice int null,
	@maxPrice int null, 
	@minYear int null, 
	@maxYear int null,
	@searchString nvarchar(50) null
AS

SELECT
v.VehicleId,
v.SalesPrice,
v.MakeId,
ma.MakeName,
v.ModelId,
mo.ModelName,
v.ConditionId,
v.BodyStyleId,
v.[Year],
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold
FROM Vehicles v
JOIN Make ma ON ma.MakeId = v.MakeId
JOIN Model mo ON mo.ModelId = v.ModelId
WHERE 
(@minPrice is null or v.MSRP >= @minPrice) 
AND (@maxPrice is null or v.MSRP <= @maxPrice)
AND (@minYear is null or v.[Year] >= @minYear)
AND (@maxYear is null or v.[Year] <= @maxYear)
AND (@searchString is null or v.[Year] like '%' + @searchString + '%'  or ma.MakeName like '%' + @searchString + '%' or mo.ModelName like '%' + @searchString + '%')
AND v.Sold = 0
ORDER BY v.MSRP DESC
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateCustomer')
		DROP PROCEDURE UpdateCustomer
GO

CREATE PROCEDURE [dbo].[UpdateCustomer]
	@CustomerId int,
	@Name nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(50),
	@Street1 nvarchar(50),
	@Street2 nvarchar(50),
	@City nvarchar(50),
	@StateId int,
	@Zipcode int
	

AS
UPDATE Customer
SET [Name] = @Name, Email = @Email, Phone = @Phone, Street1 = @Street1, Street2 = @Street2, City = @City, StateId = @StateId, Zipcode = @Zipcode
WHERE CustomerId = @CustomerId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateSales')
		DROP PROCEDURE UpdateSales
GO

CREATE PROCEDURE [dbo].[UpdateSales]
	@SalesId int,
	@CustomerId int,
	@PurchasePrice decimal,
	@SaleDate datetime,
	@VehicleId int,
	@UserId nvarchar(128)
AS
UPDATE Sale
SET CustomerId = @CustomerId, PurchasePrice = @PurchasePrice, SaleDate = @SaleDate, VehicleId = @VehicleId, UserId = @UserId
WHERE SalesId = @SalesId

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateVehicle')
		DROP PROCEDURE UpdateVehicle
GO

CREATE PROCEDURE [dbo].[UpdateVehicle]
	@VehicleId int,
	@MakeId int,
	@ModelId int,
	@ConditionId int,
	@BodyStyleId int,
	@Year int,
	@TransmissionId int,
	@ColorId int,
	@InteriorId int,
	@Mileage int,
	@VIN nvarchar(17),
	@MSRP decimal,
	@Description nvarchar(max),
	@ImageFilePath nvarchar(max),
	@Featured bit,
	@Sold bit,
	@SalesPrice decimal
AS
UPDATE Vehicles
SET MakeId = @MakeId, ModelId = @ModelId, ConditionId = @ConditionId, BodyStyleId = @BodyStyleId, [Year] = @Year, TransmissionId = @TransmissionId, ColorId = @ColorId, 
	InteriorId = @InteriorId, Mileage = @Mileage, VIN = @VIN, MSRP = @MSRP, [Description] = @Description, ImageFilePath = @ImageFilePath, Featured = @Featured, SalesPrice = @SalesPrice,
	Sold = @Sold
WHERE VehicleId = @VehicleId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UsedVehicleSearch')
		DROP PROCEDURE UsedVehicleSearch
GO

CREATE PROCEDURE [dbo].[UsedVehicleSearch]
	@minPrice int null,
	@maxPrice int null, 
	@minYear int null, 
	@maxYear int null,
	@searchString nvarchar(50) null
AS

SELECT TOP 20
v.VehicleId,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold,
v.SalesPrice
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
WHERE 
(@minPrice is null or v.MSRP >= @minPrice) 
AND (@maxPrice is null or v.MSRP <= @maxPrice)
AND (@minYear is null or v.[Year] >= @minYear)
AND (@maxYear is null or v.[Year] <= @maxYear)
AND (@searchString is null or v.[Year] like '%' + @searchString + '%'  or ma.MakeName like '%' + @searchString + '%' or mo.ModelName like '%' + @searchString + '%')
AND ConditionId = 2
ORDER BY v.MSRP DESC

GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'VehicleSearch')
		DROP PROCEDURE VehicleSearch
GO

CREATE PROCEDURE [dbo].[VehicleSearch]
	@minPrice int null,
	@maxPrice int null, 
	@minYear int null, 
	@maxYear int null,
	@searchString nvarchar(50) null
AS

SELECT TOP 20
v.VehicleId,
v.SalesPrice,
v.[Year], 
ma.MakeId,
ma.MakeName,
ma.DateAdded,
mo.ModelId, 
mo.ModelName,
mo.DateAdded,
v.ConditionId,
v.BodyStyleId,
v.TransmissionId,
v.ColorId,
v.InteriorId,
v.Mileage,
v.VIN,
v.MSRP,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
WHERE 
(@minPrice is null or v.MSRP >= @minPrice) 
AND (@maxPrice is null or v.MSRP <= @maxPrice)
AND (@minYear is null or v.[Year] >= @minYear)
AND (@maxYear is null or v.[Year] <= @maxYear)
AND (@searchString is null or v.[Year] like '%' + @searchString + '%'  or ma.MakeName like '%' + @searchString + '%' or mo.ModelName like '%' + @searchString + '%')
AND Sold = 0
ORDER BY v.MSRP DESC

GO
