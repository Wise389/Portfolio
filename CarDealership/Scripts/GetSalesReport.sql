USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetSalesReport]    Script Date: 9/10/2021 2:32:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetSalesReport]
	@UserId nvarchar(128) null,
	@StartDate datetime null, 
	@EndDate datetime null
AS

SELECT
u.UserName,
SUM(s.SalesPrice) AS TotalSales,
COUNT(s.SalesId) AS TotalVehicles

FROM Sale s
JOIN AspNetUsers u ON s.UserId = u.Id
JOIN Vehicles v ON s.VehicleId = v.VehicleId
WHERE 
(@UserId is null or s.UserId = @UserId)
AND (@StartDate is null or s.SaleDate >= @StartDate)
AND (@EndDate is null or s.SaleDate <= @EndDate)
AND v.Sold = 1
GROUP BY u.UserName
ORDER BY TotalSales DESC
GO

