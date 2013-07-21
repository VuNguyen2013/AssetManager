create database AssetManager

create table AssetGroupType
(
	Id varchar(10) primary key,
	Name nvarchar(30) not null
)

create table AssetGroup
(
	Id varchar(10) primary key,
	Name nvarchar(50) not null,
	AssetGroupTypeId varchar(10) foreign key references AssetGroupType(Id)
)

create table Capital
(
	Id varchar(10) primary key,
	Name nvarchar(50) not null,
	[Note] nvarchar(50)
)

create table DepartmentUsed
(
	Id varchar(10) primary key,
	Name nvarchar(50) not null,
	Phone varchar(15),
	Representative nvarchar(50) not null,
	[Address] nvarchar(50),
)

create table Unit
(
	Id varchar(10) primary key,
	Name nvarchar(50) not null,
	Note nvarchar(50)		
)

create table Asset
(
	Id varchar(10) primary key,
	Name nvarchar(50) not null,
	AssetGroupId varchar(10) foreign key references AssetGroup(Id),
	UnitId varchar(10) foreign key references Unit(Id),
	Amount int not null,
	CounPro nvarchar(50) not null,
	YearPro int not null,
	DepartmentUsedId varchar(10) foreign key references DepartmentUsed(Id),
	TotalPrice bigint not null default 0,
	BudgetPrice bigint not null default 0,
	OwnPrice bigint not null default 0,
	VenturePrice bigint not null default 0,
	AnotherPrice bigint not null default 0,
	TotalDepreciation bigint not null default 0,
	BudgetDepreciation bigint not null default 0,
	OwnDepreciation bigint not null default 0,
	VentureDepreciation bigint not null default 0,
	AnotherDepreciation bigint not null default 0,
	BudgetRemain bigint not null default 0,
	OwnRemain bigint not null default 0,
	VentureRemain bigint not null default 0,
	AnotherRemain bigint not null default 0,
	TotalReamain bigint not null default 0,
	UpDownCode varchar(10),
	InputDateTime datetime not null default getdate()
)

create table [Partner]
(
	Id varchar(10) primary key,
	Name nvarchar(50) not null,
	[Address] nvarchar(50),
	Phone varchar(15),
	TaxCode varchar(10)
)

create table UpDownReason
(
	Id varchar(10) primary key,
	Name nvarchar(50) not null,
	[Type] nvarchar(10),
)

create table AssetLiquidation
(
	Id varchar(10) primary key,
	AssetId varchar(10) foreign key references Asset(Id),
	Amount int not null,
	DepartmentUsedId varchar(10) foreign key references DepartmentUsed(Id),
	[LiDateTime] datetime not null default getdate(),
	LiPrice bigint not null default 0
)

create table RepairAsset
(
	Id varchar(10) primary key,
	AssetId varchar(10) foreign key references Asset(Id),
	DepartmentUsedId varchar(10) foreign key references DepartmentUsed(Id),
	Reason nvarchar(50) not null,
	[PartnerId] varchar(10) foreign key references [Partner](Id),
	[RepairDate] Date not null default getdate(),
	[Fee] bigint not null default 0,
	[Address] nvarchar(50)
)

create table WarrantyAsset
(
	Id varchar(10) primary key,
	AsssetId varchar(10) foreign key references Asset(Id),
	DepartmentUsedId varchar(10) foreign key references DepartmentUsed(Id),
	[PartnerId] varchar(10) foreign key references [Partner](Id),
	WarDateTime datetime not null default getdate(),
	DeadlineWar datetime,
	[Address] nvarchar(50) not null,
	PersonWar nvarchar(50)
)
