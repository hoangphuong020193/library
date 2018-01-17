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
GO
CREATE TABLE Category(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Type nvarchar(250),
	CategoryName nvarchar(250) NOT NULL,
	Enabled bit NULL DEFAULT 1);
GO
INSERT INTO Category(Type, CategoryName) VALUES (N'Sách', N'Công nghệ thông tin');
INSERT INTO Category(Type,CategoryName) VALUES (N'Sách',N'Ngoại ngữ');
INSERT INTO Category(Type,CategoryName) VALUES (N'Sách',N'Tài chính ngân hàng');
INSERT INTO Category(Type,CategoryName) VALUES (N'Luận văn - Đồ án',N'Đồ án môn học');
INSERT INTO Category(Type,CategoryName) VALUES (N'Luận văn - Đồ án',N'Luận văn tốt nghiệp');
GO
CREATE TABLE Supplier(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(250),
	Address nvarchar(1000),
	Phone nvarchar(15),
	Email nvarchar(250),
	Enabled bit NULL DEFAULT 1
)
GO
INSERT INTO Supplier(Name) VALUES (N'Đang cập nhập');
INSERT INTO Supplier(Name) VALUES (N'Nhã Nam');
INSERT INTO Supplier(Name) VALUES (N'Công ty sách Phương Nam');
GO
CREATE TABLE Publisher(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name nvarchar(250),
	Address nvarchar(1000),
	Phone nvarchar(15),
	Email nvarchar(250),
	Enabled bit NULL DEFAULT 1
)
GO
INSERT INTO Publisher(Name) VALUES (N'Nhà xuất bản giáo dục');
INSERT INTO Publisher(Name) VALUES (N'Nhà xuất bản tuổi trẻ');
INSERT INTO Publisher(Name) VALUES (N'AIG Việt Nam');
GO
CREATE TABLE Book(
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CategoryId int FOREIGN KEY REFERENCES Category(Id),
	BookCode nvarchar(15) not null unique,
	BookName nvarchar(250),
	Tag nvarchar(250),
	Description nvarchar(1000),
	BookImage varbinary(max),
	DateImport DateTime,
	Amount INT DEFAULT 0,
	AmountAvailable INT DEFAULT 0,
	Author nvarchar(250),
	PublisherId INT FOREIGN KEY REFERENCES Publisher(Id),
	SupplierId INT FOREIGN KEY REFERENCES Supplier(Id),
	Size nvarchar(20),
	Format nvarchar(50),
	PublicationDate Date,
	Pages int DEFAULT 0,
	MaximumDateBorrow int not null default 0,
	Enabled bit NULL DEFAULT 1
)
GO
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (1, N'Lập trình C#', N'ABCD lập trình', '2017-12-30', 10, 'B000000001', 10, N'Nguyễn Văn A',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 300);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (1,N'Lập trình hướng đối tượng', N'ABCD lập trình đối tượng', '2017-12-28', 15, 'B000000002', 15, N'Nguyễn Văn B',1, 2, '20cm x 110cm', N'Bìa mềm', '2017-07-05', 125);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (1,N'Trí tuệ nhân tạo', N'AI', '2017-12-28', 10, 'B000000003', 10, N'Lê Quang C', 2, 2, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 450);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (1,N'Java', 'Java', '2017-12-27', 20, 'B000000004', 10, N'Ngô Tấn',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 312);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (1,N'PHP', 'PHP', '2017-12-28', 30, 'B000000005', 10, N'Nguyễn Văn A',3, 2, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 120);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (1,N'Kiểm thử phần mềm', 'Testing', '2017-12-22', 3, 'B000000006', 10, N'Nguyễn Văn D',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 300);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (2,N'Toeic Academic', 'Toeic', '2017-12-22', 2, 'B000000007', 10, N'Nguyễn Văn A',3, 3, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 300);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages)
VALUES (2,N'Grammar', 'Grrammar', '2017-12-21', 50, 'B000000008', 10, N'Nguyễn Chí T',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2018-01-08', 85);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (2,N'Vocabulary', 'Vocabulary', '2017-12-21', 100, 'B000000009', 10, N'lê Thị Na',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-01-25', 300);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (3,N'Tài chính ABCD', N'Tài chính ABCD', '2017-12-28', 15, 'B000000010', 10, N'ABDFD',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 255);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages) 
VALUES (3,N'Hệ thống thông tin tài chính ngân hàng?', N'Hệ thống thông tin tài chính ngân hàng', '2017-12-28', 15, 'B000000011', 10, N'Nguyễn Văn A',1, 1, '25.5cm x 15cm', N'Bìa cứng', '2017-12-25', 300);
INSERT INTO Book(CategoryId, BookName, Description, DateImport, Amount, BookCode, AmountAvailable, Author, PublisherId, SupplierId, Size, Format, PublicationDate, Pages)
VALUES (3,N'Báo cáo tiền tệ', N'Báo cáo tiền tệ', '2017-12-28', 15, 'B000000012', 10, N'Nguyễn Văn A',1, 1, '25.5cm x 15cm', N'Bìa mềm', '2017-12-25', 300);
GO
CREATE TABLE BookCart(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES [User](Id),
	BookId INT FOREIGN KEY REFERENCES Book(Id),
	Status INT NOT NULL DEFAULT 1,
	ModifiedDate DATETIME DEFAULT GETDATE()
)
GO
CREATE TABLE BookFavorite(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES [User](Id),
	BookId INT FOREIGN KEY REFERENCES Book(Id),
)
GO
CREATE TABLE UserBookRequest(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES [User](Id),
	RequestCode nvarchar(10) not null unique,
	RequestDate DateTime not null default GETDATE(),
)
GO
CREATE TABLE UserBook(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	UserId INT FOREIGN KEY REFERENCES [User](Id),
	RequestId INT FOREIGN KEY REFERENCES [UserBookRequest](Id),
	BookId INT FOREIGN KEY REFERENCES Book(Id),
	ReceiveDate DateTime null,
	ReturnDate DateTime null,
	Status INT NOT NULL DEFAULT 0,
)