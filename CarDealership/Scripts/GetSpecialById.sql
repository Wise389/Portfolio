USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetSpecialById]    Script Date: 9/10/2021 2:32:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetSpecialById]
	@SpecialId int
AS

SELECT
s.ImageFilePath,
s.SpecialId,
s.SpecialTitle,
s.SpecialMessage
FROM Special s
WHERE s.SpecialId = @SpecialId
GO

