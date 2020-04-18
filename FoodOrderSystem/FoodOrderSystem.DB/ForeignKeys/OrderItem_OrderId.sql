ALTER TABLE [dbo].[OrderItem]
	ADD CONSTRAINT [OrderItem_OrderId]
	FOREIGN KEY (OrderId)
	REFERENCES [Order] (Id)
