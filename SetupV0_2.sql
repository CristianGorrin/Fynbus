if (not exists (select name from master.dbo.sysdatabases where(name = '[Fynbus]' or name = 'Fynbus'))) 
	create database [Fynbus]
go

set quoted_identifier off;
go
use [Fynbus];
go
if schema_id(N'dbo') is null execute(N'CREATE SCHEMA [dbo]');
go

-- Dropping existing FOREIGN KEY constraints
if object_id(N'[dbo].[FK_OwnedBy_Users_ID]', 'F') is not null
    alter table [dbo].[BasicInformation] drop constraint [FK_OwnedBy_Users_ID];
go
if object_id(N'[dbo].[FK_WagonDetails_OwnedBy_Users_ID]', 'F') is not null
    alter table [dbo].[WagonDetails] DROP constraint [FK_WagonDetails_OwnedBy_Users_ID];
go
if object_id(N'[dbo].[FK_OffersformSingleVehicle_FK_BasicInformation]', 'F') is not null
    alter table [dbo].[Offersform_SingleVehicle] DROP constraint [FK_OffersformSingleVehicle_FK_BasicInformation];
go
if object_id(N'[dbo].[FK_OffersformSingleVehicle_FK_Price]', 'F') is not null
    alter table [dbo].[Offersform_SingleVehicle] DROP constraint [FK_OffersformSingleVehicle_FK_Price];
go
if object_id(N'[dbo].[FK_OffersformSingleVehicle_FK_WagonDetails]', 'F') is not null
    alter table [dbo].[Offersform_SingleVehicle] DROP constraint [FK_OffersformSingleVehicle_FK_WagonDetails];
go
if object_id(N'[dbo].[FK_OwnedBy_FK_Users_ID]', 'F') is not null
    alter table [dbo].[Offersform_SingleVehicle] DROP constraint [FK_OwnedBy_FK_Users_ID];
go
if object_id(N'[dbo].[FK_UsersID_FK_Users_ID]', 'F') is not null
    alter table [dbo].[Token] DROP constraint [FK_UsersID_FK_Users_ID];
go
if object_id(N'[dbo].[FK_WagonDetails_FK_HomeWagon]', 'F') is not null
    alter table [dbo].[WagonDetails] DROP constraint [FK_WagonDetails_FK_HomeWagon];
go
if object_id(N'[dbo].[FK_WagonDetails_FK_WagonDetails]', 'F') is not null
    alter table [dbo].[WagonDetails] DROP constraint [FK_WagonDetails_FK_WagonDetails];
go
if object_id(N'[dbo].[FK_Weekdays_FK_PricePlan]', 'F') is not null
    alter table [dbo].[Price] DROP constraint [FK_Weekdays_FK_PricePlan];
go
if object_id(N'[dbo].[FK_WeekdaysEvening_FK_PricePlan]', 'F') is not null
    alter table [dbo].[Price] DROP constraint [FK_WeekdaysEvening_FK_PricePlan];
go
if object_id(N'[dbo].[FK_WeekendersHelligdage_FK_PricePlan]', 'F') is not null
    alter table [dbo].[Price] DROP constraint [FK_WeekendersHelligdage_FK_PricePlan];
go

-- Dropping existing tables
if object_id(N'[dbo].[Offersform_SingleVehicle]', 'U') is not null
    drop table [dbo].[Offersform_SingleVehicle];
go
if object_id(N'[dbo].[Price]', 'U') is not null
    drop table [dbo].[Price];
go
if object_id(N'[dbo].[PricePlan]', 'U') is not null
    drop table [dbo].[PricePlan];
go
if object_id(N'[dbo].[Token]', 'U') is not null
    drop table [dbo].[Token];
go
if object_id(N'[dbo].[Users]', 'U') is not null
    drop table [dbo].[Users];
go
if object_id(N'[dbo].[WagonDetails]', 'U') is not null
    drop table [dbo].[WagonDetails];
go
if object_id(N'[dbo].[BasicInformation]', 'U') is not null
    drop table [dbo].[BasicInformation];
go
if object_id(N'[dbo].[HomeWagon]', 'U') is not null
    drop table [dbo].[HomeWagon];
go

--Udbud af FV3 - FlexVariabel november 2013
--Tilbudsblanket, enkeltvogn.
create table Offersform_SingleVehicle
(
ID int identity(0,1) primary key not null,
BasicInformation int not null, --FK_BasicInformation
WagonDetails int not null, --FK_WagonDetails
Price int not null, --FK_Price
AdditionalInformation nvarchar(MAX),
OwnedBy int not null, --FK_OwnedBy_Users_ID and INDEX_Offersform_SingleVehicle_OwnedBy
);

create table BasicInformation
(
ID int identity(0,1) primary key not null,
Name nvarchar(100) not null,
CVR int not null,
NameSecondary nvarchar(100),
OwnedBy int not null, --FK_Users_ID and INDEX_BasicInformation_OwnedBy
);

