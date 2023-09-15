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
drop table Customer;



--Orders Table

create table Orders
(ID int identity not null,prefix varchar(10) not null, 
OrID as(prefix+right('0000000'+cast(ID as varchar(7)),7)) persisted primary key ,
Order_date date not null default getdate(),Cus_TP int foreign key references Customer(Customer_TP));



drop table Orders;
insert into Orders(prefix,Cus_TP) values('Ord',0711600302);
select * from Orders;







--Order_product Table

create table Order_product
(RecID int identity primary key, OID varchar(17) foreign key references Orders(OrID),PrID varchar(13) foreign key references 
Product(ProdId),Qty int not null
);


drop table Order_product;--
select * from Order_product;

--Order_product and Product tables joining

select D.OID,sum( P.Price*D.Qty) as Order_Total
from Order_product D,Product P
where D.PrID=P.ProdId
group by D.OID;




select Order_product.OID,Customer.Customer_name,Customer.Customer_TP,sum( Product.Price*Order_product.Qty) as Order_Total from(((Order_product inner join Product on Order_product.PrID = Product.ProdId)inner join Orders on Orders.OrID=Order_product.OID)inner join Customer on Orders.Cus_TP=Customer.Customer_TP ) group by Order_product.OID,Customer.Customer_name,Customer.Customer_TP; 








--Product Table

create table Product
(ID int identity not null,prefix varchar(10) not null,
 ProdId as(prefix+right('000'+cast(ID as varchar(3)),3)) persisted primary key,
 Prod_description varchar(100) not null ,Price decimal(8,2) not null,Brand varchar(50) not null, QtyInHand int not null 
);


select * from Product;
update Product set Prod_description='Head Light',Price=4500,Brand='Toyota',QtyInHand=45 where ProdId='L004';
drop table Product;
insert into Product values('T','Car Tyre',8000,'CEAT',30);
truncate table Product;











--Supply_product Table

create table Supply_product
(RecID int identity primary key, PID varchar(13) foreign key references Product(ProdID),Sup_no varchar(13) foreign key 
references Supplier(Sno),Qty int not null
);



select * from Supply_product;
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
TP int not null, Position varchar(20) not null,Salary decimal(8,2) not null,Email Varchar(100) not null,Dno varchar(10)foreign key references Department(DeptNo)
);



select * from Employee;
delete from Employee where Eno='Emp001';
drop table Employee;
truncate table Employee;

insert into Employee values('Emp','Amal','Perera','Male','Colombo','1989-04-2',31,0112459789,'Manager',30000,'someone@example.com','D01');
  

  
  
  
  
  
  
  
  --Users Table
  
  create table Users
  (UserId int identity primary key,userName varchar(50),password varchar(50) not null);

  insert into Users values('Anushna','anushna123');
  select * from Users;
  
