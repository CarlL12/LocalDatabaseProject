

CREATE TABLE Manufactures 
(
	Id int not null identity primary key,
	Manufacture nvarchar(50) not null
)
CREATE TABLE Categories 
(
	Id int not null identity primary key,
	CategoryName nvarchar(50) not null
)
CREATE TABLE ProductPictures 
(
	Id int not null identity primary key,
	Picture nvarchar(max),
)
CREATE TABLE Products 
(
	ArticleNumber nvarchar(400) not null primary key,
	Description nvarchar(max) null,
	Title nvarchar(100) not null,
	ManufactureId int not null references Manufactures(Id),
	CategoryId int not null references Categories(Id),
	ProductPictureId int not null references ProductPictures(Id),
)
CREATE TABLE Prices 
(
	ProductId nvarchar(400) not null primary key,
	ProductPrice money not null,
	SalePrice money null,
	FOREIGN KEY(ProductId) references Products(ArticleNumber)
)