IF EXISTS (SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'TruVoyageDB')
BEGIN
	DROP DATABASE TruVoyageDB
	print '' print '*** dropping database TruVoyageDB ***'
END
GO

CREATE DATABASE TruVoyageDB
GO

print '' print '*** using database TruVoyageDB ***' 
GO
USE [TruVoyageDB]
GO

print '' print'*** Creating VehicleType Table ***'
GO
/* *** Object: Table[dbo].[Vehicle]*** */

CREATE TABLE [dbo].[VehicleType](
	[VehicleTypeID]			[varchar](50)			NOT NULL
	CONSTRAINT [pk_VehicleTypeID] PRIMARY KEY ([VehicleTypeID] ASC)
)
GO

print '' print '*** Inserting VehicleType Sample Records ***'
GO
INSERT INTO [dbo].[VehicleType]
		([VehicleTypeID])
	VALUES
		("Car"),
		("SUV"),
		("Truck"),
		("Van"),
		("Motorcycle"),
		("Bicycle"),
		("Boat")
GO

print '' print'*** Creating VehicleClass Table ***'
GO
/* *** Object: Table[dbo].[VehicleClass]*** */

CREATE TABLE [dbo].[VehicleClass](
	[VehicleClassID]			[varchar](50) 			NOT NULL
	CONSTRAINT [pk_VehicleClassID] PRIMARY KEY ([VehicleClassID] ASC)
)
GO

print '' print '*** Inserting VehicleClass Sample Records ***'
GO
INSERT INTO [dbo].[VehicleClass]
		([VehicleClassID])
	VALUES
		("Luxury"),
		("Premium"),
		("Mid-Size"),
		("Compact"),
		("Full-Size"),
		("Touring"),
		("MotorSport"),
		("Off-Road")
GO

print '' print '*** Creating Vehicle Table ***'
GO
/* *** Object: Table[dbo].[Vehicle]*** */

CREATE TABLE [dbo].[Vehicle](
	[VIN]				[varchar](300) 			NOT NULL,	
	[Make]				[varchar](50)			NOT NULL,
	[Model]				[varchar](50)			NOT NULL,
	[ModelYear]			[int]					NOT NULL,
	[VehicleTypeID]		[varchar](50)			NOT NULL,
	[VehicleClassID]	[varchar](50)			NOT NULL,
	[Color]				[varchar](50)			NOT NULL,
	[Mileage]			[int]					NOT NULL,
	[EngineSize]		[varchar](20)			NOT NULL,
	[PassengerCapacity]	[int]					NOT NULL,
	[PurchasePrice]		[decimal](7,2)			NOT NULL,		
	[MaintenancePersonnelID][int]				DEFAULT -1,
	[LastMaintenanceDate][date]					DEFAULT "01/01/2001",
	[Available]			[bit]					NOT NULL DEFAULT 1,
	[NeedsMaintenance]	[bit]					NOT NULL DEFAULT 0
	
	CONSTRAINT [pk_VIN] PRIMARY KEY ([VIN] ASC)
)
GO

print '' print '*** Creating Vehicle VehicleTypeID foreign key ***'
GO
ALTER TABLE [dbo].[Vehicle]  WITH NOCHECK 
	ADD CONSTRAINT [FK_VehicleTypeID] FOREIGN KEY([VehicleTypeID])
	REFERENCES [dbo].[VehicleType] ([VehicleTypeID])
	ON UPDATE CASCADE
GO 

print '' print '*** Creating Vehicle VehicleClassID foreign key ***'
GO
ALTER TABLE [dbo].[Vehicle]  WITH NOCHECK 
	ADD CONSTRAINT [FK_VehicleClassID] FOREIGN KEY([VehicleClassID])
	REFERENCES [dbo].[VehicleClass] ([VehicleClassID])
	ON UPDATE CASCADE
GO  

print '' print '*** Inserting Vehicle Sample Records ***'
GO
INSERT INTO [dbo].[Vehicle]
		([VIN], [Make], [Model], [ModelYear], [VehicleTypeID], [VehicleClassID], [Color], 
		[Mileage], [EngineSize], [PassengerCapacity], [PurchasePrice],[Available], [NeedsMaintenance])
	VALUES
		("5FSH67562CGRFH345", "Dodge", 'Charger Scat Pack', 2018, "Car", "Premium", "Black", 000185, "V8", 4, 37000.00, 1, 0),
		("TY82AS483416SSSF8", "Toyota", 'Camry XSE V6', 2019, "Car", "Mid-Size", "White", 002085, "V6", 4, 34600.00, 1, 0),
		("SADGF456S45HFHS34Q4", "Land Rover", "Range Rover", 2019, "SUV", "Luxury", "Silver", 000028, "V8", 5, 80559.96, 0, 1)
GO 

print '' print '**** Creating sp_retrieve_all_vehicles ****'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_vehicles]
AS 
	BEGIN
		SELECT *
		FROM Vehicle
	END
GO

print '' print '**** Creating sp_retrieve_all_available_vehicles ****'
GO
CREATE PROCEDURE [dbo].[sp_retrieve_all_available_vehicles]
AS 
	BEGIN
		SELECT * 
		FROM Vehicle
		WHERE Available = 1
	END
