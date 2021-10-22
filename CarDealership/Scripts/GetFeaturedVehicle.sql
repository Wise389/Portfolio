USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetFeaturedVehicle]    Script Date: 9/10/2021 2:31:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
v.SalesId,
v.[Description],
v.ImageFilePath,
v.Featured,
v.Sold,
s.SalesPrice
FROM Vehicles v
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
JOIN Sale AS s ON s.SalesId = v.SalesId
WHERE Featured = 1

GO

