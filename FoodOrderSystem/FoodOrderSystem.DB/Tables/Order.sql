﻿CREATE TABLE [dbo].[Order]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [AddressId] UNIQUEIDENTIFIER NOT NULL, 
    [PaymentId] UNIQUEIDENTIFIER NOT NULL
)
