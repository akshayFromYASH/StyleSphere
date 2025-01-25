
  create database Shopify;
  use Shopify;

  create table users(
	UserId int primary key identity(1,1),
	UserName varchar(30),
	Email varchar(30),
	Password varchar(30),
	PhoneNumber varchar(10),
	Status varchar(20),
	UserRole varchar(20)
  );

  create table products(
	ProdId int primary key identity(101,1),
	ProdName varchar(30),
	Description varchar(200),
	Image varchar(500),
	Availaibility varchar(30),
	CategoryId int,
	UserId int,
	Price decimal,
	Stock_Quantity int
  );

create table categories(
  CategoryId int primary key identity(1,1),
  CategoryName varchar(30)
);

create table carts(
	CartId int primary key identity(1,1),
	UserId int,
	ProdId int,
	Quantity int,
	Cart_Amount decimal
);

create table orders(
	OrderId int primary key identity (1001,1),
	OrderNumber int unique,
	Total_Amount decimal,
	Shipping_Amount decimal,
	Discount_Amount decimal,
	Net_Amount decimal,
	Return_Reason varchar(240),
	Status varchar(50),
	CartId int
);

create table ReviewsRatings(
	Id int primary key identity (1,1),
	ProdId int,
	Review varchar(240),
	Rating int,
	UserId int
);

create table shipping_details(
	ShippingId int primary key identity(1,1),
	OrderId int,
	ShippingTo varchar(30),
	ContactDetails varchar(50),
	Address varchar(500)
);

create table payments(
	PaymentId int primary key identity(1,1),
	OrderDate varchar(50),
	DelieveryDate varchar(50),
	OrderId int,
	Total_Amount decimal,
	Payment_Status varchar(30),
	Payment_Method varchar(30)
);

