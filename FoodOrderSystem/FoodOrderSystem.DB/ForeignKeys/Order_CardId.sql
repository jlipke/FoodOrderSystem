ALTER TABLE [dbo].[Order]
	ADD CONSTRAINT [Order_CardId]
	FOREIGN KEY (PaymentId)
	REFERENCES [UserPayment] (Id)
