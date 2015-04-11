create database Fynbus; 
GO
use Fynbus;

--Udbud af FV3 - FlexVariabel november 2013
--Tilbudsblanket, enkeltvogn.
create table Offersform_SingleVehicle
(
ID int identity(0,1) primary key NOT NULL,
BasicInformation int NOT NULL, --FK_BasicInformation
WagonDetails int NOT NULL, --FK_WagonDetails
Price int NOT NULL, --FK_Price
AdditionalInformation nvarchar(MAX),
OwnedBy int NOT NULL, --FK_Users_ID and INDEX_Offersform_SingleVehicle_OwnedBy
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
RegistrationLetters nvarchar(2), --CH_WagonDetails_RegistrationLetters => 2 letters 
RegistrationNumbers int, --CH_WagonDetails_RegistrationNumbers => 5 digits
PhoneNumber int NOT NULL,
VehicleType tinyint NOT NULL, --CH_WagonDetails_VehicleType from 1 too 6 (6 is with a stair machine) 
StairMachine tinyint, --CH_WagonDetails_VehicleType if is 6 (120 or 160 kg.)
Highchairs tinyint, --CH_WagonDetails_Highchairs  0 => 0 - 13 kg; 1 => 9 - 18 kg; 2 => 9 - 36 kg; 3 => 15 - 36 kg, 4 => Integreret i sæde
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

create table Users
(
ID int identity(0,1) primary key NOT NULL,
Account nvarchar(50), --INDEX
[Password] nvarchar(50),
Email nvarchar(80),
UsersAccessLevels tinyint
);

create table Token
(
ID int identity(0,1) primary key NOT NULL,
UsersID int NOT NULL, --FK_Users_ID
TokenString nvarchar(450) unique NOT NULL, --INDEX
CreateDate date NOT NULL,
);

--INDEX
create index Index_Users_Account
on Users(Account);

create index Index_Token_TokenString
on Token(TokenString);

create index INDEX_Offersform_SingleVehicle_OwnedBy
on Offersform_SingleVehicle(OwnedBy);

--Constraint
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
check (StairMachine = 120 OR StairMachine = 160);
