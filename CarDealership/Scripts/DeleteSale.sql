USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[DeleteSale]    Script Date: 9/10/2021 2:27:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteSale]
	@SalesId int
AS
DELETE FROM Sale 
WHERE SalesId = @SalesId
GO

