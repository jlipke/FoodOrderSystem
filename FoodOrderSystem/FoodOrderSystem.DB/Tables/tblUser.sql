﻿CREATE TABLE [dbo].[tblUser]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(30) NOT NULL, 
    [LastName] VARCHAR(30) NOT NULL, 
    [Phone] VARCHAR(10) NOT NULL,
    [Email] VARCHAR(100) UNIQUE NOT NULL, 
    [Password] VARCHAR(30) NOT NULL
)
