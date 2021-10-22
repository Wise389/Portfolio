USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 9/10/2021 2:33:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetUserById]
	@UserId nvarchar(128)
AS

SELECT u.Id AS UserId, u.Email, u.UserName, r.[Name] AS [Role]
    FROM AspNetUsers u
    INNER JOIN AspNetUserRoles a ON a.UserId = u.Id
    INNER JOIN AspNetRoles r ON r.Id = a.RoleId
	WHERE u.Id = @UserId
GO

