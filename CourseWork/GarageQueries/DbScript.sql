CREATE DATABASE "Garage"
USE "Garage"

CREATE TABLE "Role"
(
	Id INT PRIMARY KEY IDENTITY,
	RoleName NVARCHAR(20) NOT NULL
);

CREATE TABLE "User"
(
	Id INT PRIMARY KEY IDENTITY,
	RoleId INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Phone NVARCHAR(50) NOT NULL,
	UserPassword NVARCHAR(50) NOT NULL,
	VehicleId INT (50) NULL,
	FOREIGN KEY (RoleId) References "Role",
	FOREIGN KEY (VehicleId) References "Vehicle" 
);

CREATE TABLE "Vehicle"
(
	Id INT PRIMARY KEY IDENTITY,
	Brand NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL
);

CREATE TABLE "Fuel"
(
	Id INT PRIMARY KEY IDENTITY,
	Brand NVARCHAR(50) NOT NULL,
	FuelDescription NVARCHAR(100) NOT NULL,
	Quantity NVARCHAR(50) NOT NULL,
);

CREATE TABLE "Status"
(
	Id INT PRIMARY KEY IDENTITY,
	StatusName NVARCHAR(20) NOT NULL
);

CREATE TABLE "Order"
(
	Id INT PRIMARY KEY IDENTITY,
	DriverId INT NOT NULL,
	CustomerId INT NOT NULL,
	FuelId INT NOT NULL,
	StatusId INT NOT NULL,
	OrderAddress NVARCHAR(100) NOT NULL,
	OrderDescription NVARCHAR(20) NOT NULL,
	ApplicationTime DateTime NOT NULL,
	LeadTime DateTime NOT NULL,
	FOREIGN KEY (DriverId) References "User",
	FOREIGN KEY (CustomerId) References "User",
	FOREIGN KEY (FuelId) References "Fuel",
	FOREIGN KEY (StatusId) References "Status"
);

INSERT INTO Role(RoleName) VALUES('driver');
INSERT INTO Role(RoleName) VALUES('customer');
INSERT INTO Role(RoleName) VALUES('admin');

INSERT INTO Status(StatusName) VALUES('Open');
INSERT INTO Status(StatusName) VALUES('In progress');
INSERT INTO Status(StatusName) VALUES('Closed');