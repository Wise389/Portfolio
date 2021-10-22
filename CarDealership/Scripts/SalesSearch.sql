USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[SalesSearch]    Script Date: 9/10/2021 2:33:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SalesSearch]
	@minPrice int null,
	@maxPrice int null, 
	@minYear int null, 
	@maxYear int null,
	@searchString nvarchar(50) null
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
JOIN Customer c ON c.CustomerId = s.CustomerId
JOIN Vehicles v ON v.VehicleId = s.VehicleId
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

