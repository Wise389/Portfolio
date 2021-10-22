USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[DeleteVehicle]    Script Date: 9/10/2021 2:28:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteVehicle]
	@VehicleId int
AS
UPDATE Vehicles
SET SalesId = NULL
WHERE VehicleId = @VehicleId
DELETE FROM Sale
WHERE VehicleId = @VehicleId
DELETE FROM Vehicles 
WHERE VehicleId = @VehicleId
GO

