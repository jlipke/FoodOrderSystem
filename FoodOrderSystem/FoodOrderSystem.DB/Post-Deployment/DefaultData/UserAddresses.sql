BEGIN
	DECLARE @AddressUserId UNIQUEIDENTIFIER;

	SELECT @AddressUserId = Id FROM tblUser
	WHERE Email = 'lewandowski.william@gmail.com';

	INSERT INTO [dbo].[tblUserAddress] (Id, UserId, Address, City, State, ZipCode)
	VALUES
		(NEWID(), @AddressUserId, '2222 E Evergreen Trail', 'Appleton', 'WI', '54913')

	SELECT @AddressUserId = Id FROM tblUser
	WHERE Email = 'lipke@gmail.com';

	INSERT INTO [dbo].[tblUserAddress] (Id, UserId, Address, City, State, ZipCode)
	VALUES
		(NEWID(), @AddressUserId, '3333 W Spruce Road', 'Appleton', 'WI', '54913')

	INSERT INTO [dbo].[tblUserAddress] (Id, UserId, Address, City, State, ZipCode)
	VALUES
		(NEWID(), @AddressUserId, '34 Knapp Street', 'Oshkosh', 'WI', '54901')

END