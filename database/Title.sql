CREATE TABLE Title(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nchar(100) NOT NULL,
	ShortName nchar(50) NULL,
	Enabled bit DEFAULT 1);