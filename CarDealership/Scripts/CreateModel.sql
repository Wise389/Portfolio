USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[CreateModel]    Script Date: 9/10/2021 2:26:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CreateModel]
	@ModelName nvarchar(50),
	@MakeId int,
	@DateAdded datetime,
	@UserId nvarchar(50)

AS
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES (@ModelName, @MakeId, @DateAdded, @UserId)
GO

