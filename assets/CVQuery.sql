create database DapperCv
go
use DapperCv
go
create table AppUsers(
Id int identity (1,1),
FirstName nvarchar(100),
LastName nvarchar(100),
Address nvarchar(100),
Email nvarchar(100),
ImageUrl nvarchar(100),
ShortDescription text,
UserName nvarchar(50),
Password nvarchar(30),
primary key(Id)
)

go
create table SocialMediaIcons (
Id int identity(1,1),
Link nvarchar(200),
Icon nvarchar(100),
AppUserId int,
primary key(Id),
foreign key(AppUserId) references AppUsers(Id) on delete cascade
)

go
create table Experiences (
Id int identity(1,1),
Title nvarchar(100),
SubTitle nvarchar(200),
Description  text,
StartDate datetime,
EndDate datetime,
primary key(Id)
)

go

create table Educations (
Id int identity(1,1),
Title nvarchar(100),
SubTitle nvarchar(200),
Description  text,
StartDate datetime,
EndDate datetime,
primary key(Id)
)

go

create table Skills(
Id int identity(1,1),
Description  text,
primary key(Id)
)
go

create table Interests (
Id int identity(1,1),
Description  text,
primary key(Id)
)

go
create table Certifications(
Id int identity(1,1),
Description  text,
primary key(Id)
)
go
create table Logs(
Id int identity(1,1),
Ip nvarchar(30),
Region nvarchar(150),
City nvarchar(150),
Org nvarchar(150),
Date datetime default CURRENT_TIMESTAMP
)
go
insert into AppUsers 
(Address,
Email,
FirstName,
ImageUrl,
LastName,
Password,
ShortDescription,
UserName) values 
('ESKISEHIR / TURKEY',
'enginyenice2626@gmail.com',
'Engin',
'e6d15691-ec49-4353-8637-58d34d6adc95.png',
'Yenice',
'Password12*',
'Interested in clean code and better problem‑solving. Also develops himself in Backend Development, Information Security and Web Development. Currently, dealing with backend side on application development processes. Using especially C# and Asp.Net & Core technologies.',
'enginyenice')