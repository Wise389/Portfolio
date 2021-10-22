USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[CreateCustomer]    Script Date: 9/10/2021 2:25:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CreateCustomer]
	@Name nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(50),
	@Street1 nvarchar(50),
	@Street2 nvarchar(50),
	@City nvarchar(50),
	@StateId int,
	@Zipcode int

AS
INSERT INTO Customer([Name], Email, Phone, Street1, Street2, City, StateId, Zipcode)
VALUES (@Name, @Email, @Phone, @Street1, @Street2, @City, @StateId, @Zipcode)
GO

