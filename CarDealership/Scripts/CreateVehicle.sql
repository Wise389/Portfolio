USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[CreateVehicle]    Script Date: 9/10/2021 2:27:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
DECLARE @SALESID INT
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES (@MakeId, @ModelId, @ConditionId, @BodyStyleId, @Year, @TransmissionId, @ColorId, @InteriorId, @Mileage, @VIN, @MSRP, NULL, @Description, @ImageFilePath, @Featured, @Sold)
SET @ID = SCOPE_IDENTITY()
INSERT INTO Sale (SalesPrice, SalesType, SaleDate, VehicleId, CustomerId, UserId)
VALUES (@SalesPrice, NULL, NULL, @ID, NULL, NULL)
SET @SALESID = SCOPE_IDENTITY()
UPDATE Vehicles
SET SalesId = @SALESID
WHERE VehicleId = @ID
RETURN @ID
GO

