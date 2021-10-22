USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[CreateSpecial]    Script Date: 9/10/2021 4:12:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CreateSpecial]
	@SpecialTitle nvarchar(10),
	@SpecialMessage nvarchar(50),
	@ImageFilePath nvarchar([max])
AS
INSERT INTO Special (SpecialTitle, SpecialMessage, ImageFilePath)
VALUES (@SpecialTitle, @SpecialMessage, @ImageFilePath)
GO

