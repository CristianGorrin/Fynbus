create database Fynbus; 
GO
use Fynbus;

--Udbud af FV3 - FlexVariabel november 2013
--Tilbudsblanket, enkeltvogn.
create table Offersform_SingleVehicle
(
ID int identity(0,1) NOT NULL,
BasicInformation int NOT NULL, --FK_BasicInformation
WagonDetails int NOT NULL, --FK_WagonDetails
Price int NOT NULL, --FK_Price
AdditionalInformation nvarchar(MAX)
);

create table BasicInformation
(
ID int identity(0,1) primary key NOT NULL,
Name nvarchar(100) NOT NULL,
CVR int NOT NULL,
NameSecondary nvarchar(100)
);

create table WagonDetails
(
ID int identity(0,1) primary key NOT NULL,
Guarantee int, --FK_WagonDetails
Registration nvarchar(7) unique, --CH_WagonDetailsRegistration => 2 letters + 5 digits, with no spaces and dot.
PhoneNumber int NOT NULL,
VehicleType tinyint NOT NULL, -- from 1 too 6 (6 is with a stair machine)
StairMachine tinyint, --VehicleType if is 6 (120 or 160 kg.)
Highchairs tinyint, --0 => 0 - 13 kg; 1 => 9 - 18 kg; 2 => 9 - 36 kg; 3 => 15 - 36 kg, 4 => Integreret i sæde
HomeWagon int, --FK_HomeWagon
);

create table HomeWagon
(
ID int identity(0,1) primary key NOT NULL,
StreetName nvarchar(100) NOT NULL,
StreetNumber smallint NOT NULL,
ZipCode smallint NOT NULL,
City nvarchar(100) NOT NULL,
Municipality nvarchar(200) NOT NULL,
);

create table Price
(
ID int identity(0,1) primary key NOT NULL,
Weekdays int NOT NULL, --FK_PricePlan (Mon-Fri 6:00 to 18:00)
WeekdaysEvening int NOT NULL, --FK_PricePlan (Mon-Fri 18:00 to 6:00)
WeekendersHelligdage int NOT NULL, --FK_PricePlan (Weekends and holidays)
StairMachine decimal(6,2) 
);

create table PricePlan
(
ID int identity(0,1) primary key NOT NULL,
SetUpFee decimal(6,2) NOT NULL,
HourlyRate decimal(6,2) NOT NULL,
HourlyDdownTime decimal(6,2) NOT NULL
);

