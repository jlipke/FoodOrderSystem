BEGIN 
	DECLARE @PaymentUserId UNIQUEIDENTIFIER;

	SELECT @PaymentUserId = Id FROM tblUser 
	WHERE Email = 'lewandowski.william@gmail.com';

	INSERT INTO [dbo].[tblUserPayment] (Id, UserId, CardHolderName, CardNumber, ExpirationDate, CVC)
	VALUES 
		(NEWID(), @PaymentUserId, 'William Lewandowski', '0000111122223333', '0122', '000')

	SELECT @PaymentUserId = Id FROM tblUser 
	WHERE Email = 'lipke@gmail.com';

	INSERT INTO [dbo].[tblUserPayment] (Id, UserId, CardHolderName, CardNumber, ExpirationDate, CVC)
	VALUES 
		(NEWID(), @PaymentUserId, 'Joseph Lipke', '9999888877776666', '0321', '999')
END