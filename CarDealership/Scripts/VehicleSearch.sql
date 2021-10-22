USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[VehicleSearch]    Script Date: 9/10/2021 2:35:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
s.SalesPrice,
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
JOIN Make AS ma ON ma.MakeId = v.MakeId
JOIN Model AS mo ON mo.ModelId = v.ModelId
JOIN Sale AS s ON s.SalesId = v.SalesId
WHERE 
(@minPrice is null or v.MSRP >= @minPrice) 
AND (@maxPrice is null or v.MSRP <= @maxPrice)
AND (@minYear is null or v.[Year] >= @minYear)
AND (@maxYear is null or v.[Year] <= @maxYear)
AND (@searchString is null or v.[Year] like '%' + @searchString + '%'  or ma.MakeName like '%' + @searchString + '%' or mo.ModelName like '%' + @searchString + '%')
AND Sold = 0
ORDER BY v.MSRP DESC

GO

