CREATE PROCEDURE [dbo].[usp_GetAllBooksByAuthor]
	 
AS
begin
	SELECT * from Book bk order by bk.AuthorLastName,bk.AuthorFirstName,bk.Title
end