GO

print '' print '**** Creating sp_update_vehicle_maintenance_records ****'
GO
CREATE PROCEDURE [dbo].[sp_update_vehicle_maintenance_records]
	(
	@VIN 						[varchar](300),
	
	@OldMileage 				[int],
	@OldAvailable 				[bit], 
	@OldNeedsMaintenance 		[bit],
	@OldMaintenancePersonnelID 	[int],
	@OldLastMaintenanceDate 	[date],
	
	@NewMileage 				[int],
	@NewAvailable 				[bit], 
	@NewNeedsMaintenance 		[bit],
	@NewMaintenancePersonnelID 	[int],
	@NewLastMaintenanceDate 	[date]
	)
AS	
	BEGIN
		UPDATE Vehicle
			SET Mileage = @NewMileage,
				Available = @NewAvailable,
				NeedsMaintenance = @NewNeedsMaintenance,
				MaintenancePersonnelID = @NewMaintenancePersonnelID,
				LastMaintenanceDate = @NewLastMaintenanceDate
			WHERE VIN = @VIN
			AND Mileage = @OldMileage
			AND Available = @OldAvailable
			AND NeedsMaintenance = @OldNeedsMaintenance
			AND MaintenancePersonnelID = @OldMaintenancePersonnelID
			AND LastMaintenanceDate = @OldLastMaintenanceDate 
		RETURN @@ROWCOUNT
	END
GO
 
print '' print '**** Creating sp_add_vehicle_to_inventory ****'
GO
CREATE PROCEDURE [dbo].[sp_add_vehicle_to_inventory]
	(
		@VIN 				[varchar](300),		
		@Make				[varchar](50),
		@Model				[varchar](50),
		@ModelYear			[int],
		@VehicleTypeID		[varchar](50),
		@VehicleClassID		[varchar](50),
		@Color				[varchar](50),
		@Mileage			[int],
		@EngineSize			[varchar](20),
		@PassengerCapacity	[int],
		@PurchasePrice		[decimal](7,2)	
	)
AS
	BEGIN
		INSERT INTO [dbo].[Vehicle]
			([VIN], [Make], [Model], [ModelYear], [VehicleTypeID], [VehicleClassID], 
			[Color], [Mileage], [EngineSize], [PassengerCapacity], [PurchasePrice])
		VALUES
			(@VIN, @Make, @Model, @ModelYear, @VehicleTypeID, @VehicleClassID, @Color, @Mileage, @EngineSize, @PassengerCapacity, @PurchasePrice)
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating Location Table ***'
GO
/* ***Object: Table[dbo].[Location]*** */

CREATE TABLE [dbo].[Location](
	[LocationID]		[int]IDENTITY(100000,1)	NOT NULL,	
	[Address]			[varchar](300)			NOT NULL,
	[City]				[varchar](300)			NOT NULL,
	[State]				[varchar](50)			NOT NULL,
	[Zip]				[int]					NOT NULL,
	[Country]			[varchar](200)			NOT NULL DEFAULT "United States",
	
	CONSTRAINT [pk_LocationID] PRIMARY KEY ([LocationID] ASC)
)
GO

print '' print '*** Inserting Location Sample Records ***'
GO
INSERT INTO [dbo].[Location]
		([Address], [City], [State], [Zip])
	VALUES
		("1665 Union St", "Brooklyn", "NY", 11213),
		("3638 College Dr", "Oceanside", "CA", 92056),
		("606 Glynn Springs Dr", "Williamsburg", "VA", 23188)
GO

print '' print '*** Creating RentalCompany Table ***'
GO
/* ***Object: Table[dbo].[RentalCompany]*** */

CREATE TABLE [dbo].[RentalCompany](
	[CompanyID]			[int]IDENTITY(100000,1)	NOT NULL,	
	[CompanyName]		[varchar](100)			NOT NULL,
	[LocationID]		[varchar](300)			NOT NULL
	
	CONSTRAINT [pk_CompanyID] PRIMARY KEY ([CompanyID] ASC)
)
GO
print '' print '*** Inserting RentalCompany Sample Records ***'
GO
INSERT INTO [dbo].[RentalCompany]
		([CompanyName], [LocationID])
	VALUES
		("Wertz", 100000),
		("Trivago Now", 100001),
		("Jarvis", 100002)
GO

print '' print '*** Creating Customer Table ***'
GO
/* ***Object: Table[dbo].[Customer]*** */

CREATE TABLE [dbo].[Customer](
	[CustomerID]		[int]IDENTITY(100000,1)	NOT NULL,	
	[FirstName]			[varchar](50)			NOT NULL,
	[LastName]			[varchar](50)			NOT NULL,
	[DOB]				[date]					NOT NULL,
	[StreetAddress]		[varchar](250)			NOT NULL,
	[City]				[varchar](50)			NOT NULL,
	[State]				[varchar](2)			NOT NULL,
	[Zip]				[int]					NOT NULL,
	[Phone]				[varchar](14)			NOT NULL,
	[Email]				[varchar](300)			NOT NULL,
	[PartySize]			[int]					NOT NULL,
	[DriversLicense]	[varchar](30)			DEFAULT "N/A"
	
	CONSTRAINT [pk_CustomerID] PRIMARY KEY ([CustomerID] ASC)
)
GO

