﻿CREATE TABLE [dbo].[tblUserAddress]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Address] VARCHAR(50) NOT NULL, 
    [City] VARCHAR(30) NOT NULL, 
    [StateId] INT NOT NULL, 
    [ZipCode] VARCHAR(5) NOT NULL
)
