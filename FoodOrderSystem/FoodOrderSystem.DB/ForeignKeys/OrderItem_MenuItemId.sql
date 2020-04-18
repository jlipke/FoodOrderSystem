ALTER TABLE [dbo].[tblOrderItem]
	ADD CONSTRAINT [OrderItem_MenuItemId]
	FOREIGN KEY (MenuItemId)
	REFERENCES [tblMenuItem] (Id)
