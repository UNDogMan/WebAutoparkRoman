create table [VechicleTypes](
	[ID] int constraint [VechicleTypesPK] primary key identity(1, 1),
	[TypeName] nvarchar(100),
	[TaxCoefficient] float
);
go

create table [Vehicles](
	[ID] int constraint [VehiclesPK] primary key identity(1, 1),
	[VehicleType] int constraint [VehiclesVechicleTypesFK] foreign key
		references [VechicleTypes]([ID]),
	[ModelName] nvarchar(100),
	[RegistrationNumber] nvarchar(20),
	[Weight] int,
	[ManufactureYear] int,
	[Maileage] int,
	[Color] int,
	[TankCapacity] float
);
go

create table [Orders](
	[ID] int constraint [OrdersPK] primary key identity(1, 1),
	[VehicleID] int constraint [OrdersVehiclesFK] foreign key
		references [Vehicles]([ID])
);
go

create table [Parts](
	[ID] int constraint [PartsPK] primary key identity(1, 1),
	[PartName] nvarchar(100)
);
GO

create table [OrdersParts](
	[ID] int constraint [OrdersPartsPK] primary key identity(1, 1),
	[PartID] int constraint [OrdersPartsPartsFK] foreign key
		references [PARTS]([ID]),
	[OrderID] int constraint [OrdersPartsOrdersFK] foreign key
		references [ORDERS]([ID]),
	[PartCount] int
);
GO