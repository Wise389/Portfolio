USE GuildCars
----=========================================================
----AspNetUsers Inserts
----=========================================================
--IF NOT EXISTS(SELECT TOP 1 * FROM AspNetUsers WHERE UserName = 'Admin')
--BEGIN
--INSERT INTO AspNetUsers(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
--VALUES((SELECT NEWID()), 'Admin@guildcars.com', 1, null, null, '5555555555', 1, 0, null, 0, 0, 'Admin')
--END
--IF NOT EXISTS(SELECT TOP 1 * FROM AspNetUsers WHERE UserName = 'Sales')
--BEGIN
--INSERT INTO AspNetUsers(Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName)
--VALUES((SELECT NEWID()), 'Sales@guildcars.com', 1, null, null, null, 1, 0, null, 0, 0, 'Sales')
--END
----=========================================================
----AspNetRoles Inserts
----=========================================================
--IF NOT EXISTS(SELECT TOP 1 * FROM AspNetRoles WHERE [Name] = 'Admin')
--BEGIN
--INSERT INTO AspNetRoles (Id, [Name], Discriminator)
--VALUES ((SELECT NEWID()), 'Admin', '')
--END
--IF NOT EXISTS(SELECT TOP 1 * FROM AspNetRoles WHERE [Name] = 'Sales')
--BEGIN
--INSERT INTO AspNetRoles (Id, [Name], Discriminator)
--VALUES ((SELECT NEWID()), 'Sales', '')
--END
----=========================================================
----AspNetUserClaims Inserts
----=========================================================
----=========================================================
----AspNetUserLogins Inserts
----=========================================================

--=========================================================
--Contact Inserts
--=========================================================
IF NOT EXISTS(SELECT TOP 1 * FROM Contact WHERE Email = 'Jd@gmail.com')
BEGIN
INSERT INTO Contact([Name], Email, Phone, [Message])
VALUES('John Doe', '3302165555', '3302165555', 'Joes cousins brother')
END
IF NOT EXISTS(SELECT TOP 1 * FROM Contact WHERE Email = 'Guthery@yahoo.com')
BEGIN
INSERT INTO Contact([Name], Email, Phone, [Message])
VALUES('Woody Guthery','Guthery@yahoo.com','2162555555','Looking at that pickup')
END
IF NOT EXISTS(SELECT TOP 1 * FROM Contact WHERE Email = 'Windsor@kent.edu')
BEGIN
INSERT INTO Contact([Name], Email, Phone, [Message])
VALUES('Chuck Windsor','Windsor@kent.edu','3135525555','Does that sedan have air ride breaks?')
END
IF NOT EXISTS(SELECT TOP 1 * FROM Contact WHERE Email = 'Wise@bgsu.edu')
BEGIN
INSERT INTO Contact([Name], Email, Phone, [Message])
VALUES('Jon Wise','Wise@bgsu.edu','3303546401','Looking to bargain on that 02 Saturn SL2')
END
IF NOT EXISTS(SELECT TOP 1 * FROM Contact WHERE Email = 'Gary@buckeye.org')
BEGIN
INSERT INTO Contact([Name], Email, Phone, [Message])
VALUES('Gary Garingson','Gary@buckeye.org','5555555555','GARY GARINGSON WAS HERE!!!!')
END
--=========================================================
--Customer Inserts
--=========================================================
IF NOT EXISTS(SELECT TOP 1 * FROM Customer WHERE Phone = '3302165555')
BEGIN
INSERT INTO Customer([Name], Phone, Email, Street1, Street2, City, StateId, Zipcode)
VALUES('John Doe', '3302165555', 'Jd@gmail.com', '256 WonderBread Ln', '', 'Gingerville', 26, 90210)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Customer WHERE Phone = '2162555555')
BEGIN
INSERT INTO Customer([Name], Phone, Email, Street1, Street2, City, StateId, Zipcode)
VALUES('Woody Guthery','2162555555','Guthery@yahoo.com','415 Tootsy MicSkeeter Dr','','Wonkerdoodle',28,55486)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Customer WHERE Phone = '3135525555')
BEGIN
INSERT INTO Customer([Name], Phone, Email, Street1, Street2, City, StateId, Zipcode)
VALUES('Chuck Windsor','3135525555','Windsor@kent.edu','225 Window Ward Ave','','Greenbriar',41,99756)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Customer WHERE Phone = '3303546401')
BEGIN
INSERT INTO Customer([Name], Phone, Email, Street1, Street2, City, StateId, Zipcode)
VALUES('Jon Wise','3303546401','Wise@bgsu.edu','725 Whisky Susan Cir NW','','Nashville',10,06752)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Customer WHERE Phone = '5555555555')
BEGIN
INSERT INTO Customer([Name], Phone, Email, Street1, Street2, City, StateId, Zipcode)
VALUES('Gary Garingson','5555555555','Gary@buckeye.org','35 E 32nd St','','Avalon',16,87546)
END
--=========================================================
--Make Inserts
--=========================================================
IF NOT EXISTS(SELECT TOP 1 * FROM Make WHERE MakeName = 'Toyota')
BEGIN
INSERT INTO Make(MakeName, DateAdded, UserId)
VALUES('Toyota', '2021-03-15 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Make WHERE MakeName = 'Chrystler')
BEGIN
INSERT INTO Make(MakeName, DateAdded, UserId)
VALUES('Chrystler', '2021-02-13 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Make WHERE MakeName = 'Saturn')
BEGIN
INSERT INTO Make(MakeName, DateAdded, UserId)
VALUES('Saturn', '2021-03-11 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Make WHERE MakeName = 'BMW')
BEGIN
INSERT INTO Make(MakeName, DateAdded, UserId)
VALUES('BMW', '2021-04-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Make WHERE MakeName = 'Ford')
BEGIN
INSERT INTO Make(MakeName, DateAdded, UserId)
VALUES('Ford', '2021-05-10 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END
--=========================================================
--Model Inserts
--=========================================================
IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Tacoma')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Tacoma',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Toyota'),'2021-03-15 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Corolla')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Corolla',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Toyota'),'2021-03-17 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'RAV4')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('RAV4',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Toyota'),'2021-03-22 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = '300')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('300',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Chrystler'),'2021-02-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Pacifica')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Pacifica',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Chrystler'),'2021-02-22 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Town & Country')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Town & Country',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Chrystler'),'2021-02-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'SL')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('SL',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Saturn'),'2021-03-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'SL2')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('SL2',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Saturn'),'2021-03-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Vue')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Vue',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Saturn'),'2021-03-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'M3')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('M3',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'BMW'),'2021-04-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = '5 Series')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('5 Series',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'BMW'),'2021-04-20 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Raptor')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Raptor',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Ford'),'2021-05-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Thunderbird')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Thunderbird',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Ford'),'2021-05-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Mustang')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Mustang',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Ford'),'2021-05-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

IF NOT EXISTS(SELECT TOP 1 * FROM Model WHERE ModelName = 'Explorer')
BEGIN
INSERT INTO Model(ModelName, MakeId, DateAdded, UserId)
VALUES('Explorer',(SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Ford'),'2021-05-19 01:42:09.150',(SELECT TOP 1 Id FROM AspNetUsers))
END

--=========================================================
--Vehicle Inserts
--=========================================================
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '3TMDZ5BNXJM050402')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Toyota'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'Tacoma'), 1, 2, 2018, 1, 6, 6, 29520, '3TMDZ5BNXJM050402', 40537,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-a7618dc6-acf6-428a-888a-342590b45de8.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '5YFBURHE5GP407605')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Toyota'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'Corolla'), 2, 2, 2016, 1, 6, 6, 36915, '5YFBURHE5GP407605', 35769,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-60d78858-9f28-412f-988a-baaba3972adf.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = 'P6FH349761')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Toyota'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'RAV4'), 2, 3, 2018, 1, 5, 4, 29520, 'P6FH349761', 40537,NULL, ' T-Bird ', '/images/inventory-e2f16d6f-217f-457b-b543-6ed1ee7d18ba.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1FAFP42XX1F140942')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Chrystler'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = '300'), 2, 3, 2018, 1, 6, 6, 114770, '1FAFP42XX1F140942', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-2948f242-f640-4871-9f02-14d24731c498.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '8033207270')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Chrystler'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'Pacifica  '), 1, 3, 2018, 1, 6, 6, 114770, '8033207270', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-a5ec48ac-129f-4aa0-b5dc-84e744fc4d04.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1G8ZH5286XZ294973')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Saturn'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'SL'), 1, 3, 2018, 1, 6, 6, 114770, '1G8ZH5286XZ294973', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-aa88a673-3150-457b-abb6-6c2708916171.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1G8ZK5271TZ187073')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Saturn'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'SL2'), 2, 3, 2018, 1, 6, 6, 114770, '1G8ZK5271TZ187073', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-ae3a8237-c443-41ae-853a-8b2d99e81c57.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '3GSCL33P48S726712')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Saturn'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'VUE'), 1, 3, 2018, 1, 6, 6, 114770, '3GSCL33P48S726712', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-a9d36f26-7142-43b1-b261-049b8a65cb15.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = 'WBSBL93414PN57783')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'BMW'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'M3'), 2, 3, 2018, 1, 6, 6, 114770, 'WBSBL93414PN57783', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-bb90dddd-9af8-471e-af8e-ea15b045f2ad.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1FTFW1RG4KFD17343')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'BMW'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = '5 Series'), 1, 3, 2018, 1, 6, 6, 114770, '1FTFW1RG4KFD17343', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-05468d01-a3a5-40b0-a806-a5793657da5e.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '6T09T123243')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Ford'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'Raptor'), 1, 3, 2018, 1, 6, 6, 114770, '6T09T123243', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-b39e79bf-b0d7-4165-9da3-5fa0bb1f7f45.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1FMSK7DH0LGA16718')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Ford'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'Mustang'), 2, 3, 2018, 1, 6, 6, 114770, '1FMSK7DH0LGA16718', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-77aa85fe-1867-49e0-9280-b7694b6eff4b.jpg', 1, 0)
END
IF NOT EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '2T3W1RFV0LW073156')
BEGIN
INSERT INTO Vehicles(MakeId, ModelId, ConditionId, BodyStyleId, [Year], TransmissionId, ColorId, InteriorId, Mileage, VIN, MSRP, SalesId, [Description], ImageFilePath, Featured, Sold)
VALUES((SELECT TOP 1 MakeId FROM Make WHERE MakeName = 'Ford'), (SELECT TOP 1 ModelId FROM Model WHERE ModelName = 'Explorer'), 1, 3, 2018, 1, 6, 6, 114770, '2T3W1RFV0LW073156', 35449,NULL, ' Exterior Color: Midnight Black Metallic, Interior Color: Black ', '/images/inventory-77aa85fe-1867-49e0-9280-b7694b6eff4b.jpg', 1, 0)
END
--=========================================================
--Sale Inserts
--=========================================================
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '3TMDZ5BNXJM050402'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3302165555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '3TMDZ5BNXJM050402'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '5YFBURHE5GP407605'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3302165555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '5YFBURHE5GP407605'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = 'P6FH349761'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3303546401'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = 'P6FH349761'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FAFP42XX1F140942'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(20000, 3, '2021-04-20 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '5555555555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FAFP42XX1F140942'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '8033207270'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(20000, 3, '2021-04-20 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '5555555555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '8033207270'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1G8ZH5286XZ294973'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3303546401'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1G8ZH5286XZ294973'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1G8ZK5271TZ187073'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3303546401'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1G8ZK5271TZ187073'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '3GSCL33P48S726712'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3303546401'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '3GSCL33P48S726712'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = 'WBSBL93414PN57783'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3135525555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = 'WBSBL93414PN57783'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FTFW1RG4KFD17343'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3135525555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FTFW1RG4KFD17343'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '6T09T123243'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3135525555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '6T09T123243'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FMSK7DH0LGA16718'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(18500, 1, '2021-05-10 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '3135525555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FMSK7DH0LGA16718'), (SELECT TOP 1 Id FROM AspNetUsers))
END
IF NOT EXISTS(SELECT TOP 1 * FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '2T3W1RFV0LW073156'))
BEGIN
INSERT INTO Sale(SalesPrice, SalesType, SaleDate, CustomerId, VehicleId, UserId)
VALUES(40000, 2, '2021-04-19 01:42:09.150', (SELECT TOP 1 CustomerId FROM Customer WHERE Phone = '2162555555'), (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '2T3W1RFV0LW073156'), (SELECT TOP 1 Id FROM AspNetUsers))
END

