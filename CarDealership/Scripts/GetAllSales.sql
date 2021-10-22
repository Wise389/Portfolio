USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetAllSales]    Script Date: 9/10/2021 2:30:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllSales]

AS

SELECT
s.SalesId,
s.SalesPrice,
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
FROM Sale s
LEFT JOIN Customer c ON c.CustomerId = s.CustomerId
JOIN Vehicles v ON v.VehicleId = s.VehicleId
JOIN Make ma ON ma.MakeId = v.MakeId
JOIN Model mo ON mo.ModelId = v.ModelId
GO

