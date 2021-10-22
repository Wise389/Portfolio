USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 9/10/2021 2:30:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllUsers]
AS

SELECT u.Id AS UserId, u.Email, u.UserName, r.[Name] AS [Role]
    FROM AspNetUsers u
    INNER JOIN AspNetUserRoles a ON a.UserId = u.Id
    INNER JOIN AspNetRoles r ON r.Id = a.RoleId
GO

