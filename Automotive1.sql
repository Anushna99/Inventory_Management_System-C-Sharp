create database automotive;
use automotive;

--Supplier Table

create table Supplier
(ID int identity not null,prefix varchar(10) not null, Sno as(prefix+right('000'+cast(ID as varchar(3)),3)) persisted primary key, 
Sname varchar(20) not null,Address varchar(20) not null,TP int not null, MailID varchar(100) not null
);

select * from Supplier;
drop table Supplier;
truncate table supplier;

insert into Supplier values('Sup','Perera','Colombo',0112456985,'someone@example.com');


--Customer Table

create table Customer
(Customer_TP int primary key,Customer_name varchar(30) not null,Address varchar(30) );

select * from Customer;
insert into Customer values(0711600302,'Anushna','Maharagama');
truncate table Customer;
delete from Customer where Customer_TP=11;
drop table Customer;
select count(*) from Customer where Customer_TP=011254444;



--Orders Table

create table Orders
(ID int identity not null,prefix varchar(10) not null, 
OrID as(prefix+right('0000000'+cast(ID as varchar(7)),7)) persisted primary key ,
Order_date date not null default getdate(),Cus_TP int foreign key references Customer(Customer_TP));



drop table Orders;
insert into Orders(prefix,Cus_TP) values('Ord',0711600302);
select * from Orders;
delete from Orders where ID=96;
select * from Orders where MONTH(Order_date)=10;







--Order_product Table

create table Order_product
(RecID int identity primary key, OID varchar(17) foreign key references Orders(OrID),PrID varchar(13) foreign key references 
Product(ProdId),Qty int not null,unit_price decimal(8,2) not null
);

drop table Order_product;

select * from Order_product;

--add unit price column(to give the ability to update price)....done!...
--composite primary key(OID,PrID)
--remove PrID references,to give the ability to remove product from product table(when removing product it should be removed from supply_product table beforehand)


drop table Order_product;--
select * from Order_product;

--Order_product and Product tables joining

select D.OID,sum( P.Price*D.Qty) as Order_Total from Order_product D,Product P where D.PrID=P.ProdId group by D.OID;

select Orders.Order_date,sum( Product.Price*Order_product.Qty) as Order_Total from ((Order_product Inner join Product on Order_product.PrID=Product.ProdId) inner join Orders on Orders.OrID=Order_product.OID) group by Orders.Order_date;

--income of last 5 days
select Orders.Order_date,sum( Product.Price*Order_product.Qty) as Order_Total from ((Order_product Inner join Product on Order_product.PrID=Product.ProdId) inner join Orders on Orders.OrID=Order_product.OID) where Orders.Order_date>=DATEADD(day,-5,cast(getdate() as date)) group by Orders.Order_date;



select dateadd(day,-5,cast(getdate() as date))

select sum(P.Price*D.Qty) as total from Order_product D,Product P where D.PrId=P.ProdId and D.OID='OD0000004';


select Product.prefix,sum(Order_product.Qty) as total from ((Orders inner join Order_product on Orders.OrID=Order_product.OID) inner join Product on Product.ProdId=Order_product.PrID) where MONTH(Orders.Order_date)=10 group by Product.prefix;




--Product Table

create table Product
(ID int identity not null,prefix varchar(10) not null,
 ProdId as(prefix+right('000'+cast(ID as varchar(3)),3)) persisted primary key,
 Prod_description varchar(100) not null ,Price decimal(8,2) not null,Brand varchar(50) not null, QtyInHand int not null 
);

truncate table Product;

select sum(Order_product.Qty) from Order_product;
select Product.prefix,sum(Order_product.Qty) from (( Order_product inner join Orders on Orders.OrID=Order_product.OID) inner join Product on Product.ProdId=Order_product.PrID) where Day(Orders.Order_date)=5 group by Product.prefix;

select Product.prefix,sum(Order_product.Qty) from (( Order_product inner join Orders on Orders.OrID=Order_product.OID) inner join Product on Product.ProdId=Order_product.PrID) where month(Orders.Order_date)=10 group by Product.prefix Order by Product.prefix;



select sum(Order_product.Qty) as total from ((Orders inner join Order_product on Orders.OrID=Order_product.OID) inner join Product on Product.ProdId=Order_product.PrID) where MONTH(Orders.Order_date)=10 group by Product.prefix;






select * from Product;

select ProdId from Product where ID=(select max(ID) from Product);

update Product set Prod_description='Head Light',Price=4500,Brand='Toyota',QtyInHand=45 where ProdId='L004';
drop table Product;
insert into Product values('T','Car Tyre',8000,'CEAT',30);
truncate table Product;

--from stock run out
select ProdId,Prod_description,Brand,QtyInHand from Product where QtyInHand<=10;
select count(*) as ct from Product where QtyInHand<=10; 








--Supply_product Table

create table Supply_product
(RecID int identity, PID varchar(13) foreign key references Product(ProdID),Sup_no varchar(13) foreign key 
references Supplier(Sno),primary key(PID,Sup_no)
);



select * from Supply_product;
alter table Supply_product drop column Qty;
--insert into Supply_product(PID,Sup_no) values('O011','Sup004');
delete from Supply_product where Sup_no='Sup004';
drop table Supply_product;







--Department Table

create table Department 
(DeptNo varchar(10) primary key, DeptName varchar(20) not null,TP int not null
);



select * from Department;
insert into Department values('D01','HR',0112798456),('D02','Accounts',0112578986),('D03','Other',0112487569);






--Employee Table

create table Employee
(ID int identity not null,prefix varchar(10) not null, Eno as(prefix+right('000'+cast( ID as varchar(3)),3) )persisted primary key, Fname varchar(20) not null, Surname varchar(20) not null ,Gender varchar(8) constraint ck_gender check(Gender in('Male','Female')) not null,Hometown varchar(50) not null,DOB date not null,Age int not null,
TP int not null, Position varchar(20) not null,Salary decimal(10,2) not null,Email Varchar(100) not null,Dno varchar(10)foreign key references Department(DeptNo)
);



select COUNT(Eno) from Employee group by Position;



select * from Employee;
delete from Employee where Eno='Emp001';
drop table Employee;
truncate table Employee;

insert into Employee values('Emp','Amal','Perera','Male','Colombo','1989-04-2',31,0112459789,'Manager',30000,'someone@example.com','D01');
  
--NOT EXECUTED--------------------------
--truncate table Order_product;
	select * from Order_product;
--truncate table Supply_product;
	select * from Supply_product;
truncate table Employee;
	select * from Employee;
--truncate table Department;--not executed
truncate table Product;
	select * from Product;
truncate table Orders;
	select * from Orders;
truncate table Customer;
	select * from Customer;
truncate table Supplier;
	select * from Supplier;
--truncate table Users;--not executed
	select * from Users;
----------------------------------------
  




  
  
  --Users Table
  
  create table Users
  (UserId int identity,userName varchar(50) primary key,password varchar(50) not null);

  insert into Users values('Anushna','anushna123');
  insert into Users values('Akash','akash');
  select * from Users;
  drop table Users;

  alter table Users
  add sAdmin varchar(10);

  update Users set sAdmin='true' where userName='Anushna';
  update Users set sAdmin='false' where userName='Mahesh';


  --table for themes
  create table theme
  (id int identity primary key,theme varchar(10));
  
  insert into theme values('A');
  select * from theme;
  Update theme set theme='B' where id=1;