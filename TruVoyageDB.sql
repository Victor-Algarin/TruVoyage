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

print '' print '*** Creating Vehicle Table ***'
GO
/* *** Object: Table[dbo].[Vehicle]*** */

CREATE TABLE [dbo].[Vehicle](
	[VIN]				[varchar](300) 			NOT NULL,
	[VehicleType]		[varchar](50)			NOT NULL,
	[Make]				[varchar](50)			NOT NULL,
	[Model]				[varchar](50)			NOT NULL,
	[ModelYear]			[int]					NOT NULL,
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

print '' print '*** Inserting Vehicle Sample Records ***'
GO
INSERT INTO [dbo].[Vehicle]
		([VIN], [VehicleType], [Make], [Model], [ModelYear], [Color], [Mileage], [EngineSize], [PassengerCapacity], [PurchasePrice],[Available], [NeedsMaintenance])
	VALUES
		("5FSH67562CGRFH345", 'Car', "Dodge", 'Charger Scat Pack', 2018, "Black", 000185, "V8", 4, 37000.00, 1, 0),
		("TY82AS483416SSSF8", 'Car', "Toyota", 'Camry XSE V6', 2019, "White", 002085, "V6", 4, 34600.00, 1, 0),
		("SADGF456S45HFHS34Q4", 'SUV', "Land Rover", "Range Rover", 2019, "Silver", 000028, "V8", 5, 80559.96, 0, 1)

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
		@VehicleType		[varchar](50),
		@Make				[varchar](50),
		@Model				[varchar](50),
		@ModelYear			[int],
		@Color				[varchar](50),
		@Mileage			[int],
		@EngineSize			[varchar](20),
		@PassengerCapacity	[int],
		@PurchasePrice		[decimal](7,2)	
	)
AS
	BEGIN
		INSERT INTO [dbo].[Vehicle]
			([VIN], [VehicleType], [Make], [Model], [ModelYear],
				[Color], [Mileage], [EngineSize], [PassengerCapacity], [PurchasePrice])
		VALUES
			(@VIN, @VehicleType, @Make, @Model, @ModelYear, @Color, @Mileage, @EngineSize, @PassengerCapacity, @PurchasePrice)
		RETURN @@ROWCOUNT
	END
GO

print '' print '*** Creating VehicleReservation Table ***'
GO
/* ***Object: Table[dbo].[VehicleReservation]*** */

CREATE TABLE [dbo].[VehicleReservation](
	[ReservationID]		[int]IDENTITY(100000,1)	NOT NULL,	
	[RatePerDay]		[decimal](7,2)			NOT NULL,
	[ReservationStart]	[date]					NOT NULL,
	[ReservationEnd]	[date]					NOT NULL,
	[CustomerID]		[int]					NOT NULL,
	[VIN]				[int]					NOT NULL,
	[TotalRegisteredClients] [int]				NOT NULL,
	
	CONSTRAINT [pk_ReservationID] PRIMARY KEY ([ReservationID] ASC)
)
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
	[Phone]				[int]					NOT NULL,
	[Email]				[varchar](300)			NOT NULL,
	[PartySize]			[int]					NOT NULL,
	[DriversLicense]	[varchar](30)			NOT NULL
	
	CONSTRAINT [pk_CustomerID] PRIMARY KEY ([CustomerID] ASC)
)
GO

/* print '' print '**** Creating Movies GenreID Foreign Key ****'
GO
ALTER TABLE [dbo].[Movies] WITH NOCHECK
	ADD CONSTRAINT [fk_GenreID] FOREIGN KEY ([GenreID])
	REFERENCES [dbo].[Genre] ([GenreID])
	ON UPDATE CASCADE
GO
 */



