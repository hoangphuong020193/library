CREATE TABLE PermissionGroup(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	GroupName nchar(100) NOT NULL,
	Enabled bit NULL DEFAULT 1);