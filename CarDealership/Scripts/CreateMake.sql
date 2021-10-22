USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[CreateMake]    Script Date: 9/10/2021 2:26:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CreateMake]
	@MakeName nvarchar(50),
	@DateAdded datetime,
	@UserId nvarchar(256)

AS
INSERT INTO Make (MakeName, DateAdded, UserId)
VALUES (@MakeName, @DateAdded, @UserId)
GO

