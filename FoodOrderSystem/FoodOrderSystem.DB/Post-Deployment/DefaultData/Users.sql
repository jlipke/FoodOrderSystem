BEGIN
	INSERT INTO [dbo].[tblUser] (Id, FirstName, LastName, Phone, Email, Password)
	VALUES
		(NEWID(), 'William', 'Lewandowski', '9206366040', 'lewandowski.william@gmail.com', 'P@$$W0RD'),
		(NEWID(), 'Joseph', 'Lipke', '9204445555', 'lipke@gmail.com','pass')
END