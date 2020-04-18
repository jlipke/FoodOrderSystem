ALTER TABLE [dbo].[tblOrder]
	ADD CONSTRAINT [Order_CardId]
	FOREIGN KEY (PaymentId)
	REFERENCES [tblUserPayment] (Id)
