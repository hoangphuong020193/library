CREATE TABLE [User](
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserCode nchar(15) NOT NULL UNIQUE,
	FirstName nchar(20) NULL,
	MiddleName nchar(20) NULL,
	LastName nchar(50) NULL,
	SchoolEmail nchar(50) NULL,
	PersonalEmail nchar(100) NULL,
	PhoneNumber nchar(15) NULL,
	BirthDay date,
	TitleId int FOREIGN KEY REFERENCES Title(Id),
	JoinDate date,
	Enabled bit DEFAULT 1);