ALTER TABLE [dbo].[Address]
	ADD CONSTRAINT [UserAddress_UserId]
	FOREIGN KEY (UserId)
	REFERENCES [User] (Id)
