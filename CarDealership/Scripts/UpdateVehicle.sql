USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[UpdateVehicle]    Script Date: 9/10/2021 2:35:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
	InteriorId = @InteriorId, Mileage = @Mileage, VIN = @VIN, MSRP = @MSRP, [Description] = @Description, ImageFilePath = @ImageFilePath, Featured = @Featured,
	Sold = @Sold
WHERE VehicleId = @VehicleId
UPDATE Sale
SET SalesPrice = @SalesPrice
WHERE VehicleId = @VehicleId
GO

