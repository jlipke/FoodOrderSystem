ALTER TABLE [dbo].[Order]
	ADD CONSTRAINT [Order_AddressId]
	FOREIGN KEY (AddressId)
	REFERENCES [UserAddress] (Id)