create table WagonDetails
(
ID int identity(0,1) primary key not null,
Guarantee int, --FK_WagonDetails
RegistrationLetters nvarchar(2), --CH_WagonDetails_RegistrationLetters => 2 letters 
RegistrationNumbers int, --CH_WagonDetails_RegistrationNumbers => 5 digits
PhoneNumber int not null,
VehicleType tinyint not null, --CH_WagonDetails_VehicleType from 1 too 6 (6 is with a stair machine) 
StairMachine tinyint, --CH_WagonDetails_VehicleType if is 6 (120 or 160 kg.)
Highchairs tinyint, --CH_WagonDetails_Highchairs  0 => 0 - 13 kg; 1 => 9 - 18 kg; 2 => 9 - 36 kg; 3 => 15 - 36 kg, 4 => Integreret i sæde
HomeWagon int, --FK_HomeWagon
OwnedBy int not null --FK_WagonDetails_OwnedBy_Users_ID
);

create table HomeWagon
(
ID int identity(0,1) primary key not null,
StreetName nvarchar(100) not null,
StreetNumber smallint not null,
ZipCode smallint not null,
City nvarchar(100) not null,
Municipality nvarchar(200) not null,
);

create table Price
(
ID int identity(0,1) primary key not null,
Weekdays int unique not null, --FK_PricePlan (Mon-Fri 6:00 to 18:00)
WeekdaysEvening int unique not null, --FK_PricePlan (Mon-Fri 18:00 to 6:00)
WeekendersHelligdage int unique not null, --FK_PricePlan (Weekends and holidays)
StairMachine decimal(6,2) 
);

create table PricePlan
(
ID int identity(0,1) primary key not null,
SetUpFee decimal(6,2) not null,
HourlyRate decimal(6,2) not null,
HourlyDdownTime decimal(6,2) not null
);

create table Users
(
ID int identity(0,1) primary key not null,
Account nvarchar(50), --INDEX
[Password] nvarchar(50),
Email nvarchar(80),
UsersAccessLevels tinyint
);

create table Token
(
ID int identity(0,1) primary key not null,
UsersID int not null, --FK_Users_ID
TokenString nvarchar(450) unique not null, --INDEX
CreateDate date not null,
);

--INDEX
create index Index_Users_Account
on Users(Account);

create index Index_Token_TokenString
on Token(TokenString);

create index INDEX_Offersform_SingleVehicle_OwnedBy
on Offersform_SingleVehicle(OwnedBy);

create index INDEX_BasicInformation_OwnedBy
on BasicInformation(OwnedBy);

--constraint
--Foreign key
alter table Offersform_SingleVehicle add constraint OffersformSingleVehicle_FK_BasicInformation
foreign key (BasicInformation) references BasicInformation(ID);

alter table Offersform_SingleVehicle add constraint OffersformSingleVehicle_FK_WagonDetails
foreign key (WagonDetails) references WagonDetails(ID);

alter table Offersform_SingleVehicle add constraint OffersformSingleVehicle_FK_Price
foreign key (Price) references Price(ID);

alter table WagonDetails add constraint WagonDetails_FK_WagonDetails
foreign key (Guarantee) references WagonDetails(ID);

alter table WagonDetails add constraint WagonDetails_FK_HomeWagon
foreign key (HomeWagon) references HomeWagon(ID);

alter table Price add constraint Weekdays_FK_PricePlan
foreign key (Weekdays) references PricePlan(ID);

alter table Price add constraint WeekdaysEvening_FK_PricePlan
foreign key (WeekdaysEvening) references PricePlan(ID);

alter table Price add constraint WeekendersHelligdage_FK_PricePlan
foreign key (WeekendersHelligdage) references PricePlan(ID);

alter table Token add constraint UsersID_FK_Users_ID
foreign key (UsersID) references Users(ID);

alter table Offersform_SingleVehicle add constraint OwnedBy_FK_Users_ID
foreign key (OwnedBy) references Users(ID);

alter table BasicInformation add constraint FK_OwnedBy_Users_ID
foreign key (OwnedBy) references Users(ID);

alter table WagonDetails add constraint FK_WagonDetails_OwnedBy_Users_ID
foreign key (OwnedBy) references Users(ID)

--Check
alter table WagonDetails add constraint CH_WagonDetails_RegistrationLetters
check (RegistrationLetters like '__');

alter table WagonDetails add constraint CH_WagonDetails_RegistrationNumbers
check (RegistrationNumbers like '[0-9][0-9][0-9][0-9][0-9]');

alter table WagonDetails add constraint CH_WagonDetails_VehicleType
check (VehicleType like '[0-5]');

alter table WagonDetails add constraint CH_WagonDetails_Highchairs
check (Highchairs like '[0-4]');

alter table WagonDetails add constraint CH_WagonDetails_StairMachine
check (StairMachine = 120 or StairMachine = 160);
