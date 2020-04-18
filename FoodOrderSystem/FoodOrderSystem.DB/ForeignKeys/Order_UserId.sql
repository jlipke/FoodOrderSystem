ALTER TABLE [dbo].[tblOrder]
	ADD CONSTRAINT [Order_UserId]
	FOREIGN KEY (UserId)
	REFERENCES [tblUser] (Id)
