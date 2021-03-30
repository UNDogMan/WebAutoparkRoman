CREATE TABLE [VECHICLE_TYPES](
	[ID] int constraint [VECHICLE_TYPES_PK] primary key identity(1, 1),
	[TYPE_NAME] nvarchar(100),
	[TAX_COEFFICIENT] float
);
GO

CREATE TABLE [VECHICLES](
	[ID] int constraint [VECHICLE_PK] primary key identity(1, 1),
	[VEHICLE_TYPE] int constraint [VECHICLE_VECHICLE_TYPE_FK] foreign key
		references [VECHICLE_TYPES]([ID]),
	[MODEL_NAME] nvarchar(100),
	[REGISTRATION_NUMBER] nvarchar(20),
	[WEIGHT] int,
	[MANUFACTURE_YEAR] int,
	[MAILEAGE] int,
	[COLOR] int,
	[TANK_CAPACITY] float
);
GO

CREATE TABLE [ORDERS](
	[ID] int constraint [ORDERS_PK] primary key identity(1, 1),
	[VECHICLE_ID] int constraint [ORDERS_VEHICLE_FK] foreign key
		references [VECHICLES]([ID])
);
GO

CREATE TABLE [PARTS](
	[ID] int constraint [PARTS_PK] primary key identity(1, 1),
	[PART_NAME] nvarchar(100)
);
GO

CREATE TABLE [ORDERS_PARTS](
	[ID] int constraint [ORDERS_PARTS_PK] primary key identity(1, 1),
	[ID_PART] int constraint [ORDERS_PARTS_PARTS_FK] foreign key
		references [PARTS]([ID]),
	[ID_ORDER] int constraint [ORDERS_PARTS_ORDERS_FK] foreign key
		references [ORDERS]([ID]),
	[PART_COUNT] int
);
GO