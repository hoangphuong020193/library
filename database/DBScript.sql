CREATE DATABASE library
GO
USE library
GO
CREATE TABLE Titles(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(100) NOT NULL,
	ShortName nvarchar(50) NULL,
	Enabled bit NULL DEFAULT 1);
GO
INSERT INTO Titles(Name, ShortName) VALUES('Sinh viên', N'SV');
INSERT INTO Titles(Name, ShortName) VALUES(N'Giảng viên', N'GV');
INSERT INTO Titles(Name, ShortName) VALUES(N'Nhân viên', N'NV');
GO
CREATE TABLE [Users](
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
	TitleId int FOREIGN KEY REFERENCES Titles(Id) NOT NULL,
	JoinDate date,
	Enabled bit DEFAULT 1);
GO
INSERT INTO [Users](UserName, Password, FirstName, MiddleName, LastName, SchoolEmail, TitleId) VALUES ('16H1010012', '4a60b7200b2ff800015942f88a55499f',N'Phương', N'Hoàng', N'Nguyễn', '16H1010012@ou.edu.vn', 1);
INSERT INTO [Users](UserName, Password, FirstName, MiddleName, LastName, SchoolEmail, TitleId) VALUES ('16H1010013', '4a60b7200b2ff800015942f88a55499f',N'Quang', N'Diệu', N'Trần', '16H1010013@ou.edu.vn', 1);
INSERT INTO [Users](UserName, Password, FirstName, MiddleName, LastName, SchoolEmail, TitleId) VALUES ('NV00000001', '4a60b7200b2ff800015942f88a55499f',N'An', N'Ngọc', N'Trịnh', 'NV00000001@ou.edu.vn', 3);
INSERT INTO [Users](UserName, Password, FirstName, MiddleName, LastName, SchoolEmail, TitleId) VALUES ('admin', '4a60b7200b2ff800015942f88a55499f',N'Admin', N'', N'', 'admin', 3);
GO
CREATE TABLE PermissionGroups(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	GroupName nvarchar(100) NOT NULL,
	Enabled bit DEFAULT 1);
GO
INSERT INTO PermissionGroups(GroupName) VALUES (N'Thủ thư');
GO
CREATE TABLE PermissionGroupMembers(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	GroupId int FOREIGN KEY REFERENCES PermissionGroups(Id) NOT NULL,
	UserId int FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	Enabled bit DEFAULT 1);
GO
INSERT INTO PermissionGroupMembers(GroupId, UserId) VALUES (1, 3);
GO
CREATE TABLE Categories(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Type nvarchar(250),
	CategoryName nvarchar(250) NOT NULL,
	Enabled bit DEFAULT 1);
