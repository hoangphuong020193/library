CREATE TABLE PermissionGroupMember(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	GroupId int FOREIGN KEY REFERENCES PermissionGroup(Id),
	UserId int FOREIGN KEY REFERENCES [User](Id),
	Enabled bit NOT NULL DEFAULT 1
);