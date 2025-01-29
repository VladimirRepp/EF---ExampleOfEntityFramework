Go
Create Database DBFirst_Library

Go
Create Database ModelFirst_Users

Go
Create Database CodeFirst_Employees

Go
Use DBFirst_Library

Go
Use ModelFirst_Users

Go
Use CodeFirst_Employees

Go 
Select * from Employees

Go 
Select * from People

CREATE TABLE [DBFirst_Library].[Author]
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 FirstName VARCHAR(100) NOT NULL,
 LastName VARCHAR(100) NOT NULL
)

CREATE TABLE Publisher
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 PublisherName VARCHAR(100) NOT NULL,
 Address VARCHAR(100) NOT NULL
)

CREATE TABLE Book
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Title VARCHAR(100) NOT NULL,
 IdAuthor INT NOT NULL FOREIGN KEY REFERENCES 
 Author(Id),
 Pages INT,
 Price INT,
 IdPublisher INT NOT NULL FOREIGN KEY 
 REFERENCES Publisher(Id)
)
