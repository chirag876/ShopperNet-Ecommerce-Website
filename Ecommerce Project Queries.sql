create Database Shoppers

create table Users(Id int Identity(1,1), Name nvarchar(max), Email nvarchar(max), Password nvarchar(max), Phone nvarchar(10), Country nvarchar(max));

--create table Orders(orderId int identity(1001,1), Email varchar(max), ItemId int, ItemName varchar(max), ItemPrice int, Quantity int)
create table orders(orderid int identity(1,1), ItemId int, Quantity int, Email varchar(30), Address varchar(max))

create table Items(ItemId int Identity(1,1), Name nvarchar(max), Description nvarchar(max), ItemImage nvarchar(max), ItemPrice int)

create table profile(Id int identity(101,1), Name varchar(max), Email varchar(max),DateofBirth varchar(max), Address varchar(max), phone varchar(max))

create table ShopperCart(Id int identity(1,1), ItemId int, ItemName varchar(max), ItemPrice int, Quantity int, Email varchar(max))

create table Admin(id int, AdminEmail varchar(max), Password varchar(max))

create table shippingadd(shipaddid int identity(111,1), Email varchar(max), Address varchar(max))

insert into Users values('Chirag Gupta', 'chirag1706gupta@gmail.com','chirag1706', '8769240601', 'India')

----------------------------------------------------------all the sp used for this project----------------------------------------------------------
--sp for adding the user in Users table
create or alter PROCEDURE AddUser  'Chavvi Bindal', 'Chavi611@gmail.com', 'chavi244', '6738387354', 'India'
@Name varchar(max),
@Email varchar(max),
@Password varchar(max),
@Phone varchar(max),
@Country varchar(max)
as
begin
insert into Users values(@Name, @Email, @Password, @Phone, @Country)
end

--sp for adding the order detail in orders table
create or alter proc insertorder
@ItemId int,
@Quantity int,
@Email varchar(30),
@Address varchar(max),
@TotalPrice int
as
begin
insert into orders values(@ItemId, @Quantity, @Email,@Address,@TotalPrice)
end
-------------------------------------------------------------------------------------------------------------------------------------------
--sp for inserting values into shoppercart table
create or alter proc getcartdetails 1, 'Bedsheet', 4500, 1, 'chirag1706gupta@gmail.com'
@ItemId int,
@ItemName varchar(max),
@ItemPrice int,
@Quantity int,
@Email varchar(max)
as 
begin
insert into ShopperCart values(@ItemId,@ItemName,@ItemPrice,@Quantity,@Email)
end
---------------------------------------------------------------------------------------------------------------------------------------------
--sp for editing user profile details
create or alter proc editprofile
@Name varchar(max),
@Email varchar(max),
@DateofBirth varchar(max),
@Address varchar(max),
@phone varchar(max)
as
begin
update profile set Name = @Name, DateofBirth=@DateofBirth, phone=@phone, Address=@Address where Email=@Email
end
--------------------------------------------------------------------------------------------------------------------------------------------
--sp for updating the shipping address
create or alter proc updateadd
@Email varchar(max),
@Address varchar(max)
as
begin
update Orders set Address=@Address where Email=@Email
end

-------------------------------------------------------------------------------------------------------------------------------------------
--sp for adding the address in shipping address page
create or alter proc addaddress
@Email varchar(max),
@Address varchar(max)
as
begin
insert into shippingadd values(@Email, @Address)
end

--create or alter proc insertitems 'Laptop',	'Apple Laptop'	,'https://media.istockphoto.com/id/506061551/photo/laptop-on-white-table.jpg?s=612x612&w=0&k=20&c=VUhXE3jkNA_RdqdsjFVq1TX2aPymd6sj7uUoVlDzF4U=',	50000
--@Name varchar(max),
--@Description varchar(max),
--@ItemImage varchar(max),
--@ItemPrice int
--as
--begin
--insert into Items values(@Name, @Description, @ItemImage, @ItemPrice)
--end



--sp for decreasing item quantity on shoppercart
create or alter proc decreasequantity
@Email varchar(max),
@ItemId int
AS
BEGIN
update ShopperCart set Quantity = Quantity-1 where ItemId = @ItemId and Email = @Email
END

--sp for increasing item quantity on shoppercart
create or alter proc increasequantity
@Email varchar(max),
@ItemId int
AS
BEGIN
update ShopperCart set Quantity = Quantity+1 where ItemId = @ItemId and Email = @Email
END

--sp for removing product from cart
create or alter proc removecartproduct
@ItemId int
AS
BEGIN
Delete from ShopperCart where ItemId = @ItemId
END

--Alter Table shippingadd
--add orderid int

--alter table shippingadd drop column orderid
select * from orders
truncate table orders
select * from shippingadd

select * from ShopperCart
