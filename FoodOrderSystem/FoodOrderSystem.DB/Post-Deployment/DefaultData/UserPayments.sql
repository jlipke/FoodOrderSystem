BEGIN 
	DECLARE @UserId UNIQUEIDENTIFIER;

	SELECT @UserId = Id FROM tblUser 
	WHERE Email = 'lewandowski.william@gmail.com';

	INSERT INTO [dbo].[tblUserPayment] (Id, UserId, CardHolderName, CardNumber, ExpirationDate, CVC)
	VALUES 
		(NEWID(), @UserId, 'William Lewandowski', '0000111122223333', '0122', '000')
END