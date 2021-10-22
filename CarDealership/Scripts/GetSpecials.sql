USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetSpecials]    Script Date: 9/10/2021 2:32:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetSpecials]
AS

SELECT
s.ImageFilePath,
s.SpecialId,
s.SpecialTitle,
s.SpecialMessage
FROM Special s

GO

