CREATE TABLE [dbo].[Product] (
	Uid UNIQUEIDENTIFIER NOT NULL,
	Title NVARCHAR(256) NULL,
	CreationDate DATETIME NOT NULL,
	ModifiedDate DATETIME NOT NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Uid] ASC)
);