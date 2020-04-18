ALTER TABLE [dbo].[OrderItem]
	ADD CONSTRAINT [OrderItem_MenuItemId]
	FOREIGN KEY (MenuItemId)
	REFERENCES [MenuItem] (Id)
