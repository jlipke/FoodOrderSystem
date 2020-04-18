ALTER TABLE [dbo].[Order]
	ADD CONSTRAINT [Order_UserId]
	FOREIGN KEY (UserId)
	REFERENCES [User] (Id)
