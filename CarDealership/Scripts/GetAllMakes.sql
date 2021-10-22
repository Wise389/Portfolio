USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetAllMakes]    Script Date: 9/10/2021 2:29:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllMakes]	
AS

SELECT 
m.MakeId,
m.MakeName,
m.DateAdded,
m.UserId,
u.Email
FROM Make m
JOIN AspNetUsers u ON u.Id = m.UserId
GO

