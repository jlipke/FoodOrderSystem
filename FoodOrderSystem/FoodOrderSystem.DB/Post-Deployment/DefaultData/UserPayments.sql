BEGIN 
	DECLARE @PaymentUserId UNIQUEIDENTIFIER;

	SELECT @PaymentUserId = Id FROM tblUser 
	WHERE Email = 'lewandowski.william@gmail.com';

	INSERT INTO [dbo].[tblUserPayment] (Id, UserId, CardHolderName, CardNumber, ExpirationDate, CVC)
	VALUES 
		(NEWID(), @PaymentUserId, 'William Lewandowski', '0000111122223333', '0122', '000')
END