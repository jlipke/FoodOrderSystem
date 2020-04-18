ALTER TABLE [dbo].[tblUserPayment]
	ADD CONSTRAINT [UserPayment_UserId]
	FOREIGN KEY (UserId)
	REFERENCES [tblUser] (Id)
