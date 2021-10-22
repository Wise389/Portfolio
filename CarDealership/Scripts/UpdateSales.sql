USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSales]    Script Date: 9/10/2021 2:34:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateSales]
	@SalesId int,
	@CustomerId int,
	@SalesPrice decimal,
	@SaleDate datetime,
	@VehicleId int,
	@UserId nvarchar(128)
AS
UPDATE Sale
SET CustomerId = @CustomerId, SalesPrice = @SalesPrice, SaleDate = @SaleDate, VehicleId = @VehicleId, UserId = @UserId
WHERE SalesId = @SalesId

GO

