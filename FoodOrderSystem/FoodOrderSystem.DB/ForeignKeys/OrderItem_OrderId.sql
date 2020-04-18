ALTER TABLE [dbo].[tblOrderItem]
	ADD CONSTRAINT [OrderItem_OrderId]
	FOREIGN KEY (OrderId)
	REFERENCES [tblOrder] (Id)
