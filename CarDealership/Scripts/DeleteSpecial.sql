USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[DeleteSpecial]    Script Date: 9/10/2021 2:28:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[DeleteSpecial]
	@SpecialId int
AS
DELETE FROM Special 
WHERE SpecialId = @SpecialId
GO

