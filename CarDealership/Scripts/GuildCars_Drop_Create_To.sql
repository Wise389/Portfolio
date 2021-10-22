USE GuildCars
GO
IF (OBJECT_ID('dbo.FK_Sale_Vehicles', 'F') IS NOT NULL)
ALTER TABLE [dbo].[Sale] DROP CONSTRAINT [FK_Sale_Vehicles]
GO
IF (OBJECT_ID('dbo.FK_Sale_Customer', 'F') IS NOT NULL)
ALTER TABLE [dbo].[Sale] DROP CONSTRAINT [FK_Sale_Customer]
GO
IF (OBJECT_ID('dbo.FK_Vehicles_Sale', 'F') IS NOT NULL)
ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_Vehicles_Sale]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]'))
DROP TABLE [dbo].[User]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]'))
DROP TABLE [dbo].[Customer]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sale]'))
DROP TABLE [dbo].[Sale]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vehicles]'))
DROP TABLE [dbo].[Vehicles]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Model]'))
DROP TABLE [dbo].[Model]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Make]'))
DROP TABLE [dbo].[Make]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]'))
DROP TABLE [dbo].[Contact]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Special]'))
DROP TABLE [dbo].[Special]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
DROP TABLE [dbo].[AspNetUserRoles]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]'))
DROP TABLE [dbo].[AspNetRoles]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
DROP TABLE [dbo].[AspNetUserClaims]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
DROP TABLE [dbo].[AspNetUserLogins]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]'))
DROP TABLE [dbo].[AspNetUsers]
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetRoles]'))
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL, --index
	[Name] [nvarchar](256) NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	PRIMARY KEY (Id)
	)
GO
CREATE INDEX Id ON AspNetRoles(Id)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUsers]'))
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL, --index
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	PRIMARY KEY (Id)
)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserClaims]'))
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL, --index
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_AspNetUserClaims_AspNetUsers FOREIGN KEY(UserId) REFERENCES AspNetUsers (Id)
)
GO
CREATE INDEX Id ON AspNetUserClaims(Id)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserLogins]'))
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL, --index
	PRIMARY KEY (LoginProvider, ProviderKey, UserId),
	CONSTRAINT FK_AspNetUserLogins_AspNetUsers FOREIGN KEY(UserId) REFERENCES AspNetUsers (Id)
)
GO
CREATE INDEX Id ON AspNetUserLogins(UserId)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspNetUserRoles]'))
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
	PRIMARY KEY (UserId, RoleId),
	CONSTRAINT FK_AspNetUserRoles_AspNetUsers FOREIGN KEY(UserId) REFERENCES AspNetUsers (Id),
	CONSTRAINT FK_AspNetUserRoles_AspNetRoles FOREIGN KEY(RoleId) REFERENCES AspNetRoles (Id)
)
GO
CREATE INDEX UserId ON AspNetUserRoles(UserId)
CREATE INDEX RoleId ON AspNetUserRoles(RoleId)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Make]'))
CREATE TABLE [dbo].[Make](
	[MakeId] [int] IDENTITY(1,1) NOT NULL,
	[MakeName] [nvarchar](50) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	PRIMARY KEY (MakeId),
	CONSTRAINT FK_Make_AspNetUsers FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id)
)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Model]'))
CREATE TABLE [dbo].[Model](
	[ModelId] [int] IDENTITY(1,1) NOT NULL,
	[ModelName] [nchar](50) NOT NULL,
	[MakeId] [int] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	PRIMARY KEY (ModelId),
	CONSTRAINT FK_Model_Make FOREIGN KEY (MakeId) REFERENCES Make(MakeId),
	CONSTRAINT FK_Model_AspNetUsers FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id)
)
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]'))
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	PRIMARY KEY (ContactId)
)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]'))
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Street1] [nvarchar](50) NOT NULL,
	[Street2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NOT NULL,
	[StateId] [int] NOT NULL,
	[Zipcode] [int] NOT NULL,
	PRIMARY KEY (CustomerId)
)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vehicles]'))
CREATE TABLE [dbo].[Vehicles](
	[VehicleId] [int] IDENTITY(1,1) NOT NULL,
	[MakeId] [int] NOT NULL,
	[ModelId] [int] NOT NULL,
	[ConditionId] [int] NOT NULL,
	[BodyStyleId] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[TransmissionId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
	[InteriorId] [int] NOT NULL,
	[Mileage] [int] NOT NULL,
	[VIN] [nvarchar](17) NOT NULL,
	[MSRP] [decimal](18, 0) NOT NULL,
	[SalesId] [int] NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ImageFilePath] [nvarchar](max) NOT NULL,
	[Featured] [bit] NOT NULL,
	[Sold] [bit] NOT NULL,
	PRIMARY KEY (VehicleId),
	CONSTRAINT FK_Vehicles_Make FOREIGN KEY (MakeId) REFERENCES Make (MakeId),
	CONSTRAINT FK_Vehicles_Model FOREIGN KEY (ModelId) REFERENCES Model (ModelId)
	)
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sale]'))
CREATE TABLE [dbo].[Sale](
	[SalesId] [int] IDENTITY(1,1) NOT NULL,
	[SalesPrice] [decimal](18, 2) NOT NULL,
	[SalesType] [int] NULL,
	[SaleDate] [datetime] NULL,
	[CustomerId] [int] NULL,
	[VehicleId] [int] NOT NULL,
	[UserId] [nvarchar](128) NULL,
	PRIMARY KEY (SalesId),
	CONSTRAINT FK_Sale_Customer FOREIGN KEY(CustomerId) REFERENCES Customer (CustomerId),
	CONSTRAINT FK_Sale_Vehicles FOREIGN KEY(VehicleId) REFERENCES Vehicles (VehicleId)
)
GO
ALTER TABLE [dbo].[Vehicles] WITH CHECK ADD CONSTRAINT [FK_Vehicles_Sale] FOREIGN KEY ([SalesId])
REFERENCES [dbo].[Sale] ([SalesId])
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Special]'))
CREATE TABLE [dbo].[Special](
	[SpecialId] [int] IDENTITY(1,1) NOT NULL,
	[SpecialTitle] [nchar](50) NOT NULL,
	[SpecialMessage] [nvarchar](max) NOT NULL,
	[ImageFilePath] [nvarchar](max) NOT NULL,
	PRIMARY KEY (SpecialId)
)
GO



