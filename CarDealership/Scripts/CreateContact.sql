USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[CreateContact]    Script Date: 9/10/2021 2:25:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CreateContact]
	@Name nvarchar(max),
	@Email nvarchar(50),
	@Phone nvarchar(50),
	@Message nvarchar(max)

AS
INSERT INTO Contact ([Name], Email, Phone, [Message])
VALUES (@Name, @Email, @Phone, @Message)
GO

