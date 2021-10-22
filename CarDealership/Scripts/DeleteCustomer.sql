USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 9/10/2021 2:27:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteCustomer]
	@CustomerId int
AS
DELETE FROM Customer 
WHERE CustomerId = @CustomerId
GO

