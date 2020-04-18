BEGIN 
	DECLARE @UserId UNIQUEIDENTIFIER;
	DECLARE @AddressId UNIQUEIDENTIFIER;
	DECLARE @PaymentId UNIQUEIDENTIFIER;

	SELECT @UserId = Id FROM tblUser
	WHERE Email = 'lewandowski.william@gmail.com';

	SELECT @AddressId = Id FROM tblUserAddress
	WHERE Address = '2222 E Evergreen Trail';

	SELECT @PaymentId = Id FROM tblUserPayment
	WHERE CardNumber = '0000111122223333';

	INSERT INTO [dbo].[tblOrder] (Id, UserId, AddressId, PaymentId, Date)
	VALUES
		(NEWID(), @UserId, @AddressId, @PaymentId, DATETIME())
END