--=========================================================
--Vehicle SalesId Inserts
--=========================================================
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '3TMDZ5BNXJM050402' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '3TMDZ5BNXJM050402'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '3TMDZ5BNXJM050402')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '5YFBURHE5GP407605' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '5YFBURHE5GP407605'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '5YFBURHE5GP407605')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = 'P6FH349761' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = 'P6FH349761'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = 'P6FH349761')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1FAFP42XX1F140942' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FAFP42XX1F140942'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FAFP42XX1F140942')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '8033207270' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '8033207270'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '8033207270')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1G8ZH5286XZ294973' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1G8ZH5286XZ294973'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1G8ZH5286XZ294973')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1G8ZK5271TZ187073' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1G8ZK5271TZ187073'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1G8ZK5271TZ187073')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '3GSCL33P48S726712' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '3GSCL33P48S726712'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '3GSCL33P48S726712')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = 'WBSBL93414PN57783' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = 'WBSBL93414PN57783'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = 'WBSBL93414PN57783')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1FTFW1RG4KFD17343' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FTFW1RG4KFD17343'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FTFW1RG4KFD17343')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '6T09T123243' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '6T09T123243'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '6T09T123243')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '1FMSK7DH0LGA16718' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FMSK7DH0LGA16718'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '1FMSK7DH0LGA16718')
END
IF EXISTS(SELECT TOP 1 * FROM Vehicles WHERE VIN = '2T3W1RFV0LW073156' AND SalesId IS NULL)
BEGIN
UPDATE Vehicles SET SalesId = (SELECT TOP 1 SalesId FROM Sale WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '2T3W1RFV0LW073156'))
WHERE VehicleId = (SELECT TOP 1 VehicleId FROM Vehicles WHERE VIN = '2T3W1RFV0LW073156')
END
--=========================================================
--Special Inserts
--=========================================================
IF NOT EXISTS(SELECT TOP 1 * FROM Special WHERE ImageFilePath = '/images/inventory-2948f242-f640-4871-9f02-14d24731c498.jpg')
BEGIN
INSERT INTO Special(SpecialTitle, SpecialMessage, ImageFilePath)
VALUES('Big Ol BEAUUUTY','BRAND NEW NEVER BEFORE SEEN','/images/inventory-2948f242-f640-4871-9f02-14d24731c498.jpg')
END
IF NOT EXISTS(SELECT TOP 1 * FROM Special WHERE ImageFilePath = '/images/inventory-a5ec48ac-129f-4aa0-b5dc-84e744fc4d04.jpg')
BEGIN
INSERT INTO Special(SpecialTitle, SpecialMessage, ImageFilePath)
VALUES('6X THE FUN FOR HALF THE PRICE','OH LORDY WOULD YOU LOOK AT THAT!','/images/inventory-a5ec48ac-129f-4aa0-b5dc-84e744fc4d04.jpg')
END
IF NOT EXISTS(SELECT TOP 1 * FROM Special WHERE ImageFilePath = '/images/inventory-aa88a673-3150-457b-abb6-6c2708916171.jpg')
BEGIN
INSERT INTO Special(SpecialTitle, SpecialMessage, ImageFilePath)
VALUES('MAMA WARNED ME ABOUT A CAR LIKE THIS','SHOW OFF YOUR WILD SIDE IN THIS BABY','/images/inventory-aa88a673-3150-457b-abb6-6c2708916171.jpg')
END