USE [GuildCars]
GO

/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 9/9/2021 9:25:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCustomer]
	@CustomerId int,
	@Name nvarchar(50),
	@Email nvarchar(50),
	@Phone nvarchar(50),
	@Street1 nvarchar(50),
	@Street2 nvarchar(50),
	@City nvarchar(50),
	@StateId int,
	@Zipcode int
	

AS
UPDATE Customer
SET [Name] = @Name, Email = @Email, Phone = @Phone, Street1 = @Street1, Street2 = @Street2, City = @City, StateId = @StateId, Zipcode = @Zipcode
WHERE CustomerId = @CustomerId
GO

