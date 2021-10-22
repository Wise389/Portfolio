USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetSaleById]    Script Date: 9/10/2021 2:31:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetSaleById]
	@VehicleId int
	AS

SELECT
s.SalesId,
s.SalesPrice,
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
v.SalesId,
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

