BEGIN
	INSERT INTO [dbo].[tblMenuItem] (Id, ItemName, Price)
	VALUES 
		(NEWID(), 'Cheese Pizza', 12.99),
		(NEWID(), 'Pepperoni Pizza', 13.99)
END