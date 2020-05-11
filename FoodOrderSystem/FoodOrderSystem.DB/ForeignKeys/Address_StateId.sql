ALTER TABLE [dbo].[tblUserAddress]
	ADD CONSTRAINT [Address_StateId]
	FOREIGN KEY (StateId)
	REFERENCES [tblState] (Id)
