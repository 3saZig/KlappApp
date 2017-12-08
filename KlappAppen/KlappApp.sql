create schema trh
go

create table trh.Gift
(
        Id int identity primary key,
        Price int not null default 0,
        Receiver nvarchar(50) not null,
        Name nvarchar(50) not null,
        BudgetId int references trh.Budget (Id)
)

create table trh.Budget
(
        Id int identity primary key,
        Total int not null,
        AspNetUsersId nvarchar(450) references dbo.AspNetUsers (Id)
)