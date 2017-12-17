CREATE DATABASE library
GO
USE library
GO
CREATE TABLE Title(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(100) NOT NULL,
	ShortName nvarchar(50) NULL,
	Enabled bit NULL DEFAULT 1);
GO
INSERT INTO Title(Name, ShortName) VALUES('Sinh viên', N'SV');
INSERT INTO Title(Name, ShortName) VALUES(N'Giảng viên', N'GV');
INSERT INTO Title(Name, ShortName) VALUES(N'Nhân viên', N'NV');
GO
CREATE TABLE [User](
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserName nvarchar(15) NOT NULL UNIQUE,
	Password nvarchar(100) NOT NULL,
	FirstName nvarchar(20) NULL,
	MiddleName nvarchar(20) NULL,
	LastName nvarchar(50) NULL,
	SchoolEmail nvarchar(50) NULL,
	PersonalEmail nvarchar(100) NULL,
	PhoneNumber nvarchar(15) NULL,
	BirthDay date,
	TitleId int FOREIGN KEY REFERENCES Title(Id),
	JoinDate date,
	Enabled bit NULL DEFAULT 1);
GO
INSERT INTO [User](UserName, Password, FirstName, MiddleName, LastName, SchoolEmail, TitleId) VALUES ('16H1010012', '4a60b7200b2ff800015942f88a55499f',N'Phương', N'Hoàng', N'Nguyễn', '16H1010012@ou.edu.vn', 1);
INSERT INTO [User](UserName, Password, FirstName, MiddleName, LastName, SchoolEmail, TitleId) VALUES ('16H1010013', '4a60b7200b2ff800015942f88a55499f',N'Quang', N'Diệu', N'Trần', '16H1010013@ou.edu.vn', 1);
INSERT INTO [User](UserName, Password, FirstName, MiddleName, LastName, SchoolEmail, TitleId) VALUES ('NV00000001', '4a60b7200b2ff800015942f88a55499f',N'An', N'Ngọc', N'Trịnh', 'NV00000001@ou.edu.vn', 3);
GO
CREATE TABLE PermissionGroup(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	GroupName nvarchar(100) NOT NULL,
	Enabled bit NULL DEFAULT 1);
GO
INSERT INTO PermissionGroup(GroupName) VALUES (N'Thủ thư');
GO
CREATE TABLE PermissionGroupMember(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	GroupId int FOREIGN KEY REFERENCES PermissionGroup(Id),
	UserId int FOREIGN KEY REFERENCES [User](Id),
	Enabled bit NULL DEFAULT 1);
GO
INSERT INTO PermissionGroupMember(GroupId, UserId) VALUES (1, 3);