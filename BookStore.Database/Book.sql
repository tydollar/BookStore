CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Publisher] Varchar(256),
	[Title] Varchar(256),
	[AuthorLastName] Varchar(256),
	[AuthorFirstName] Varchar(256),
	[Price] decimal

)
