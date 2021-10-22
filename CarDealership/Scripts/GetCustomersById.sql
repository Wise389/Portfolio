USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetCustomersById]    Script Date: 9/10/2021 2:31:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCustomersById]
	@CustomerId int
AS

SELECT
c.CustomerId,
c.[Name],
c.Phone,
c.Email,
c.Street1,
c.Street2,
c.City,
c.StateId,
c.Zipcode
FROM Customer c
WHERE CustomerId = @CustomerId
GO