print '' print '*** Inserting Customer Sample Records ***'
GO
INSERT INTO [dbo].[Customer]
		([FirstName], [LastName], [DOB], [StreetAddress], [City], [State], [Zip], [Phone], [Email], [PartySize], [DriversLicense])
	VALUES
		("Jimmy", "Faslane", "05/17/1975", "404 FU Lane", "Eat My", "AZ", 55545, 3191234567, "no@no.com", 2, "123CC4567"),
		("Wyatt", "Eauyp", "07/11/1991", "503 Error Dr", "FixYo Shiz", "NY", 11213, 3655785555, "yes@yes.com", 4, "894AS555")
GO

print '' print '*** Creating VehicleReservation Table ***'
GO
/* ***Object: Table[dbo].[VehicleReservation]*** */

CREATE TABLE [dbo].[VehicleReservation](
	[ReservationID]		[int]IDENTITY(100000,1)	NOT NULL,	
	[CustomerID]		[int]					NOT NULL,		
	[CompanyID]			[int]					NOT NULL,
	[VIN]				[varchar](300)			NOT NULL,
	[RatePerDay]		[decimal](7,2)			NOT NULL,	
	[ReservationStart]	[date]					NOT NULL,
	[ReservationEnd]	[date]					NOT NULL,
	[PickUpTime]		[time]					NOT NULL,
	[DropOffTime]		[time]					NOT NULL,	
	[PickUpLocation]	[varchar](300)			NOT NULL,
	[DropOffLocation]	[varchar](300)			NOT NULL
	
	CONSTRAINT [pk_ReservationID] PRIMARY KEY ([ReservationID] ASC)
)
GO

/* print '' print '*** Inserting VehicleReservation Sample Records ***'
GO
INSERT INTO [dbo].[VehicleReservation]
		([CustomerID], [CompanyID], [VIN], [RatePerDay], [ReservationStart], [ReservationEnd], [PickUpTime], [DropOffTime], [PickUpLocation], [DropOffLocation])
	VALUES
		(100000, 100000, "5FSH67562CGRFH345", 46.50, "01/09/2019","01/10/2019", "13:30:00", "19:00:00",,100000)
GO */

-- SELECT [RentalCompany].[LocationID] FROM [RentalCompany] INNER JOIN [Location] ON [RentalCompany].[LocationID] = [Location].[LocationID],


-- PROBABLY NEED TO MAKE A LOOK UP TABLE, OR JUST DO THIS IN A STORED PROCEDURE
print '' print '*** Inserting VehicleReservation Sample Records ***'
GO
INSERT INTO [dbo].[VehicleReservation]
		([CustomerID], [CompanyID], [VIN], [RatePerDay], [ReservationStart], [ReservationEnd], [PickUpTime], [DropOffTime], [PickUpLocation], [DropOffLocation]) 
	VALUES
		(100000, 100000, "5FSH67562CGRFH345", 46.50, "01/09/2019","01/10/2019", "13:30:00", "19:00:00")
INSERT INTO [dbo].[VehicleReservation]
	([PickUpLocation], [DropOffLocation])
	SELECT RentalCompany.LocationID, RentalCompany.LocationID
	FROM RentalCompany
	INNER JOIN VehicleReservation ON VehicleReservation.CompanyID = RentalCompany.CompanyID
GO

/* print '' print '*** Inserting VehicleReservation Location Sample Records ***'
GO
INSERT INTO [dbo].[VehicleReservation]([PickUpLocation], [DropOffLocation])
	SELECT [LoctionID], [LocationID]
	FROM [dbo].[RentalCompany]
	WHERE [RentalCompany].[CompanyID] = [VehicleReservation].[CompanyID]
GO */


print '' print '*** Creating VehicleReservation CustomerID foreign key ***'
GO
ALTER TABLE [dbo].[VehicleReservation]  WITH NOCHECK 
	ADD CONSTRAINT [FK_CustomerID] FOREIGN KEY([CustomerID])
	REFERENCES [dbo].[Customer] ([CustomerID])
	ON UPDATE CASCADE
GO 

print '' print '*** Creating VehicleReservation CompanyID foreign key ***'
GO
ALTER TABLE [dbo].[VehicleReservation]  WITH NOCHECK 
	ADD CONSTRAINT [FK_CompanyID] FOREIGN KEY([CompanyID])
	REFERENCES [dbo].[RentalCompany] ([CompanyID])
	ON UPDATE CASCADE
GO 

print '' print '*** Creating VehicleReservation VIN foreign key ***'
GO
ALTER TABLE [dbo].[VehicleReservation]  WITH NOCHECK 
	ADD CONSTRAINT [FK_VIN] FOREIGN KEY([VIN])
	REFERENCES [dbo].[Vehicle] ([VIN])
	ON UPDATE CASCADE
GO 

