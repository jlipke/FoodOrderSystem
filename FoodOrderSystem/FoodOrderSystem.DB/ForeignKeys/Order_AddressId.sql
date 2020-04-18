ALTER TABLE [dbo].[tblOrder]
	ADD CONSTRAINT [Order_AddressId]
	FOREIGN KEY (AddressId)
	REFERENCES [tblUserAddress] (Id)
