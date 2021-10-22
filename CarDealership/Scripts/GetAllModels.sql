USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetAllModels]    Script Date: 9/10/2021 2:30:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllModels]	
AS

SELECT 
m.ModelId,
m.ModelName,
m.MakeId,
ma.MakeName,
m.DateAdded,
m.UserId,
asp.Email
FROM Model m
JOIN Make ma ON m.MakeId = ma.MakeId
JOIN AspNetUsers asp ON asp.Id = m.UserId
GO

