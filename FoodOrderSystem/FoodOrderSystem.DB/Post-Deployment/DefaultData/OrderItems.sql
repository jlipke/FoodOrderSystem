BEGIN
	DECLARE @UserId UNIQUEIDENTIFIER;
	DECLARE @OrderId UNIQUEIDENTIFIER;
	DECLARE @MenuItemId UNIQUEIDENTIFIER;

	SELECT @UserId = Id FROM tblUser
	WHERE Email = 'lewandowski.william@gmail.com';

	SELECT @OrderId = Id FROM tblOrder
	WHERE UserId = @UserId;

	SELECT @MenuItemId = Id FROM tblMenuItem
	WHERE ItemName = 'Cheese Pizza';

	INSERT INTO [dbo].[tblOrderItem] (Id, OrderId, MenuItemId)
	VALUES
		(NEWID(), @OrderId, @MenuItemId)
END