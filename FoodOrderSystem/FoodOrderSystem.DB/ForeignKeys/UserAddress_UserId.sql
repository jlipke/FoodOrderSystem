ALTER TABLE [dbo].[tblUserAddress]
	ADD CONSTRAINT [UserAddress_UserId]
	FOREIGN KEY (UserId)
	REFERENCES [tblUser] (Id)