GO
INSERT INTO Categories(Type, CategoryName) VALUES (N'Sách', N'Công nghệ thông tin');
INSERT INTO Categories(Type,CategoryName) VALUES (N'Sách',N'Ngoại ngữ');
INSERT INTO Categories(Type,CategoryName) VALUES (N'Sách',N'Tài chính ngân hàng');
INSERT INTO Categories(Type,CategoryName) VALUES (N'Luận văn - Đồ án',N'Đồ án môn học');
INSERT INTO Categories(Type,CategoryName) VALUES (N'Luận văn - Đồ án',N'Luận văn tốt nghiệp');
GO
CREATE TABLE Suppliers(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(250),
	Address nvarchar(1000),
	Phone nvarchar(15),
	Email nvarchar(250),
	Enabled bit DEFAULT 1
)
GO
INSERT INTO Suppliers(Name) VALUES (N'Đang cập nhập');
INSERT INTO Suppliers(Name) VALUES (N'Nhã Nam');
INSERT INTO Suppliers(Name) VALUES (N'Công ty sách Phương Nam');
GO
CREATE TABLE Publishers(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(250),
	Address nvarchar(1000),
	Phone nvarchar(15),
	Email nvarchar(250),
	Enabled bit DEFAULT 1
)
GO
INSERT INTO Publishers(Name) VALUES (N'Nhà xuất bản giáo dục');
INSERT INTO Publishers(Name) VALUES (N'Nhà xuất bản tuổi trẻ');
INSERT INTO Publishers(Name) VALUES (N'AIG Việt Nam');
GO
CREATE TABLE Libraries (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(250),
	Address nvarchar(1000),
	Phone nvarchar(15),
	Email nvarchar(250),
	Enabled bit DEFAULT 1
)
GO
INSERT INTO Libraries(Name) VALUES (N'Cơ sở 1');
INSERT INTO Libraries(Name) VALUES (N'Cơ sở 2');
INSERT INTO Libraries(Name) VALUES (N'Cơ sở 3');
INSERT INTO Libraries(Name) VALUES (N'Cơ sở 4');
INSERT INTO Libraries(Name) VALUES (N'Cơ sở 5');
GO
CREATE TABLE Books(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CategoryId int FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	BookCode nvarchar(15) not null unique,
	BookName nvarchar(250),
	Tag nvarchar(250),
	Description nvarchar(1000),
	BookImage varbinary(max),
	DateImport DateTime,
	Amount INT DEFAULT 0,
	AmountAvailable INT DEFAULT 0,
	Author nvarchar(250),
	PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
	SupplierId INT FOREIGN KEY REFERENCES Suppliers(Id) NOT NULL,
	LibraryId INT FOREIGN KEY REFERENCES Libraries(Id) NOT NULL,
	Size nvarchar(20),
	Format nvarchar(50),
	PublicationDate Date,
	Pages int DEFAULT 0,
	MaximumDateBorrow int not null default 0,
	Enabled bit DEFAULT 1
)
GO
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (1, N'Lập trình C#', N'ABCD lập trình', '2017-12-30', 10, 'B000000001', 10, N'Nguyễn Văn A',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 300, 1);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (1,N'Lập trình hướng đối tượng', N'ABCD lập trình đối tượng', '2017-12-28', 15, 'B000000002', 15, N'Nguyễn Văn B',1, 2, '20cm x 110cm', N'Bìa mềm', '2017-07-05', 125, 2);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (1,N'Trí tuệ nhân tạo', N'AI', '2017-12-28', 10, 'B000000003', 10, N'Lê Quang C', 2, 2, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 450, 2);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (1,N'Java', 'Java', '2017-12-27', 20, 'B000000004', 10, N'Ngô Tấn',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 312, 3);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (1,N'PHP', 'PHP', '2017-12-28', 30, 'B000000005', 10, N'Nguyễn Văn A',3, 2, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 120, 4);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (1,N'Kiểm thử phần mềm', 'Testing', '2017-12-22', 3, 'B000000006', 10, N'Nguyễn Văn D',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 300, 1);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (2,N'Toeic Academic', 'Toeic', '2017-12-22', 2, 'B000000007', 10, N'Nguyễn Văn A',3, 3, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 300, 5);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId)
VALUES (2,N'Grammar', 'Grrammar', '2017-12-21', 50, 'B000000008', 10, N'Nguyễn Chí T',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2018-01-08', 85, 5);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (2,N'Vocabulary', 'Vocabulary', '2017-12-21', 100, 'B000000009', 10, N'lê Thị Na',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-01-25', 300, 3);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (3,N'Tài chính ABCD', N'Tài chính ABCD', '2017-12-28', 15, 'B000000010', 10, N'ABDFD',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 255, 2);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId) 
VALUES (3,N'Hệ thống thông tin tài chính ngân hàng?', N'Hệ thống thông tin tài chính ngân hàng', '2017-12-28', 15, 'B000000011', 10, N'Nguyễn Văn A',1, 1, '25.5cm x 15cm', N'Bìa cứng', '2017-12-25', 300, 1);
INSERT INTO Books(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages, LibraryId)
VALUES (3,N'Báo cáo tiền tệ', N'Báo cáo tiền tệ', '2017-12-28', 15, 'B000000012', 10, N'Nguyễn Văn A',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 300, 4);
GO
CREATE TABLE BookCarts(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL,
	Status INT NOT NULL DEFAULT 1,
	ModifiedDate DATETIME DEFAULT GETDATE()
)
GO
CREATE TABLE BookFavorites(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL,
)
GO
CREATE TABLE UserBookRequests(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	RequestCode nvarchar(10) not null unique,
	RequestDate DateTime not null default GETDATE(),
)
GO
CREATE TABLE UserBooks(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	RequestId INT FOREIGN KEY REFERENCES UserBookRequests(Id) NOT NULL,
	BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL,
	ReceiveDate DateTime null,
	ReturnDate DateTime null,
	DeadlineDate DateTime not null,
	Status INT NOT NULL DEFAULT 0,
)
GO
CREATE TABLE UserNotifications(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	Message nvarchar(1000) not null,
	MessageDate DateTime not null default GETDATE()
)