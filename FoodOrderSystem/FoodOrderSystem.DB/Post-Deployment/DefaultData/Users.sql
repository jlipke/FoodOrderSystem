BEGIN
	INSERT INTO [dbo].[tblUser] (Id, FirstName, LastName, Phone, Email, Password)
	VALUES
		(NEWID(), 'William', 'Lewandowski', '19206366040', 'lewandowski.william@gmail.com', 'P@$$W0RD')
END