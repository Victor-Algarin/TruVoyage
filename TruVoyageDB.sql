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
	[VehicleType]			[varchar](50)			NOT NULL,
	[Make]				[varchar](50)			NOT NULL,
	[Model]				[varchar](50)			NOT NULL,
	[ModelYear]			[int]					NOT NULL,
	[Color]				[varchar](50)			NOT NULL,
	[Mileage]			[int]					NOT NULL DEFAULT 000000,
	[EngineSize]		[varchar](20)			NOT NULL,
	[PassengerCapacity]	[int]					NOT NULL,
	[Available]			[bit]					NOT NULL DEFAULT 1,
	[NeedsMaintenance]	[bit]					NOT NULL DEFAULT 0,
	[LastMaintenanceDate][date]					NULL,
	[MaintenancePersonnelID][int]				NULL,
	[PurchasePrice]		[decimal](7,2)			NOT NULL
	
	CONSTRAINT [pk_VIN] PRIMARY KEY ([VIN] ASC)
)
GO

print '' print '*** Inserting Vehicle Sample Records ***'
GO
INSERT INTO [dbo].[Vehicle]
		([VIN], [VehicleType], [Make], [Model], [ModelYear], [Color], [Mileage], [EngineSize], [PassengerCapacity], [PurchasePrice])
	VALUES
		("5FSH67562CGRFH345", 'Car', "Dodge", 'Charger Scat Pack', 2018, "Black", 000185, "V8", 4, 37000.00),
		("TY82AS483416SSSF8", 'Car', "Toyota", 'Camry XSE V6', 2019, "White", 002085, "V6", 4, 34600.00)
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

