ALTER TABLE [dbo].[UserPayment]
	ADD CONSTRAINT [UserPayment_UserId]
	FOREIGN KEY (UserId)
	REFERENCES [User] (Id)
