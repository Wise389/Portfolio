USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[CreateSale]    Script Date: 9/10/2021 2:26:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CreateSale]
	@SalesId int,
	@SalesPrice decimal,
	@SalesType int,
	@SalesDate datetime,
	@VehicleId int,
	@UserId nvarchar(50),
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
UPDATE Sale
SET SalesPrice = @SalesPrice, SalesType = @SalesType, SaleDate = @SalesDate, CustomerId = @CUSTOMERID, UserId = (SELECT Id FROM AspNetUsers WHERE UserName = @UserId)
WHERE SalesId = @SalesId
UPDATE Vehicles
SET Sold = 1
WHERE VehicleId = @VehicleId
GO

