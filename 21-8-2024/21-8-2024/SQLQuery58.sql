create table Users (
 ID int PRIMARY KEY IDENTITY(1,1),
 Username VARCHAR(255),
 Password VARCHAR(255),
 Email VARCHAR(255)

);
create table Orders  (
 ID int PRIMARY KEY IDENTITY(1,1),
 UserID INT FOREIGN KEY REFERENCES Users(ID),
 OrderDate VARCHAR(255),


);
