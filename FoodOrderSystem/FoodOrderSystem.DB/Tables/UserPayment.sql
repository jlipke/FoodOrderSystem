CREATE TABLE [dbo].[UserPayment]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [PaymentName] VARCHAR(30) NOT NULL, 
    [CardHolderName] VARCHAR(60) NOT NULL, 
    [CardNumber] VARCHAR(16) NOT NULL, 
    [ExpirationDate] VARCHAR(4) NOT NULL, 
    [CVC] VARCHAR(3) NULL
)
