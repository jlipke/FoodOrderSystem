CREATE PROCEDURE [dbo].[spCreateUser]
	@FirstName VARCHAR(30),
	@LastName VARCHAR(30),
	@Email VARCHAR(100),
	@Phone VARCHAR(10),
	@Password VARCHAR(30)

AS
	INSERT INTO tblUser (Id, FirstName, LastName, Email, Phone, Password)
	VALUES (NEWID(), @FirstName, @LastName, @Email, @Phone, @Password);
RETURN 0
